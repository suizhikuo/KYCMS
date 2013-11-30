namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IAnomaly
    {
        bool Add(M_Anomaly model);
        bool CheckHas(int chId, int infoId);
        void Delete(int id);
        DataTable GetList(int chId, int pageIndex, int pageSize, ref int recordCount);
    }
}

