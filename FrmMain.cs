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
    public partial class FrmMain : Form
    {
        private int childFormNumber = 0;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        public bool IsLoggedInQuanLy = false;

        public void KiemTraQuyen()
        {
            // Tìm và vô hiệu hóa/ẩn menu QUẢN LÝ nếu IsLoggedInQuanLy là false
            // Bạn cần thay thế tên biến menu chính xác của menu QUẢN LÝ trong FrmMain.Designer.cs
            // Ví dụ: Giả sử menu QUẢN LÝ có tên là 'quanLyToolStripMenuItem'
            if (mnuQuanLy != null)
            {
                // Chỉ cho phép menu QUẢN LÝ hiển thị nếu đã đăng nhập thành công
                mnuQuanLy.Visible = IsLoggedInQuanLy;
            }
        }

        private void mnuQuanLyVeTau_Click(object sender, EventArgs e)
        {
            FrmQuanLyVeTau frmQuanLyVeTau = new FrmQuanLyVeTau();
            frmQuanLyVeTau.Show();
        }

        private void mnuQuanLyTau_Click(object sender, EventArgs e)
        {
            FrmQuanLyTau frmQuanLyTau = new FrmQuanLyTau();
            frmQuanLyTau.Show();
        }

        private void mnuTimKiemVeTau_Click(object sender, EventArgs e)
        {
            FrmTimKiemVeTau frmTimKiemVeTau = new FrmTimKiemVeTau();
            frmTimKiemVeTau.Show();
        }

        private void mnuTimKiemVeDaDat_Click(object sender, EventArgs e)
        {
            FrmTimKiemVeDaDat frmTimKiemVeDaDat = new FrmTimKiemVeDaDat();
            frmTimKiemVeDaDat.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            KiemTraQuyen();
            FrmDangNhap fdn = new FrmDangNhap(this); // Truyền tham chiếu Form Main
            fdn.ShowDialog();
        }
    }
}
