using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OgrenciBilSis.DataSet1TableAdapters;

namespace OgrenciBilSis
{
    public partial class frmDersIslemleri : Form
    {
        public frmDersIslemleri()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.tbl_DerslerTableAdapter();
        void Listele(DataSet1TableAdapters.tbl_DerslerTableAdapter ds)
        {
            dataGridView1.DataSource = ds.DersListesi();
            Temizle();
        }

        void Temizle()
        {
            txtDersId.Clear();
            txtDersAd.Clear();
            txtDersAd.Focus();
        }
        private void frmDersIslemleri_Load(object sender, EventArgs e)
        {
            Listele(ds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtDersAd.Text);
            Listele(ds);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele(ds);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(txtDersAd.Text, byte.Parse(txtDersId.Text));
            Listele(ds);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtDersId.Text));
            Listele(ds);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDersId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
