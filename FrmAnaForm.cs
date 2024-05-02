using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayitSistemi
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtKayitDataSet8.Ogrenci' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ogrenciTableAdapter2.Fill(this.yurtKayitDataSet8.Ogrenci);
            // TODO: Bu kod satırı 'yurtKayitDataSet7.Ogrenci' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ogrenciTableAdapter1.Fill(this.yurtKayitDataSet7.Ogrenci);
            // TODO: Bu kod satırı 'yurtKayitDataSet1.Ogrenci' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ogrenciTableAdapter.Fill(this.yurtKayitDataSet1.Ogrenci);
        }

        // Hesap Makinesi menü öğesine tıklandığında çalışacak olan olay işleyicisi
        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Sistem, hesap makinesi uygulamasını başlatır
            System.Diagnostics.Process.Start("Calc.exe");
        }

        // Paint menü öğesine tıklandığında çalışacak olan olay işleyicisi
        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Sistem, Paint uygulamasını başlatır
            System.Diagnostics.Process.Start("MsPaint.Exe");
        }

        // Öğrenci Ekle menü öğesine tıklandığında çalışacak olan olay işleyicisi
        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmOgrKayit formundan yeni bir öğrenci kayıt formu oluşturulur
            FrmOgrKayit fr = new FrmOgrKayit();

            // Oluşturulan form görüntülenir
            fr.Show();
        }

        // Öğrenci Listesi menü öğesine tıklandığında çalışacak olan olay işleyicisi
        private void öğrenciListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmOgrListe formundan yeni bir öğrenci listesi formu oluşturulur
            FrmOgrListe fr = new FrmOgrListe();

            // Oluşturulan form görüntülenir
            fr.Show();
        }

        // Bölüm Listesi menü öğesine tıklandığında çalışacak olan olay işleyicisi
        private void bölümListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmBolumler formundan yeni bir bölüm ekleme formu oluşturulur
            FrmBolumler fr = new FrmBolumler();

            // Oluşturulan form görüntülenir
            fr.Show();
        }

        // Ödeme Al menü öğesine tıklandığında çalışacak olan olay işleyicisi
        private void ödemeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmOdemeler formundan yeni bir ödeme alma formu oluşturulur
            FrmOdemeler fr = new FrmOdemeler();

            // Oluşturulan form görüntülenir
            fr.Show();
        }

        // Gider Ekle menü öğesine tıklandığında çalışacak olan olay işleyicisi
        private void giderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmGider formundan yeni bir gider ekleme formu oluşturulur
            FrmGider fr = new FrmGider();

            // Oluşturulan form görüntülenir
            fr.Show();
        }

        // Gider İstatistikleri menü öğesine tıklandığında çalışacak olay işleyicisi
        private void giderİstatisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmGiderListesi formundan yeni bir gider listesi formu oluşturulur
            FrmGiderListesi fr = new FrmGiderListesi();

            // Oluşturulan form görüntülenir
            fr.Show();
        }

        // Gelir İstatistikleri menü öğesine tıklandığında çalışacak olay işleyicisi
        private void gelirİstatisikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmGelirİstatistik formundan yeni bir gelir istatistikleri formu oluşturulur
            FrmGelirİstatistik fr = new FrmGelirİstatistik();

            // Oluşturulan form görüntülenir
            fr.Show();
        }

        // Şifre İşlemleri menü öğesine tıklandığında çalışacak olay işleyicisi
        private void şifreİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmYoneticiDuzenle formundan yeni bir yönetici düzenleme formu oluşturulur
            FrmYoneticiDuzenle fr = new FrmYoneticiDuzenle();

            // Oluşturulan form görüntülenir
            fr.Show();
        }

        // Personel Düzenle menü öğesine tıklandığında çalışacak olay işleyicisi
        private void personelDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmPersonel formundan yeni bir personel düzenleme formu oluşturulur
            FrmPersonel fr = new FrmPersonel();

            // Oluşturulan form görüntülenir
            fr.Show();
        }

        // Not Ekle menü öğesine tıklandığında çalışacak olay işleyicisi
        private void notEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmNotEkle formundan yeni bir not ekleme formu oluşturulur
            FrmNotEkle fr = new FrmNotEkle();

            // Oluşturulan form görüntülenir
            fr.Show();
        }

        // Hakkımızda menü öğesine tıklandığında çalışacak olay işleyicisi
        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kullanıcıya bir bilgi iletişim kutusu gösterilir
            MessageBox.Show("Bu program Serhat Ece tarafından Sistem Analizi ve Tasarımı Proje dersi için yapılmıştır.", "Yurt Kayıt Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Çıkış menü öğesine tıklandığında çalışacak olay işleyicisi
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Uygulama kapatılır
            Application.Exit();
        }

        private void oturumuKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmAdminGiris formu oluşturulur
            FrmAdminGiris fr = new FrmAdminGiris();

            // Oluşturulan form görüntülenir
            fr.Show();

            this.Hide();
        }
    }
}
