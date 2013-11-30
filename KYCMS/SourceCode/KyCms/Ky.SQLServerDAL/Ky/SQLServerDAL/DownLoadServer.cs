namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DownLoadServer : IDownLoadServer
    {
        public void AddData(M_DownLoadServerData model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TypeId", SqlDbType.Int, 4), new SqlParameter("@DownLoadServerName", SqlDbType.NVarChar), new SqlParameter("@DownLoadServerDir", SqlDbType.NVarChar), new SqlParameter("@IsOpened", SqlDbType.Bit, 1), new SqlParameter("@IsOuter", SqlDbType.Int, 4), new SqlParameter("@UnionId", SqlDbType.Text), new SqlParameter("@DayDownNum", SqlDbType.Int, 4), new SqlParameter("@AllDownNum", SqlDbType.Int, 4), new SqlParameter("@AddTime", SqlDbType.DateTime), new SqlParameter("@DownLoadServerDataId", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.TypeId;
            commandParameters[1].Value = model.DownLoadServerName;
            commandParameters[2].Value = model.DownLoadServerDir;
            commandParameters[3].Value = model.IsOpened;
            commandParameters[4].Value = model.IsOuter;
            commandParameters[5].Value = model.UnionId;
            commandParameters[6].Value = model.DayDownNum;
            commandParameters[7].Value = model.AllDownNum;
            commandParameters[8].Value = model.AddTime;
            commandParameters[9].Value = model.DownLoadServerDataId;
            SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoadServerData_Set", commandParameters);
        }

        public void AddType(M_DownLoadServerType model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TypeId", SqlDbType.Int, 4), new SqlParameter("@TypeName", SqlDbType.NVarChar) };
            commandParameters[0].Value = model.TypeId;
            commandParameters[1].Value = model.TypeName;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoadServerType_Set", commandParameters);
        }

        public void DeleteData(int downServerId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@DownLoadServerDataId", downServerId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoadServerData_Delete", commandParameters);
        }

        public void DeleteType(int typeId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TypeId", typeId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoadServerType_Delete", commandParameters);
        }

        public DataTable GetDataInfo(int DownServerId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@DownLoadServerDataId", DownServerId) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoadServerData_GetInfo", commandParameters);
        }

        public DataTable GetDataList(int typeId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TypeId", typeId) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoadServerData_GetList", commandParameters);
        }

        public DataTable GetTypeInfo(int typeId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TypeId", typeId) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoadServerType_GetInfo", commandParameters);
        }

        public DataTable GetTypeList()
        {
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoadServerType_GetList", new SqlParameter[0]);
        }

        public bool IsAllowDeleteType(int typeId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TypeId", SqlDbType.Int, 4) };
            commandParameters[0].Value = typeId;
            if (SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoad_IsAllowDeleteType", commandParameters) == null)
            {
                return false;
            }
            return true;
        }

        public void SetIsOpened(int downServerId, bool isOpened)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@DownServerId", downServerId), new SqlParameter("@IsOpened", isOpened) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoadServerData_SetIsOpened", commandParameters);
        }

        public void UpdateData(M_DownLoadServerData model)
        {
            this.AddData(model);
        }

        public void UpdateType(M_DownLoadServerType model)
        {
            this.AddType(model);
        }
    }
}

