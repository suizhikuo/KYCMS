namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class User : IUser
    {
        public int AddFriend(int userId, string friendName, int groupId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("@FriendName", SqlDbType.NVarChar, 20), new SqlParameter("@FriendGroupId", SqlDbType.Int, 4), new SqlParameter("@Flag", SqlDbType.Int, 4) };
            commandParameters[0].Value = userId;
            commandParameters[1].Value = friendName;
            commandParameters[2].Value = groupId;
            commandParameters[3].Value = 0;
            commandParameters[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_User_AddFriend", commandParameters);
            return (int) commandParameters[3].Value;
        }

        public void AddFriendGroup(string groupName, int isUserId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@GroupName", SqlDbType.NVarChar), new SqlParameter("@IsUserId", SqlDbType.Int, 4), new SqlParameter("@GroupId", SqlDbType.Int, 4), new SqlParameter("@Type", SqlDbType.VarChar, 20) };
            commandParameters[0].Value = groupName;
            commandParameters[1].Value = isUserId;
            commandParameters[2].Value = 0;
            commandParameters[3].Value = "Add";
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_User_SetFriendGroup", commandParameters);
        }

        public void AddUserCate(M_UserCate model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("@CateName", SqlDbType.VarChar, 50), new SqlParameter("@CateType", SqlDbType.Int, 4), new SqlParameter("@Discription", SqlDbType.Text), new SqlParameter("@UserCateId", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.UserId;
            commandParameters[1].Value = model.CateName;
            commandParameters[2].Value = model.CateType;
            commandParameters[3].Value = model.Discription;
            commandParameters[4].Value = model.UserCateId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserCate_Set", commandParameters);
        }

        public bool CheckMultiIdentity(string input, string tabelName, string filedName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@input", SqlDbType.NVarChar, 500), new SqlParameter("@tableName", SqlDbType.NVarChar, 100), new SqlParameter("@filedName", SqlDbType.NVarChar, 100), new SqlParameter("@output", SqlDbType.Int, 4) };
            commandParameters[0].Value = input;
            commandParameters[1].Value = tabelName;
            commandParameters[2].Value = filedName;
            commandParameters[3].Value = 0;
            commandParameters[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_User_CheckMultiIdentity", commandParameters);
            int num = (int) commandParameters[3].Value;
            return (num > 1);
        }

        public int CountFriendGroupMember(int groupId, int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@GroupName", SqlDbType.NVarChar), new SqlParameter("@IsUserId", SqlDbType.Int, 4), new SqlParameter("@GroupId", SqlDbType.Int, 4), new SqlParameter("@Type", SqlDbType.VarChar, 20) };
            commandParameters[0].Value = "";
            commandParameters[1].Value = userId;
            commandParameters[2].Value = groupId;
            commandParameters[3].Value = "CountMember";
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_User_SetFriendGroup", commandParameters);
            if ((table != null) && (table.Rows.Count > 0))
            {
                return (int) table.Rows[0][0];
            }
            return 0;
        }

        public void Delete(int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            commandParameters[0].Value = userId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Users_Delete", commandParameters);
        }

        public void DeleteFriend(int Id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int, 4) };
            commandParameters[0].Value = Id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_User_DeleteFriend", commandParameters);
        }

        public void DeleteFriendGroup(int groupId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@GroupName", SqlDbType.NVarChar), new SqlParameter("@IsUserId", SqlDbType.Int, 4), new SqlParameter("@GroupId", SqlDbType.Int, 4), new SqlParameter("@Type", SqlDbType.VarChar, 20) };
            commandParameters[0].Value = "";
            commandParameters[1].Value = -1;
            commandParameters[2].Value = groupId;
            commandParameters[3].Value = "Delete";
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_User_SetFriendGroup", commandParameters);
        }

        public void DeleteResume(int id)
        {
            this.SetResume(3, id, 0, "", 0, "", 0, 0, 0, DateTime.Now);
        }

        public void DeleteUserCate(int userCateId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserCateId", SqlDbType.Int, 4) };
            commandParameters[0].Value = userCateId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserCate_Delete", commandParameters);
        }

        public M_User GetUser(string identity, int type)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Identity", SqlDbType.NVarChar, 20), new SqlParameter("@Type", SqlDbType.Int, 4) };
            commandParameters[0].Value = identity;
            commandParameters[1].Value = type;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Users_GetUser", commandParameters);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                M_User user = new M_User();
                user.UserID = int.Parse(row["userid"].ToString());
                user.LogName = row["logname"].ToString();
                user.UserPwd = row["userpwd"].ToString();
                user.Email = row["email"].ToString();
                user.GroupID = int.Parse(row["groupid"].ToString());
                user.Question = row["question"].ToString();
                user.Answer = row["answer"].ToString();
                user.Integral = int.Parse(row["integral"].ToString());
                user.YellowBoy = decimal.Parse(row["yellowboy"].ToString());
                user.IsLock = bool.Parse(row["islock"].ToString());
                user.RegTime = DateTime.Parse(row["regtime"].ToString());
                user.LoginNum = int.Parse(row["loginnum"].ToString());
                user.LastLoginIP = row["lastloginip"].ToString();
                user.LastLoginTime = DateTime.Parse(row["lastlogintime"].ToString());
                user.Secret = int.Parse(row["secret"].ToString());
                user.ErrorNum = int.Parse(row["errornum"].ToString());
                user.ErrorTime = DateTime.Parse(row["errortime"].ToString());
                user.ExpireTime = DateTime.Parse(row["expiretime"].ToString());
                user.ConfirmRegCode = row["confirmregcode"].ToString();
                user.TypeId = int.Parse(row["typeid"].ToString());
                user.Status = int.Parse(row["status"].ToString());
                return user;
            }
            return null;
        }

        public DataRow GetUserAllInfo(int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@userId", userId) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_User_GetAllInfo", commandParameters);
            if ((table == null) || (table.Rows.Count <= 0))
            {
                return null;
            }
            return table.Rows[0];
        }

        public M_UserCate GetUserCateById(int userCateId)
        {
            M_UserCate cate = new M_UserCate();
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserCateId", userCateId) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserCate_GetById", commandParameters);
            if (table.Rows.Count > 0)
            {
                cate.UserId = int.Parse(table.Rows[0]["UserId"].ToString());
                cate.UserCateId = int.Parse(table.Rows[0]["UserCateId"].ToString());
                cate.CateType = int.Parse(table.Rows[0]["ModelType"].ToString());
                cate.CateName = table.Rows[0]["CateName"].ToString();
                cate.Discription = table.Rows[0]["Discription"].ToString();
            }
            return cate;
        }

        public int GetUserCateCount(int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", userId) };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserCate_GetCountByUserId", commandParameters));
        }

        public DataTable GetUserCateList(int userId, int modelType)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@userid", userId), new SqlParameter("@modeltype", modelType) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserCate_GetList", commandParameters);
        }

        public int GetUserCount(int typeId, int groupId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@typeid", typeId), new SqlParameter("@groupid", groupId) };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_User_GetUserCount", commandParameters));
        }

        public DataTable GetUserList(int groupId, int noLoginType, string logName, int typeId, int isLock, string order, int pageIndex, int pageSize, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@groupid", groupId), new SqlParameter("@nologintype", noLoginType), new SqlParameter("@logname", logName), new SqlParameter("@typeid", typeId), new SqlParameter("@islock", isLock), new SqlParameter("@order", order), new SqlParameter("@pageindex", pageIndex), new SqlParameter("@pagesize", pageSize) };
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Users_GetUserList", commandParameters);
            recordCount = Convert.ToInt32(set.Tables[1].Rows[0][0]);
            return set.Tables[0];
        }

        public void InsertResume(int userId, string userName, int unitId, string unitName, int userType, int jobId, int status, DateTime addTime)
        {
            this.SetResume(1, 0, userId, userName, unitId, unitName, userType, jobId, status, addTime);
        }

        public DataTable ListFriendGroup(int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@GroupName", SqlDbType.NVarChar), new SqlParameter("@IsUserId", SqlDbType.Int, 4), new SqlParameter("@GroupId", SqlDbType.Int, 4), new SqlParameter("@Type", SqlDbType.VarChar, 20) };
            commandParameters[0].Value = "";
            commandParameters[1].Value = userId;
            commandParameters[2].Value = 0;
            commandParameters[3].Value = "ListGroup";
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_User_SetFriendGroup", commandParameters);
        }

        public DataTable ListGroupMember(string whereStr, int pageSize, int pageIndex, ref int total)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@WhereStr", SqlDbType.NVarChar, 0x7d0), new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@PageIndex", SqlDbType.Int, 4), new SqlParameter("@Total", SqlDbType.Int, 4) };
            commandParameters[0].Value = whereStr;
            commandParameters[1].Value = pageSize;
            commandParameters[2].Value = pageIndex;
            commandParameters[3].Value = 0;
            commandParameters[3].Direction = ParameterDirection.Output;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_User_ListGroupMember", commandParameters);
            total = (int) commandParameters[3].Value;
            return table;
        }

        public DataSet ListResume(int pageSize, int pageindex, string whereString)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.Int, 4), new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@PageIndex", SqlDbType.Int, 4), new SqlParameter("@WhereStr", SqlDbType.NVarChar, 0x7d0) };
            commandParameters[0].Value = 2;
            commandParameters[1].Value = pageSize;
            commandParameters[2].Value = pageindex;
            commandParameters[3].Value = whereString;
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_HireInfo_Get", commandParameters);
        }

        public bool Login(string logName, string pwd)
        {
            bool flag = false;
            SqlParameter[] commandParameters = new SqlParameter[2];
            commandParameters[0] = new SqlParameter("@LogName", SqlDbType.NVarChar, 20);
            commandParameters[0].Value = logName;
            commandParameters[1] = new SqlParameter("@Pwd", SqlDbType.NVarChar, 200);
            commandParameters[1].Value = pwd;
            if (Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "up_User_Login", commandParameters)) > 0)
            {
                flag = true;
            }
            return flag;
        }

        public void LoginFailError(int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@userid", userId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Users_Login_Error", commandParameters);
        }

        public void LoginFailOnErrorNum(int userId, DateTime errorTime)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@userid", userId), new SqlParameter("@errortime", errorTime) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Users_Login_OnErrorNum", commandParameters);
        }

        public void LoginSuccess(int userId, string loginIp, DateTime loginTime)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@userid", userId), new SqlParameter("@lastloginip", loginIp), new SqlParameter("@lastlogintime", loginTime) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Users_Login_Success", commandParameters);
        }

        public void ModifyOtherBasicInfo(int userId, string email, int groupId, int secret)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@userid", userId), new SqlParameter("@email", email), new SqlParameter("@groupid", groupId), new SqlParameter("@secret", secret) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Users_ModifyOtherBasicInfo", commandParameters);
        }

        public void ModifyPwd(int userId, string pwd)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@userid", userId), new SqlParameter("@pwd", pwd) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Users_ModifyPwd", commandParameters);
        }

        public void ModifyQuestion(int userId, string question, string answer)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@userid", userId), new SqlParameter("@question", question), new SqlParameter("@answer", answer) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Users_ModifyQuestion", commandParameters);
        }

        public int Recharge(int userId, string cardAccount, string cardPwd)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("@CardAccount", SqlDbType.VarChar, 15), new SqlParameter("@CardPwd", SqlDbType.VarChar, 20), new SqlParameter("@Flag", SqlDbType.Int, 4) };
            commandParameters[0].Value = userId;
            commandParameters[1].Value = cardAccount;
            commandParameters[2].Value = cardPwd;
            commandParameters[3].Direction = ParameterDirection.Output;
            commandParameters[3].Value = 0;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "up_User_Recharge", commandParameters);
            return (int) commandParameters[3].Value;
        }

        public DataTable RechargeRecord(int userId, int pageSize, int pageIndex, ref int total)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("PageSize", SqlDbType.Int, 4), new SqlParameter("PageIndex", SqlDbType.Int, 4), new SqlParameter("@PageCount", SqlDbType.Int, 4) };
            commandParameters[0].Value = userId;
            commandParameters[1].Value = pageSize;
            commandParameters[2].Value = pageIndex;
            commandParameters[3].Value = 0;
            commandParameters[3].Direction = ParameterDirection.Output;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_User_RechargeRecord", commandParameters);
            total = (int) commandParameters[3].Value;
            return table;
        }

        public int Reg(M_User model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@logname", model.LogName), new SqlParameter("@userpwd", model.UserPwd), new SqlParameter("@typeid", model.TypeId), new SqlParameter("@email", model.Email), new SqlParameter("@islock", model.IsLock), new SqlParameter("@groupid", model.GroupID), new SqlParameter("@question", model.Question), new SqlParameter("@answer", model.Answer), new SqlParameter("@integral", model.Integral), new SqlParameter("@secret", model.Secret), new SqlParameter("@confirmcode", model.ConfirmRegCode), new SqlParameter("@status", model.Status) };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Users_Add", commandParameters));
        }

        public void SetFriend(int Id, OperateType type)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int, 4), new SqlParameter("@IsDisable", SqlDbType.Int, 4) };
            commandParameters[0].Value = Id;
            commandParameters[1].Value = (type == OperateType.Disable) ? 2 : 1;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_User_SetFriend", commandParameters);
        }

        private void SetResume(int type, int id, int userId, string userName, int unitId, string unitName, int userType, int jobId, int status, DateTime addTime)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Type", type), new SqlParameter("@Id", id), new SqlParameter("@UserId", userId), new SqlParameter("@UserName", userName), new SqlParameter("@UnitId", unitId), new SqlParameter("@UnitName", unitName), new SqlParameter("@UserType", userType), new SqlParameter("@Status", status), new SqlParameter("@AddTime", addTime), new SqlParameter("@JobId", jobId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_HireInfo_Set", commandParameters);
        }

        public void SetUserLockStatus(int userId, bool lockStatus)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@userid", userId), new SqlParameter("@lockstatus", lockStatus) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Users_SetLockStatus", commandParameters);
        }

        public void UpdateFriendGroup(int groupId, string newName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@GroupName", SqlDbType.NVarChar), new SqlParameter("@IsUserId", SqlDbType.Int, 4), new SqlParameter("@GroupId", SqlDbType.Int, 4), new SqlParameter("@Type", SqlDbType.VarChar, 20) };
            commandParameters[0].Value = newName;
            commandParameters[1].Value = 0;
            commandParameters[2].Value = groupId;
            commandParameters[3].Value = "Update";
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_User_SetFriendGroup", commandParameters);
        }

        public void UpdateRegCode(int userId, string newCode)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("@NewCode", SqlDbType.VarChar, 50) };
            commandParameters[0].Value = userId;
            commandParameters[1].Value = newCode;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_User_UpdateRegCode", commandParameters);
        }

        public void UpdateResume(int id, int status)
        {
            this.SetResume(2, id, 0, "", 0, "", 0, 0, status, DateTime.Now);
        }

        public void UpdateUserCate(M_UserCate model)
        {
            this.AddUserCate(model);
        }

        public void UpdateUserStatus(int userId, int status)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@userId", userId), new SqlParameter("@status", status) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Users_SetStatus", commandParameters);
        }

        public DataTable ViewResume(string whereString)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Type", 1), new SqlParameter("@PageSize", SqlDbType.BigInt), new SqlParameter("@PageIndex", SqlDbType.BigInt), new SqlParameter("@WhereStr", whereString) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_HireInfo_Get", commandParameters);
        }
    }
}

