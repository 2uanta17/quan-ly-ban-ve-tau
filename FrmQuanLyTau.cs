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
    public partial class FrmQuanLyTau : Form
    {
        private KETNOI_CSDL db = new KETNOI_CSDL();
        public FrmQuanLyTau()
        {
            InitializeComponent();
            txtGioDi.Format = DateTimePickerFormat.Time;
            txtGioDi.ShowUpDown = true;
            txtGioDen.Format = DateTimePickerFormat.Time;
            txtGioDen.ShowUpDown = true;

            numGiaVe.Maximum = 99999999;
            numGiaVe.Minimum = 1000;
        }

        private void FrmQuanLyTau_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadHanhTrinh();
            ClearInputControls();

            DATA_QuanLyTau.SelectionChanged += DATA_QuanLyTau_SelectionChanged;
        }

        private void LoadComboBoxes()
        {
            string sqlTau = "SELECT MaTau, TenTau FROM Tau ORDER BY TenTau";
            DataTable dtTau = db.Lay_DuLieuBang(sqlTau);
            cboTau.DataSource = dtTau;
            cboTau.DisplayMember = "TenTau";
            cboTau.ValueMember = "MaTau";

            string sqlGa = "SELECT MaGa, TenGa FROM GaTau ORDER BY TenGa";
            DataTable dtGa1 = db.Lay_DuLieuBang(sqlGa);
            DataTable dtGa2 = dtGa1.Copy();

            cboGaDi.DataSource = dtGa1;
            cboGaDi.DisplayMember = "TenGa";
            cboGaDi.ValueMember = "MaGa";

            cboGaDen.DataSource = dtGa2;
            cboGaDen.DisplayMember = "TenGa";
            cboGaDen.ValueMember = "MaGa";
        }

        private void LoadHanhTrinh()
        {
            string sql = @"
                SELECT H.MaHanhTrinh, H.MaTau, T.TenTau, H.MaGaDi, GDi.TenGa AS GaDi, 
                       H.MaGaDen, GDen.TenGa AS GaDen, H.NgayDi, H.GioDi, H.GioDen, H.GiaVe
                FROM HanhTrinh H
                JOIN Tau T ON H.MaTau = T.MaTau
                JOIN GaTau GDi ON H.MaGaDi = GDi.MaGa
                JOIN GaTau GDen ON H.MaGaDen = GDen.MaGa
                ORDER BY H.NgayDi DESC, H.GioDi";

            try
            {
                DataTable dt = db.Lay_DuLieuBang(sql);

                DATA_QuanLyTau.DataSource = dt;

                DATA_QuanLyTau.Columns["MaHanhTrinh"].Visible = false;
                DATA_QuanLyTau.Columns["MaTau"].Visible = false;
                DATA_QuanLyTau.Columns["MaGaDi"].Visible = false;
                DATA_QuanLyTau.Columns["MaGaDen"].Visible = false;

                DATA_QuanLyTau.Columns["TenTau"].HeaderText = "Tàu";
                DATA_QuanLyTau.Columns["GaDi"].HeaderText = "Ga Đi";
                DATA_QuanLyTau.Columns["GaDen"].HeaderText = "Ga Đến";
                DATA_QuanLyTau.Columns["NgayDi"].HeaderText = "Ngày Đi";
                DATA_QuanLyTau.Columns["GioDi"].HeaderText = "Giờ Đi";
                DATA_QuanLyTau.Columns["GioDen"].HeaderText = "Giờ Đến";
                DATA_QuanLyTau.Columns["GiaVe"].HeaderText = "Giá Vé (VNĐ)";

                DATA_QuanLyTau.Columns["NgayDi"].DefaultCellStyle.Format = "dd/MM/yyyy";
                DATA_QuanLyTau.Columns["GiaVe"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Hành trình: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputControls()
        {
            txtMaHanhTrinh.Text = string.Empty;

            cboTau.SelectedIndex = -1;
            cboGaDi.SelectedIndex = -1;
            cboGaDen.SelectedIndex = -1;

            txtNgayDi.Value = DateTime.Now;
            txtGioDi.Value = DateTime.Today.AddHours(8);
            txtGioDen.Value = DateTime.Today.AddHours(10);
            numGiaVe.Value = 100000;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void DATA_QuanLyTau_SelectionChanged(object sender, EventArgs e)
        {
            if (DATA_QuanLyTau.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DATA_QuanLyTau.SelectedRows[0];


                txtMaHanhTrinh.Text = row.Cells["MaHanhTrinh"].Value.ToString();

                cboTau.SelectedValue = row.Cells["MaTau"].Value;
                cboGaDi.SelectedValue = row.Cells["MaGaDi"].Value;
                cboGaDen.SelectedValue = row.Cells["MaGaDen"].Value;

                //txtNgayDi.Value = (DateTime)row.Cells["NgayDi"].Value;
                object ngayDiValue = row.Cells["NgayDi"].Value;
                if (ngayDiValue != DBNull.Value)
                {
                    txtNgayDi.Value = Convert.ToDateTime(ngayDiValue);
                }
                else
                {
                    txtNgayDi.Value = DateTime.Today; // Gán mặc định nếu NULL
                }

                TimeSpan gioDiSpan;
                object gioDiValue = row.Cells["GioDi"].Value;
                if (gioDiValue != DBNull.Value)
                {
                    gioDiSpan = (TimeSpan)Convert.ChangeType(gioDiValue, typeof(TimeSpan));
                }
                else
                {
                    gioDiSpan = new TimeSpan(8, 0, 0);
                }

                TimeSpan gioDenSpan;
                object gioDenValue = row.Cells["GioDen"].Value;
                if (gioDenValue != DBNull.Value)
                {
                    gioDenSpan = (TimeSpan)Convert.ChangeType(gioDenValue, typeof(TimeSpan));
                }
                else
                {
                    gioDenSpan = new TimeSpan(10, 0, 0);
                }

                txtGioDi.Value = DateTime.Today.Add(gioDiSpan);
                txtGioDen.Value = DateTime.Today.Add(gioDenSpan);

                object giaVeValue = row.Cells["GiaVe"].Value;
                if (giaVeValue != DBNull.Value)
                {
                    numGiaVe.Value = Convert.ToDecimal(giaVeValue);
                }
                else
                {
                    numGiaVe.Value = 1000; // Gán mặc định nếu NULL
                }

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                ClearInputControls();
            }


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboTau.SelectedValue == null || cboGaDi.SelectedValue == null || cboGaDen.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Tàu, Ga đi và Ga đến.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTau = (int)cboTau.SelectedValue;
            int maGaDi = (int)cboGaDi.SelectedValue;
            int maGaDen = (int)cboGaDen.SelectedValue;

            DateTime ngayDi = txtNgayDi.Value.Date;
            TimeSpan gioDi = txtGioDi.Value.TimeOfDay;
            TimeSpan gioDen = txtGioDen.Value.TimeOfDay;
            decimal giaVe = numGiaVe.Value;

            string sql = $@"
                INSERT INTO HanhTrinh (MaTau, MaGaDi, MaGaDen, NgayDi, GioDi, GioDen, GiaVe)
                VALUES ({maTau}, {maGaDi}, {maGaDen}, '{ngayDi:yyyy-MM-dd}', '{gioDi}', '{gioDen}', {giaVe})";

            try
            {
                db.ThucThi(sql);
                MessageBox.Show("Thêm Hành trình mới thành công.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHanhTrinh();
                ClearInputControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm Hành trình: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHanhTrinh.Text))
            {
                MessageBox.Show("Vui lòng chọn Hành trình cần sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHanhTrinh = int.Parse(txtMaHanhTrinh.Text);
            if (DATA_QuanLyTau.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn Hành trình cần sửa trên lưới.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTau = (int)cboTau.SelectedValue;
            int maGaDi = (int)cboGaDi.SelectedValue;
            int maGaDen = (int)cboGaDen.SelectedValue;

            DateTime ngayDi = txtNgayDi.Value.Date;
            TimeSpan gioDi = txtGioDi.Value.TimeOfDay;
            TimeSpan gioDen = txtGioDen.Value.TimeOfDay;
            decimal giaVe = numGiaVe.Value;

            string sql = $@"
                UPDATE HanhTrinh 
                SET MaTau = {maTau}, MaGaDi = {maGaDi}, MaGaDen = {maGaDen}, 
                    NgayDi = '{ngayDi:yyyy-MM-dd}', GioDi = '{gioDi}', GioDen = '{gioDen}', GiaVe = {giaVe}
                WHERE MaHanhTrinh = {maHanhTrinh}";

            try
            {
                db.ThucThi(sql);
                MessageBox.Show("Cập nhật Hành trình thành công.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHanhTrinh();
                ClearInputControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật Hành trình: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHanhTrinh.Text))
            {
                MessageBox.Show("Vui lòng chọn Hành trình cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHanhTrinh = int.Parse(txtMaHanhTrinh.Text);
            if (DATA_QuanLyTau.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn Hành trình cần xóa trên lưới.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sqlCheck = $"SELECT COUNT(*) FROM Ve WHERE MaHanhTrinh = {maHanhTrinh}";
            DataTable dtCheck = db.Lay_DuLieuBang(sqlCheck);
            int countVe = (int)dtCheck.Rows[0][0];

            if (countVe > 0)
            {
                MessageBox.Show($"Không thể xóa hành trình này vì đã có {countVe} vé được bán.", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa Hành trình này không?",
                "Xác nhận Xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string sqlDelete = $"DELETE FROM HanhTrinh WHERE MaHanhTrinh = {maHanhTrinh}";

                try
                {
                    db.ThucThi(sqlDelete);
                    MessageBox.Show("Xóa Hành trình thành công.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHanhTrinh();
                    ClearInputControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa Hành trình: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
