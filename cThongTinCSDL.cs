using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TVGenCode
{
    public class cThongTinCSDL
    {
        private cTruyVanCSDL oTruyVanCSLD = new cTruyVanCSDL();

        public string[,] GetTableNameId()
        {
            string[,] arrTable;
            DataTable dtbTables = oTruyVanCSLD.RunSQLGet("SELECT Name, id FROM sysobjects WHERE  Name <> 'dtproperties' AND Name <> 'sysdiagrams' AND Xtype = 'U' ORDER BY name"); 
            arrTable = new string[2, dtbTables.Rows.Count];
            for (int i=0;i<dtbTables.Rows.Count;i++)
            {
                arrTable[0, i] = dtbTables.Rows[i]["Name"].ToString();
                arrTable[1, i] = dtbTables.Rows[i]["id"].ToString();
            }
            return arrTable;
        }

        public string[] GetTableName()
        {
            string[] arrTable;
            DataTable dtbTables = oTruyVanCSLD.RunSQLGet("SELECT Name, id FROM sysobjects WHERE Name <> 'dtproperties'  AND Name <> 'sysdiagrams' AND Xtype = 'U' ORDER BY name");
            arrTable = new string[dtbTables.Rows.Count];
            for (int i = 0; i < dtbTables.Rows.Count; i++)
            {
                arrTable[i] = dtbTables.Rows[i]["Name"].ToString();
            }
            return arrTable;
        }

        public DataTable GetTable()
        {
            DataTable dtbTables = oTruyVanCSLD.RunSQLGet("SELECT Name as TableName, id FROM sysobjects WHERE Name <> 'dtproperties'  AND Name <> 'sysdiagrams' AND Xtype = 'U' ORDER BY name");
            if (dtbTables.Rows.Count > 0)
            {
                if (dtbTables.Columns.Contains("STT") == false)
                {
                    dtbTables.Columns.Add("STT", Type.GetType("System.Int32"));
                    dtbTables.Columns.Add("Select", Type.GetType("System.Boolean"));
                }
                for (int i = 0; i <= dtbTables.Rows.Count - 1; i++)
                {
                    dtbTables.Rows[i]["STT"] = i + 1;
                    dtbTables.Rows[i]["Select"] = false;
                }
            }
            return dtbTables;
        }

        public DataTable GetColunms(string TableID)
        {
            DataTable dtb = oTruyVanCSLD.RunSQLGet("SELECT Name, xType, Length, colstat, isnullable FROM syscolumns WHERE id = " + TableID);
            return dtb;
        }

        public string GetDataType(string xtype)
        {
            DataTable dtb = oTruyVanCSLD.RunSQLGet("SELECT Name, xType FROM systypes WHERE xType = " + xtype);
            if (dtb.Rows.Count == 0)
                return "";
            return dtb.Rows[0]["Name"].ToString();
        }

        public string GetCsDataType(string xtype)
        {
            DataTable dtb = oTruyVanCSLD.RunSQLGet("SELECT Name, xType FROM systypes WHERE xType = " + xtype);
            if (dtb.Rows.Count == 0)
                return "";
            string CsDataType = "";
            switch (dtb.Rows[0]["Name"].ToString())
            {
                case "int":
                case "tinyint":
                    CsDataType = "int";
                    break;
                case "bigint":
                    CsDataType = "long";
                    break;
                case "numeric":
                case "real":
                case "float":
                case "money":
                case "decimal":
                    CsDataType = "double";
                    break;
                case "boolean":
                case "bit":
                    CsDataType = "bool";
                    break;
                case "datetime":
                case "smalldatetime":
                    CsDataType = "DateTime";
                    break;
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":                    
                case "char":
                case "nchar":
                    CsDataType = "string";
                    break;
                case "image":
                    CsDataType = "byte[]";
                    break;
            }
            return CsDataType;
        }

        public string Get_SP_DataType(string xtype)
        {
            DataTable dtb = oTruyVanCSLD.RunSQLGet("SELECT Name, xType FROM systypes WHERE xType = " + xtype);
            if (dtb.Rows.Count == 0)
                return "";
            string CsDataType = "";
            switch (dtb.Rows[0]["Name"].ToString())
            {
                case "int":
                    CsDataType = "Int";
                    break;
                case "tinyint":
                    CsDataType = "TinyInt";
                    break;
                case "bigint":                    
                    CsDataType = "BigInt";
                    break;
                case "numeric":
                    CsDataType = "Numeric";
                    break;
                case "real":
                    CsDataType = "Real";
                    break;
                case "float":
                    CsDataType = "Float";
                    break;
                case "money":
                    CsDataType = "Money";
                    break;
                case "boolean":
                case "bit":                    
                    CsDataType = "Bit";
                    break;
                case "smalldatetime":
                    CsDataType = "SmallDateTime";
                    break;
                case "datetime":
                    CsDataType = "DateTime";
                    break;
                case "varchar":
                    CsDataType = "VarChar";
                    break;
                case "nvarchar":
                    CsDataType = "NVarChar";
                    break;
                case "text":
                    CsDataType = "Text";
                    break;
                case "ntext":
                    CsDataType = "NText";
                    break;
                case "char":
                    CsDataType = "Char";
                    break;
                case "nchar":
                    CsDataType = "NChar";
                    break;
                case "decimal":
                    CsDataType = "Decimal";
                    break;
                case "image":
                    CsDataType = "Image";
                    break;
            }
            return CsDataType;
        }

        public DataTable TimKhoa(string TableID)
        {
            string SQL = "SELECT name, xtype,Length, id, colstat, colid FROM syscolumns WHERE syscolumns.id = " + TableID;
            SQL += "AND colid IN (SELECT colid FROM sysindexkeys LEFT JOIN sysindexes ON sysindexkeys.indid = sysindexes.indid ";
            SQL += "WHERE sysindexes.Id = " + TableID + " AND sysindexkeys.id = " + TableID;
            SQL += "AND Name like 'PK_%')";
            DataTable dtb = oTruyVanCSLD.RunSQLGet(SQL);
            return dtb;
        }
    }
}
