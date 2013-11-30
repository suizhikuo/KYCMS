namespace Ky.SQLServerDAL.CommonModel
{
    using Ky.DALFactory;
    using Ky.Model;
    using Ky.SQLServerDAL;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class UserGroupModel : IUserGroupModel
    {
        public int Add(M_UserGroupModel model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Name", SqlDbType.NVarChar), new SqlParameter("@TableName", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NVarChar), new SqlParameter("@UserGroupId", SqlDbType.Int, 4), new SqlParameter("@ModelHtml", SqlDbType.NText), new SqlParameter("@AddTime", SqlDbType.DateTime), new SqlParameter("@IsValidate", SqlDbType.Bit), new SqlParameter("@IsHtml", SqlDbType.Bit), new SqlParameter("@SpaceTypeId", SqlDbType.Int, 4) };
            commandParameters[0].Value = model.Name;
            commandParameters[1].Value = model.TableName;
            commandParameters[2].Value = model.Content;
            commandParameters[3].Value = model.UserGroupId;
            commandParameters[4].Value = model.ModelHtml;
            commandParameters[5].Value = model.AddTime;
            commandParameters[6].Value = model.IsValidate;
            commandParameters[7].Value = model.IsHtml;
            commandParameters[8].Value = model.SpaceTypeId;
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserGroupModel_Add", commandParameters));
        }

        public void AddTable(string TableName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TableName", TableName) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserGroupModel_AddTable", commandParameters);
        }

        public void Delete(int Id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", Id) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserGroupModel_Delete", commandParameters);
        }

        public DataTable GetAll()
        {
            DataTable table = new DataTable();
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserGroupModel_GetAll", new SqlParameter[0]);
        }

        public M_UserGroupModel GetModel(int Id)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int, 4) };
            commandParameters[0].Value = Id;
            M_UserGroupModel model = new M_UserGroupModel();
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserGroupModel_GetModel", commandParameters);
            model.Id = Id;
            if (set.Tables[0].Rows.Count > 0)
            {
                model.Name = set.Tables[0].Rows[0]["Name"].ToString();
                model.TableName = set.Tables[0].Rows[0]["TableName"].ToString();
                model.Content = set.Tables[0].Rows[0]["Content"].ToString();
                if (set.Tables[0].Rows[0]["UserGroupId"].ToString() != "")
                {
                    model.UserGroupId = int.Parse(set.Tables[0].Rows[0]["UserGroupId"].ToString());
                }
                model.ModelHtml = set.Tables[0].Rows[0]["ModelHtml"].ToString();
                if (set.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(set.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (set.Tables[0].Rows[0]["IsValidate"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsValidate"].ToString() == "1") || (set.Tables[0].Rows[0]["IsValidate"].ToString().ToLower() == "true"))
                    {
                        model.IsValidate = true;
                    }
                    else
                    {
                        model.IsValidate = false;
                    }
                }
                if (set.Tables[0].Rows[0]["IsHtml"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsHtml"].ToString() == "1") || (set.Tables[0].Rows[0]["IsHtml"].ToString().ToLower() == "true"))
                    {
                        model.IsHtml = true;
                    }
                    else
                    {
                        model.IsHtml = false;
                    }
                }
                if (set.Tables[0].Rows[0]["SpaceTypeId"].ToString() != "")
                {
                    model.SpaceTypeId = int.Parse(set.Tables[0].Rows[0]["SpaceTypeId"].ToString());
                }
                return model;
            }
            return null;
        }

        public DataTable GetTextType(int ModelId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ModelId", ModelId) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserGroupModel_GetTextType", commandParameters);
        }

        public void Update(M_UserGroupModel model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Name", model.Name), new SqlParameter("@TableName", model.TableName), new SqlParameter("@Content", model.Content), new SqlParameter("@AddTime", model.AddTime), new SqlParameter("@Id", model.Id), new SqlParameter("@IsValidate", model.IsValidate), new SqlParameter("@IsHtml", model.IsHtml), new SqlParameter("@SpaceTypeId", model.SpaceTypeId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserGroupModel_Update", commandParameters);
        }

        public void UpdateModelHtml(M_UserGroupModel model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ModelHtml", model.ModelHtml), new SqlParameter("@Id", model.Id) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserGroupModel_ModelHtml", commandParameters);
        }

        public void UpdateUserGroupId(int Id, int UserGroupId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Id", Id), new SqlParameter("@UserGroupId", UserGroupId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_UserGroupModel_UpdateUserGroupId", commandParameters);
        }
    }
}

