namespace Ky.DALFactory
{
    using System;
    using System.Data;

    public interface ICreate
    {
        DataTable GetArticle_HeadeList(int infoCount, int colid, bool isImg);
        DataTable GetChannel_Column_InfoList(int chId, int colCount, string colIdStr);
        DataTable GetChannel_InfoList(string tableName, int infoCount, int chid, string typeStr, string dateStr, string orderStr);
        int GetChannel_SpecialInfoCount(string tableName, int infoCount, string specialIdStr, string dateStr);
        DataTable GetChannel_SpecialInfoList(string tableName, int infoCount, string specialIdStr, string dateStr, string orderStr);
        DataRow GetCloseInfo(string tableName, int id, int colid, string direct);
        DataTable GetColumn_ChildCol_InfoList(int colId, int colCount);
        int GetColumn_FinallyInfoCount(string tableName, string colIdstr, string dateStr);
        DataTable GetColumn_FinallyInfoList(string tableName, string colIdStr, string dateStr, string orderStr, bool isPadding, int pageIndex, int pageSize);
        DataTable GetColumn_FlashInfoList(string tableName, int chId, string colIdStr, int infoCount);
        DataTable GetColumn_InfoList(string tableName, int infoCount, string colIdStr, string typeStr, string dateStr, string orderStr);
        DataTable GetColumnAll(string tableName, string colId, int pageIndex, int pageSize);
        DataTable GetDateRange(string tableName, string startDate, string endDate, int pageIndex, int pageSize);
        int GetDigCount(int modelId, int infoId);
        DataTable GetField_InfoList(int modelType, string tableName, int chId, int colId, string fieldName, string keyword, int pageIndex, int pageSize, ref int recordCount);
        DataTable GetIdRange(string tableName, int startId, int endId, int pageIndex, int pageSize);
        DataTable GetInfo(string tableName, int cursorPage, int pageSize);
        DataTable GetInfo_RelationInfoList(string tableName, int infoCount, string whereStr);
        DataRow GetInfoById(string tableName, int Id);
        DataSet GetIrregularr(string tableName, int chId, int pageIndex, int pageSize);
        DataTable GetNewRecordNum(string tableName, int topNum, int pageIndex, int pageSize);
        int GetSite_SpecialInfoCount(string tableNameStr, int infoCount, string specialIdStr, string dateStr);
        DataTable GetSite_SpecialInfoList(string tableNameStr, int infoCount, string specialIdStr, string dateStr, string orderStr);
        void InfoRecordCount(string tableName, string wheStr, ref int recordCount);
        int LastInfoCount(string tableName, int topNum);
        void SetDigCount(int modelId, int infoId);
    }
}

