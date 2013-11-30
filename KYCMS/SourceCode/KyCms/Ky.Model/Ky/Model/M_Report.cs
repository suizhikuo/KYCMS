namespace Ky.Model
{
    using System;

    public class M_Report
    {
        private DateTime _addTime;
        private string _content;
        private int _isComplete;
        private int _reportId;
        private string _url;
        private int _userId;
        private string _userName;

        public DateTime AddTime
        {
            get
            {
                return this._addTime;
            }
            set
            {
                this._addTime = value;
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

        public int IsComplete
        {
            get
            {
                return this._isComplete;
            }
            set
            {
                this._isComplete = value;
            }
        }

        public int ReportId
        {
            get
            {
                return this._reportId;
            }
            set
            {
                this._reportId = value;
            }
        }

        public string Url
        {
            get
            {
                return this._url;
            }
            set
            {
                this._url = value;
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

        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                this._userName = value;
            }
        }
    }
}

