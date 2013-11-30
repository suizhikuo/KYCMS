namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IModelField
    {
        void Add(M_ModelField model);
        void AddField(string TableName, string FieldName, string FieldType, string DefaultValue);
        void Del(int FieldId);
        void DelField(string TableName, string FieldName);
        DataTable GetAllTable();
        DataTable GetList(int ModelId);
        M_ModelField GetModel(int FieldId);
        DataTable GetSearchField(int modelId);
        DataTable GetSelectPropertyTrue(int ModelId);
        DataTable GetTableAllField(string TableName);
        DataTable GetTableAllFieldAndType(string TbleName);
        bool IsNotField(string TableName, string FieldName);
        void MoveField(int ModelId, int FieldId, string MoveType);
        void Update(M_ModelField model);
        void UpdateFieldDefault(string TableName, string FieldName, string DefaultValue);
    }
}

