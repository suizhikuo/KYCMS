namespace Ky.Model
{
    using System;

    public class M_UserLog
    {
        private DateTime _addtime;
        private string _description;
        private int _infoid;
        private int _logid;
        private int _modeltype;
        private int _point;
        private int _userid;
        private string _username;

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

        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

        public int InfoId
        {
            get
            {
                return this._infoid;
            }
            set
            {
                this._infoid = value;
            }
        }

        public int LogId
        {
            get
            {
                return this._logid;
            }
            set
            {
                this._logid = value;
            }
        }

        public int ModelType
        {
            get
            {
                return this._modeltype;
            }
            set
            {
                this._modeltype = value;
            }
        }

        public int Point
        {
            get
            {
                return this._point;
            }
            set
            {
                this._point = value;
            }
        }

        public int UserId
        {
            get
            {
                return this._userid;
            }
            set
            {
                this._userid = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }
    }
}

