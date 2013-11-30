namespace Ky.Model
{
    using System;

    public class M_UserFavorite
    {
        private DateTime _adddate;
        private int _id;
        private string _title;
        private string _url;
        private int _userid;

        public DateTime AddDate
        {
            get
            {
                return this._adddate;
            }
            set
            {
                this._adddate = value;
            }
        }

        public int id
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
                return this._userid;
            }
            set
            {
                this._userid = value;
            }
        }
    }
}

