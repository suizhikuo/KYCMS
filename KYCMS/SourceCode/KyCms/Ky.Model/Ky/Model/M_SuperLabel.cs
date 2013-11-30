namespace Ky.Model
{
    using System;

    public class M_SuperLabel
    {
        private DateTime _AddTime;
        private string _content;
        private string _DataBaseConn;
        private int _databasetype;
        private string _guesttable;
        private string _hosttable;
        private bool _IsHtml;
        private bool _isunlockpage;
        private int _lbcategoryid;
        private string _lbcategoryname;
        private string _name;
        private int _NumColumns;
        private int _PageSize;
        private string _sqlstr;
        private string _superdes;
        private int _superid;

        public DateTime AddTime
        {
            get
            {
                return this._AddTime;
            }
            set
            {
                this._AddTime = value;
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

        public string DataBaseConn
        {
            get
            {
                return this._DataBaseConn;
            }
            set
            {
                this._DataBaseConn = value;
            }
        }

        public int DataBaseType
        {
            get
            {
                return this._databasetype;
            }
            set
            {
                this._databasetype = value;
            }
        }

        public string GuestTable
        {
            get
            {
                return this._guesttable;
            }
            set
            {
                this._guesttable = value;
            }
        }

        public string HostTable
        {
            get
            {
                return this._hosttable;
            }
            set
            {
                this._hosttable = value;
            }
        }

        public bool IsHtml
        {
            get
            {
                return this._IsHtml;
            }
            set
            {
                this._IsHtml = value;
            }
        }

        public bool IsUnlockPage
        {
            get
            {
                return this._isunlockpage;
            }
            set
            {
                this._isunlockpage = value;
            }
        }

        public int LbCategoryId
        {
            get
            {
                return this._lbcategoryid;
            }
            set
            {
                this._lbcategoryid = value;
            }
        }

        public string LbCategoryName
        {
            get
            {
                return this._lbcategoryname;
            }
            set
            {
                this._lbcategoryname = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public int NumColumns
        {
            get
            {
                return this._NumColumns;
            }
            set
            {
                this._NumColumns = value;
            }
        }

        public int PageSize
        {
            get
            {
                return this._PageSize;
            }
            set
            {
                this._PageSize = value;
            }
        }

        public string SqlStr
        {
            get
            {
                return this._sqlstr;
            }
            set
            {
                this._sqlstr = value;
            }
        }

        public string SuperDes
        {
            get
            {
                return this._superdes;
            }
            set
            {
                this._superdes = value;
            }
        }

        public int SuperId
        {
            get
            {
                return this._superid;
            }
            set
            {
                this._superid = value;
            }
        }
    }
}

