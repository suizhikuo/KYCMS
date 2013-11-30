namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface ISinglePage
    {
        int Add(M_SinglePage model);
        void Delete(int SingleId);
        DataSet GetList(int currPage, int pageSize);
        M_SinglePage GetModel(int SingleId);
        void Update(M_SinglePage model);
    }
}

