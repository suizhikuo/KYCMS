﻿namespace Ky.Model
{
    using System;

    public class M_ModelField
    {
        private DateTime _adddate;
        private string _alias;
        private string _content;
        private string _description;
        private int _fieldid;
        private bool _isnotnull;
        private bool _issearchform;
        private int _modelid;
        private string _name;
        private int _orderid;
        private string _type;

        public DateTime AddDate
        {
            get
            {
                return this._adddate;
            }
            set
            {
                this._adddate = value;
            }
        }

        public string Alias
        {
            get
            {
                return this._alias;
            }
            set
            {
                this._alias = value;
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

        public int FieldId
        {
            get
            {
                return this._fieldid;
            }
            set
            {
                this._fieldid = value;
            }
        }

        public bool IsNotNull
        {
            get
            {
                return this._isnotnull;
            }
            set
            {
                this._isnotnull = value;
            }
        }

        public bool IsSearchForm
        {
            get
            {
                return this._issearchform;
            }
            set
            {
                this._issearchform = value;
            }
        }

        public int ModelId
        {
            get
            {
                return this._modelid;
            }
            set
            {
                this._modelid = value;
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

        public int OrderId
        {
            get
            {
                return this._orderid;
            }
            set
            {
                this._orderid = value;
            }
        }

        public string Type
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

