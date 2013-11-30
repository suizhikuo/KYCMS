namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IEnterprise
    {
        void AddEnterPrise(M_Enterprise model);
        void DeleteEnterprise(string idStr, int userId);
        M_Enterprise GetEnterpriseById(int Id, int userId);
        DataTable GetEnterpriseByUserId(int userId, int pageIndex, int pageSize, ref int recordCount);
        void UpdateEnterPrise(M_Enterprise model);
    }
}

