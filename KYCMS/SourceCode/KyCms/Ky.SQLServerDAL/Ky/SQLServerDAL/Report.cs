namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Report : IReport
    {
        public void Add(M_Report model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Content", model.Content), new SqlParameter("@Url", model.Url), new SqlParameter("@UserId", model.UserId), new SqlParameter("@UserName", model.UserName), new SqlParameter("@IsComplete", model.IsComplete), new SqlParameter("@AddTime", model.AddTime) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Report_Add", commandParameters);
        }

        public void Delete(int reportId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ReportId", reportId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Report_Delete", commandParameters);
        }

        public DataSet GetList(int pageIndex, int pageSize, string whereStr)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@PageIndex", pageIndex), new SqlParameter("@PageSize", pageSize), new SqlParameter("@WhereStr", whereStr) };
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Report_GetList", commandParameters);
        }

        public void SetStatus(int reportId, int status)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ReportId", reportId), new SqlParameter("@Status", status) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Report_SetStatus", commandParameters);
        }
    }
}

