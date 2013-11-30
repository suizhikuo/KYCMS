namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Log : ILog
    {
        public void Add(LogType logType, string userName, int userId, string description, string ipAddress, DateTime logTime)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@LogType", logType), new SqlParameter("@UserName", userName), new SqlParameter("@UserId", userId), new SqlParameter("@Description", description), new SqlParameter("@IpAddress", ipAddress), new SqlParameter("@LogTime", logTime) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Log_Add", commandParameters);
        }

        public void Delete(DateTime logTime)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@LogTime", logTime) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Log_Delete", commandParameters);
        }

        public DataTable GetList(LogType logType, string userName, string startTime, string endTime, int currPage, int pageSize, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@LogType", logType), new SqlParameter("@UserName", userName), new SqlParameter("@StartTime", startTime), new SqlParameter("@EndTime", endTime), new SqlParameter("@CurrPage", currPage), new SqlParameter("@PageSize", pageSize), new SqlParameter("@RecordCount", SqlDbType.BigInt) };
            commandParameters[6].Direction = ParameterDirection.Output;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Log_GetList", commandParameters);
            recordCount = int.Parse(commandParameters[6].Value.ToString());
            return table;
        }
    }
}

