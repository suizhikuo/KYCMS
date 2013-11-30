namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface ICollection
    {
        void Add(M_Collection collectionM);
        void CollectionData(string tableName, string fieldName, string fieldValue);
        void Delete(int id);
        M_Collection GetIdByCollection(int id);
        DataTable GetList();
        void Update(M_Collection collectionM);
    }
}

