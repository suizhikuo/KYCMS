namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IAd
    {
        void Add(M_Ad model);
        void Delete(int AdId);
        DataSet GetList(int PageSize, int PageIndex, string strWhere);
        M_Ad GetModel(int AdId);
        void Update(M_Ad model);
    }
}

