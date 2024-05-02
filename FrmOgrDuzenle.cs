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
    public partial class FrmOgrDuzenle : Form
    {
        public FrmOgrDuzenle()
        {
            InitializeComponent();
        }

        // Formun dışından erişilebilir hale getirilmiş değişkenler
        public string id, ad, soyad, TC, telefon, dogum, bolum, mail, odano, veliad, velitel, adres;

        // SQL bağlantısı için bir nesne oluşturulur
        SqlBaglantim bgl = new SqlBaglantim();

        // Güncelle butonuna tıklandığında çalışacak olay
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Ogrenci tablosundaki verileri güncellemek için SQL komutu oluşturulur
                SqlCommand komut = new SqlCommand("update Ogrenci set OgrAd=@p2, OgrSoyad=@p3, OgrTC=@p4, OgrTelefon=@p5, OgrDogum=@p6, OgrBolum=@p7, OgrMail=@p8, OgrOdaNo=@p9, OgrVeliAdSoyad=@p10, OgrVeliTelefon=@p11, OgrVeliAdres=@p12 where Ogrid=@p1", bgl.baglanti());

                // Parametreler eklenir
                komut.Parameters.AddWithValue("@p1", TxtOgrid.Text);
                komut.Parameters.AddWithValue("@p2", TxtOgrAd.Text);
                komut.Parameters.AddWithValue("@p3", TxtOgrSoyad.Text);
                komut.Parameters.AddWithValue("@p4", MskTC.Text);
                komut.Parameters.AddWithValue("@p5", MskOgrTelefon.Text);
                komut.Parameters.AddWithValue("@p6", MskDogum.Text);
                komut.Parameters.AddWithValue("@p7", CmbBolum.Text);
                komut.Parameters.AddWithValue("@p8", TxtMail.Text);
                komut.Parameters.AddWithValue("@p9", CmbOdaNo.Text);
                komut.Parameters.AddWithValue("@p10", TxtVeliAdSoyad.Text);
                komut.Parameters.AddWithValue("@p11", MskVeliTelefon.Text);
                komut.Parameters.AddWithValue("@p12", RchAdres.Text);

                // Komut çalıştırılır ve veritabanı güncellenir
                komut.ExecuteNonQuery();

                // Bağlantı kapatılır
                bgl.baglanti().Close();

                // Kullanıcıya bilgi mesajı gösterilir
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Güncellendi");
            }
            catch (Exception)
            {
                // Hata durumunda kullanıcıya bilgi mesajı gösterilir
                MessageBox.Show("Kayıt Güncellenemedi! Tekrar Deneyiniz");
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komutsil = new SqlCommand("delete from Ogrenci where Ogrid=@k1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@k1", TxtOgrid.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Silindi");
                Temizle();
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Silinemedi, Tekrar Deneyiniz!!!");
            }

            // Odanan Aktif Ogrenci Sayisını Azaltma
            SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif-1 where OdaNo=@oda", bgl.baglanti());
            komutoda.Parameters.AddWithValue("@oda", CmbOdaNo.Text);
            komutoda.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        // Form yüklendiğinde çalışacak olay
        private void FrmOgrDuzenle_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde, belirtilen değişkenlerin değerleri ilgili metin kutularına atanır
            TxtOgrid.Text = id;
            TxtOgrAd.Text = ad;
            TxtOgrSoyad.Text = soyad;
            MskTC.Text = TC;
            MskOgrTelefon.Text = telefon;
            MskDogum.Text = dogum;
            CmbBolum.Text = bolum;
            TxtMail.Text = mail;
            CmbOdaNo.Text = odano;
            TxtVeliAdSoyad.Text = veliad;
            MskVeliTelefon.Text = velitel;
            RchAdres.Text = adres;
        }

        private void Temizle()
        {
            TxtOgrid.Clear();
            TxtOgrAd.Clear();
            TxtOgrSoyad.Clear();
            MskTC.Clear();
            MskOgrTelefon.Clear();
            MskDogum.Clear();
            TxtMail.Clear();
            TxtVeliAdSoyad.Clear();
            MskVeliTelefon.Clear();
            RchAdres.Clear();
        }
    }
}