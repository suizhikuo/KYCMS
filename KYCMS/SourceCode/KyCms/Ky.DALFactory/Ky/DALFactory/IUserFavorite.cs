namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IUserFavorite
    {
        void Add(M_UserFavorite model);
        void Delete(int id);
        DataSet GetList(int currPage, int pageSize, string WhereStr);
    }
}

