namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    internal class KyCommon : IKyCommon
    {
        public bool CheckHas(string input, string fileldName, string tableName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Input", input), new SqlParameter("@FileldName", fileldName), new SqlParameter("@TableName", tableName) };
            return (int.Parse(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CMS_CheckHas", commandParameters).ToString()) == 1);
        }
    }
}

