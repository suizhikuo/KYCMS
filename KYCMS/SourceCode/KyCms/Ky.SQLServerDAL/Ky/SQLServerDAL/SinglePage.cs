namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class SinglePage : ISinglePage
    {
        public int Add(M_SinglePage model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Name", SqlDbType.NVarChar, 100), new SqlParameter("@FolderPath", SqlDbType.NVarChar, 50), new SqlParameter("@FileName", SqlDbType.NVarChar, 100), new SqlParameter("@FileExtend", SqlDbType.NVarChar, 50), new SqlParameter("@TemplatePath", SqlDbType.NVarChar, 150), new SqlParameter("@Content", SqlDbType.NVarChar, 200), new SqlParameter("@AddTime", SqlDbType.DateTime) };
            commandParameters[0].Value = model.Name;
            commandParameters[1].Value = model.FolderPath;
            commandParameters[2].Value = model.FileName;
            commandParameters[3].Value = model.FileExtend;
            commandParameters[4].Value = model.TemplatePath;
            commandParameters[5].Value = model.Content;
            commandParameters[6].Value = model.AddTime;
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_SinglePage_Add", commandParameters));
        }

        public void Delete(int SingleId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SingleId", SqlDbType.Int, 4) };
            commandParameters[0].Value = SingleId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_SinglePage_Del", commandParameters);
        }

        public DataSet GetList(int currPage, int pageSize)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CurrPage", SqlDbType.Int, 4), new SqlParameter("@PageSize", SqlDbType.Int, 4) };
            commandParameters[0].Value = currPage;
            commandParameters[1].Value = pageSize;
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_SinglePage_GetList", commandParameters);
        }

        public M_SinglePage GetModel(int SingleId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SingleId", SqlDbType.Int, 4) };
            commandParameters[0].Value = SingleId;
            M_SinglePage page = new M_SinglePage();
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_SinglePage_GetModel", commandParameters);
            page.SingleId = SingleId;
            if (set.Tables[0].Rows.Count > 0)
            {
                page.Name = set.Tables[0].Rows[0]["Name"].ToString();
                page.FolderPath = set.Tables[0].Rows[0]["FolderPath"].ToString();
                page.FileName = set.Tables[0].Rows[0]["FileName"].ToString();
                page.FileExtend = set.Tables[0].Rows[0]["FileExtend"].ToString();
                page.TemplatePath = set.Tables[0].Rows[0]["TemplatePath"].ToString();
                page.Content = set.Tables[0].Rows[0]["Content"].ToString();
                if (set.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    page.AddTime = DateTime.Parse(set.Tables[0].Rows[0]["AddTime"].ToString());
                }
                return page;
            }
            return null;
        }

        public void Update(M_SinglePage model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SingleId", SqlDbType.Int, 4), new SqlParameter("@Name", SqlDbType.NVarChar, 100), new SqlParameter("@FolderPath", SqlDbType.NVarChar, 50), new SqlParameter("@FileName", SqlDbType.NVarChar, 100), new SqlParameter("@FileExtend", SqlDbType.NVarChar, 50), new SqlParameter("@TemplatePath", SqlDbType.NVarChar, 150), new SqlParameter("@Content", SqlDbType.NVarChar, 200), new SqlParameter("@AddTime", SqlDbType.DateTime) };
            commandParameters[0].Value = model.SingleId;
            commandParameters[1].Value = model.Name;
            commandParameters[2].Value = model.FolderPath;
            commandParameters[3].Value = model.FileName;
            commandParameters[4].Value = model.FileExtend;
            commandParameters[5].Value = model.TemplatePath;
            commandParameters[6].Value = model.Content;
            commandParameters[7].Value = model.AddTime;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_SinglePage_Update", commandParameters);
        }
    }
}

