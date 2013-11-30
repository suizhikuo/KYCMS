namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_Tag
    {
        private ITag dal = DataAccess.CreateTag();

        public bool Add(M_Tag model)
        {
            return this.dal.Add(model);
        }

        public DataRow AddTagStr(string tagNameStr, int modelType, int uId, string uName)
        {
            tagNameStr = new B_SiteInfo().GetFiltering(tagNameStr);
            return this.dal.AddTagStr(tagNameStr, modelType, uId, uName);
        }

        public void ClearSearchCount()
        {
            this.dal.ClearSearchCount();
        }

        public void Delete(int searchCount)
        {
            this.dal.Delete(searchCount);
            B_Log.Add(LogType.Delete, "清理搜索次数少于" + searchCount + "次的关键字");
        }

        public DataTable GetList(int currPage, int pageSize, ref int recordCount)
        {
            return this.dal.GetList(currPage, pageSize, ref recordCount);
        }

        public void SetTagSearchCount(string tagName, int modelType)
        {
            this.dal.SetTagSearchCount(tagName, modelType);
        }
    }
}

