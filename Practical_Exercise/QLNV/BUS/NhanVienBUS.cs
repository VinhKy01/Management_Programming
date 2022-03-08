using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class NhanVienBUS
    {
        public static List<NhanVienDTO> ShowListNhanVien()
        {
            return NhanVienDAO.LayDanhSachNhanVien();
        } 

        public static bool ThemNhanVien_BUS(string manv, string holot, string ten, string macv, string gioitinh, string ngaysinh)
        {
            if (DAO.NhanVienDAO.KTraMaNV_DAO(manv))
            {
                return false;
            }
            else
            {
                NhanVienDAO.ThemNhanVien_DAO(manv, holot, ten, macv, gioitinh, ngaysinh);
                return true;
            }
            
        }

        public static bool xoaNhanVien_BUS(string manv)
        {
            if (!NhanVienDAO.KTraMaNV_DAO(manv))
            {
                return false;
            }
            else
            {
                NhanVienDAO.XoaNV_DAO(manv);
                return true;
            }

        }
    }
}
