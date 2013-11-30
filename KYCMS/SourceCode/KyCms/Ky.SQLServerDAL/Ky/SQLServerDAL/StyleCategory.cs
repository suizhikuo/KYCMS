namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class StyleCategory : IStyleCategory
    {
        public void Add(M_StyleCategory model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Name", SqlDbType.NVarChar), new SqlParameter("ParentID", SqlDbType.Int), new SqlParameter("Desc", SqlDbType.NVarChar) };
            commandParameters[0].Value = model.Name;
            commandParameters[1].Value = model.ParentID;
            commandParameters[2].Value = model.Desc;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_StyleCategory_ADD", commandParameters);
        }

        public void Delete(int styleCategoryId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@StyleCategoryID", SqlDbType.Int) };
            commandParameters[0].Value = styleCategoryId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_StyleCategory_Delete ", commandParameters);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Style_DeleteAndStyleCategoryId", commandParameters);
        }

        private void GetListItem(int parentId, DataTable dt, int depth, DataTable dt2)
        {
            DataRow[] rowArray = dt.Select("ParentID=" + parentId);
            foreach (DataRow row in rowArray)
            {
                DataRow row2 = dt2.NewRow();
                int num = int.Parse(row["StyleCategoryID"].ToString());
                row2["StyleCategoryID"] = num;
                row2["Name"] = row["Name"];
                row2["ParentID"] = row["ParentID"];
                row2["Depth"] = depth;
                dt2.Rows.Add(row2);
                this.GetListItem(num, dt, depth + 1, dt2);
            }
        }

        public DataTable GetListItemByStyleId()
        {
            DataTable table = new DataTable();
            table.Columns.Add("StyleCategoryID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("ParentID", typeof(int));
            table.Columns.Add("Depth", typeof(int));
            DataTable dt = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_StyleCategoryid", null);
            this.GetListItem(0, dt, 0, table);
            dt.Dispose();
            return table;
        }

        public DataTable GetStyleCategoryList()
        {
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "", null);
        }

        public M_StyleCategory GetUpdateData(int styleCategoryId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@StyleCategoryID", SqlDbType.Int) };
            commandParameters[0].Value = styleCategoryId;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_StyleCategory_GetIdData", commandParameters);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                M_StyleCategory category = new M_StyleCategory();
                category.ParentID = int.Parse(row["ParentID"].ToString());
                category.Name = row["Name"].ToString();
                category.Desc = row["Desc"].ToString();
                return category;
            }
            return null;
        }

        public void Update(M_StyleCategory model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Name", SqlDbType.NVarChar), new SqlParameter("ParentID", SqlDbType.Int), new SqlParameter("Desc", SqlDbType.NVarChar), new SqlParameter("StyleCategoryId", SqlDbType.Int) };
            commandParameters[0].Value = model.Name;
            commandParameters[1].Value = model.ParentID;
            commandParameters[2].Value = model.Desc;
            commandParameters[3].Value = model.StyleCategoryID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_StyleCategory_Update", commandParameters);
        }
    }
}

