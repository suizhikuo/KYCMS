namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface ITag
    {
        bool Add(M_Tag model);
        DataRow AddTagStr(string tagNameStr, int modelType, int uId, string uName);
        void ClearSearchCount();
        void Delete(int searchCount);
        DataTable GetList(int currPage, int pageSize, ref int recordCount);
        void SetTagSearchCount(string tagName, int modelType);
    }
}

