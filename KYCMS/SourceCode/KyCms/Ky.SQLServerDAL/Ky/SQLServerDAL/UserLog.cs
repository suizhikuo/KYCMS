namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class UserLog : IUserLog
    {
        public void Add(M_UserLog model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", model.UserId), new SqlParameter("@UserName", model.UserName), new SqlParameter("@Description", model.Description), new SqlParameter("@InfoId", model.InfoId), new SqlParameter("@ModelType", model.ModelType), new SqlParameter("@Point", model.Point), new SqlParameter("@AddTime", model.AddTime) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserLog_Add", commandParameters);
        }

        public bool CheckIsPay(int checkPayType, int modelType, int infoId, int userId, int hourCount, int viewCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CheckPayType", checkPayType), new SqlParameter("@ModelType", modelType), new SqlParameter("@InfoId", infoId), new SqlParameter("@UserId", userId), new SqlParameter("@HourCount", hourCount), new SqlParameter("@ViewCount", viewCount) };
            return (Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserLog_CheckIsPay", commandParameters)) == 1);
        }

        public DataTable ListLog(string whereStr, int pageSize, int pageIndex, ref int total)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@WhereStr", SqlDbType.NVarChar, 200), new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@PageIndex", SqlDbType.Int, 4), new SqlParameter("Total", SqlDbType.Int, 4) };
            commandParameters[0].Value = whereStr;
            commandParameters[1].Value = pageSize;
            commandParameters[2].Value = pageIndex;
            commandParameters[3].Value = 0;
            commandParameters[3].Direction = ParameterDirection.Output;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserLog_ListLog", commandParameters);
            total = (int) commandParameters[3].Value;
            return table;
        }

        public bool ReducePoint(int userId, int point)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", userId), new SqlParameter("@Point", point) };
            return (Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserLog_ReducePoint", commandParameters)) == 1);
        }
    }
}

