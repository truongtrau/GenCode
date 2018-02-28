using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TVGenCode
{
    public partial class frmSinhMaTuyChon : Form
    {
        public bool ShowAll = false;
        public frmSinhMaTuyChon()
        {
            InitializeComponent();
        }

        private void frmSinhMaTuyChon_Load(object sender, EventArgs e)
        {
            btnTaoThuTuc.Enabled = true;
            if (ShowAll == true)
            {
                btnEntity.Enabled = true;
                btnBaseData.Enabled = true;
                btnData.Enabled = true;
                btnBusiness.Enabled = true;
            }
            cThongTinCSDL oThongTinCSDL = new cThongTinCSDL();
            grdTable.DataSource = oThongTinCSDL.GetTable();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTaoThuTuc_Click(object sender, EventArgs e)
        {
            if (grvTable.DataRowCount > 0)
            {
                try
                {
                    DataTable dt = (DataTable)grdTable.DataSource;
                    if (MessageBox.Show("Bạn đang muốn sinh lại mã của các thủ tục (_Get, _Add, _Update, _Delete). Việc này sẽ tạo ra các file script trong thư mục bạn chọn. Bạn chắc chắn muốn thực hiện hành động này?", "TRUONG VIET - GENCODE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if ((bool)dr["Select"] == true)
                        {
                            cTaoThuTuc oTaoThuTuc = new cTaoThuTuc();
                            cTruyVanCSDL oTruyVanCSDL = new cTruyVanCSDL();
                            File.WriteAllText("a.txt", oTaoThuTuc.TaoThuTucGet(dr["TableName"].ToString(), dr["Id"].ToString()));
                            File.WriteAllText("b.txt", oTaoThuTuc.TaoThuTucAdd(dr["TableName"].ToString(), dr["Id"].ToString()));
                            File.WriteAllText("c.txt", oTaoThuTuc.TaoThuTucUpdate(dr["TableName"].ToString(), dr["Id"].ToString()));
                            File.WriteAllText("d.txt", oTaoThuTuc.TaoThuTucDelete(dr["TableName"].ToString(), dr["Id"].ToString()));

                            oTruyVanCSDL.RunSQL(oTaoThuTuc.TaoThuTucGet(dr["TableName"].ToString(), dr["Id"].ToString()));
                            oTruyVanCSDL.RunSQL(oTaoThuTuc.TaoThuTucAdd(dr["TableName"].ToString(), dr["Id"].ToString()));
                            oTruyVanCSDL.RunSQL(oTaoThuTuc.TaoThuTucUpdate(dr["TableName"].ToString(), dr["Id"].ToString()));
                            oTruyVanCSDL.RunSQL(oTaoThuTuc.TaoThuTucDelete(dr["TableName"].ToString(), dr["Id"].ToString()));
                        }
                    }
                    MessageBox.Show("Đã tạo xong đầy đủ các thủ tục (_Get, _Add, _Update, _Delete) trong cơ sở dữ liệu!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi tạo lại các thủ tục trong Cơ sở dữ liệu!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Database của bạn chưa có bảng nào!", "THÔNG BÁO");
        }

        private void btnEntity_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)grdTable.DataSource;
                foreach (DataRow dr in dt.Rows)
                {
                    if ((bool)dr["Select"] == true)
                    {
                        cTaoLopEntity oTaoLopEntity = new cTaoLopEntity();
                        oTaoLopEntity.TaoLopEntity(dr["TableName"].ToString(), dr["Id"].ToString());
                    }
                }
                MessageBox.Show("Đã tạo lại đầy đủ các lớp trong dự án Entity trong thư mục bạn đã chọn!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo lại các lớp trong dự án Entity trong thư mục bạn đã chọn! Đề nghị kiểm tra lại thư mục dự án Entity!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBaseData_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)grdTable.DataSource;
                foreach (DataRow dr in dt.Rows)
                {
                    if ((bool)dr["Select"] == true)
                    {
                        cTaoLopData oTaoLopData = new cTaoLopData();
                        oTaoLopData.TaoLopBaseData(dr["TableName"].ToString(), dr["Id"].ToString());
                    }
                }
                MessageBox.Show("Đã tạo lại đầy đủ các lớp Base trong dự án Data trong thư mục bạn đã chọn!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo lại các lớp Base trong dự án Data trong thư mục bạn đã chọn! Đề nghị kiểm tra lại thư mục dự án Data!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đang muốn sinh lại mã của các lớp Data (không phải lớp Base). Việc làm này sẽ loại bỏ toàn bộ các đoạn mã bạn đã xây dựng trong các lớp Data (không phải lớp Base). Bạn chắc chắn muốn thực hiện việc này?", "TRUONG VIET - GENCODE", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No)
                return;
            try
            {
                DataTable dt = (DataTable)grdTable.DataSource;
                foreach (DataRow dr in dt.Rows)
                {
                    if ((bool)dr["Select"] == true)
                    {
                        cTaoLopData oTaoLopData = new cTaoLopData();
                        oTaoLopData.TaoLopData(dr["TableName"].ToString(), dr["Id"].ToString());
                    }
                }
                MessageBox.Show("Đã tạo lại đầy đủ các lớp Data trong dự án Data trong thư mục bạn đã chọn!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo lại các lớp Data trong dự án Data trong thư mục bạn đã chọn! Đề nghị kiểm tra lại thư mục dự án Data!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBusiness_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đang muốn sinh lại mã của các lớp Business. Việc làm này sẽ loại bỏ toàn bộ các đoạn mã bạn đã xây dựng trong các lớp Business. Bạn chắc chắn muốn thực hiện việc này?", "TRUONG VIET - GENCODE", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No)
                return;
            try
            {
                DataTable dt = (DataTable)grdTable.DataSource;
                foreach (DataRow dr in dt.Rows)
                {
                    if ((bool)dr["Select"] == true)
                    {
                        cTaoLopBusiness oTaoLopBusiness = new cTaoLopBusiness();
                        oTaoLopBusiness.TaoLopBusiness(dr["TableName"].ToString(), dr["Id"].ToString());
                    }
                }
                MessageBox.Show("Đã tạo lại đầy đủ các lớp Business trong dự án Business trong thư mục bạn đã chọn!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo lại các lớp Business trong dự án Business trong thư mục bạn đã chọn! Đề nghị kiểm tra lại thư mục dự án Business!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
