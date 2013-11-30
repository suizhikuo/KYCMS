namespace Ky.Model
{
    using System;

    public class M_Style
    {
        private string _content;
        private string _name;
        private int _stylecategoryid;
        private int _styleid;
        private int _type;

        public string Content
        {
            get
            {
                return this._content;
            }
            set
            {
                this._content = value;
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

        public int StyleCategoryId
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

        public int StyleID
        {
            get
            {
                return this._styleid;
            }
            set
            {
                this._styleid = value;
            }
        }

        public int Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}

