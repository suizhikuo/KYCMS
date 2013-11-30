namespace Ky.Model
{
    using System;

    public class M_Special
    {
        private string _extension;
        private int _id;
        private bool _iscommand;
        private bool _isDeleted;
        private bool _islock;
        private string _metakeyword;
        private string _metaremark;
        private int _parentid;
        private string _picSavePath;
        private string _savedirtype;
        private int _siteid;
        private string _specalcontent;
        private int _specalitemnum;
        private string _specaltemplet;
        private DateTime _specialaddtime;
        private string _specialcname;
        private string _specialdomain;
        private string _specialename;
        private string _specialremark;

        public string Extension
        {
            get
            {
                return this._extension;
            }
            set
            {
                this._extension = value;
            }
        }

        public int ID
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

        public bool IsCommand
        {
            get
            {
                return this._iscommand;
            }
            set
            {
                this._iscommand = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return this._isDeleted;
            }
            set
            {
                this._isDeleted = value;
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

        public string MetaKeyWord
        {
            get
            {
                return this._metakeyword;
            }
            set
            {
                this._metakeyword = value;
            }
        }

        public string MetaRemark
        {
            get
            {
                return this._metaremark;
            }
            set
            {
                this._metaremark = value;
            }
        }

        public int ParentID
        {
            get
            {
                return this._parentid;
            }
            set
            {
                this._parentid = value;
            }
        }

        public string PicSavePath
        {
            get
            {
                return this._picSavePath;
            }
            set
            {
                this._picSavePath = value;
            }
        }

        public string SaveDirType
        {
            get
            {
                return this._savedirtype;
            }
            set
            {
                this._savedirtype = value;
            }
        }

        public int SiteID
        {
            get
            {
                return this._siteid;
            }
            set
            {
                this._siteid = value;
            }
        }

        public DateTime SpecialAddTime
        {
            get
            {
                return this._specialaddtime;
            }
            set
            {
                this._specialaddtime = value;
            }
        }

        public string SpecialCName
        {
            get
            {
                return this._specialcname;
            }
            set
            {
                this._specialcname = value;
            }
        }

        public string SpecialContent
        {
            get
            {
                return this._specalcontent;
            }
            set
            {
                this._specalcontent = value;
            }
        }

        public string SpecialDomain
        {
            get
            {
                return this._specialdomain;
            }
            set
            {
                this._specialdomain = value;
            }
        }

        public string SpecialEName
        {
            get
            {
                return this._specialename;
            }
            set
            {
                this._specialename = value;
            }
        }

        public int SpecialItemNum
        {
            get
            {
                return this._specalitemnum;
            }
            set
            {
                this._specalitemnum = value;
            }
        }

        public string SpecialRemark
        {
            get
            {
                return this._specialremark;
            }
            set
            {
                this._specialremark = value;
            }
        }

        public string SpecialTemplet
        {
            get
            {
                return this._specaltemplet;
            }
            set
            {
                this._specaltemplet = value;
            }
        }
    }
}

