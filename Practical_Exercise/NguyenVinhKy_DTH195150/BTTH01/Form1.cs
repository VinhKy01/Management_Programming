using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTH01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Kết nối
        DataSet ds = new DataSet("dsQLNV");
        SqlDataAdapter da;
        SqlDataAdapter daFill;
        SqlConnection conn = new SqlConnection();
        

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = @"Data Source=DESKTOP-D05RLNC\SQLEXPRESS;Initial Catalog=QLNV;User ID=sa;Password=12345";

            // Dữ liệu combobox Chức vụ
            string sQueryChucVu = @"select * from chucvu";
            da = new SqlDataAdapter(sQueryChucVu, conn);
            da.Fill(ds, "tblChucVu");
            cbbChucVu.DataSource = ds.Tables["tblChucVu"];
            cbbChucVu.DisplayMember = "tencv";
            cbbChucVu.ValueMember = "macv";

            //Dữ liệu vào DataDridview
            da = new SqlDataAdapter(@"select *from nhanvien", conn);
            da.Fill(ds, "tblNhanVien");
            dtgvStaff.DataSource = ds.Tables["tblNhanVien"];

        }

        private void cbbChucVu_SelectedValueChanged(object sender, EventArgs e)
        {
            string machucvu = cbbChucVu.ToString();
            string ten = cbbChucVu.DisplayMember;
            string s = cbbChucVu.SelectedValue.ToString();
            daFill = new SqlDataAdapter($@"select n.*, c.tencv from nhanvien n, chucvu c where n.macv=c.macv and c.tencv = N'{machucvu}'", conn);
            daFill.Fill(ds, "tblNhanVien");
            dtgvStaff.DataSource = ds.Tables["tblNhanVien"];
        }
        
    }
}