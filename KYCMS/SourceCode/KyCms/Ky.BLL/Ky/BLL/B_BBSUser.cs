namespace Ky.BLL
{
    using System;
    using System.Configuration;
    using System.Web;

    public class B_BBSUser
    {
        private string _bbsServiceUrl = string.Empty;
        private string _cookieDomain = string.Empty;
        private bool _isOpen = false;
        private string _servicePwd = string.Empty;

        public B_BBSUser()
        {
            this._bbsServiceUrl = ConfigurationManager.AppSettings["BBS_ServiceUrl"].Trim();
            this._cookieDomain = ConfigurationManager.AppSettings["BBS_CookieDomain"].Trim();
            this._servicePwd = ConfigurationManager.AppSettings["BBS_ServicePwd"].Trim();
            if (this._bbsServiceUrl.Length != 0)
            {
                this._isOpen = true;
            }
        }

        public bool BBS_User_CheckIsExists(string logName)
        {
            if (this._isOpen)
            {
                WebServiceHelper helper = new WebServiceHelper(this._bbsServiceUrl, "");
                return bool.Parse(helper.InvokeWebService("Exists", new object[] { logName }).ToString());
            }
            return false;
        }

        public string BBS_User_Reg(string logName, string pwd, string email, bool isLogin)
        {
            if (this._isOpen)
            {
                WebServiceHelper helper = new WebServiceHelper(this._bbsServiceUrl, "");
                return helper.InvokeWebService("CreateUser", new object[] { logName, pwd, email, isLogin.ToString(), this._servicePwd }).ToString();
            }
            return string.Empty;
        }

        public void ClearUserCookie()
        {
            if (this._isOpen)
            {
                HttpContext.Current.Response.Cookies["dnt"].Value = string.Empty;
                HttpContext.Current.Response.Cookies["dnt"].Expires = DateTime.Now.AddYears(-1);
                HttpContext.Current.Response.Cookies["dnt"].Domain = this._cookieDomain;
                HttpContext.Current.Response.Cookies["dnt"].Path = "/";
            }
        }

        public void Delete(string logName)
        {
            if (this._isOpen)
            {
                int userId = this.GetUserId(logName);
                new WebServiceHelper(this._bbsServiceUrl, "").InvokeWebService("Delete", new object[] { userId, this._servicePwd });
            }
        }

        public string GetUserCookie(string logName, string pwd)
        {
            if (this._isOpen)
            {
                WebServiceHelper helper = new WebServiceHelper(this._bbsServiceUrl, "");
                return helper.InvokeWebService("CheckLogin", new object[] { logName, pwd, this._servicePwd }).ToString();
            }
            return string.Empty;
        }

        private int GetUserId(string logName)
        {
            if (this._isOpen)
            {
                WebServiceHelper helper = new WebServiceHelper(this._bbsServiceUrl, "");
                return int.Parse(helper.InvokeWebService("GetUserID", new object[] { logName }).ToString());
            }
            return -1;
        }

        public void LoginOut(string logName)
        {
            if (this._isOpen)
            {
                int userId = this.GetUserId(logName);
                new WebServiceHelper(this._bbsServiceUrl, "").InvokeWebService("LoginOut", new object[] { userId, this._servicePwd });
            }
        }

        public void UpdatePwd(string logName, string pwd)
        {
            if (this._isOpen)
            {
                int userId = this.GetUserId(logName);
                new WebServiceHelper(this._bbsServiceUrl, "").InvokeWebService("UpdateUserPassword", new object[] { userId.ToString(), pwd, this._servicePwd });
            }
        }

        public void WriteUserCookie(string cookieValue)
        {
            if (this._isOpen)
            {
                HttpContext.Current.Response.Cookies["dnt"].Value = cookieValue;
                HttpContext.Current.Response.Cookies["dnt"].Domain = this._cookieDomain;
                HttpContext.Current.Response.Cookies["dnt"].Path = "/";
            }
        }
    }
}

