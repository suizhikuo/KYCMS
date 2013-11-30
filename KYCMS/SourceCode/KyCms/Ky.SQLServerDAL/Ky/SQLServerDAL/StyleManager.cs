namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class StyleManager : IStyle
    {
        public bool AddSearchStyle(int modelId, string content)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@modelid", SqlDbType.Int), new SqlParameter("@content", SqlDbType.NText) };
            commandParameters[0].Value = modelId;
            commandParameters[1].Value = content;
            return (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Style_AddSearchStyle", commandParameters) > 0);
        }

        public void AddStyle(M_Style mStyle)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@StyleCategoryId", SqlDbType.Int), new SqlParameter("@Name", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NVarChar), new SqlParameter("@Type", SqlDbType.Int) };
            commandParameters[0].Value = mStyle.StyleCategoryId;
            commandParameters[1].Value = mStyle.Name;
            commandParameters[2].Value = mStyle.Content;
            commandParameters[3].Value = mStyle.Type;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_Style_ADD", commandParameters);
        }

        public void Delete(int styleId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@StyleId", SqlDbType.Int) };
            commandParameters[0].Value = styleId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Style_Delete", commandParameters);
        }

        public string Get_Channel_Name(int ChId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ChId", SqlDbType.Int) };
            commandParameters[0].Value = ChId;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Channel_GetName", commandParameters);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0]["ChName"].ToString();
            }
            return string.Empty;
        }

        public DataTable GetAllStyle()
        {
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Style_GetAll", null);
        }

        public DataRow GetSearchStyle(int modelId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@modelid", modelId) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Style_GetSearchStyle", commandParameters);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0];
            }
            return null;
        }

        public M_Style GetStyle(int styleId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@StyleID", SqlDbType.Int) };
            commandParameters[0].Value = styleId;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_Style_GetId", commandParameters);
            M_Style style = new M_Style();
            if (table.Rows.Count > 0)
            {
                style.StyleCategoryId = int.Parse(table.Rows[0]["StyleCategoryId"].ToString());
                style.Name = table.Rows[0]["Name"].ToString();
                style.Content = table.Rows[0]["Content"].ToString();
                style.Type = int.Parse(table.Rows[0]["Type"].ToString());
            }
            else
            {
                return null;
            }
            return style;
        }

        public DataTable GetStyleByModel(int modelId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@type", SqlDbType.Int) };
            commandParameters[0].Value = modelId;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Style_GetByModelId", commandParameters);
        }

        public string GetStyleContent(int styleId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@StyleID", SqlDbType.Int) };
            commandParameters[0].Value = styleId;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Style_ConById", commandParameters);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0]["content"].ToString();
            }
            return "";
        }

        public DataTable GetStyleList(int styleId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@StyleCategoryId", SqlDbType.Int) };
            commandParameters[0].Value = styleId;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Style_GetList", commandParameters);
        }

        public DataTable GetStyleNameList(string labelName, int pageIndex, int pageSize, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@labelName", SqlDbType.VarChar), new SqlParameter("@CursorPage", SqlDbType.Int), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@RecordCount", SqlDbType.Int) };
            commandParameters[0].Value = labelName;
            commandParameters[1].Value = pageIndex;
            commandParameters[2].Value = pageSize;
            commandParameters[3].Value = 0;
            commandParameters[3].Direction = ParameterDirection.Output;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_StyleContent_GetLbcategoryNameList", commandParameters);
            recordCount = int.Parse(commandParameters[3].Value.ToString());
            return table;
        }

        public DataTable StyleCategory_GetList(int parentId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ParentID", SqlDbType.Int) };
            commandParameters[0].Value = parentId;
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_StyleCategory_GetList", commandParameters);
        }

        public int StyleIDGetStylegoryId(int styleId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@StyleID", SqlDbType.Int) };
            commandParameters[0].Value = styleId;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Style_StyleIDGetStylegoryId", commandParameters);
            if (table.Rows.Count > 0)
            {
                return int.Parse(table.Rows[0]["StyleCategoryId"].ToString());
            }
            return 0;
        }

        public bool UpdateSearchStyle(int modelId, string content)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@modelid", SqlDbType.Int), new SqlParameter("@content", SqlDbType.NText) };
            commandParameters[0].Value = modelId;
            commandParameters[1].Value = content;
            return (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Style_UpdateSearchStyle", commandParameters) > 0);
        }

        public void UpdateStyle(M_Style mStyle)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@StyleCategoryId", SqlDbType.Int), new SqlParameter("@Name", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NVarChar), new SqlParameter("@Type", SqlDbType.Int), new SqlParameter("@StyleID", SqlDbType.Int) };
            commandParameters[0].Value = mStyle.StyleCategoryId;
            commandParameters[1].Value = mStyle.Name;
            commandParameters[2].Value = mStyle.Content;
            commandParameters[3].Value = mStyle.Type;
            commandParameters[4].Value = mStyle.StyleID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "UP_Style_Update", commandParameters);
        }
    }
}

