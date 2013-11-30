namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Superior : ISuperior
    {
        public void Add(M_Superior model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Name", SqlDbType.NVarChar), new SqlParameter("@StartCode", SqlDbType.NVarChar), new SqlParameter("@EndCode", SqlDbType.NVarChar) };
            commandParameters[0].Value = model.Name;
            commandParameters[1].Value = model.StartCode;
            commandParameters[2].Value = model.EndCode;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Superior_Add", commandParameters);
        }

        public void Delete(int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int, 4) };
            commandParameters[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Superior_Delete", commandParameters);
        }

        public M_Superior GetIdBySuperior(int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int, 4) };
            commandParameters[0].Value = id;
            M_Superior superior = new M_Superior();
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Superior_GetIdBySuperiorl", commandParameters);
            superior.id = id;
            if (table.Rows.Count > 0)
            {
                superior.Name = table.Rows[0]["Name"].ToString();
                superior.StartCode = table.Rows[0]["StartCode"].ToString();
                superior.EndCode = table.Rows[0]["EndCode"].ToString();
                return superior;
            }
            return null;
        }

        public DataTable GetList()
        {
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Superior_GetList", null);
        }

        public void Update(M_Superior model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int, 4), new SqlParameter("@Name", SqlDbType.NVarChar), new SqlParameter("@StartCode", SqlDbType.NVarChar), new SqlParameter("@EndCode", SqlDbType.NVarChar) };
            commandParameters[0].Value = model.id;
            commandParameters[1].Value = model.Name;
            commandParameters[2].Value = model.StartCode;
            commandParameters[3].Value = model.EndCode;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Superior_Update", commandParameters);
        }
    }
}

