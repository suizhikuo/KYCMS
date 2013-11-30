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
using Ky.SQLServerDAL;
using Ky.Model;
using Ky.BLL;

public partial class System_down_DownLoadServerList : System.Web.UI.Page
{
    B_DownLoadServerType TypeBll = new B_DownLoadServerType();
    M_DownLoadServerType TypeModel = new M_DownLoadServerType();
    B_DownLoadServerData DataBll = new B_DownLoadServerData();
    M_DownLoadServerData DataModel = new M_DownLoadServerData();
    B_Admin AdminBll = new B_Admin();
    public int TypeId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        if (!IsPostBack)
        {
            TypeBind();
            ServerDataBind();
        }
    }
    //服务器类别绑定
    public void TypeBind()
    {
        DataTable dt = TypeBll.GetTypeList();
        repServerType.DataSource = dt;
        repServerType.DataBind();
    }
    //服务器名称绑定
    public void ServerDataBind()
    {
        for (int i = 0; i < repServerType.Items.Count; i++)
        {
            Label lbTypeId = (Label)repServerType.Items[i].FindControl("lbID");
            TypeId = int.Parse(lbTypeId.Text.Trim());
            Repeater repServerName = (Repeater)repServerType.Items[i].FindControl("repServerName");
            repServerName.DataSource = DataBll.GetDataList(TypeId);
            repServerName.DataBind();
        }
    }
    public string GetBtnText(object status)
    {
        string returnStr = "";
        if (status != null)
        {
            bool flag = Convert.ToBoolean(status);
            if (flag)
                returnStr = "禁用";
            else
                returnStr = "启用";
        }
        return returnStr;
    }
    public string GetIsOpened(object isOpened)
    {
        string returnStr = "";
        if (isOpened != null)
        {
            bool flag = Convert.ToBoolean(isOpened);
            if (flag)
                returnStr = "启用";
            else
                returnStr = "禁用";
        }
        return returnStr;
    }
    //删除类别
    protected void repServerType_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label lbTypeId = (Label)e.Item.FindControl("lbID");
        if (e.CommandName == "deleteType")
            TypeBll.DeleteType(int.Parse(lbTypeId.Text.Trim()));
        TypeBind();
        ServerDataBind();
    }
    //设置类别删除按钮的状态
    protected void repServerType_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lbTypeId = (Label)e.Item.FindControl("lbID");
            bool flag = TypeBll.IsAllowDeleteType(int.Parse(lbTypeId.Text.Trim()));
            if (flag)
            {
                LinkButton btnDeleteType = (LinkButton)e.Item.FindControl("btnDeleteType");
                btnDeleteType.Enabled = false;
            }
        }
    }
    //服务器相关设置
    protected void repServerName_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label lbDownServerId = (Label)e.Item.FindControl("lbDownServerId");
        int DownServerId = int.Parse(lbDownServerId.Text.Trim());
        if (e.CommandName == "state")
        {
            LinkButton btn = (LinkButton)e.CommandSource;
            if (btn.Text.Trim() == "禁用")
                DataBll.SetIsOpened(DownServerId, false);
            else
                DataBll.SetIsOpened(DownServerId, true);
            TypeBind();
            ServerDataBind();
        }
        if (e.CommandName == "deleteData")
        {
            DataBll.DeleteData(DownServerId);
            TypeBind();
            ServerDataBind();
        }
    }



}
