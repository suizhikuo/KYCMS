namespace Ky.Model
{
    using System;

    public class M_CustomForm
    {
        private DateTime _addtime;
        private int _customformid;
        private DateTime _endtime;
        private string _formdesc;
        private string _formname;
        private bool _issubmitnum;
        private bool _isunlocktime;
        private bool _isvalidate;
        private int _money;
        private int _showform;
        private DateTime _starttime;
        private string _tablename;
        private string _uploadpath;
        private int _UploadSize;
        private string _usergroup;

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

        public int CustomFormId
        {
            get
            {
                return this._customformid;
            }
            set
            {
                this._customformid = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return this._endtime;
            }
            set
            {
                this._endtime = value;
            }
        }

        public string FormDesc
        {
            get
            {
                return this._formdesc;
            }
            set
            {
                this._formdesc = value;
            }
        }

        public string FormName
        {
            get
            {
                return this._formname;
            }
            set
            {
                this._formname = value;
            }
        }

        public bool IsSubmitNum
        {
            get
            {
                return this._issubmitnum;
            }
            set
            {
                this._issubmitnum = value;
            }
        }

        public bool IsUnlockTime
        {
            get
            {
                return this._isunlocktime;
            }
            set
            {
                this._isunlocktime = value;
            }
        }

        public bool IsValidate
        {
            get
            {
                return this._isvalidate;
            }
            set
            {
                this._isvalidate = value;
            }
        }

        public int Money
        {
            get
            {
                return this._money;
            }
            set
            {
                this._money = value;
            }
        }

        public int ShowForm
        {
            get
            {
                return this._showform;
            }
            set
            {
                this._showform = value;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return this._starttime;
            }
            set
            {
                this._starttime = value;
            }
        }

        public string TableName
        {
            get
            {
                return this._tablename;
            }
            set
            {
                this._tablename = value;
            }
        }

        public string UploadPath
        {
            get
            {
                return this._uploadpath;
            }
            set
            {
                this._uploadpath = value;
            }
        }

        public int UploadSize
        {
            get
            {
                return this._UploadSize;
            }
            set
            {
                this._UploadSize = value;
            }
        }

        public string UserGroup
        {
            get
            {
                return this._usergroup;
            }
            set
            {
                this._usergroup = value;
            }
        }
    }
}

