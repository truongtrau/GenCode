using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace TVGenCode
{
    public class cTaoLopBusiness
    {
        private cThongTinCSDL oThongTinCSDL = new cThongTinCSDL();
        
        private void TaoLop(string TableName, DataTable dtbProperties, DataTable dtbKeyProperties)
        {
            string Path = Program.ThuMucGoc;
            string PrjName = Path.Substring(Path.LastIndexOf("\\") + 1);
            // Tao file Solution
            string[] arrLines = File.ReadAllLines("Templates\\Business.cs.Template.txt");
            for (int i = 0; i < arrLines.Length; i++)
            {
                if (arrLines[i].IndexOf("<@Prj@>") >= 0)
                    arrLines[i] = arrLines[i].Replace("<@Prj@>", PrjName);
                if (arrLines[i].IndexOf("<@Class@>") >= 0)
                    arrLines[i] = arrLines[i].Replace("<@Class@>", TableName);
                int index = arrLines[i].IndexOf("<@Properties@>");
                if (index >= 0)
                {
                    string line = "\n" + arrLines[i].Remove(index);
                    arrLines[i] = "";

                    for (int j = 0; j < dtbProperties.Rows.Count; j++)
                    {
                        if (oThongTinCSDL.GetCsDataType(dtbProperties.Rows[j]["xtype"].ToString())=="string")                           
                            arrLines[i] = arrLines[i] + line + "o" + TableName + "Info." + dtbProperties.Rows[j]["name"].ToString() + " = dtb.Rows[i][\"" + dtbProperties.Rows[j]["Name"].ToString() + "\"].ToString();";
                        else if (oThongTinCSDL.GetCsDataType(dtbProperties.Rows[j]["xtype"].ToString())=="byte[]")
                            arrLines[i] = arrLines[i] + line + "o" + TableName + "Info." + dtbProperties.Rows[j]["name"].ToString() + " = " + "(byte[])(dtb.Rows[i][\"" + dtbProperties.Rows[j]["Name"].ToString() + "\"]);";
                        else
                            arrLines[i] = arrLines[i] + line + "o" + TableName + "Info." + dtbProperties.Rows[j]["name"].ToString() + " = " + oThongTinCSDL.GetCsDataType(dtbProperties.Rows[j]["xtype"].ToString()) + ".Parse(dtb.Rows[i][\"" + dtbProperties.Rows[j]["Name"].ToString() + "\"].ToString());";
                    }
                }

                int idxToRow = arrLines[i].IndexOf("<@ToDataRow@>");
                if (idxToRow >= 0)
                {
                    string line = "\n" + arrLines[i].Remove(idxToRow);
                    arrLines[i] = "";

                    for (int j = 0; j < dtbProperties.Rows.Count; j++)
                    {
                        arrLines[i] = arrLines[i] + line + "dr[p" + TableName + "Info.str" + dtbProperties.Rows[j]["name"].ToString() + "] = p" + TableName + "Info." + dtbProperties.Rows[j]["name"].ToString() + ";";
                    }
                }

                int idxToInfo = arrLines[i].IndexOf("<@ToInfo@>");
                if (idxToInfo >= 0)
                {
                    string line = "\n" + arrLines[i].Remove(idxToInfo);
                    arrLines[i] = "";

                    for (int j = 0; j < dtbProperties.Rows.Count; j++)
                    {
                        if (oThongTinCSDL.GetCsDataType(dtbProperties.Rows[j]["xtype"].ToString()) == "string")
                            arrLines[i] = arrLines[i] + line + "p" + TableName + "Info." + dtbProperties.Rows[j]["name"].ToString() + " = dr[p" + TableName + "Info.str" + dtbProperties.Rows[j]["name"].ToString() + "].ToString();";
                        else if (oThongTinCSDL.GetCsDataType(dtbProperties.Rows[j]["xtype"].ToString()) == "byte[]")
                            arrLines[i] = arrLines[i] + line + "p" + TableName + "Info." + dtbProperties.Rows[j]["name"].ToString() + " = (byte[])(dr[p" + TableName + "Info.str" + dtbProperties.Rows[j]["name"].ToString() + "]);";
                        else
                            arrLines[i] = arrLines[i] + line + "p" + TableName + "Info." + dtbProperties.Rows[j]["name"].ToString() + " = " + oThongTinCSDL.GetCsDataType(dtbProperties.Rows[j]["xtype"].ToString()) + ".Parse(dr[p" + TableName + "Info.str" + dtbProperties.Rows[j]["name"].ToString() + "].ToString());";
                    }
                }
            }
            File.WriteAllLines(Program.ThuMucGoc + "\\" + PrjName + ".Business\\cB" + TableName + ".cs", arrLines);
        }

        public void TaoLopBusiness()
        {
            // Lay danh sach bang
            string[,] arrTables = oThongTinCSDL.GetTableNameId();
            for (int i = 0; i < arrTables.GetLength(1); i++)
            {
                // Lay danh sach cot cua bang
                DataTable dtbColumns = oThongTinCSDL.GetColunms(arrTables[1, i]);
                DataTable dtbKeyColumns = oThongTinCSDL.TimKhoa(arrTables[1, i]);
                TaoLop(arrTables[0, i], dtbColumns, dtbKeyColumns);
            }
        }

        public void TaoLopBusiness(string TableName, string TableID)
        {
            // Lay danh sach cot cua bang
            DataTable dtbColumns = oThongTinCSDL.GetColunms(TableID);
            DataTable dtbKeyColumns = oThongTinCSDL.TimKhoa(TableID);
            TaoLop(TableName, dtbColumns, dtbKeyColumns);
        }
    }
}
