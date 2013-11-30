namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Group : IGroup
    {
        public int Delete(int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@GroupId", SqlDbType.Int, 4) };
            commandParameters[0].Value = id;
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Group_Delete", commandParameters));
        }

        public DataTable GetAdminGroupList()
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TypeId", SqlDbType.Int) };
            commandParameters[0].Value = 1;
            DataTable table = new DataTable();
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_PowerGroup", commandParameters);
        }

        public int GetAdminGroupUserCount(int groupId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@GroupId", groupId) };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Group_GetAdminGroupUserCount", commandParameters));
        }
    }
}

