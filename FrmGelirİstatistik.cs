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
    public partial class FrmGelirİstatistik : Form
    {
        public FrmGelirİstatistik()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim(); // SqlBaglantim sınıfından bir nesne oluşturulur.

        private void FrmGelirİstatistik_Load(object sender, EventArgs e)
        {
            // Kasa tablosundaki tüm ödeme miktarlarının toplamını alır.
            SqlCommand komut = new SqlCommand("Select Sum(OdemeMiktar) from Kasa", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                LblPara.Text = oku[0].ToString() + " TL"; // Toplam ödeme miktarını Label'a yazdırır.
            }
            bgl.baglanti().Close(); // Bağlantıyı kapatır.

            // Kasa tablosundan tekrarsız olarak ayları listeler.
            SqlCommand komut2 = new SqlCommand("SELECT OdemeAy FROM (SELECT OdemeAy, CASE OdemeAy WHEN 'Ocak' THEN 1 WHEN 'Şubat' THEN 2 WHEN 'Mart' THEN 3 WHEN 'Nisan' THEN 4 WHEN 'Mayıs' THEN 5 WHEN 'Haziran' THEN 6 WHEN 'Temmuz' THEN 7 WHEN 'Ağustos' THEN 8 WHEN 'Eylül' THEN 9 WHEN 'Ekim' THEN 10 WHEN 'Kasım' THEN 11 WHEN 'Aralık' THEN 12 END AS AySira FROM Kasa) AS AyListesi GROUP BY OdemeAy, AySira ORDER BY AySira", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbAy.Items.Add(oku2[0].ToString()); // Ay verilerini ComboBox'a ekler.
            }
            bgl.baglanti().Close(); // Bağlantıyı kapatır.


            // Veritabanından veri çekerek grafik oluşturmak için SQL komutu oluşturulur
            SqlCommand komut3 = new SqlCommand("SELECT OdemeAy, SUM(OdemeMiktar) AS ToplamMiktar FROM kasa GROUP BY OdemeAy ORDER BY CASE OdemeAy WHEN 'Ocak' THEN 1 WHEN 'Şubat' THEN 2 WHEN 'Mart' THEN 3 WHEN 'Nisan' THEN 4 WHEN 'Mayıs' THEN 5 WHEN 'Haziran' THEN 6 WHEN 'Temmuz' THEN 7 WHEN 'Ağustos' THEN 8 WHEN 'Eylül' THEN 9 WHEN 'Ekim' THEN 10 WHEN 'Kasım' THEN 11 WHEN 'Aralık' THEN 12 END", bgl.baglanti());

            // Komutu çalıştırarak verileri SqlDataReader nesnesi üzerinden okuma
            SqlDataReader oku3 = komut3.ExecuteReader();

            // Okunan her bir satırı grafik üzerine eklemek için döngü kullanılır
            while (oku3.Read())
            {
                // Grafik üzerine veri eklemek için Series koleksiyonuna veri eklenir
                this.chart1.Series["Aylık"].Points.AddXY(oku3[0], oku3[1]);
            }

            // Veritabanı bağlantısı kapatılır
            bgl.baglanti().Close();
        }

        private void CmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen ayın toplam ödeme miktarını alır.
            SqlCommand komut = new SqlCommand("select sum(OdemeMiktar) From Kasa where OdemeAy=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbAy.Text); // ComboBox'tan seçilen ayı parametre olarak kullanır.
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                LblAyKazanc.Text = oku[0].ToString() + " TL"; // Seçilen ayın toplam ödeme miktarını Label'a yazdırır.
            }
            bgl.baglanti().Close(); // Bağlantıyı kapatır.
        }
    }
}
