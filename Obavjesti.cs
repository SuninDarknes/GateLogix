using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace GateLogix
{
    public partial class Obavjesti : Form
    {
        GateLogixData data = new GateLogixData();
        public Obavjesti()
        {
            InitializeComponent();
        }

        private void Obavjesti_Load(object sender, EventArgs e)
        {
            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM firma", db.GetConnection()))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        comboBox1.Items.Add(reader["naziv"]);
                    }
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            List<Zaposlenik> neZaposleniki = data.firme[comboBox1.SelectedIndex + 1].nePostujuRadnoVrijeme(out List<string> razlog, out List<RadniZapis> zapis);
            label2.Text = "Ukupno: " + neZaposleniki.Count;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < neZaposleniki.Count; i++)
            {
                dataGridView1.Rows.Add(zapis[i].id, neZaposleniki[i].ime, neZaposleniki[i].prezime, zapis[i].vrijeme.ToString(), razlog[i]);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dataGridView1.Rows.Clear();
                int sveUkupno = 0;
                foreach (Firma firma in data.firme.Values)
                {
                    List<Zaposlenik> neZaposleniki = firma.nePostujuRadnoVrijeme(out List<string> razlog, out List<RadniZapis> zapis);
                    sveUkupno += neZaposleniki.Count;
                    for (int i = 0; i < neZaposleniki.Count; i++)
                    {
                        dataGridView1.Rows.Add(zapis[i].id, neZaposleniki[i].ime, neZaposleniki[i].prezime, zapis[i].vrijeme.ToString(), razlog[i]);
                    }
                }

                label2.Text = "Ukupno: " + sveUkupno;
            } else
            {
                dataGridView1.Rows.Clear();
            }
        }
    }
}
