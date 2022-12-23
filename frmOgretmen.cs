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
    public partial class frmOgretmen : Form
    {
        public frmOgretmen()
        {
            InitializeComponent();
        }

        private void frmOgretmen_Load(object sender, EventArgs e)
        {

        }

        private void btnKulupIslemleri_Click(object sender, EventArgs e)
        {
            frmKulupIslemleri kulupIslemleri = new frmKulupIslemleri();
            kulupIslemleri.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDersIslemleri_Click(object sender, EventArgs e)
        {
            frmDersIslemleri dersIslemleri = new frmDersIslemleri();
            dersIslemleri.Show();
        }
    }
}
