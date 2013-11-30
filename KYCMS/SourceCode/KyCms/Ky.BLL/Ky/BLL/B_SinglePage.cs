namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_SinglePage
    {
        private ISinglePage dal = DataAccess.CreateSinglePage();

        public int Add(M_SinglePage model)
        {
            return this.dal.Add(model);
        }

        public void Delete(int SingleId)
        {
            this.dal.Delete(SingleId);
        }

        public DataSet GetList(int currPage, int pageSize)
        {
            return this.dal.GetList(currPage, pageSize);
        }

        public M_SinglePage GetModel(int SingleId)
        {
            return this.dal.GetModel(SingleId);
        }

        public void Update(M_SinglePage model)
        {
            this.dal.Update(model);
        }
    }
}

