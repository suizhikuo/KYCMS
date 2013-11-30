namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IDictionary
    {
        int Add(M_Dictionary model);
        int Delete(int id);
        DataSet GetList(int pageSize, int pageIndex, string whereStr);
        M_Dictionary GetModel(int id);
        int Update(M_Dictionary model);
    }
}

