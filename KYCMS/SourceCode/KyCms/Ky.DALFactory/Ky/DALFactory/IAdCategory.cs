namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IAdCategory
    {
        void Add(M_AdCategory model);
        void Delete(int AdCategoryId);
        DataSet GetList(int PageSize, int PageIndex, string strWhere);
        M_AdCategory GetModel(int AdCategoryId);
        void Update(M_AdCategory model);
    }
}

