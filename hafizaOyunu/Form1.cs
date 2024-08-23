using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace hafizaOyunu
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=DESKTOP-GI5M6IP\\SQLEXPRESS;Initial Catalog=hafizaOyunu;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void cb4_CheckedChanged(object sender, EventArgs e)
        {
            if (cb4.Checked)
            {
                cb6.Checked = false;
                cb8.Checked = false;
            }
        }

        private void cb6_CheckedChanged(object sender, EventArgs e)
        {
            if (cb6.Checked)
            {
                cb4.Checked = false;
                cb8.Checked = false;
            }
        }

        private void cb8_CheckedChanged(object sender, EventArgs e)
        {
            if (cb8.Checked)
            {
                cb4.Checked = false;
                cb6.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;

            if (string.IsNullOrEmpty(kullaniciAdi))
            {
                MessageBox.Show("Kullanıcı adı boş olamaz.");
                return;
            }

            string query = "INSERT INTO kullanici (kullaniciAdi) VALUES (@kullaniciAdi)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı adı başarıyla kaydedildi.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }

            if (cb4.Checked)
                {
                    Form2 form2 = new Form2();
                    form2.Show();

                }
                else if (cb6.Checked)
                {
                    Form3 form3 = new Form3();
                    form3.Show();

                }
                else if (cb8.Checked)
                {
                    Form4 form4 = new Form4();
                    form4.Show();

                }
                else
                {
                    MessageBox.Show("Lütfen bir seçenek seçin.");
                }
            }

            private void button2_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

            private void Form1_Load(object sender, EventArgs e)
            {

            }
        }
    }

