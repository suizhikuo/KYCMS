namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Enterprise : IEnterprise
    {
        public void AddEnterPrise(M_Enterprise model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int, 4), new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("@Title", SqlDbType.NVarChar), new SqlParameter("@Conetent", SqlDbType.Text), new SqlParameter("@AddTime", SqlDbType.NVarChar), new SqlParameter("@TypeId", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.Id;
            commandParameters[1].Value = model.UserId;
            commandParameters[2].Value = model.Title;
            commandParameters[3].Value = model.Conetent;
            commandParameters[4].Value = model.AddTime;
            commandParameters[5].Value = model.TypeId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_EnterPrise_Set", commandParameters);
        }

        public void DeleteEnterprise(string idStr, int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@IdStr", idStr), new SqlParameter("@UserId", userId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Enterprise_Delete", commandParameters);
        }

        public M_Enterprise GetEnterpriseById(int Id, int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", Id), new SqlParameter("@UserId", userId) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Enterprise_GetById", commandParameters);
            M_Enterprise enterprise = new M_Enterprise();
            if (table.Rows.Count > 0)
            {
                enterprise.Id = Id;
                enterprise.UserId = int.Parse(table.Rows[0]["UserId"].ToString());
                enterprise.TypeId = int.Parse(table.Rows[0]["TypeId"].ToString());
                enterprise.Title = table.Rows[0]["Title"].ToString();
                enterprise.Conetent = table.Rows[0]["Conetent"].ToString();
                enterprise.AddTime = table.Rows[0]["AddTime"].ToString();
                return enterprise;
            }
            return null;
        }

        public DataTable GetEnterpriseByUserId(int userId, int pageIndex, int pageSize, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", userId), new SqlParameter("@PageIndex", pageIndex), new SqlParameter("@PageSize", pageSize) };
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Enterprise_GetByUserId", commandParameters);
            recordCount = Convert.ToInt32(set.Tables[1].Rows[0][0]);
            return set.Tables[0];
        }

        public void UpdateEnterPrise(M_Enterprise model)
        {
            this.AddEnterPrise(model);
        }
    }
}

