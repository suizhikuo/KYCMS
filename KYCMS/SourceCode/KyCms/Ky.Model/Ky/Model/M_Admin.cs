namespace Ky.Model
{
    using System;

    public class M_Admin
    {
        private int _addcount;
        private bool _allowmultilogin;
        private int _checkcount;
        private int _groupid;
        private string _groupname;
        private string _lastloginip;
        private DateTime _lastlogintime;
        private DateTime _lastlogouttime;
        private string _loginname;
        private int _logintime;
        private string _password;
        private string _randnumber;
        private int _rejectcount;
        private int _userid;
        private string _username;

        public int AddCount
        {
            get
            {
                return this._addcount;
            }
            set
            {
                this._addcount = value;
            }
        }

        public bool AllowMultiLogin
        {
            get
            {
                return this._allowmultilogin;
            }
            set
            {
                this._allowmultilogin = value;
            }
        }

        public int CheckCount
        {
            get
            {
                return this._checkcount;
            }
            set
            {
                this._checkcount = value;
            }
        }

        public int GroupId
        {
            get
            {
                return this._groupid;
            }
            set
            {
                this._groupid = value;
            }
        }

        public string GroupName
        {
            get
            {
                return this._groupname;
            }
            set
            {
                this._groupname = value;
            }
        }

        public string LastLoginIP
        {
            get
            {
                return this._lastloginip;
            }
            set
            {
                this._lastloginip = value;
            }
        }

        public DateTime LastLoginTime
        {
            get
            {
                return this._lastlogintime;
            }
            set
            {
                this._lastlogintime = value;
            }
        }

        public DateTime LastLogoutTime
        {
            get
            {
                return this._lastlogouttime;
            }
            set
            {
                this._lastlogouttime = value;
            }
        }

        public string LoginName
        {
            get
            {
                return this._loginname;
            }
            set
            {
                this._loginname = value;
            }
        }

        public int LoginTime
        {
            get
            {
                return this._logintime;
            }
            set
            {
                this._logintime = value;
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        public string RandNumber
        {
            get
            {
                return this._randnumber;
            }
            set
            {
                this._randnumber = value;
            }
        }

        public int RejectCount
        {
            get
            {
                return this._rejectcount;
            }
            set
            {
                this._rejectcount = value;
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

