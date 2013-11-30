namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IUserLog
    {
        void Add(M_UserLog model);
        bool CheckIsPay(int checkPayType, int modelType, int infoId, int userId, int hourCount, int viewCount);
        DataTable ListLog(string whereStr, int pageSize, int pageIndex, ref int total);
        bool ReducePoint(int userId, int point);
    }
}

