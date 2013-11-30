namespace Ky.Model
{
    using System;

    public class M_DownLoadServerType
    {
        private int _typeid;
        private string _typename;

        public int TypeId
        {
            get
            {
                return this._typeid;
            }
            set
            {
                this._typeid = value;
            }
        }

        public string TypeName
        {
            get
            {
                return this._typename;
            }
            set
            {
                this._typename = value;
            }
        }
    }
}

