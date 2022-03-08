using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using BUS;

namespace GUI
{
    public partial class fNhanVien : Form
    {
        int rowIdex;
        BindingSource listNhanVien = new BindingSource();
        public fNhanVien()
        {
            InitializeComponent();
        }

        //Ham load list
        void LoadNV()
        {
            List<NhanVienDTO> lstNhanVien = NhanVienBUS.ShowListNhanVien();
            dtgvNhanVien.DataSource = lstNhanVien;
        }

        private void fNhanVien_Load(object sender, EventArgs e)
        {
            dtgvNhanVien.DataSource = listNhanVien;
            LoadNV();
            BindingNhanVien();
        }

        void BindingNhanVien()
        {
            txtManv.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "SMaNV", true, DataSourceUpdateMode.Never));
            txtHolot.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "SHoLot", true, DataSourceUpdateMode.Never));
            txtTenNhanVien.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "STenNV", true, DataSourceUpdateMode.Never));
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtManv.Clear();
            txtHolot.Clear();
            txtTenNhanVien.Clear();
            rdbNam.Checked = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string gioitinh;
            string manv = txtManv.Text;
            string holot = txtHolot.Text;
            string ten = txtTenNhanVien.Text;
            string macv = cbbMacv.Text;
            if (rdbNam.Checked = true)
                gioitinh = "Nam";
            else
                gioitinh = "Nữ";

            string ngaysinh = dtpkNgaySinh.Value.ToShortDateString();
            if(NhanVienBUS.ThemNhanVien_BUS(manv, holot, ten, macv, gioitinh, ngaysinh))
            {
                MessageBox.Show("Thêm thành công", "Thông báo");
                LoadNV();
            }
            else
            {
                MessageBox.Show("Éc ô éc", "Thông báo");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dtgvNhanVien.Rows[rowIdex];
            string macv = dr.Cells[0].Value.ToString();
            if (BUS.NhanVienBUS.xoaNhanVien_BUS(macv))
            {
                MessageBox.Show("Da xoa thanh cong", "Thong bao");
                LoadNV();
            }
            else
                MessageBox.Show("et o et");

        }
    }
}
