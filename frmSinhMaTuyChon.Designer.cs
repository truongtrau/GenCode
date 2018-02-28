namespace TVGenCode
{
    partial class frmSinhMaTuyChon
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
            this.btnData = new System.Windows.Forms.Button();
            this.btnBusiness = new System.Windows.Forms.Button();
            this.btnBaseData = new System.Windows.Forms.Button();
            this.btnEntity = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grdTable = new DevExpress.XtraGrid.GridControl();
            this.grvTable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnTaoThuTuc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTable)).BeginInit();
            this.SuspendLayout();
            // 
            // btnData
            // 
            this.btnData.Enabled = false;
            this.btnData.Location = new System.Drawing.Point(373, 465);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(77, 32);
            this.btnData.TabIndex = 27;
            this.btnData.Text = "Data";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // btnBusiness
            // 
            this.btnBusiness.Enabled = false;
            this.btnBusiness.Location = new System.Drawing.Point(474, 465);
            this.btnBusiness.Name = "btnBusiness";
            this.btnBusiness.Size = new System.Drawing.Size(77, 32);
            this.btnBusiness.TabIndex = 26;
            this.btnBusiness.Text = "Business";
            this.btnBusiness.UseVisualStyleBackColor = true;
            this.btnBusiness.Click += new System.EventHandler(this.btnBusiness_Click);
            // 
            // btnBaseData
            // 
            this.btnBaseData.Enabled = false;
            this.btnBaseData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnBaseData.Location = new System.Drawing.Point(272, 465);
            this.btnBaseData.Name = "btnBaseData";
            this.btnBaseData.Size = new System.Drawing.Size(77, 32);
            this.btnBaseData.TabIndex = 25;
            this.btnBaseData.Text = "Base Data";
            this.btnBaseData.UseVisualStyleBackColor = true;
            this.btnBaseData.Click += new System.EventHandler(this.btnBaseData_Click);
            // 
            // btnEntity
            // 
            this.btnEntity.Enabled = false;
            this.btnEntity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnEntity.Location = new System.Drawing.Point(171, 465);
            this.btnEntity.Name = "btnEntity";
            this.btnEntity.Size = new System.Drawing.Size(77, 32);
            this.btnEntity.TabIndex = 24;
            this.btnEntity.Text = "Entity";
            this.btnEntity.UseVisualStyleBackColor = true;
            this.btnEntity.Click += new System.EventHandler(this.btnEntity_Click);
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(575, 465);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 32);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdTable
            // 
            this.grdTable.Location = new System.Drawing.Point(12, 12);
            this.grdTable.MainView = this.grvTable;
            this.grdTable.Name = "grdTable";
            this.grdTable.Size = new System.Drawing.Size(645, 447);
            this.grdTable.TabIndex = 29;
            this.grdTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTable});
            // 
            // grvTable
            // 
            this.grvTable.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.grvTable.GridControl = this.grdTable;
            this.grvTable.Name = "grvTable";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "STT";
            this.gridColumn1.FieldName = "STT";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 50;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Select";
            this.gridColumn2.FieldName = "Select";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên bảng";
            this.gridColumn3.FieldName = "TableName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 494;
            // 
            // btnTaoThuTuc
            // 
            this.btnTaoThuTuc.Enabled = false;
            this.btnTaoThuTuc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnTaoThuTuc.Location = new System.Drawing.Point(70, 465);
            this.btnTaoThuTuc.Name = "btnTaoThuTuc";
            this.btnTaoThuTuc.Size = new System.Drawing.Size(77, 32);
            this.btnTaoThuTuc.TabIndex = 30;
            this.btnTaoThuTuc.Text = "Tạo thủ tục";
            this.btnTaoThuTuc.UseVisualStyleBackColor = true;
            this.btnTaoThuTuc.Click += new System.EventHandler(this.btnTaoThuTuc_Click);
            // 
            // frmSinhMaTuyChon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 509);
            this.Controls.Add(this.btnTaoThuTuc);
            this.Controls.Add(this.grdTable);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.btnBusiness);
            this.Controls.Add(this.btnBaseData);
            this.Controls.Add(this.btnEntity);
            this.Name = "frmSinhMaTuyChon";
            this.Text = "SINH MÃ TÙY CHỌN";
            this.Load += new System.EventHandler(this.frmSinhMaTuyChon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Button btnBusiness;
        private System.Windows.Forms.Button btnBaseData;
        private System.Windows.Forms.Button btnEntity;
        private System.Windows.Forms.Button btnClose;
        private DevExpress.XtraGrid.GridControl grdTable;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTable;
        private System.Windows.Forms.Button btnTaoThuTuc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}