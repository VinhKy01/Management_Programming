using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAO
{
    public class NhanVienDAO
    {
        public static List<NhanVienDTO> LayDanhSachNhanVien()
        {
            string query = @"select *from nhanvien";
   

            //DataTable chứa dữ liệu lấy về
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            //Có dữ liệu thì chuyển dữ liệu từ Database qua dữ liệu đã định dạng DTO
            List<NhanVienDTO> lstNhanVien = new List<NhanVienDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.SMaNV = dt.Rows[i]["manv"].ToString();
                nv.SHoLot = dt.Rows[i]["holot"].ToString();
                nv.STenNV = dt.Rows[i]["tennv"].ToString();
                nv.SPhai = dt.Rows[i]["phai"].ToString();
                nv.DateNgaySinh = (DateTime)dt.Rows[i]["ngaysinh"];
                nv.SMaCV = dt.Rows[i]["macv"].ToString();
                lstNhanVien.Add(nv);
            }

            return lstNhanVien;
        }

        public static bool KTraMaNV_DAO(string ma)
        {
            string query = "select * from nhanvien where manv = @manv";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { ma });

            return data.Rows.Count > 0;
        }

        public static bool ThemNhanVien_DAO(string manv, string holot, string ten, string macv, string gioitinh, string ngaysinh)
        {
            string query = @"insert into nhanvien values ( @manv , @holot , @tennv , @phai , @ngaysinh , @macv )";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] {  manv,  holot,  ten,   gioitinh, ngaysinh,macv}) > 0;

        }

        public static bool XoaNV_DAO(string manv)
        {
            string query = "delete nhanvien where manv = @manv";
            //try
            //{
                return DataProvider.Instance.ExcuteNonQuery(query, new object[] { manv }) > 0;
            //}
            //catch { };
            //return true;
        }
    }
}
