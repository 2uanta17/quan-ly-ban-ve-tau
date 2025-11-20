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
    public partial class FrmQuanLyVeTau : Form
    {
        private KETNOI_CSDL db = new KETNOI_CSDL();
        public FrmQuanLyVeTau()
        {
            InitializeComponent();
        }

        private void FrmQuanLyVeTau_Load(object sender, EventArgs e)
        {
            LoadDanhSachVe();
        }

        private void LoadDanhSachVe()
        {
            string sql = @"
                SELECT 
                    V.MaVe, T.TenTau, GDi.TenGa AS GaDi, GDen.TenGa AS GaDen, 
                    H.NgayDi, H.GioDi, V.SoGhe, V.TenHanhKhach, V.ThongTinLienHe, V.TrangThai 
                FROM Ve V
                JOIN HanhTrinh H ON V.MaHanhTrinh = H.MaHanhTrinh
                JOIN Tau T ON H.MaTau = T.MaTau
                JOIN GaTau GDi ON H.MaGaDi = GDi.MaGa
                JOIN GaTau GDen ON H.MaGaDen = GDen.MaGa
                ORDER BY V.MaVe DESC";

            try
            {
                DataTable dt = db.Lay_DuLieuBang(sql);
                DATA_QuanLyVeTau.DataSource = dt;

                DATA_QuanLyVeTau.Columns["MaVe"].HeaderText = "Mã Vé";
                DATA_QuanLyVeTau.Columns["TenTau"].HeaderText = "Tàu";
                DATA_QuanLyVeTau.Columns["GaDi"].HeaderText = "Ga Đi";
                DATA_QuanLyVeTau.Columns["GaDen"].HeaderText = "Ga Đến";
                DATA_QuanLyVeTau.Columns["NgayDi"].HeaderText = "Ngày Đi";
                DATA_QuanLyVeTau.Columns["GioDi"].HeaderText = "Giờ Đi";
                DATA_QuanLyVeTau.Columns["SoGhe"].HeaderText = "Số Ghế";
                DATA_QuanLyVeTau.Columns["TenHanhKhach"].HeaderText = "Hành Khách";
                DATA_QuanLyVeTau.Columns["ThongTinLienHe"].HeaderText = "Liên Hệ";
                DATA_QuanLyVeTau.Columns["TrangThai"].HeaderText = "Trạng Thái";

                DATA_QuanLyVeTau.Columns["NgayDi"].DefaultCellStyle.Format = "dd/MM/yyyy";
                DATA_QuanLyVeTau.Columns["GioDi"].DefaultCellStyle.Format = "hh\\:mm";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu vé: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadDanhSachVe();
                return;
            }

            bool laMaVe = int.TryParse(tuKhoa, out int maVeCanTim);

            string sql = $@"
                SELECT 
                    V.MaVe, T.TenTau, GDi.TenGa AS GaDi, GDen.TenGa AS GaDen, 
                    H.NgayDi, H.GioDi, V.SoGhe, V.TenHanhKhach, V.ThongTinLienHe, V.TrangThai 
                FROM Ve V
                JOIN HanhTrinh H ON V.MaHanhTrinh = H.MaHanhTrinh
                JOIN Tau T ON H.MaTau = T.MaTau
                JOIN GaTau GDi ON H.MaGaDi = GDi.MaGa
                JOIN GaTau GDen ON H.MaGaDen = GDen.MaGa
                WHERE
                    {(laMaVe ? $"V.MaVe = {maVeCanTim}" : "1=0")} 
                    OR V.TenHanhKhach LIKE N'%{tuKhoa}%'
                    OR GDi.TenGa LIKE N'%{tuKhoa}%'
                    OR GDen.TenGa LIKE N'%{tuKhoa}%'
                ORDER BY V.MaVe DESC";

            try
            {
                DataTable dt = db.Lay_DuLieuBang(sql);

                DATA_QuanLyVeTau.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy vé nào phù hợp với từ khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                // Câu SQL giống DataGridView
                string sql = @"
                SELECT 
                    V.MaVe, T.TenTau, GDi.TenGa AS GaDi, GDen.TenGa AS GaDen, 
                    H.NgayDi, H.GioDi, H.GioDen,
                    V.SoGhe, V.TenHanhKhach, V.ThongTinLienHe, V.TrangThai 
                FROM Ve V
                JOIN HanhTrinh H ON V.MaHanhTrinh = H.MaHanhTrinh
                JOIN Tau T ON H.MaTau = T.MaTau
                JOIN GaTau GDi ON H.MaGaDi = GDi.MaGa
                JOIN GaTau GDen ON H.MaGaDen = GDen.MaGa
                ORDER BY V.MaVe DESC";

                // Lấy dữ liệu bằng class KETNOI_CSDL
                DataTable dt = db.Lay_DuLieuBang(sql);

                // Gán vào Crystal Report
                rptQuanLyVeTau rpt = new rptQuanLyVeTau();
                rpt.SetDataSource(dt);

                // Mở form để hiển thị report
                Form frm = new Form();
                CrystalDecisions.Windows.Forms.CrystalReportViewer viewer =
                new CrystalDecisions.Windows.Forms.CrystalReportViewer();

                viewer.Dock = DockStyle.Fill;
                viewer.ReportSource = rpt;

                frm.Controls.Add(viewer);
                frm.WindowState = FormWindowState.Maximized;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in báo cáo: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có hàng nào được chọn không
            if (DATA_QuanLyVeTau.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một vé để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy Mã Vé (MaVe là tên cột)
            int maVeCanXoa = (int)DATA_QuanLyVeTau.SelectedRows[0].Cells["MaVe"].Value;

            // **LOẠI BỎ logic kiểm tra TrangThai == "Đã hủy"**
            // Vì nếu xóa là xóa luôn, không quan tâm trạng thái hiện tại là gì.

            // 3. Xác nhận xóa VĨNH VIỄN
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn XÓA VĨNH VIỄN vé Mã {maVeCanXoa} khỏi hệ thống không?", "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                // ➡️ THAY THẾ LỆNH UPDATE BẰNG LỆNH DELETE
                string sqlDelete = $"DELETE FROM Ve WHERE MaVe = {maVeCanXoa}";

                try
                {
                    db.ThucThi(sqlDelete); // Thực thi lệnh DELETE

                    // Thông báo đã xóa
                    MessageBox.Show($"Đã xóa vĩnh viễn vé Mã {maVeCanXoa} thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại danh sách để cập nhật lưới dữ liệu (vé đã bị mất)
                    btnTimKiem_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa vé: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
