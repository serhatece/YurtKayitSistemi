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
    public partial class FrmGider : Form
    {
        public FrmGider()
        {
            InitializeComponent();
        }

        // SqlBağlantim sınıfından bir örnek oluşturulur
        SqlBaglantim bgl = new SqlBaglantim();

        // Kaydet butonuna tıklandığında çalışacak olay
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Giderler tablosuna veri eklemek için SQL komutu oluşturulur
                SqlCommand komut = new SqlCommand("insert into Giderler (Elektrik, Su, Dogalgaz, internet, Gıda, Personel, Diger) Values (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", bgl.baglanti());

                // Parametreler eklenir
                komut.Parameters.AddWithValue("@p1", TxtElektrik.Text);
                komut.Parameters.AddWithValue("@p2", TxtSu.Text);
                komut.Parameters.AddWithValue("@p3", TxtDogalgaz.Text);
                komut.Parameters.AddWithValue("@p4", TxtInternet.Text);
                komut.Parameters.AddWithValue("@p5", TxtGida.Text);
                komut.Parameters.AddWithValue("@p6", TxtPersonel.Text);
                komut.Parameters.AddWithValue("@p7", TxtDiger.Text);

                // Komut çalıştırılır ve veritabanına veri eklenir
                komut.ExecuteNonQuery();

                // Bağlantı kapatılır
                bgl.baglanti().Close();

                // Kullanıcıya bilgi mesajı gösterilir
                MessageBox.Show("Gider Kayıtları Eklendi");

                // TextBox'lar temizlenir
                Temizle();
            }
            catch (Exception)
            {
                // Hata durumunda kullanıcıya bilgi mesajı gösterilir
                MessageBox.Show("Gider Kayıtları Eklenemedi, Tekrar Deneyiniz!");
            }
        }

        private void Temizle()
        {
            TxtElektrik.Clear();
            TxtSu.Clear();
            TxtDogalgaz.Clear();
            TxtInternet.Clear();
            TxtGida.Clear();
            TxtElektrik.Clear();
            TxtDiger.Clear();
        }
    }
}
