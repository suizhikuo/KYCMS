namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_DownLoadServerData
    {
        private IDownLoadServer iDL = DataAccess.CreateDownServer();

        public void AddData(M_DownLoadServerData model)
        {
            this.iDL.AddData(model);
        }

        public void DeleteData(int downServerId)
        {
            this.iDL.DeleteData(downServerId);
        }

        public DataTable GetDataInfo(int DownServerId)
        {
            return this.iDL.GetDataInfo(DownServerId);
        }

        public DataTable GetDataList(int typeId)
        {
            return this.iDL.GetDataList(typeId);
        }

        public void SetIsOpened(int downServerId, bool isOpened)
        {
            this.iDL.SetIsOpened(downServerId, isOpened);
        }

        public void UpdateData(M_DownLoadServerData model)
        {
            this.iDL.UpdateData(model);
        }
    }
}

