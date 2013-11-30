namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IUserGroup
    {
        void Add(M_UserGroup model);
        void Delete(int UserGroupId);
        DataSet GetList(int currPage, int pageSize, string WhereStr);
        M_UserGroup GetModel(int UserGroupId);
        DataTable ManageList(string StrWhere);
        void Update(M_UserGroup model);
    }
}

