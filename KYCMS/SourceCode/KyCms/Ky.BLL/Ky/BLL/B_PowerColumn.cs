namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;

    public class B_PowerColumn
    {
        private IPowerColumn dal = DataAccess.CreatePowerColumn();

        public M_PowerColumn GetModel(int id)
        {
            return this.dal.GetModel(id);
        }
    }
}

