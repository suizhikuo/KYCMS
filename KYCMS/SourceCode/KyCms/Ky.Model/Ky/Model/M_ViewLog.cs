namespace Ky.Model
{
    using System;

    public class M_ViewLog
    {
        private DateTime _addtime;
        private int _id;
        private int _infoid;
        private int _modeltype;
        private int _userid;
        private string _username;

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

        public int InfoId
        {
            get
            {
                return this._infoid;
            }
            set
            {
                this._infoid = value;
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
    }
}

