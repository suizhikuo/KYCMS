namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_DownLoadServerType
    {
        private IDownLoadServer iDL = DataAccess.CreateDownServer();

        public void AddType(M_DownLoadServerType model)
        {
            this.iDL.AddType(model);
        }

        public void DeleteType(int typeId)
        {
            this.iDL.DeleteType(typeId);
        }

        public DataTable GetTypeInfo(int typeId)
        {
            return this.iDL.GetTypeInfo(typeId);
        }

        public DataTable GetTypeList()
        {
            return this.iDL.GetTypeList();
        }

        public bool IsAllowDeleteType(int typeId)
        {
            return this.iDL.IsAllowDeleteType(typeId);
        }

        public void UpdateType(M_DownLoadServerType model)
        {
            this.iDL.UpdateType(model);
        }
    }
}

