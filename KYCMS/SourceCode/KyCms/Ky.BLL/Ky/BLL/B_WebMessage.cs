namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_WebMessage
    {
        private IWebMessage iwebm = DataAccess.CreateWebMessage();

        public void Delete(int WMId)
        {
            this.iwebm.Delete(WMId);
        }

        public DataTable GetList(string WhereStr)
        {
            return this.iwebm.GetList(WhereStr);
        }

        public DataSet GetList(int currPage, int pageSize, string WhereStr)
        {
            return this.iwebm.GetList(currPage, pageSize, WhereStr);
        }

        public void Insert(M_WebMessage model)
        {
            this.iwebm.Insert(model);
        }

        public M_WebMessage Show(int WMId, int UserId)
        {
            return this.iwebm.Show(WMId, UserId);
        }

        public void UpdateDel(int WMId, int UserId, int DelTypeId)
        {
            this.iwebm.UpdateDel(WMId, UserId, DelTypeId);
        }
    }
}

