using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using SQLDMO;

namespace TVGenCode
{
    public partial class frmMain : Form
    {
        private SqlConnection sqlCn;
        private string[] arrTables = new string[0];
        private bool ThuMuc = false;
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SQLDMO.Application app = new SQLDMO.Application();
            SQLDMO.NameList sqlList = app.ListAvailableSQLServers();
            for (int i = 1; i < sqlList.Count;i++ )
            {
                cmbServer.Items.Add(sqlList.Item(i));
            }
            SetText();
        }

        private void SetText()
        {
            cmbServer.Text = Properties.Settings.Default.ServerName;
            txtUserID.Text = Properties.Settings.Default.UserName;
            txtPassword.Text = Properties.Settings.Default.Password;
            txtDBName.Text = Properties.Settings.Default.DBName;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.ServerName = cmbServer.Text;
            Properties.Settings.Default.UserName = txtUserID.Text;
            Properties.Settings.Default.Password = txtPassword.Text;
            Properties.Settings.Default.DBName = txtDBName.Text;

            Properties.Settings.Default.Save();
        }

        private void btnKetNoiCoSoDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCn = new SqlConnection();
                sqlCn.ConnectionString = @"Data Source=" + cmbServer.Text + ";User ID=" + txtUserID.Text + ";Password=" + txtPassword.Text + ";Initial Catalog=" + txtDBName.Text;
                sqlCn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Co loi: " + ex.Message);
                return;
            }
            finally { }
            MessageBox.Show("Kết nối cơ sở dữ liệu thành công!", "TRUONG VIET - GENCODE",  MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtDuongDanSolution.Enabled = true;
            btnNoiLuuSolution.Enabled = true;
            btnTaoThuTuc.Enabled = true;
            btnTuyChon.Enabled = true;
            cTruyVanCSDL.sqlCn = sqlCn;

            SaveSettings();
        }

        private void btnNoiLuuSolution_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Properties.Settings.Default.FolderPath;
            folderBrowserDialog1.ShowDialog();
            txtDuongDanSolution.Text = folderBrowserDialog1.SelectedPath;
            Program.ThuMucGoc = txtDuongDanSolution.Text;
            Properties.Settings.Default.FolderPath = txtDuongDanSolution.Text;
            btnTaoMaToanDuAn.Enabled = true;
            btnTaoMaEntity.Enabled = true;
            btnTaoMaBaseData.Enabled = true;
            btnTaoMaData.Enabled = true;
            btnTaoMaBusiness.Enabled = true;
            ThuMuc = true;
        }

        private void btnTaoThuTuc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đang muốn sinh lại mã của các thủ tục (_Get, _Add, _Update, _Delete). Việc làm này sẽ thay thế toàn bộ các thủ tục này bạn đã xây dựng trong cơ sở dữ liệu. Bạn chắc chắn muốn thực hiện hành động này?", "TRUONG VIET - GENCODE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            cTaoThuTuc oTaoThuTuc = new cTaoThuTuc();
            cTruyVanCSDL oTruyVanCSDL = new cTruyVanCSDL();
            File.WriteAllText("a.txt", oTaoThuTuc.TaoThuTucGet());
            File.WriteAllText("b.txt", oTaoThuTuc.TaoThuTucAdd());
            File.WriteAllText("c.txt", oTaoThuTuc.TaoThuTucUpdate());
            File.WriteAllText("d.txt", oTaoThuTuc.TaoThuTucDelete());

            oTruyVanCSDL.RunSQL(oTaoThuTuc.TaoThuTucGet());
            oTruyVanCSDL.RunSQL(oTaoThuTuc.TaoThuTucAdd());
            oTruyVanCSDL.RunSQL(oTaoThuTuc.TaoThuTucUpdate());
            oTruyVanCSDL.RunSQL(oTaoThuTuc.TaoThuTucDelete());
            MessageBox.Show("Đã tạo xong đầy đủ các thủ tục (_Get, _Add, _Update, _Delete) trong cơ sở dữ liệu!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTaoMaEntity_Click(object sender, EventArgs e)
        {
            try
            {
                cTaoLopEntity oTaoLopEntity = new cTaoLopEntity();
                oTaoLopEntity.TaoLopEntity();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo lại các lớp trong dự án Entity trong thư mục bạn đã chọn! Đề nghị kiểm tra lại thư mục dự án Entity!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                MessageBox.Show("Đã tạo lại đầy đủ các lớp trong dự án Entity trong thư mục bạn đã chọn!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTaoMaToanDuAn_Click(object sender, EventArgs e)
        {
            cThongTinCSDL oThongTinCSDL = new cThongTinCSDL();
            arrTables = oThongTinCSDL.GetTableName();
            cTaoDuAn oTaoDuAn = new cTaoDuAn();
            oTaoDuAn.CreateSolution();
            oTaoDuAn.CreateEntityPrj(arrTables);
            oTaoDuAn.CreateDataPrj(arrTables);
            oTaoDuAn.CreateBusinessPrj(arrTables);
            cTaoLopEntity oTaoLopEntity = new cTaoLopEntity();
            oTaoLopEntity.TaoLopEntity();
            cTaoLopData oTaoLopData = new cTaoLopData();
            oTaoLopData.TaoLopBaseData();
            oTaoLopData.TaoLopData();
            cTaoLopBusiness oTaoLopBusiness = new cTaoLopBusiness();
            oTaoLopBusiness.TaoLopBusiness();
            MessageBox.Show("Đã tạo xong đầy đủ solution và các dự án trong thư mục bạn đã chọn!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTaoMaBaseData_Click(object sender, EventArgs e)
        {
            try
            {
                cTaoLopData oTaoLopData = new cTaoLopData();
                oTaoLopData.TaoLopBaseData();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo lại các lớp Base trong dự án Data trong thư mục bạn đã chọn! Đề nghị kiểm tra lại thư mục dự án Data!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                MessageBox.Show("Đã tạo lại đầy đủ các lớp Base trong dự án Data trong thư mục bạn đã chọn!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTaoMaData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đang muốn sinh lại mã của các lớp Data (không phải lớp Base). Việc làm này sẽ loại bỏ toàn bộ các đoạn mã bạn đã xây dựng trong các lớp Data (không phải lớp Base). Bạn chắc chắn muốn thực hiện việc này?", "TRUONG VIET - GENCODE", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No)
                return;
            try
            {
                cTaoLopData oTaoLopData = new cTaoLopData();
                oTaoLopData.TaoLopData();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo lại các lớp Data trong dự án Data trong thư mục bạn đã chọn! Đề nghị kiểm tra lại thư mục dự án Data!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                MessageBox.Show("Đã tạo lại đầy đủ các lớp Data trong dự án Data trong thư mục bạn đã chọn!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTaoMaBusiness_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đang muốn sinh lại mã của các lớp Business. Việc làm này sẽ loại bỏ toàn bộ các đoạn mã bạn đã xây dựng trong các lớp Business. Bạn chắc chắn muốn thực hiện việc này?", "TRUONG VIET - GENCODE", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No)
                return;
            try
            {
                cTaoLopBusiness oTaoLopBusiness = new cTaoLopBusiness();
                oTaoLopBusiness.TaoLopBusiness();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo lại các lớp Business trong dự án Business trong thư mục bạn đã chọn! Đề nghị kiểm tra lại thư mục dự án Business!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                MessageBox.Show("Đã tạo lại đầy đủ các lớp Business trong dự án Business trong thư mục bạn đã chọn!", "TRUONG VIET - GENCODE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void btnTuyChon_Click(object sender, EventArgs e)
        {
            frmSinhMaTuyChon frm = new frmSinhMaTuyChon();
            frm.ShowAll = ThuMuc;
            frm.ShowDialog();
        }
    }
}