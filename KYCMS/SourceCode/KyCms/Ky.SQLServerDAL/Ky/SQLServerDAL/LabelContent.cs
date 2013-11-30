namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class LabelContent : ILabelContent
    {
        public void Add(M_LabelContent model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Name", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.Text), new SqlParameter("@LbCategoryId", SqlDbType.Int), new SqlParameter("@ModeType", SqlDbType.Int), new SqlParameter("@LabelCategoryID", SqlDbType.Int), new SqlParameter("@AnomalyStyle", SqlDbType.Text) };
            commandParameters[0].Value = model.Name;
            commandParameters[1].Value = model.Content;
            commandParameters[2].Value = model.LbCategoryId;
            commandParameters[3].Value = model.ModeType;
            commandParameters[4].Value = 0;
            commandParameters[5].Value = model.AnomalyStyle;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_LabelContent_Set", commandParameters);
        }

        public void Delete(string labelCategoryId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@LabelCategoryID", SqlDbType.VarChar, 500) };
            commandParameters[0].Value = labelCategoryId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_LabelContent_Delete", commandParameters);
        }

        public string GetLabelContent(int labelCategoryId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@LabelCategoryID", SqlDbType.Int) };
            commandParameters[0].Value = labelCategoryId;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_LabelContent_GetContent", commandParameters);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0]["Content"].ToString();
            }
            return string.Empty;
        }

        public string GetLabelContentByName(string name)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Name", SqlDbType.NVarChar) };
            commandParameters[0].Value = name;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_LabelContent_ConByName", commandParameters);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0]["Content"].ToString();
            }
            return "";
        }

        public M_LabelContent GetLabelContentId(int labelCagegoryId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@LabelCategoryID", SqlDbType.Int) };
            commandParameters[0].Value = labelCagegoryId;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_LabelContent_GetInfo", commandParameters);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                M_LabelContent content = new M_LabelContent();
                content.Name = row["Name"].ToString();
                content.Content = row["Content"].ToString();
                content.LbCategoryId = int.Parse(row["LbCategoryId"].ToString());
                content.AnomalyStyle = row["AnomalyStyle"].ToString();
                return content;
            }
            return null;
        }

        public DataTable GetLabelList()
        {
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_LabelContent_GetList", null);
        }

        public DataTable GetLbCategoryIdList(int labelCagegoryId, int cursorPage, int pageSize, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@LbCategoryId", SqlDbType.Int), new SqlParameter("@CursorPage", SqlDbType.Int), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@RecordCount", SqlDbType.Int) };
            commandParameters[0].Value = labelCagegoryId;
            commandParameters[1].Value = cursorPage;
            commandParameters[2].Value = pageSize;
            commandParameters[3].Value = 0;
            commandParameters[3].Direction = ParameterDirection.Output;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_LabelContent_GetLbcategoryIdList", commandParameters);
            recordCount = int.Parse(commandParameters[3].Value.ToString());
            return table;
        }

        public DataTable GetLbCategoryNameList(string labelName, int pageIndex, int pageSize, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@labelName", SqlDbType.VarChar), new SqlParameter("@CursorPage", SqlDbType.Int), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@RecordCount", SqlDbType.Int) };
            commandParameters[0].Value = labelName;
            commandParameters[1].Value = pageIndex;
            commandParameters[2].Value = pageSize;
            commandParameters[3].Value = 0;
            commandParameters[3].Direction = ParameterDirection.Output;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_LabelContent_GetLbcategoryNameList", commandParameters);
            recordCount = int.Parse(commandParameters[3].Value.ToString());
            return table;
        }

        public void Update(M_LabelContent model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Name", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.Text), new SqlParameter("@LbCategoryId", SqlDbType.Int), new SqlParameter("@ModeType", SqlDbType.Int), new SqlParameter("@LabelCategoryID", SqlDbType.Int), new SqlParameter("@AnomalyStyle", SqlDbType.Text) };
            commandParameters[0].Value = model.Name;
            commandParameters[1].Value = model.Content;
            commandParameters[2].Value = model.LbCategoryId;
            commandParameters[3].Value = model.ModeType;
            commandParameters[4].Value = model.LabelCategoryID;
            commandParameters[5].Value = model.AnomalyStyle;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_LabelContent_Set", commandParameters);
        }
    }
}

