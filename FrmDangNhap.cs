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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace QUANLYBANVETAU
{
    public partial class FrmDangNhap : Form
    {
        KETNOI_CSDL db = new KETNOI_CSDL();
        FrmMain _parentForm;
        public FrmDangNhap(FrmMain parent)
        {
            InitializeComponent();
            _parentForm = parent;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            db.KetNoi_DuLieu();
            string tk = txtDangNhap.Text;
            string mk = txtMatKhau.Text;
            string sql_login = "SELECT * FROM QUANLY WHERE TENDANGNHAP='" + tk + "' AND MATKHAU='" + mk + "'";

            SqlCommand cmd = new SqlCommand(sql_login, db.cnn);
            SqlDataReader docdulieu = cmd.ExecuteReader();

            if (docdulieu.Read() == true)
            {
                MessageBox.Show("Bạn đã đăng nhập thành công với tư cách Quản lý.");

                // 1. Cập nhật trạng thái đăng nhập của Form Main
                _parentForm.IsLoggedInQuanLy = true;

                // 2. Kích hoạt menu QUẢN LÝ trên Form Main
                _parentForm.KiemTraQuyen();

                this.Close(); // Đóng form Đăng Nhập (hoặc Hide())
            }
            else
            {
                MessageBox.Show("Hãy kiểm tra lại thông tin đăng nhập!", "Thông báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            _parentForm.IsLoggedInQuanLy = false;
            _parentForm.KiemTraQuyen(); // Đảm bảo menu QUẢN LÝ bị ẩn
            this.Close(); // Đóng form Đăng Nhập
        }
    }
}
