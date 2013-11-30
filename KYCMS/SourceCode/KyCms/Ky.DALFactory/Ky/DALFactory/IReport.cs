namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IReport
    {
        void Add(M_Report model);
        void Delete(int reportId);
        DataSet GetList(int pageIndex, int pageSize, string whereStr);
        void SetStatus(int reportId, int status);
    }
}

