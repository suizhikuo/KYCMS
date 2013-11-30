namespace Ky.Model
{
    using System;

    public class M_Superior
    {
        private string _endcode;
        private int _id;
        private string _name;
        private string _startcode;

        public string EndCode
        {
            get
            {
                return this._endcode;
            }
            set
            {
                this._endcode = value;
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

        public string StartCode
        {
            get
            {
                return this._startcode;
            }
            set
            {
                this._startcode = value;
            }
        }
    }
}

