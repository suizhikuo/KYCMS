namespace Ky.Model
{
    using System;

    public class M_UserGroupModel
    {
        private DateTime _addtime;
        private string _content;
        private int _id;
        private bool _IsHtml;
        private bool _isvalidate;
        private string _modelhtml;
        private string _name;
        private int _SpaceTypeId;
        private string _tablename;
        private int _UserGroupId;

        public DateTime AddTime
        {
            get
            {
                return this._addtime;
            }
            set
            {
                this._addtime = value;
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

        public bool IsHtml
        {
            get
            {
                return this._IsHtml;
            }
            set
            {
                this._IsHtml = value;
            }
        }

        public bool IsValidate
        {
            get
            {
                return this._isvalidate;
            }
            set
            {
                this._isvalidate = value;
            }
        }

        public string ModelHtml
        {
            get
            {
                return this._modelhtml;
            }
            set
            {
                this._modelhtml = value;
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

        public int SpaceTypeId
        {
            get
            {
                return this._SpaceTypeId;
            }
            set
            {
                this._SpaceTypeId = value;
            }
        }

        public string TableName
        {
            get
            {
                return this._tablename;
            }
            set
            {
                this._tablename = value;
            }
        }

        public int UserGroupId
        {
            get
            {
                return this._UserGroupId;
            }
            set
            {
                this._UserGroupId = value;
            }
        }
    }
}

