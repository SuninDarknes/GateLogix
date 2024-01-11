using System;
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
            dataGridView1.Rows.Clear();
            Firma firma= data.firme[comboBox1.SelectedIndex + 1];
            List<Triplet> triplets = data.nedovoljnoSatiuTjednu(firma, dateTimePicker1.Value);
            foreach (Triplet triplet in triplets)
            {
                dataGridView1.Rows.Add((triplet.First as Zaposlenik).ime, (triplet.First as Zaposlenik).prezime, triplet.Second);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Firma firma = data.firme[comboBox1.SelectedIndex + 1];
            List<Triplet> triplets = data.nedovoljnoSatiuTjednu(firma, dateTimePicker1.Value);
            foreach (Triplet triplet in triplets)
            {
                dataGridView1.Rows.Add((triplet.First as Zaposlenik).ime, (triplet.First as Zaposlenik).prezime, triplet.Second);
            }
        }
    }
}
