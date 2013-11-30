namespace Ky.Model
{
    using System;

    public class M_VoteSubject
    {
        private int _categoryId;
        private DateTime _enddate = DateTime.Now.AddDays(7.0);
        private bool _requireLogin = false;
        private DateTime _startdate = DateTime.Now;
        private string _subject;
        private int _subjectId;

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

        public DateTime EndDate
        {
            get
            {
                return this._enddate;
            }
            set
            {
                this._enddate = value;
            }
        }

        public bool RequireLogin
        {
            get
            {
                return this._requireLogin;
            }
            set
            {
                this._requireLogin = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this._startdate;
            }
            set
            {
                this._startdate = value;
            }
        }

        public string Subject
        {
            get
            {
                return this._subject;
            }
            set
            {
                this._subject = value;
            }
        }

        public int SubjectId
        {
            get
            {
                return this._subjectId;
            }
            set
            {
                this._subjectId = value;
            }
        }
    }
}

