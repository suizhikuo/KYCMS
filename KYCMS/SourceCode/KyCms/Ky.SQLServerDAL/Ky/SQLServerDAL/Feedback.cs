namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Feedback : IFeedback
    {
        public void Add(M_Feedback model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ParentId", SqlDbType.Int, 4), new SqlParameter("@title", SqlDbType.NVarChar), new SqlParameter("@author", SqlDbType.NVarChar), new SqlParameter("@reward", SqlDbType.Int, 4), new SqlParameter("@scoring", SqlDbType.Int, 4), new SqlParameter("@categoryId", SqlDbType.Int, 4), new SqlParameter("@content", SqlDbType.NText), new SqlParameter("@state", SqlDbType.Int, 4), new SqlParameter("@replyDate", SqlDbType.DateTime), new SqlParameter("@EndDate", SqlDbType.DateTime), new SqlParameter("@IP", SqlDbType.NVarChar) };
            commandParameters[0].Value = model.ParentId;
            commandParameters[1].Value = model.Title;
            commandParameters[2].Value = model.Author;
            commandParameters[3].Value = model.Reward;
            commandParameters[4].Value = model.Scoring;
            commandParameters[5].Value = model.CategoryId;
            commandParameters[6].Value = model.Content;
            commandParameters[7].Value = model.State;
            commandParameters[8].Value = model.ReplyDate;
            commandParameters[9].Value = model.EndDate;
            commandParameters[10].Value = model.Ip;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Feedback_Add", commandParameters);
        }

        public DataSet Count()
        {
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Feedback_Count", null);
        }

        public void Delete(int feedbackId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@FeedbackId", SqlDbType.Int, 4) };
            commandParameters[0].Value = feedbackId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Feedback_Delete", commandParameters);
        }

        public DataSet GetFeedback(int feedbackId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@FeedbackID", SqlDbType.Int, 4), new SqlParameter("@Type", SqlDbType.Int, 4), new SqlParameter("@Author", SqlDbType.NVarChar) };
            commandParameters[0].Value = feedbackId;
            commandParameters[1].Value = 1;
            commandParameters[2].Value = "";
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Feedback_GetFeedback", commandParameters);
        }

        public DataSet GetList(int pageSize, int pageIndex, string whereStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@PageIndex", SqlDbType.Int, 4), new SqlParameter("@WhereStr", SqlDbType.NVarChar) };
            commandParameters[0].Value = pageSize;
            commandParameters[1].Value = pageIndex;
            commandParameters[2].Value = whereStr;
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Feedback_GetList", commandParameters);
        }

        public DataTable GetReplyers(int type, int feedbackId, string author)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@FeedbackID", SqlDbType.Int, 4), new SqlParameter("@Type", SqlDbType.Int, 4), new SqlParameter("@Author", SqlDbType.NVarChar) };
            commandParameters[0].Value = feedbackId;
            commandParameters[1].Value = type;
            commandParameters[2].Value = author;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Feedback_GetFeedback", commandParameters);
        }

        public void UpdateState(int id, int type, int value)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int, 4), new SqlParameter("@Type", SqlDbType.Int, 4), new SqlParameter("@Value", SqlDbType.Int, 4) };
            commandParameters[0].Value = id;
            commandParameters[1].Value = type;
            commandParameters[2].Value = value;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Feedback_UpdateState", commandParameters);
        }
    }
}

