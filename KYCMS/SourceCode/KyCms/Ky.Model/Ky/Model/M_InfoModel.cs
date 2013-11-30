namespace Ky.Model
{
    using System;

    public class M_InfoModel
    {
        private bool _IsHtml;
        private string _modelhtml;
        private DateTime addTime;
        private bool isSystem;
        private string modelDesc;
        private int modelId;
        private string modelName;
        private string tableName;
        private string uploadPath;
        private int uploadSize;

        public DateTime AddTime
        {
            get
            {
                return this.addTime;
            }
            set
            {
                this.addTime = value;
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

        public bool IsSystem
        {
            get
            {
                return this.isSystem;
            }
            set
            {
                this.isSystem = value;
            }
        }

        public string ModelDesc
        {
            get
            {
                return this.modelDesc;
            }
            set
            {
                this.modelDesc = value;
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

        public int ModelId
        {
            get
            {
                return this.modelId;
            }
            set
            {
                this.modelId = value;
            }
        }

        public string ModelName
        {
            get
            {
                return this.modelName;
            }
            set
            {
                this.modelName = value;
            }
        }

        public string TableName
        {
            get
            {
                return this.tableName;
            }
            set
            {
                this.tableName = value;
            }
        }

        public string UploadPath
        {
            get
            {
                return this.uploadPath;
            }
            set
            {
                this.uploadPath = value;
            }
        }

        public int UploadSize
        {
            get
            {
                return this.uploadSize;
            }
            set
            {
                this.uploadSize = value;
            }
        }
    }
}

