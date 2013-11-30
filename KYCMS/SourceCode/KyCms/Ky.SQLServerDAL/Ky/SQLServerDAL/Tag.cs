namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Tag : ITag
    {
        public bool Add(M_Tag model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Name", model.Name), new SqlParameter("@TagCategoryId", model.TagCategoryId), new SqlParameter("@ModelType", model.ModelType), new SqlParameter("@UserId", model.UserId), new SqlParameter("@UserName", model.UserName) };
            return (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Tag_Add", commandParameters) == 1);
        }

        public DataRow AddTagStr(string tagNameStr, int modelType, int uId, string uName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tagstr", tagNameStr), new SqlParameter("@modeltype", modelType), new SqlParameter("@uid", uId), new SqlParameter("@uname", uName) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Tag_AddTagStr", commandParameters);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0];
            }
            return null;
        }

        public void ClearSearchCount()
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Tag_Clear", new SqlParameter[0]);
        }

        public void Delete(int searchCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SearchCount", searchCount) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Tag_Delete", commandParameters);
        }

        public DataTable GetList(int currPage, int pageSize, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CurrPage", currPage), new SqlParameter("@PageSize", pageSize), new SqlParameter("@RecordCount", SqlDbType.BigInt) };
            commandParameters[2].Direction = ParameterDirection.Output;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Tag_GetList", commandParameters);
            recordCount = Convert.ToInt32(commandParameters[2].Value);
            return table;
        }

        public void SetTagSearchCount(string tagName, int modelType)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@tagName", tagName), new SqlParameter("@modeltype", modelType) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Tag_SetSearchCount", commandParameters);
        }
    }
}

