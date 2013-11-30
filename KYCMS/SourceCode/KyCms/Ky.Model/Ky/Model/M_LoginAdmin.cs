namespace Ky.Model
{
    using System;

    public class M_LoginAdmin
    {
        private string _adminName;
        private string _loginName;
        private string _password;
        private int _userId;

        public string AdminName
        {
            get
            {
                return this._adminName;
            }
            set
            {
                this._adminName = value;
            }
        }

        public string LoginName
        {
            get
            {
                return this._loginName;
            }
            set
            {
                this._loginName = value;
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

        public int UserId
        {
            get
            {
                return this._userId;
            }
            set
            {
                this._userId = value;
            }
        }
    }
}

