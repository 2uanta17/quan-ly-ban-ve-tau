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
    public partial class FrmTimKiemVeTau : Form
    {
        private KETNOI_CSDL db = new KETNOI_CSDL();

        private List<HanhTrinhViewModel> dsHanhTrinhTimDuoc;
        public FrmTimKiemVeTau()
        {
            InitializeComponent();
        }

        private void FrmTimKiemVeTau_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            DATA_VeTau.CellDoubleClick += DATA_VeTau_CellDoubleClick;

            DATA_VeTau.ReadOnly = true;
            DATA_VeTau.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DATA_VeTau.AllowUserToAddRows = false;
            DATA_VeTau.AllowUserToDeleteRows = false;
            DATA_VeTau.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadComboBoxes()
        {
            try
            {
                DataTable dtGa = db.Lay_DuLieuBang("SELECT TenGa FROM GaTau ORDER BY TenGa");

                List<string> dsGaDi = new List<string>();
                List<string> dsGaDen = new List<string>();

                foreach (DataRow row in dtGa.Rows)
                {
                    string tenGa = row["TenGa"]?.ToString() ?? "";
                    dsGaDi.Add(tenGa);
                    dsGaDen.Add(tenGa);
                }

                cboGaDi.DataSource = dsGaDi;
                cboGaDen.DataSource = dsGaDen;

                cboGaDi.SelectedItem = "Hà Nội";
                cboGaDen.SelectedItem = "Hải Phòng";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách ga: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string gaDi = cboGaDi.Text;
            string gaDen = cboGaDen.Text;
            DateTime ngayDi = txtNgayDi.Value.Date;

            if (string.IsNullOrEmpty(gaDi) || string.IsNullOrEmpty(gaDen))
            {
                MessageBox.Show("Vui lòng chọn ga đi và ga đến.");
                return;
            }

            if (gaDi == gaDen)
            {
                MessageBox.Show("Ga đi và ga đến không được trùng nhau.");
                return;
            }

            string sql = $@"
                SELECT H.MaHanhTrinh, T.TenTau, H.GioDi, H.GioDen, H.GiaVe 
                FROM HanhTrinh H
                JOIN Tau T ON H.MaTau = T.MaTau
                JOIN GaTau GDi ON H.MaGaDi = GDi.MaGa
                JOIN GaTau GDen ON H.MaGaDen = GDen.MaGa
                WHERE GDi.TenGa = N'{gaDi}' 
                  AND GDen.TenGa = N'{gaDen}' 
                  AND H.NgayDi = '{ngayDi.ToString("yyyy-MM-dd")}';
            ";

            try
            {
                DataTable dt = db.Lay_DuLieuBang(sql);

                dsHanhTrinhTimDuoc = new List<HanhTrinhViewModel>();

                foreach (DataRow row in dt.Rows)
                {
                    HanhTrinhViewModel ht = new HanhTrinhViewModel
                    {
                        MaHanhTrinh = (int)row["MaHanhTrinh"],
                        TenTau = row["TenTau"]?.ToString() ?? "N/A",
                        GioDi = (TimeSpan)row["GioDi"],
                        GioDen = (TimeSpan)row["GioDen"],
                        GiaVe = (decimal)row["GiaVe"]
                    };
                    dsHanhTrinhTimDuoc.Add(ht);
                }

                DATA_VeTau.DataSource = dsHanhTrinhTimDuoc;

                DATA_VeTau.Columns["MaHanhTrinh"].Visible = false;
                DATA_VeTau.Columns["TenTau"].HeaderText = "Tên Tàu";
                DATA_VeTau.Columns["GioDi"].HeaderText = "Giờ Đi";
                DATA_VeTau.Columns["GioDen"].HeaderText = "Giờ Đến";
                DATA_VeTau.Columns["GiaVe"].HeaderText = "Giá Vé";
                DATA_VeTau.Columns["GiaVe"].DefaultCellStyle.Format = "N0";

                if (dsHanhTrinhTimDuoc.Count > 0)
                {
                    MessageBox.Show($"Tìm thấy {dsHanhTrinhTimDuoc.Count} chuyến tàu.\n" +
                                    $"Vui lòng NHẤP ĐÚP CHUỘT vào chuyến tàu bạn muốn để chọn chỗ.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hành trình phù hợp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void DATA_VeTau_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dsHanhTrinhTimDuoc == null || dsHanhTrinhTimDuoc.Count == 0)
            {
                MessageBox.Show("Bạn phải tìm kiếm trước khi chọn.");
                return;
            }

            if (e.RowIndex >= 0)
            {
                FrmChonCho frmChon = new FrmChonCho(dsHanhTrinhTimDuoc);

                frmChon.FormClosed += (s, args) => this.Show();

                frmChon.Show();
                this.Hide();
            }
        }
    }
}
