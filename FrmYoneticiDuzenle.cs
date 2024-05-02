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
    public partial class FrmYoneticiDuzenle : Form
    {
        public FrmYoneticiDuzenle()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim(); // SqlBaglantim sınıfından bir nesne oluşturulur.

        private void Form1_Load(object sender, EventArgs e)
        {
            // Admin tablosundan verileri yükler.
            this.adminTableAdapter.Fill(this.yurtKayitDataSet5.Admin);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Yeni yönetici ekler.
                SqlCommand komut = new SqlCommand("insert into Admin(YöneticiAd, YöneticiSifre) values (@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text); // Yönetici adını parametre olarak ekler.
                komut.Parameters.AddWithValue("@p2", TxtSifre.Text); // Yönetici şifresini parametre olarak ekler.
                komut.ExecuteNonQuery();
                bgl.baglanti().Close(); // Bağlantıyı kapatır.
                MessageBox.Show("Yönetici Eklendi"); // Başarılı ekleme mesajı gösterir.
                this.adminTableAdapter.Fill(this.yurtKayitDataSet5.Admin); // Yönetici verilerini tekrar yükler.
                Temizle(); // Textboxlar Temizlenir.

            }
            catch (Exception)
            {
                MessageBox.Show("Yönetici Eklenemedi, Tekrar Deneyiniz!!!"); // Hata durumunda kullanıcıya hata mesajı gösterir.
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // DataGridView'de bir hücreye tıklandığında yapılacak işlemler
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string ad, sifre, id;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString(); // Seçilen yönetici ID'sini alır.
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString(); // Seçilen yönetici adını alır.
            sifre = dataGridView1.Rows[secilen].Cells[2].Value.ToString(); // Seçilen yönetici şifresini alır.
            TxtYoneticiid.Text = id;
            TxtKullaniciAd.Text = ad;
            TxtSifre.Text = sifre;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçilen yöneticiyi siler.
                SqlCommand komut = new SqlCommand("delete from Admin where Yöneticiid=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtYoneticiid.Text); // Yönetici ID'sini parametre olarak ekler.
                komut.ExecuteNonQuery();
                bgl.baglanti().Close(); // Bağlantıyı kapatır.
                MessageBox.Show("Kayıt Silindi"); // Başarılı silme mesajı gösterir.
                this.adminTableAdapter.Fill(this.yurtKayitDataSet5.Admin); // Yönetici verilerini tekrar yükler.
                Temizle(); // Textboxlar temizlenir.
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Silinemedi, Tekrar Deneyiniz!!"); // Hata durumunda kullanıcıya hata mesajı gösterir.
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçilen yönetici bilgilerini günceller.
                SqlCommand komut = new SqlCommand("update admin set YöneticiAd=@p1, YöneticiSifre=@p2 where Yöneticiid=@p3", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text); // Yönetici adını parametre olarak ekler.
                komut.Parameters.AddWithValue("@p2", TxtSifre.Text); // Yönetici şifresini parametre olarak ekler.
                komut.Parameters.AddWithValue("@p3", TxtYoneticiid.Text); // Yönetici ID'sini parametre olarak ekler.
                bgl.baglanti().Close(); // Bağlantıyı kapatır.
                komut.ExecuteNonQuery();
                MessageBox.Show("Güncelleme Gerçekleşti"); // Başarılı güncelleme mesajı gösterir.
                this.adminTableAdapter.Fill(this.yurtKayitDataSet5.Admin); // Yönetici verilerini tekrar yükler.
            }
            catch (Exception)
            {
                MessageBox.Show("Güncelleme Gerçekleşemedi, Tekrar Deneyiniz!!"); // Hata durumunda kullanıcıya hata mesajı gösterir.
            }
        }

        private void Temizle()
        {
            TxtYoneticiid.Clear();
            TxtKullaniciAd.Clear();
            TxtSifre.Clear();
        }
    }
}
