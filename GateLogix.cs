using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.ComponentModel.Design;

namespace GateLogix
{
    public partial class GateLogix : Form
    {

        public GateLogix()
        {
            InitializeComponent();

        }

        private void GateLogix_Load(object sender, EventArgs e)
        {
            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM zaposlenik", db.GetConnection()))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        comboBox1.Items.Add(reader["ime"]+ " " + reader["prezime"]);
                    }
                }
            }


        }
        private void alertiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Obavjesti().Show();
        }
        private void mjenjanjeRadnogVremenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MjenjanjeRadnogVremena().Show();
        }

        private void generatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
             new GeneratorPodatki().Show();
        }

        private void prikazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PrikaziPodatke().Show();
        }
        private void nedovoljnoSatiUTjednuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NedovoljnoSati().Show();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox1.Focused)
                return;
            
            textBox1.Text = (comboBox1.SelectedIndex+1).ToString();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Focused) return;
            try
            {
                comboBox1.SelectedIndex = Int32.Parse(textBox1.Text)-1;
            }
            catch
            {
                comboBox1.SelectedIndex = -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM zaposlenik WHERE id = @id", db.GetConnection()))
            {
                command.Parameters.AddWithValue("@id", textBox1.Text);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader != null && reader.Read())
                    {
                        comboBox1.SelectedIndex = Int32.Parse(textBox1.Text) - 1;
                    }
                    else
                    {
                        MessageBox.Show("Ne postoji zaposlenik s tim ID-om!");
                    }
                }
            }
            using (SQLiteCommand command = new SQLiteCommand("INSERT INTO radniZapis (zaposlenik, vrijeme) VALUES (@zaposlenik, @vrijeme)", db.GetConnection()))
            {
                command.Parameters.AddWithValue("@zaposlenik", textBox1.Text);
                command.Parameters.AddWithValue("@vrijeme", dateTimePicker1.Value);
                command.ExecuteNonQuery();
            }
        }
    }

}
