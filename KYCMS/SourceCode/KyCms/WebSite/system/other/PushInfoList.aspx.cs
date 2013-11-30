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
using Ky.BLL;
using Ky.Common;

public partial class system_other_PushInfoList : System.Web.UI.Page
{
    B_Ad Bll = new B_Ad();
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

    protected void rptItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete" && e.CommandArgument != null)
        {
            string[] args = e.CommandArgument.ToString().Split('|');
            Bll.Delete(int.Parse(args[0]));
            if (File.Exists(Param.SiteRootPath + @"\push\"+args[1]+".js"))
            {
                try
                {
                    Bll.RefreshAd(args[1]);
                }
                catch (Exception exp)
                { Function.ShowSysMsg(1, "<li>数据已删除.但在刷新广告JS时有异常发生:" + exp.Message + " 您需要手动刷新该广告所属广告位JS</li><li><a href='other/PushCategoryList.aspx'>广告位列表</a></li><li><a href='javascript:window.history.back()'>返回上一步</a></li>"); }
            } 
            BindData();
        }
    }

    protected void rptItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litType = e.Item.FindControl("LitType") as Literal;
            switch (litType.Text)
            {
                case "1":
                    litType.Text = "图片";
                    break;
                case "2":
                    litType.Text = "Flash";
                    break;
                case "3":
                    litType.Text = "文字";
                    break;
                case "4":
                    litType.Text = "代码";
                    break;
            }
        }
    }

    protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Pager.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }

    protected string SetDate(object data)
    {
        string returnStr = "";
        if (data != null)
        {
            DateTime d=Convert.ToDateTime(data);
            if (d < DateTime.Now)
            {
                returnStr = d.ToShortDateString() + "<span style='color:red'>(已过期)</span>";
            }
            else
                returnStr = d.ToShortDateString();
        }
        return returnStr;
    }

    protected string SetCategoryName(object name)
    {
        string returnStr = "";
        if (name == null || name.ToString() == string.Empty)
        {
            returnStr = "<span style='color:red'>无</span>";
        }
        else
            returnStr = name.ToString();
        return returnStr;
    }

    protected void DeleteAll_Click(object sender, EventArgs e)
    {
        int count = 0;
        for (int i = 0; i < rptAdCategory.Items.Count; i++)
        {
            CheckBox chkBox = rptAdCategory.Items[i].FindControl("chkBox") as CheckBox;
            if (chkBox != null && chkBox.Checked)
            {
                Literal id = rptAdCategory.Items[i].FindControl("LitId") as Literal;
                Bll.Delete(int.Parse(id.Text));
                count++;
            }
        }
        if (count > 0)
        {
            Function.ShowSysMsg(1, "<li>数据已删除,请刷新相关广告位的JS.</li><li><a href='other/PushInfoList.aspx'>返回广告列表<a></li>");
        }
    }
}
