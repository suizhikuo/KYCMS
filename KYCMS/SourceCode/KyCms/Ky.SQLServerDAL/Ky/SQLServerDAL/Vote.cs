namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Vote : IVote
    {
        public int AddSubject(M_VoteSubject model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Subject", SqlDbType.NVarChar), new SqlParameter("@StartDate", SqlDbType.DateTime), new SqlParameter("@EndDate", SqlDbType.DateTime), new SqlParameter("@RequireLogin", SqlDbType.Bit, 1), new SqlParameter("@CategoryId", SqlDbType.Int, 4), new SqlParameter("@Identity", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.Subject;
            commandParameters[1].Value = model.StartDate;
            commandParameters[2].Value = model.EndDate;
            commandParameters[3].Value = model.RequireLogin;
            commandParameters[4].Value = model.CategoryId;
            commandParameters[5].Value = 0;
            commandParameters[5].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_VoteSubject_Add", commandParameters);
            return (int) commandParameters[5].Value;
        }

        public void AddVote(M_Vote model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@SubjectId", SqlDbType.Int, 4), new SqlParameter("@VoteTitle", SqlDbType.NVarChar), new SqlParameter("@DisplayType", SqlDbType.Int, 4), new SqlParameter("@IsMore", SqlDbType.Bit, 1), new SqlParameter("@ModelType", SqlDbType.Int, 4), new SqlParameter("@ItemTitle1", SqlDbType.NVarChar), new SqlParameter("@ItemNum1", SqlDbType.Int, 4), new SqlParameter("@ItemTitle2", SqlDbType.NVarChar), new SqlParameter("@ItemNum2", SqlDbType.Int, 4), new SqlParameter("@ItemTitle3", SqlDbType.NVarChar), new SqlParameter("@ItemNum3", SqlDbType.Int, 4), new SqlParameter("@ItemTitle4", SqlDbType.NVarChar), new SqlParameter("@ItemNum4", SqlDbType.Int, 4), new SqlParameter("@ItemTitle5", SqlDbType.NVarChar), new SqlParameter("@ItemNum5", SqlDbType.Int, 4), new SqlParameter("@ItemTitle6", SqlDbType.NVarChar), 
                new SqlParameter("@ItemNum6", SqlDbType.Int, 4)
             };
            commandParameters[0].Value = model.SubjectId;
            commandParameters[1].Value = model.VoteTitle;
            commandParameters[2].Value = model.DisplayType;
            commandParameters[3].Value = model.IsMore;
            commandParameters[4].Value = model.ModelType;
            commandParameters[5].Value = model.ItemTitle1;
            commandParameters[6].Value = model.ItemNum1;
            commandParameters[7].Value = model.ItemTitle2;
            commandParameters[8].Value = model.ItemNum2;
            commandParameters[9].Value = model.ItemTitle3;
            commandParameters[10].Value = model.ItemNum3;
            commandParameters[11].Value = model.ItemTitle4;
            commandParameters[12].Value = model.ItemNum4;
            commandParameters[13].Value = model.ItemTitle5;
            commandParameters[14].Value = model.ItemNum5;
            commandParameters[15].Value = model.ItemTitle6;
            commandParameters[16].Value = model.ItemNum6;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Vote_Add", commandParameters);
        }

        public void Delete(int subjectId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SubjectId", SqlDbType.Int, 4) };
            commandParameters[0].Value = subjectId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_VoteSubject_Delete", commandParameters);
        }

        public DataTable GetAll()
        {
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_VoteSubject_GetAll", null);
        }

        public DataTable GetSubject(int subjectId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SubjectId", SqlDbType.Int, 4), new SqlParameter("@Type", SqlDbType.Int, 4) };
            commandParameters[0].Value = subjectId;
            commandParameters[1].Value = 2;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_VoteSubject_Get", commandParameters);
        }

        public DataTable GetSubjects(int pageSize, int pageIndex, string whereStr, ref int total)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SubjectId", SqlDbType.Int, 4), new SqlParameter("@Type", SqlDbType.Int, 4), new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@PageIndex", SqlDbType.Int, 4), new SqlParameter("@WhereStr", SqlDbType.VarChar, 100), new SqlParameter("@Total", SqlDbType.Int, 4) };
            commandParameters[1].Value = 1;
            commandParameters[2].Value = pageSize;
            commandParameters[3].Value = pageIndex;
            commandParameters[4].Value = whereStr;
            commandParameters[5].Value = 0;
            commandParameters[5].Direction = ParameterDirection.Output;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_VoteSubject_Get", commandParameters);
            total = (int) commandParameters[5].Value;
            return table;
        }

        public M_Vote GetVoteIdbyInfo(int voteId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@voteId", SqlDbType.Int) };
            commandParameters[0].Value = voteId;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Vote_GetVoteIdByInfo", commandParameters);
            M_Vote vote = new M_Vote();
            vote.VoteTitle = table.Rows[0]["VoteTitle"].ToString();
            if (table.Rows[0]["isMore"].ToString() == "True")
            {
                vote.IsMore = true;
            }
            else
            {
                vote.IsMore = false;
            }
            vote.ItemTitle1 = table.Rows[0]["ItemTitle1"].ToString();
            vote.ItemTitle2 = table.Rows[0]["ItemTitle2"].ToString();
            vote.ItemTitle3 = table.Rows[0]["ItemTitle3"].ToString();
            vote.ItemTitle4 = table.Rows[0]["ItemTitle4"].ToString();
            vote.ItemTitle5 = table.Rows[0]["ItemTitle5"].ToString();
            vote.ItemTitle6 = table.Rows[0]["ItemTitle6"].ToString();
            vote.ItemNum1 = int.Parse(table.Rows[0]["ItemNum1"].ToString());
            vote.ItemNum2 = int.Parse(table.Rows[0]["ItemNum2"].ToString());
            vote.ItemNum3 = int.Parse(table.Rows[0]["ItemNum3"].ToString());
            vote.ItemNum4 = int.Parse(table.Rows[0]["ItemNum4"].ToString());
            vote.ItemNum5 = int.Parse(table.Rows[0]["ItemNum5"].ToString());
            vote.ItemNum6 = int.Parse(table.Rows[0]["ItemNum6"].ToString());
            vote.SubjectId = int.Parse(table.Rows[0]["SubjectId"].ToString());
            return vote;
        }

        public void UpdateSubject(M_VoteSubject model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@VoteSubjectId", SqlDbType.Int, 4), new SqlParameter("@Subject", SqlDbType.NVarChar), new SqlParameter("@StartDate", SqlDbType.DateTime), new SqlParameter("@EndDate", SqlDbType.DateTime), new SqlParameter("@RequireLogin", SqlDbType.Bit, 1), new SqlParameter("@CategoryId", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.SubjectId;
            commandParameters[1].Value = model.Subject;
            commandParameters[2].Value = model.StartDate;
            commandParameters[3].Value = model.EndDate;
            commandParameters[4].Value = model.RequireLogin;
            commandParameters[5].Value = model.CategoryId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_VoteSubject_Update", commandParameters);
        }

        public void UpdateVote(M_Vote model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@VoteId", SqlDbType.Int, 4), new SqlParameter("@VoteTitle", SqlDbType.NVarChar), new SqlParameter("@IsMore", SqlDbType.Bit, 1), new SqlParameter("@ItemTitle1", SqlDbType.NVarChar), new SqlParameter("@ItemNum1", SqlDbType.Int, 4), new SqlParameter("@ItemTitle2", SqlDbType.NVarChar), new SqlParameter("@ItemNum2", SqlDbType.Int, 4), new SqlParameter("@ItemTitle3", SqlDbType.NVarChar), new SqlParameter("@ItemNum3", SqlDbType.Int, 4), new SqlParameter("@ItemTitle4", SqlDbType.NVarChar), new SqlParameter("@ItemNum4", SqlDbType.Int, 4), new SqlParameter("@ItemTitle5", SqlDbType.NVarChar), new SqlParameter("@ItemNum5", SqlDbType.Int, 4), new SqlParameter("@ItemTitle6", SqlDbType.NVarChar), new SqlParameter("@ItemNum6", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.VoteId;
            commandParameters[1].Value = model.VoteTitle;
            commandParameters[2].Value = model.IsMore;
            commandParameters[3].Value = model.ItemTitle1;
            commandParameters[4].Value = model.ItemNum1;
            commandParameters[5].Value = model.ItemTitle2;
            commandParameters[6].Value = model.ItemNum2;
            commandParameters[7].Value = model.ItemTitle3;
            commandParameters[8].Value = model.ItemNum3;
            commandParameters[9].Value = model.ItemTitle4;
            commandParameters[10].Value = model.ItemNum4;
            commandParameters[11].Value = model.ItemTitle5;
            commandParameters[12].Value = model.ItemNum5;
            commandParameters[13].Value = model.ItemTitle6;
            commandParameters[14].Value = model.ItemNum6;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Vote_Update", commandParameters);
        }
    }
}

