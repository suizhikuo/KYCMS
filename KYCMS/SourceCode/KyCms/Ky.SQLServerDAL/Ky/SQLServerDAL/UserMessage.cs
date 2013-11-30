namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class UserMessage : IUserMessage
    {
        public void AddMessage(M_UserMessage model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int, 4), new SqlParameter("@Title", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.Text), new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("@AnounName", SqlDbType.NVarChar), new SqlParameter("@HomePage", SqlDbType.NVarChar), new SqlParameter("@IsPrivacy", SqlDbType.Bit, 1), new SqlParameter("@IsResume", SqlDbType.Bit, 1), new SqlParameter("@ResumeContent", SqlDbType.Text), new SqlParameter("@PostTime", SqlDbType.NVarChar) };
            commandParameters[0].Value = model.Id;
            commandParameters[1].Value = model.Title;
            commandParameters[2].Value = model.Content;
            commandParameters[3].Value = model.UserId;
            commandParameters[4].Value = model.AnounName;
            commandParameters[5].Value = model.HomePage;
            commandParameters[6].Value = model.IsPrivacy;
            commandParameters[7].Value = model.IsResume;
            commandParameters[8].Value = model.ResumeContent;
            commandParameters[9].Value = model.PostTime;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserMessage_Set", commandParameters);
        }

        public void DeleteMessage(string idStr, int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@IdStr", idStr), new SqlParameter("@UserId", userId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserMessage_Delete", commandParameters);
        }

        public DataRow GetMessageById(int id, int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", id), new SqlParameter("@UserId", userId) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserMessage_GetById", commandParameters);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0];
            }
            return null;
        }

        public DataTable GetMessageByUserId(int userId, int pageIndex, int pageSize, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", userId), new SqlParameter("@PageIndex", pageIndex), new SqlParameter("@PageSize", pageSize) };
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserMessage_GetByUserId", commandParameters);
            recordCount = Convert.ToInt32(set.Tables[1].Rows[0][0]);
            return set.Tables[0];
        }

        public void ResumeMessage(M_UserMessage model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int, 4), new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("@ResumeContent", SqlDbType.Text), new SqlParameter("@ResumeTime", SqlDbType.NVarChar) };
            commandParameters[0].Value = model.Id;
            commandParameters[1].Value = model.UserId;
            commandParameters[2].Value = model.ResumeContent;
            commandParameters[3].Value = model.ResumeTime;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserMessage_Resume", commandParameters);
        }
    }
}

