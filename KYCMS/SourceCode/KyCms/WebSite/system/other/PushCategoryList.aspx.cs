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
using System.IO;
using System.Text;
using Ky.BLL;
using Ky.Model;
using Ky.Common;

public partial class system_other_PushCategoryList : System.Web.UI.Page
{
    B_AdCategory Bll = new B_AdCategory();
    B_Ad AdBll = new B_Ad();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(30);
        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        DataSet data = Bll.GetList(Pager.PageSize, Pager.CurrentPageIndex, "");
        rptAdCategory.DataSource = data.Tables[0];
        rptAdCategory.DataBind();
        Pager.RecordCount = Convert.ToInt32(data.Tables[1].Rows[0][0]);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    protected void rptItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal litType = e.Item.FindControl("LitDisplayType") as Literal;
            switch (litType.Text)
            {
                case "1":
                    litType.Text = "矩形横幅";
                    break;
                case "2":
                    litType.Text = "对联";
                    break;
                case "3":
                    litType.Text = "随屏移动";
                    break;
                case "4":
                    litType.Text = "随机浮动";
                    break;
                case "5":
                    litType.Text = "版位广告";
                    break;
            }
        }
    }

    protected void rptItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete" && e.CommandArgument != null)
        {
            int key = int.Parse(e.CommandArgument.ToString());
            Bll.Delete(key);
            try
            {
                File.Delete(Param.SiteRootPath + "\\Push\\" + key + ".js");
            }
            catch (IOException)
            {
                Function.ShowSysMsg(1,"<li>数据已删除.但在删除广告JS文件时I/O异常,请手动删除 Push/"+key+".js 文件.</li><li><a href='javascript:window.history.back()'>返回上一步</li>");
            }
        }
        if (e.CommandName == "SetDisable")
        {
            string[] args = e.CommandArgument.ToString().Split('|');
            string status = args[1];
            int key = int.Parse(args[0]);
            M_AdCategory model = Bll.GetModel(key);
            if (status == "1")
            {
                model.IsDisabled = 2;
                Bll.Update(model);
                try
                {
                    File.Delete(Param.SiteRootPath + "\\Push\\" + key + ".js");
                }
                catch (IOException)
                {
                    Function.ShowSysMsg(1, "<li>数据已更新.但在删除广告JS文件时I/O异常,您需要手动删除 Push/" + key + ".js 文件.</li><li><a href='javascript:window.history.back()'>返回上一步</li>");
                }
            }
            if (status == "2")
            {
                model.IsDisabled = 1;
                Bll.Update(model);
                try
                {
                    AdBll.RefreshAd(key.ToString());
                }
                catch (IOException)
                { Function.ShowSysMsg(1, "<li>数据已更新.但未能刷新广告JS文件.请确保Push文件夹有写权限,然后手动刷新该广告位JS.</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>"); }
                catch (Exception exp)
                { Function.ShowSysMsg(0, "<li>" + exp.Message + "</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>"); }
            }
            
        }
        if (e.CommandName == "Refresh")
        {
            string cid = e.CommandArgument.ToString();
            try
            {
                AdBll.RefreshAd(cid);
            }
            catch (IOException)
            { Function.ShowSysMsg(0, "<li>未能刷新广告JS文件.请确保Push文件夹有写权限,然后手动刷新该广告位JS.</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>"); }
            catch (Exception exp)
            { Function.ShowSysMsg(0,"<li>"+exp.Message+"</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>"); }
            Function.ShowSysMsg(1,"<li>JS文件已更新.</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        BindData();
    }

    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptAdCategory.Items.Count; i++)
        {
            CheckBox chk = rptAdCategory.Items[i].FindControl("chkBox") as CheckBox;
            if (chk != null && chk.Checked)
            {
                Literal id = rptAdCategory.Items[i].FindControl("LitId") as Literal;
                Bll.Delete(int.Parse(id.Text));
                try
                {
                    File.Delete(Param.SiteRootPath + "\\Push\\" + id.Text + ".js");
                }
                catch (IOException)
                {
                    Function.ShowSysMsg(1, "<li>已删除 "+(i+1)+" 条数据.但在删除广告JS文件时I/O异常,请手动删除 Push/" + id.Text + ".js 文件.</li><li>为了后续的修改/删除能顺利进行,请确保 Push 文件夹有写权限.</li><li><a href='javascript:window.history.back()'>返回上一步</li>");
                }
            }
        }
        BindData();
    }

    protected string SetWH(object wh)
    {
        string returnStr = "";
        if (wh != null)
        {
            returnStr = wh.ToString().Substring(0, wh.ToString().LastIndexOf('|'));
        }
        return returnStr;
    }
}
