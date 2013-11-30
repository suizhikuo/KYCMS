namespace Ky.Model
{
    using System;

    public class M_Notice
    {
        private DateTime _adddate;
        private string _content;
        private int _ispriority;
        private string _isstate;
        private int _noticeid;
        private DateTime _overduedate;
        private string _title;
        private int _typeid;
        private int _userid;
        private string _username;

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

        public string Content
        {
            get
            {
                return this._content;
            }
            set
            {
                this._content = value;
            }
        }

        public int IsPriority
        {
            get
            {
                return this._ispriority;
            }
            set
            {
                this._ispriority = value;
            }
        }

        public string IsState
        {
            get
            {
                return this._isstate;
            }
            set
            {
                this._isstate = value;
            }
        }

        public int NoticeId
        {
            get
            {
                return this._noticeid;
            }
            set
            {
                this._noticeid = value;
            }
        }

        public DateTime OverdueDate
        {
            get
            {
                return this._overduedate;
            }
            set
            {
                this._overduedate = value;
            }
        }

        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
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

