namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class AdCategory : IAdCategory
    {
        public void Add(M_AdCategory model)
        {
            this.ExcuteSet(1, model);
        }

        public void Delete(int AdCategoryId)
        {
            M_AdCategory model = new M_AdCategory();
            model.AdCategoryId = AdCategoryId;
            this.ExcuteSet(3, model);
        }

        private void ExcuteSet(int type, M_AdCategory model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.Int, 4), new SqlParameter("@AdCategoryId", SqlDbType.Int, 4), new SqlParameter("@CategoryName", SqlDbType.NVarChar, 50), new SqlParameter("@IsDisabled", SqlDbType.Int, 4), new SqlParameter("@WidthHeigth", SqlDbType.VarChar, 12), new SqlParameter("@DisplayType", SqlDbType.Int, 4), new SqlParameter("@Description", SqlDbType.NVarChar, 50) };
            commandParameters[0].Value = type;
            commandParameters[1].Value = model.AdCategoryId;
            commandParameters[2].Value = (model.CategoryName == null) ? "" : model.CategoryName;
            commandParameters[3].Value = model.IsDisabled;
            commandParameters[4].Value = (model.WidthHeigth == null) ? "||" : model.WidthHeigth;
            commandParameters[5].Value = model.DisplayType;
            commandParameters[6].Value = (model.Description == null) ? "" : model.Description;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_AdCategory_Set", commandParameters);
        }

        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.Int, 4), new SqlParameter("@AdCategoryId", SqlDbType.Int, 4), new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@PageIndex", SqlDbType.Int, 4), new SqlParameter("@WhereString", SqlDbType.NVarChar, 0x7d0) };
            commandParameters[0].Value = 2;
            commandParameters[1].Value = 0;
            commandParameters[2].Value = PageSize;
            commandParameters[3].Value = PageIndex;
            commandParameters[4].Value = strWhere;
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_AdCategory_Get", commandParameters);
        }

        public M_AdCategory GetModel(int AdCategoryId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.Int, 4), new SqlParameter("@AdCategoryId", SqlDbType.Int, 4), new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@PageIndex", SqlDbType.Int, 4), new SqlParameter("@WhereString", SqlDbType.NVarChar, 0x7d0) };
            commandParameters[0].Value = 1;
            commandParameters[1].Value = AdCategoryId;
            commandParameters[4].Value = "";
            M_AdCategory category = new M_AdCategory();
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_AdCategory_Get", commandParameters);
            category.AdCategoryId = AdCategoryId;
            if (table.Rows.Count > 0)
            {
                category.CategoryName = table.Rows[0]["CategoryName"].ToString();
                if (table.Rows[0]["IsDisabled"].ToString() != "")
                {
                    category.IsDisabled = int.Parse(table.Rows[0]["IsDisabled"].ToString());
                }
                category.WidthHeigth = table.Rows[0]["WidthHeigth"].ToString();
                if (table.Rows[0]["DisplayType"].ToString() != "")
                {
                    category.DisplayType = int.Parse(table.Rows[0]["DisplayType"].ToString());
                }
                category.Description = table.Rows[0]["Description"].ToString();
                return category;
            }
            return null;
        }

        public void Update(M_AdCategory model)
        {
            this.ExcuteSet(2, model);
        }
    }
}

