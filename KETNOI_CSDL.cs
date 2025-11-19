using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYBANVETAU
{
    internal class KETNOI_CSDL
    {
        public SqlConnection cnn;
        public SqlCommand cmd;
        public DataTable dta;
        public SqlDataAdapter ada;

        public void KetNoi_DuLieu()
        {
            string sql1 = @"Data Source=DESKTOP-UFACNQ2\SQLEXPRESS;Initial Catalog=QUANLYBANVETAU;Integrated Security=True;TrustServerCertificate=True";
            cnn = new SqlConnection(sql1);
            cnn.Open();
        }

        public void HuyKetNoi()
        {
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
        }

        public DataTable Lay_DuLieuBang(string Sql)
        {
            KetNoi_DuLieu();
            ada = new SqlDataAdapter(Sql, cnn);
            dta = new DataTable();
            ada.Fill(dta);
            return dta;
        }

        public void ThucThi(string Sql)
        {
            KetNoi_DuLieu();
            cmd = new SqlCommand(Sql, cnn);
            cmd.ExecuteNonQuery();
            HuyKetNoi();
        }
    }
}
