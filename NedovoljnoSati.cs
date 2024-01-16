using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace GateLogix
{
    public partial class NedovoljnoSati : Form
    {
        GateLogixData data = new GateLogixData();
        public NedovoljnoSati()
        {
            InitializeComponent();
        }
        private void NedovoljnoSati_Load(object sender, EventArgs e)
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
            prikazPodataka();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            prikazPodataka();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            prikazPodataka();
        }
        private void prikazPodataka()
        {
            dataGridView1.Rows.Clear();
            Firma firma = data.firme[comboBox1.SelectedIndex + 1];

            List<Zaposlenik> zaposlenici = firma.satiuTjednu(dateTimePicker1.Value, out List<TimeSpan> sati);
            for (int i=0;i< zaposlenici.Count;i++)
            {
                if(checkBox1.Checked)
                    dataGridView1.Rows.Add(zaposlenici[i].ime, zaposlenici[i].prezime, sati[i].TotalHours);
                else if(sati[i].TotalHours <40)
                    dataGridView1.Rows.Add(zaposlenici[i].ime, zaposlenici[i].prezime, sati[i].TotalHours);
            }
        }


    }
}
