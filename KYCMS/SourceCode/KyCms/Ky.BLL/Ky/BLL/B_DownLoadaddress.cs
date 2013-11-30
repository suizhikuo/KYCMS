namespace Ky.BLL
{
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;

    public class B_DownLoadaddress
    {
        private IDownLoadAddress IDLA = DataAccess.CreateDownLoadAddress();

        public void Add(M_DownLoadAddress model)
        {
            this.IDLA.Add(model);
        }

        public DataRow GetAddressPath(int addressId, int serverId)
        {
            return this.IDLA.GetAddressPath(addressId, serverId);
        }

        public DataTable GetGroupAddresList(int addressNum, int downLoadServerId)
        {
            return this.IDLA.GetGroupAddresList(addressNum, downLoadServerId);
        }

        public DataTable GetInfoBySoftId(int SoftId)
        {
            return this.IDLA.GetInfoBySoftId(SoftId);
        }

        public void Update(M_DownLoadAddress model)
        {
            this.IDLA.Update(model);
        }
    }
}

