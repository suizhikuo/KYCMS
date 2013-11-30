namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface ISpecial
    {
        void Add(M_Special model);
        void CompleteDelete(int id);
        void Delete(int id);
        DataTable GetAllSpecial();
        DataTable GetChannelSpecial(int chId);
        M_Special GetSpecial(int id);
        DataTable GetSpecialByParentId(int id);
        DataTable GetSpecials(int selectType);
        void Update(M_Special model);
    }
}

