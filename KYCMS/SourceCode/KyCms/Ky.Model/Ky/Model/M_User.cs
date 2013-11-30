namespace Ky.Model
{
    using System;

    public class M_User
    {
        private string _answer = string.Empty;
        private string _confirmRegCode = string.Empty;
        private string _email = string.Empty;
        private int _errNum;
        private DateTime _errTime;
        private DateTime _expireTime = DateTime.Now;
        private int _groupid;
        private int _integral = 0;
        private bool _islock = false;
        private string _lastloginip = string.Empty;
        private DateTime _lastlogintime = DateTime.Now;
        private int _loginnum = 0;
        private string _logname = string.Empty;
        private string _question = string.Empty;
        private DateTime _regtime = DateTime.Now;
        private int _secret = 1;
        private int _status;
        private int _typeId;
        private int _userid;
        private string _userpwd = string.Empty;
        private decimal _yellowboy = 0M;

        public string Answer
        {
            get
            {
                return this._answer;
            }
            set
            {
                this._answer = value;
            }
        }

        public string ConfirmRegCode
        {
            get
            {
                return this._confirmRegCode;
            }
            set
            {
                this._confirmRegCode = value;
            }
        }

        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }

        public int ErrorNum
        {
            get
            {
                return this._errNum;
            }
            set
            {
                this._errNum = value;
            }
        }

        public DateTime ErrorTime
        {
            get
            {
                return this._errTime;
            }
            set
            {
                this._errTime = value;
            }
        }

        public DateTime ExpireTime
        {
            get
            {
                return this._expireTime;
            }
            set
            {
                this._expireTime = value;
            }
        }

        public int GroupID
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

        public int Integral
        {
            get
            {
                return this._integral;
            }
            set
            {
                this._integral = value;
            }
        }

        public bool IsLock
        {
            get
            {
                return this._islock;
            }
            set
            {
                this._islock = value;
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

        public int LoginNum
        {
            get
            {
                return this._loginnum;
            }
            set
            {
                this._loginnum = value;
            }
        }

        public string LogName
        {
            get
            {
                return this._logname;
            }
            set
            {
                this._logname = value;
            }
        }

        public string Question
        {
            get
            {
                return this._question;
            }
            set
            {
                this._question = value;
            }
        }

        public DateTime RegTime
        {
            get
            {
                return this._regtime;
            }
            set
            {
                this._regtime = value;
            }
        }

        public int Secret
        {
            get
            {
                return this._secret;
            }
            set
            {
                this._secret = value;
            }
        }

        public int Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }

        public int TypeId
        {
            get
            {
                return this._typeId;
            }
            set
            {
                this._typeId = value;
            }
        }

        public int UserID
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

        public string UserPwd
        {
            get
            {
                return this._userpwd;
            }
            set
            {
                this._userpwd = value;
            }
        }

        public decimal YellowBoy
        {
            get
            {
                return this._yellowboy;
            }
            set
            {
                this._yellowboy = value;
            }
        }
    }
}

