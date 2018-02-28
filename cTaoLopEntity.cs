using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace TVGenCode
{
    public class cTaoLopEntity
    {
        private cThongTinCSDL oThongTinCSDL = new cThongTinCSDL();
        private void TaoLop(string TableName, DataTable dtbProperties)
        {
            string Path = Program.ThuMucGoc;
            string PrjName = Path.Substring(Path.LastIndexOf("\\") + 1);
            // Tao file Solution
            string[] arrLines = File.ReadAllLines("Templates\\Entity.cs.Template.txt");
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
                    // Sinh biến thuộc tính
                    for (int j = 0; j < dtbProperties.Rows.Count; j++)
                        arrLines[i] = arrLines[i] + line + "private " + oThongTinCSDL.GetCsDataType(dtbProperties.Rows[j]["xtype"].ToString()) + " m" + dtbProperties.Rows[j]["name"].ToString() + ";";
                    arrLines[i] = arrLines[i] + "\n";

                    // Sinh các biến tên các trường trong bảng
                    for (int j = 0; j < dtbProperties.Rows.Count; j++)
                        arrLines[i] = arrLines[i] + line + "public string " + "str" + dtbProperties.Rows[j]["name"].ToString() + " = " + '"' + dtbProperties.Rows[j]["name"].ToString() + '"' + ";";
                    arrLines[i] = arrLines[i] + "\n";

                    // Sinh hàm khởi tạo
                    arrLines[i] = arrLines[i] + line + "public " + TableName + "Info()";
                    arrLines[i] = arrLines[i] + line + "{ }\n";

                    // Sinh các property
                    for (int j = 0; j < dtbProperties.Rows.Count; j++)
                    {
                        arrLines[i] = arrLines[i] + line + "public " + oThongTinCSDL.GetCsDataType(dtbProperties.Rows[j]["xtype"].ToString()) + " " + dtbProperties.Rows[j]["name"].ToString() + "{";
                        arrLines[i] = arrLines[i] + line + "\tset{ m" + dtbProperties.Rows[j]["name"].ToString() + " = value;}";
                        arrLines[i] = arrLines[i] + line + "\tget{ return m" + dtbProperties.Rows[j]["name"].ToString() + ";}";
                        arrLines[i] = arrLines[i] + line + "}";
                    }
                }
            }
            File.WriteAllLines(Program.ThuMucGoc + "\\" + PrjName + ".Entity\\" + TableName + "Info.cs", arrLines);
        }

        public void TaoLopEntity()
        {
            // Lay danh sach bang
            //string strCode = "";
            string[,] arrTables = oThongTinCSDL.GetTableNameId();
            for (int i = 0; i < arrTables.GetLength(1); i++)
            {
                // Lay danh sach cot cua bang
                DataTable dtbColumns = oThongTinCSDL.GetColunms(arrTables[1, i]);
                TaoLop(arrTables[0, i], dtbColumns);       
            }
        }

        public void TaoLopEntity(string TableName, string TableID)
        {
            // string strCode = "";
            // Lay danh sach cot cua bang
            DataTable dtbColumns = oThongTinCSDL.GetColunms(TableID);
            TaoLop(TableName, dtbColumns);
        }
    }
}
