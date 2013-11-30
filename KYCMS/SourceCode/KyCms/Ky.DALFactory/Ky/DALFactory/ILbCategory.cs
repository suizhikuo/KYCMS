namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface ILbCategory
    {
        int Add(M_LbCategory model);
        void Delete(int lbCategoryId);
        M_LbCategory GetLabeCategoryIdData(int lbCategoryId);
        DataTable GetLabelCategoryList(int parentId);
        DataTable GetListItemLabelId();
        void Update(M_LbCategory model);
    }
}

