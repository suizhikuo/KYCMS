namespace Ky.BLL
{
    using Ky.Common;
    using Ky.DALFactory;
    using Ky.Model;
    using System;
    using System.Data;
    using System.Web;

    public class B_Admin
    {
        private IAdmin dal = DataAccess.CreateAdmin();

        public bool Add(M_Admin model)
        {
            return this.dal.Add(model);
        }

        public void CheckIsLogin()
        {
            if (HttpContext.Current.Request.Cookies["AdminState"] == null)
            {
                HttpContext.Current.Response.Redirect("~/System/Login.aspx");
            }
            else
            {
                string loginName = Ky.Common.Function.UrlDecode(HttpContext.Current.Request.Cookies["AdminState"]["LoginName"]);
                string password = Ky.Common.Function.DESDecrypt(HttpContext.Current.Request.Cookies["AdminState"]["Password"]);
                if (this.GetModel(loginName, password) == null)
                {
                    HttpContext.Current.Response.Redirect("~/System/Login.aspx");
                }
            }
        }

        public void CheckMulitLogin()
        {
            this.CheckIsLogin();
            string str = string.Empty;
            if (HttpContext.Current.Request.Cookies["randNum"] != null)
            {
                str = Ky.Common.Function.UrlDecode(HttpContext.Current.Request.Cookies["randNum"].Value);
            }
            int userId = int.Parse(HttpContext.Current.Request.Cookies["AdminState"]["UserId"]);
            M_Admin model = new B_Admin().GetModel(userId);
            if (!(model.AllowMultiLogin || !(str != model.RandNumber)))
            {
                HttpContext.Current.Response.Write("<font style='color:red;font-size:12px'>该账号设置为不允许多人同时使用，已经有其他人用该账号登陆 <a href='" + Param.ApplicationRootPath + "/System/Login.aspx' style='color:blue'>重新登陆</a></font>");
                HttpContext.Current.Response.End();
            }
        }

        public void ClearCookie()
        {
            HttpContext.Current.Response.Cookies["AdminState"].Expires = DateTime.Now.AddDays(-1.0);
        }

        public void Delete(int id)
        {
            this.dal.Delete(id);
        }

        public DataTable GetAdminByGroupID(int goupID)
        {
            return this.dal.GetAdminByGroupID(goupID);
        }

        public DataTable GetAdminList()
        {
            return this.dal.GetAdminList();
        }

        public string GetGroupAdminCount(int goupID)
        {
            return this.dal.GetGroupAdminCount(goupID);
        }

        public M_LoginAdmin GetLoginModel()
        {
            this.CheckMulitLogin();
            M_LoginAdmin admin = new M_LoginAdmin();
            admin.UserId = int.Parse(HttpContext.Current.Request.Cookies["AdminState"]["UserId"]);
            admin.LoginName = Ky.Common.Function.UrlDecode(HttpContext.Current.Request.Cookies["AdminState"]["LoginName"]);
            admin.Password = Ky.Common.Function.DESDecrypt(HttpContext.Current.Request.Cookies["AdminState"]["Password"]);
            admin.AdminName = Ky.Common.Function.UrlDecode(HttpContext.Current.Request.Cookies["AdminState"]["AdminName"]);
            return admin;
        }

        public M_Admin GetModel(int userId)
        {
            return this.dal.GetModel(userId);
        }

        public M_Admin GetModel(string loginName, string password)
        {
            return this.dal.GetModel(loginName, password);
        }

        public void SetLoginState(M_Admin model)
        {
            bool allowMultiLogin = model.AllowMultiLogin;
            M_Site siteModel = new B_SiteInfo().GetSiteModel();
            string rndNum = Ky.Common.Function.GetRndNum(16);
            HttpContext.Current.Response.Cookies["AdminState"]["UserId"] = model.UserId.ToString();
            HttpContext.Current.Response.Cookies["AdminState"]["LoginName"] = Ky.Common.Function.UrlEncode(model.LoginName);
            HttpContext.Current.Response.Cookies["AdminState"]["AdminName"] = Ky.Common.Function.UrlEncode(model.UserName);
            HttpContext.Current.Response.Cookies["AdminState"]["Password"] = Ky.Common.Function.DESEncrypt(model.Password);
            if (HttpContext.Current.Request.UserHostAddress != null)
            {
                model.LastLoginIP = HttpContext.Current.Request.UserHostAddress;
            }
            else
            {
                model.LastLoginIP = "";
            }
            model.LastLoginTime = DateTime.Now;
            model.RandNumber = rndNum;
            this.UpdateState(model);
            HttpContext.Current.Response.Cookies["randNum"].Value = rndNum;
            B_Log.Add(LogType.Login, "登陆后台");
            HttpContext.Current.Response.Redirect(Param.ApplicationRootPath + "/System/Index.aspx");
        }

        public void UpdateInfo(M_Admin model)
        {
            this.dal.UpdateInfo(model);
        }

        public void UpdateState(M_Admin model)
        {
            this.dal.UpdateState(model);
        }
    }
}

