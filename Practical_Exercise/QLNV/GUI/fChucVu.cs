using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using DAO;


namespace GUI
{
    public partial class fChucVu : Form
    {
        public fChucVu()
        {
            InitializeComponent();
        }

        private void fChucVu_Load(object sender, EventArgs e)
        {
            List<ChucVuDTO> lstChucVu = ChucVuBUS.ShowListChucVu();
            dtgvChucVu.DataSource = lstChucVu;
        }
    }
}
