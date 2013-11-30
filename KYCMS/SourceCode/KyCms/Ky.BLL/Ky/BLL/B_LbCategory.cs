namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_LbCategory
    {
        private ILbCategory ilbcategory = DataAccess.CareateLbCategory();

        public int Add(M_LbCategory model)
        {
            return this.ilbcategory.Add(model);
        }

        public void Delete(int lbCategoryId)
        {
            this.ilbcategory.Delete(lbCategoryId);
        }

        public M_LbCategory GetLabeCategoryIdData(int lbCategoryId)
        {
            return this.ilbcategory.GetLabeCategoryIdData(lbCategoryId);
        }

        public DataTable GetLabelCategoryList(int parentId)
        {
            return this.ilbcategory.GetLabelCategoryList(parentId);
        }

        public DataTable GetListItemByLabelId()
        {
            return this.ilbcategory.GetListItemLabelId();
        }

        public void Update(M_LbCategory model)
        {
            this.ilbcategory.Update(model);
        }
    }
}

