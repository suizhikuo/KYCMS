namespace Ky.DALFactory
{
    using System;
    using System.Data;

    public interface IGroup
    {
        int Delete(int id);
        DataTable GetAdminGroupList();
        int GetAdminGroupUserCount(int groupId);
    }
}

