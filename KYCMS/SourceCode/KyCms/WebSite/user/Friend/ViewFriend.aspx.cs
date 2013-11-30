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
using System.Text;
using Ky.BLL;
using Ky.Model;
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class user_Friend_ViewFriend : System.Web.UI.Page
{
    int UserId = 0;
    B_User user = new B_User();
    B_UserGroupModel UserGroupModelBll = new B_UserGroupModel();
    B_UserGroupModelField GroupField = new B_UserGroupModelField();
    B_User UserBll = new B_User();
    M_User UserModel = new M_User();
    private B_ModelField BModelField = new B_ModelField();

    protected void Page_Load(object sender, EventArgs e)
    {
        string qryId = Request.QueryString["fid"];
        if (!string.IsNullOrEmpty(qryId) && Function.CheckInteger(qryId))
        {
            UserId = int.Parse(qryId);
        }
        UserModel = UserBll.GetUser(UserId);
        if (UserModel != null)
        {
            if (UserModel.Secret == 0)
            {
                InfoTable.Visible = true;
            }
            else
            {
                BindData();
            }
        }
        else
        { Response.Redirect("../welcome.aspx"); }
    }
    void BindData()
    {
        StringBuilder sbUserInfo = new StringBuilder();
        DataTable fileds = GroupField.GetIsUserList(UserModel.TypeId);
        DataRow values = UserBll.GetUserAllInfo(UserId);
        for (int i = 0; i < fileds.Rows.Count; i++)
        {
            sbUserInfo.Append("<tr><td class=\"bqleft\">");
            sbUserInfo.Append(fileds.Rows[i]["Alias"].ToString());
            sbUserInfo.Append("：");
            sbUserInfo.Append("</td><td class=\"bqright\">");
            if (fileds.Rows[i]["Type"].ToString() == "PicType")
            {
                sbUserInfo.Append("<a href=\"ShowPic.aspx?path=");
                sbUserInfo.Append(Function.UrlEncode(values[fileds.Rows[i]["Name"].ToString()].ToString()));
                sbUserInfo.Append("\" target=\"_blank\"><img width=\"60\" height=\"60\" src=\"");
                sbUserInfo.Append(Param.ApplicationRootPath);
                sbUserInfo.Append("/Upload/User/");
                sbUserInfo.Append(values[fileds.Rows[i]["Name"].ToString()]);
                sbUserInfo.Append("\" alt=\"点击查看大图\" border=\"0\" /></a>");
            }
            else
            {
                if (fileds.Rows[i]["Type"].ToString() == "ErLinkageType")
                {
                    sbUserInfo.Append(Function.HtmlEncode(values[fileds.Rows[i]["Name"].ToString()]));
                    sbUserInfo.Append(Function.HtmlEncode(values[BModelField.GetFieldContent(fileds.Rows[i]["Content"].ToString(), 2, 1)]));
                }
                else
                {
                    sbUserInfo.Append(Function.HtmlEncode(values[fileds.Rows[i]["Name"].ToString()]));
                }
            }
            sbUserInfo.Append("</td></tr>");
        }
        LitUserInfo.Text = sbUserInfo.ToString();
    }
}
