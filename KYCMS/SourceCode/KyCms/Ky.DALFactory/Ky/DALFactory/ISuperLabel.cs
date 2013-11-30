namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface ISuperLabel
    {
        void Add(M_SuperLabel model);
        int CheckName(string Name);
        DataTable CheckSql(string sql);
        DataTable DataBaseTypeSql(string LinkPath, string DataBaseType, string sql);
        void Delete(int SuperId);
        DataSet GetList(int currPage, int pageSize);
        M_SuperLabel GetModel(int SuperId);
        int GetSuperId(string Name);
        bool IsModelTable(string TableName);
        DataSet SuperLabelOut(string InSuperId);
        void Update(M_SuperLabel model);
    }
}

