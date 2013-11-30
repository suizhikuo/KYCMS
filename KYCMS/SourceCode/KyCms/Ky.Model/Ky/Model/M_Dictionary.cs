namespace Ky.Model
{
    using System;

    public class M_Dictionary
    {
        private string _dicName;
        private int _id;
        private int _parentId;
        private int _sort;

        public string DicName
        {
            get
            {
                return this._dicName;
            }
            set
            {
                this._dicName = value;
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

        public int Sort
        {
            get
            {
                return this._sort;
            }
            set
            {
                this._sort = value;
            }
        }
    }
}

