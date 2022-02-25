using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class NhanVienDAO
    {
        static SqlConnection con;
        public static List<NhanVienDTO> LayDanhSachNhanVien()
        {
            string query = @"select *from nhanvien";
            con = DataProvider.MoKetNoi();

            //DataTable chứa dữ liệu lấy về
            DataTable dt = DataProvider.TruyVanLayDuLieu(query, con);

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            //Có dữ liệu thì chuyển dữ liệu từ Database qua dữ liệu đã định dạng DTO
            List<NhanVienDTO> lstNhanVien = new List<NhanVienDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.SMaNV = dt.Rows[i]["macv"].ToString();
                nv.SHoLot = dt.Rows[i]["holot"].ToString();
                nv.STenNV = dt.Rows[i]["tennv"].ToString();
                nv.SPhai = dt.Rows[i]["phai"].ToString();
                nv.DateNgaySinh = (DateTime)dt.Rows[i]["ngaysinh"];
                nv.SMaCV = dt.Rows[i]["macv"].ToString();
                lstNhanVien.Add(nv);
            }

            return lstNhanVien;
        }
    }
}
