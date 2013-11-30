namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_Link
    {
        private readonly ILink dal = DataAccess.CreateLink();

        public void Add(M_Link model)
        {
            this.dal.Add(model);
        }

        public DataSet GetList(int pageSize, int pageIndex, string whereString)
        {
            return this.dal.GetList(pageSize, pageIndex, whereString);
        }

        public M_Link GetModel(int LinkId)
        {
            return this.dal.GetModel(LinkId);
        }

        public void Set(int LinkId, int Type)
        {
            this.dal.Set(LinkId, Type);
        }

        public void Update(M_Link model)
        {
            this.dal.Update(model);
        }
    }
}

