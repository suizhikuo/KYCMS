namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IDownLoadAddress
    {
        void Add(M_DownLoadAddress model);
        DataRow GetAddressPath(int addressId, int serverId);
        DataTable GetGroupAddresList(int addressNum, int downLoadServerId);
        DataTable GetInfoBySoftId(int SoftId);
        void Update(M_DownLoadAddress model);
    }
}

