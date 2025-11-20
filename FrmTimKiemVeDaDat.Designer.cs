namespace QUANLYBANVETAU
{
    partial class FrmTimKiemVeDaDat
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
            this.btnInVe = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblNhapSDT = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.DATA_VeDaDat = new System.Windows.Forms.DataGridView();
            this.btnHuyVe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DATA_VeDaDat)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInVe
            // 
            this.btnInVe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInVe.Location = new System.Drawing.Point(85, 362);
            this.btnInVe.Name = "btnInVe";
            this.btnInVe.Size = new System.Drawing.Size(248, 50);
            this.btnInVe.TabIndex = 27;
            this.btnInVe.Text = "IN VÉ";
            this.btnInVe.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(85, 275);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(248, 50);
            this.btnTimKiem.TabIndex = 26;
            this.btnTimKiem.Text = "TÌM KIẾM";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(85, 193);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(248, 45);
            this.txtSDT.TabIndex = 25;
            // 
            // lblNhapSDT
            // 
            this.lblNhapSDT.AutoSize = true;
            this.lblNhapSDT.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhapSDT.Location = new System.Drawing.Point(78, 130);
            this.lblNhapSDT.Name = "lblNhapSDT";
            this.lblNhapSDT.Size = new System.Drawing.Size(320, 38);
            this.lblNhapSDT.TabIndex = 24;
            this.lblNhapSDT.Text = "NHẬP SỐ ĐIỆN THOẠI:";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(552, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(344, 54);
            this.lblTieuDe.TabIndex = 23;
            this.lblTieuDe.Text = "TRA CỨU VÉ TÀU";
            // 
            // DATA_VeDaDat
            // 
            this.DATA_VeDaDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DATA_VeDaDat.Location = new System.Drawing.Point(442, 130);
            this.DATA_VeDaDat.Name = "DATA_VeDaDat";
            this.DATA_VeDaDat.RowHeadersWidth = 62;
            this.DATA_VeDaDat.RowTemplate.Height = 28;
            this.DATA_VeDaDat.Size = new System.Drawing.Size(952, 695);
            this.DATA_VeDaDat.TabIndex = 28;
            // 
            // btnHuyVe
            // 
            this.btnHuyVe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyVe.Location = new System.Drawing.Point(85, 450);
            this.btnHuyVe.Name = "btnHuyVe";
            this.btnHuyVe.Size = new System.Drawing.Size(248, 50);
            this.btnHuyVe.TabIndex = 29;
            this.btnHuyVe.Text = "HỦY VÉ";
            this.btnHuyVe.UseVisualStyleBackColor = true;
            this.btnHuyVe.Click += new System.EventHandler(this.btnHuyVe_Click);
            // 
            // FrmTimKiemVeDaDat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 894);
            this.Controls.Add(this.btnHuyVe);
            this.Controls.Add(this.DATA_VeDaDat);
            this.Controls.Add(this.btnInVe);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.lblNhapSDT);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "FrmTimKiemVeDaDat";
            this.Text = "FrmTimKiemVeDaDat";
            ((System.ComponentModel.ISupportInitialize)(this.DATA_VeDaDat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnInVe;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblNhapSDT;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.DataGridView DATA_VeDaDat;
        private System.Windows.Forms.Button btnHuyVe;
    }
}