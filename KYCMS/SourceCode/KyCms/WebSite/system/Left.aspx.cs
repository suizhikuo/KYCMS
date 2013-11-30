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
using System.Text;
using Ky.Model;
using Ky.BLL.CommonModel;

public partial class System_Left : System.Web.UI.Page
{
    B_Admin AdminBll = new B_Admin();
    B_Controller ControllerBll = new B_Controller();
    B_InfoModel InfoModel = new B_InfoModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckIsLogin();
        if (Request.QueryString["Id"] == "3")
        {
            Bind();
        }
        if (Request.QueryString["Id"] == "1")
        {
            SetMyController();
        }
        litDv.Visible = true;
        litDv.Text = "程序开发：<a href=\"http://www.kycms.com\" target=\"_blank\">酷源科技</a>";

        B_UserGroupModel usergroupmodelbll=new B_UserGroupModel();
        RepUserGroupModel.DataSource = usergroupmodelbll.GetAll();
        RepUserGroupModel.DataBind();
        AjaxPro.Utility.RegisterTypeForAjax(typeof(System_Left));
    }
    [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
    public string CreateChannel(string chId)
    {
        B_SiteInfo SiteBll = new B_SiteInfo();
        B_Channel ChannelBll = new B_Channel();
        M_Site SiteModel = SiteBll.GetSiteModel();
        if (!SiteModel.IsStaticType)
        {
            return "fail$全站参数设置没有开启生成静态页面功能";
        }
        string chIdStr = ""; 
        M_Channel channelModel = ChannelBll.GetChannel(int.Parse(chId));
        if (channelModel != null && channelModel.IsStaticType)
        {
            chIdStr = chIdStr + chId + ",";
        }

        if (chIdStr == string.Empty)
        {
            return "fail$所选频道没有开启生成静态页面功能";
        }
        chIdStr = chIdStr.Substring(0, (chIdStr.Length - 1));
        
        Session["createchid"] = chIdStr;
        return "succ$" + chIdStr;
    }
    [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
    public string CreateColumn(string colId)
    {
        B_SiteInfo SiteBll = new B_SiteInfo();
        B_Channel ChannelBll = new B_Channel();
        M_Site SiteModel = SiteBll.GetSiteModel();
        if (!SiteModel.IsStaticType)
        {
            return "fail$全站参数设置没有开启生成静态页面功能";
        }
        B_Column columnBll = new B_Column();
        M_Column columnModel = columnBll.GetColumn(int.Parse(colId));
        M_Channel channelModel = ChannelBll.GetChannel(columnModel.ChId);
        if (channelModel == null || !channelModel.IsStaticType)
        {
            return "fail$所属频道没有开启生成静态页面功能";
        }
        Session["createcolid"] = colId;
        return "succ$" + colId;
    }
    [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
    public string CreateInfoByColId(string colId)
    {
        B_SiteInfo SiteBll = new B_SiteInfo();
        B_Channel ChannelBll = new B_Channel();
        M_Site SiteModel = SiteBll.GetSiteModel();
        if (!SiteModel.IsStaticType)
        {
            return "fail$全站参数设置没有开启生成静态页面功能";
        }
        B_Column columnBll = new B_Column();
        M_Column columnModel = columnBll.GetColumn(int.Parse(colId));
        M_Channel channelModel = ChannelBll.GetChannel(columnModel.ChId);
        if (channelModel == null || !channelModel.IsStaticType)
        {
            return "fail$所属频道没有开启生成静态页面功能";
        }
        Session["newscolumnid"] = colId;
        return "succ$" + channelModel.ModelType;
        
    }
    [AjaxPro.AjaxMethod]
    public string GetInfoUrl(string chId,string colId)
    {
        B_Channel channelBll = new B_Channel();
        M_Channel channelModel = channelBll.GetChannel(int.Parse(chId));
        string pageUrl = "#";
        switch (channelModel.ModelType)
        {
            default:
                pageUrl = "info/AddInfo.aspx";
                break ;
            case 1:
                pageUrl = "info/SetArticle.aspx";
                break;
            case 2:
                pageUrl = "info/SetImage.aspx";
                break;
            case 3:
                pageUrl = "info/SetDownLoad.aspx";
                break;
        }
        if (colId == "0")
        {
            return pageUrl + "?ChId=" + chId;
        }
        else
        {
            return pageUrl + "?ChId=" + chId+"&ColId="+colId;
        }
    }
   
    private void SetMyController()
    {

        M_LoginAdmin model = AdminBll.GetLoginModel();
        int userId = model.UserId;
        DataTable dt = ControllerBll.GetList(userId);
        StringBuilder sb = new StringBuilder();
        foreach (DataRow dr in dt.Rows)
        {
            sb.Append("<tr>\r\n<td class=\"leftdh\"><a href='");
            sb.Append(dr["LinkURI"].ToString());
            sb.Append("' target='ContentIframe'>");
            sb.Append(dr["ControllerName"]);
            sb.Append("</a>\r\n ");
            sb.Append("</td>\r\n</tr>");
        }
        ltController.Text = sb.ToString();
    }

    
    private void Bind()
    {
        int ChType = 1;
        B_Dictionary dictionBll = new B_Dictionary();
        DataTable chTypeDt = dictionBll.GetDictionary(ChType);
        
        for (int i = 0; i < chTypeDt.Rows.Count; i++)
        {
            TreeNode chTypeNode = new TreeNode();
            chTypeNode.ToolTip = "分类右键操作$" + chTypeDt.Rows[i]["id"].ToString();
            chTypeNode.Text = chTypeDt.Rows[i]["DicName"].ToString();
            chTypeNode.ImageUrl = "~/system/images/category.gif";
            chTypeNode.NavigateUrl = "~/system/info/ChannelList.aspx?ChType=" + chTypeDt.Rows[i]["id"].ToString();
            chTypeNode.Target = "ContentIframe";
            tvNav.Nodes.Add(chTypeNode);
        }
        TreeNode chTypeOtherNode = new TreeNode();
        chTypeOtherNode.ToolTip = "分类右键操作$0";
        chTypeOtherNode.Text = "其他";
        chTypeOtherNode.ImageUrl = "~/system/images/category.gif";
        chTypeOtherNode.NavigateUrl = "~/system/info/ChannelList.aspx?ChType=0";
        chTypeOtherNode.Target = "ContentIframe";
        tvNav.Nodes.Add(chTypeOtherNode);

        B_Channel channelBll = new B_Channel();
        B_Column columnBll = new B_Column();
        DataView channelDv = channelBll.GetList(false);
        
        for (int i = 0; i < tvNav.Nodes.Count-1; i++)
        {
            int chType = int.Parse(chTypeDt.Rows[i]["id"].ToString());
            
            DataTable chDt = channelDv.ToTable();
            
            DataView chTypeDv = new DataView(chDt);
            chTypeDv.RowFilter=string.Format("[chtype]={0}",chType);
            for (int j = 0; j < chTypeDv.Count; j++)
            {
                TreeNode channelNode = new TreeNode();
                channelNode.ToolTip = "频道右键操作$" + chTypeDv[j]["ChId"].ToString() + "$" + chTypeDv[j]["ChType"].ToString();
                channelNode.Text = chTypeDv[j]["ChName"].ToString();
                channelNode.ImageUrl = "~/system/images/folder.gif";
                channelNode.NavigateUrl = "~/system/info/ColumnList.aspx?ChId=" + chTypeDv[j]["ChId"];
                channelNode.Target = "ContentIframe";
                tvNav.Nodes[i].ChildNodes.Add(channelNode);
            }
            
            for (int j = 0; j < chTypeDv.Count; j++)
            {
                DataView dv = columnBll.GetColumnListByChannelId((int)chTypeDv[j]["ChId"]);
                DataTable dt = dv.ToTable();
                dv.Dispose();
                BindColumn(0, tvNav.Nodes[i].ChildNodes[j], dt, (int)chTypeDv[j]["ModelType"], (int)chTypeDv[j]["ChId"]);
            }
            chDt.Dispose();
            chTypeDv.Dispose();
        }
        DataTable chDt2 = channelDv.ToTable();
        DataView chTypeDv2 = new DataView(chDt2);
        chTypeDv2.RowFilter = "[chtype]=0 or [chtype] is null";
        for (int j = 0; j < chTypeDv2.Count; j++)
        {
            TreeNode channelNode = new TreeNode();
            channelNode.ToolTip = "频道右键操作$" + chTypeDv2[j]["ChId"].ToString() + "$" + chTypeDv2[j]["ChType"].ToString();
            channelNode.Text = chTypeDv2[j]["ChName"].ToString();
            channelNode.ImageUrl = "~/system/images/folder.gif";
            channelNode.NavigateUrl = "~/system/info/ColumnList.aspx?ChId=" + chTypeDv2[j]["ChId"];
            channelNode.Target = "ContentIframe";
            tvNav.Nodes[tvNav.Nodes.Count - 1].ChildNodes.Add(channelNode);
        }
        for (int j = 0; j < chTypeDv2.Count; j++)
        {
            DataView dv = columnBll.GetColumnListByChannelId((int)chTypeDv2[j]["ChId"]);
            DataTable dt = dv.ToTable();
            dv.Dispose();
            BindColumn(0, tvNav.Nodes[tvNav.Nodes.Count - 1].ChildNodes[j], dt, (int)chTypeDv2[j]["ModelType"], (int)chTypeDv2[j]["ChId"]);
        }
        chDt2.Dispose();
        chTypeDv2.Dispose();
    }

    private void BindColumn(int colParentId, TreeNode tn, DataTable dt, int modelType, int chId)
    {
        DataView dv = new DataView(dt);
        dv.RowFilter = "colParentId= " + colParentId;
        for (int i = 0; i < dv.Count; i++)
        {
            TreeNode columnNode = new TreeNode();
            columnNode.ToolTip = "栏目右键操作$" + dv[i]["ColId"].ToString() + "$" + dv[i]["ChId"].ToString();
            columnNode.Text = dv[i]["ColName"].ToString();
            columnNode.NavigateUrl = "~/system/info/InfoList.aspx?ChId=" + chId + "&ColId=" + dv[i]["ColId"];
            columnNode.Target = "ContentIframe";

            tn.ChildNodes.Add(columnNode);
            BindColumn((int)dv[i]["ColId"], tn.ChildNodes[i], dt, modelType, chId);
        }
    }

  
}
 