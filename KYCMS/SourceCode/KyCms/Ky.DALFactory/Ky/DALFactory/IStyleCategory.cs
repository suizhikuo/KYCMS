namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IStyleCategory
    {
        void Add(M_StyleCategory model);
        void Delete(int styleCategoryId);
        DataTable GetListItemByStyleId();
        DataTable GetStyleCategoryList();
        M_StyleCategory GetUpdateData(int styleCategoryId);
        void Update(M_StyleCategory model);
    }
}

