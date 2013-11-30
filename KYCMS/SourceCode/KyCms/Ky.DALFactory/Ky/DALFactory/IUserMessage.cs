namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IUserMessage
    {
        void AddMessage(M_UserMessage model);
        void DeleteMessage(string idStr, int userId);
        DataRow GetMessageById(int id, int userId);
        DataTable GetMessageByUserId(int userId, int pageIndex, int pageSize, ref int recordCount);
        void ResumeMessage(M_UserMessage model);
    }
}

