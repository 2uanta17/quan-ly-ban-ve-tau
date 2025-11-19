namespace QUANLYBANVETAU
{
    partial class FrmTimKiemVeTau
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
            this.cboGaDi = new System.Windows.Forms.ComboBox();
            this.lblGaDi = new System.Windows.Forms.Label();
            this.cboGaDen = new System.Windows.Forms.ComboBox();
            this.lblGaDen = new System.Windows.Forms.Label();
            this.txtNgayDi = new System.Windows.Forms.DateTimePicker();
            this.lblNgayDi = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.DATA_VeTau = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DATA_VeTau)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(449, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(354, 54);
            this.lblTieuDe.TabIndex = 5;
            this.lblTieuDe.Text = "TÌM KIẾM VÉ TÀU";
            // 
            // cboGaDi
            // 
            this.cboGaDi.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGaDi.FormattingEnabled = true;
            this.cboGaDi.Location = new System.Drawing.Point(265, 101);
            this.cboGaDi.Name = "cboGaDi";
            this.cboGaDi.Size = new System.Drawing.Size(275, 46);
            this.cboGaDi.TabIndex = 18;
            // 
            // lblGaDi
            // 
            this.lblGaDi.AutoSize = true;
            this.lblGaDi.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGaDi.Location = new System.Drawing.Point(119, 104);
            this.lblGaDi.Name = "lblGaDi";
            this.lblGaDi.Size = new System.Drawing.Size(103, 38);
            this.lblGaDi.TabIndex = 17;
            this.lblGaDi.Text = "GA ĐI:";
            // 
            // cboGaDen
            // 
            this.cboGaDen.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGaDen.FormattingEnabled = true;
            this.cboGaDen.Location = new System.Drawing.Point(887, 104);
            this.cboGaDen.Name = "cboGaDen";
            this.cboGaDen.Size = new System.Drawing.Size(275, 46);
            this.cboGaDen.TabIndex = 20;
            // 
            // lblGaDen
            // 
            this.lblGaDen.AutoSize = true;
            this.lblGaDen.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGaDen.Location = new System.Drawing.Point(720, 104);
            this.lblGaDen.Name = "lblGaDen";
            this.lblGaDen.Size = new System.Drawing.Size(131, 38);
            this.lblGaDen.TabIndex = 19;
            this.lblGaDen.Text = "GA ĐẾN:";
            // 
            // txtNgayDi
            // 
            this.txtNgayDi.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayDi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtNgayDi.Location = new System.Drawing.Point(265, 202);
            this.txtNgayDi.Name = "txtNgayDi";
            this.txtNgayDi.Size = new System.Drawing.Size(275, 45);
            this.txtNgayDi.TabIndex = 22;
            // 
            // lblNgayDi
            // 
            this.lblNgayDi.AutoSize = true;
            this.lblNgayDi.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayDi.Location = new System.Drawing.Point(82, 202);
            this.lblNgayDi.Name = "lblNgayDi";
            this.lblNgayDi.Size = new System.Drawing.Size(140, 38);
            this.lblNgayDi.TabIndex = 21;
            this.lblNgayDi.Text = "NGÀY ĐI:";
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(499, 288);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(248, 50);
            this.btnThem.TabIndex = 23;
            this.btnThem.Text = "TÌM KIẾM";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // DATA_VeTau
            // 
            this.DATA_VeTau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DATA_VeTau.Location = new System.Drawing.Point(89, 380);
            this.DATA_VeTau.Name = "DATA_VeTau";
            this.DATA_VeTau.RowHeadersWidth = 62;
            this.DATA_VeTau.RowTemplate.Height = 28;
            this.DATA_VeTau.Size = new System.Drawing.Size(1073, 345);
            this.DATA_VeTau.TabIndex = 24;
            // 
            // FrmTimKiemVeTau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 756);
            this.Controls.Add(this.DATA_VeTau);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtNgayDi);
            this.Controls.Add(this.lblNgayDi);
            this.Controls.Add(this.cboGaDen);
            this.Controls.Add(this.lblGaDen);
            this.Controls.Add(this.cboGaDi);
            this.Controls.Add(this.lblGaDi);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "FrmTimKiemVeTau";
            this.Text = "FrmTimKiemVeTau";
            this.Load += new System.EventHandler(this.FrmTimKiemVeTau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DATA_VeTau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.ComboBox cboGaDi;
        private System.Windows.Forms.Label lblGaDi;
        private System.Windows.Forms.ComboBox cboGaDen;
        private System.Windows.Forms.Label lblGaDen;
        private System.Windows.Forms.DateTimePicker txtNgayDi;
        private System.Windows.Forms.Label lblNgayDi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView DATA_VeTau;
    }
}