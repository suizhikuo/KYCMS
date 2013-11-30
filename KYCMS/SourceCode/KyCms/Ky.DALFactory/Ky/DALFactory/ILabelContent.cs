namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface ILabelContent
    {
        void Add(M_LabelContent model);
        void Delete(string labelCategoryId);
        string GetLabelContent(int labelCategoryId);
        string GetLabelContentByName(string name);
        M_LabelContent GetLabelContentId(int labelCagegoryId);
        DataTable GetLabelList();
        DataTable GetLbCategoryIdList(int labelCagegoryId, int cursorPage, int pageSize, ref int recordCount);
        DataTable GetLbCategoryNameList(string labelName, int pageIndex, int pageSize, ref int recordCount);
        void Update(M_LabelContent model);
    }
}

