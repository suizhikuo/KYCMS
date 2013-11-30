using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Ky.BLL;
using Ky.Common;
using Ky.Model;

public partial class user_SetRecommand : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InfoTable.Visible = false;
        B_User user = new B_User();
        M_User userModel = user.GetUser(user.GetCookie().UserID);

        B_SiteInfo site = new B_SiteInfo();
        M_Site siteModel = site.GetSiteModel();
        if (userModel != null)
        {
            if (siteModel.IsOpenInvite)
            {
                B_UserGroup groupBll = new B_UserGroup();
                string integral = groupBll.Power_UserGroup("Invite", 0, groupBll.GetModel(userModel.GroupID).GroupPower);
                lbIntegral.Text = integral;
                if (siteModel.Domain.EndsWith("/"))
                {
                    txtUrl.Text = siteModel.Domain + "user/Reg.aspx?TypeId=" + userModel.TypeId + "&recmd_uid=" + userModel.UserID;
                }
                else
                {
                    txtUrl.Text = siteModel.Domain + "/user/Reg.aspx?TypeId=" + userModel.TypeId + "&recmd_uid=" + userModel.UserID;
                }
            }
            else
            {
                InfoTable.Visible = true;
                MainTable.Visible = false;
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}
