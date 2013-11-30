namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_UserMessage
    {
        private IUserMessage IUM = DataAccess.CreateUserMessage();

        public void AddMessage(M_UserMessage model)
        {
            this.IUM.AddMessage(model);
        }

        public void DeleteMessage(string idStr, int userId)
        {
            this.IUM.DeleteMessage(idStr, userId);
        }

        public DataRow GetMessageById(int id, int userId)
        {
            return this.IUM.GetMessageById(id, userId);
        }

        public DataTable GetMessageByUserId(int userId, int pageIndex, int pageSize, ref int recordCount)
        {
            return this.IUM.GetMessageByUserId(userId, pageIndex, pageSize, ref recordCount);
        }

        public void ResumeMessage(M_UserMessage model)
        {
            this.IUM.ResumeMessage(model);
        }
    }
}

