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
    public partial class FrmChonCho : Form
    {
        private List<HanhTrinhViewModel> dsHanhTrinh;
        private int selectedMaHanhTrinh;
        private int selectedSoGhe;
        private string selectedTenTau = "";
        private decimal selectedGiaVe;

        private KETNOI_CSDL db = new KETNOI_CSDL();
        public FrmChonCho()
        {
            InitializeComponent();
            this.dsHanhTrinh = new List<HanhTrinhViewModel>();
        }

        public FrmChonCho(List<HanhTrinhViewModel> danhSachHanhTrinh)
        {
            InitializeComponent();
            this.dsHanhTrinh = danhSachHanhTrinh;
        }

        private void FrmChonCho_Load(object sender, EventArgs e)
        {
            btnMuaVe.Enabled = false;
            grpChonTau.Controls.Clear();

            LoadDanhSachTau();

            lblVeChonTau.Text = "CHƯA CHỌN TÀU";
            lblVeChonGhe.Text = "CHƯA CHỌN GHẾ";
            lblGiaVe.Text = "0 VNĐ";
        }

        private void LoadDanhSachTau()
        {
            if (dsHanhTrinh == null || dsHanhTrinh.Count == 0)
            {
                MessageBox.Show("Không có hành trình nào.");
                return;
            }

            int yPos = 50;

            foreach (var ht in dsHanhTrinh)
            {
                RadioButton rb = new RadioButton();

                rb.Text = $"{ht.TenTau} ({ht.GioDi:hh\\:mm} - {ht.GioDen:hh\\:mm}) - {ht.GiaVe:N0} VNĐ";
                rb.Tag = ht.MaHanhTrinh;
                rb.AutoSize = true;
                rb.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                rb.Location = new Point(25, yPos);
                rb.CheckedChanged += RadioButtonTau_CheckedChanged;

                grpChonTau.Controls.Add(rb);

                yPos += 40;
            }
        }

        private void RadioButtonTau_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null || rb.Tag == null)
            {
                return;
            }

            if (rb.Checked)
            {
                selectedMaHanhTrinh = (int)rb.Tag;

                var hanhTrinhDaChon = dsHanhTrinh.FirstOrDefault(ht => ht.MaHanhTrinh == selectedMaHanhTrinh);
                if (hanhTrinhDaChon != null)
                {
                    selectedTenTau = hanhTrinhDaChon.TenTau;
                    selectedGiaVe = hanhTrinhDaChon.GiaVe;
                }

                lblVeChonTau.Text = $"TÀU {selectedTenTau}";
                lblVeChonGhe.Text = "CHƯA CHỌN GHẾ";
                lblGiaVe.Text = "0 VNĐ";
                btnMuaVe.Enabled = false;

                LoadDanhSachGhe(selectedMaHanhTrinh);
            }
        }

        private void LoadDanhSachGhe(int maHanhTrinh)
        {
            flpChonCho.Controls.Clear();

            List<int> danhSachGheDaDat = new List<int>();

            string sql_tam_thoi = $"SELECT SoGhe FROM Ve WHERE MaHanhTrinh = {maHanhTrinh} AND TrangThai = N'Đã đặt'";
            DataTable dt = db.Lay_DuLieuBang(sql_tam_thoi);


            foreach (DataRow row in dt.Rows)
            {
                danhSachGheDaDat.Add((int)row["SoGhe"]);
            }

            for (int i = 1; i <= 51; i++)
            {
                Button btnGhe = new Button();
                btnGhe.Text = i.ToString();
                btnGhe.Tag = i;
                btnGhe.Size = new Size(60, 60);
                btnGhe.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btnGhe.Margin = new Padding(5);

                if (danhSachGheDaDat.Contains(i))
                {
                    btnGhe.Enabled = false;
                    btnGhe.BackColor = Color.IndianRed;
                    btnGhe.ForeColor = Color.White;
                }
                else
                {
                    btnGhe.Enabled = true;
                    btnGhe.BackColor = Color.Honeydew;
                    btnGhe.Cursor = Cursors.Hand;
                    btnGhe.Click += BtnGhe_Click;
                }

                flpChonCho.Controls.Add(btnGhe);
            }
        }

        private void BtnGhe_Click(object sender, EventArgs e)
        {
            Button btnGhe = sender as Button;

            if (btnGhe == null || btnGhe.Tag == null)
            {
                return;
            }

            selectedSoGhe = (int)btnGhe.Tag;

            lblVeChonGhe.Text = $"GHẾ SỐ {selectedSoGhe}";
            lblGiaVe.Text = $"{selectedGiaVe:N0} VNĐ";
            btnMuaVe.Enabled = true;

            foreach (Control ctrl in flpChonCho.Controls)
            {
                if (ctrl is Button)
                {
                    Button ghe = (Button)ctrl;
                    if (ghe.Enabled)
                    {
                        ghe.BackColor = Color.Honeydew;
                    }
                }
            }
            btnGhe.BackColor = Color.Gold;
        }

        private void btnMuaVe_Click(object sender, EventArgs e)
        {
            FrmThanhToan frmTT = new FrmThanhToan(
            selectedMaHanhTrinh,
            selectedSoGhe,
            selectedTenTau,
            selectedGiaVe
             );

            DialogResult result = frmTT.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadDanhSachGhe(selectedMaHanhTrinh);

                lblVeChonGhe.Text = "CHƯA CHỌN GHẾ";
                lblGiaVe.Text = "0 VNĐ";
                btnMuaVe.Enabled = false;
            }
        }

        private void btnQuayVe_Click(object sender, EventArgs e)
        {
            var frmTimKiem = Application.OpenForms.OfType<FrmTimKiemVeTau>().FirstOrDefault();

            if (frmTimKiem != null)
            {
                frmTimKiem.Show();
            }
            else
            {
                FrmTimKiemVeTau frmMoi = new FrmTimKiemVeTau();
                frmMoi.Show();
            }

            this.Close();
        }
    }

    public class HanhTrinhViewModel
    {
        public int MaHanhTrinh { get; set; }
        public string TenTau { get; set; }
        public TimeSpan GioDi { get; set; }
        public TimeSpan GioDen { get; set; }
        public decimal GiaVe { get; set; }
    }
}
