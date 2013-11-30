namespace Ky.BLL
{
    using Ky.Common;
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Web;

    public class B_User
    {
        private IUser iu = DataAccess.CreateUser();

        public void AddCmdUserIntegral(int recmd_uid)
        {
            M_User user = new B_User().GetUser(recmd_uid);
            B_Money money = new B_Money();
            if (user != null)
            {
                B_UserGroup group = new B_UserGroup();
                int num = int.Parse(group.Power_UserGroup("Invite", 0, group.GetModel(user.GroupID).GroupPower));
                money.Integral(num, recmd_uid);
            }
        }

        public int AddFriend(int userId, string friendName, int groupId)
        {
            return this.iu.AddFriend(userId, friendName, groupId);
        }

        public void AddFriendGroup(string groupName, int isUserId)
        {
            this.iu.AddFriendGroup(groupName, isUserId);
        }

        public void AddUserCate(M_UserCate model)
        {
            this.iu.AddUserCate(model);
        }

        public void CheckIsLogin()
        {
            if (!this.IsLogin())
            {
                HttpContext.Current.Response.Redirect(Param.ApplicationRootPath + "/user/Login.aspx?ReturnUrl=" + Ky.Common.Function.UrlEncode(HttpContext.Current.Request.Url.ToString()));
            }
        }

        public bool CheckMultiIdentity(string input, string tabelName, string filedName)
        {
            return this.iu.CheckMultiIdentity(input, tabelName, filedName);
        }

        public int CountFriendGroupMember(int groupId, int userId)
        {
            return this.iu.CountFriendGroupMember(groupId, userId);
        }

        public void Delete(int userId)
        {
            string logName = this.GetUser(userId).LogName;
            this.iu.Delete(userId);
            new B_BBSUser().Delete(logName);
            B_Log.Add(LogType.Delete, "删除用户成功 被删用户编号：" + userId);
        }

        public void DeleteFriend(int Id)
        {
            this.iu.DeleteFriend(Id);
        }

        public void DeleteFriendGroup(int groupId)
        {
            this.iu.DeleteFriendGroup(groupId);
        }

        public void DeleteResume(int id)
        {
            this.iu.DeleteResume(id);
        }

        public void DeleteUserCate(int userCateId)
        {
            this.iu.DeleteUserCate(userCateId);
        }

        public void ExpireCookie()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["User"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Parse("1900-01-01");
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public M_User GetCookie()
        {
            this.CheckIsLogin();
            HttpCookie cookie = HttpContext.Current.Request.Cookies["User"];
            M_User user = new M_User();
            user.UserPwd = cookie["pd"].ToString();
            user.LogName = Ky.Common.Function.UrlDecode(cookie["logN"].ToString());
            try
            {
                user.UserID = int.Parse(cookie["uId"].ToString());
            }
            catch
            {
                user.UserID = 0;
            }
            return user;
        }

        public M_User GetUser(int userId)
        {
            return this.iu.GetUser(userId.ToString(), 1);
        }

        public M_User GetUser(string logName)
        {
            return this.iu.GetUser(logName, 0);
        }

        public DataRow GetUserAllInfo(int userId)
        {
            return this.iu.GetUserAllInfo(userId);
        }

        public M_UserCate GetUserCateById(int userCateId)
        {
            return this.iu.GetUserCateById(userCateId);
        }

        public int GetUserCateCount(int userId)
        {
            return this.iu.GetUserCateCount(userId);
        }

        public DataTable GetUserCateList(int userId, int modelType)
        {
            return this.iu.GetUserCateList(userId, modelType);
        }

        public int GetUserCount(int typeId, int groupId)
        {
            return this.iu.GetUserCount(typeId, groupId);
        }

        public DataTable GetUserList(int groupId, int noLoginType, string logName, int typeId, int isLock, string order, int pageIndex, int pageSize, ref int recordCount)
        {
            if (logName.Length != 0)
            {
                logName = "%" + logName + "%";
            }
            return this.iu.GetUserList(groupId, noLoginType, logName, typeId, isLock, order, pageIndex, pageSize, ref recordCount);
        }

        public void InsertResume(int userId, string userName, int unitId, string unitName, int userType, int jobId, int status, DateTime addTime)
        {
            this.iu.InsertResume(userId, userName, unitId, unitName, userType, jobId, status, addTime);
        }

        public bool IsLogin()
        {
            B_User user = new B_User();
            if (HttpContext.Current.Request.Cookies["User"] == null)
            {
                return false;
            }
            string logName = string.Empty;
            string str2 = string.Empty;
            if (HttpContext.Current.Request.Cookies["User"]["logN"] != null)
            {
                logName = Ky.Common.Function.UrlDecode(HttpContext.Current.Request.Cookies["User"]["logN"]);
            }
            if (HttpContext.Current.Request.Cookies["User"]["pd"] != null)
            {
                str2 = Ky.Common.Function.UrlDecode(HttpContext.Current.Request.Cookies["User"]["pd"]);
            }
            if ((logName == string.Empty) || (str2 == string.Empty))
            {
                return false;
            }
            M_User user2 = null;
            user2 = user.GetUser(logName);
            if ((user2 == null) || (user2.UserPwd != str2))
            {
                return false;
            }
            return true;
        }

        public DataTable ListFriendGroup(int userId)
        {
            return this.iu.ListFriendGroup(userId);
        }

        public DataTable ListGroupMember(string whereStr, int pageSize, int pageIndex, ref int total)
        {
            return this.iu.ListGroupMember(whereStr, pageSize, pageIndex, ref total);
        }

        public DataSet ListResume(int pageSize, int pageindex, string whereString)
        {
            return this.iu.ListResume(pageSize, pageindex, whereString);
        }

        public bool Login(string logName, string pwd)
        {
            string str = Ky.Common.Function.MD5Encrypt(pwd);
            string loginValidateType = B_ConfigModule.GetConfig(Param.SiteRootPath + @"\" + Param.ConfDirName + @"\Config.config").LoginValidateType;
            switch (loginValidateType)
            {
                case "16":
                case "32":
                {
                    string str4 = str;
                    if (loginValidateType == "16")
                    {
                        str4 = str.Substring(8, 16);
                    }
                    return this.iu.Login(logName, str4);
                }
            }
            string str5 = str.Substring(8, 16);
            return (this.iu.Login(logName, str) || this.iu.Login(logName, str5));
        }

        public void LoginFailError(int userId)
        {
            this.iu.LoginFailError(userId);
        }

        public void LoginFailOnErrorNum(int userId, DateTime errorTime)
        {
            this.iu.LoginFailOnErrorNum(userId, errorTime);
        }

        public void LoginSuccess(int userId, string loginIp, DateTime loginTime)
        {
            this.iu.LoginSuccess(userId, loginIp, loginTime);
        }

        public void ModifyOtherBasicInfo(int userId, string email, int groupId, int secret)
        {
            this.iu.ModifyOtherBasicInfo(userId, email, groupId, secret);
        }

        public void ModifyPwd(int userId, string pwd)
        {
            this.iu.ModifyPwd(userId, pwd);
        }

        public void ModifyQuestion(int userId, string question, string answer)
        {
            this.iu.ModifyQuestion(userId, question, answer);
        }

        public int Recharge(int userId, string cardAccount, string cardPwd)
        {
            return this.iu.Recharge(userId, cardAccount, cardPwd);
        }

        public DataTable RechargeRecord(int userId, int pageSize, int pageIndex, ref int total)
        {
            return this.iu.RechargeRecord(userId, pageSize, pageIndex, ref total);
        }

        public int Reg(M_User model)
        {
            return this.iu.Reg(model);
        }

        public void SetFriend(int Id, OperateType type)
        {
            this.iu.SetFriend(Id, type);
        }

        public void SetUserLockStatus(int userId, bool lockStatus)
        {
            this.iu.SetUserLockStatus(userId, lockStatus);
        }

        public void UpdateFriendGroup(int groupId, string newName)
        {
            this.iu.UpdateFriendGroup(groupId, newName);
        }

        public void UpdateRegCode(int userId, string newCode)
        {
            this.iu.UpdateRegCode(userId, newCode);
        }

        public void UpdateResume(int id, int status)
        {
            this.iu.UpdateResume(id, status);
        }

        public void UpdateUserCate(M_UserCate model)
        {
            this.iu.UpdateUserCate(model);
        }

        public void UpdateUserStatus(int userId, int status)
        {
            this.iu.UpdateUserStatus(userId, status);
        }

        public DataTable ViewResume(string whereString)
        {
            return this.iu.ViewResume(whereString);
        }
    }
}

