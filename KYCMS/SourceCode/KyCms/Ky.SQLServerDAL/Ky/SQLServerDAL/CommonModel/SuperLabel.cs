namespace Ky.SQLServerDAL.CommonModel
{
    using Ky.Common;
    using Ky.DALFactory;
    using Ky.Model;
    using Ky.SQLServerDAL;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class SuperLabel : ISuperLabel
    {
        public void Add(M_SuperLabel model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Name", SqlDbType.NVarChar), new SqlParameter("@LbCategoryName", SqlDbType.NVarChar), new SqlParameter("@LbCategoryId", SqlDbType.Int, 4), new SqlParameter("@DataBaseType", SqlDbType.Int, 4), new SqlParameter("@SuperDes", SqlDbType.NVarChar), new SqlParameter("@IsUnlockPage", SqlDbType.Bit, 1), new SqlParameter("@HostTable", SqlDbType.NVarChar), new SqlParameter("@GuestTable", SqlDbType.NVarChar), new SqlParameter("@SqlStr", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@AddTime", SqlDbType.DateTime), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@IsHtml", SqlDbType.Bit, 1), new SqlParameter("@NumColumns", SqlDbType.Int), new SqlParameter("@DataBaseConn", SqlDbType.NVarChar) };
            commandParameters[0].Value = model.Name;
            commandParameters[1].Value = model.LbCategoryName;
            commandParameters[2].Value = model.LbCategoryId;
            commandParameters[3].Value = model.DataBaseType;
            commandParameters[4].Value = model.SuperDes;
            commandParameters[5].Value = model.IsUnlockPage;
            commandParameters[6].Value = model.HostTable;
            commandParameters[7].Value = model.GuestTable;
            commandParameters[8].Value = model.SqlStr;
            commandParameters[9].Value = model.Content;
            commandParameters[10].Value = model.AddTime;
            commandParameters[11].Value = model.PageSize;
            commandParameters[12].Value = model.IsHtml;
            commandParameters[13].Value = model.NumColumns;
            commandParameters[14].Value = model.DataBaseConn;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_SuperLabel_Add", commandParameters);
        }

        public int CheckName(string Name)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Name", SqlDbType.NVarChar) };
            commandParameters[0].Value = Name;
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_SuperLabel_CheckName", commandParameters));
        }

        public DataTable CheckSql(string sql)
        {
            try
            {
                DataTable table = new DataTable();
                return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.Text, Ky.Common.Function.SqlFiltrate(sql), new SqlParameter[0]);
            }
            catch
            {
                return null;
            }
        }

        public DataTable DataBaseTypeSql(string LinkPath, string DataBaseType, string sql)
        {
            SqlRun run = new SqlRun(LinkPath, DataBaseType);
            return run.RunSqlDs(sql, DataBaseType).Tables[0];
        }

        public void Delete(int SuperId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SuperId", SqlDbType.Int, 4) };
            commandParameters[0].Value = SuperId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_SuperLabel_Delete", commandParameters);
        }

        public DataSet GetList(int currPage, int pageSize)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CurrPage", SqlDbType.Int, 4), new SqlParameter("@PageSize", SqlDbType.Int, 4) };
            commandParameters[0].Value = currPage;
            commandParameters[1].Value = pageSize;
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_SuperLabel_GetList", commandParameters);
        }

        public M_SuperLabel GetModel(int SuperId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SuperId", SqlDbType.Int, 4) };
            commandParameters[0].Value = SuperId;
            M_SuperLabel label = new M_SuperLabel();
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_SuperLabel_GetModel", commandParameters);
            label.SuperId = SuperId;
            if (set.Tables[0].Rows.Count > 0)
            {
                label.Name = set.Tables[0].Rows[0]["Name"].ToString();
                label.LbCategoryName = set.Tables[0].Rows[0]["LbCategoryName"].ToString();
                if (set.Tables[0].Rows[0]["LbCategoryId"].ToString() != "")
                {
                    label.LbCategoryId = int.Parse(set.Tables[0].Rows[0]["LbCategoryId"].ToString());
                }
                if (set.Tables[0].Rows[0]["DataBaseType"].ToString() != "")
                {
                    label.DataBaseType = int.Parse(set.Tables[0].Rows[0]["DataBaseType"].ToString());
                }
                label.SuperDes = set.Tables[0].Rows[0]["SuperDes"].ToString();
                if (set.Tables[0].Rows[0]["IsUnlockPage"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsUnlockPage"].ToString() == "1") || (set.Tables[0].Rows[0]["IsUnlockPage"].ToString().ToLower() == "true"))
                    {
                        label.IsUnlockPage = true;
                    }
                    else
                    {
                        label.IsUnlockPage = false;
                    }
                }
                label.HostTable = set.Tables[0].Rows[0]["HostTable"].ToString();
                label.GuestTable = set.Tables[0].Rows[0]["GuestTable"].ToString();
                label.SqlStr = set.Tables[0].Rows[0]["SqlStr"].ToString();
                label.Content = set.Tables[0].Rows[0]["Content"].ToString();
                if (set.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    label.AddTime = DateTime.Parse(set.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (set.Tables[0].Rows[0]["PageSize"].ToString() != "")
                {
                    label.PageSize = int.Parse(set.Tables[0].Rows[0]["PageSize"].ToString());
                }
                if (set.Tables[0].Rows[0]["NumColumns"].ToString() != "")
                {
                    label.NumColumns = int.Parse(set.Tables[0].Rows[0]["NumColumns"].ToString());
                }
                if (set.Tables[0].Rows[0]["IsHtml"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsHtml"].ToString() == "1") || (set.Tables[0].Rows[0]["IsHtml"].ToString().ToLower() == "true"))
                    {
                        label.IsHtml = true;
                    }
                    else
                    {
                        label.IsHtml = false;
                    }
                }
                label.DataBaseConn = set.Tables[0].Rows[0]["DataBaseConn"].ToString();
                return label;
            }
            return null;
        }

        public int GetSuperId(string Name)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Name", SqlDbType.NVarChar) };
            commandParameters[0].Value = Name;
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_SuperLabel_GetSuperId", commandParameters));
        }

        public bool IsModelTable(string TableName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TableName", SqlDbType.NVarChar) };
            commandParameters[0].Value = TableName;
            return (Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_SuperLabel_IsModelTable", commandParameters)) == 1);
        }

        public DataSet SuperLabelOut(string InSuperId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@InSuperId", SqlDbType.NVarChar) };
            commandParameters[0].Value = InSuperId;
            return SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_SuperLabel_Out", commandParameters);
        }

        public void Update(M_SuperLabel model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SuperId", SqlDbType.Int, 4), new SqlParameter("@Name", SqlDbType.NVarChar), new SqlParameter("@LbCategoryName", SqlDbType.NVarChar), new SqlParameter("@LbCategoryId", SqlDbType.Int, 4), new SqlParameter("@DataBaseType", SqlDbType.Int, 4), new SqlParameter("@SuperDes", SqlDbType.NVarChar), new SqlParameter("@IsUnlockPage", SqlDbType.Bit, 1), new SqlParameter("@HostTable", SqlDbType.NVarChar), new SqlParameter("@GuestTable", SqlDbType.NVarChar), new SqlParameter("@SqlStr", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@AddTime", SqlDbType.DateTime), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@NumColumns", SqlDbType.Int), new SqlParameter("@IsHtml", SqlDbType.Bit, 1), new SqlParameter("@DataBaseConn", SqlDbType.NVarChar) };
            commandParameters[0].Value = model.SuperId;
            commandParameters[1].Value = model.Name;
            commandParameters[2].Value = model.LbCategoryName;
            commandParameters[3].Value = model.LbCategoryId;
            commandParameters[4].Value = model.DataBaseType;
            commandParameters[5].Value = model.SuperDes;
            commandParameters[6].Value = model.IsUnlockPage;
            commandParameters[7].Value = model.HostTable;
            commandParameters[8].Value = model.GuestTable;
            commandParameters[9].Value = model.SqlStr;
            commandParameters[10].Value = model.Content;
            commandParameters[11].Value = model.AddTime;
            commandParameters[12].Value = model.PageSize;
            commandParameters[13].Value = model.NumColumns;
            commandParameters[14].Value = model.IsHtml;
            commandParameters[15].Value = model.DataBaseConn;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_SuperLabel_Update", commandParameters);
        }
    }
}

