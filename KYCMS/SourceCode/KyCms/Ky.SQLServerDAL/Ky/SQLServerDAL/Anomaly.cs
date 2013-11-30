namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Anomaly : IAnomaly
    {
        public bool Add(M_Anomaly model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@InfoId", SqlDbType.Int, 4), new SqlParameter("@ChId", SqlDbType.Int, 4), new SqlParameter("@ColName", SqlDbType.NVarChar), new SqlParameter("@Title", SqlDbType.VarChar, 200) };
            commandParameters[0].Value = model.InfoId;
            commandParameters[1].Value = model.ChId;
            commandParameters[2].Value = model.ColName;
            commandParameters[3].Value = model.Title;
            return (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Anomaly_Add", commandParameters) > 0);
        }

        public bool CheckHas(int chId, int infoId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@chid", SqlDbType.Int), new SqlParameter("@infoid", SqlDbType.Int) };
            commandParameters[0].Value = chId;
            commandParameters[1].Value = infoId;
            if (SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Anomaly_CheckHas", commandParameters).Rows.Count > 0)
            {
                return false;
            }
            return true;
        }

        public void Delete(int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int, 4) };
            commandParameters[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_Anomaly_Delete", commandParameters);
        }

        public DataTable GetList(int chId, int pageIndex, int pageSize, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@chid", SqlDbType.Int), new SqlParameter("@pageindex", SqlDbType.Int), new SqlParameter("@pagesize", SqlDbType.Int), new SqlParameter("@recordcount", SqlDbType.Int) };
            commandParameters[0].Value = chId;
            commandParameters[1].Value = pageIndex;
            commandParameters[2].Value = pageSize;
            commandParameters[3].Value = 0;
            commandParameters[3].Direction = ParameterDirection.Output;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Anomaly_GetList", commandParameters);
            recordCount = int.Parse(commandParameters[3].Value.ToString());
            if ((table != null) && (table.Rows.Count != 0))
            {
                return table;
            }
            return null;
        }
    }
}

