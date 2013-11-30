namespace Ky.DALFactory
{
    using System;
    using System.Data;

    public interface IInfoOper
    {
        void AddHitCount(string tableName, int id);
        void Auditing(string tableName, int id, int status, int adiminId, string adminName);
        void Cancel(string tableName, int id);
        void CompleteDeleteInfo(string tableName, int id);
        void DeleteInfoToRecycle(string idStr, string tableName);
        DataSet GetCustomTableList(string TableName, int currPage, int pageSize, string strWhere);
        int GetHitCount(string tableName, int id);
        DataRow GetInfo(string tableName, int id);
        DataTable GetInfoList(string tableName, string fieldName, string keyword, int chId, string colIdStr, string status, string property, string propertyType, string propertyValue, int userType, int pageIndex, int pageSize, ref int recordCount);
        DataTable GetRecycleInfoList(string tableName, int type, int pageIndex, int pageSize, ref int recordCount);
        DataTable GetRssInfoList(string tableName, int chId, string colId);
        DataTable GetSpecialInfoList(string tableNameStr, int specialId);
        DataRow GetUserInfo(string tableName, int UserId);
        DataTable GetUserInfoList(string tableName, int uId, string fieldName, string keyword, int chId, string colIdStr, string status, string property, string propertyType, string propertyValue, int userCateId, int pageIndex, int pageSize, ref int recordCount);
        bool IsExistsInfoByUserId(string tableName, int userId);
        void MassMoveInfo(string tableName, string idStr, int colid, int targetColId);
        void MassSetInfo(string tableName, string idStr, int colId, bool tagFlag, string tagIdStr, string tagNameStr, bool topFlag, bool isTop, bool recommendFlag, bool isRecommend, bool focusFlag, bool isFocus, bool templatePathFlag, string templatePath, bool hitCountFlag, int hitCount, bool isOpenedFlag, int isOpened, bool groupIdStrFlag, string groupIdStr, bool pointCountFlag, int pointCount, bool chargeTypeFlag, int chargeType, bool chargeHourCountFlag, int chargeHourCount, bool chargeViewCountFlag, int chargeViewCount, bool pageTypeFlag, int pageType);
        void RestoreRecycle(string tableName, int type, int id);
        void SetInfoSpecial(string tableName, int id, string specialIdStr);
        void SetProperty(string tableName, string property, string propertyValue, int id);
        void SetPublish(string tableName, int id, int uId);
        void UpdateIsCreated(string tableName, int id);
        void UserDeleteInfo(string idStr, string tableName, int uId);
    }
}

