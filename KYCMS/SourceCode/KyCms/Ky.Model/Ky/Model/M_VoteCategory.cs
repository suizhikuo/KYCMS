namespace Ky.Model
{
    using System;

    public class M_VoteCategory
    {
        private int _categoryId;
        private string _name;

        public int CategoryId
        {
            get
            {
                return this._categoryId;
            }
            set
            {
                this._categoryId = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
    }
}

