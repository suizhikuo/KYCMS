namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_Feedback
    {
        private IFeedback iF = DataAccess.CreateFeedback();

        public void Add(M_Feedback model)
        {
            this.iF.Add(model);
        }

        public DataTable Count()
        {
            DataSet set = this.iF.Count();
            DataTable table = new DataTable();
            table.Columns.Add("Total", typeof(int));
            table.Columns.Add("Finished", typeof(int));
            table.Columns.Add("Answing", typeof(int));
            DataRow row = table.NewRow();
            row["Total"] = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            row["Finished"] = Convert.ToInt32(set.Tables[1].Rows[0][0]);
            row["Answing"] = Convert.ToInt32(set.Tables[2].Rows[0][0]);
            table.Rows.Add(row);
            return table;
        }

        public void Delete(int feedbackId)
        {
            this.iF.Delete(feedbackId);
            B_Log.Add(LogType.Delete, "删除问答成功。编号：" + feedbackId.ToString());
        }

        public DataSet GetFeedback(int feedbackId)
        {
            return this.iF.GetFeedback(feedbackId);
        }

        public DataTable GetHighScoringAuthor()
        {
            return this.iF.GetReplyers(3, 0, "");
        }

        public DataSet GetList(int pageSize, int pageIndex, string whereStr)
        {
            return this.iF.GetList(pageSize, pageIndex, whereStr);
        }

        public DataTable GetReplyers(int id, string author)
        {
            return this.iF.GetReplyers(2, id, author);
        }

        public void UpdateState(int id, int type, int value)
        {
            this.iF.UpdateState(id, type, value);
        }
    }
}

