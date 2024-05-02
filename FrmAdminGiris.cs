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

namespace YurtKayitSistemi
{
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        // SQL bağlantısı için bir nesne oluşturulur
        SqlBaglantim bgl = new SqlBaglantim();

        // Giriş yap butonuna tıklandığında çalışacak olay
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            // SQL sorgusu oluşturulur: Veritabanında giriş yapılacak olan yönetici adı ve şifre kontrol edilir
            SqlCommand komut = new SqlCommand("select * from Admin where YöneticiAd=@p1 and YöneticiSifre=@p2", bgl.baglanti());

            // Parametreler atanır: Kullanıcı tarafından girilen kullanıcı adı ve şifre
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);

            // SQL sorgusu çalıştırılır ve sonuç SqlDataReader nesnesine aktarılır
            SqlDataReader oku = komut.ExecuteReader();

            // Eğer SqlDataReader nesnesi veri içeriyorsa, yani kullanıcı adı ve şifre doğruysa
            if (oku.Read())
            {
                // Ana form nesnesi oluşturulur ve gösterilir
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();
                // Giriş formu gizlenir
                this.Hide();
            }
            else
            {
                // Kullanıcıya hatalı giriş bilgisi mesajı gösterilir
                MessageBox.Show("Hatalı kullanıcı adı ya da şifre");
                // Kullanıcı adı ve şifre alanları temizlenir, odaklanma kullanıcı adı alanına verilir
                TxtKullaniciAd.Clear();
                TxtSifre.Clear();
                TxtKullaniciAd.Focus();
            }
            // Bağlantı kapatılır
            bgl.baglanti().Close();
        }
    }
}