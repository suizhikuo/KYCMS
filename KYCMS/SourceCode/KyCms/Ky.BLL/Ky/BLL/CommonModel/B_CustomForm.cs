namespace Ky.BLL.CommonModel
{
    using Ky.Common;
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.IO;

    public class B_CustomForm
    {
        private ICustomForm dal = DataAccess.CreateCustomForm();

        public void Add(M_CustomForm model)
        {
            this.dal.Add(model);
            this.dal.AddTable(model.TableName);
            if (!Directory.Exists(Param.SiteRootPath + "/upload/" + model.UploadPath))
            {
                Directory.CreateDirectory(Param.SiteRootPath + "/upload/" + model.UploadPath);
            }
        }

        public void Delete(int CustomFormId)
        {
            this.dal.Delete(CustomFormId);
        }

        public DataTable GetAll()
        {
            return this.dal.GetAll();
        }

        public DataTable GetFormSubmitNum(string TableName, int UId)
        {
            return this.dal.GetFormSubmitNum(TableName, UId);
        }

        public M_CustomForm GetModel(int CustomFormId)
        {
            return this.dal.GetModel(CustomFormId);
        }

        public void Update(M_CustomForm model)
        {
            this.dal.Update(model);
        }
    }
}

