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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }

        // Sql Bağlantımızı Yaptık!
        SqlBaglantim bgl = new SqlBaglantim(); // Sql bağlantısı için kullanılan nesne

        // Form yüklendiğinde çalışacak kodlar
        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            // Bölüm verilerini yükleme işlemi
            this.bolumlerTableAdapter.Fill(this.yurtKayitDataSet.Bolumler);
        }

        // Bölüm ekleme butonu tıklama olayı
        private void PcbBolumEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // Bölüm ekleme sorgusu
                SqlCommand komut1 = new SqlCommand("insert into Bolumler (BolumAd) values (@p1)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", TxtBolumAd.Text); // Bölüm adını parametre olarak ekler
                komut1.ExecuteNonQuery(); // Sorguyu çalıştırır
                bgl.baglanti().Close(); // Bağlantıyı kapatır
                MessageBox.Show("Bölüm Eklendi"); // Kullanıcıya bilgi mesajı gösterir
                this.bolumlerTableAdapter.Fill(this.yurtKayitDataSet.Bolumler); // Bölüm verilerini yeniden yükler
                Temizle();
            }
            catch
            {
                MessageBox.Show("Hata Oluştu. Yeniden Deneyin"); // Hata durumunda kullanıcıya bilgi mesajı gösterir
            }
        }

        // Bölüm silme butonu tıklama olayı
        private void PcbBolumSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Bölüm silme sorgusu
                SqlCommand komut2 = new SqlCommand("delete from Bolumler where Bolumid=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtBolumid.Text); // Silinecek bölüm ID'sini parametre olarak ekler
                komut2.ExecuteNonQuery(); // Sorguyu çalıştırır
                bgl.baglanti().Close(); // Bağlantıyı kapatır
                MessageBox.Show("Silme İşlemi Gerçekleşti"); // Kullanıcıya bilgi mesajı gösterir
                this.bolumlerTableAdapter.Fill(this.yurtKayitDataSet.Bolumler); // Bölüm verilerini yeniden yükler
                Temizle();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata, işlem gerçekleşmedi"); // Hata durumunda kullanıcıya bilgi mesajı gösterir
            }
        }

        // DataGridView hücresine tıklandığında çalışacak kodlar
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen bölümün ID'sini ve adını ilgili TextBox'lara yazma işlemi
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            string bolumad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtBolumid.Text = id;
            TxtBolumAd.Text = bolumad;
        }

        // Bölüm düzenleme butonu tıklama olayı
        private void PcbBolumDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                // Bölüm düzenleme sorgusu
                SqlCommand komut2 = new SqlCommand("update Bolumler Set BolumAd=@p1 where Bolumid=@p2", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p2", TxtBolumid.Text); // Düzenlenecek bölüm ID'sini parametre olarak ekler
                komut2.Parameters.AddWithValue("@p1", TxtBolumAd.Text); // Yeni bölüm adını parametre olarak ekler
                komut2.ExecuteNonQuery(); // Sorguyu çalıştırır
                bgl.baglanti().Close(); // Bağlantıyı kapatır
                MessageBox.Show("Güncelleme Gerçekleşti"); // Kullanıcıya bilgi mesajı gösterir
                this.bolumlerTableAdapter.Fill(this.yurtKayitDataSet.Bolumler); // Bölüm verilerini yeniden yükler
                Temizle();
            }
            catch
            {
                MessageBox.Show("Hata"); // Hata durumunda kullanıcıya bilgi mesajı gösterir
            }
        }
        private void Temizle()
        {
            TxtBolumid.Clear();
            TxtBolumAd.Clear();
        }
    }
}
