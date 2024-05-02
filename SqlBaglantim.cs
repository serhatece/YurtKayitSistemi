using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace YurtKayitSistemi
{
    public class SqlBaglantim
    {
        public SqlConnection baglanti()
        {
            // SQL bağlantısı oluşturulur ve yapılandırılır.
            // Bağlantı dizesi, veritabanı sunucusu bilgisini, veritabanı adını ve kimlik doğrulama yöntemini içerir.
            // Bu dizede, 'serhatecee\SQLEXPRESS' veritabanı sunucusunun adı ve 'YurtKayit' veritabanının adı bulunmaktadır.
            // 'Integrated Security=True' parametresi, Windows kimlik doğrulama yöntemini kullanarak oturum açmayı sağlar.
            SqlConnection baglan = new SqlConnection(@"Data Source=serhatecee\SQLEXPRESS;Initial Catalog=YurtKayit;Integrated Security=True");

            // Bağlantı açılır.
            baglan.Open();

            // Oluşturulan bağlantı nesnesi geri döndürülür.
            return baglan;
        }


    }
}
