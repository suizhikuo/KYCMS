namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IAdmin
    {
        bool Add(M_Admin model);
        void Delete(int id);
        DataTable GetAdminByGroupID(int goupID);
        DataTable GetAdminList();
        string GetGroupAdminCount(int goupID);
        M_Admin GetModel(int userId);
        M_Admin GetModel(string loginName, string password);
        void UpdateInfo(M_Admin model);
        void UpdateState(M_Admin model);
    }
}

