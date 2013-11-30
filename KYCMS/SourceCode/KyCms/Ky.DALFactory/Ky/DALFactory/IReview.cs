namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IReview
    {
        bool Add(M_Review model);
        void DelReview(int id);
        void DelReviewByInfoId(int modelType, int infoId);
        DataTable GetList(int modelType, int infoId, bool isCheck);
        M_Review GetModel(int id);
        DataSet ManageList(string tableName, int modelType, int pageIndex, int pageSize, bool isCheck);
        DataSet ReviewList(int currPage, int pageSize, string StrWhere);
        void UpdateIsCheck(int id);
    }
}

