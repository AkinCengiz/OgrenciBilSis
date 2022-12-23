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
    public partial class frmSinavNotlari : Form
    {
        public frmSinavNotlari()
        {
            InitializeComponent();
        }

        private DataSet1TableAdapters.DataTable2TableAdapter dsAdapter = new DataTable2TableAdapter();
        private DataSet1TableAdapters.tbl_NotlarTableAdapter dtNotlar = new tbl_NotlarTableAdapter();
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        void DersDoldur()
        {
            tbl_DerslerTableAdapter tblAdapter = new tbl_DerslerTableAdapter();
            cmbDers.DataSource = tblAdapter.DersListesi();
            cmbDers.DisplayMember = tblAdapter.DersListesi().DersAdColumn.ToString();
            cmbDers.ValueMember = tblAdapter.DersListesi().DersIdColumn.ToString();
        }

        void OgrenciDoldur()
        {
            tbl_OgrencilerTableAdapter tblOgrenciler = new tbl_OgrencilerTableAdapter();
            cmbOgrenci.DataSource = tblOgrenciler.OgrenciGetir();
            cmbOgrenci.ValueMember = tblOgrenciler.OgrenciGetir().OgrIDColumn.ToString();
            cmbOgrenci.DisplayMember = tblOgrenciler.OgrenciGetir().OgrenciColumn.ToString();
        }
        void TumNotlariGetir(DataSet1TableAdapters.DataTable2TableAdapter ds)
        {
            dataGridView1.DataSource = ds.TumNotlariGetir();
        }
        private void frmSinavNotlari_Load(object sender, EventArgs e)
        {
            OgrenciDoldur();
            DersDoldur();
            TumNotlariGetir(dsAdapter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dtNotlar.NotlariGetir(int.Parse(cmbOgrenci.SelectedValue.ToString()));
        }

        private int NotId;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NotId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            cmbDers.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbOgrenci.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            txtOrtalama.Text = ((Convert.ToInt16(txtSınav1.Text) + Convert.ToInt16(txtSınav2.Text) +
                                 Convert.ToInt16(txtSınav3.Text) + Convert.ToInt16(txtProje.Text)) / 4).ToString();
            txtDurum.Text = (Convert.ToInt16(txtOrtalama.Text) > 60) ? "1" : "0";
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            dtNotlar.NotGuncelle(byte.Parse(cmbDers.SelectedValue.ToString()),
                int.Parse(cmbOgrenci.SelectedValue.ToString()), byte.Parse(txtSınav1.Text), byte.Parse(txtSınav2.Text),
                byte.Parse(txtSınav3.Text), byte.Parse(txtProje.Text), decimal.Parse(txtOrtalama.Text),
                (txtDurum.Text == "1") ? true : false, NotId);
            TumNotlariGetir(dsAdapter);
        }
    }
}