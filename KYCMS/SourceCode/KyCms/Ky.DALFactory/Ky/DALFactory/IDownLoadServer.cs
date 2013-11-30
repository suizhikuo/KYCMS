namespace Ky.DALFactory
{
    using Ky.Model;
    using System;
    using System.Data;

    public interface IDownLoadServer
    {
        void AddData(M_DownLoadServerData model);
        void AddType(M_DownLoadServerType model);
        void DeleteData(int downServerId);
        void DeleteType(int typeId);
        DataTable GetDataInfo(int downServerId);
        DataTable GetDataList(int typeId);
        DataTable GetTypeInfo(int typeId);
        DataTable GetTypeList();
        bool IsAllowDeleteType(int TypeId);
        void SetIsOpened(int downServerId, bool isOpened);
        void UpdateData(M_DownLoadServerData model);
        void UpdateType(M_DownLoadServerType model);
    }
}

