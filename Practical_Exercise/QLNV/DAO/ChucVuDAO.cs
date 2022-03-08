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
        public static List<ChucVuDTO> LayChucVu()
        {
            string query = @"select *from chucvu";

            //DataTable chứa dữ liệu lấy về
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);

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

        //check ma chcuc vu
        public static bool KTraMaCV_DAO(string ma)
        {
            string query = "select * from chucvu where macv = @macv";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { ma });
            
            return data.Rows.Count > 0;
        }

        //them chuc vu
        public static bool ThemCV_DAO(string ma, string ten, float heso)
        {
            string query = "insert into chucvu values( @ma , @ten , @heso )";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { ma, ten, heso }) > 0;
        }

        //Xoa chuc vu
        public static bool XoaCV_DAO(string macv)
        {
            string query = "delete chucvu where macv = @macv";
            try
            {
                return DataProvider.Instance.ExcuteNonQuery(query, new object[] { macv }) > 0;
            }
            catch { };
            return true;
        }


    }
}
