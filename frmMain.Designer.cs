namespace TVGenCode
{
    partial class frmMain
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
            this.btnKetNoiCoSoDuLieu = new System.Windows.Forms.Button();
            this.txtDuongDanSolution = new System.Windows.Forms.TextBox();
            this.btnNoiLuuSolution = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnTaoThuTuc = new System.Windows.Forms.Button();
            this.btnTaoMaEntity = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTaoMaBaseData = new System.Windows.Forms.Button();
            this.btnTaoMaBusiness = new System.Windows.Forms.Button();
            this.btnTaoMaToanDuAn = new System.Windows.Forms.Button();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnTaoMaData = new System.Windows.Forms.Button();
            this.btnTuyChon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKetNoiCoSoDuLieu
            // 
            this.btnKetNoiCoSoDuLieu.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnKetNoiCoSoDuLieu.Location = new System.Drawing.Point(350, 42);
            this.btnKetNoiCoSoDuLieu.Name = "btnKetNoiCoSoDuLieu";
            this.btnKetNoiCoSoDuLieu.Size = new System.Drawing.Size(119, 55);
            this.btnKetNoiCoSoDuLieu.TabIndex = 4;
            this.btnKetNoiCoSoDuLieu.Text = "Kết nối CSDL";
            this.btnKetNoiCoSoDuLieu.UseVisualStyleBackColor = true;
            this.btnKetNoiCoSoDuLieu.Click += new System.EventHandler(this.btnKetNoiCoSoDuLieu_Click);
            // 
            // txtDuongDanSolution
            // 
            this.txtDuongDanSolution.Enabled = false;
            this.txtDuongDanSolution.Location = new System.Drawing.Point(12, 138);
            this.txtDuongDanSolution.Name = "txtDuongDanSolution";
            this.txtDuongDanSolution.Size = new System.Drawing.Size(312, 20);
            this.txtDuongDanSolution.TabIndex = 5;
            // 
            // btnNoiLuuSolution
            // 
            this.btnNoiLuuSolution.Enabled = false;
            this.btnNoiLuuSolution.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNoiLuuSolution.Location = new System.Drawing.Point(350, 133);
            this.btnNoiLuuSolution.Name = "btnNoiLuuSolution";
            this.btnNoiLuuSolution.Size = new System.Drawing.Size(119, 29);
            this.btnNoiLuuSolution.TabIndex = 6;
            this.btnNoiLuuSolution.Text = "Chọn thư mục dự án";
            this.btnNoiLuuSolution.UseVisualStyleBackColor = true;
            this.btnNoiLuuSolution.Click += new System.EventHandler(this.btnNoiLuuSolution_Click);
            // 
            // btnTaoThuTuc
            // 
            this.btnTaoThuTuc.Enabled = false;
            this.btnTaoThuTuc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnTaoThuTuc.Location = new System.Drawing.Point(127, 187);
            this.btnTaoThuTuc.Name = "btnTaoThuTuc";
            this.btnTaoThuTuc.Size = new System.Drawing.Size(106, 40);
            this.btnTaoThuTuc.TabIndex = 7;
            this.btnTaoThuTuc.Text = "Tạo thủ tục";
            this.btnTaoThuTuc.UseVisualStyleBackColor = true;
            this.btnTaoThuTuc.Click += new System.EventHandler(this.btnTaoThuTuc_Click);
            // 
            // btnTaoMaEntity
            // 
            this.btnTaoMaEntity.Enabled = false;
            this.btnTaoMaEntity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnTaoMaEntity.Location = new System.Drawing.Point(377, 187);
            this.btnTaoMaEntity.Name = "btnTaoMaEntity";
            this.btnTaoMaEntity.Size = new System.Drawing.Size(99, 40);
            this.btnTaoMaEntity.TabIndex = 8;
            this.btnTaoMaEntity.Text = "Entity";
            this.btnTaoMaEntity.UseVisualStyleBackColor = true;
            this.btnTaoMaEntity.Click += new System.EventHandler(this.btnTaoMaEntity_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(190, 31);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(134, 20);
            this.txtUserID.TabIndex = 9;
            this.txtUserID.Text = "truongviet";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 91);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(137, 20);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.Text = "123";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(190, 91);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(134, 20);
            this.txtDBName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Server Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "User ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "DB Name:";
            // 
            // btnTaoMaBaseData
            // 
            this.btnTaoMaBaseData.Enabled = false;
            this.btnTaoMaBaseData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnTaoMaBaseData.Location = new System.Drawing.Point(12, 252);
            this.btnTaoMaBaseData.Name = "btnTaoMaBaseData";
            this.btnTaoMaBaseData.Size = new System.Drawing.Size(99, 32);
            this.btnTaoMaBaseData.TabIndex = 16;
            this.btnTaoMaBaseData.Text = "Base Data";
            this.btnTaoMaBaseData.UseVisualStyleBackColor = true;
            this.btnTaoMaBaseData.Click += new System.EventHandler(this.btnTaoMaBaseData_Click);
            // 
            // btnTaoMaBusiness
            // 
            this.btnTaoMaBusiness.Enabled = false;
            this.btnTaoMaBusiness.Location = new System.Drawing.Point(251, 252);
            this.btnTaoMaBusiness.Name = "btnTaoMaBusiness";
            this.btnTaoMaBusiness.Size = new System.Drawing.Size(109, 32);
            this.btnTaoMaBusiness.TabIndex = 17;
            this.btnTaoMaBusiness.Text = "Business";
            this.btnTaoMaBusiness.UseVisualStyleBackColor = true;
            this.btnTaoMaBusiness.Click += new System.EventHandler(this.btnTaoMaBusiness_Click);
            // 
            // btnTaoMaToanDuAn
            // 
            this.btnTaoMaToanDuAn.Enabled = false;
            this.btnTaoMaToanDuAn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnTaoMaToanDuAn.Location = new System.Drawing.Point(251, 187);
            this.btnTaoMaToanDuAn.Name = "btnTaoMaToanDuAn";
            this.btnTaoMaToanDuAn.Size = new System.Drawing.Size(109, 40);
            this.btnTaoMaToanDuAn.TabIndex = 19;
            this.btnTaoMaToanDuAn.Text = "Tạo mã toàn dự án";
            this.btnTaoMaToanDuAn.UseVisualStyleBackColor = true;
            this.btnTaoMaToanDuAn.Click += new System.EventHandler(this.btnTaoMaToanDuAn_Click);
            // 
            // cmbServer
            // 
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(12, 31);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(137, 21);
            this.cmbServer.TabIndex = 20;
            this.cmbServer.Text = "TVSERVER";
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(377, 252);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 32);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnTaoMaData
            // 
            this.btnTaoMaData.Enabled = false;
            this.btnTaoMaData.Location = new System.Drawing.Point(127, 252);
            this.btnTaoMaData.Name = "btnTaoMaData";
            this.btnTaoMaData.Size = new System.Drawing.Size(106, 32);
            this.btnTaoMaData.TabIndex = 18;
            this.btnTaoMaData.Text = "Data";
            this.btnTaoMaData.UseVisualStyleBackColor = true;
            this.btnTaoMaData.Click += new System.EventHandler(this.btnTaoMaData_Click);
            // 
            // btnTuyChon
            // 
            this.btnTuyChon.Enabled = false;
            this.btnTuyChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnTuyChon.Location = new System.Drawing.Point(12, 187);
            this.btnTuyChon.Name = "btnTuyChon";
            this.btnTuyChon.Size = new System.Drawing.Size(99, 40);
            this.btnTuyChon.TabIndex = 16;
            this.btnTuyChon.Text = "Tùy chọn";
            this.btnTuyChon.UseVisualStyleBackColor = true;
            this.btnTuyChon.Click += new System.EventHandler(this.btnTuyChon_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 298);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmbServer);
            this.Controls.Add(this.btnTaoMaToanDuAn);
            this.Controls.Add(this.btnTaoMaData);
            this.Controls.Add(this.btnTaoMaBusiness);
            this.Controls.Add(this.btnTuyChon);
            this.Controls.Add(this.btnTaoMaBaseData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.btnTaoMaEntity);
            this.Controls.Add(this.btnTaoThuTuc);
            this.Controls.Add(this.btnNoiLuuSolution);
            this.Controls.Add(this.txtDuongDanSolution);
            this.Controls.Add(this.btnKetNoiCoSoDuLieu);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRUONG VIET - SINH MA TU DONG";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKetNoiCoSoDuLieu;
        private System.Windows.Forms.TextBox txtDuongDanSolution;
        private System.Windows.Forms.Button btnNoiLuuSolution;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnTaoThuTuc;
        private System.Windows.Forms.Button btnTaoMaEntity;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTaoMaBaseData;
        private System.Windows.Forms.Button btnTaoMaBusiness;
        private System.Windows.Forms.Button btnTaoMaToanDuAn;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTaoMaData;
        private System.Windows.Forms.Button btnTuyChon;
    }
}

