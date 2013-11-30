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
using Ky.Common;
using Ky.BLL;
using Ky.Model;

public partial class sys_template_MoreReviewList : System.Web.UI.Page
{
    B_SiteInfo SiteBll = new B_SiteInfo();
    B_User UserBll = new B_User();
    B_Review ReviewBll = new B_Review();
    protected int PageIndex = 1;
    protected int PageSize = 10;
    protected int RecordCount = 0;
    protected  int PageCount = 0;
    protected  int ModelType = 0;
    protected  int Id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
         if(!string.IsNullOrEmpty(Request.QueryString["P"]))
        {
            try
            {
                PageIndex = int.Parse(Request.QueryString["P"]);
            }
            catch{}
        }
         if (!string.IsNullOrEmpty(Request.QueryString["PageSize"]))
        {
            try
            {
                PageSize = int.Parse(Request.QueryString["PageSize"]);
            }
            catch { }
        }
        if(!string.IsNullOrEmpty(Request.QueryString["ModelType"]))
        {
            try
            {
                ModelType = int.Parse(Request.QueryString["ModelType"]);
            }
            catch{}
        }
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
        {
            try
            {
                Id = int.Parse(Request.QueryString["Id"]);
            }
            catch { }
        }
        
        if (ModelType <= 0 || Id <= 0)
        {
            return;
        }
        Bind(PageIndex, PageSize, " Where IsCheck=1 And ModelType=" + ModelType + " And InfoId="+Id+" ");
        SetLink();
    }
    protected void Bind(int pageIndex,int pageSize,string whereStr)
    {
        DataSet ds = ReviewBll.ReviewList(pageIndex, pageSize, whereStr);
        repReview.DataSource = ds.Tables[0].DefaultView;
        repReview.DataBind();
        RecordCount = (int)ds.Tables[1].Rows[0][0];
        PageCount = (RecordCount - 1) / PageSize + 1;

    }
    protected void SetLink()
    {
        int prePageIndex = PageIndex-1;
        //hlPre.NavigateUrl = Param.ApplicationRootPath + "/Comment.aspx?P=" + prePageIndex + "&Type=" + ModelType + "&Id=" + Id;
        hlPre.NavigateUrl = "javascript:ReviewPadding('" + Param.ApplicationRootPath + "',"+ModelType+","+Id+","+PageSize+","+prePageIndex+")";
        hlFirst.NavigateUrl = "javascript:ReviewPadding('" + Param.ApplicationRootPath + "'," + ModelType + "," + Id + "," + PageSize + ",1)";
        if (PageIndex <= 1)
        {
            hlPre.NavigateUrl = string.Empty;
            hlFirst.NavigateUrl = string.Empty;
        }
        
        int nextPageIndex = PageIndex + 1;
        //hlNext.NavigateUrl = Param.ApplicationRootPath + "/Comment.aspx?P=" + nextPageIndex + "&Type=" + ModelType + "&Id=" + Id;

        hlNext.NavigateUrl = "javascript:ReviewPadding('" + Param.ApplicationRootPath + "'," + ModelType + "," + Id + "," + PageSize + "," + nextPageIndex + ")";
        hlEnd.NavigateUrl = "javascript:ReviewPadding('" + Param.ApplicationRootPath + "'," + ModelType + "," + Id + "," + PageSize + "," + PageCount + ")";
        if (PageIndex >= PageCount)
        {
            hlNext.NavigateUrl = string.Empty;
            hlEnd.NavigateUrl = string.Empty;
        }
        
    }
    protected string GetReviewContent(object ReviewContent)
    {
        if (ReviewContent != null && ReviewContent.ToString() != string.Empty)
        {
            return Function.UbbToHtml(ReviewContent.ToString());
        }
        else
        {
            return string.Empty;
        }
    }
    protected string GetName(string loginName)
    {
        if (loginName == "")
            return "匿名";
        return loginName;
    }
}
