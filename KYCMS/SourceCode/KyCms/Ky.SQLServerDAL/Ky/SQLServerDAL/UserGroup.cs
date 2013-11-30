namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class UserGroup : IUserGroup
    {
        public void Add(M_UserGroup model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserGroupName", SqlDbType.NVarChar), new SqlParameter("@UserGroupContent", SqlDbType.NVarChar), new SqlParameter("@TypeId", SqlDbType.Int, 4), new SqlParameter("@GroupPower", SqlDbType.NText), new SqlParameter("@ColumnPower", SqlDbType.NText), new SqlParameter("@IsSystem", SqlDbType.Int, 4), new SqlParameter("@AddDate", SqlDbType.DateTime), new SqlParameter("@Up_Id", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.UserGroupName;
            commandParameters[1].Value = model.UserGroupContent;
            commandParameters[2].Value = model.TypeId;
            commandParameters[3].Value = model.GroupPower;
            commandParameters[4].Value = model.ColumnPower;
            commandParameters[5].Value = model.IsSystem;
            commandParameters[6].Value = model.AddDate;
            commandParameters[7].Value = 1;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserGroup", commandParameters);
        }

        public void Delete(int UserGroupId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserGroupId", SqlDbType.Int, 4), new SqlParameter("@Up_Id", SqlDbType.Int, 4) };
            commandParameters[0].Value = UserGroupId;
            commandParameters[1].Value = 3;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserGroup", commandParameters);
        }

        public DataSet GetList(int currPage, int pageSize, string WhereStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CurrPage", SqlDbType.Int, 4), new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@WhereStr", SqlDbType.NVarChar, 100) };
            commandParameters[0].Value = currPage;
            commandParameters[1].Value = pageSize;
            commandParameters[2].Value = WhereStr;
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserGroup_GetList", commandParameters);
        }

        public M_UserGroup GetModel(int UserGroupId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserGroupId", SqlDbType.Int, 4), new SqlParameter("@Up_Id", SqlDbType.Int, 4) };
            commandParameters[0].Value = UserGroupId;
            commandParameters[1].Value = 4;
            M_UserGroup group = new M_UserGroup();
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserGroup", commandParameters);
            group.UserGroupId = UserGroupId;
            if (set.Tables[0].Rows.Count > 0)
            {
                group.UserGroupName = set.Tables[0].Rows[0]["UserGroupName"].ToString();
                group.UserGroupContent = set.Tables[0].Rows[0]["UserGroupContent"].ToString();
                if (set.Tables[0].Rows[0]["TypeId"].ToString() != "")
                {
                    group.TypeId = int.Parse(set.Tables[0].Rows[0]["TypeId"].ToString());
                }
                group.GroupPower = set.Tables[0].Rows[0]["GroupPower"].ToString();
                group.ColumnPower = set.Tables[0].Rows[0]["ColumnPower"].ToString();
                if (set.Tables[0].Rows[0]["IsSystem"].ToString() != "")
                {
                    group.IsSystem = int.Parse(set.Tables[0].Rows[0]["IsSystem"].ToString());
                }
                if (set.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    group.AddDate = DateTime.Parse(set.Tables[0].Rows[0]["AddDate"].ToString());
                }
                return group;
            }
            return null;
        }

        public DataTable ManageList(string StrWhere)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@StrWhere", SqlDbType.NVarChar, 0x3e8) };
            commandParameters[0].Value = StrWhere;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserGroup_ManageList", commandParameters);
        }

        public void Update(M_UserGroup model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserGroupId", SqlDbType.Int, 4), new SqlParameter("@UserGroupName", SqlDbType.NVarChar), new SqlParameter("@UserGroupContent", SqlDbType.NVarChar), new SqlParameter("@GroupPower", SqlDbType.NText), new SqlParameter("@ColumnPower", SqlDbType.NText), new SqlParameter("@IsSystem", SqlDbType.Int, 4), new SqlParameter("@AddDate", SqlDbType.DateTime), new SqlParameter("@Up_Id", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.UserGroupId;
            commandParameters[1].Value = model.UserGroupName;
            commandParameters[2].Value = model.UserGroupContent;
            commandParameters[3].Value = model.GroupPower;
            commandParameters[4].Value = model.ColumnPower;
            commandParameters[5].Value = model.IsSystem;
            commandParameters[6].Value = model.AddDate;
            commandParameters[7].Value = 2;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserGroup", commandParameters);
        }
    }
}

