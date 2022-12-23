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
    public partial class frmKulupIslemleri : Form
    {
        public frmKulupIslemleri()
        {
            InitializeComponent();
        }

        public void KulupleriGetir()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from tbl_Kulupler", _connection.DbConnection());
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        void Temizle()
        {
            txtKulupAd.Clear();
            txtKulupId.Clear();
        }

        private DatabaseConnectionSentence _connection = new DatabaseConnectionSentence();
        private void frmKulupIslemleri_Load(object sender, EventArgs e)
        {
            txtKulupAd.Focus();
            KulupleriGetir();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            KulupleriGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into tbl_Kulupler (KulupAd) values (@Ad)",
                _connection.DbConnection());
            command.Parameters.AddWithValue("@Ad", txtKulupAd.Text);
            command.ExecuteNonQuery();
            _connection.DbConnection().Close();
            KulupleriGetir();
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtKulupId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtKulupAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("update tbl_Kulupler set KulupAd=@Ad where KulupId=@Id",
                _connection.DbConnection());
            command.Parameters.AddWithValue("@Ad", txtKulupAd.Text);
            command.Parameters.AddWithValue("@Id", txtKulupId.Text);
            command.ExecuteNonQuery();
            _connection.DbConnection().Close();
            KulupleriGetir();
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand command =
                new SqlCommand("delete from tbl_Kulupler where KulupId=@Id", _connection.DbConnection());
            command.Parameters.AddWithValue("@Id", txtKulupId.Text);
            command.ExecuteNonQuery();
            _connection.DbConnection().Close();
            KulupleriGetir();
            Temizle();
        }
    }
}
