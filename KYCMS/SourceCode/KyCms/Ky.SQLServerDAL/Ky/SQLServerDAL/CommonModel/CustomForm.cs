namespace Ky.SQLServerDAL.CommonModel
{
    using Ky.DALFactory;
    using Ky.Model;
    using Ky.SQLServerDAL;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CustomForm : ICustomForm
    {
        public void Add(M_CustomForm model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ShowForm", model.ShowForm), new SqlParameter("@FormName", model.FormName), new SqlParameter("@TableName", model.TableName), new SqlParameter("@UploadPath", model.UploadPath), new SqlParameter("@FormDesc", model.FormDesc), new SqlParameter("@IsUnlockTime", model.IsUnlockTime), new SqlParameter("@StartTime", model.StartTime), new SqlParameter("@EndTime", model.EndTime), new SqlParameter("@UserGroup", model.UserGroup), new SqlParameter("@IsSubmitNum", model.IsSubmitNum), new SqlParameter("@Money", model.Money), new SqlParameter("@IsValidate", model.IsValidate), new SqlParameter("@AddTime", model.AddTime) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomForm_Add", commandParameters);
        }

        public void AddTable(string TableName)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TableName", TableName) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomForm_AddTable", commandParameters);
        }

        public void Delete(int CustomFormId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CustomFormId", CustomFormId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomForm_Delete", commandParameters);
        }

        public DataTable GetAll()
        {
            DataTable table = new DataTable();
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomForm_GetAll", new SqlParameter[0]);
        }

        public DataTable GetFormSubmitNum(string TableName, int UId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@TableName", TableName), new SqlParameter("@UId", UId) };
            return SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomField_SubmitNum", commandParameters);
        }

        public M_CustomForm GetModel(int CustomFormId)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@CustomFormId", SqlDbType.Int, 4) };
            commandParameters[0].Value = CustomFormId;
            M_CustomForm form = new M_CustomForm();
            DataSet set = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomForm_GetModel", commandParameters);
            if (set.Tables[0].Rows.Count > 0)
            {
                if (set.Tables[0].Rows[0]["ShowForm"].ToString() != "")
                {
                    form.ShowForm = int.Parse(set.Tables[0].Rows[0]["ShowForm"].ToString());
                }
                if (set.Tables[0].Rows[0]["UploadSize"].ToString() != "")
                {
                    form.UploadSize = int.Parse(set.Tables[0].Rows[0]["UploadSize"].ToString());
                }
                form.FormName = set.Tables[0].Rows[0]["FormName"].ToString();
                form.TableName = set.Tables[0].Rows[0]["TableName"].ToString();
                form.UploadPath = set.Tables[0].Rows[0]["UploadPath"].ToString();
                form.FormDesc = set.Tables[0].Rows[0]["FormDesc"].ToString();
                if (set.Tables[0].Rows[0]["IsUnlockTime"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsUnlockTime"].ToString() == "1") || (set.Tables[0].Rows[0]["IsUnlockTime"].ToString().ToLower() == "true"))
                    {
                        form.IsUnlockTime = true;
                    }
                    else
                    {
                        form.IsUnlockTime = false;
                    }
                }
                if (set.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    form.StartTime = DateTime.Parse(set.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (set.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    form.EndTime = DateTime.Parse(set.Tables[0].Rows[0]["EndTime"].ToString());
                }
                form.UserGroup = set.Tables[0].Rows[0]["UserGroup"].ToString();
                if (set.Tables[0].Rows[0]["IsSubmitNum"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsSubmitNum"].ToString() == "1") || (set.Tables[0].Rows[0]["IsSubmitNum"].ToString().ToLower() == "true"))
                    {
                        form.IsSubmitNum = true;
                    }
                    else
                    {
                        form.IsSubmitNum = false;
                    }
                }
                if (set.Tables[0].Rows[0]["Money"].ToString() != "")
                {
                    form.Money = int.Parse(set.Tables[0].Rows[0]["Money"].ToString());
                }
                if (set.Tables[0].Rows[0]["IsValidate"].ToString() != "")
                {
                    if ((set.Tables[0].Rows[0]["IsValidate"].ToString() == "1") || (set.Tables[0].Rows[0]["IsValidate"].ToString().ToLower() == "true"))
                    {
                        form.IsValidate = true;
                    }
                    else
                    {
                        form.IsValidate = false;
                    }
                }
                if (set.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    form.AddTime = DateTime.Parse(set.Tables[0].Rows[0]["AddTime"].ToString());
                }
                return form;
            }
            return null;
        }

        public void Update(M_CustomForm model)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@ShowForm", model.ShowForm), new SqlParameter("@FormName", model.FormName), new SqlParameter("@TableName", model.TableName), new SqlParameter("@UploadPath", model.UploadPath), new SqlParameter("@FormDesc", model.FormDesc), new SqlParameter("@IsUnlockTime", model.IsUnlockTime), new SqlParameter("@StartTime", model.StartTime), new SqlParameter("@EndTime", model.EndTime), new SqlParameter("@UserGroup", model.UserGroup), new SqlParameter("@IsSubmitNum", model.IsSubmitNum), new SqlParameter("@Money", model.Money), new SqlParameter("@IsValidate", model.IsValidate), new SqlParameter("@AddTime", model.AddTime), new SqlParameter("@CustomFormId", model.CustomFormId) };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringKy, CommandType.StoredProcedure, "Up_CustomForm_Update", commandParameters);
        }
    }
}

