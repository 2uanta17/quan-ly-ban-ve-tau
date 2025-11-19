using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYBANVETAU
{
    public partial class FrmThanhToan : Form
    {
        private int maHanhTrinh;
        private int soGhe;
        private string tenTau;
        private decimal giaVe;

        private KETNOI_CSDL db = new KETNOI_CSDL();
        public FrmThanhToan(int maHanhTrinh, int soGhe, string tenTau, decimal giaVe)
        {
            InitializeComponent();

            this.maHanhTrinh = maHanhTrinh;
            this.soGhe = soGhe;
            this.tenTau = tenTau;
            this.giaVe = giaVe;
        }

        private void FrmThanhToan_Load(object sender, EventArgs e)
        {
            lblThongTinVe.Text = $"Tàu: {this.tenTau} | Ghế: {this.soGhe} | Giá: {this.giaVe:N0} VNĐ";
            lblThongTinVe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblThongTinVe.ForeColor = Color.Black;
        }

        private void btnXacNhanMuaVe_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();

            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên hành khách.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrEmpty(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập thông tin liên hệ (SĐT hoặc Email).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            string sql = $"INSERT INTO Ve (MaHanhTrinh, SoGhe, TenHanhKhach, ThongTinLienHe, TrangThai) " +
                           $"VALUES ({this.maHanhTrinh}, {this.soGhe}, N'{hoTen}', N'{soDienThoai}', N'Đã đặt')";

            try
            {
                db.ThucThi(sql);

                MessageBox.Show("Đặt vé thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi đặt vé.\nChi tiết: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
