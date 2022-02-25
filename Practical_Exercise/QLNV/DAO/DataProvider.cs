using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DataProvider
    {
        public static SqlConnection MoKetNoi()
        {
            string s = @"Data Source=DESKTOP-D05RLNC\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True";
            SqlConnection KetNoi = new SqlConnection(s);
            KetNoi.Open();
            return KetNoi;
        }
        // Thực hiện truy vấn trả về bảng dữ liệu
        public static DataTable TruyVanLayDuLieu(string query, SqlConnection KetNoi)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, KetNoi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        // Thực hiện truy vấn không trả về dữ liệu
        public static bool TruyVanKhongLayDuLieu(string query, SqlConnection  KetNoi)
        {
            try
            {
                SqlCommand cm = new SqlCommand(query, KetNoi);
                cm.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
