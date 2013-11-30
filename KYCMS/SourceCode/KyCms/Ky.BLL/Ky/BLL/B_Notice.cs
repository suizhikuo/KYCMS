namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_Notice
    {
        private INotice inotice = DataAccess.CreateNotice();

        public void Delete(int NoticeId)
        {
            this.inotice.Del(NoticeId);
        }

        public DataSet GetList(int currPage, int pageSize, string WhereStr)
        {
            return this.inotice.GetList(currPage, pageSize, WhereStr);
        }

        public DataTable GetTop(int TopValue)
        {
            return this.inotice.GetTop(TopValue);
        }

        public void Insert(M_Notice model)
        {
            this.inotice.Insert(model);
        }

        public DataTable Manage(int TypeId)
        {
            return this.inotice.Manage(TypeId);
        }

        public M_Notice Show(int NoticeId)
        {
            return this.inotice.Show(NoticeId);
        }

        public void Update(M_Notice model)
        {
            this.inotice.Update(model);
        }

        public void UpdateIsState(int NoticeId)
        {
            this.inotice.UpdateIsState(NoticeId);
        }
    }
}

