namespace Ky.Model
{
    using System;
    using System.Xml.Serialization;

    public class M_ConfigModule
    {
        private string loginValidateType;

        [XmlElement]
        public string LoginValidateType
        {
            get
            {
                return this.loginValidateType;
            }
            set
            {
                this.loginValidateType = value;
            }
        }
    }
}

