namespace Ky.Model
{
    using System;

    public class M_Link
    {
        private DateTime _addtime;
        private string _description;
        private string _email;
        private bool _isdisable;
        private string _linkcategory;
        private int _linkid;
        private int _linktype;
        private string _ownername;
        private string _sitelogo;
        private string _sitename;
        private string _siteurl;
        private int _status;

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

        public bool IsDisable
        {
            get
            {
                return this._isdisable;
            }
            set
            {
                this._isdisable = value;
            }
        }

        public string LinkCategory
        {
            get
            {
                return this._linkcategory;
            }
            set
            {
                this._linkcategory = value;
            }
        }

        public int LinkId
        {
            get
            {
                return this._linkid;
            }
            set
            {
                this._linkid = value;
            }
        }

        public int LinkType
        {
            get
            {
                return this._linktype;
            }
            set
            {
                this._linktype = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return this._ownername;
            }
            set
            {
                this._ownername = value;
            }
        }

        public string SiteLogo
        {
            get
            {
                return this._sitelogo;
            }
            set
            {
                this._sitelogo = value;
            }
        }

        public string SiteName
        {
            get
            {
                return this._sitename;
            }
            set
            {
                this._sitename = value;
            }
        }

        public string SiteUrl
        {
            get
            {
                return this._siteurl;
            }
            set
            {
                this._siteurl = value;
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
    }
}

