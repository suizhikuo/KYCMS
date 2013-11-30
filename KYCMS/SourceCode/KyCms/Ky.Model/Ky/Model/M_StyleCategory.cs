namespace Ky.Model
{
    using System;

    public class M_StyleCategory
    {
        private string _desc;
        private string _name;
        private int _parentid;
        private int _stylecategoryid;

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

        public int StyleCategoryID
        {
            get
            {
                return this._stylecategoryid;
            }
            set
            {
                this._stylecategoryid = value;
            }
        }
    }
}

