namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_Special
    {
        private ISpecial isp = DataAccess.CreateSpeciall();

        public void Add(M_Special model)
        {
            this.isp.Add(model);
            B_Log.Add(LogType.Add, "新增专题成功 专题名：" + model.SpecialCName);
        }

        public void Delete(int id)
        {
            this.isp.Delete(id);
            B_Log.Add(LogType.Delete, "删除专题成功 编号：" + id);
        }

        public void DeleteComplete(int specialId)
        {
            this.isp.CompleteDelete(specialId);
        }

        public DataTable GetAllSpecial()
        {
            return this.isp.GetAllSpecial();
        }

        public DataTable GetChannelSpecial(int chId)
        {
            return this.isp.GetChannelSpecial(chId);
        }

        public M_Special GetSpecial(int id)
        {
            return this.isp.GetSpecial(id);
        }

        public DataTable GetSpecialByParentId(int parentId)
        {
            return this.isp.GetSpecialByParentId(parentId);
        }

        public DataTable GetSpecials(int selectType)
        {
            return this.isp.GetSpecials(selectType);
        }

        public void Update(M_Special model)
        {
            this.isp.Update(model);
            B_Log.Add(LogType.Update, "修改专题成功 编号：" + model.ID);
        }
    }
}

