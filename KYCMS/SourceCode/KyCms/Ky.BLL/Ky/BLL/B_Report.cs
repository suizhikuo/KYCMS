namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_Report
    {
        private IReport dal = DataAccess.CreateReport();

        public void Add(M_Report model)
        {
            this.dal.Add(model);
        }

        public void Delete(int reportId)
        {
            this.dal.Delete(reportId);
        }

        public DataTable GetList(int pageIndex, int pageSize, string whereStr, ref int recordCount)
        {
            DataSet set = this.dal.GetList(pageIndex, pageSize, whereStr);
            DataTable table = set.Tables[0];
            recordCount = (int) set.Tables[1].Rows[0][0];
            return table;
        }

        public void SetStatus(int reportId, int status)
        {
            this.dal.SetStatus(reportId, status);
        }
    }
}

