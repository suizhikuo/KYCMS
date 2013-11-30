namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Money : IMoney
    {
        public void ExpireTime(int Value, int UserId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Value", SqlDbType.NVarChar), new SqlParameter("@UserId", SqlDbType.Int), new SqlParameter("@TypeId", SqlDbType.Int) };
            commandParameters[0].Value = Value;
            commandParameters[1].Value = UserId;
            commandParameters[2].Value = 3;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UpdateMoney", commandParameters);
        }

        public void Integral(int Value, int UserId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Value", SqlDbType.NVarChar), new SqlParameter("@UserId", SqlDbType.Int), new SqlParameter("@TypeId", SqlDbType.Int) };
            commandParameters[0].Value = Value;
            commandParameters[1].Value = UserId;
            commandParameters[2].Value = 2;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UpdateMoney", commandParameters);
        }

        public void YellowBoy(decimal Value, int UserId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Value", SqlDbType.NVarChar), new SqlParameter("@UserId", SqlDbType.Int), new SqlParameter("@TypeId", SqlDbType.Int) };
            commandParameters[0].Value = Value;
            commandParameters[1].Value = UserId;
            commandParameters[2].Value = 1;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UpdateMoney", commandParameters);
        }
    }
}

