namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IVoteCategory
    {
        void Add(M_VoteCategory model);
        void Delete(int id);
        M_VoteCategory GetCategory(int id);
        DataTable GetList();
        void Update(M_VoteCategory model);
    }
}

