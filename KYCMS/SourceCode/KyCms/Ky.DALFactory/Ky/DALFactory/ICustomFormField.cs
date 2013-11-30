namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface ICustomFormField
    {
        void Add(M_CustomFormField model);
        void Del(int FieldId);
        DataTable GetIsUserList(int CustomFormId);
        DataTable GetList(int CustomFormId);
        M_CustomFormField GetModel(int FieldId);
        M_CustomFormField GetModel(int CustomFormId, string Name);
        DataTable GetSelectPropertyTrue(int CustomFormId);
        DataTable GetTitleList(int CustomFormId);
        void MoveField(int CustomFormId, int FieldId, string MoveType);
        void Update(M_CustomFormField model);
    }
}

