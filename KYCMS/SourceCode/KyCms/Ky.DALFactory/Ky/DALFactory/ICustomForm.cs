namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface ICustomForm
    {
        void Add(M_CustomForm model);
        void AddTable(string TableName);
        void Delete(int CustomFormId);
        DataTable GetAll();
        DataTable GetFormSubmitNum(string TableName, int UId);
        M_CustomForm GetModel(int CustomFormId);
        void Update(M_CustomForm model);
    }
}

