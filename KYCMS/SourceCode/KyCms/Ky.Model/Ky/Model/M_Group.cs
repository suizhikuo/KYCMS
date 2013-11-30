namespace Ky.Model
{
    using System;

    public class M_Group
    {
        private string description = string.Empty;
        private string groupName = string.Empty;
        private string id;
        private string type;

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public string GroupId
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

        public string GroupName
        {
            get
            {
                return this.groupName;
            }
            set
            {
                this.groupName = value;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
    }
}

