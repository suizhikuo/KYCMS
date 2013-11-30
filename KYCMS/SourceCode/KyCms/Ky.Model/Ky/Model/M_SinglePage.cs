namespace Ky.Model
{
    using System;

    public class M_SinglePage
    {
        private DateTime _addtime;
        private string _content;
        private string _fileextend;
        private string _filename;
        private string _folderpath;
        private string _name;
        private int _singleid;
        private string _templatepath;

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

        public string FileExtend
        {
            get
            {
                return this._fileextend;
            }
            set
            {
                this._fileextend = value;
            }
        }

        public string FileName
        {
            get
            {
                return this._filename;
            }
            set
            {
                this._filename = value;
            }
        }

        public string FolderPath
        {
            get
            {
                return this._folderpath;
            }
            set
            {
                this._folderpath = value;
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

        public int SingleId
        {
            get
            {
                return this._singleid;
            }
            set
            {
                this._singleid = value;
            }
        }

        public string TemplatePath
        {
            get
            {
                return this._templatepath;
            }
            set
            {
                this._templatepath = value;
            }
        }
    }
}

