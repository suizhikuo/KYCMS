namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_AdCategory
    {
        private IAdCategory dal = DataAccess.CreateAdCategory();

        public void Add(M_AdCategory model)
        {
            this.dal.Add(model);
        }

        public void Delete(int AdCategoryId)
        {
            this.dal.Delete(AdCategoryId);
            B_Log.Add(LogType.Delete, "删除广告位成功.编号:" + AdCategoryId);
        }

        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return this.dal.GetList(PageSize, PageIndex, strWhere);
        }

        public M_AdCategory GetModel(int AdCategoryId)
        {
            return this.dal.GetModel(AdCategoryId);
        }

        public void Update(M_AdCategory model)
        {
            this.dal.Update(model);
        }
    }
}

