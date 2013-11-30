namespace Ky.Model
{
    using System;

    public class M_DownLoadAddress
    {
        private int _addressid;
        private string _addressname;
        private int _addressnum;
        private string _addresspath;
        private int _downloaddataid;
        private int _downloadserverid;

        public int AddressId
        {
            get
            {
                return this._addressid;
            }
            set
            {
                this._addressid = value;
            }
        }

        public string AddressName
        {
            get
            {
                return this._addressname;
            }
            set
            {
                this._addressname = value;
            }
        }

        public int AddressNum
        {
            get
            {
                return this._addressnum;
            }
            set
            {
                this._addressnum = value;
            }
        }

        public string AddressPath
        {
            get
            {
                return this._addresspath;
            }
            set
            {
                this._addresspath = value;
            }
        }

        public int DownLoadDataId
        {
            get
            {
                return this._downloaddataid;
            }
            set
            {
                this._downloaddataid = value;
            }
        }

        public int DownLoadServerID
        {
            get
            {
                return this._downloadserverid;
            }
            set
            {
                this._downloadserverid = value;
            }
        }
    }
}

