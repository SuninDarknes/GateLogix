using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace GateLogix
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GateLogix());
        }
    }
    class db
    {
        public static event EventHandler Commit;
        private static SQLiteConnection connection = null;
        public static SQLiteConnection GetConnection()
        {
            if (connection == null)
            {
                if (!System.IO.File.Exists("GateLogix.db"))
                {
                    connection = new SQLiteConnection("Data Source=GateLogix.db");
                    connection.Open();
                    string sql = "CREATE TABLE firma (id INTEGER PRIMARY KEY AUTOINCREMENT,naziv string, ulazPocetak time,ulazKraj time,izlazPocetak time,izlazKraj time);"
                        + "CREATE TABLE zaposlenik (id INTEGER PRIMARY KEY AUTOINCREMENT, ime string, prezime string, firma INTEGER);"
                        + "CREATE TABLE radniZapis (id INTEGER PRIMARY KEY AUTOINCREMENT, zaposlenik INTEGER, vrijeme datetime, ulaz BOOLEAN);";
                    SQLiteCommand command = new SQLiteCommand(sql, connection);
                    command.ExecuteNonQuery();


                }
                else
                {
                    connection = new SQLiteConnection("Data Source=GateLogix.db");
                    connection.Open();
                }
                connection.Commit += (sender, e) =>
                {
                    Commit?.Invoke(sender, e);
                };
            }


            return connection;
        }
    }
    class RadniZapis
    {
        public int id { get; }
        public Zaposlenik zaposlenik { get; }
        public DateTime vrijeme { get; }
        public bool ulaz { get; }
        public RadniZapis(int id,Zaposlenik zaposlenik, DateTime vrijeme, bool ulaz)
        {
            this.id = id;
            this.zaposlenik = zaposlenik;
            this.vrijeme = vrijeme;
            this.ulaz = ulaz;
        }

    }
    class Zaposlenik : IComparable
    {
        public int id { get; }
        public string ime { get; }
        public string prezime { get; }
        public Firma firma { get; }
        public List<RadniZapis> radniZapisi { get; }

        public Zaposlenik(int id, string ime, string prezime, Firma firma)
        {
            this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.firma = firma;
            radniZapisi = new List<RadniZapis>();
        }
        public void dodajRadniZapis(RadniZapis radniZapis)
        {
            radniZapisi.Add(radniZapis);
        }
        public TimeSpan brojRadnihSati()
        {
            TimeSpan sati = new TimeSpan(0, 0, 0);
            RadniZapis ulazniZapis=null;
            foreach ( RadniZapis radniZapis in radniZapisi)
            {
                if (ulazniZapis == null && radniZapis.ulaz) ulazniZapis = radniZapis;
                else if(ulazniZapis !=null && !radniZapis.ulaz)
                {
                    sati += radniZapis.vrijeme - ulazniZapis.vrijeme;
                    ulazniZapis = null;
                }
            }

            return sati;
        }
        public TimeSpan brojRadnihSatiuTjednu(DateTime tjedan)
        {
            while (tjedan.DayOfWeek != DayOfWeek.Sunday)
                tjedan = tjedan.AddDays(-1);
            TimeSpan sati = new TimeSpan(0, 0, 0);
            RadniZapis ulazniZapis = null;
            foreach (RadniZapis radniZapis in radniZapisi)
            {

                if (ulazniZapis == null && radniZapis.ulaz && radniZapis.vrijeme.Date >= tjedan && radniZapis.vrijeme.Date <= tjedan.AddDays(7))
                    ulazniZapis = radniZapis;
                else if (ulazniZapis != null && !radniZapis.ulaz && radniZapis.vrijeme.Date >= tjedan && radniZapis.vrijeme.Date <= tjedan.AddDays(7))
                {
                    sati += radniZapis.vrijeme - ulazniZapis.vrijeme;

                    ulazniZapis = null;
                }
            }

            return sati;
        }

        public int CompareTo(object obj)
        {
            Zaposlenik zaposlenik = obj as Zaposlenik;
            if(zaposlenik.brojRadnihSati().TotalHours > brojRadnihSati().TotalHours)
            {
                return 1;
            } else if (zaposlenik.brojRadnihSati().TotalHours < brojRadnihSati().TotalHours)
            {
                return -1;
            } else
            {
                return 0;
            }
        }
    }

    class Firma
    {
        public int id { get; }
        public string naziv { get; }
        public DateTime ulazPocetak { get; }
        public DateTime ulazKraj { get; }
        public DateTime izlazPocetak { get; }
        public DateTime izlazKraj { get; }
        public List<Zaposlenik> zaposlenici { get; }
        public Firma(int id, string naziv, DateTime ulazPocetak, DateTime ulazKraj, DateTime izlazPocetak, DateTime izlazKraj)
        {
            this.id = id;
            this.naziv = naziv;
            this.ulazPocetak = ulazPocetak;
            this.ulazKraj = ulazKraj;
            this.izlazPocetak = izlazPocetak;
            this.izlazKraj = izlazKraj;
            zaposlenici = new List<Zaposlenik>();
        }
        public void dodajZaposlenika(Zaposlenik zaposlenik)
        {
            zaposlenici.Add(zaposlenik);
        }
        public List<Zaposlenik> nePostujuRadnoVrijeme(out List<string> razlog, out List<RadniZapis> zapis)
        {
            razlog = new List<string>();
            zapis = new List<RadniZapis>();
            List<Zaposlenik> neZaposleniki = new List<Zaposlenik>();
            foreach (Zaposlenik zaposlenik in zaposlenici)
            {
                foreach (RadniZapis radniZapis in zaposlenik.radniZapisi)
                {
                    bool grjesan = false;
                    if (radniZapis.ulaz)
                    {
                        if (radniZapis.vrijeme.TimeOfDay < zaposlenik.firma.ulazPocetak.TimeOfDay)
                        {
                            razlog.Add("Prerano došao");
                            grjesan = true;
                        } else if (radniZapis.vrijeme.TimeOfDay > zaposlenik.firma.ulazKraj.TimeOfDay)
                        {
                            razlog.Add("Kasni na posao");
                            grjesan = true;
                        }


                    } else if (!radniZapis.ulaz)
                    {
                        if (radniZapis.vrijeme.TimeOfDay < zaposlenik.firma.izlazPocetak.TimeOfDay)
                        {
                            razlog.Add("Odlazi pre rano");
                            grjesan = true;
                        } else if (radniZapis.vrijeme.TimeOfDay > zaposlenik.firma.izlazKraj.TimeOfDay)
                        {
                            razlog.Add("Odlazi kasno");
                            grjesan = true;
                        }
                    }
                    if (grjesan)
                    {
                        neZaposleniki.Add(zaposlenik);
                        zapis.Add(radniZapis);
                    }
                }
            }
            return neZaposleniki;
        }
        public List<Zaposlenik> nePostujuRadnoVrijeme()
        {
            return nePostujuRadnoVrijeme(out List<string> razlog, out List<RadniZapis> zapis);
        }


        public List<Zaposlenik> zaposlenikiKojiNemajuDovoljnoSatiuTjednu(DateTime tjedan)
        {
            List<Zaposlenik> zaposlenici = satiuTjednu(tjedan, out List<TimeSpan> sati);
            for (int i = 0;i<zaposlenici.Count;i++)
            {
                if (sati[i].TotalHours >= 40)
                    zaposlenici.RemoveAt(i);
            }
            
            return zaposlenici;
        }
        //od svakog zaposlenika
        public List<Zaposlenik> satiuTjednu(DateTime tjedan, out List<TimeSpan> sati)
        {
            sati = new List<TimeSpan>();
            List<Zaposlenik> zaposlenici = new List<Zaposlenik>();
            foreach (Zaposlenik zaposlenik in this.zaposlenici)
            {
                sati.Add( zaposlenik.brojRadnihSatiuTjednu(tjedan));
                if (sati.Last() < new TimeSpan(40, 0, 0))
                    zaposlenici.Add(zaposlenik);
            }
            return zaposlenici;

        }
    }
    class GateLogixData
    {
        public Dictionary<int, Firma> firme { get; private set; }
        public Dictionary<int, Zaposlenik> zaposlenici { get; private set; }
        public Dictionary<int, RadniZapis> radniZapisi { get; private set; }
       
        



        public void updateAllData()
        {
            firme = new Dictionary<int, Firma>();
            zaposlenici = new Dictionary<int, Zaposlenik>();
            radniZapisi = new Dictionary<int, RadniZapis>();

            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM firma", db.GetConnection()))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        firme.Add(reader.GetInt32(0), new Firma(
                            reader.GetInt32(0),
                           reader.GetString(1),
                            reader.GetDateTime(2),
                            reader.GetDateTime(3),
                             reader.GetDateTime(4),
                            reader.GetDateTime(5)
                        ));

                    }
                }
            }

            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM zaposlenik", db.GetConnection()))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        zaposlenici.Add(reader.GetInt32(0), new Zaposlenik(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), firme[reader.GetInt32(3)]));

                    }
                }
            }

            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM radniZapis", db.GetConnection()))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        radniZapisi.Add(reader.GetInt32(0), new RadniZapis(reader.GetInt32(0),zaposlenici[reader.GetInt32(1)], reader.GetDateTime(2), reader.GetBoolean(3)));

                    }
                }
            }
            foreach (var zaposlenik in zaposlenici)
            {
                zaposlenik.Value.firma.dodajZaposlenika(zaposlenik.Value);
            }
            foreach (var radniZapis in radniZapisi)
            {
                radniZapis.Value.zaposlenik.dodajRadniZapis(radniZapis.Value);
            }
        }

        public GateLogixData()
        {
            updateAllData();
            db.Commit += (sender, e) =>
            {
                updateAllData();
            };
        }


    }
}
