namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface INotice
    {
        void Del(int NoticeId);
        DataSet GetList(int currPage, int pageSize, string WhereStr);
        DataTable GetTop(int TopValue);
        void Insert(M_Notice model);
        DataTable Manage(int TypeId);
        M_Notice Show(int NoticeId);
        void Update(M_Notice model);
        void UpdateIsState(int NoticeId);
    }
}

