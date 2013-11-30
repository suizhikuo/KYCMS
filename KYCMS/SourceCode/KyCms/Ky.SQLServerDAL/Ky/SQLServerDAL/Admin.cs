namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Admin : IAdmin
    {
        public bool Add(M_Admin model)
        {
            SqlParameter[] commandParameters = new SqlParameter[7];
            commandParameters[0] = new SqlParameter("@LogName", SqlDbType.NVarChar, 20);
            commandParameters[0].Value = model.LoginName;
            commandParameters[1] = new SqlParameter("@UserName", SqlDbType.NVarChar, 20);
            commandParameters[1].Value = model.UserName;
            commandParameters[2] = new SqlParameter("@Password", SqlDbType.VarChar, 200);
            commandParameters[2].Value = model.Password;
            commandParameters[3] = new SqlParameter("@GroupId", SqlDbType.Int, 4);
            commandParameters[3].Value = model.GroupId;
            commandParameters[4] = new SqlParameter("@GroupName", SqlDbType.NVarChar, 50);
            commandParameters[4].Value = model.GroupName;
            commandParameters[5] = new SqlParameter("@AllowMultiLogin", SqlDbType.Bit, 1);
            commandParameters[5].Value = model.AllowMultiLogin;
            commandParameters[6] = new SqlParameter("@output", SqlDbType.Bit, 1);
            commandParameters[6].Direction = ParameterDirection.Output;
            commandParameters[6].Value = 0;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Admin_Add", commandParameters);
            return (bool) commandParameters[6].Value;
        }

        public void Delete(int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", SqlDbType.Int, 4) };
            commandParameters[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Admin_Delete", commandParameters);
        }

        public DataTable GetAdminByGroupID(int goupID)
        {
            DataTable table = new DataTable("Admin");
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@GroupId", SqlDbType.Int, 4) };
            commandParameters[0].Value = goupID;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Admin_GetAdminListByGroupId", commandParameters);
        }

        public DataTable GetAdminList()
        {
            DataTable table = new DataTable("Admin");
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Admin_GetAdminList", null);
        }

        public string GetGroupAdminCount(int goupID)
        {
            DataTable table = new DataTable("Admin");
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@GroupId", SqlDbType.Int, 4) };
            commandParameters[0].Value = goupID;
            return SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Admin_GetAdminCount", commandParameters).ToString();
        }

        public M_Admin GetModel(int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", userId) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Admin_GetInfoById", commandParameters);
            if ((table != null) && (table.Rows.Count > 0))
            {
                M_Admin admin = new M_Admin();
                admin.UserId = int.Parse(table.Rows[0]["UserId"].ToString());
                admin.LoginName = table.Rows[0]["LoginName"].ToString();
                admin.UserName = table.Rows[0]["UserName"].ToString();
                admin.LoginName = table.Rows[0]["LoginName"].ToString();
                admin.UserName = table.Rows[0]["UserName"].ToString();
                admin.Password = table.Rows[0]["Password"].ToString();
                admin.LastLoginIP = table.Rows[0]["LastLoginIP"].ToString();
                if (table.Rows[0]["LastLoginTime"].ToString() != "")
                {
                    admin.LastLoginTime = DateTime.Parse(table.Rows[0]["LastLoginTime"].ToString());
                }
                if (table.Rows[0]["LastLogoutTime"].ToString() != "")
                {
                    admin.LastLogoutTime = DateTime.Parse(table.Rows[0]["LastLogoutTime"].ToString());
                }
                if (table.Rows[0]["LoginTime"].ToString() != "")
                {
                    admin.LoginTime = int.Parse(table.Rows[0]["LoginTime"].ToString());
                }
                if (table.Rows[0]["AllowMultiLogin"].ToString() != "")
                {
                    if ((table.Rows[0]["AllowMultiLogin"].ToString() == "1") || (table.Rows[0]["AllowMultiLogin"].ToString().ToLower() == "true"))
                    {
                        admin.AllowMultiLogin = true;
                    }
                    else
                    {
                        admin.AllowMultiLogin = false;
                    }
                }
                if (table.Rows[0]["CheckCount"].ToString() != "")
                {
                    admin.CheckCount = int.Parse(table.Rows[0]["CheckCount"].ToString());
                }
                if (table.Rows[0]["AddCount"].ToString() != "")
                {
                    admin.AddCount = int.Parse(table.Rows[0]["AddCount"].ToString());
                }
                if (table.Rows[0]["RejectCount"].ToString() != "")
                {
                    admin.RejectCount = int.Parse(table.Rows[0]["RejectCount"].ToString());
                }
                if (table.Rows[0]["GroupId"].ToString() != "")
                {
                    admin.GroupId = int.Parse(table.Rows[0]["GroupId"].ToString());
                }
                admin.GroupName = table.Rows[0]["GroupName"].ToString();
                admin.RandNumber = table.Rows[0]["RandNumber"].ToString();
                return admin;
            }
            return null;
        }

        public M_Admin GetModel(string loginName, string password)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@LoginName", loginName), new SqlParameter("@password", password) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Admin_GetInfoByNameAndPass", commandParameters);
            if ((table != null) && (table.Rows.Count > 0))
            {
                M_Admin admin = new M_Admin();
                admin.UserId = int.Parse(table.Rows[0]["UserId"].ToString());
                admin.LoginName = table.Rows[0]["LoginName"].ToString();
                admin.UserName = table.Rows[0]["UserName"].ToString();
                admin.LoginName = table.Rows[0]["LoginName"].ToString();
                admin.UserName = table.Rows[0]["UserName"].ToString();
                admin.Password = table.Rows[0]["Password"].ToString();
                admin.LastLoginIP = table.Rows[0]["LastLoginIP"].ToString();
                if (table.Rows[0]["LastLoginTime"].ToString() != "")
                {
                    admin.LastLoginTime = DateTime.Parse(table.Rows[0]["LastLoginTime"].ToString());
                }
                if (table.Rows[0]["LastLogoutTime"].ToString() != "")
                {
                    admin.LastLogoutTime = DateTime.Parse(table.Rows[0]["LastLogoutTime"].ToString());
                }
                if (table.Rows[0]["LoginTime"].ToString() != "")
                {
                    admin.LoginTime = int.Parse(table.Rows[0]["LoginTime"].ToString());
                }
                if (table.Rows[0]["AllowMultiLogin"].ToString() != "")
                {
                    if ((table.Rows[0]["AllowMultiLogin"].ToString() == "1") || (table.Rows[0]["AllowMultiLogin"].ToString().ToLower() == "true"))
                    {
                        admin.AllowMultiLogin = true;
                    }
                    else
                    {
                        admin.AllowMultiLogin = false;
                    }
                }
                if (table.Rows[0]["CheckCount"].ToString() != "")
                {
                    admin.CheckCount = int.Parse(table.Rows[0]["CheckCount"].ToString());
                }
                if (table.Rows[0]["AddCount"].ToString() != "")
                {
                    admin.AddCount = int.Parse(table.Rows[0]["AddCount"].ToString());
                }
                if (table.Rows[0]["RejectCount"].ToString() != "")
                {
                    admin.RejectCount = int.Parse(table.Rows[0]["RejectCount"].ToString());
                }
                if (table.Rows[0]["GroupId"].ToString() != "")
                {
                    admin.GroupId = int.Parse(table.Rows[0]["GroupId"].ToString());
                }
                admin.GroupName = table.Rows[0]["GroupName"].ToString();
                admin.RandNumber = table.Rows[0]["RandNumber"].ToString();
                return admin;
            }
            return null;
        }

        public void UpdateInfo(M_Admin model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", model.UserId), new SqlParameter("@Password", model.Password), new SqlParameter("@AllowMultiLogin", model.AllowMultiLogin), new SqlParameter("@GroupId", model.GroupId), new SqlParameter("@GroupName", model.GroupName), new SqlParameter("@UserName", model.UserName) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Admin_Update", commandParameters);
        }

        public void UpdateState(M_Admin model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@LastLoginIP", model.LastLoginIP), new SqlParameter("@LastLoginTime", model.LastLoginTime), new SqlParameter("@RandNumber", model.RandNumber), new SqlParameter("@LoginName", model.LoginName) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Admin_UpdateState", commandParameters);
        }
    }
}

