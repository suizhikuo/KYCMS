namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CollectionAddress : ICollectionAddress
    {
        public void Add(M_CollectionAddress model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ColectionId", SqlDbType.Int, 4), new SqlParameter("@CollectionUrl", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Bit, 1) };
            commandParameters[0].Value = model.ColectionId;
            commandParameters[1].Value = model.CollectionUrl;
            commandParameters[2].Value = model.State;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CollectionAddress_Add", commandParameters);
        }

        public bool DeleteCollId(int collid, bool state)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@collid", SqlDbType.Int), new SqlParameter("@state", SqlDbType.Bit) };
            commandParameters[0].Value = collid;
            commandParameters[1].Value = state;
            return (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CollectionAddress_DeleteCollId", commandParameters) > 0);
        }

        public DataTable GetCollIdByCollAddress(int CollId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@collectionid", SqlDbType.Int) };
            commandParameters[0].Value = CollId;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CollectionAddress_GetCollidByAddress", commandParameters);
            if ((table != null) && (table.Rows.Count != 0))
            {
                return table;
            }
            return null;
        }

        public DataTable GetCollIdByList(int collid, bool state, int pageIndex, int pageSize, ref int recordCount)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@collid", SqlDbType.Int), new SqlParameter("@state", SqlDbType.Bit), new SqlParameter("@pageindex", SqlDbType.Int), new SqlParameter("@pagesize", SqlDbType.Int), new SqlParameter("@recordcount", SqlDbType.Int) };
            commandParameters[0].Value = collid;
            commandParameters[1].Value = state;
            commandParameters[2].Value = pageIndex;
            commandParameters[3].Value = pageSize;
            commandParameters[4].Value = 0;
            commandParameters[4].Direction = ParameterDirection.Output;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CollectionAddress_GetCollIdList", commandParameters);
            recordCount = int.Parse(commandParameters[4].Value.ToString());
            return table;
        }

        public bool IsCheckAddress(string address)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@collectionaddress", SqlDbType.NVarChar) };
            commandParameters[0].Value = address;
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CollectionAddress_CheckAddress", commandParameters);
            if ((table != null) && (table.Rows.Count > 0))
            {
                return false;
            }
            return true;
        }

        public void UpdateState(string address)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@collectionaddress", SqlDbType.NVarChar) };
            commandParameters[0].Value = address;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CollectionAddress_UpdateState", commandParameters);
        }
    }
}

