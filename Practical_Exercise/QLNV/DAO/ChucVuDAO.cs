using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class ChucVuDAO
    {
        static SqlConnection con;
        public static List<ChucVuDTO> LayChucVu()
        {
            string query = @"select *from chucvu";
            con = DataProvider.MoKetNoi();

            //DataTable chứa dữ liệu lấy về
            DataTable dt = DataProvider.TruyVanLayDuLieu(query, con);

            //Không có dữ liệu
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            //Có dữ liệu thì chuyển dữ liệu từ Database qua dữ liệu đã định dạng DTO
            List<ChucVuDTO> lstChucVu = new List<ChucVuDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChucVuDTO cv = new ChucVuDTO();
                cv.SMaCV = dt.Rows[i]["macv"].ToString();
                cv.STenCV = dt.Rows[i]["tencv"].ToString();
                cv.FHSPhuCap = float.Parse(dt.Rows[i]["hsphucap"].ToString());
                lstChucVu.Add(cv);
            }
            return lstChucVu;
        }
    }
}
