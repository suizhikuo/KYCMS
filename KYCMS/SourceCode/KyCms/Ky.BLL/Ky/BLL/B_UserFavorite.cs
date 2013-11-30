namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_UserFavorite
    {
        private IUserFavorite dal = DataAccess.CreateUserFavorite();

        public void Add(M_UserFavorite model)
        {
            this.dal.Add(model);
        }

        public void Delete(int id)
        {
            this.dal.Delete(id);
        }

        public DataSet GetList(int currPage, int pageSize, string WhereStr)
        {
            return this.dal.GetList(currPage, pageSize, WhereStr);
        }
    }
}

