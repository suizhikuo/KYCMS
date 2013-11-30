namespace Ky.Model
{
    using System;

    public class M_LabelContent
    {
        private string _anomalystyle;
        private string _content;
        private int _labelcategoryid;
        private int _lbCategoryId;
        private int _modetype;
        private string _name;

        public string AnomalyStyle
        {
            get
            {
                return this._anomalystyle;
            }
            set
            {
                this._anomalystyle = value;
            }
        }

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

        public int LabelCategoryID
        {
            get
            {
                return this._labelcategoryid;
            }
            set
            {
                this._labelcategoryid = value;
            }
        }

        public int LbCategoryId
        {
            get
            {
                return this._lbCategoryId;
            }
            set
            {
                this._lbCategoryId = value;
            }
        }

        public int ModeType
        {
            get
            {
                return this._modetype;
            }
            set
            {
                this._modetype = value;
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
    }
}

