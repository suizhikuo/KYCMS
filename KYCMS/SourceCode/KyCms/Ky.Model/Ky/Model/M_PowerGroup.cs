namespace Ky.Model
{
    using System;

    public class M_PowerGroup
    {
        private DateTime _adddate;
        private string _powerauditing;
        private string _powerchannel;
        private string _powercolumn;
        private string _PowerContent;
        private int _powerid;
        private string _powermodel;
        private string _powername;
        private int _TypeId;

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

        public string PowerAuditing
        {
            get
            {
                return this._powerauditing;
            }
            set
            {
                this._powerauditing = value;
            }
        }

        public string PowerChannel
        {
            get
            {
                return this._powerchannel;
            }
            set
            {
                this._powerchannel = value;
            }
        }

        public string PowerColumn
        {
            get
            {
                return this._powercolumn;
            }
            set
            {
                this._powercolumn = value;
            }
        }

        public string PowerContent
        {
            get
            {
                return this._PowerContent;
            }
            set
            {
                this._PowerContent = value;
            }
        }

        public int PowerId
        {
            get
            {
                return this._powerid;
            }
            set
            {
                this._powerid = value;
            }
        }

        public string PowerModel
        {
            get
            {
                return this._powermodel;
            }
            set
            {
                this._powermodel = value;
            }
        }

        public string PowerName
        {
            get
            {
                return this._powername;
            }
            set
            {
                this._powername = value;
            }
        }

        public int TypeId
        {
            get
            {
                return this._TypeId;
            }
            set
            {
                this._TypeId = value;
            }
        }
    }
}

