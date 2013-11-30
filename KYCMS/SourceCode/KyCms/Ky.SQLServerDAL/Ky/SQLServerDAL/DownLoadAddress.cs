namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DownLoadAddress : IDownLoadAddress
    {
        public void Add(M_DownLoadAddress model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@DownLoadDataId", SqlDbType.Int, 4), new SqlParameter("@AddressNum", SqlDbType.Int, 4), new SqlParameter("@DownLoadServerID", SqlDbType.Int, 4), new SqlParameter("@AddressName", SqlDbType.NVarChar), new SqlParameter("@AddressPath", SqlDbType.NVarChar), new SqlParameter("@AddressId", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.DownLoadDataId;
            commandParameters[1].Value = model.AddressNum;
            commandParameters[2].Value = model.DownLoadServerID;
            commandParameters[3].Value = model.AddressName;
            commandParameters[4].Value = model.AddressPath;
            commandParameters[5].Value = model.AddressId;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoadAddress_Set", commandParameters);
        }

        public DataRow GetAddressPath(int addressId, int serverId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@serverid", serverId), new SqlParameter("@addressid", addressId) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoad_GetAddressPath", commandParameters);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0];
            }
            return null;
        }

        public DataTable GetGroupAddresList(int addressNum, int downLoadServerId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@addresnum", SqlDbType.Int), new SqlParameter("@downloadserverid", SqlDbType.Int) };
            commandParameters[0].Value = addressNum;
            commandParameters[1].Value = downLoadServerId;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoadAddress_GetGroupAddresList", commandParameters);
            if ((table == null) || (table.Rows.Count <= 0))
            {
                return null;
            }
            return table;
        }

        public DataTable GetInfoBySoftId(int SoftId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@SoftId", SoftId) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_DownLoadAddress_GetInfoBySoftId", commandParameters);
        }

        public void Update(M_DownLoadAddress model)
        {
            this.Add(model);
        }
    }
}

