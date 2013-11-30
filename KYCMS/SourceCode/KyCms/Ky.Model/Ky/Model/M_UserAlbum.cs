namespace Ky.Model
{
    using System;

    public class M_UserAlbum
    {
        private string _addtime;
        private string _albumcate;
        private string _albumdescription;
        private string _albumname;
        private string _albumpassword;
        private int _id;
        private int _imgcount;
        private int _isopened;
        private string _logo;
        private int _userid;
        private string _username;

        public string AddTime
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

        public string AlbumCate
        {
            get
            {
                return this._albumcate;
            }
            set
            {
                this._albumcate = value;
            }
        }

        public string AlbumDescription
        {
            get
            {
                return this._albumdescription;
            }
            set
            {
                this._albumdescription = value;
            }
        }

        public string AlbumName
        {
            get
            {
                return this._albumname;
            }
            set
            {
                this._albumname = value;
            }
        }

        public string AlbumPassword
        {
            get
            {
                return this._albumpassword;
            }
            set
            {
                this._albumpassword = value;
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

        public int ImgCount
        {
            get
            {
                return this._imgcount;
            }
            set
            {
                this._imgcount = value;
            }
        }

        public int IsOpened
        {
            get
            {
                return this._isopened;
            }
            set
            {
                this._isopened = value;
            }
        }

        public string Logo
        {
            get
            {
                return this._logo;
            }
            set
            {
                this._logo = value;
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
    }
}

