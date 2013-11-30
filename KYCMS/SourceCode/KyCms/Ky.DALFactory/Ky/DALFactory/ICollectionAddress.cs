namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface ICollectionAddress
    {
        void Add(M_CollectionAddress model);
        bool DeleteCollId(int collid, bool state);
        DataTable GetCollIdByCollAddress(int CollId);
        DataTable GetCollIdByList(int collid, bool state, int pageIndex, int pageSize, ref int recordCount);
        bool IsCheckAddress(string address);
        void UpdateState(string address);
    }
}

