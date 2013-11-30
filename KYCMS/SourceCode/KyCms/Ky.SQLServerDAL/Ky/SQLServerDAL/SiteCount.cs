namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class SiteCount : ISiteCount
    {
        public void AddDayCount(string currDay, string currHour)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CurrHour", currHour), new SqlParameter("@CurrDay", currDay) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_KyCount_AddDayCount", commandParameters);
        }

        public void AddMonthCount(string currMonth, string currDay)
        {
            SqlParameter[] commandParameters = new SqlParameter[2];
            commandParameters[1] = new SqlParameter("@currDay", currDay);
            commandParameters[0] = new SqlParameter("@currMonth", currMonth);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_KyCount_AddMonthCount", commandParameters);
        }

        public void AddWeekCount(string currDate, string currWeekDay)
        {
            SqlParameter[] commandParameters = new SqlParameter[2];
            commandParameters[1] = new SqlParameter("@CurrDate", currDate);
            commandParameters[0] = new SqlParameter("@CurrWeekDay", currWeekDay);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_KyCount_AddWeekCount", commandParameters);
        }

        public void AddYearCount(string currYear, string currMonth)
        {
            SqlParameter[] commandParameters = new SqlParameter[2];
            commandParameters[1] = new SqlParameter("@currMonth", currMonth);
            commandParameters[0] = new SqlParameter("@currYear", currYear);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_KyCount_AddYearCount", commandParameters);
        }

        public DataTable GetData(string dataType, string filter)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.VarChar, 10), new SqlParameter("@Filter", SqlDbType.VarChar, 15) };
            commandParameters[0].Value = dataType;
            commandParameters[1].Value = filter;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Site_Count", commandParameters);
            DataTable table2 = new DataTable();
            table2.Columns.Add("Type", typeof(string));
            table2.Columns.Add("Num", typeof(int));
            table2.Columns.Add("Proportion", typeof(string));
            int num = 0;
            if (table.Rows.Count > 0)
            {
                int num2;
                for (num2 = 0; num2 < (table.Columns.Count - 1); num2++)
                {
                    num += (int) table.Rows[0][num2];
                }
                for (num2 = 0; num2 < (table.Columns.Count - 1); num2++)
                {
                    DataRow row = table2.NewRow();
                    row[0] = (num2 + 1).ToString();
                    row[1] = (int) table.Rows[0][num2];
                    if (num == 0)
                    {
                        row[2] = 0;
                    }
                    else
                    {
                        row[2] = (Math.Round((double) (Convert.ToDouble(table.Rows[0][num2].ToString()) / Convert.ToDouble(num)), 3) * 100.0) + "%";
                    }
                    table2.Rows.Add(row);
                }
            }
            return table2;
        }
    }
}

