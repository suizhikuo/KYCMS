namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;
    using System.ComponentModel;

    public interface ITagCategory
    {
        void Add(M_TagCategory model);
        void Delete(int tagCategoryId);
        DataTable GetList();
        void Update(M_TagCategory model);
    }
}

