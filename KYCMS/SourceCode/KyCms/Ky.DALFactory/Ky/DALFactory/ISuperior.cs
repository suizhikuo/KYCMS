namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface ISuperior
    {
        void Add(M_Superior model);
        void Delete(int id);
        M_Superior GetIdBySuperior(int id);
        DataTable GetList();
        void Update(M_Superior model);
    }
}

