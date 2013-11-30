namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_LabelContent
    {
        private ILabelContent iLabelContent = DataAccess.CreateLabelContent();

        public void Add(M_LabelContent model)
        {
            this.iLabelContent.Add(model);
        }

        public void Delete(string labelCategoryId)
        {
            this.iLabelContent.Delete(labelCategoryId);
        }

        public string GetLabelContent(int labelCategoryId)
        {
            return this.iLabelContent.GetLabelContent(labelCategoryId);
        }

        public string GetLabelContentByName(string name)
        {
            return this.iLabelContent.GetLabelContentByName(name);
        }

        public M_LabelContent GetLabelContentId(int labelCagegoryId)
        {
            return this.iLabelContent.GetLabelContentId(labelCagegoryId);
        }

        public DataTable GetLabelList()
        {
            return this.iLabelContent.GetLabelList();
        }

        public DataTable GetLbCategoryIdList(int labelCagegoryId, int cursorPage, int pageSize, ref int recordCount)
        {
            return this.iLabelContent.GetLbCategoryIdList(labelCagegoryId, cursorPage, pageSize, ref recordCount);
        }

        public DataTable GetLbCategoryNameList(string labelName, int pageIndex, int pageSize, ref int recordCount)
        {
            return this.iLabelContent.GetLbCategoryNameList(labelName, pageIndex, pageSize, ref recordCount);
        }

        public void Update(M_LabelContent model)
        {
            this.iLabelContent.Update(model);
        }
    }
}

