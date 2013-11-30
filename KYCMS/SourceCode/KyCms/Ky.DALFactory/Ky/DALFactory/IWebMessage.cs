namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IWebMessage
    {
        void Delete(int WMId);
        DataTable GetList(string WhereStr);
        DataSet GetList(int currPage, int pageSize, string WhereStr);
        void Insert(M_WebMessage model);
        M_WebMessage Show(int WMId, int UserId);
        void UpdateDel(int WMId, int UserId, int DelTypeId);
    }
}

