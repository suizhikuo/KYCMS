namespace Ky.Model
{
    using System;

    public class M_PowerColumn
    {
        private string _ColumnErrorCodes;
        private int _pcid;
        private string _powercolumnname;

        public string ColumnErrorCodes
        {
            get
            {
                return this._ColumnErrorCodes;
            }
            set
            {
                this._ColumnErrorCodes = value;
            }
        }

        public int PCId
        {
            get
            {
                return this._pcid;
            }
            set
            {
                this._pcid = value;
            }
        }

        public string PowerColumnName
        {
            get
            {
                return this._powercolumnname;
            }
            set
            {
                this._powercolumnname = value;
            }
        }
    }
}

