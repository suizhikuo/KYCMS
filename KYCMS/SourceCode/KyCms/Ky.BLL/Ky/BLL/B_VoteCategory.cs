namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_VoteCategory
    {
        private IVoteCategory ivc = DataAccess.CreateVoteCat();

        public void Add(M_VoteCategory model)
        {
            this.ivc.Add(model);
            B_Log.Add(LogType.Add, "新增投票分类成功 分类名：" + model.Name);
        }

        public void Delete(int id)
        {
            this.ivc.Delete(id);
            B_Log.Add(LogType.Delete, "删除投票分类成功 编号：" + id);
        }

        public M_VoteCategory GetCategory(int id)
        {
            return this.ivc.GetCategory(id);
        }

        public DataTable GetList()
        {
            return this.ivc.GetList();
        }

        public void Update(M_VoteCategory model)
        {
            this.ivc.Update(model);
            B_Log.Add(LogType.Update, "修改投票分类成功 编号：" + model.CategoryId);
        }
    }
}

