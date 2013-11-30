namespace Ky.BLL
{
    using Ky.DALFactory;
    using System;
    using System.Data;

    public class B_Group
    {
        private IGroup ig = DataAccess.CreateGroup();

        public int Delete(int id)
        {
            return this.ig.Delete(id);
        }

        public int GetAdminGroupUserCount(int groupId)
        {
            return this.ig.GetAdminGroupUserCount(groupId);
        }

        public DataTable GetAdminList()
        {
            return this.ig.GetAdminGroupList();
        }
    }
}

