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
        private void RefreshData()
        {
            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM zaposlenik", db.GetConnection()))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    comboBox1.Items.Clear();
                    while (reader != null && reader.Read())
                    {
                        comboBox1.Items.Add(reader["ime"] + " " + reader["prezime"]);
                    }
                }
            }
        }
        private void RefreshData(object sender, FormClosedEventArgs e)
        {
            RefreshData();
        }

        private void GateLogix_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";

            RefreshData();


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
             GeneratorPodatki gp = new GeneratorPodatki();
            gp.Show();
            gp.FormClosed += RefreshData;

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
                        return;
                    }
                }
            }
            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM radniZapis WHERE zaposlenik = @id", db.GetConnection()))
            {
                command.Parameters.AddWithValue("@id", textBox1.Text);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    List<int> list = new List<int>();
                    while (reader != null && reader.Read())
                    {
                        list.Add(Int32.Parse(reader["id"].ToString()));
                    }
                    if (list.Count % 2 == 0 && sender == null)
                    {
                        MessageBox.Show("Zaposlenik nije na poslu!");
                        return;
                    } else if (list.Count % 2 == 1 && sender != null)
                    {
                        MessageBox.Show("Zaposlenik je već na poslu!");
                        return;
                    }
                }
            }
            using (SQLiteCommand command = new SQLiteCommand("INSERT INTO radniZapis (zaposlenik, vrijeme, ulaz) VALUES (@zaposlenik, @vrijeme, @ulaz)", db.GetConnection()))
            {
                command.Parameters.AddWithValue("@zaposlenik", textBox1.Text);
                command.Parameters.AddWithValue("@vrijeme", dateTimePicker1.Value);
                command.Parameters.AddWithValue("@ulaz", sender == null ? 0:1);
                command.ExecuteNonQuery();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1_Click(null, e);
        }

        private void objasniEnkapsulacijuUOOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Enkapsulacija je koncept u objektno orijentiranom programiranju (OOP) koji se odnosi na skrivanje unutarnjih detalja objekta i ograničavanje pristupa samo onim dijelovima koji su nužni za vanjsko korištenje objekta. Cilj enkapsulacije je zaštiti atribute i metode objekta kako bi se osigurala sigurnost, održavanje i promjene u budućnosti.\n\nPritisak na gumb OK vodi na primjer.", "Enkapsulacija u OOP", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("https://github.com/SuninDarknes/GateLogix/blob/main/Primjer.cs");
            }
        }
    }

}
