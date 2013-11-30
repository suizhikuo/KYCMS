namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Link : ILink
    {
        public void Add(M_Link model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@LinkType", SqlDbType.Int, 4), new SqlParameter("@LinkCategory", SqlDbType.NVarChar), new SqlParameter("@SiteName", SqlDbType.NVarChar), new SqlParameter("@SiteUrl", SqlDbType.VarChar, 255), new SqlParameter("@SiteLogo", SqlDbType.VarChar, 255), new SqlParameter("@OwnerName", SqlDbType.NVarChar), new SqlParameter("@Email", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@AddTime", SqlDbType.DateTime, 8), new SqlParameter("@Status", SqlDbType.Int, 4), new SqlParameter("@IsDisable", SqlDbType.Bit, 1) };
            commandParameters[0].Value = model.LinkType;
            commandParameters[1].Value = model.LinkCategory;
            commandParameters[2].Value = model.SiteName;
            commandParameters[3].Value = model.SiteUrl;
            commandParameters[4].Value = model.SiteLogo;
            commandParameters[5].Value = model.OwnerName;
            commandParameters[6].Value = model.Email;
            commandParameters[7].Value = model.Description;
            commandParameters[8].Value = model.AddTime;
            commandParameters[9].Value = model.Status;
            commandParameters[10].Value = model.IsDisable;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Link_Add", commandParameters);
        }

        public DataSet GetList(int PageSize, int PageIndex, string whereString)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@pageSize", SqlDbType.Int, 4), new SqlParameter("@pageIndex", SqlDbType.Int, 4), new SqlParameter("@whereString", SqlDbType.NVarChar) };
            commandParameters[0].Value = PageSize;
            commandParameters[1].Value = PageIndex;
            commandParameters[2].Value = whereString;
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Link_GetList", commandParameters);
        }

        public M_Link GetModel(int LinkId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@LinkId", SqlDbType.Int, 4) };
            commandParameters[0].Value = LinkId;
            M_Link link = new M_Link();
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Link_GetModel", commandParameters);
            link.LinkId = LinkId;
            if (table.Rows.Count > 0)
            {
                link.LinkType = Convert.ToInt32(table.Rows[0]["LinkType"]);
                link.LinkCategory = table.Rows[0]["LinkCategory"].ToString();
                link.SiteName = table.Rows[0]["SiteName"].ToString();
                link.SiteUrl = table.Rows[0]["SiteUrl"].ToString();
                link.SiteLogo = table.Rows[0]["SiteLogo"].ToString();
                link.OwnerName = table.Rows[0]["OwnerName"].ToString();
                link.Email = table.Rows[0]["Email"].ToString();
                link.Description = table.Rows[0]["Description"].ToString();
                link.AddTime = DateTime.Parse(table.Rows[0]["AddTime"].ToString());
                link.Status = Convert.ToInt32(table.Rows[0]["Status"]);
                link.IsDisable = Convert.ToBoolean(table.Rows[0]["IsDisable"]);
                return link;
            }
            return null;
        }

        public void Set(int LinkId, int Type)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@LinkId", SqlDbType.Int, 4), new SqlParameter("@Type", SqlDbType.Int, 4) };
            commandParameters[0].Value = LinkId;
            commandParameters[1].Value = Type;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Link_Set", commandParameters);
        }

        public void Update(M_Link model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@LinkId", SqlDbType.Int, 4), new SqlParameter("@LinkType", SqlDbType.Int, 4), new SqlParameter("@LinkCategory", SqlDbType.NVarChar), new SqlParameter("@SiteName", SqlDbType.NVarChar), new SqlParameter("@SiteUrl", SqlDbType.VarChar, 255), new SqlParameter("@SiteLogo", SqlDbType.VarChar, 255), new SqlParameter("@OwnerName", SqlDbType.NVarChar), new SqlParameter("@Email", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@AddTime", SqlDbType.DateTime, 8), new SqlParameter("@Status", SqlDbType.Int, 4), new SqlParameter("@IsDisable", SqlDbType.Bit, 1) };
            commandParameters[0].Value = model.LinkId;
            commandParameters[1].Value = model.LinkType;
            commandParameters[2].Value = model.LinkCategory;
            commandParameters[3].Value = model.SiteName;
            commandParameters[4].Value = model.SiteUrl;
            commandParameters[5].Value = model.SiteLogo;
            commandParameters[6].Value = model.OwnerName;
            commandParameters[7].Value = model.Email;
            commandParameters[8].Value = model.Description;
            commandParameters[9].Value = model.AddTime;
            commandParameters[10].Value = model.Status;
            commandParameters[11].Value = model.IsDisable;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Link_Update", commandParameters);
        }
    }
}

