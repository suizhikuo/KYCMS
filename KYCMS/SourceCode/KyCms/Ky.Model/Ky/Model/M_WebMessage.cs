namespace Ky.Model
{
    using System;

    public class M_WebMessage
    {
        private DateTime _adddate;
        private int _AllUser;
        private string _content;
        private int _isread;
        private int _IsSend;
        private DateTime _OverdueDate;
        private int _ReceiverDel;
        private int _receiverid;
        private string _receivername;
        private int _SendDel;
        private int _sendid;
        private string _sendname;
        private string _title;
        private int _TypeId;
        private int _UserGroupId;
        private int _wmid;

        public int GetDelType(int WMId, int UserId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

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

        public int AllUser
        {
            get
            {
                return this._AllUser;
            }
            set
            {
                this._AllUser = value;
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

        public int IsRead
        {
            get
            {
                return this._isread;
            }
            set
            {
                this._isread = value;
            }
        }

        public int IsSend
        {
            get
            {
                return this._IsSend;
            }
            set
            {
                this._IsSend = value;
            }
        }

        public DateTime OverdueDate
        {
            get
            {
                return this._OverdueDate;
            }
            set
            {
                this._OverdueDate = value;
            }
        }

        public int ReceiverDel
        {
            get
            {
                return this._ReceiverDel;
            }
            set
            {
                this._ReceiverDel = value;
            }
        }

        public int ReceiverId
        {
            get
            {
                return this._receiverid;
            }
            set
            {
                this._receiverid = value;
            }
        }

        public string ReceiverName
        {
            get
            {
                return this._receivername;
            }
            set
            {
                this._receivername = value;
            }
        }

        public int SendDel
        {
            get
            {
                return this._SendDel;
            }
            set
            {
                this._SendDel = value;
            }
        }

        public int SendId
        {
            get
            {
                return this._sendid;
            }
            set
            {
                this._sendid = value;
            }
        }

        public string SendName
        {
            get
            {
                return this._sendname;
            }
            set
            {
                this._sendname = value;
            }
        }

        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
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

        public int WMId
        {
            get
            {
                return this._wmid;
            }
            set
            {
                this._wmid = value;
            }
        }
    }
}

