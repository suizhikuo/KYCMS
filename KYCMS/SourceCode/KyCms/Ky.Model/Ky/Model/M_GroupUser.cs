namespace Ky.Model
{
    using System;

    public class M_GroupUser
    {
        private string groupId;
        private string id;
        private string userId;

        public string GroupId
        {
            get
            {
                return this.groupId;
            }
            set
            {
                this.groupId = value;
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                this.userId = value;
            }
        }
    }
}

