
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
using Ky.Model;
using Ky.SQLServerDAL;
using Ky.BLL;
using Ky.Common;
using Ky.BLL.CommonModel;
public partial class user_Enterprise_AddInfo : System.Web.UI.Page
{
    M_User UserModel = null;
    B_User UserBll = new B_User();
    B_Enterprise EnterpriseBll = new B_Enterprise();
    M_Enterprise EnterpriseModel = new M_Enterprise();
    int Id = 0;
    B_Dictionary DictionaryBll = new B_Dictionary();
    protected void Page_Load(object sender, EventArgs e)
    {
        UserModel = UserBll.GetCookie();

        if(!string.IsNullOrEmpty(Request.QueryString["Id"]))
        {
            Id = Convert.ToInt32(Request.QueryString["Id"]);
        }
        if(!IsPostBack)
        {
             ddlTypeIdBind();

             if (Id != 0)
             {
                 btnSaveAs.Text = " 修 改 ";
                 Show();
             }
        }
       
    }

    protected void ddlTypeIdBind()
    {
        ddlTypeId.DataSource = DictionaryBll.GetDictionary(74);
        ddlTypeId.DataTextField = "DicName";
       ddlTypeId.DataValueField = "ID";
        ddlTypeId.DataBind();
    }

    protected void btnSaveAs_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text.Trim().Length == 0)
        {
            Function.ShowMsg(0, "<li>标题必须填写</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        }

        if (txtContent.Text.Length == 0)
        {
            Function.ShowMsg(0, "<li>内容必须填写</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        }
        EnterpriseModel.Id = Id;
        EnterpriseModel.Title = txtTitle.Text.Trim();
        EnterpriseModel.Conetent = txtContent.Text;
        EnterpriseModel.AddTime = DateTime.Now.ToString();
        EnterpriseModel.TypeId = Convert.ToInt32(ddlTypeId.SelectedValue);
        EnterpriseModel.UserId = UserModel.UserID;
        if(EnterpriseModel.Id<=0)
        {
            EnterpriseBll.AddEnterPrise(EnterpriseModel);
            Function.ShowMsg(1, "<li>添加成功</li><li><a href='javascript:window.location.href=\"enterprise/InfoList.aspx\"'>返回信息列表</a></li>");
        }
        else
        {
            EnterpriseBll.UpdateEnterPrise(EnterpriseModel);
            Function.ShowMsg(1, "<li>修改成功</li><li><a href='javascript:window.location.href=\"enterprise/InfoList.aspx\"';'>返回上一级</a></li>");
        }
    }

    public void Show()
    {
        EnterpriseModel = EnterpriseBll.GetEnterpriseById(Id, UserModel.UserID);
        txtTitle.Text = EnterpriseModel.Title;
        ddlTypeId.SelectedValue = EnterpriseModel.TypeId.ToString();
        txtContent.Text = EnterpriseModel.Conetent;
    }
}
