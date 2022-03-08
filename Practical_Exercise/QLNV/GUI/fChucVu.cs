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
        int rowIndex;
        BindingSource listChucVu = new BindingSource();
        public fChucVu()
        {
            InitializeComponent();
        }

        //loaf data\
        void LoadChucVu()
        {
            List<ChucVuDTO> lstChucVu = ChucVuBUS.ShowListChucVu();
            listChucVu.DataSource = lstChucVu;
        }

        //binding
        void BindingChucVu()
        {
            txtHSPC.DataBindings.Add(new Binding("Text", dtgvChucVu.DataSource, "FHSPhuCap", true, DataSourceUpdateMode.Never));
            txtMaCV.DataBindings.Add(new Binding("Text", dtgvChucVu.DataSource, "SMaCV", true, DataSourceUpdateMode.Never));
            txtTenCV.DataBindings.Add(new Binding("Text", dtgvChucVu.DataSource, "STenCV", true, DataSourceUpdateMode.Never));
        }

        private void fChucVu_Load(object sender, EventArgs e)
        {
            dtgvChucVu.DataSource = listChucVu;

            LoadChucVu();

            BindingChucVu();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaCV.Text = "";
            txtTenCV.Text = "";
            txtHSPC.Text = "";
            txtMaCV.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ma = txtMaCV.Text;
            string ten = txtTenCV.Text;
            float heso = float.Parse(txtHSPC.Text);
            if (BUS.ChucVuBUS.themChucVu_BUS(ma, ten, heso))
            {
                MessageBox.Show("Da xoa thanh cong", "Thong bao");
                LoadChucVu();
            }
            else
                MessageBox.Show("et o et");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dtgvChucVu.Rows[rowIndex];
            string macv = dr.Cells[0].Value.ToString();
            if (BUS.ChucVuBUS.xoaChucVu_BUS(macv))
            {
                MessageBox.Show("Da xoa thanh cong", "Thong bao");
                LoadChucVu();
            }
            else
                MessageBox.Show("et o et");

        }

        private void dtgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }
    }
}
