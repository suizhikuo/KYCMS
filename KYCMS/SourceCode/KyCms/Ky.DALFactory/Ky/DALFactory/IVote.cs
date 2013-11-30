namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IVote
    {
        int AddSubject(M_VoteSubject model);
        void AddVote(M_Vote model);
        void Delete(int subjectId);
        DataTable GetAll();
        DataTable GetSubject(int subjectId);
        DataTable GetSubjects(int pageSize, int pageIndex, string whereStr, ref int total);
        M_Vote GetVoteIdbyInfo(int voteId);
        void UpdateSubject(M_VoteSubject model);
        void UpdateVote(M_Vote model);
    }
}

