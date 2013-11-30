namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IChannel
    {
        int Add(M_Channel model);
        void CompleteDelete(int chId);
        void Delete(int id);
        DataTable GetAll();
        void SetDisable(int chId, bool isDisabled);
        int Update(M_Channel model);
    }
}

