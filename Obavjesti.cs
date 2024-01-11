using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
             var lista =  data.nePostujuRadnoVrijeme(data.firme[comboBox1.SelectedIndex+1]);
            dataGridView1.Rows.Clear();
            foreach (var item in lista)
            {
                Zaposlenik zaposlenik = item.Second as Zaposlenik;
                dataGridView1.Rows.Add( item.First, zaposlenik.ime, zaposlenik.prezime, data.radniZapisi[(int)item.First].vrijeme.ToString(), item.Third);  
            }
            
        }
    }
}
