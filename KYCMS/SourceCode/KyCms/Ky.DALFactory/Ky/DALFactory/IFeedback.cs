namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IFeedback
    {
        void Add(M_Feedback model);
        DataSet Count();
        void Delete(int feedbackId);
        DataSet GetFeedback(int feedbackId);
        DataSet GetList(int pageSize, int pageIndex, string whereStr);
        DataTable GetReplyers(int type, int feedbackId, string author);
        void UpdateState(int id, int type, int value);
    }
}

