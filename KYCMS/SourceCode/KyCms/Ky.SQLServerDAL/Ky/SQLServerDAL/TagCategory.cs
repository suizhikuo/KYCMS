namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class TagCategory : ITagCategory
    {
        public void Add(M_TagCategory model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TagCategoryId", model.TagCategoryId), new SqlParameter("@Name", model.Name), new SqlParameter("@Desc", model.Desc) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_TagCategory_Set", commandParameters);
        }

        public void Delete(int tagCategoryId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TagCategoryId", tagCategoryId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_TagCateogry_Delete", commandParameters);
        }

        public DataTable GetList()
        {
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_TagCategory_GetList", new SqlParameter[0]);
        }

        public void Update(M_TagCategory model)
        {
            this.Add(model);
        }
    }
}

