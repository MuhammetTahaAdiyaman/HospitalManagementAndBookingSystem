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
namespace Proje_Hastane
{
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void LnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit frmHastaKayit = new FrmHastaKayit(); ;
            frmHastaKayit.Show();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("select * from Tbl_Hastalar where HastaTC = @p1 and HastaSifre = @p2",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", MskTc.Text);
            komut1.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut1.ExecuteReader();
            if(dr.Read())
            {
                FrmHastaDetay frmHastaDetay = new FrmHastaDetay();  
                frmHastaDetay.tc = MskTc.Text;
                frmHastaDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC veya Şifre");
            }

            bgl.baglanti().Close();
        }
    }
}
