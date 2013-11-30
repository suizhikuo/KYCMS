namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_CollectionAddress
    {
        private ICollectionAddress dal = DataAccess.CreateCollectionAddress();

        public void Add(M_CollectionAddress model)
        {
            this.dal.Add(model);
        }

        public bool DeleteCollId(int collid, bool state)
        {
            return this.dal.DeleteCollId(collid, state);
        }

        public DataTable GetCollIdByCollAddress(int collId)
        {
            return this.dal.GetCollIdByCollAddress(collId);
        }

        public DataTable GetCollIdByList(int collid, bool state, int pageIndex, int pageSize, ref int recordCount)
        {
            return this.dal.GetCollIdByList(collid, state, pageIndex, pageSize, ref recordCount);
        }

        public bool IsCheckAddress(string address)
        {
            return this.dal.IsCheckAddress(address);
        }

        public void UpdateSate(string address)
        {
            this.dal.UpdateState(address);
        }
    }
}

