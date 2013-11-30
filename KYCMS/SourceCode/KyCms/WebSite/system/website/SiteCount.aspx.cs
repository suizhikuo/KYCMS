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

public partial class system_website_SiteCount : System.Web.UI.Page
{
    B_SiteCount bll = new B_SiteCount();
    string dataType = "";
    string filter = "";
    B_Admin admin = new B_Admin();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(29);

        if (!string.IsNullOrEmpty(Request.QueryString["type"]) && !string.IsNullOrEmpty(Request.QueryString["filter"]))
        {
            try
            {
                dataType = Request.QueryString["type"];
                string F = Request.QueryString["filter"];

                if (F == "cur")
                {
                    if (dataType == "year")
                    {
                        filter = DateTime.Now.Year.ToString();
                    }
                    if (dataType == "month")
                    {
                        filter = DateTime.Now.ToString("yyyy-MM");
                    }
                    if (dataType == "week")
                    {
                        filter = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    if (dataType == "day")
                    {
                        filter = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                }
                else
                {
                    filter = F;
                }
            }
            catch
            { }

            BindData(dataType, filter);
        }
    }


    void BindData(string dataType,string filter)
    {
        rptSiteCount.DataSource = bll.GetData(dataType, filter);
        rptSiteCount.DataBind();
    }

    protected string SetHeaderName()
    {
        if (dataType == "year")
            return "月份";
        if (dataType == "month")
            return "日期";
        if (dataType == "week")
            return "星期";
        if (dataType == "day")
            return "时间";
        else
            return "";
    }

    protected string SetType(object type)
    {
        string str = "";
        if (type != null)
        {
            switch (dataType)
            {
                case "year":
                    str = type.ToString() + "月";
                    break;
                case "month":
                    str = type.ToString() + "日";
                    break;
                case "week":
                    str = "星期" + type.ToString();
                    break;
                case "day":
                    int time =int.Parse(type.ToString());
                    str = (time - 1) + ":00-"+time+":00";
                    break;
                default:
                    break;
            }
        }
        return str;
    }

    protected Unit SetImg(object num)
    {
        if (num != null)
        {
            return new Unit(num.ToString());
        }
        else
        {
            return new Unit(0);
        }
    }
}
