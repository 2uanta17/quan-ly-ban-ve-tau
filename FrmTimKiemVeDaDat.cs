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
    public partial class FrmTimKiemVeDaDat : Form
    {
        KETNOI_CSDL kn = new KETNOI_CSDL();
        public FrmTimKiemVeDaDat()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();
            if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập **Số điện thoại** để tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = $@"
                SELECT 
                    V.MaVe AS N'Mã Vé',
                    T.TenTau AS N'Tên Tàu',
                    GDi.TenGa AS N'Ga Đi',
                    GDen.TenGa AS N'Ga Đến',
                    HT.NgayDi AS N'Ngày Đi',
                    HT.GioDi AS N'Giờ Đi',
                    V.SoGhe AS N'Số Ghế',
                    HT.GiaVe AS N'Giá Vé',
                    V.TenHanhKhach AS N'Tên Hành Khách',
                    V.TrangThai AS N'Trạng Thái'
                FROM 
                    Ve V
                JOIN 
                    HanhTrinh HT ON V.MaHanhTrinh = HT.MaHanhTrinh
                JOIN 
                    Tau T ON HT.MaTau = T.MaTau
                JOIN 
                    GaTau GDi ON HT.MaGaDi = GDi.MaGa
                JOIN 
                    GaTau GDen ON HT.MaGaDen = GDen.MaGa
                WHERE 
                    V.ThongTinLienHe = '{sdt}' 
                ORDER BY 
                    HT.NgayDi DESC, HT.GioDi DESC
            ";

            DataTable dt = kn.Lay_DuLieuBang(sql);
            DATA_VeDaDat.DataSource = dt;
            if (DATA_VeDaDat.Columns.Contains("Ngày Đi"))
            {
                DATA_VeDaDat.Columns["Ngày Đi"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show($"Không tìm thấy vé tàu nào với SĐT: **{sdt}**", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuyVe_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có dòng nào được chọn không
            if (DATA_VeDaDat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một vé trong danh sách để hủy.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy Mã Vé (cột đầu tiên) từ dòng được chọn
            // Giả định cột 'Mã Vé' là cột đầu tiên (index 0)
            int maVe;
            try
            {
                // Lấy giá trị của ô đầu tiên (MaVe) trong dòng được chọn
                string maVeStr = DATA_VeDaDat.SelectedRows[0].Cells["Mã Vé"].Value.ToString();
                maVe = Convert.ToInt32(maVeStr);
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể lấy Mã Vé. Vui lòng kiểm tra lại cấu trúc DataGridView.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Xác nhận hủy
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn hủy vé có Mã Vé: {maVe}?",
                                             "Xác nhận hủy",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                // 4. Thực hiện câu lệnh UPDATE
                string sqlUpdate = $"UPDATE Ve SET TrangThai = N'Đã hủy' WHERE MaVe = {maVe}";

                try
                {
                    kn.ThucThi(sqlUpdate); // Thực thi câu lệnh UPDATE
                    MessageBox.Show($"Đã hủy thành công vé có Mã Vé: {maVe}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Load lại danh sách vé sau khi hủy (gọi lại sự kiện tìm kiếm)
                    // Điều này giúp cập nhật ngay trạng thái 'Đã hủy' trên DataGridView
                    btnTimKiem_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hủy vé: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
