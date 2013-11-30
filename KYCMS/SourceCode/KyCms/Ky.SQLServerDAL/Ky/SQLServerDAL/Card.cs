namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Card : ICard
    {
        public string Add(M_Card model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.Int, 4), new SqlParameter("@CardAccount", SqlDbType.VarChar, 10), new SqlParameter("@Password", SqlDbType.VarChar, 200), new SqlParameter("@IsUsed", SqlDbType.Bit, 1), new SqlParameter("@CardPoint", SqlDbType.Int, 4), new SqlParameter("@CardDay", SqlDbType.Int, 4), new SqlParameter("@AdminID", SqlDbType.Int, 4), new SqlParameter("@AdminName", SqlDbType.VarChar, 50), new SqlParameter("@OverdueDate", SqlDbType.DateTime) };
            commandParameters[0].Value = (model.Type == CardType.MonthCard) ? 1 : 0;
            commandParameters[1].Value = model.CardAccount;
            commandParameters[2].Value = model.Password;
            commandParameters[3].Value = model.IsUsed;
            commandParameters[4].Value = model.CardPoint;
            commandParameters[5].Value = model.CardDay;
            commandParameters[6].Value = model.AdminID;
            commandParameters[7].Value = model.AdminName;
            commandParameters[8].Value = model.OverdueDate;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Card_Add", commandParameters);
            string str = string.Empty;
            if (table.Rows.Count > 0)
            {
                str = table.Rows[0]["Account"].ToString();
            }
            return str;
        }

        public void Delete(string account)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CardAccount", SqlDbType.VarChar, 15) };
            commandParameters[0].Value = account;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Card_Delete", commandParameters);
        }

        public M_Card GetCard(string account)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Account", SqlDbType.VarChar, 20) };
            commandParameters[0].Value = account;
            M_Card card = new M_Card();
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Card_GetCard", commandParameters);
            card.CardAccount = account;
            if (table.Rows.Count > 0)
            {
                if (table.Rows[0]["Type"].ToString() != "")
                {
                    card.Type = (int.Parse(table.Rows[0]["Type"].ToString()) == 0) ? CardType.PointCard : CardType.MonthCard;
                }
                card.Password = table.Rows[0]["Password"].ToString();
                if (table.Rows[0]["IsUsed"].ToString() != "")
                {
                    if ((table.Rows[0]["IsUsed"].ToString() == "1") || (table.Rows[0]["IsUsed"].ToString().ToLower() == "true"))
                    {
                        card.IsUsed = true;
                    }
                    else
                    {
                        card.IsUsed = false;
                    }
                }
                if (table.Rows[0]["CardPoint"].ToString() != "")
                {
                    card.CardPoint = int.Parse(table.Rows[0]["CardPoint"].ToString());
                }
                if (table.Rows[0]["CardDay"].ToString() != "")
                {
                    card.CardDay = int.Parse(table.Rows[0]["CardDay"].ToString());
                }
                if (table.Rows[0]["AdminID"].ToString() != "")
                {
                    card.AdminID = int.Parse(table.Rows[0]["AdminID"].ToString());
                }
                card.AdminName = table.Rows[0]["AdminName"].ToString();
                if (table.Rows[0]["UserID"].ToString() != "")
                {
                    card.UserID = int.Parse(table.Rows[0]["UserID"].ToString());
                }
                card.UserName = table.Rows[0]["UserName"].ToString();
                if (table.Rows[0]["OverdueDate"].ToString() != "")
                {
                    card.OverdueDate = DateTime.Parse(table.Rows[0]["OverdueDate"].ToString());
                }
                return card;
            }
            return null;
        }

        public DataSet GetCards(int pageSize, int pageIndex, string whereString)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@PageIndex", SqlDbType.Int, 4), new SqlParameter("@Total", SqlDbType.Int, 4), new SqlParameter("@WhereStr", SqlDbType.VarChar, 100) };
            commandParameters[0].Value = pageSize;
            commandParameters[1].Value = pageIndex;
            commandParameters[2].Direction = ParameterDirection.Output;
            commandParameters[2].Value = "0";
            commandParameters[3].Value = whereString;
            DataTable table = new DataTable("Data");
            table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Card_GetCards", commandParameters);
            DataSet set = new DataSet();
            if (table != null)
            {
                set.Tables.Add(table.Copy());
            }
            DataTable table2 = new DataTable("Total");
            table2.Columns.Add("Total", typeof(int));
            table2.Rows.Add(new object[] { (int) commandParameters[2].Value });
            set.Tables.Add(table2.Copy());
            return set;
        }

        public DataTable GetCardsByType(CardType type)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DataTable GetCardsByUser(string userName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Update(M_Card model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.Int, 4), new SqlParameter("@CardAccount", SqlDbType.VarChar, 20), new SqlParameter("@Password", SqlDbType.VarChar, 200), new SqlParameter("@IsUsed", SqlDbType.Bit, 1), new SqlParameter("@CardPoint", SqlDbType.Int, 4), new SqlParameter("@CardDay", SqlDbType.Int, 4), new SqlParameter("@AdminID", SqlDbType.Int, 4), new SqlParameter("@AdminName", SqlDbType.VarChar, 50), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@OverdueDate", SqlDbType.DateTime) };
            commandParameters[0].Value = model.Type;
            commandParameters[1].Value = model.CardAccount;
            commandParameters[2].Value = model.Password;
            commandParameters[3].Value = model.IsUsed;
            commandParameters[4].Value = model.CardPoint;
            commandParameters[5].Value = model.CardDay;
            commandParameters[6].Value = model.AdminID;
            commandParameters[7].Value = model.AdminName;
            commandParameters[8].Value = model.UserID;
            commandParameters[9].Value = model.UserName;
            commandParameters[10].Value = model.OverdueDate;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Card_Update", commandParameters);
        }
    }
}

