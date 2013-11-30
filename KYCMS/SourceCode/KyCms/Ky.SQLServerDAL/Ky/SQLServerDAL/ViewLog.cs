namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class ViewLog : IViewLog
    {
        public void Add(M_ViewLog model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", model.UserId), new SqlParameter("@UserName", model.UserName), new SqlParameter("@ModelType", model.ModelType), new SqlParameter("@InfoId", model.InfoId), new SqlParameter("@AddTime", model.AddTime) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ViewLog_Add", commandParameters);
        }

        public int GetViewCount(int userId, string date)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", userId), new SqlParameter("@Date", date) };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_ViewLog_GetViewCount", commandParameters));
        }
    }
}

