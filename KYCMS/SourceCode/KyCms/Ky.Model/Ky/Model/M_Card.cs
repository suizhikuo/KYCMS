namespace Ky.Model
{
    using System;

    public class M_Card
    {
        private int _adminid;
        private string _adminname;
        private string _cardaccount;
        private int _cardday;
        private int _cardpoint;
        private int _id;
        private bool _isused;
        private DateTime _overduedate;
        private string _password;
        private CardType _type;
        private int _userid;
        private string _username;

        public int AdminID
        {
            get
            {
                return this._adminid;
            }
            set
            {
                this._adminid = value;
            }
        }

        public string AdminName
        {
            get
            {
                return this._adminname;
            }
            set
            {
                this._adminname = value;
            }
        }

        public string CardAccount
        {
            get
            {
                return this._cardaccount;
            }
            set
            {
                this._cardaccount = value;
            }
        }

        public int CardDay
        {
            get
            {
                return this._cardday;
            }
            set
            {
                this._cardday = value;
            }
        }

        public int CardPoint
        {
            get
            {
                return this._cardpoint;
            }
            set
            {
                this._cardpoint = value;
            }
        }

        public int ID
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

        public bool IsUsed
        {
            get
            {
                return this._isused;
            }
            set
            {
                this._isused = value;
            }
        }

        public DateTime OverdueDate
        {
            get
            {
                return this._overduedate;
            }
            set
            {
                this._overduedate = value;
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        public CardType Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }

        public int UserID
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
    }
}

