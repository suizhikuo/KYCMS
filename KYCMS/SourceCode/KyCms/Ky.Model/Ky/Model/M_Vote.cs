namespace Ky.Model
{
    using System;

    public class M_Vote
    {
        private int _displaytype = 1;
        private bool _ismore = false;
        private int _itemnum1 = 0;
        private int _itemnum2 = 0;
        private int _itemnum3 = 0;
        private int _itemnum4 = 0;
        private int _itemnum5 = 0;
        private int _itemnum6 = 0;
        private string _itemtitle1 = null;
        private string _itemtitle2 = null;
        private string _itemtitle3 = null;
        private string _itemtitle4 = null;
        private string _itemtitle5 = null;
        private string _itemtitle6 = null;
        private int _modeltype = 1;
        private int _subjectId;
        private int _voteid;
        private string _votetitle;

        public int DisplayType
        {
            get
            {
                return this._displaytype;
            }
            set
            {
                this._displaytype = value;
            }
        }

        public bool IsMore
        {
            get
            {
                return this._ismore;
            }
            set
            {
                this._ismore = value;
            }
        }

        public int ItemNum1
        {
            get
            {
                return this._itemnum1;
            }
            set
            {
                this._itemnum1 = value;
            }
        }

        public int ItemNum2
        {
            get
            {
                return this._itemnum2;
            }
            set
            {
                this._itemnum2 = value;
            }
        }

        public int ItemNum3
        {
            get
            {
                return this._itemnum3;
            }
            set
            {
                this._itemnum3 = value;
            }
        }

        public int ItemNum4
        {
            get
            {
                return this._itemnum4;
            }
            set
            {
                this._itemnum4 = value;
            }
        }

        public int ItemNum5
        {
            get
            {
                return this._itemnum5;
            }
            set
            {
                this._itemnum5 = value;
            }
        }

        public int ItemNum6
        {
            get
            {
                return this._itemnum6;
            }
            set
            {
                this._itemnum6 = value;
            }
        }

        public string ItemTitle1
        {
            get
            {
                return this._itemtitle1;
            }
            set
            {
                this._itemtitle1 = value;
            }
        }

        public string ItemTitle2
        {
            get
            {
                return this._itemtitle2;
            }
            set
            {
                this._itemtitle2 = value;
            }
        }

        public string ItemTitle3
        {
            get
            {
                return this._itemtitle3;
            }
            set
            {
                this._itemtitle3 = value;
            }
        }

        public string ItemTitle4
        {
            get
            {
                return this._itemtitle4;
            }
            set
            {
                this._itemtitle4 = value;
            }
        }

        public string ItemTitle5
        {
            get
            {
                return this._itemtitle5;
            }
            set
            {
                this._itemtitle5 = value;
            }
        }

        public string ItemTitle6
        {
            get
            {
                return this._itemtitle6;
            }
            set
            {
                this._itemtitle6 = value;
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

        public int SubjectId
        {
            get
            {
                return this._subjectId;
            }
            set
            {
                this._subjectId = value;
            }
        }

        public int VoteId
        {
            get
            {
                return this._voteid;
            }
            set
            {
                this._voteid = value;
            }
        }

        public string VoteTitle
        {
            get
            {
                return this._votetitle;
            }
            set
            {
                this._votetitle = value;
            }
        }
    }
}

