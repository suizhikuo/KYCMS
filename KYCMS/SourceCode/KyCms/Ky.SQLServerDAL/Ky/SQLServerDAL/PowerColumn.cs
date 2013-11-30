namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class PowerColumn : IPowerColumn
    {
        public M_PowerColumn GetModel(int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int) };
            commandParameters[0].Value = id;
            DataTable table = new DataTable();
            table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_PowerColumn_Update", commandParameters);
            if (table.Rows.Count > 0)
            {
                M_PowerColumn column = new M_PowerColumn();
                column.PowerColumnName = table.Rows[0]["PowerColumnName"].ToString();
                column.ColumnErrorCodes = table.Rows[0]["ColumnErrorCodes"].ToString();
                return column;
            }
            return null;
        }
    }
}

