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
    public partial class FrmGiderGuncelle : Form
    {
        public FrmGiderGuncelle()
        {
            InitializeComponent();
        }

        // Değişkenler form dışından da erişilebilir olacak şekilde public olarak tanımlanır
        public string elektrik, su, dogalgaz, gida, diger, internet, personel, id;

        // Güncelle butonuna tıklandığında çalışacak olay
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Giderler tablosundaki verileri güncellemek için SQL komutu oluşturulur
                SqlCommand komut = new SqlCommand("update Giderler set Elektrik=@p1, Su=@p2, Dogalgaz=@p3, internet=@p4, Gıda=@p5, Personel=@p6, Diger=@p7 where Odemeid=@p8", bgl.baglanti());

                // Parametreler eklenir
                komut.Parameters.AddWithValue("@p8", TxtGiderid.Text);
                komut.Parameters.AddWithValue("@p1", TxtElektrik.Text);
                komut.Parameters.AddWithValue("@p2", TxtSu.Text);
                komut.Parameters.AddWithValue("@p3", TxtDogalgaz.Text);
                komut.Parameters.AddWithValue("@p4", TxtInternet.Text);
                komut.Parameters.AddWithValue("@p5", TxtGida.Text);
                komut.Parameters.AddWithValue("@p6", TxtPersonel.Text);
                komut.Parameters.AddWithValue("@p7", TxtDiger.Text);

                // Komut çalıştırılır ve veritabanı güncellenir
                komut.ExecuteNonQuery();

                // Bağlantı kapatılır
                bgl.baglanti().Close();

                // Kullanıcıya bilgi mesajı gösterilir
                MessageBox.Show("Gider Kayıtları Güncellendi");
            }
            catch (Exception)
            {
                // Hata durumunda kullanıcıya bilgi mesajı gösterilir
                MessageBox.Show("Gider Kayıtları Güncellenemedi!!! Tekrar Deneyiniz");
            }
        }

        // Sql bağlantısı için bir nesne oluşturulur
        SqlBaglantim bgl = new SqlBaglantim();


        // Form yüklendiğinde çalışacak olay
        private void FrmGiderGuncelle_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde, belirtilen değişkenlerin değerleri ilgili metin kutularına atanır
            TxtGiderid.Text = id;
            TxtElektrik.Text = elektrik;
            TxtGida.Text = gida;
            TxtSu.Text = su;
            TxtPersonel.Text = personel;
            TxtInternet.Text = internet;
            TxtDogalgaz.Text = dogalgaz;
            TxtDiger.Text = diger;
        }
    }
}
