namespace Ky.Model
{
    using System;

    public class M_Enterprise
    {
        private string _addtime;
        private string _conetent;
        private int _id;
        private string _title;
        private int _typeid;
        private int _userid;

        public string AddTime
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

        public string Conetent
        {
            get
            {
                return this._conetent;
            }
            set
            {
                this._conetent = value;
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

        public int TypeId
        {
            get
            {
                return this._typeid;
            }
            set
            {
                this._typeid = value;
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

