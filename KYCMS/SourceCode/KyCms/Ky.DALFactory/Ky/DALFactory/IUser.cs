using Ky.Model;
using System;
using System.Data;
namespace Ky.DALFactory
{

    public interface IUser
    {
        int AddFriend(int userId, string friendName, int groupId);
        void AddFriendGroup(string groupName, int isUserId);
        void AddUserCate(M_UserCate model);
        bool CheckMultiIdentity(string input, string tabelName, string filedName);
        int CountFriendGroupMember(int groupId, int userId);
        void Delete(int userId);
        void DeleteFriend(int Id);
        void DeleteFriendGroup(int groupId);
        void DeleteResume(int id);
        void DeleteUserCate(int userCateId);
        M_User GetUser(string identity, int type);
        DataRow GetUserAllInfo(int UserId);
        M_UserCate GetUserCateById(int UserCateId);
        int GetUserCateCount(int userId);
        DataTable GetUserCateList(int userId, int modelType);
        int GetUserCount(int typeId, int groupId);
        DataTable GetUserList(int groupId, int noLoginType, string logName, int typeId, int isLock, string order, int pageIndex, int pageSize, ref int recordCount);
        void InsertResume(int userId, string userName, int unitId, string unitName, int userType, int jobId, int status, DateTime addTime);
        DataTable ListFriendGroup(int userId);
        DataTable ListGroupMember(string whereStr, int pageSize, int pageIndex, ref int total);
        DataSet ListResume(int pageSize, int pageindex, string whereString);
        bool Login(string logName, string pwd);
        void LoginFailError(int userId);
        void LoginFailOnErrorNum(int userId, DateTime errorTime);
        void LoginSuccess(int userId, string loginIp, DateTime loginTime);
        void ModifyOtherBasicInfo(int userId, string email, int groupId, int secret);
        void ModifyPwd(int userId, string pwd);
        void ModifyQuestion(int userId, string question, string answer);
        int Recharge(int userId, string cardAccount, string cardPwd);
        DataTable RechargeRecord(int userId, int pageSize, int pageIndex, ref int total);
        int Reg(M_User model);
        void SetFriend(int Id, OperateType type);
        void SetUserLockStatus(int userId, bool lockStatus);
        void UpdateFriendGroup(int groupId, string newName);
        void UpdateRegCode(int userId, string newCode);
        void UpdateResume(int id, int status);
        void UpdateUserCate(M_UserCate model);
        void UpdateUserStatus(int userId, int status);
        DataTable ViewResume(string whereString);
    }
}

