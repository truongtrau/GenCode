using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace TVGenCode
{
    public class cTruyVanCSDL
    {
        public static SqlConnection sqlCn;
        public void RunSQL(string SQL)
        {
            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                string[] arrSQL = SQL.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arrSQL.Length; i++)
                {
                    sqlCmd.CommandText = arrSQL[i];
                    sqlCmd.ExecuteNonQuery();
                }
            }
            //catch{}
            finally { }

            sqlDA.Dispose();
            sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;
        }

        public DataTable RunSQLGet(string SQL)
        {
            DataTable dtb = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = SQL;
                sqlDA.Fill(dtb);
            }
            finally { }

            sqlDA.Dispose();
            sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;

            return dtb;
        }
    }
}
