namespace Ky.Model
{
    using System;

    public class M_UserMessage
    {
        private string _anounname;
        private string _content;
        private string _homepage;
        private int _id;
        private bool _isprivacy;
        private bool _isresume;
        private string _posttime;
        private string _resumecontent;
        private string _resumetime;
        private string _title;
        private int _userid;

        public string AnounName
        {
            get
            {
                return this._anounname;
            }
            set
            {
                this._anounname = value;
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

        public string HomePage
        {
            get
            {
                return this._homepage;
            }
            set
            {
                this._homepage = value;
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

        public bool IsPrivacy
        {
            get
            {
                return this._isprivacy;
            }
            set
            {
                this._isprivacy = value;
            }
        }

        public bool IsResume
        {
            get
            {
                return this._isresume;
            }
            set
            {
                this._isresume = value;
            }
        }

        public string PostTime
        {
            get
            {
                return this._posttime;
            }
            set
            {
                this._posttime = value;
            }
        }

        public string ResumeContent
        {
            get
            {
                return this._resumecontent;
            }
            set
            {
                this._resumecontent = value;
            }
        }

        public string ResumeTime
        {
            get
            {
                return this._resumetime;
            }
            set
            {
                this._resumetime = value;
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
    }
}

