using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul_Otomasyon
{
    class sqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-JA53S8S;Initial Catalog=dbo.OkulOtomasyonu;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
