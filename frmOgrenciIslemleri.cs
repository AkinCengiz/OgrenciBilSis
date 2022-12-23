using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciBilSis
{
    public partial class frmOgrenciIslemleri : Form
    {
        public frmOgrenciIslemleri()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private DataSet1TableAdapters.DataTable1TableAdapter dsAdapter =
            new DataSet1TableAdapters.DataTable1TableAdapter();
        private void btnSil_Click(object sender, EventArgs e)
        {
            dsAdapter.OgrenciSil(int.Parse(txtOgrenciId.Text));
            OgrenciListele(dsAdapter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Temizle()
        {
            txtOgrenciAd.Clear();
            txtOgrenciSoyad.Clear();
            txtOgrenciId.Clear();
            rdbErkek.Checked = true;
            rdbKiz.Checked = false;
        }
        private void frmOgrenciIslemleri_Load(object sender, EventArgs e)
        {
            
            OgrenciListele(dsAdapter);
            KulupDoldur();
        }

        void KulupDoldur()
        {
            cmbKulup.DataSource = tbl_KuluplerTableAdapter.KulupListele();
            cmbKulup.ValueMember = tbl_KuluplerTableAdapter.KulupListele().KulupIdColumn.ToString();
            cmbKulup.DisplayMember = tbl_KuluplerTableAdapter.KulupListele().KulupAdColumn.ToString();
        }

        private void OgrenciListele(DataSet1TableAdapters.DataTable1TableAdapter dsAdapter)
        {
            dataGridView1.DataSource = dsAdapter.OgrenciListele();
            Temizle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            dsAdapter.OgrenciEkle(txtOgrenciAd.Text, txtOgrenciSoyad.Text,byte.Parse(cmbKulup.SelectedValue.ToString()),
                (rdbKiz.Checked) ? rdbKiz.Text : rdbErkek.Text);
            OgrenciListele(dsAdapter);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            OgrenciListele(dsAdapter);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOgrenciId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtOgrenciAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtOgrenciSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbKulup.Text=dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Erkek")
            {
                rdbErkek.Checked = true;
            }
            else
            {
                rdbKiz.Checked = true;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            dsAdapter.OgrenciGuncelle(txtOgrenciAd.Text, txtOgrenciSoyad.Text,
                (rdbKiz.Checked == true) ? rdbKiz.Text : rdbErkek.Text, byte.Parse(cmbKulup.SelectedValue.ToString()),
                int.Parse(txtOgrenciId.Text));
            OgrenciListele(dsAdapter);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAra_Click(object sender, EventArgs e)
        {

        }
    }
}