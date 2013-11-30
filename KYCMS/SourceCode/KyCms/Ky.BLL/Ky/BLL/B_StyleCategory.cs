namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_StyleCategory
    {
        private IStyleCategory istylecategory = DataAccess.CreateStyleCategory();

        public void Add(M_StyleCategory model)
        {
            this.istylecategory.Add(model);
        }

        public void Delete(int styleCategoryId)
        {
            this.istylecategory.Delete(styleCategoryId);
        }

        public DataTable GetListItemByStyleId()
        {
            return this.istylecategory.GetListItemByStyleId();
        }

        public DataTable GetStyleCategoryList()
        {
            return this.istylecategory.GetStyleCategoryList();
        }

        public M_StyleCategory GetUpdateData(int styleCategoryId)
        {
            return this.istylecategory.GetUpdateData(styleCategoryId);
        }

        public void Update(M_StyleCategory model)
        {
            this.istylecategory.Update(model);
        }
    }
}

