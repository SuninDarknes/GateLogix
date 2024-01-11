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
                        + "CREATE TABLE radniZapis (id INTEGER PRIMARY KEY AUTOINCREMENT, zaposlenik INTEGER, vrijeme datetime);";
                    SQLiteCommand command = new SQLiteCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
                else
                {
                    connection = new SQLiteConnection("Data Source=GateLogix.db");
                    connection.Open();
                }
            }
            return connection;
        }
    }
    class Zaposlenik
    {
        public string ime { get; }
        public string prezime { get; }
        public Firma firma { get; }
        public Zaposlenik(string ime, string prezime, Firma firma)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.firma = firma;
        }

    }
    class RadniZapis
    {
        public Zaposlenik zaposlenik { get; }
        public DateTime vrijeme { get; }
        public bool ulaz { get; }
        public RadniZapis(Zaposlenik zaposlenik, DateTime vrijeme)
        {
            this.zaposlenik = zaposlenik;
            this.vrijeme = vrijeme;
        }

    }
    class Firma
    {
        public string naziv { get; }
        public DateTime ulazPocetak { get; }
        public DateTime ulazKraj { get; }
        public DateTime izlazPocetak { get; }
        public DateTime izlazKraj { get; }
        public Firma(string naziv, DateTime ulazPocetak, DateTime ulazKraj, DateTime izlazPocetak, DateTime izlazKraj)
        {
            this.naziv = naziv;
            this.ulazPocetak = ulazPocetak;
            this.ulazKraj = ulazKraj;
            this.izlazPocetak = izlazPocetak;
            this.izlazKraj = izlazKraj;
        }
    }
    class GateLogixData
    {
        public Dictionary<int, Firma> firme { get; }
        public Dictionary<int, Zaposlenik> zaposlenici { get; }
        public Dictionary<int, RadniZapis> radniZapisi { get; }
       
        //Vraca listu zaposlenika koji ne postuju radno vrijeme
        //int, Zaposlenik, string
        public List<Triplet> nePostujuRadnoVrijeme(Firma firma)
        {
            List<Triplet> zaposlenici = new List<Triplet>();
            foreach (KeyValuePair<int, Zaposlenik> zaposlenik in this.zaposlenici)
            {
                if(zaposlenik.Value.firma != firma)
                
                    continue;
                
                bool ulaz = false;
                bool izlaz = false;
                int brojac = 0; 
                foreach (KeyValuePair<int, RadniZapis> radniZapis in radniZapisi)
                {
                    if (radniZapis.Value.zaposlenik == zaposlenik.Value)
                    {

                        if (brojac%2==0)
                        {
                            if(radniZapis.Value.vrijeme.TimeOfDay < zaposlenik.Value.firma.ulazPocetak.TimeOfDay)
                            zaposlenici.Add(new Triplet(radniZapis.Key, zaposlenik.Value, "Prerano došao"));
                            if(radniZapis.Value.vrijeme.TimeOfDay > zaposlenik.Value.firma.ulazKraj.TimeOfDay)
                                zaposlenici.Add(new Triplet(radniZapis.Key, zaposlenik.Value, "Kasni na posao"));
                        }
                        if (brojac % 2 == 1)
                        {
                            if(radniZapis.Value.vrijeme.TimeOfDay < zaposlenik.Value.firma.izlazPocetak.TimeOfDay)
                                zaposlenici.Add(new Triplet(radniZapis.Key, zaposlenik.Value, "Odlazi pre rano"));
                            if(radniZapis.Value.vrijeme.TimeOfDay > zaposlenik.Value.firma.izlazKraj.TimeOfDay)
                                zaposlenici.Add(new Triplet(radniZapis.Key, zaposlenik.Value, "Odlazi kasno"));
                        }
                    }
                    brojac++;

                }
                
            }
            return zaposlenici;
        }
        public List<Triplet> nedovoljnoSatiuTjednu(Firma firma, DateTime tjedan)
        {
            while (tjedan.DayOfWeek != DayOfWeek.Sunday)
                tjedan = tjedan.AddDays(-1);

            List<Triplet> zaposlenici = new List<Triplet>();
            foreach (KeyValuePair<int, Zaposlenik> zaposlenik in this.zaposlenici)
            {
                if (zaposlenik.Value.firma != firma)
                    continue;
                List<RadniZapis> mojiZapisi = new List<RadniZapis>();
                foreach (KeyValuePair<int, RadniZapis> radniZapis in radniZapisi)
                    if (radniZapis.Value.zaposlenik == zaposlenik.Value)
                        mojiZapisi.Add(radniZapis.Value);



                TimeSpan sati = new TimeSpan(0, 0, 0);
                for (int i = 0; i < mojiZapisi.Count - 1; i += 2)
                {
                    if (mojiZapisi[i].vrijeme.Date >= tjedan && mojiZapisi[i].vrijeme.Date <= tjedan.AddDays(7))
                    {
                        sati += mojiZapisi[i + 1].vrijeme - mojiZapisi[i].vrijeme;
                    }
                }

                //if (sati.TotalHours < 40)

                zaposlenici.Add(new Triplet(zaposlenik.Value, sati.TotalHours, 0));

            }
            return zaposlenici;
        }
        public List<Zaposlenik> nedovoljnoSatiuTjednuList(Firma firma, DateTime tjedan)
        {
            while (tjedan.DayOfWeek != DayOfWeek.Sunday)
                tjedan = tjedan.AddDays(-1);

            List<Zaposlenik> zaposlenici = new List<Zaposlenik>();
            foreach (KeyValuePair<int, Zaposlenik> zaposlenik in this.zaposlenici)
            {
                if (zaposlenik.Value.firma != firma)
                    continue;
                List<RadniZapis> mojiZapisi = new List<RadniZapis>();
                foreach (KeyValuePair<int, RadniZapis> radniZapis in radniZapisi)
                    if (radniZapis.Value.zaposlenik == zaposlenik.Value)
                        mojiZapisi.Add(radniZapis.Value);



                TimeSpan sati = new TimeSpan(0, 0, 0);
                for (int i = 0; i < mojiZapisi.Count - 1; i += 2)
                {
                    if (mojiZapisi[i].vrijeme.Date >= tjedan && mojiZapisi[i].vrijeme.Date <= tjedan.AddDays(7))
                    {
                        sati += mojiZapisi[i + 1].vrijeme - mojiZapisi[i].vrijeme;
                    }
                }

                if (sati.TotalHours < 40)
                    zaposlenici.Add(zaposlenik.Value);

            }
            return zaposlenici;
        }


        public GateLogixData()
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
                        zaposlenici.Add(reader.GetInt32(0), new Zaposlenik(reader.GetString(1),reader.GetString(2), firme[reader.GetInt32(3)]));
                        
                    }
                }
            }

            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM radniZapis", db.GetConnection()))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        radniZapisi.Add(reader.GetInt32(0), new RadniZapis(zaposlenici[reader.GetInt32(1)], reader.GetDateTime(2)));
                        
                    }
                }
            }
        }


    }
}
