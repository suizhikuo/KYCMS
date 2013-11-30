namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_Vote
    {
        private IVote iV = DataAccess.CreateVote();

        public int AddSubject(M_VoteSubject model)
        {
            int num = this.iV.AddSubject(model);
            B_Log.Add(LogType.Add, "新增投票主题成功");
            return num;
        }

        public void AddVote(M_Vote model)
        {
            this.iV.AddVote(model);
            B_Log.Add(LogType.Add, "新增投票内容成功");
        }

        public void Delete(int subjectId)
        {
            this.iV.Delete(subjectId);
            B_Log.Add(LogType.Delete, "删除一个投票主题成功 编号：" + subjectId);
        }

        public DataTable GetAll()
        {
            return this.iV.GetAll();
        }

        public DataTable GetSubject(int sujectId)
        {
            return this.iV.GetSubject(sujectId);
        }

        public DataTable GetSubjects(int pageSize, int pageIndex, string whereStr, ref int total)
        {
            return this.iV.GetSubjects(pageSize, pageIndex, whereStr, ref total);
        }

        public M_Vote GetVoteIdbyInfo(int voteId)
        {
            return this.iV.GetVoteIdbyInfo(voteId);
        }

        public void UpdateSubject(M_VoteSubject model)
        {
            this.iV.UpdateSubject(model);
            B_Log.Add(LogType.Update, "修改投票主题成功 编号：" + model.SubjectId);
        }

        public void UpdateVote(M_Vote model)
        {
            this.iV.UpdateVote(model);
        }
    }
}

