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
using Ky.BLL.CommonModel;
using Ky.Model;
using Ky.Common;

public partial class System_user_UserCate : System.Web.UI.Page
{
    M_UserCate userCateModel = new M_UserCate();
    B_User userBll = new B_User();
    int UCId = 0;
    M_User userInfo;

    B_InfoModel InfoModelBll = new B_InfoModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        userBll.CheckIsLogin();
        userInfo = userBll.GetCookie();
        M_Site siteModel = null;
        B_SiteInfo siteBll = new B_SiteInfo();
        siteModel = siteBll.GetSiteModel();
        int count = userBll.GetUserCateCount(userInfo.UserID);
        if (!string.IsNullOrEmpty(Request["UCId"]))
        {
            try
            {
                UCId = int.Parse(Request["UCId"]);
            }
            catch { }
        }
        if (count >= siteModel.UserClassCount && siteModel.UserClassCount != 0 && UCId <= 0)
        {
            Function.ShowMsg(0, "<li>您创建的专栏数已达到上限，请联系系统管理员</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
            return;
        }
        if (!IsPostBack)
        {

            if (UCId > 0)
            {
                ShowInfo();
            }
            lbUserName.Text = userInfo.LogName;
            ltMsg.Text = "";

            DataTable dt = InfoModelBll.GetList();
            ddlCateType.DataTextField = "ModelName";
            ddlCateType.DataValueField = "ModelId";
            ddlCateType.DataSource = dt.DefaultView;
            ddlCateType.DataBind();
            dt.Dispose();
        }
    }
    //修改
    protected void ShowInfo()
    {
        M_UserCate model = userBll.GetUserCateById(UCId);
        txtCateName.Text = model.CateName;
        ddlCateType.SelectedValue = model.CateType.ToString();
        txtDiscription.Text = model.Discription;
        lbUserName.Text = userInfo.LogName;
    }
    protected void btnSaveCate_Click(object sender, EventArgs e)
    {
        bool checkValidate = CheckValidate();
        if (checkValidate)
        {
            userCateModel.CateName = txtCateName.Text.Trim();
            userCateModel.UserCateId = UCId;
            userCateModel.UserId = userInfo.UserID;
            userCateModel.CateType = int.Parse(ddlCateType.SelectedValue.Trim());
            userCateModel.Discription = txtDiscription.Text.Trim();
            if (UCId > 0)
            {
                userBll.UpdateUserCate(userCateModel);
                Function.ShowMsg(1, "<li>专栏修改成功</li><li><a href='info/UserCateList.aspx'>返回专栏列表</a></li>");
            }
            else
            {
                userBll.AddUserCate(userCateModel);
                Function.ShowMsg(1, "<li>专栏创建成功</li><li><a href='info/SetUserCate.aspx'>继续创建</a></li><li><a href='info/UserCateList.aspx'>返回专栏列表</a></li>");
            }
            return;
        }
    }

    #region  验证文本框输入是否合法
    public bool CheckValidate()
    {
        if (txtCateName.Text.Trim().Length == 0)
            Function.ShowMsg(0, "<li>专栏名称必须填写</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
        B_KyCommon kycommonBll = new B_KyCommon();
        if (UCId <= 0)
        {
            if (kycommonBll.CheckHas(txtCateName.Text.Trim(), "CateName", "KyUserCate"))
            {
                Function.ShowMsg(0, "<li>对不起,该专栏名称已经被占用</li><li><a href='info/SetUserCate.aspx'>重新创建</a></li><li><a href='info/UserCateList.aspx'>返回专栏列表</a></li>");
            }
        }
        return true;
    }
    #endregion
}
