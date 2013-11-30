namespace Ky.Model
{
    using System;

    public class M_Tag
    {
        private int _daysearchcount;
        private int _modeltype;
        private string _name;
        private int _tagcategoryid;
        private long _tagid;
        private int _totalsearchcount;
        private int _userid;
        private string _username;
        private int _yesterdaysearchcount;

        public int DaySearchCount
        {
            get
            {
                return this._daysearchcount;
            }
            set
            {
                this._daysearchcount = value;
            }
        }

        public int ModelType
        {
            get
            {
                return this._modeltype;
            }
            set
            {
                this._modeltype = value;
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

        public int TagCategoryId
        {
            get
            {
                return this._tagcategoryid;
            }
            set
            {
                this._tagcategoryid = value;
            }
        }

        public long TagId
        {
            get
            {
                return this._tagid;
            }
            set
            {
                this._tagid = value;
            }
        }

        public int TotalSearchCount
        {
            get
            {
                return this._totalsearchcount;
            }
            set
            {
                this._totalsearchcount = value;
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

        public int YesterdaySearchCount
        {
            get
            {
                return this._yesterdaysearchcount;
            }
            set
            {
                this._yesterdaysearchcount = value;
            }
        }
    }
}

