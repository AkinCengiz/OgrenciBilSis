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
    public partial class frmOgrenciNotlar : Form
    {
        public frmOgrenciNotlar()
        {
            InitializeComponent();
        }

        public string ogrenciId;
        private DatabaseConnectionSentence _connection = new DatabaseConnectionSentence();
        private void frmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                "select tbl_Dersler.DersAd as Ders, Sinav1 as [Sınav 1], Sinav2 as [Sınav 2], Sinav3 as [Sınav 3], Proje as Proje,  Ortalama as Ortalama, Durum from tbl_Notlar inner join tbl_Dersler on tbl_Notlar.DersId = tbl_Dersler.DersId where OgrID = @ID",
                _connection.DbConnection());
            command.Parameters.AddWithValue("@ID", ogrenciId);
            //Datagrid öğrenci not bilgileri ile dolduruluyor.
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}
