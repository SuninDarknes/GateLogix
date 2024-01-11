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
    public partial class MjenjanjeRadnogVremena : Form
    {
        public MjenjanjeRadnogVremena()
        {
            InitializeComponent();
        }

        private void MjenjanjeRadnogVremena_Load(object sender, EventArgs e)
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

            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker3.Format = DateTimePickerFormat.Time;
            dateTimePicker3.ShowUpDown = true;
            dateTimePicker4.Format = DateTimePickerFormat.Time;
            dateTimePicker4.ShowUpDown = true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM firma WHERE naziv = @naziv", db.GetConnection()))
            {
                command.Parameters.AddWithValue("@naziv", comboBox1.SelectedItem.ToString());
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        dateTimePicker1.Value = DateTime.Parse(reader["ulazPocetak"].ToString());
                        dateTimePicker2.Value = DateTime.Parse(reader["ulazKraj"].ToString());
                        dateTimePicker3.Value = DateTime.Parse(reader["izlazPocetak"].ToString());
                        dateTimePicker4.Value = DateTime.Parse(reader["izlazKraj"].ToString());
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteCommand command = new SQLiteCommand("UPDATE firma SET ulazPocetak = @ulazPocetak, ulazKraj = @ulazKraj, izlazPocetak = @izlazPocetak, izlazKraj = @izlazKraj WHERE naziv = @naziv", db.GetConnection()))
            {
                command.Parameters.AddWithValue("@ulazPocetak", dateTimePicker1.Value.ToString("HH:mm"));
                command.Parameters.AddWithValue("@ulazKraj", dateTimePicker2.Value.ToString("HH:mm"));
                command.Parameters.AddWithValue("@izlazPocetak", dateTimePicker3.Value.ToString("HH:mm"));
                command.Parameters.AddWithValue("@izlazKraj", dateTimePicker4.Value.ToString("HH:mm"));
                command.Parameters.AddWithValue("@naziv", comboBox1.SelectedItem.ToString());
                command.ExecuteNonQuery();
            }
        }
    }
}
