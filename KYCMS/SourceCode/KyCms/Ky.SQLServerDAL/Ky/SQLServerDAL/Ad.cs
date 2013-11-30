namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Ad : IAd
    {
        public void Add(M_Ad model)
        {
            this.ExcuteSet(1, model);
        }

        public void Delete(int AdId)
        {
            M_Ad model = new M_Ad();
            model.AdId = AdId;
            model.EndTime = DateTime.Now;
            this.ExcuteSet(3, model);
        }

        private void ExcuteSet(int type, M_Ad model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.Int, 4), new SqlParameter("@AdId", SqlDbType.Int, 4), new SqlParameter("@CategoryId", SqlDbType.VarChar, 100), new SqlParameter("@AdName", SqlDbType.NVarChar), new SqlParameter("@AdType", SqlDbType.Int, 4), new SqlParameter("@Content", SqlDbType.NVarChar), new SqlParameter("@EndTime", SqlDbType.DateTime), new SqlParameter("@Weight", SqlDbType.Int, 4), new SqlParameter("@HitCount", SqlDbType.Int, 4) };
            commandParameters[0].Value = type;
            commandParameters[1].Value = model.AdId;
            commandParameters[2].Value = (model.CategoryId == null) ? "" : model.CategoryId;
            commandParameters[3].Value = (model.AdName == null) ? "" : model.AdName;
            commandParameters[4].Value = model.AdType;
            commandParameters[5].Value = (model.Content == null) ? "" : model.Content;
            commandParameters[6].Value = model.EndTime;
            commandParameters[7].Value = model.Weight;
            commandParameters[8].Value = model.HitCount;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Ad_Set", commandParameters);
        }

        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.Int, 4), new SqlParameter("@AdId", SqlDbType.Int, 4), new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@PageIndex", SqlDbType.Int, 4), new SqlParameter("@WhereString", SqlDbType.NVarChar) };
            commandParameters[0].Value = 2;
            commandParameters[1].Value = 0;
            commandParameters[2].Value = PageSize;
            commandParameters[3].Value = PageIndex;
            commandParameters[4].Value = strWhere;
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Ad_Get", commandParameters);
        }

        public M_Ad GetModel(int AdId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.Int, 4), new SqlParameter("@AdId", SqlDbType.Int, 4), new SqlParameter("@PageSize", SqlDbType.Int, 4), new SqlParameter("@PageIndex", SqlDbType.Int, 4), new SqlParameter("@WhereString", SqlDbType.NVarChar) };
            commandParameters[0].Value = 1;
            commandParameters[1].Value = AdId;
            commandParameters[4].Value = "";
            M_Ad ad = new M_Ad();
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Ad_Get", commandParameters);
            ad.AdId = AdId;
            if (table.Rows.Count > 0)
            {
                ad.CategoryId = table.Rows[0]["CategoryId"].ToString();
                ad.AdName = table.Rows[0]["AdName"].ToString();
                if (table.Rows[0]["AdType"].ToString() != "")
                {
                    ad.AdType = int.Parse(table.Rows[0]["AdType"].ToString());
                }
                ad.Content = table.Rows[0]["Content"].ToString();
                if (table.Rows[0]["EndTime"].ToString() != "")
                {
                    ad.EndTime = DateTime.Parse(table.Rows[0]["EndTime"].ToString());
                }
                if (table.Rows[0]["Weight"].ToString() != "")
                {
                    ad.Weight = int.Parse(table.Rows[0]["Weight"].ToString());
                }
                if (table.Rows[0]["HitCount"].ToString() != "")
                {
                    ad.HitCount = int.Parse(table.Rows[0]["HitCount"].ToString());
                }
                return ad;
            }
            return null;
        }

        public void Update(M_Ad model)
        {
            this.ExcuteSet(2, model);
        }
    }
}

