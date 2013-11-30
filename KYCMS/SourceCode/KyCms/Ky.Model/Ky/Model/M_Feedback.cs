namespace Ky.Model
{
    using System;

    public class M_Feedback
    {
        private string _author;
        private int _categoryId;
        private string _content;
        private DateTime _endDate;
        private int _id;
        private string _ip;
        private int _parentId;
        private DateTime _replyDate;
        private int _reward;
        private int _scoring;
        private int _state;
        private string _title;

        public string Author
        {
            get
            {
                return this._author;
            }
            set
            {
                this._author = value;
            }
        }

        public int CategoryId
        {
            get
            {
                return this._categoryId;
            }
            set
            {
                this._categoryId = value;
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

        public DateTime EndDate
        {
            get
            {
                return this._endDate;
            }
            set
            {
                this._endDate = value;
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

        public string Ip
        {
            get
            {
                return this._ip;
            }
            set
            {
                this._ip = value;
            }
        }

        public int ParentId
        {
            get
            {
                return this._parentId;
            }
            set
            {
                this._parentId = value;
            }
        }

        public DateTime ReplyDate
        {
            get
            {
                return this._replyDate;
            }
            set
            {
                this._replyDate = value;
            }
        }

        public int Reward
        {
            get
            {
                return this._reward;
            }
            set
            {
                this._reward = value;
            }
        }

        public int Scoring
        {
            get
            {
                return this._scoring;
            }
            set
            {
                this._scoring = value;
            }
        }

        public int State
        {
            get
            {
                return this._state;
            }
            set
            {
                this._state = value;
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
    }
}

