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

namespace Okul_Otomasyon
{
    public partial class FrmOgretmenler : Form
    {
        public FrmOgretmenler()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_ogretmenler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void ilekle()
        {
            SqlCommand komut = new SqlCommand("Select * from tbl_iller", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                cmbil.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }
        private void FrmOgretmenler_Load(object sender, EventArgs e)
        {
            listele();
            ilekle();
            
        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbil.Properties.Items.Clear();
            cmbilce.Text = "";
            SqlCommand komut = new SqlCommand("Select * from tbl_ilceler where sehir=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbil.SelectedIndex+1);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read()) 
            {
                cmbilce.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();

        }
    }
}
