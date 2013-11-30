namespace Ky.Model
{
    using System;

    public class M_UserPhoto
    {
        private int _albumid;
        private string _description = "";
        private string _filename = "";
        private string _filepath = "";
        private int _filesize = 0;
        private int _photoid;
        private string _posttime = "";
        private int _userid = 0;
        private string _username = "";
        private int _visitnum;

        public int AlbumId
        {
            get
            {
                return this._albumid;
            }
            set
            {
                this._albumid = value;
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

        public string FilePath
        {
            get
            {
                return this._filepath;
            }
            set
            {
                this._filepath = value;
            }
        }

        public int FileSize
        {
            get
            {
                return this._filesize;
            }
            set
            {
                this._filesize = value;
            }
        }

        public int PhotoId
        {
            get
            {
                return this._photoid;
            }
            set
            {
                this._photoid = value;
            }
        }

        public string PostTime
        {
            get
            {
                return this._posttime;
            }
            set
            {
                this._posttime = value;
            }
        }

        public int UserId
        {
            get
            {
                return this._userid;
            }
            set
            {
                this._userid = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }

        public int VisitNum
        {
            get
            {
                return this._visitnum;
            }
            set
            {
                this._visitnum = value;
            }
        }
    }
}

