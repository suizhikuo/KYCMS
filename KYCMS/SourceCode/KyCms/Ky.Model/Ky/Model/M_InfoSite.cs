namespace Ky.Model
{
    using System;

    public class M_InfoSite
    {
        private string _audioUploadType;
        private int _historyTime;
        private string _imgUploadType;
        private int _infoCreateNum;
        private bool _isOpenViewerDig;
        private string _otherUploadType;
        private int _searchResultPageSize;
        private int _searchTime;
        private string _softUploadType;
        private int _specialInfoCreateNum;
        private string _videoUploadType;

        public string AudioUploadType
        {
            get
            {
                return this._audioUploadType;
            }
            set
            {
                this._audioUploadType = value;
            }
        }

        public int HistoryTime
        {
            get
            {
                return this._historyTime;
            }
            set
            {
                this._historyTime = value;
            }
        }

        public string ImgUploadType
        {
            get
            {
                return this._imgUploadType;
            }
            set
            {
                this._imgUploadType = value;
            }
        }

        public int InfoCreateNum
        {
            get
            {
                return this._infoCreateNum;
            }
            set
            {
                this._infoCreateNum = value;
            }
        }

        public bool IsOpenViewerDig
        {
            get
            {
                return this._isOpenViewerDig;
            }
            set
            {
                this._isOpenViewerDig = value;
            }
        }

        public string OtherUploadType
        {
            get
            {
                return this._otherUploadType;
            }
            set
            {
                this._otherUploadType = value;
            }
        }

        public int SearchResultPageSize
        {
            get
            {
                return this._searchResultPageSize;
            }
            set
            {
                this._searchResultPageSize = value;
            }
        }

        public int SearchTime
        {
            get
            {
                return this._searchTime;
            }
            set
            {
                this._searchTime = value;
            }
        }

        public string SoftUploadType
        {
            get
            {
                return this._softUploadType;
            }
            set
            {
                this._softUploadType = value;
            }
        }

        public int SpecialInfoCreateNum
        {
            get
            {
                return this._specialInfoCreateNum;
            }
            set
            {
                this._specialInfoCreateNum = value;
            }
        }

        public string VideoUploadType
        {
            get
            {
                return this._videoUploadType;
            }
            set
            {
                this._videoUploadType = value;
            }
        }
    }
}

