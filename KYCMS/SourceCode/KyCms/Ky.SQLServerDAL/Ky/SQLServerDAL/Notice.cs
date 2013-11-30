namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Notice : INotice
    {
        public void Del(int NoticeId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@NoticeId", SqlDbType.Int, 4), new SqlParameter("@TypeId", SqlDbType.Int, 4) };
            commandParameters[0].Value = NoticeId;
            commandParameters[1].Value = 3;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_Notice", commandParameters);
        }

        public DataSet GetList(int currPage, int pageSize, string WhereStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CurrPage", SqlDbType.Int, 4), new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@WhereStr", SqlDbType.NVarChar, 0x3e8) };
            commandParameters[0].Value = currPage;
            commandParameters[1].Value = pageSize;
            commandParameters[2].Value = WhereStr;
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_TagNotice_GetList", commandParameters);
        }

        public DataTable GetTop(int TopValue)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Top", SqlDbType.Int, 4) };
            commandParameters[0].Value = TopValue;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Notice_GetTop", commandParameters);
        }

        public void Insert(M_Notice model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Title", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@OverdueDate", SqlDbType.DateTime), new SqlParameter("@IsPriority", SqlDbType.Int, 4), new SqlParameter("@IsState", SqlDbType.NVarChar), new SqlParameter("@AddDate", SqlDbType.DateTime), new SqlParameter("@TypeId", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.Title;
            commandParameters[1].Value = model.Content;
            commandParameters[2].Value = model.UserId;
            commandParameters[3].Value = model.UserName;
            commandParameters[4].Value = model.OverdueDate;
            commandParameters[5].Value = model.IsPriority;
            commandParameters[6].Value = model.IsState;
            commandParameters[7].Value = model.AddDate;
            commandParameters[8].Value = model.TypeId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_Notice", commandParameters);
        }

        public DataTable Manage(int TypeId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TypeId", SqlDbType.Int, 4) };
            commandParameters[0].Value = TypeId;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_Notice", commandParameters);
        }

        public M_Notice Show(int NoticeId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@NoticeId", SqlDbType.Int, 4), new SqlParameter("@TypeId", SqlDbType.Int, 4) };
            commandParameters[0].Value = NoticeId;
            commandParameters[1].Value = 4;
            M_Notice notice = new M_Notice();
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_Notice", commandParameters);
            notice.NoticeId = NoticeId;
            if (table.Rows.Count > 0)
            {
                notice.Title = table.Rows[0]["Title"].ToString();
                notice.Content = table.Rows[0]["Content"].ToString();
                if (table.Rows[0]["UserId"].ToString() != "")
                {
                    notice.UserId = int.Parse(table.Rows[0]["UserId"].ToString());
                }
                notice.UserName = table.Rows[0]["UserName"].ToString();
                if (table.Rows[0]["OverdueDate"].ToString() != "")
                {
                    notice.OverdueDate = DateTime.Parse(table.Rows[0]["OverdueDate"].ToString());
                }
                if (table.Rows[0]["IsPriority"].ToString() != "")
                {
                    notice.IsPriority = int.Parse(table.Rows[0]["IsPriority"].ToString());
                }
                notice.IsState = table.Rows[0]["IsState"].ToString();
                if (table.Rows[0]["AddDate"].ToString() != "")
                {
                    notice.AddDate = DateTime.Parse(table.Rows[0]["AddDate"].ToString());
                }
                return notice;
            }
            return null;
        }

        public void Update(M_Notice model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@NoticeId", SqlDbType.Int, 4), new SqlParameter("@Title", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@OverdueDate", SqlDbType.DateTime), new SqlParameter("@IsPriority", SqlDbType.Int, 4), new SqlParameter("@IsState", SqlDbType.NVarChar), new SqlParameter("@AddDate", SqlDbType.DateTime), new SqlParameter("@TypeId", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.NoticeId;
            commandParameters[1].Value = model.Title;
            commandParameters[2].Value = model.Content;
            commandParameters[3].Value = model.UserId;
            commandParameters[4].Value = model.UserName;
            commandParameters[5].Value = model.OverdueDate;
            commandParameters[6].Value = model.IsPriority;
            commandParameters[7].Value = model.IsState;
            commandParameters[8].Value = model.AddDate;
            commandParameters[9].Value = model.TypeId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_Notice", commandParameters);
        }

        public void UpdateIsState(int NoticeId)
        {
            SqlParameter[] parameterArray;
            M_Notice notice = new M_Notice();
            if (this.Show(NoticeId).IsState == "草稿")
            {
                parameterArray = new SqlParameter[] { new SqlParameter("@NoticeId", SqlDbType.Int, 4), new SqlParameter("@IsState", SqlDbType.NVarChar), new SqlParameter("@TypeId", SqlDbType.Int, 4) };
                parameterArray[0].Value = NoticeId;
                parameterArray[1].Value = "审核通过";
                parameterArray[2].Value = 5;
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_Notice", parameterArray);
            }
            else
            {
                parameterArray = new SqlParameter[] { new SqlParameter("@NoticeId", SqlDbType.Int, 4), new SqlParameter("@IsState", SqlDbType.NVarChar), new SqlParameter("@TypeId", SqlDbType.Int, 4) };
                parameterArray[0].Value = NoticeId;
                parameterArray[1].Value = "草稿";
                parameterArray[2].Value = 5;
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_Notice", parameterArray);
            }
        }
    }
}

