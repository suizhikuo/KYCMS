namespace Ky.Model
{
    using System;

    public class M_LbCategory
    {
        private string _desc;
        private int _lbcategoryid;
        private string _name;
        private int _parentid;

        public string Desc
        {
            get
            {
                return this._desc;
            }
            set
            {
                this._desc = value;
            }
        }

        public int LbCategoryID
        {
            get
            {
                return this._lbcategoryid;
            }
            set
            {
                this._lbcategoryid = value;
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

        public int ParentID
        {
            get
            {
                return this._parentid;
            }
            set
            {
                this._parentid = value;
            }
        }
    }
}

