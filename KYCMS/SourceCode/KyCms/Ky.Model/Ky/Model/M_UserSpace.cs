namespace Ky.Model
{
    using System;

    public class M_UserSpace
    {
        private string _addtime;
        private int _id;
        private string _password;
        private int _prevpower;
        private string _spacedescription;
        private string _spacename;
        private int _templateid;
        private int _userid;
        private string _username;
        private int _usertype;

        public string AddTime
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

        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
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

        public int PrevPower
        {
            get
            {
                return this._prevpower;
            }
            set
            {
                this._prevpower = value;
            }
        }

        public string SpaceDescription
        {
            get
            {
                return this._spacedescription;
            }
            set
            {
                this._spacedescription = value;
            }
        }

        public string SpaceName
        {
            get
            {
                return this._spacename;
            }
            set
            {
                this._spacename = value;
            }
        }

        public int TemplateId
        {
            get
            {
                return this._templateid;
            }
            set
            {
                this._templateid = value;
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

        public int UserType
        {
            get
            {
                return this._usertype;
            }
            set
            {
                this._usertype = value;
            }
        }
    }
}

