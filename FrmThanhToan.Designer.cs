namespace QUANLYBANVETAU
{
    partial class FrmThanhToan
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
            this.lblThongTinVe = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.btnXacNhanMuaVe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(549, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(349, 54);
            this.lblTieuDe.TabIndex = 4;
            this.lblTieuDe.Text = "THANH TOÁN VÉ";
            // 
            // lblThongTinVe
            // 
            this.lblThongTinVe.AutoSize = true;
            this.lblThongTinVe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTinVe.Location = new System.Drawing.Point(197, 150);
            this.lblThongTinVe.Name = "lblThongTinVe";
            this.lblThongTinVe.Size = new System.Drawing.Size(222, 38);
            this.lblThongTinVe.TabIndex = 5;
            this.lblThongTinVe.Text = "THÔNG TIN VÉ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(197, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 38);
            this.label1.TabIndex = 6;
            this.label1.Text = "NHẬP HỌ TÊN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(197, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 38);
            this.label2.TabIndex = 7;
            this.label2.Text = "NHẬP SỐ ĐIỆN THOẠI:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(558, 247);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(425, 45);
            this.txtHoTen.TabIndex = 20;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDienThoai.Location = new System.Drawing.Point(558, 352);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(425, 45);
            this.txtSoDienThoai.TabIndex = 21;
            // 
            // btnXacNhanMuaVe
            // 
            this.btnXacNhanMuaVe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanMuaVe.Location = new System.Drawing.Point(571, 512);
            this.btnXacNhanMuaVe.Name = "btnXacNhanMuaVe";
            this.btnXacNhanMuaVe.Size = new System.Drawing.Size(293, 50);
            this.btnXacNhanMuaVe.TabIndex = 22;
            this.btnXacNhanMuaVe.Text = "XÁC NHẬN MUA VÉ";
            this.btnXacNhanMuaVe.UseVisualStyleBackColor = true;
            this.btnXacNhanMuaVe.Click += new System.EventHandler(this.btnXacNhanMuaVe_Click);
            // 
            // FrmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 771);
            this.Controls.Add(this.btnXacNhanMuaVe);
            this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblThongTinVe);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "FrmThanhToan";
            this.Text = "FrmThanhToan";
            this.Load += new System.EventHandler(this.FrmThanhToan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblThongTinVe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Button btnXacNhanMuaVe;
    }
}