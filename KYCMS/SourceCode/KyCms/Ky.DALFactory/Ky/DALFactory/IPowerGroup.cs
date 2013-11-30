namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IPowerGroup
    {
        void Del(int PowerId);
        void Insert(M_PowerGroup model);
        DataTable Manage();
        DataTable PowerColumnNameList();
        DataTable PowerModelList();
        M_PowerGroup Show(int PowerId);
        void Update(M_PowerGroup model);
    }
}

