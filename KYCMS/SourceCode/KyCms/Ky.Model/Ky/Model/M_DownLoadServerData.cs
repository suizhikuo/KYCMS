namespace Ky.Model
{
    using System;

    public class M_DownLoadServerData
    {
        private DateTime _addtime;
        private int _alldownnum;
        private int _daydownnum;
        private int _downloadserverdataid;
        private string _downloadserverdir;
        private string _downloadservername;
        private bool _isopened;
        private int _isouter;
        private int _typeid;
        private string _unionid;

        public DateTime AddTime
        {
            get
            {
                return this._addtime;
            }
            set
            {
                this._addtime = value;
            }
        }

        public int AllDownNum
        {
            get
            {
                return this._alldownnum;
            }
            set
            {
                this._alldownnum = value;
            }
        }

        public int DayDownNum
        {
            get
            {
                return this._daydownnum;
            }
            set
            {
                this._daydownnum = value;
            }
        }

        public int DownLoadServerDataId
        {
            get
            {
                return this._downloadserverdataid;
            }
            set
            {
                this._downloadserverdataid = value;
            }
        }

        public string DownLoadServerDir
        {
            get
            {
                return this._downloadserverdir;
            }
            set
            {
                this._downloadserverdir = value;
            }
        }

        public string DownLoadServerName
        {
            get
            {
                return this._downloadservername;
            }
            set
            {
                this._downloadservername = value;
            }
        }

        public bool IsOpened
        {
            get
            {
                return this._isopened;
            }
            set
            {
                this._isopened = value;
            }
        }

        public int IsOuter
        {
            get
            {
                return this._isouter;
            }
            set
            {
                this._isouter = value;
            }
        }

        public int TypeId
        {
            get
            {
                return this._typeid;
            }
            set
            {
                this._typeid = value;
            }
        }

        public string UnionId
        {
            get
            {
                return this._unionid;
            }
            set
            {
                this._unionid = value;
            }
        }
    }
}

