namespace Ky.SQLServerDAL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class UserSpace : IUserSpace
    {
        public int GetSapcePrevPowerByUserId(int userId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@userId", userId) };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserSpace_GetPrevPower", commandParameters));
        }

        public M_UserSpace GetUserSpaceById(int Id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", Id) };
            DataTable table = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserSpace_GetById", commandParameters);
            M_UserSpace space = new M_UserSpace();
            if (table.Rows.Count > 0)
            {
                space.Id = int.Parse(table.Rows[0]["Id"].ToString());
                space.SpaceName = table.Rows[0]["SpaceName"].ToString();
                space.SpaceDescription = table.Rows[0]["SpaceDescription"].ToString();
                space.UserId = int.Parse(table.Rows[0]["UserId"].ToString());
                space.UserName = table.Rows[0]["UserName"].ToString();
                space.AddTime = table.Rows[0]["AddTime"].ToString();
                space.PrevPower = int.Parse(table.Rows[0]["PrevPower"].ToString());
                space.Password = table.Rows[0]["Password"].ToString();
                space.TemplateId = Convert.ToInt32(table.Rows[0]["TemplateId"]);
                space.UserType = Convert.ToInt32(table.Rows[0]["UserType"]);
                return space;
            }
            return null;
        }

        public void RegSpace(M_UserSpace model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int, 4), new SqlParameter("@SpaceName", SqlDbType.NVarChar), new SqlParameter("@SpaceDescription", SqlDbType.NVarChar), new SqlParameter("@PrevPower", SqlDbType.Int, 4), new SqlParameter("@Password", SqlDbType.NVarChar), new SqlParameter("@AddTime", SqlDbType.NVarChar), new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@TemplateId", SqlDbType.Int, 4), new SqlParameter("@UserType", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.Id;
            commandParameters[1].Value = model.SpaceName;
            commandParameters[2].Value = model.SpaceDescription;
            commandParameters[3].Value = model.PrevPower;
            commandParameters[4].Value = model.Password;
            commandParameters[5].Value = model.AddTime;
            commandParameters[6].Value = model.UserId;
            commandParameters[7].Value = model.UserName;
            commandParameters[8].Value = model.TemplateId;
            commandParameters[9].Value = model.UserType;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserSpace_Set", commandParameters);
        }

        public void UpdateSpace(M_UserSpace model)
        {
            this.RegSpace(model);
        }
    }
}

