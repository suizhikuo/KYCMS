namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class LbCategory : ILbCategory
    {
        public int Add(M_LbCategory model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("Name", SqlDbType.NVarChar), new SqlParameter("ParentID", SqlDbType.Int), new SqlParameter("Desc", SqlDbType.NVarChar), new SqlParameter("@LbCategoryID", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.Name;
            commandParameters[1].Value = model.ParentID;
            commandParameters[2].Value = model.Desc;
            commandParameters[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_LbCategory_ADD", commandParameters);
            return (int) commandParameters[3].Value;
        }

        public void Delete(int lbCategoryId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("lbCategoryID", SqlDbType.Int) };
            commandParameters[0].Value = lbCategoryId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_LbCategory_Delete", commandParameters);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_LbContent_DeleteLbCategoryId", commandParameters);
        }

        public M_LbCategory GetLabeCategoryIdData(int lbCategoryId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@LbCategoryID", SqlDbType.Int) };
            commandParameters[0].Value = lbCategoryId;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_LbCategory_GetIdData", commandParameters);
            if (table.Rows.Count > 0)
            {
                M_LbCategory category = new M_LbCategory();
                category.Name = table.Rows[0]["Name"].ToString();
                category.Desc = table.Rows[0]["Desc"].ToString();
                return category;
            }
            return null;
        }

        public DataTable GetLabelCategoryList(int parentId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ParentID", SqlDbType.Int) };
            commandParameters[0].Value = parentId;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_LbCategory_GetParentIDList", commandParameters);
        }

        private void GetListItem(int parentId, DataTable dt, int depth, DataTable dt2)
        {
            DataRow[] rowArray = dt.Select("ParentID=" + parentId);
            foreach (DataRow row in rowArray)
            {
                DataRow row2 = dt2.NewRow();
                int num = int.Parse(row["LbCategoryID"].ToString());
                row2["LbCategoryID"] = num;
                row2["Name"] = row["Name"];
                row2["ParentID"] = row["ParentID"];
                row2["Depth"] = depth;
                dt2.Rows.Add(row2);
                this.GetListItem(num, dt, depth + 1, dt2);
            }
        }

        public DataTable GetListItemLabelId()
        {
            DataTable table = new DataTable();
            table.Columns.Add("LbCategoryID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("ParentID", typeof(int));
            table.Columns.Add("Depth", typeof(int));
            DataTable dt = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_LbCategory_ID", null);
            this.GetListItem(0, dt, 0, table);
            dt.Dispose();
            return table;
        }

        public void Update(M_LbCategory model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Name", SqlDbType.NVarChar), new SqlParameter("@ParentID", SqlDbType.Int), new SqlParameter("@Desc", SqlDbType.NVarChar), new SqlParameter("@LbCategoryID", SqlDbType.Int) };
            commandParameters[0].Value = model.Name;
            commandParameters[1].Value = model.ParentID;
            commandParameters[2].Value = model.Desc;
            commandParameters[3].Value = model.LbCategoryID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_LbCategory_Update", commandParameters);
        }
    }
}

