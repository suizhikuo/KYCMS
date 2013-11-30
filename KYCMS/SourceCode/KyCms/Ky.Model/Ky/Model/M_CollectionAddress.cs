namespace Ky.Model
{
    using System;

    public class M_CollectionAddress
    {
        private int _colectionid;
        private string _collectionurl;
        private int _id;
        private bool _state;

        public int ColectionId
        {
            get
            {
                return this._colectionid;
            }
            set
            {
                this._colectionid = value;
            }
        }

        public string CollectionUrl
        {
            get
            {
                return this._collectionurl;
            }
            set
            {
                this._collectionurl = value;
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

        public bool State
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
    }
}

