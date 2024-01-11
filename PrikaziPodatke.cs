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
    public partial class PrikaziPodatke : Form
    {
        void UpdateData()
        {
            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM firma", db.GetConnection()))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;

                }
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    comboBox1.Items.Clear();
                    while (reader != null && reader.Read())
                    {
                        comboBox1.Items.Add(reader["naziv"]);
                    }
                }
            }
            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM zaposlenik", db.GetConnection()))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView2.DataSource = dataTable;
                }
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    comboBox2.Items.Clear();
                    while (reader != null && reader.Read())
                    {
                        comboBox2.Items.Add(reader["ime"] + " " + reader["prezime"]);
                    }
                }
            }
            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM radniZapis", db.GetConnection()))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView3.DataSource = dataTable;
                }
            }
        }
        public PrikaziPodatke()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker3.Format = DateTimePickerFormat.Time;
            dateTimePicker3.ShowUpDown = true;
            dateTimePicker4.Format = DateTimePickerFormat.Time;
            dateTimePicker4.ShowUpDown = true;
        }

        private void PrikaziPodatke_Load(object sender, EventArgs e)
        {
            UpdateData();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Insert into firma
            using (SQLiteCommand command = new SQLiteCommand("INSERT INTO firma (naziv, ulazPocetak, ulazKraj, izlazPocetak, izlazKraj) VALUES (@naziv, @ulazPocetak, @ulazKraj, @izlazPocetak, @izlazKraj)", db.GetConnection()))
            {
                command.Parameters.AddWithValue("@naziv", textBox1.Text);
                command.Parameters.AddWithValue("@ulazPocetak", dateTimePicker1.Value.ToString("HH:mm"));
                command.Parameters.AddWithValue("@ulazKraj", dateTimePicker2.Value.ToString("HH:mm"));
                command.Parameters.AddWithValue("@izlazPocetak", dateTimePicker3.Value.ToString("HH:mm"));
                command.Parameters.AddWithValue("@izlazKraj", dateTimePicker4.Value.ToString("HH:mm"));
                command.ExecuteNonQuery();
            }
            UpdateData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SQLiteCommand command = new SQLiteCommand("INSERT INTO zaposlenik (ime, prezime, firma) VALUES (@ime, @prezime, @firma)", db.GetConnection()))
            {
                command.Parameters.AddWithValue("@ime", textBox2.Text);
                command.Parameters.AddWithValue("@prezime", textBox3.Text);
                command.Parameters.AddWithValue("@firma", comboBox1.SelectedIndex+1);
                command.ExecuteNonQuery();
            }
            UpdateData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SQLiteCommand command = new SQLiteCommand("INSERT INTO radniZapis (zaposlenik, vrijeme) VALUES (@zaposlenik, @vrijeme)", db.GetConnection()))
            {
                command.Parameters.AddWithValue("@zaposlenik", comboBox2.SelectedIndex+1);
                command.Parameters.AddWithValue("@vrijeme", dateTimePicker5.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                command.ExecuteNonQuery();
            }
            UpdateData();
        }
    }
}
