namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IUserGroupModel
    {
        int Add(M_UserGroupModel model);
        void AddTable(string TableName);
        void Delete(int CustomFormId);
        DataTable GetAll();
        M_UserGroupModel GetModel(int Id);
        DataTable GetTextType(int ModelId);
        void Update(M_UserGroupModel model);
        void UpdateModelHtml(M_UserGroupModel model);
        void UpdateUserGroupId(int Id, int UserGroupId);
    }
}

