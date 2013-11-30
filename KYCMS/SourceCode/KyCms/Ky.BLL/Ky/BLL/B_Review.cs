namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_Review
    {
        private IReview iReview = DataAccess.CreateReview();

        public bool Add(M_Review model)
        {
            return this.iReview.Add(model);
        }

        public void DelReview(int id)
        {
            this.iReview.DelReview(id);
        }

        public void DelReviewByInfoId(int modelType, int infoId)
        {
            this.iReview.DelReviewByInfoId(modelType, infoId);
        }

        public DataTable GetList(int modelType, int newsId, bool isCheck)
        {
            return this.iReview.GetList(modelType, newsId, isCheck);
        }

        public M_Review GetModel(int id)
        {
            return this.GetModel(id);
        }

        public DataSet ManageList(string tableName, int modelType, int pageIndex, int pageSize, bool isCheck)
        {
            return this.iReview.ManageList(tableName, modelType, pageIndex, pageSize, isCheck);
        }

        public DataSet ReviewList(int currPage, int pageSize, string StrWhere)
        {
            return this.iReview.ReviewList(currPage, pageSize, StrWhere);
        }

        public void UpdateIsCheck(int id)
        {
            this.iReview.UpdateIsCheck(id);
        }
    }
}

