namespace Ky.BLL.CommonModel
{
    using Ky.Common;
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.IO;

    public class B_InfoModel
    {
        private IInfoModel dal = DataAccess.CreateInfoModel();

        public int Add(M_InfoModel model)
        {
            int num = this.dal.Add(model);
            this.dal.AddTable(model.TableName);
            try
            {
                Directory.CreateDirectory(Param.SiteRootPath + "/upload/" + model.UploadPath);
            }
            catch
            {
            }
            return num;
        }

        public int AddInfoModel(DataTable dt, string TableName)
        {
            return this.dal.AddInfoModel(dt, TableName);
        }

        public bool CheckExistsChannel(int modelId)
        {
            return this.dal.CheckExistsChannel(modelId);
        }

        public bool CheckTableValidate(string tableName)
        {
            return this.dal.CheckTableValidate(tableName);
        }

        public bool CheckUploadPathValidate(string uploadPath)
        {
            return this.dal.CheckUploadPathValidate(uploadPath);
        }

        public void Delete(int modelId)
        {
            if (this.GetModel(modelId) != null)
            {
                this.dal.Delete(modelId);
            }
        }

        public DataTable GetList()
        {
            return this.dal.GetList();
        }

        public M_InfoModel GetModel(int modelId)
        {
            return this.dal.GetModel(modelId);
        }

        public int GetModelInfoCount(string tableName, string whereStr)
        {
            return this.dal.GetModelInfoCount(tableName, whereStr);
        }

        public DataTable GetModelNumCount()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("ModelName", typeof(string)));
            table.Columns.Add(new DataColumn("ModelNum", typeof(int)));
            table.Columns.Add(new DataColumn("ModelId", typeof(string)));
            DataTable list = this.GetList();
            for (int i = 0; i < list.Rows.Count; i++)
            {
                for (int j = 0; j < this.GetModelInfoCount(list.Rows[i]["TableName"].ToString(), "[status] in(0,1,2,3)"); j++)
                {
                    DataRow row = table.NewRow();
                    row[0] = list.Rows[i]["ModelName"].ToString();
                    row[1] = 1;
                    row[2] = list.Rows[i]["ModelId"].ToString();
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        public DataTable GetTextType(int ModelId)
        {
            return this.dal.GetTextType(ModelId);
        }

        public DataSet ModelOut(string InModelId)
        {
            return this.dal.ModelOut(InModelId);
        }

        public int Update(M_InfoModel model)
        {
            return this.dal.Update(model);
        }

        public void UpdateInfoModel(DataTable dt, string TableName)
        {
            this.dal.UpdateInfoModel(dt, TableName);
        }

        public void UpdateModelHtml(M_InfoModel model)
        {
            this.dal.UpdateModelHtml(model);
        }
    }
}

