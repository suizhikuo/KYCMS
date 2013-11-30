namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.ComponentModel;

    public class UserFavorite : IUserFavorite
    {
        public void Add(M_UserFavorite model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("@Title", SqlDbType.NVarChar), new SqlParameter("@Url", SqlDbType.NVarChar), new SqlParameter("@AddDate", SqlDbType.DateTime), new SqlParameter("@TypeId", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.UserId;
            commandParameters[1].Value = model.Title;
            commandParameters[2].Value = model.Url;
            commandParameters[3].Value = model.AddDate;
            commandParameters[4].Value = 1;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserFavorite", commandParameters);
        }

        public void Delete(int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int, 4), new SqlParameter("@TypeId", SqlDbType.Int, 4) };
            commandParameters[0].Value = id;
            commandParameters[1].Value = 2;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserFavorite", commandParameters);
        }

        public DataSet GetList(int currPage, int pageSize, string WhereStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CurrPage", SqlDbType.Int, 4), new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@WhereStr", SqlDbType.NVarChar, 100) };
            commandParameters[0].Value = currPage;
            commandParameters[1].Value = pageSize;
            commandParameters[2].Value = WhereStr;
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserFavorite_GetList", commandParameters);
        }
    }
}

