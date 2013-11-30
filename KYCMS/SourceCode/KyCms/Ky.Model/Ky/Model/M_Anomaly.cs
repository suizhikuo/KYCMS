namespace Ky.Model
{
    using System;

    public class M_Anomaly
    {
        private int _chid;
        private string _colname;
        private int _id;
        private int _infoid;
        private string _title;

        public int ChId
        {
            get
            {
                return this._chid;
            }
            set
            {
                this._chid = value;
            }
        }

        public string ColName
        {
            get
            {
                return this._colname;
            }
            set
            {
                this._colname = value;
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

