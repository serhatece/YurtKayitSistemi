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
    public partial class FrmOdemeler : Form
    {
        public FrmOdemeler()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim(); // SqlBaglantim sınıfından bir nesne oluşturulur.

        private void FrmOdemeler_Load(object sender, EventArgs e)
        {
            // Borçlar tablosundan verileri yükler.
            this.borclarTableAdapter.Fill(this.yurtKayitDataSet2.Borclar);

        }

        private void BtnOdemeAl_Click(object sender, EventArgs e)
        {
            // Ödeme alındığında yapılacak işlemler
            int odenen, kalan, yeniborc;
            odenen = Convert.ToInt16(TxtOdenen.Text);
            kalan = Convert.ToInt16(TxtKalan.Text);
            yeniborc = kalan - odenen;
            TxtKalan.Text = yeniborc.ToString(); // Yeni kalan borcu TextBox'a yazdırır.

            // Yeni kalan borcu veritabanına kaydeder.
            SqlCommand komut = new SqlCommand("update Borclar set OgrKalanBorc=@p1 where Ogrid=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p2", TxtOgrid.Text);
            komut.Parameters.AddWithValue("@p1", TxtKalan.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close(); // Bağlantıyı kapatır.
            MessageBox.Show("Borç Başarılı bir Şekilde Ödendi"); // Başarılı ödeme mesajı gösterir.
            this.borclarTableAdapter.Fill(this.yurtKayitDataSet2.Borclar); // Borçları tekrar yükler.

            // Kasa tablosuna ödeme miktarını ve ödeme yapılan ayı ekler.
            SqlCommand komut2 = new SqlCommand("insert into Kasa (OdemeAy, OdemeMiktar) values (@k1,@k2)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@k1", TxtOdenenAy.Text);
            komut2.Parameters.AddWithValue("@k2", TxtOdenen.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close(); // Bağlantıyı kapatır.

            // Textboxları Temizler
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // DataGridView'de bir hücreye tıklandığında yapılacak işlemler
            int secilen;
            string id, ad, soyad, kalan;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString(); // Seçilen öğrenci ID'sini alır.
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString(); // Seçilen öğrenci adını alır.
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString(); // Seçilen öğrenci soyadını alır.
            kalan = dataGridView1.Rows[secilen].Cells[3].Value.ToString(); // Seçilen öğrencinin kalan borcunu alır.

            // TextBox'lara seçilen öğrenci bilgilerini yazdırır.
            TxtAd.Text = ad;
            TxtSoyad.Text = soyad;
            TxtKalan.Text = kalan;
            TxtOgrid.Text = id;
        }

        private void Temizle()
        {
            TxtOgrid.Clear();
            TxtAd.Clear();
            TxtSoyad.Clear();
            TxtOdenen.Clear();
            TxtKalan.Clear();
            TxtOdenenAy.Clear();
        }
    }
}
