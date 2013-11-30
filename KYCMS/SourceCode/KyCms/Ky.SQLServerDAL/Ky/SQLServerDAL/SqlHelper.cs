namespace Ky.SQLServerDAL
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using Ky.Common;
    /// <summary>
    /// ///51/a/s/px/
    /// </summary>
    public abstract class SqlHelper
    {
        public static readonly string ConnectionStringKy = Param.GetConStr();
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        protected SqlHelper()
        {
        }

        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(ConnectionStringKy, cmdType, cmdText, commandParameters);
        }

        public static DataSet ExecuteDataSet(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            cmd.Parameters.Clear();
            return dataSet;
        }

        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                cmd.Parameters.Clear();
                return dataSet;
            }
        }

        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(ConnectionStringKy, cmdType, cmdText, commandParameters);
        }

        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int num = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return num;
        }

        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int num = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return num;
        }

        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 60;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                int num = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return num;
            }
        }

        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteReader(ConnectionStringKy, cmdType, cmdText, commandParameters);
        }

        public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            return reader;
        }

        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlDataReader reader2;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                reader2 = reader;
            }
            catch
            {
                conn.Close();
                throw;
            }
            return reader2;
        }

        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(ConnectionStringKy, cmdType, cmdText, commandParameters);
        }

        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object obj2 = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return obj2;
        }

        public static object ExecuteScalar(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            object obj2 = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return obj2;
        }

        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object obj2 = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return obj2;
            }
        }

        public static DataTable ExecuteTable(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteTable(ConnectionStringKy, cmdType, cmdText, commandParameters);
        }

        public static DataTable ExecuteTable(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Result");
            cmd.Parameters.Clear();
            return dataSet.Tables["Result"];
        }

        public static DataTable ExecuteTable(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Result");
                cmd.Parameters.Clear();
                if (dataSet.Tables.Count > 0)
                {
                    return dataSet.Tables["Result"];
                }
                return null;
            }
        }

        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] parameterArray = (SqlParameter[])parmCache[cacheKey];
            if (parameterArray == null)
            {
                return null;
            }
            SqlParameter[] parameterArray2 = new SqlParameter[parameterArray.Length];
            int index = 0;
            int length = parameterArray.Length;
            while (index < length)
            {
                parameterArray2[index] = (SqlParameter)((ICloneable)parameterArray[index]).Clone();
                index++;
            }
            return parameterArray2;
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 60;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }
}

