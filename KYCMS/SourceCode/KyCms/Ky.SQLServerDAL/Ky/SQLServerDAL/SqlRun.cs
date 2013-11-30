namespace Ky.SQLServerDAL
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;

    public class SqlRun
    {
        protected SqlConnection sqlconn;

        public SqlRun(string LinkPath, string DataBaseType)
        {
            if (DataBaseType == "3")
            {
                this.sqlconn = new SqlConnection(LinkPath);
                this.sqlconn.Open();
            }
        }

        public void Dispose()
        {
            this.sqlconn.Close();
            this.sqlconn.Dispose();
            this.sqlconn = null;
        }

        private void Open(string DataBaseType)
        {
            if (DataBaseType == "3")
            {
                try
                {
                    this.sqlconn.Close();
                    this.sqlconn.Open();
                }
                catch (Exception exception)
                {
                    HttpContext.Current.Response.Write(exception.Message.ToString());
                }
            }
        }

        public DataSet RunSqlDs(string SqlStr, string DataBaseType)
        {
            this.Open(DataBaseType);
            if (DataBaseType == "3")
            {
                SqlCommand selectCommand = new SqlCommand(SqlStr, this.sqlconn);
                selectCommand.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                this.sqlconn.Close();
                return dataSet;
            }
            return null;
        }
    }
}

