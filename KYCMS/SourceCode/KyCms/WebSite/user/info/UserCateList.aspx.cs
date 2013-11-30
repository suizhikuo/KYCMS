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

public partial class User_News_UserCateList : System.Web.UI.Page
{
    B_User UserBll = new B_User();
    B_InfoModel InfoModelBll = new B_InfoModel();
    M_User UserModel = null;

    string keyWord = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserBll.CheckIsLogin();
        UserModel = UserBll.GetUser(UserBll.GetCookie().LogName);

        if(!IsPostBack)
        {
            BindCateType();
            Bind();
        }
    }

    #region 绑定数据
    public void Bind()
    {
        DataTable dt = UserBll.GetUserCateList(UserModel.UserID,0);
        gvInfoList.DataSource = dt;
        gvInfoList.DataBind();
    }
    #endregion

    #region 绑定模块类别
    public void BindCateType()
    {
        DataTable dt = InfoModelBll.GetList();
        ddlModelType.DataTextField = "ModelName";
        ddlModelType.DataValueField = "ModelId";
        ddlModelType.DataSource = dt.DefaultView;
        ddlModelType.DataBind();
        ddlModelType.Items.Insert(0, new ListItem("所有模型类别", "0"));
    }
    #endregion

    #region GridView 的CSS样式设置
    protected void gvInfoList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType==DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='tdbgmouseover'");
            e.Row.Attributes.Add("onmouseout", "this.className='tdbg'");
        }
    }
    #endregion

    protected void gvInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(gvInfoList.DataKeys[e.RowIndex].Value);
        UserBll.DeleteUserCate(id);
        Bind();
    }
    protected void ddlModelType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int modelType = int.Parse(ddlModelType.SelectedValue);
        DataTable dt = UserBll.GetUserCateList(UserModel.UserID, modelType);
        gvInfoList.DataSource = dt.DefaultView;
        gvInfoList.DataBind();
        dt.Dispose();
    }

}
