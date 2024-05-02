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
    // Yurt Kayıt Sistemi namespace'inde FrmPersonel adlı bir form sınıfı tanımlanır
    public partial class FrmPersonel : Form
    {
        // FrmPersonel sınıfının yapıcı metodudur
        public FrmPersonel()
        {
            InitializeComponent(); // Formun bileşenlerini yükler
        }

        // SQL bağlantısı için bir nesne oluşturulur
        SqlBaglantim bgl = new SqlBaglantim();

        // Form yüklendiğinde çalışacak olay
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            // Personel verilerini yükler
            this.personelTableAdapter.Fill(this.yurtKayitDataSet6.Personel);
        }

        // Kaydet butonuna tıklandığında çalışacak olay
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Personel tablosuna yeni kayıt ekler
                SqlCommand komut = new SqlCommand("insert into Personel (PersonelAdSoyad,PersonelDepartman) values (@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtPersonelAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtPersonelGorev.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayit Eklendi");
                this.personelTableAdapter.Fill(this.yurtKayitDataSet6.Personel); // Yeniden verileri yükler
                Temizle();
            }
            catch (Exception)
            {
                MessageBox.Show("Kayit Eklenemedi, Tekrar Deneyiniz!!!");
            }
        }

        // Sil butonuna tıklandığında çalışacak olay
        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçilen personel kaydını siler
                SqlCommand komut = new SqlCommand("delete from Personel where Personelid=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtPersonelid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Silindi");
                this.personelTableAdapter.Fill(this.yurtKayitDataSet6.Personel); // Yeniden verileri yükler
                Temizle();
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Silinemedi, Tekrar Deneyiniz!!!");
            }
        }

        // DataGridView hücresine tıklanıldığında çalışacak olay
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen hücrenin satırını alır
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string ad, gorev, id;

            // Satırdaki verileri alır
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            gorev = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            // İlgili metin kutularına verileri yerleştirir
            TxtPersonelAd.Text = ad;
            TxtPersonelGorev.Text = gorev;
            TxtPersonelid.Text = id;
        }

        // Güncelle butonuna tıklandığında çalışacak olay
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçilen personel kaydını günceller
                SqlCommand komutgun = new SqlCommand("update Personel set PersonelAdSoyad=@p1,PersonelDepartman=@p2 where Personelid=@p3", bgl.baglanti());
                komutgun.Parameters.AddWithValue("@p1", TxtPersonelAd.Text);
                komutgun.Parameters.AddWithValue("@p2", TxtPersonelGorev.Text);
                komutgun.Parameters.AddWithValue("@p3", TxtPersonelid.Text);
                komutgun.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Güncellendi");
                this.personelTableAdapter.Fill(this.yurtKayitDataSet6.Personel); // Yeniden verileri yükler
                Temizle();
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Güncellenemedi, Tekrar Deneyiniz!!!");
            }
        }

        private void Temizle()
        {
            TxtPersonelid.Clear();
            TxtPersonelAd.Clear();
            TxtPersonelGorev.Clear();
        }
    }
}