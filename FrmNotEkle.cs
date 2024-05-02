using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace YurtKayitSistemi
{
    public partial class FrmNotEkle : Form
    {
        public FrmNotEkle()
        {
            InitializeComponent();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // Kayıt dosyası seçme iletişim kutusunun özellikleri ayarlanır
            saveFileDialog1.Title = "Kayıt Yeri Seçin";
            saveFileDialog1.Filter = "Metin Dosyası | *.txt";
            saveFileDialog1.InitialDirectory = "C:\\Notlar";

            // Eğer kullanıcı bir dosya seçtiyse
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosyayı yazmak için bir StreamWriter nesnesi oluşturulur
                StreamWriter kaydet = new StreamWriter(saveFileDialog1.FileName);

                // RichTextBox'taki içerik dosyaya yazılır
                kaydet.WriteLine(richTextBox1.Text);

                // Dosya kapatılır
                kaydet.Close();

                // Kullanıcıya kaydedildiğine dair bir mesaj gösterilir
                MessageBox.Show("Kayıt Yapıldı");
            }
        }
    }
}