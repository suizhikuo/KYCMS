namespace Ky.Model
{
    using System;

    public class M_Controller
    {
        private int _controllerId;
        private string _controllerName;
        private string _linkURI;
        private int _orderNum;
        private int _userId;

        public int ControllerId
        {
            get
            {
                return this._controllerId;
            }
            set
            {
                this._controllerId = value;
            }
        }

        public string ControllerName
        {
            get
            {
                return this._controllerName;
            }
            set
            {
                this._controllerName = value;
            }
        }

        public string LinkURI
        {
            get
            {
                return this._linkURI;
            }
            set
            {
                this._linkURI = value;
            }
        }

        public int OrderNum
        {
            get
            {
                return this._orderNum;
            }
            set
            {
                this._orderNum = value;
            }
        }

        public int UserId
        {
            get
            {
                return this._userId;
            }
            set
            {
                this._userId = value;
            }
        }
    }
}

