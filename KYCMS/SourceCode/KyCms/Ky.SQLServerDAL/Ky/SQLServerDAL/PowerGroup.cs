namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class PowerGroup : IPowerGroup
    {
        public void Del(int PowerId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TypeId", SqlDbType.Int) };
            commandParameters[0].Value = 4;
            SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_PowerGroup", commandParameters);
        }

        public void Insert(M_PowerGroup model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@PowerName", SqlDbType.NVarChar, 50), new SqlParameter("@PowerColumn", SqlDbType.NText), new SqlParameter("@PowerChannel", SqlDbType.NText), new SqlParameter("@PowerAuditing", SqlDbType.NText), new SqlParameter("@PowerModel", SqlDbType.NVarChar, 50), new SqlParameter("@AddDate", SqlDbType.DateTime), new SqlParameter("@TypeId", SqlDbType.Int), new SqlParameter("@PowerContent", SqlDbType.NText) };
            commandParameters[0].Value = model.PowerName;
            commandParameters[1].Value = model.PowerColumn;
            commandParameters[2].Value = model.PowerChannel;
            commandParameters[3].Value = model.PowerAuditing;
            commandParameters[4].Value = model.PowerModel;
            commandParameters[5].Value = model.AddDate;
            commandParameters[6].Value = model.TypeId;
            commandParameters[7].Value = model.PowerContent;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_PowerGroup", commandParameters);
        }

        public DataTable Manage()
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TypeId", SqlDbType.Int) };
            commandParameters[0].Value = 1;
            DataTable table = new DataTable();
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_PowerGroup", commandParameters);
        }

        public DataTable PowerColumnNameList()
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TypeId", SqlDbType.Int) };
            commandParameters[0].Value = 6;
            DataTable table = new DataTable();
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_PowerGroup", commandParameters);
        }

        public DataTable PowerModelList()
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TypeId", SqlDbType.Int) };
            commandParameters[0].Value = 7;
            DataTable table = new DataTable();
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_PowerGroup", commandParameters);
        }

        public M_PowerGroup Show(int PowerId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TypeId", SqlDbType.Int), new SqlParameter("@PowerId", SqlDbType.Int) };
            commandParameters[0].Value = 2;
            commandParameters[1].Value = PowerId;
            DataTable table = new DataTable();
            table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_PowerGroup", commandParameters);
            if (table.Rows.Count > 0)
            {
                M_PowerGroup group = new M_PowerGroup();
                group.PowerName = table.Rows[0]["PowerName"].ToString();
                group.PowerColumn = table.Rows[0]["PowerColumn"].ToString();
                group.PowerChannel = table.Rows[0]["PowerChannel"].ToString();
                group.PowerAuditing = table.Rows[0]["PowerAuditing"].ToString();
                group.PowerModel = table.Rows[0]["PowerModel"].ToString();
                group.PowerContent = table.Rows[0]["PowerContent"].ToString();
                return group;
            }
            return null;
        }

        public void Update(M_PowerGroup model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@PowerName", SqlDbType.NVarChar, 50), new SqlParameter("@PowerColumn", SqlDbType.NText), new SqlParameter("@PowerChannel", SqlDbType.NText), new SqlParameter("@PowerAuditing", SqlDbType.NText), new SqlParameter("@PowerModel", SqlDbType.NVarChar, 50), new SqlParameter("@AddDate", SqlDbType.DateTime), new SqlParameter("@TypeId", SqlDbType.Int), new SqlParameter("@PowerId", SqlDbType.Int), new SqlParameter("@PowerContent", SqlDbType.NText) };
            commandParameters[0].Value = model.PowerName;
            commandParameters[1].Value = model.PowerColumn;
            commandParameters[2].Value = model.PowerChannel;
            commandParameters[3].Value = model.PowerAuditing;
            commandParameters[4].Value = model.PowerModel;
            commandParameters[5].Value = model.AddDate;
            commandParameters[6].Value = model.TypeId;
            commandParameters[7].Value = model.PowerId;
            commandParameters[8].Value = model.PowerContent;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_PowerGroup", commandParameters);
        }
    }
}

