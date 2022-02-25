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
    }
}
