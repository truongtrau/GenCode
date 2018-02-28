using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace TVGenCode
{
    public class cTaoThuTuc
    {
        private cThongTinCSDL oThongTinCSDL = new cThongTinCSDL();
        public string TaoThuTucGet()
        {
            string SQL = "";
            string[,] arrTables = oThongTinCSDL.GetTableNameId();
            for (int i = 0; i < arrTables.GetLength(1); i++)
            {
                SQL += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_" + arrTables[0, i] + "_Get]') AND type in (N'P', N'PC'))";
                SQL += "\nDROP PROCEDURE [dbo].[sp_" + arrTables[0, i] + "_Get]\nGO";
                SQL += "\nCREATE PROCEDURE dbo.sp_";
                SQL += arrTables[0, i] + "_Get";
                // Lay Khoa chinh cua bang
                DataTable dtbKeyProperties = oThongTinCSDL.TimKhoa(arrTables[1, i]);
                if (dtbKeyProperties.Rows.Count == 0)
                    SQL += "";
                else
                    SQL += "\n(";
                for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
                {
                    if (j >= 1)
                        SQL += ",\n\t@" + dtbKeyProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbKeyProperties.Rows[j]["xtype"].ToString()) + "(" + dtbKeyProperties.Rows[j]["Length"].ToString() + ")";
                    else
                        SQL += "\n\t@" + dtbKeyProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbKeyProperties.Rows[j]["xtype"].ToString()) + "(" + dtbKeyProperties.Rows[j]["Length"].ToString() + ")";
                }
                if (dtbKeyProperties.Rows.Count == 0)
                    SQL += "\nAS";
                else
                {
                    SQL += "\n)\nAS";
                }
                if (dtbKeyProperties.Rows.Count > 0)
                {
                    SQL += "\nBEGIN";
                    SQL += "\n\tIf ";
                    for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
                    {
                        if (j >= 1)
                            SQL += " AND @" + dtbKeyProperties.Rows[j]["name"].ToString() + " <= 0";
                        else
                            SQL += " @" + dtbKeyProperties.Rows[j]["name"].ToString() + " <= 0";
                    }
                    SQL += "\n\t\tSELECT * FROM " + arrTables[0, i];
                    SQL += "\n\tElse";
                    SQL += "\n\t\tSELECT * FROM " + arrTables[0, i] + " WHERE ";
                    for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
                    {
                        if (j >= 1)
                            SQL += " AND " + dtbKeyProperties.Rows[j]["name"].ToString() + " = @" + dtbKeyProperties.Rows[j]["name"].ToString();
                        else
                            SQL += dtbKeyProperties.Rows[j]["name"].ToString() + " = @" + dtbKeyProperties.Rows[j]["name"].ToString();
                    }
                    SQL += "\nEND";
                }
                SQL += "\nGO";
            }
            SQL = SQL.Replace("int(4)", "int");
            SQL = SQL.Replace("datetime(8)", "datetime");
            SQL = SQL.Replace("money(8)", "money");
            SQL = SQL.Replace("float(8)", "float");
            SQL = SQL.Replace("bigint(8)", "bigint");
            SQL = SQL.Replace("bit(1)", "bit");
            SQL = SQL.Replace("image(16)", "image");
            SQL = SQL.Replace("ntext(16)", "ntext");
            SQL = SQL.Replace("real(4)", "real");
            
            return SQL;
        }

        public string TaoThuTucGet(string TableName, string TableID)
        {
            string SQL = "";
            SQL += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_" + TableName + "_Get]') AND type in (N'P', N'PC'))";
            SQL += "\nDROP PROCEDURE [dbo].[sp_" + TableName + "_Get]\nGO";
            SQL += "\nCREATE PROCEDURE dbo.sp_";
            SQL += TableName + "_Get";
            // Lay Khoa chinh cua bang
            DataTable dtbKeyProperties = oThongTinCSDL.TimKhoa(TableID);
            if (dtbKeyProperties.Rows.Count == 0)
                SQL += "";
            else
                SQL += "\n(";
            for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
            {
                if (j >= 1)
                    SQL += ",\n\t@" + dtbKeyProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbKeyProperties.Rows[j]["xtype"].ToString()) + "(" + dtbKeyProperties.Rows[j]["Length"].ToString() + ")";
                else
                    SQL += "\n\t@" + dtbKeyProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbKeyProperties.Rows[j]["xtype"].ToString()) + "(" + dtbKeyProperties.Rows[j]["Length"].ToString() + ")";
            }
            if (dtbKeyProperties.Rows.Count == 0)
                SQL += "\nAS";
            else
            {
                SQL += "\n)\nAS";
            }
            if (dtbKeyProperties.Rows.Count > 0)
            {
                SQL += "\nBEGIN";
                SQL += "\n\tIf ";
                for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
                {
                    if (j >= 1)
                        SQL += " AND @" + dtbKeyProperties.Rows[j]["name"].ToString() + " <= 0";
                    else
                        SQL += " @" + dtbKeyProperties.Rows[j]["name"].ToString() + " <= 0";
                }
                SQL += "\n\t\tSELECT * FROM " + TableName;
                SQL += "\n\tElse";
                SQL += "\n\t\tSELECT * FROM " + TableName + " WHERE ";
                for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
                {
                    if (j >= 1)
                        SQL += " AND " + dtbKeyProperties.Rows[j]["name"].ToString() + " = @" + dtbKeyProperties.Rows[j]["name"].ToString();
                    else
                        SQL += dtbKeyProperties.Rows[j]["name"].ToString() + " = @" + dtbKeyProperties.Rows[j]["name"].ToString();
                }
                SQL += "\nEND";
            }
            SQL += "\nGO";

            SQL = SQL.Replace("int(4)", "int");
            SQL = SQL.Replace("datetime(8)", "datetime");
            SQL = SQL.Replace("money(8)", "money");
            SQL = SQL.Replace("float(8)", "float");
            SQL = SQL.Replace("bigint(8)", "bigint");
            SQL = SQL.Replace("bit(1)", "bit");
            SQL = SQL.Replace("image(16)", "image");
            SQL = SQL.Replace("ntext(16)", "ntext");
            SQL = SQL.Replace("real(4)", "real");

            return SQL;
        }

        public string TaoThuTucAdd()
        {
            string SQL = "";
            string[,] arrTables = oThongTinCSDL.GetTableNameId();
            for (int i = 0; i < arrTables.GetLength(1); i++)
            {
                SQL += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_" + arrTables[0, i] + "_Add]') AND type in (N'P', N'PC'))";
                SQL += "\nDROP PROCEDURE [dbo].[sp_" + arrTables[0, i] + "_Add]\nGO";
                SQL += "\nCREATE PROCEDURE dbo.sp_";
                SQL += arrTables[0, i] + "_Add";
                // Lay Khoa chinh cua bang
                DataTable dtbProperties = oThongTinCSDL.GetColunms(arrTables[1, i]);
                SQL += "\n(";
                dtbProperties.DefaultView.RowFilter = "colstat = 0";
                for (int j = 0; j < dtbProperties.DefaultView.Count; j++)
                {
                    if (j >= 1)
                        SQL += ",\n\t@" + dtbProperties.DefaultView[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbProperties.DefaultView[j]["xtype"].ToString()) + "(" + dtbProperties.DefaultView[j]["Length"].ToString() + ")" + isNull(int.Parse(dtbProperties.DefaultView[j]["isnullable"].ToString()));
                    else
                        SQL += "\n\t@" + dtbProperties.DefaultView[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbProperties.DefaultView[j]["xtype"].ToString()) + "(" + dtbProperties.DefaultView[j]["Length"].ToString() + ")" + isNull(int.Parse(dtbProperties.DefaultView[j]["isnullable"].ToString()));
                }
                SQL += ",\n\t@ID int output";
                SQL += "\n)\nAS";
                SQL += "\nBEGIN";

                // Kiểm tra nếu là trường datetime có thể null thì phải xem xét với giá trị mặc định của null là ngày 1/1/1900
                for (int j = 0; j < dtbProperties.DefaultView.Count; j++)
                {
                    if (oThongTinCSDL.GetDataType(dtbProperties.DefaultView[j]["xtype"].ToString()).ToLower() == "datetime"
                        && isNull(int.Parse(dtbProperties.DefaultView[j]["isnullable"].ToString())) == " = null")
                    {
                        SQL += "\n\tIf @" + dtbProperties.DefaultView[j]["name"].ToString() + " = Convert(datetime,'1/1/1900')";
                        SQL += "\n\t\tSET @" + dtbProperties.DefaultView[j]["name"].ToString() + " = null";
                    }
                }

                SQL += "\n\tINSERT INTO " + arrTables[0, i] + "(";
                for (int j = 0; j < dtbProperties.DefaultView.Count; j++)
                {
                    if (j >= 1)
                        SQL += "," + dtbProperties.DefaultView[j]["name"].ToString();
                    else
                        SQL += "" + dtbProperties.DefaultView[j]["name"].ToString();
                }
                SQL += ")";
                SQL += "\n\tVALUES(";
                for (int j = 0; j < dtbProperties.DefaultView.Count; j++)
                {
                    if (j >= 1)
                        SQL += ",@" + dtbProperties.DefaultView[j]["name"].ToString();
                    else
                        SQL += "@" + dtbProperties.DefaultView[j]["name"].ToString();
                }
                SQL += ")";
                SQL += "\n\tSELECT @ID = @@Identity";
                SQL += "\nEND\nGO";
            }
            SQL = SQL.Replace("int(4)", "int");
            SQL = SQL.Replace("datetime(8)", "datetime");
            SQL = SQL.Replace("money(8)", "money");
            SQL = SQL.Replace("float(8)", "float");
            SQL = SQL.Replace("bigint(8)", "bigint");
            SQL = SQL.Replace("bit(1)", "bit");
            SQL = SQL.Replace("image(16)", "image");
            SQL = SQL.Replace("ntext(16)", "ntext");
            SQL = SQL.Replace("real(4)", "real");
            return SQL;
        }

        private string isNull(int isnullable)
        {
            if (isnullable == 1)
                return " = null";
            else
                return "";
        }

        public string TaoThuTucAdd(string TableName, string TableID)
        {
            string SQL = "";

            SQL += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_" + TableName + "_Add]') AND type in (N'P', N'PC'))";
            SQL += "\nDROP PROCEDURE [dbo].[sp_" + TableName + "_Add]\nGO";
            SQL += "\nCREATE PROCEDURE dbo.sp_";
            SQL += TableName + "_Add";
            // Lay Khoa chinh cua bang
            DataTable dtbProperties = oThongTinCSDL.GetColunms(TableID);
            SQL += "\n(";
            dtbProperties.DefaultView.RowFilter = "colstat = 0";
            for (int j = 0; j < dtbProperties.DefaultView.Count; j++)
            {
                if (j >= 1)
                    SQL += ",\n\t@" + dtbProperties.DefaultView[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbProperties.DefaultView[j]["xtype"].ToString()) + "(" + dtbProperties.DefaultView[j]["Length"].ToString() + ")" + isNull(int.Parse(dtbProperties.DefaultView[j]["isnullable"].ToString()));
                else
                    SQL += "\n\t@" + dtbProperties.DefaultView[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbProperties.DefaultView[j]["xtype"].ToString()) + "(" + dtbProperties.DefaultView[j]["Length"].ToString() + ")" + isNull(int.Parse(dtbProperties.DefaultView[j]["isnullable"].ToString()));
            }
            SQL += ",\n\t@ID int output";
            SQL += "\n)\nAS";
            SQL += "\nBEGIN";

            // Kiểm tra nếu là trường datetime có thể null thì phải xem xét với giá trị mặc định của null là ngày 1/1/1900
            for (int j = 0; j < dtbProperties.DefaultView.Count; j++)
            {
                if (oThongTinCSDL.GetDataType(dtbProperties.DefaultView[j]["xtype"].ToString()).ToLower() == "datetime"
                    && isNull(int.Parse(dtbProperties.DefaultView[j]["isnullable"].ToString())) == " = null")
                {
                    SQL += "\n\tIf @" + dtbProperties.DefaultView[j]["name"].ToString() + " = Convert(datetime,'1/1/1900')";
                    SQL += "\n\t\tSET @" + dtbProperties.DefaultView[j]["name"].ToString() + " = null";
                }
            }

            SQL += "\n\tINSERT INTO " + TableName + "(";
            for (int j = 0; j < dtbProperties.DefaultView.Count; j++)
            {
                if (j >= 1)
                    SQL += "," + dtbProperties.DefaultView[j]["name"].ToString();
                else
                    SQL += "" + dtbProperties.DefaultView[j]["name"].ToString();
            }
            SQL += ")";
            SQL += "\n\tVALUES(";
            for (int j = 0; j < dtbProperties.DefaultView.Count; j++)
            {
                if (j >= 1)
                    SQL += ",@" + dtbProperties.DefaultView[j]["name"].ToString();
                else
                    SQL += "@" + dtbProperties.DefaultView[j]["name"].ToString();
            }
            SQL += ")";
            SQL += "\n\tSELECT @ID = @@Identity";
            SQL += "\nEND\nGO";

            SQL = SQL.Replace("int(4)", "int");
            SQL = SQL.Replace("datetime(8)", "datetime");
            SQL = SQL.Replace("money(8)", "money");
            SQL = SQL.Replace("float(8)", "float");
            SQL = SQL.Replace("bigint(8)", "bigint");
            SQL = SQL.Replace("bit(1)", "bit");
            SQL = SQL.Replace("image(16)", "image");
            SQL = SQL.Replace("ntext(16)", "ntext");
            SQL = SQL.Replace("real(4)", "real");
            return SQL;
        }

        public string TaoThuTucUpdate()
        {
            string SQL = "";
            string[,] arrTables = oThongTinCSDL.GetTableNameId();
            for (int i = 0; i < arrTables.GetLength(1); i++)
            {
                SQL += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_" + arrTables[0, i] + "_Update]') AND type in (N'P', N'PC'))";
                SQL += "\nDROP PROCEDURE [dbo].[sp_" + arrTables[0, i] + "_Update]\nGO";
                SQL += "\nCREATE PROCEDURE dbo.sp_";
                SQL += arrTables[0, i] + "_Update";
                // Lay Khoa chinh cua bang
                DataTable dtbProperties = oThongTinCSDL.GetColunms(arrTables[1, i]);
                DataTable dtbKeyProperties = oThongTinCSDL.TimKhoa(arrTables[1, i]);
                SQL += "\n(";
                DataView dtvKeyProperty = dtbKeyProperties.DefaultView;
                int k = 0;
                for (int j = 0; j < dtbProperties.Rows.Count; j++)
                {
                    dtvKeyProperty.RowFilter = "Name = '" + dtbProperties.Rows[j]["Name"].ToString() + "'";
                    if (dtvKeyProperty.Count <= 0)
                    {
                        if (k >= 1)
                            SQL += ",\n\t@" + dtbProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbProperties.Rows[j]["xtype"].ToString()) + "(" + dtbProperties.Rows[j]["Length"].ToString() + ")" + isNull(int.Parse(dtbProperties.Rows[j]["isnullable"].ToString()));
                        else
                            SQL += "\n\t@" + dtbProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbProperties.Rows[j]["xtype"].ToString()) + "(" + dtbProperties.Rows[j]["Length"].ToString() + ")" + isNull(int.Parse(dtbProperties.Rows[j]["isnullable"].ToString()));
                        k++;
                    }
                }
                for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
                {
                    if (k >= 1)
                        SQL += ",\n\t@" + dtbKeyProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbKeyProperties.Rows[j]["xtype"].ToString()) + "(" + dtbKeyProperties.Rows[j]["Length"].ToString() + ")";
                    else
                        SQL += "\n\t@" + dtbKeyProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbKeyProperties.Rows[j]["xtype"].ToString()) + "(" + dtbKeyProperties.Rows[j]["Length"].ToString() + ")";
                }


                SQL += "\n)\nAS";
                SQL += "\nBEGIN";

                // Kiểm tra nếu là trường datetime có thể null thì phải xem xét với giá trị mặc định của null là ngày 1/1/1900
                for (int j = 0; j < dtbProperties.DefaultView.Count; j++)
                {
                    if (oThongTinCSDL.GetDataType(dtbProperties.DefaultView[j]["xtype"].ToString()).ToLower() == "datetime"
                        && isNull(int.Parse(dtbProperties.DefaultView[j]["isnullable"].ToString())) == " = null")
                    {
                        SQL += "\n\tIf @" + dtbProperties.DefaultView[j]["name"].ToString() + " = Convert(datetime,'1/1/1900')";
                        SQL += "\n\t\tSET @" + dtbProperties.DefaultView[j]["name"].ToString() + " = null";
                    }
                }

                SQL += "\n\tUPDATE " + arrTables[0, i] + " SET ";
                k = 0;
                for (int j = 0; j < dtbProperties.Rows.Count; j++)
                {
                    dtvKeyProperty.RowFilter = "Name = '" + dtbProperties.Rows[j]["Name"].ToString() + "'";
                    if (dtvKeyProperty.Count <= 0)
                    {
                        if (k >= 1)
                            SQL += ", " + dtbProperties.Rows[j]["name"].ToString() + " = @" + dtbProperties.Rows[j]["name"].ToString();
                        else
                            SQL += " " + dtbProperties.Rows[j]["name"].ToString() + " = @" + dtbProperties.Rows[j]["name"].ToString();
                        k++;
                    }
                }
                if (dtbKeyProperties.Rows.Count == 0)
                    SQL += "";
                else
                {
                    SQL += " WHERE ";
                    for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
                    {
                        if (j >= 1)
                            SQL += " AND " + dtbKeyProperties.Rows[j]["name"].ToString() + " = @" + dtbKeyProperties.Rows[j]["name"].ToString();
                        else
                            SQL += " " + dtbKeyProperties.Rows[j]["name"].ToString() + " = @" + dtbKeyProperties.Rows[j]["name"].ToString();
                    }
                }
                SQL += "\n";
                SQL += "\nEND\nGO";
            }
            SQL = SQL.Replace("int(4)", "int");
            SQL = SQL.Replace("datetime(8)", "datetime");
            SQL = SQL.Replace("money(8)", "money");
            SQL = SQL.Replace("float(8)", "float");
            SQL = SQL.Replace("bigint(8)", "bigint");
            SQL = SQL.Replace("bit(1)", "bit");
            SQL = SQL.Replace("image(16)", "image");
            SQL = SQL.Replace("ntext(16)", "ntext");
            SQL = SQL.Replace("real(4)", "real");

            return SQL;
        }

        public string TaoThuTucUpdate(string TableName, string TableID)
        {
            string SQL = "";

            SQL += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_" + TableName + "_Update]') AND type in (N'P', N'PC'))";
            SQL += "\nDROP PROCEDURE [dbo].[sp_" + TableName + "_Update]\nGO";
            SQL += "\nCREATE PROCEDURE dbo.sp_";
            SQL += TableName + "_Update";
            // Lay Khoa chinh cua bang
            DataTable dtbProperties = oThongTinCSDL.GetColunms(TableID);
            DataTable dtbKeyProperties = oThongTinCSDL.TimKhoa(TableID);
            SQL += "\n(";
            DataView dtvKeyProperty = dtbKeyProperties.DefaultView;
            int k = 0;
            for (int j = 0; j < dtbProperties.Rows.Count; j++)
            {
                dtvKeyProperty.RowFilter = "Name = '" + dtbProperties.Rows[j]["Name"].ToString() + "'";
                if (dtvKeyProperty.Count <= 0)
                {
                    if (k >= 1)
                        SQL += ",\n\t@" + dtbProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbProperties.Rows[j]["xtype"].ToString()) + "(" + dtbProperties.Rows[j]["Length"].ToString() + ")" + isNull(int.Parse(dtbProperties.Rows[j]["isnullable"].ToString()));
                    else
                        SQL += "\n\t@" + dtbProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbProperties.Rows[j]["xtype"].ToString()) + "(" + dtbProperties.Rows[j]["Length"].ToString() + ")" + isNull(int.Parse(dtbProperties.Rows[j]["isnullable"].ToString()));
                    k++;
                }
            }
            for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
            {
                if (k >= 1)
                    SQL += ",\n\t@" + dtbKeyProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbKeyProperties.Rows[j]["xtype"].ToString()) + "(" + dtbKeyProperties.Rows[j]["Length"].ToString() + ")";
                else
                    SQL += "\n\t@" + dtbKeyProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbKeyProperties.Rows[j]["xtype"].ToString()) + "(" + dtbKeyProperties.Rows[j]["Length"].ToString() + ")";
            }


            SQL += "\n)\nAS";
            SQL += "\nBEGIN";

            // Kiểm tra nếu là trường datetime có thể null thì phải xem xét với giá trị mặc định của null là ngày 1/1/1900
            for (int j = 0; j < dtbProperties.DefaultView.Count; j++)
            {
                if (oThongTinCSDL.GetDataType(dtbProperties.DefaultView[j]["xtype"].ToString()).ToLower() == "datetime"
                    && isNull(int.Parse(dtbProperties.DefaultView[j]["isnullable"].ToString())) == " = null")
                {
                    SQL += "\n\tIf @" + dtbProperties.DefaultView[j]["name"].ToString() + " = Convert(datetime,'1/1/1900')";
                    SQL += "\n\t\tSET @" + dtbProperties.DefaultView[j]["name"].ToString() + " = null";
                }
            }

            SQL += "\n\tUPDATE " + TableName + " SET ";
            k = 0;
            for (int j = 0; j < dtbProperties.Rows.Count; j++)
            {
                dtvKeyProperty.RowFilter = "Name = '" + dtbProperties.Rows[j]["Name"].ToString() + "'";
                if (dtvKeyProperty.Count <= 0)
                {
                    if (k >= 1)
                        SQL += ", " + dtbProperties.Rows[j]["name"].ToString() + " = @" + dtbProperties.Rows[j]["name"].ToString();
                    else
                        SQL += " " + dtbProperties.Rows[j]["name"].ToString() + " = @" + dtbProperties.Rows[j]["name"].ToString();
                    k++;
                }
            }
            if (dtbKeyProperties.Rows.Count == 0)
                SQL += "";
            else
            {
                SQL += " WHERE ";
                for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
                {
                    if (j >= 1)
                        SQL += " AND " + dtbKeyProperties.Rows[j]["name"].ToString() + " = @" + dtbKeyProperties.Rows[j]["name"].ToString();
                    else
                        SQL += " " + dtbKeyProperties.Rows[j]["name"].ToString() + " = @" + dtbKeyProperties.Rows[j]["name"].ToString();
                }
            }
            SQL += "\n";
            SQL += "\nEND\nGO";

            SQL = SQL.Replace("int(4)", "int");
            SQL = SQL.Replace("datetime(8)", "datetime");
            SQL = SQL.Replace("money(8)", "money");
            SQL = SQL.Replace("float(8)", "float");
            SQL = SQL.Replace("bigint(8)", "bigint");
            SQL = SQL.Replace("bit(1)", "bit");
            SQL = SQL.Replace("image(16)", "image");
            SQL = SQL.Replace("ntext(16)", "ntext");
            SQL = SQL.Replace("real(4)", "real");

            return SQL;
        }

        public string TaoThuTucDelete()
        {
            string SQL = "";
            string[,] arrTables = oThongTinCSDL.GetTableNameId();
            for (int i = 0; i < arrTables.GetLength(1); i++)
            {
                DataTable dtbProperties = oThongTinCSDL.GetColunms(arrTables[1, i]);
                DataTable dtbKeyProperties = oThongTinCSDL.TimKhoa(arrTables[1, i]);
                if (dtbKeyProperties.Rows.Count == 0)
                    SQL += "\n";
                else
                {
                    SQL += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_" + arrTables[0, i] + "_Delete]') AND type in (N'P', N'PC'))";
                    SQL += "\nDROP PROCEDURE [dbo].[sp_" + arrTables[0, i] + "_Delete]\nGO";
                    SQL += "\nCREATE PROCEDURE dbo.sp_";
                    SQL += arrTables[0, i] + "_Delete";
                    // Lay Khoa chinh cua bang

                    SQL += "\n(";
                    DataView dtvKeyProperty = dtbKeyProperties.DefaultView;
                    for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
                    {
                        if (j >= 1)
                            SQL += ",\n\t@" + dtbKeyProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbKeyProperties.Rows[j]["xtype"].ToString()) + "(" + dtbKeyProperties.Rows[j]["Length"].ToString() + ")";
                        else
                            SQL += "\n\t@" + dtbKeyProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbKeyProperties.Rows[j]["xtype"].ToString()) + "(" + dtbKeyProperties.Rows[j]["Length"].ToString() + ")";
                    }

                    SQL += "\n)\nAS";
                    SQL += "\nBEGIN";
                    SQL += "\n\tDELETE FROM " + arrTables[0, i] + " ";
                    SQL += " WHERE ";
                    for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
                    {
                        if (j >= 1)
                            SQL += " AND " + dtbKeyProperties.Rows[j]["name"].ToString() + " = @" + dtbKeyProperties.Rows[j]["name"].ToString();
                        else
                            SQL += " " + dtbKeyProperties.Rows[j]["name"].ToString() + " = @" + dtbKeyProperties.Rows[j]["name"].ToString();
                    }
                    SQL += "\n";
                    SQL += "\nEND\nGO";
                }
            }
            SQL = SQL.Replace("int(4)", "int");
            SQL = SQL.Replace("datetime(8)", "datetime");
            SQL = SQL.Replace("money(8)", "money");
            SQL = SQL.Replace("float(8)", "float");
            SQL = SQL.Replace("bigint(8)", "bigint");
            SQL = SQL.Replace("bit(1)", "bit");
            SQL = SQL.Replace("image(16)", "image");
            SQL = SQL.Replace("ntext(16)", "ntext");
            SQL = SQL.Replace("real(4)", "real");

            return SQL;
        }

        public string TaoThuTucDelete(string TableName, string TableID)
        {
            string SQL = "";
            DataTable dtbProperties = oThongTinCSDL.GetColunms(TableID);
            DataTable dtbKeyProperties = oThongTinCSDL.TimKhoa(TableID);
            if (dtbKeyProperties.Rows.Count == 0)
                SQL += "\n";
            else
            {
                SQL += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_" + TableName + "_Delete]') AND type in (N'P', N'PC'))";
                SQL += "\nDROP PROCEDURE [dbo].[sp_" + TableName + "_Delete]\nGO";
                SQL += "\nCREATE PROCEDURE dbo.sp_";
                SQL += TableName + "_Delete";
                // Lay Khoa chinh cua bang

                SQL += "\n(";
                DataView dtvKeyProperty = dtbKeyProperties.DefaultView;
                for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
                {
                    if (j >= 1)
                        SQL += ",\n\t@" + dtbKeyProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbKeyProperties.Rows[j]["xtype"].ToString()) + "(" + dtbKeyProperties.Rows[j]["Length"].ToString() + ")";
                    else
                        SQL += "\n\t@" + dtbKeyProperties.Rows[j]["name"].ToString() + " " + oThongTinCSDL.GetDataType(dtbKeyProperties.Rows[j]["xtype"].ToString()) + "(" + dtbKeyProperties.Rows[j]["Length"].ToString() + ")";
                }

                SQL += "\n)\nAS";
                SQL += "\nBEGIN";
                SQL += "\n\tDELETE FROM " + TableName + " ";
                SQL += " WHERE ";
                for (int j = 0; j < dtbKeyProperties.Rows.Count; j++)
                {
                    if (j >= 1)
                        SQL += " AND " + dtbKeyProperties.Rows[j]["name"].ToString() + " = @" + dtbKeyProperties.Rows[j]["name"].ToString();
                    else
                        SQL += " " + dtbKeyProperties.Rows[j]["name"].ToString() + " = @" + dtbKeyProperties.Rows[j]["name"].ToString();
                }
                SQL += "\n";
                SQL += "\nEND\nGO";
            }
            SQL = SQL.Replace("int(4)", "int");
            SQL = SQL.Replace("datetime(8)", "datetime");
            SQL = SQL.Replace("money(8)", "money");
            SQL = SQL.Replace("float(8)", "float");
            SQL = SQL.Replace("bigint(8)", "bigint");
            SQL = SQL.Replace("bit(1)", "bit");
            SQL = SQL.Replace("image(16)", "image");
            SQL = SQL.Replace("ntext(16)", "ntext");
            SQL = SQL.Replace("real(4)", "real");

            return SQL;
        }
    }
}
