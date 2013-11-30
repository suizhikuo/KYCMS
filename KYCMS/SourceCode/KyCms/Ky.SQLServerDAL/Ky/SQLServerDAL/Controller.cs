namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Controller : IController
    {
        public void Add(M_Controller model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ControllerId", model.ControllerId), new SqlParameter("@ControllerName", model.ControllerName), new SqlParameter("@LinkURI", model.LinkURI), new SqlParameter("@OrderNum", model.OrderNum), new SqlParameter("@UserId", model.UserId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Controller_Set", commandParameters);
        }

        public void Delete(int controllerId, int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ControllerId", controllerId), new SqlParameter("@UserId", userId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Controller_Delete", commandParameters);
        }

        public DataTable GetList(int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", userId) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Controller_GetList", commandParameters);
        }

        public void SetDefault(int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@UserId", userId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_Controller_Set_Default", commandParameters);
        }

        public void Update(M_Controller model)
        {
            this.Add(model);
        }
    }
}

