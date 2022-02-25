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
    }
}
