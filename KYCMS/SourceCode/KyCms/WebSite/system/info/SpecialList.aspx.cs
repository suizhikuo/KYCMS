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

public partial class System_website_Speacils : System.Web.UI.Page
{
    B_Special special = new B_Special();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        B_Admin admin = new B_Admin();
        AdminGroupBll.Power_Judge(3);
        if (!IsPostBack)
        {
            BindSpeacils();
        }
    }

    /// <summary>
    /// 为 GridView  绑定数据
    /// </summary>
    void BindSpeacils()
    {
        rptSpeacils.DataSource = special.GetSpecials(0);
        rptSpeacils.DataBind();
    }

    /// <summary>
    /// 查看专题信息
    /// </summary>
    /// <param name="key">专题ID</param>
    /// <returns>专题链接</returns>
    protected string ViewSpeacil(object key)
    {
        if (key != null && key.ToString() != "")
        {
            return "SetSpecial.aspx?Action=Update&key=" + key.ToString();
        }
        else
        {
            return "";
        }
    }


    /// <summary>
    /// 父repeater绑定数据
    /// </summary>
    protected void rptSpeacils_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal iscmd = (Literal)e.Item.FindControl("lbIscmd");
            iscmd.Text = iscmd.Text == "False" ? "&nbsp;" : "荐";
            LinkButton cmd = (LinkButton)e.Item.FindControl("lnkbtnCmd");
            cmd.Text = iscmd.Text == "荐" ? "取消推荐" : "设为推荐";

            Literal islock = (Literal)e.Item.FindControl("lbIslock");
            islock.Text = islock.Text == "False" ? "&nbsp;" : "锁";
            LinkButton disable = (LinkButton)e.Item.FindControl("lnkbtnDisable");
            disable.Text = islock.Text == "锁"?"启用":"禁用";

            Literal chName = (Literal)e.Item.FindControl("lbChName");
            chName.Text = chName.Text == string.Empty ? "全站专题" : chName.Text;
            
            Repeater child = (Repeater)e.Item.FindControl("rptChild");
            Label id = (Label)e.Item.FindControl("lbID");
            int key = int.Parse(id.Text);
            child.DataSource = special.GetSpecialByParentId(key);
            child.DataBind();
        }
    }

    /// <summary>
    /// 子专题数据绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rptChild_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal iscmd = (Literal)e.Item.FindControl("lbChildIscmd");
            iscmd.Text = iscmd.Text == "False" ? "&nbsp;" : "荐";

            LinkButton cmd = (LinkButton)e.Item.FindControl("lnkbtnChildCmd");
            cmd.Text = iscmd.Text == "荐" ? "取消推荐" : "设为推荐";

            Literal islock = (Literal)e.Item.FindControl("lbChildIslock");
            islock.Text = islock.Text == "False" ? "&nbsp;" : "锁";

            LinkButton disable = (LinkButton)e.Item.FindControl("lnkbtnChildDisable");
            disable.Text = islock.Text == "锁" ? "启用" : "禁用";

            Literal chName = (Literal)e.Item.FindControl("lbChildChName");
            chName.Text = chName.Text == string.Empty ? "全站专题" : chName.Text;
        }
    }

    /// <summary>
    /// 设置父专题的图片和样式
    /// </summary>
    /// <param name="id"></param>
    protected string IsLink(object id,object cnName)
    {
        string folder = Param.ApplicationRootPath + "/images/folder.gif";
        string pic = Param.ApplicationRootPath + "/images/+.gif";

        int Id = (int)id;
        DataTable dt = special.GetSpecialByParentId(Id);
        if (dt.Rows.Count > 0)
        {
            return "<img src=" + pic + "  align=absmiddle /><img src=" + folder + "  align=absmiddle /><b><a href='SpecialInfoList.aspx?sid=" + Id + "'>" + cnName.ToString() + "</a></b>";
        }
        else
        {
            return "<img src=" + pic + "  align=absmiddle /><img src=" + folder + "  align=absmiddle />" + "<a href='SpecialInfoList.aspx?sid=" + Id + "'>" + cnName.ToString() + "</a>";
        }
    }

    /// <summary>
    /// 设置子专题的图片
    /// </summary>
    protected string SetChild(object childName,object id)
    {
        if (childName != null && childName.ToString() != "")
        {
            string pic = Param.ApplicationRootPath + "/images/-.gif";
            string folder = Param.ApplicationRootPath + "/images/folder.gif";
            string line = Param.ApplicationRootPath + "/images/tree_line.gif";
            return "<img src=" + line + " align=absmiddle />" + "&nbsp;<img src=" + pic + "  align=absmiddle /><img src=" + folder + "  align=absmiddle />" + "<a href='SpecialInfoList.aspx?sid=" + id.ToString() + "'>" + childName.ToString() + "</a>";
        }
        else
        {
            return "";
        }
    }

    ///// <summary>
    ///// 父repeater事件
    ///// </summary>
    protected void rptSpeacils_ItemCommand(object source,RepeaterCommandEventArgs e)
    {
        Label id = (Label)e.Item.FindControl("lbID");
        int key = int.Parse(id.Text);
        M_Special model = special.GetSpecial(key);
        if (e.CommandName == "Delete")
        {            
            special.Delete(key);
            BindSpeacils();
        }
        if (e.CommandName == "SetDisable")
        {
            model.IsLock = model.IsLock == true ? false : true;
            special.Update(model);
            BindSpeacils();
        }
        if (e.CommandName == "SetCmd")
        {
            model.IsCommand = model.IsCommand == true ? false : true;
            special.Update(model);
            BindSpeacils();
        }
    }

    ///// <summary>
    ///// 子repeater 事件
    ///// </summary>
    protected void rptChild_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label id = (Label)e.Item.FindControl("lbChildID");
        int key = int.Parse(id.Text);
        M_Special model = special.GetSpecial(key);
        if (e.CommandName == "Delete")
        {
            special.Delete(key);
            BindSpeacils();
        }
        if (e.CommandName == "ChildSetDisable")
        {
            model.IsLock = model.IsLock == true ? false : true;
            special.Update(model);
            BindSpeacils();
        }
        if (e.CommandName == "ChildSetCmd")
        {
            model.IsCommand = model.IsCommand == true ? false : true;
            special.Update(model);
            BindSpeacils();
        }
    }
}
