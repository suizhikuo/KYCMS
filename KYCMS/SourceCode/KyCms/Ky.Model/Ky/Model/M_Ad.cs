namespace Ky.Model
{
    using System;

    public class M_Ad
    {
        private int _adid;
        private string _adname;
        private int _adtype;
        private string _categoryid;
        private string _content;
        private DateTime _endtime;
        private int _hitcount;
        private int _weight;

        public int AdId
        {
            get
            {
                return this._adid;
            }
            set
            {
                this._adid = value;
            }
        }

        public string AdName
        {
            get
            {
                return this._adname;
            }
            set
            {
                this._adname = value;
            }
        }

        public int AdType
        {
            get
            {
                return this._adtype;
            }
            set
            {
                this._adtype = value;
            }
        }

        public string CategoryId
        {
            get
            {
                return this._categoryid;
            }
            set
            {
                this._categoryid = value;
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

        public int HitCount
        {
            get
            {
                return this._hitcount;
            }
            set
            {
                this._hitcount = value;
            }
        }

        public int Weight
        {
            get
            {
                return this._weight;
            }
            set
            {
                this._weight = value;
            }
        }
    }
}

