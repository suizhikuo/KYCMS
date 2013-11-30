namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_Anomaly
    {
        private IAnomaly dal = DataAccess.CreateAnomaly();

        public bool Add(M_Anomaly model)
        {
            return this.dal.Add(model);
        }

        public bool CheckHas(int chId, int infoId)
        {
            return this.dal.CheckHas(chId, infoId);
        }

        public void Delete(int id)
        {
            this.dal.Delete(id);
        }

        public DataTable GetList(int chid, int pageIndex, int pageSize, ref int recordCount)
        {
            return this.dal.GetList(chid, pageIndex, pageSize, ref recordCount);
        }
    }
}

