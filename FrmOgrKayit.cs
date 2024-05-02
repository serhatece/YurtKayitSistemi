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
    public partial class FrmOgrKayit : Form
    {
        public FrmOgrKayit()
        {
            InitializeComponent();
        }

        // Sql Bağlantımızı Yaptık!
        SqlBaglantim bgl = new SqlBaglantim(); // SQL bağlantısı için bir nesne oluşturuluyor.

        private void FrmOgrKayit_Load(object sender, EventArgs e)
        {
            // Bölüm Combobox'ına Veri tabanında Bolumler Tablosundaki verileri aldık!
            SqlCommand komut = new SqlCommand("Select BolumAd From Bolumler", bgl.baglanti()); // Bölümleri seçmek için SQL komutu oluşturuluyor.
            SqlDataReader oku = komut.ExecuteReader(); // Komut çalıştırılıyor ve sonuçlar SqlDataReader nesnesine aktarılıyor.
            while (oku.Read())
            {
                CmbBolum.Items.Add(oku[0].ToString()); // Okunan bölüm adlarını ComboBox'a ekliyoruz.
            }
            bgl.baglanti().Close(); // Bağlantı kapatılıyor.

            // Boş Odaları Listeleme Komutları
            SqlCommand komut2 = new SqlCommand("Select OdaNo From Odalar where OdaKapasite != OdaAktif", bgl.baglanti()); // Boş odaları seçmek için SQL komutu oluşturuluyor.
            SqlDataReader oku2 = komut2.ExecuteReader(); // Komut çalıştırılıyor ve sonuçlar SqlDataReader nesnesine aktarılıyor.
            while (oku2.Read())
            {
                CmbOdaNo.Items.Add(oku2[0].ToString()); // Okunan boş oda numaralarını ComboBox'a ekliyoruz.
            }
            bgl.baglanti().Close(); // Bağlantı kapatılıyor.
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // Öğrenci Kayıt Kodları
            try
            {
                SqlCommand komutkaydet = new SqlCommand("INSERT INTO Ogrenci (OgrAd, OgrSoyad, OgrTC, OgrTelefon, OgrDogum, OgrBolum, OgrMail, OgrOdaNo, OgrVeliAdSoyad, OgrVeliTelefon, OgrVeliAdres) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11)", bgl.baglanti());
                komutkaydet.Parameters.AddWithValue("@p1", TxtOgrAd.Text); // Öğrenci adını parametre olarak ekliyoruz.
                komutkaydet.Parameters.AddWithValue("@p2", TxtOgrSoyad.Text); // Öğrenci soyadını parametre olarak ekliyoruz.
                komutkaydet.Parameters.AddWithValue("@p3", MskTC.Text); // Öğrenci TC numarasını parametre olarak ekliyoruz.
                komutkaydet.Parameters.AddWithValue("@p4", MskOgrTelefon.Text); // Öğrenci telefon numarasını parametre olarak ekliyoruz.
                komutkaydet.Parameters.AddWithValue("@p5", MskDogum.Text); // Öğrenci doğum tarihini parametre olarak ekliyoruz.
                komutkaydet.Parameters.AddWithValue("@p6", CmbBolum.Text); // Öğrenci bölümünü parametre olarak ekliyoruz.
                komutkaydet.Parameters.AddWithValue("@p7", TxtMail.Text); // Öğrenci mail adresini parametre olarak ekliyoruz.
                komutkaydet.Parameters.AddWithValue("@p8", CmbOdaNo.Text); // Öğrenci oda numarasını parametre olarak ekliyoruz.
                komutkaydet.Parameters.AddWithValue("@p9", TxtVeliAdSoyad.Text); // Veli ad soyadını parametre olarak ekliyoruz.
                komutkaydet.Parameters.AddWithValue("@p10", MskVeliTelefon.Text); // Veli telefon numarasını parametre olarak ekliyoruz.
                komutkaydet.Parameters.AddWithValue("@p11", RchAdres.Text); // Veli adresini parametre olarak ekliyoruz.
                komutkaydet.ExecuteNonQuery(); // Komut çalıştırılıyor ve veritabanına yeni öğrenci kaydı ekleniyor.
                bgl.baglanti().Close(); // Bağlantı kapatılıyor.
                MessageBox.Show("Kayıt Başarılı bir şekilde Eklendi"); // Başarılı ekleme mesajı gösteriliyor.

                //Ögrenci id'yi Labele Cekme
                SqlCommand komut = new SqlCommand("select Ogrid from Ogrenci", bgl.baglanti());
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    label12.Text = oku[0].ToString();
                }

                // Öğrenci Borç Alanı Kodunu Yazdık!!
                SqlCommand komutkaydet2 = new SqlCommand("insert into Borclar (Ogrid,OgrAd,OgrSoyad) values (@b1,@b2,@b3) ", bgl.baglanti());
                komutkaydet2.Parameters.AddWithValue("@b1", label12.Text); // Öğrenci ID'sini parametre olarak ekliyoruz.
                komutkaydet2.Parameters.AddWithValue("@b2", TxtOgrAd.Text); // Öğrenci adını parametre olarak ekliyoruz.
                komutkaydet2.Parameters.AddWithValue("@b3", TxtOgrSoyad.Text); // Öğrenci soyadını parametre olarak ekliyoruz.
                komutkaydet2.ExecuteNonQuery(); // Komut çalıştırılıyor ve veritabanına öğrenci borç kaydı ekleniyor.
                bgl.baglanti().Close(); // Bağlantı kapatılıyor.

                Temizle(); // Textboxlar Temizlenir.
            }
            catch (Exception)
            {
                MessageBox.Show("HATA!!! Lütfen Yeniden Deneyin"); // Hata durumunda kullanıcıya hata mesajı gösteriliyor.
            }

            //Ögrenci Oda Kontenjani Arttirma
            SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif+1 where OdaNo=@oda1", bgl.baglanti());
            komutoda.Parameters.AddWithValue("@oda1", CmbOdaNo.Text);
            komutoda.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void Temizle()
        {
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
