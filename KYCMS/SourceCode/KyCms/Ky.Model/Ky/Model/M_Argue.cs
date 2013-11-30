namespace Ky.Model
{
    using System;

    public class M_Argue
    {
        private string _arguetitle;
        private int _id;
        private string _squareexcuse = string.Empty;
        private string _squaretitle = string.Empty;
        private string _unsquareexcuse = string.Empty;
        private string _unsquaretitle = string.Empty;

        public string ArgueTitle
        {
            get
            {
                return this._arguetitle;
            }
            set
            {
                this._arguetitle = value;
            }
        }

        public int ID
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

        public string SquareExcuse
        {
            get
            {
                return this._squareexcuse;
            }
            set
            {
                this._squareexcuse = value;
            }
        }

        public string SquareTitle
        {
            get
            {
                return this._squaretitle;
            }
            set
            {
                this._squaretitle = value;
            }
        }

        public string UnSquareExcuse
        {
            get
            {
                return this._unsquareexcuse;
            }
            set
            {
                this._unsquareexcuse = value;
            }
        }

        public string UnSquareTitle
        {
            get
            {
                return this._unsquaretitle;
            }
            set
            {
                this._unsquaretitle = value;
            }
        }
    }
}

