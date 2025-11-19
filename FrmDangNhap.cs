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

namespace QUANLYBANVETAU
{
    public partial class FrmDangNhap : Form
    {
        KETNOI_CSDL db = new KETNOI_CSDL();
        public FrmDangNhap()
        {
            InitializeComponent();
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
                MessageBox.Show("Bạn đã đăng nhập thành công");
                FrmMain Fmain = new FrmMain();
                Fmain.Show();
                this.Hide();
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
    }
}
