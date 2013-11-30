namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class VoteCategory : IVoteCategory
    {
        public void Add(M_VoteCategory model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Name", SqlDbType.NVarChar, 200), new SqlParameter("@Type", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.Name;
            commandParameters[1].Value = 1;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_VoteCategory_Set", commandParameters);
        }

        public void Delete(int id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CategoryId", SqlDbType.Int, 4), new SqlParameter("@Type", SqlDbType.Int, 4) };
            commandParameters[0].Value = id;
            commandParameters[1].Value = 3;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_VoteCategory_Set", commandParameters);
        }

        public M_VoteCategory GetCategory(int id)
        {
            M_VoteCategory category = new M_VoteCategory();
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int, 4), new SqlParameter("@Type", SqlDbType.Int, 4) };
            commandParameters[0].Value = id;
            commandParameters[1].Value = 1;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_VoteCategory_Get", commandParameters);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                category.CategoryId = (int) row["CategoryId"];
                category.Name = row["Name"].ToString();
                return category;
            }
            return null;
        }

        public DataTable GetList()
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.Int, 4) };
            commandParameters[0].Value = 2;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_VoteCategory_Get", commandParameters);
        }

        public void Update(M_VoteCategory model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CategoryId", SqlDbType.Int, 4), new SqlParameter("@Name", SqlDbType.NVarChar, 200), new SqlParameter("@Type", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.CategoryId;
            commandParameters[1].Value = model.Name;
            commandParameters[2].Value = 2;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_VoteCategory_Set", commandParameters);
        }
    }
}

