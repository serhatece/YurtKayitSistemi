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
    public partial class FrmOgrListe : Form
    {
        public FrmOgrListe()
        {
            InitializeComponent();
        }

        private void FrmOgrListe_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtKayitDataSet3.Ogrenci' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ogrenciTableAdapter.Fill(this.yurtKayitDataSet3.Ogrenci); // Form yüklendiğinde, öğrenci verilerini DataGridView'e yükler.

        }

        int secilen;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilen = dataGridView1.SelectedCells[0].RowIndex; // Seçilen hücrenin satır indeksini alır.
            FrmOgrDuzenle fr = new FrmOgrDuzenle(); // FrmOgrDuzenle formundan yeni bir nesne oluşturulur.
            fr.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString(); // Seçilen öğrencinin ID'si alınır ve FrmOgrDuzenle formundaki ilgili değişkene atanır.
            fr.ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString(); // Seçilen öğrencinin adı alınır ve FrmOgrDuzenle formundaki ilgili değişkene atanır.
            fr.soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString(); // Seçilen öğrencinin soyadı alınır ve FrmOgrDuzenle formundaki ilgili değişkene atanır.
            fr.TC = dataGridView1.Rows[secilen].Cells[3].Value.ToString(); // Seçilen öğrencinin TC kimlik numarası alınır ve FrmOgrDuzenle formundaki ilgili değişkene atanır.
            fr.telefon = dataGridView1.Rows[secilen].Cells[4].Value.ToString(); // Seçilen öğrencinin telefon numarası alınır ve FrmOgrDuzenle formundaki ilgili değişkene atanır.
            fr.dogum = dataGridView1.Rows[secilen].Cells[5].Value.ToString(); // Seçilen öğrencinin doğum tarihi alınır ve FrmOgrDuzenle formundaki ilgili değişkene atanır.
            fr.bolum = dataGridView1.Rows[secilen].Cells[6].Value.ToString(); // Seçilen öğrencinin bölümü alınır ve FrmOgrDuzenle formundaki ilgili değişkene atanır.
            fr.mail = dataGridView1.Rows[secilen].Cells[7].Value.ToString(); // Seçilen öğrencinin e-posta adresi alınır ve FrmOgrDuzenle formundaki ilgili değişkene atanır.
            fr.odano = dataGridView1.Rows[secilen].Cells[8].Value.ToString(); // Seçilen öğrencinin oda numarası alınır ve FrmOgrDuzenle formundaki ilgili değişkene atanır.
            fr.veliad = dataGridView1.Rows[secilen].Cells[9].Value.ToString(); // Seçilen öğrencinin veli adı soyadı alınır ve FrmOgrDuzenle formundaki ilgili değişkene atanır.
            fr.velitel = dataGridView1.Rows[secilen].Cells[10].Value.ToString(); // Seçilen öğrencinin veli telefon numarası alınır ve FrmOgrDuzenle formundaki ilgili değişkene atanır.
            fr.adres = dataGridView1.Rows[secilen].Cells[11].Value.ToString(); // Seçilen öğrencinin adresi alınır ve FrmOgrDuzenle formundaki ilgili değişkene atanır.

            fr.Show(); // FrmOgrDuzenle formunu gösterir.

            this.ogrenciTableAdapter.Fill(this.yurtKayitDataSet3.Ogrenci); // Form yüklendiğinde, öğrenci verilerini DataGridView'e yükler.
        }
    }
}
