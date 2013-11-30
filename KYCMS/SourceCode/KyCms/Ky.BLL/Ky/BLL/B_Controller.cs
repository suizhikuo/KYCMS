namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_Controller
    {
        private IController dal = DataAccess.CreateController();

        public void Add(M_Controller model)
        {
            this.dal.Add(model);
        }

        public void Delete(int controllerId, int userId)
        {
            this.dal.Delete(controllerId, userId);
        }

        public DataTable GetList(int userId)
        {
            return this.dal.GetList(userId);
        }

        public void SetDefault(int userId)
        {
            this.dal.SetDefault(userId);
            B_Log.Add(LogType.Update, "设置我的控制台为默认设置");
        }

        public void Update(M_Controller model)
        {
            if (model.ControllerId > 0)
            {
                this.dal.Update(model);
            }
        }
    }
}

