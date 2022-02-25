using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        private string sMaNV;
        private string sHoLot;
        private string sTenNV;
        private string sPhai;
        private DateTime dateNgaySinh;
        private string sMaCV;

        public string SMaNV { get => sMaNV; set => sMaNV = value; }
        public string SHoLot { get => sHoLot; set => sHoLot = value; }
        public string STenNV { get => sTenNV; set => sTenNV = value; }
        public string SPhai { get => sPhai; set => sPhai = value; }
        public DateTime DateNgaySinh { get => dateNgaySinh; set => dateNgaySinh = value; }
        public string SMaCV { get => sMaCV; set => sMaCV = value; }
    }
}
