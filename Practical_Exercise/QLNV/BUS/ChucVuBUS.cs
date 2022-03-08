using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class ChucVuBUS
    {
        public static List<ChucVuDTO> ShowListChucVu()
        {
            return ChucVuDAO.LayChucVu();
        }

        public static bool themChucVu_BUS(string ma, string ten, float heso)
        {
            if (DAO.ChucVuDAO.KTraMaCV_DAO(ma))
                return false;
            else
            {
                ChucVuDAO.ThemCV_DAO(ma, ten, heso);
                return true;
            }
        }

        public static bool xoaChucVu_BUS(string macv)
        {
            if (!ChucVuDAO.KTraMaCV_DAO(macv))
            {
                return false;
            }
            else
            {
                ChucVuDAO.XoaCV_DAO(macv);
                return true;
            }
        
        }
    }
}
