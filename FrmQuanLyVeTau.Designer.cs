namespace QUANLYBANVETAU
{
    partial class FrmQuanLyVeTau
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblNhapThongTin = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnInThongTin = new System.Windows.Forms.Button();
            this.DATA_QuanLyVeTau = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DATA_QuanLyVeTau)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(565, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(343, 54);
            this.lblTieuDe.TabIndex = 3;
            this.lblTieuDe.Text = "QUẢN LÝ VÉ TÀU";
            // 
            // lblNhapThongTin
            // 
            this.lblNhapThongTin.AutoSize = true;
            this.lblNhapThongTin.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhapThongTin.Location = new System.Drawing.Point(100, 135);
            this.lblNhapThongTin.Name = "lblNhapThongTin";
            this.lblNhapThongTin.Size = new System.Drawing.Size(268, 38);
            this.lblNhapThongTin.TabIndex = 4;
            this.lblNhapThongTin.Text = "NHẬP THÔNG TIN:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(374, 135);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(425, 45);
            this.txtTimKiem.TabIndex = 19;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(837, 135);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(248, 50);
            this.btnTimKiem.TabIndex = 20;
            this.btnTimKiem.Text = "TÌM KIẾM";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnInThongTin
            // 
            this.btnInThongTin.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInThongTin.Location = new System.Drawing.Point(1104, 135);
            this.btnInThongTin.Name = "btnInThongTin";
            this.btnInThongTin.Size = new System.Drawing.Size(248, 50);
            this.btnInThongTin.TabIndex = 21;
            this.btnInThongTin.Text = "IN THÔNG TIN";
            this.btnInThongTin.UseVisualStyleBackColor = true;
            this.btnInThongTin.Click += new System.EventHandler(this.btnInThongTin_Click);
            // 
            // DATA_QuanLyVeTau
            // 
            this.DATA_QuanLyVeTau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DATA_QuanLyVeTau.Location = new System.Drawing.Point(107, 233);
            this.DATA_QuanLyVeTau.Name = "DATA_QuanLyVeTau";
            this.DATA_QuanLyVeTau.RowHeadersWidth = 62;
            this.DATA_QuanLyVeTau.RowTemplate.Height = 28;
            this.DATA_QuanLyVeTau.Size = new System.Drawing.Size(1245, 509);
            this.DATA_QuanLyVeTau.TabIndex = 22;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(1373, 135);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(248, 50);
            this.btnXoa.TabIndex = 23;
            this.btnXoa.Text = "XÓA";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // FrmQuanLyVeTau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1655, 771);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.DATA_QuanLyVeTau);
            this.Controls.Add(this.btnInThongTin);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblNhapThongTin);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "FrmQuanLyVeTau";
            this.Text = "FrmQuanLyVeTau";
            this.Load += new System.EventHandler(this.FrmQuanLyVeTau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DATA_QuanLyVeTau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblNhapThongTin;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnInThongTin;
        private System.Windows.Forms.DataGridView DATA_QuanLyVeTau;
        private System.Windows.Forms.Button btnXoa;
    }
}