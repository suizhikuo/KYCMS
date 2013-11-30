namespace Ky.Model
{
    using System;

    public class M_TagCategory
    {
        private string _desc;
        private string _name;
        private int _tagcategoryid;

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

        public int TagCategoryId
        {
            get
            {
                return this._tagcategoryid;
            }
            set
            {
                this._tagcategoryid = value;
            }
        }
    }
}

