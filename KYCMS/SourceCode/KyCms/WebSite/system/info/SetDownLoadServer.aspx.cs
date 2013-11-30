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
using Ky.SQLServerDAL;
using Ky.Model;
using Ky.Common;

public partial class System_down_DownLoadServer : System.Web.UI.Page
{
    B_DownLoadServerType TypeBll = new B_DownLoadServerType();
    M_DownLoadServerType TypeModel = new M_DownLoadServerType();
    B_DownLoadServerData DataBll = new B_DownLoadServerData();
    M_DownLoadServerData DataModel = new M_DownLoadServerData();
    int TypeId = 0;
    int ServerId = 0;
    string Type = string.Empty;
    B_Admin AdminBll = new B_Admin();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        if (!string.IsNullOrEmpty(Request.QueryString["TypeId"]))
        {
            try
            {
                TypeId = int.Parse(Request.QueryString["TypeId"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["ServerId"]))
        {
            try
            {
                ServerId = int.Parse(Request.QueryString["ServerId"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["Type"]))
        {
            try
            {
                Type = Request.QueryString["Type"];
            }
            catch { }
        }
        if (TypeId < 0)
        {
            Function.ShowSysMsg(0, "<li>类别参数错误</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
        }
        if (Type == "EditName")
        {
            if (ServerId < 0)
            {
                Function.ShowSysMsg(0, "<li>服务器编号参数错误</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
            }
        }
        if (!IsPostBack)
        {
            TypeBind();
            if (Type == "EditType")
            {
                ddlDownServerType.SelectedValue = "-1";
                ShowTypeInfo(TypeId);
                SaveAs.Text = "确定修改";
            }
            else
            {
                ddlDownServerType.SelectedValue = TypeId.ToString();
            }
            if (Type == "EditName")
            {
                ShowDataInfo();
                SaveAs.Text = "确定修改";
            }
        }
    }
    //绑定类别名称
    public void TypeBind()
    {
        DataTable dt = TypeBll.GetTypeList();
        ddlDownServerType.DataTextField = "TypeName";
        ddlDownServerType.DataValueField = "TypeId";
        ddlDownServerType.DataSource = dt;
        ddlDownServerType.DataBind();
        ddlDownServerType.Items.Insert(0, new ListItem("做为服务器分类", "-1"));
    }
    //设置类别名称
    public void SetType()
    {
        TypeModel.TypeName = txtDownServerName.Text.Trim();
        TypeModel.TypeId = TypeId;
        if (TypeId == 0 || Type == "AddType")
        {
            TypeModel.TypeId = 0;
            TypeBll.AddType(TypeModel);
            Function.ShowSysMsg(1, "<li>服务器类别添加成功</li><li><a href='javascript:window.location.href=\"info/DownLoadServerList.aspx\"'>返回列表页</a></li>");
        }
        if (TypeId != 0 && Type == "EditType")
        {
            TypeBll.UpdateType(TypeModel);
            Function.ShowSysMsg(1, "<li>服务器类别修改成功</li><li><a href='javascript:window.location.href=\"info/DownLoadServerList.aspx\"'>返回列表页</a></li>");
        }
        if(TypeId!=0 && Type=="EditName")
        {
            TypeModel.TypeId = 0;
            TypeBll.AddType(TypeModel);
            DataBll.DeleteData(ServerId);
            Function.ShowSysMsg(1, "<li>修改成功</li><li><a href='javascript:window.location.href=\"info/DownLoadServerList.aspx\"'>返回列表页</a></li>");
        }
    }
    //显示修改类别名称
    public void ShowTypeInfo(int typeId)
    {
        DataTable dt = TypeBll.GetTypeInfo(typeId);
        txtDownServerName.Text = dt.Rows[0]["TypeName"].ToString();
    }
    //设置服务器名称
    public void SetServerName()
    {
        DataModel.TypeId = int.Parse(ddlDownServerType.SelectedValue);
        DataModel.DownLoadServerName = txtDownServerName.Text.Trim();
        DataModel.DownLoadServerDir = txtDownServerDir.Text.Trim();
        DataModel.DownLoadServerDataId = ServerId;
        if (rdBtnIsOpened0.Checked)
            DataModel.IsOpened = false;
        else if (rdBtnIsOpened1.Checked)
            DataModel.IsOpened = true;
        if (rdBtnIsOuter0.Checked)
            DataModel.IsOuter = 0;
        if (rdBtnIsOuter1.Checked)
        {
            DataModel.IsOuter = 1;
            DataModel.UnionId = txtUnionId.Text.Trim();
        }
        if (rdBtnIsOuter2.Checked)
        {
            DataModel.IsOuter = 2;
            DataModel.UnionId = txtUnionId.Text.Trim();
        }
        DataModel.AddTime = DateTime.Now;
        if (ServerId <= 0)
        {
            DataBll.AddData(DataModel);
            Function.ShowSysMsg(1, "<li>服务器添加成功</li><li><a href='javascript:window.location.href=\"info/DownLoadServerList.aspx\"'>返回列表页</a></li>");
        }
        else
        {
            DataBll.UpdateData(DataModel);
            Function.ShowSysMsg(1, "<li>服务器修改成功</li><li><a href='javascript:window.location.href=\"info/DownLoadServerList.aspx\"'>返回列表页</a></li>");
        }
    }
    //显示修改服务器名称
    public void ShowDataInfo()
    {
        DataTable dt = DataBll.GetDataInfo(ServerId);
        ddlDownServerType.SelectedValue = dt.Rows[0]["TypeId"].ToString();
        txtDownServerName.Text = dt.Rows[0]["DownLoadServerName"].ToString();
        txtDownServerDir.Text = dt.Rows[0]["DownLoadServerDir"].ToString();
        switch (dt.Rows[0]["IsOpened"].ToString())
        {
            case "False":
                rdBtnIsOpened0.Checked = true;
                break;
            case "True":
                rdBtnIsOpened1.Checked = true;
                break;
        }
        switch (dt.Rows[0]["IsOuter"].ToString())
        {
            case "0":
                rdBtnIsOuter0.Checked = true;
                break;
            case "1":
                rdBtnIsOuter1.Checked = true;
                IsUnion.Attributes.Add("style","display=''");
                txtUnionId.Text = dt.Rows[0]["UnionId"].ToString();
                break;
            case "2":
                rdBtnIsOuter2.Checked = true;
                IsUnion.Attributes.Add("style", "display=''");
                txtUnionId.Text = dt.Rows[0]["UnionId"].ToString();
                break;
        }
    }
    //保存
    protected void SaveAs_Click(object sender, EventArgs e)
    {
        bool flag = CheckValidate();
        if (flag)
        {
            if (int.Parse(ddlDownServerType.SelectedValue) < 0)
            {
                SetType();
            }
            else
            {
                SetServerName();
            }
        }
    }
    //校验文本框输入
    protected bool CheckValidate()
    {
        if (int.Parse(ddlDownServerType.SelectedValue) < 0)
        {
            if (txtDownServerName.Text.Trim().Length == 0)
            {
                LitMsg.Text = "<script>alert('服务器类别名称必须填写')</script>";
                return false;
            }
        }
        if (int.Parse(ddlDownServerType.SelectedValue) > 0)
        {
            if (txtDownServerName.Text.Trim().Length == 0)
            {
                LitMsg.Text = "<script>alert('服务器名称必须填写')</script>";
                return false;
            }
            if (txtDownServerDir.Text.Trim().Length == 0)
            {
                LitMsg.Text = "<script>alert('服务器路径必须填写')</script>";
                return false;
            }
        }
        return true;
    }
}
