using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        fChucVu fcv;

        private void mniChucVu_Click(object sender, EventArgs e)
        {
            if (fcv == null || fcv.IsDisposed)
            {
                fcv = new fChucVu();
                fcv.MdiParent = this;
                fcv.Show();
            }
        }

        fNhanVien fnv;

        private void mniNhanVien_Click(object sender, EventArgs e)
        {
            if (fnv == null || fnv.IsDisposed)
            {
                fnv = new fNhanVien();
                fnv.MdiParent = this;
                fnv.Show();
            }
        }
    }
}
