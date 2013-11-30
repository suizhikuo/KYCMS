namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IUserGroupModelField
    {
        void Add(M_UserGroupModelField model);
        void Del(int FieldId);
        DataTable GetIsUserList(int ModelId);
        DataTable GetList(int ModelId);
        M_UserGroupModelField GetModel(int FieldId);
        M_UserGroupModelField GetModel(int ModelId, string Name);
        DataTable GetSelectPropertyTrue(int ModelId);
        DataTable GetTitleList(int ModelId);
        void MoveField(int CustomFormId, int FieldId, string MoveType);
        void Update(M_UserGroupModelField model);
    }
}

