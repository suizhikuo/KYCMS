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
public partial class System_Label_GetLabelContent : System.Web.UI.Page
{
    int labelContentId;
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(6);
        Response.Cache.SetNoStore();
        if (Request.QueryString["labelContentId"] != null && Request.QueryString["labelContentId"] != "")
        {
            try
            {
                labelContentId = int.Parse(Request.QueryString["labelContentId"]);
            }
            catch { }
        }
        if (labelContentId == 0)
        {
            return;
        }
        B_LabelContent bll = new B_LabelContent();
        string content = bll.GetLabelContent(labelContentId);
        Response.Write(content);
    }
}
