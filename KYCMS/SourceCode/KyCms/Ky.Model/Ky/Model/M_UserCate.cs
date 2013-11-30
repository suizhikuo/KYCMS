namespace Ky.Model
{
    using System;

    public class M_UserCate
    {
        private string _catename;
        private int _catetype;
        private string _discription;
        private int _usercateid;
        private int _userid;

        public string CateName
        {
            get
            {
                return this._catename;
            }
            set
            {
                this._catename = value;
            }
        }

        public int CateType
        {
            get
            {
                return this._catetype;
            }
            set
            {
                this._catetype = value;
            }
        }

        public string Discription
        {
            get
            {
                return this._discription;
            }
            set
            {
                this._discription = value;
            }
        }

        public int UserCateId
        {
            get
            {
                return this._usercateid;
            }
            set
            {
                this._usercateid = value;
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
    }
}

