namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_Superior
    {
        private ISuperior dal = DataAccess.CreateSuperior();

        public void Add(M_Superior model)
        {
            this.dal.Add(model);
        }

        public void Delete(int id)
        {
            this.dal.Delete(id);
        }

        public M_Superior GetIdBySuperior(int id)
        {
            return this.dal.GetIdBySuperior(id);
        }

        public DataTable GetList()
        {
            return this.dal.GetList();
        }

        public void Update(M_Superior model)
        {
            this.dal.Update(model);
        }
    }
}

