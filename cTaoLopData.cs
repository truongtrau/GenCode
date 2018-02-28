using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace TVGenCode
{
    public class cTaoLopData
    {
        private cThongTinCSDL oThongTinCSDL = new cThongTinCSDL();
        private void TaoLop(string TableName, DataTable dtbProperties)
        {
            string Path = Program.ThuMucGoc;
            string PrjName = Path.Substring(Path.LastIndexOf("\\") + 1);
            // Tao file Solution
            string[] arrLines = File.ReadAllLines("Templates\\Data.cs.Template.txt");
            for (int i = 0; i < arrLines.Length; i++)
            {
                if (arrLines[i].IndexOf("<@Prj@>") >= 0)
                    arrLines[i] = arrLines[i].Replace("<@Prj@>", PrjName);
                if (arrLines[i].IndexOf("<@Class@>") >= 0)
                    arrLines[i] = arrLines[i].Replace("<@Class@>", TableName);
            }
            File.WriteAllLines(Program.ThuMucGoc + "\\" + PrjName + ".Data\\cD" + TableName + ".cs", arrLines);
        }

        private void TaoLopBase(string TableName, DataTable dtbProperties, DataTable dtbKeyProperties)
        {
            string Path = Program.ThuMucGoc;
            string PrjName = Path.Substring(Path.LastIndexOf("\\") + 1);
            // Tao file Solution
            string[] arrLines = File.ReadAllLines("Templates\\Data_Base.cs.Template.txt");
            for (int i = 0; i < arrLines.Length; i++)
            {
                if (arrLines[i].IndexOf("<@Prj@>") >= 0)
                    arrLines[i] = arrLines[i].Replace("<@Prj@>", PrjName);
                if (arrLines[i].IndexOf("<@Class@>") >= 0)
                    arrLines[i] = arrLines[i].Replace("<@Class@>", TableName);
                int index = arrLines[i].IndexOf("<@GetParameters@>");
                if (index >= 0)
                {
                    string line = "\n" + arrLines[i].Remove(index);
                    arrLines[i] = "";

                    for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
                    {
                        arrLines[i] = arrLines[i] + line + "colParam.Add(CreateParam(\"@" + dtbKeyProperties.Rows[j]["name"].ToString() + "\",SqlDbType." + oThongTinCSDL.Get_SP_DataType(dtbKeyProperties.Rows[j]["xtype"].ToString()) + ",p" + TableName + "Info." + dtbKeyProperties.Rows[j]["Name"].ToString() + "));";
                    }
                }
                index = arrLines[i].IndexOf("<@AddParameters@>");
                if (index >= 0)
                {
                    string line = "\n" + arrLines[i].Remove(index);
                    arrLines[i] = "";

                    dtbProperties.DefaultView.RowFilter = "colstat = 0";
                    for (int j = 0; j < dtbProperties.DefaultView.Count; j++)
                    {
                        arrLines[i] = arrLines[i] + line + "colParam.Add(CreateParam(\"@" + dtbProperties.DefaultView[j]["name"].ToString() + "\",SqlDbType." + oThongTinCSDL.Get_SP_DataType(dtbProperties.DefaultView[j]["xtype"].ToString()) + ",p" + TableName + "Info." + dtbProperties.DefaultView[j]["Name"].ToString() + "));";
                    }
                }
                index = arrLines[i].IndexOf("<@UpdateParameters@>");
                if (index >= 0)
                {
                    string line = "\n" + arrLines[i].Remove(index);
                    arrLines[i] = "";
                    DataView dtvKeyProperty = dtbKeyProperties.DefaultView;
                    for (int j = 0; j < dtbProperties.Rows.Count; j++)
                    {
                        dtvKeyProperty.RowFilter = "Name = '" + dtbProperties.Rows[j]["Name"].ToString() + "'";
                        if (dtvKeyProperty.Count<=0)
                            arrLines[i] = arrLines[i] + line + "colParam.Add(CreateParam(\"@" + dtbProperties.Rows[j]["name"].ToString() + "\",SqlDbType." + oThongTinCSDL.Get_SP_DataType(dtbProperties.Rows[j]["xtype"].ToString()) + ",p" + TableName + "Info." + dtbProperties.Rows[j]["Name"].ToString() + "));";
                    }
                    for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
                    {
                        arrLines[i] = arrLines[i] + line + "colParam.Add(CreateParam(\"@" + dtbKeyProperties.Rows[j]["name"].ToString() + "\",SqlDbType." + oThongTinCSDL.Get_SP_DataType(dtbKeyProperties.Rows[j]["xtype"].ToString()) + ",p" + TableName + "Info." + dtbKeyProperties.Rows[j]["Name"].ToString() + "));";
                    }
                }
                index = arrLines[i].IndexOf("<@DeleteParameters@>");
                if (index >= 0)
                {
                    string line = "\n" + arrLines[i].Remove(index);
                    arrLines[i] = "";
                    for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
                    {
                        arrLines[i] = arrLines[i] + line + "colParam.Add(CreateParam(\"@" + dtbKeyProperties.Rows[j]["name"].ToString() + "\",SqlDbType." + oThongTinCSDL.Get_SP_DataType(dtbKeyProperties.Rows[j]["xtype"].ToString()) + ",p" + TableName + "Info." + dtbKeyProperties.Rows[j]["Name"].ToString() + "));";
                    }
                }
            }
            File.WriteAllLines(Program.ThuMucGoc + "\\" + PrjName + ".Data\\cD" + TableName + "_Base.cs", arrLines);
        }

        public void TaoLopBaseData()
        {
            // Lay danh sach bang
            string[,] arrTables = oThongTinCSDL.GetTableNameId();
            for (int i = 0; i < arrTables.GetLength(1); i++)
            {
                // Lay danh sach cot cua bang
                DataTable dtbColumns = oThongTinCSDL.GetColunms(arrTables[1, i]);
                DataTable dtbKeyColumns = oThongTinCSDL.TimKhoa(arrTables[1, i]);
                TaoLopBase(arrTables[0, i], dtbColumns,dtbKeyColumns);
            }
        }

        public void TaoLopBaseData(string TableName, string TableID)
        {
            // Lay danh sach cot cua bang
            DataTable dtbColumns = oThongTinCSDL.GetColunms(TableID);
            DataTable dtbKeyColumns = oThongTinCSDL.TimKhoa(TableID);
            TaoLopBase(TableName, dtbColumns, dtbKeyColumns);
        }

        public void TaoLopData()
        {
            // Lay danh sach bang
            string[,] arrTables = oThongTinCSDL.GetTableNameId();
            for (int i = 0; i < arrTables.GetLength(1); i++)
            {
                // Lay danh sach cot cua bang
                DataTable dtbColumns = oThongTinCSDL.GetColunms(arrTables[1, i]);
                TaoLop(arrTables[0, i], dtbColumns);
            }
        }

        public void TaoLopData(string TableName, string TableID)
        {
            // Lay danh sach cot cua bang
            DataTable dtbColumns = oThongTinCSDL.GetColunms(TableID);
            TaoLop(TableName, dtbColumns);
        }
    }
}
