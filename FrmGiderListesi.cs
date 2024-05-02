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
    public partial class FrmGiderListesi : Form
    {
        public FrmGiderListesi()
        {
            InitializeComponent();
        }

        // Form yüklendiğinde çalışacak olay
        private void FrmGiderListesi_Load(object sender, EventArgs e)
        {
            // Giderler tablosundan verileri yükler
            this.giderlerTableAdapter.Fill(this.yurtKayitDataSet4.Giderler);
        }

        // DataGridView hücresine tıklandığında çalışacak olay
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen satırın indeksi
            int secilen;

            // FrmGiderGuncelle formundan bir nesne oluşturulur
            FrmGiderGuncelle frg = new FrmGiderGuncelle();

            // Seçilen satırın indeksi alınır ve ilgili hücrelerin değerleri FrmGiderGuncelle formundaki değişkenlere atanır
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            frg.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            frg.elektrik = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            frg.su = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            frg.dogalgaz = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            frg.internet = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            frg.gida = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            frg.personel = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            frg.diger = dataGridView1.Rows[secilen].Cells[7].Value.ToString();

            // FrmGiderGuncelle formu gösterilir
            frg.Show();

            // Giderler tablosundan verileri yükler
            this.giderlerTableAdapter.Fill(this.yurtKayitDataSet4.Giderler);
        }
    }
}
