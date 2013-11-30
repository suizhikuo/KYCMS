namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IController
    {
        void Add(M_Controller model);
        void Delete(int controllerId, int userId);
        DataTable GetList(int userId);
        void SetDefault(int userId);
        void Update(M_Controller model);
    }
}

