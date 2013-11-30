namespace Ky.Model
{
    using System;

    public class M_Review
    {
        private int _brarnum;
        private int _fightnum;
        private int _id;
        private string _infoId;
        private bool _isargue;
        private bool _ischeck;
        private bool _iselite;
        private int _issquare;
        private int _modelType;
        private string _reviewcontent;
        private string _reviewip;
        private DateTime _reviewtime;
        private string _reviewtitle;
        private string _usernum;

        public int BrarNum
        {
            get
            {
                return this._brarnum;
            }
            set
            {
                this._brarnum = value;
            }
        }

        public int FightNum
        {
            get
            {
                return this._fightnum;
            }
            set
            {
                this._fightnum = value;
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

        public string InfoId
        {
            get
            {
                return this._infoId;
            }
            set
            {
                this._infoId = value;
            }
        }

        public bool IsArgue
        {
            get
            {
                return this._isargue;
            }
            set
            {
                this._isargue = value;
            }
        }

        public bool IsCheck
        {
            get
            {
                return this._ischeck;
            }
            set
            {
                this._ischeck = value;
            }
        }

        public bool IsElite
        {
            get
            {
                return this._iselite;
            }
            set
            {
                this._iselite = value;
            }
        }

        public int IsSquare
        {
            get
            {
                return this._issquare;
            }
            set
            {
                this._issquare = value;
            }
        }

        public int ModelType
        {
            get
            {
                return this._modelType;
            }
            set
            {
                this._modelType = value;
            }
        }

        public string ReviewContent
        {
            get
            {
                return this._reviewcontent;
            }
            set
            {
                this._reviewcontent = value;
            }
        }

        public string ReviewIP
        {
            get
            {
                return this._reviewip;
            }
            set
            {
                this._reviewip = value;
            }
        }

        public DateTime ReviewTime
        {
            get
            {
                return this._reviewtime;
            }
            set
            {
                this._reviewtime = value;
            }
        }

        public string ReviewTitle
        {
            get
            {
                return this._reviewtitle;
            }
            set
            {
                this._reviewtitle = value;
            }
        }

        public string UserNum
        {
            get
            {
                return this._usernum;
            }
            set
            {
                this._usernum = value;
            }
        }
    }
}

