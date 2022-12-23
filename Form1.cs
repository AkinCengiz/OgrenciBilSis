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

namespace OgrenciBilSis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private DatabaseConnectionSentence _connection = new DatabaseConnectionSentence();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select OgrAd, OgrSoyad from tbl_Ogrenciler where OgrId=@Id",
                _connection.DbConnection());
            command.Parameters.AddWithValue("@Id", txtId.Text);
            string adSoyad;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                adSoyad = reader[0] + " " + reader[1];
            }
            else
            {
                adSoyad = "";
                MessageBox.Show("Hatalı öğrenci seçildi...");
            }
            reader.Close();
            _connection.DbConnection().Close();

            frmOgrenciNotlar ogrenciNotlar = new frmOgrenciNotlar();
            ogrenciNotlar.ogrenciId = txtId.Text;
            ogrenciNotlar.Text += " - Öğrenci No: " + txtId.Text + " - Öğrenci Adı Soyadı : " + adSoyad.ToString();
            ogrenciNotlar.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmOgretmen ogretmenForm = new frmOgretmen();
            ogretmenForm.Show();
            this.Hide();
        }
    }
}
