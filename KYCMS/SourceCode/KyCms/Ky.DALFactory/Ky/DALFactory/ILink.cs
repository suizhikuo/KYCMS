namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface ILink
    {
        void Add(M_Link model);
        DataSet GetList(int PageSize, int PageIndex, string whereString);
        M_Link GetModel(int LinkId);
        void Set(int LinkId, int Type);
        void Update(M_Link model);
    }
}

