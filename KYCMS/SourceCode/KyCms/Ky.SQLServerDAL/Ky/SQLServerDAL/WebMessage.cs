namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class WebMessage : IWebMessage
    {
        public void Delete(int WMId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete KyWebMessage ");
            builder.Append(" where WMId=" + WMId + "");
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SqlStr", SqlDbType.NVarChar, 3910) };
            commandParameters[0].Value = builder.ToString();
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Sp_ExecuteSql", commandParameters);
        }

        public string GetDelType(int WMId, int UserId)
        {
            M_WebMessage message = new M_WebMessage();
            if (this.Show(WMId, UserId).ReceiverId == UserId)
            {
                return "ReceiverDel";
            }
            return "SendDel";
        }

        public DataTable GetList(string WhereStr)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from KyWebMessage");
            builder.Append("" + WhereStr + "");
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SqlStr", SqlDbType.NVarChar, 3910) };
            commandParameters[0].Value = builder.ToString();
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Sp_ExecuteSql", commandParameters);
        }

        public DataSet GetList(int currPage, int pageSize, string WhereStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CurrPage", SqlDbType.Int, 4), new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@WhereStr", SqlDbType.NVarChar, 100) };
            commandParameters[0].Value = currPage;
            commandParameters[1].Value = pageSize;
            commandParameters[2].Value = WhereStr;
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_WebMessage_GetList", commandParameters);
        }

        public void Insert(M_WebMessage model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ReceiverId", SqlDbType.Int, 4), new SqlParameter("@ReceiverName", SqlDbType.NVarChar), new SqlParameter("@SendId", SqlDbType.Int, 4), new SqlParameter("@SendName", SqlDbType.NVarChar), new SqlParameter("@Title", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NVarChar), new SqlParameter("@IsSend", SqlDbType.Int, 4), new SqlParameter("@IsRead", SqlDbType.Int, 4), new SqlParameter("@ReceiverDel", SqlDbType.Int, 4), new SqlParameter("@SendDel", SqlDbType.Int, 4), new SqlParameter("@AllUser", SqlDbType.Int, 4), new SqlParameter("@UserGroupId", SqlDbType.Int, 4), new SqlParameter("@OverdueDate", SqlDbType.DateTime), new SqlParameter("@AddDate", SqlDbType.DateTime) };
            commandParameters[0].Value = model.ReceiverId;
            commandParameters[1].Value = model.ReceiverName;
            commandParameters[2].Value = model.SendId;
            commandParameters[3].Value = model.SendName;
            commandParameters[4].Value = model.Title;
            commandParameters[5].Value = model.Content;
            commandParameters[6].Value = model.IsSend;
            commandParameters[7].Value = model.IsRead;
            commandParameters[8].Value = model.ReceiverDel;
            commandParameters[9].Value = model.SendDel;
            commandParameters[10].Value = model.AllUser;
            commandParameters[11].Value = model.UserGroupId;
            commandParameters[12].Value = model.OverdueDate;
            commandParameters[13].Value = model.AddDate;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_WebMessage", commandParameters);
        }

        public M_WebMessage Show(int WMId, int UserId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from KyWebMessage ");
            builder.Append("where WMId=" + WMId + "");
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SqlStr", SqlDbType.NVarChar, 3910) };
            commandParameters[0].Value = builder.ToString();
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Sp_ExecuteSql", commandParameters);
            if (table.Rows.Count > 0)
            {
                M_WebMessage message = new M_WebMessage();
                if (table.Rows[0]["ReceiverId"].ToString() != "")
                {
                    message.ReceiverId = int.Parse(table.Rows[0]["ReceiverId"].ToString());
                }
                message.ReceiverName = table.Rows[0]["ReceiverName"].ToString();
                if (table.Rows[0]["SendId"].ToString() != "")
                {
                    message.SendId = int.Parse(table.Rows[0]["SendId"].ToString());
                }
                message.SendName = table.Rows[0]["SendName"].ToString();
                message.Title = table.Rows[0]["Title"].ToString();
                message.Content = table.Rows[0]["Content"].ToString();
                if (table.Rows[0]["IsSend"].ToString() != "")
                {
                    message.IsSend = int.Parse(table.Rows[0]["IsSend"].ToString());
                }
                if (table.Rows[0]["IsRead"].ToString() != "")
                {
                    message.IsRead = int.Parse(table.Rows[0]["IsRead"].ToString());
                }
                if (table.Rows[0]["ReceiverDel"].ToString() != "")
                {
                    message.ReceiverDel = int.Parse(table.Rows[0]["ReceiverDel"].ToString());
                }
                if (table.Rows[0]["SendDel"].ToString() != "")
                {
                    message.SendDel = int.Parse(table.Rows[0]["SendDel"].ToString());
                }
                if (table.Rows[0]["AllUser"].ToString() != "")
                {
                    message.AllUser = int.Parse(table.Rows[0]["AllUser"].ToString());
                }
                if (table.Rows[0]["UserGroupId"].ToString() != "")
                {
                    message.UserGroupId = int.Parse(table.Rows[0]["UserGroupId"].ToString());
                }
                if (table.Rows[0]["OverdueDate"].ToString() != "")
                {
                    message.OverdueDate = DateTime.Parse(table.Rows[0]["OverdueDate"].ToString());
                }
                if (table.Rows[0]["AddDate"].ToString() != "")
                {
                    message.AddDate = DateTime.Parse(table.Rows[0]["AddDate"].ToString());
                }
                if ((table.Rows[0]["AllUser"].ToString() == "0") && (table.Rows[0]["ReceiverId"].ToString() == ("" + UserId + "")))
                {
                    this.UpdateRead(WMId);
                }
                return message;
            }
            return null;
        }

        public void UpdateDel(int WMId, int UserId, int DelTypeId)
        {
            StringBuilder builder = new StringBuilder();
            if (DelTypeId == 1)
            {
                builder.Append("update KyWebMessage set ");
                builder.Append(string.Concat(new object[] { "ReceiverDel=1 where WMId=", WMId, " and ReceiverId=", UserId, "" }));
            }
            if (DelTypeId == 2)
            {
                builder.Append("update KyWebMessage set ");
                builder.Append(string.Concat(new object[] { "SendDel=1 where WMId=", WMId, " and SendId=", UserId, "" }));
            }
            if (DelTypeId == 3)
            {
                builder.Append("update KyWebMessage set ");
                builder.Append(string.Concat(new object[] { "SendDel=1 where WMId=", WMId, " and SendId=", UserId, " and SendDel=0" }));
            }
            if (DelTypeId == 4)
            {
                string delType = this.GetDelType(WMId, UserId);
                M_WebMessage message = new M_WebMessage();
                message = this.Show(WMId, UserId);
                if (((message.ReceiverDel == 2) || (message.SendDel == 2)) || (((message.SendId == message.ReceiverId) && (message.ReceiverDel == 1)) && (message.SendDel == 1)))
                {
                    builder.Append("delete KyWebMessage ");
                    builder.Append("where WMId=" + WMId + "");
                }
                else
                {
                    builder.Append("update KyWebMessage set ");
                    builder.Append(string.Concat(new object[] { "", delType, "=2 where WMId=", WMId, " and ", delType, "=1" }));
                }
            }
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SqlStr", SqlDbType.NVarChar, 0x7d0) };
            commandParameters[0].Value = builder.ToString();
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Sp_ExecuteSql", commandParameters);
        }

        public void UpdateRead(int WMId)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update KyWebMessage set ");
            builder.Append("IsRead=1 where WMId=" + WMId + "");
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SqlStr", SqlDbType.NVarChar) };
            commandParameters[0].Value = builder.ToString();
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Sp_ExecuteSql", commandParameters);
        }
    }
}

