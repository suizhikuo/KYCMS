namespace Ky.Model
{
    using System;

    public class M_UserGroup
    {
        private DateTime _adddate;
        private string _ColumnPower;
        private string _GroupPower;
        private int _issystem;
        private int _typeid;
        private string _usergroupcontent;
        private int _usergroupid;
        private string _usergroupname;

        public DateTime AddDate
        {
            get
            {
                return this._adddate;
            }
            set
            {
                this._adddate = value;
            }
        }

        public string ColumnPower
        {
            get
            {
                return this._ColumnPower;
            }
            set
            {
                this._ColumnPower = value;
            }
        }

        public string GroupPower
        {
            get
            {
                return this._GroupPower;
            }
            set
            {
                this._GroupPower = value;
            }
        }

        public int IsSystem
        {
            get
            {
                return this._issystem;
            }
            set
            {
                this._issystem = value;
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

        public string UserGroupContent
        {
            get
            {
                return this._usergroupcontent;
            }
            set
            {
                this._usergroupcontent = value;
            }
        }

        public int UserGroupId
        {
            get
            {
                return this._usergroupid;
            }
            set
            {
                this._usergroupid = value;
            }
        }

        public string UserGroupName
        {
            get
            {
                return this._usergroupname;
            }
            set
            {
                this._usergroupname = value;
            }
        }
    }
}

