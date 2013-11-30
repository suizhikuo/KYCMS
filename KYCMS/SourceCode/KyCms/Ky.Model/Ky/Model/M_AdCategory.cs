namespace Ky.Model
{
    using System;

    public class M_AdCategory
    {
        private int _adcategoryid;
        private string _categoryname;
        private string _description;
        private int _displaytype;
        private int _isdisabled;
        private string _widthheigth;

        public int AdCategoryId
        {
            get
            {
                return this._adcategoryid;
            }
            set
            {
                this._adcategoryid = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return this._categoryname;
            }
            set
            {
                this._categoryname = value;
            }
        }

        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

        public int DisplayType
        {
            get
            {
                return this._displaytype;
            }
            set
            {
                this._displaytype = value;
            }
        }

        public int IsDisabled
        {
            get
            {
                return this._isdisabled;
            }
            set
            {
                this._isdisabled = value;
            }
        }

        public string WidthHeigth
        {
            get
            {
                return this._widthheigth;
            }
            set
            {
                this._widthheigth = value;
            }
        }
    }
}

