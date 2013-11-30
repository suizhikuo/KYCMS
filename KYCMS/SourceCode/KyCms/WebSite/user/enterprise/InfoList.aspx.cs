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
using Ky.Model;
using Ky.SQLServerDAL;
using Ky.Common;
public partial class user_enterprise_InfoList : System.Web.UI.Page
{
    B_User UserBll = new B_User();
    M_User UserModel = new M_User();
    M_Enterprise EnterpriseModel = null;
    B_Enterprise EnterpriseBll = new B_Enterprise();
    protected void Page_Load(object sender, EventArgs e)
    {
        UserBll.CheckIsLogin();
        UserModel = UserBll.GetUser(UserBll.GetCookie().LogName);
        B_UserSpace.IsActive(UserModel.UserID, 1);
        if (!IsPostBack)
        {
            EnterpriseBind();
        }
    }
    protected void EnterpriseBind()
    {
        int recordcount = 0;
        DataTable dt = EnterpriseBll.GetEnterpriseByUserId(UserModel.UserID,AspNetPager.CurrentPageIndex,AspNetPager.PageSize, ref recordcount);
        repEnterpriseInfoList.DataSource = dt.DefaultView;
        repEnterpriseInfoList.DataBind();
        AspNetPager.RecordCount = recordcount;
        AspNetPager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条信息 每页显示{3}条", AspNetPager.CurrentPageIndex, AspNetPager.PageCount, AspNetPager.RecordCount, AspNetPager.PageSize);
    }

    protected void AspNetPager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager.CurrentPageIndex = e.NewPageIndex;
        EnterpriseBind();
    }

    protected void repEnterpriseInfoList_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        HiddenField hfId = (HiddenField)e.Item.FindControl("hfId");
        EnterpriseBll.DeleteEnterprise(hfId.Value, UserModel.UserID);
        EnterpriseBind();
    }


    protected void btnDeleteChecked_Click(object sender, EventArgs e)
    {
        string idStr = GetSelectIdStr();
        EnterpriseBll.DeleteEnterprise(idStr, UserModel.UserID);
        EnterpriseBind();
    }

    #region 取得批量选择的ID
    private string GetSelectIdStr()
    {
        string idStr = string.Empty;
        foreach (RepeaterItem item in repEnterpriseInfoList.Items)
        {
            CheckBox cb = (CheckBox)item.FindControl("chkBoxDelete");
            HiddenField hf = (HiddenField)item.FindControl("hfId");
            if (cb.Checked)
            {
                idStr += hf.Value + ",";
            }

        }
        if(idStr=="")
        {
            return "";
        }
        if (idStr.EndsWith(","))
        {
            idStr = idStr.Substring(0, idStr.Length - 1);
        }
        return idStr;
    }
    #endregion

}
