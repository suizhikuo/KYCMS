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
using Ky.Model;

public partial class Comment : System.Web.UI.Page
{
    int Id = 0;
    int ModelType = 0;
    int P = 1;
    B_Create CreateBll = new B_Create();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
        {
            try
            {
                Id = int.Parse(Request.QueryString["Id"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["ModelType"]))
        {
            try
            {
                ModelType = int.Parse(Request.QueryString["ModelType"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["P"]))
        {
            try
            {
                P = int.Parse(Request.QueryString["P"]);
            }
            catch { }
        }
        if (Id <= 0 || ModelType <= 0)
        {
            Function.ShowMsg(0, "<li>该评论不存在</li>");
        }
        Response.Write(CreateBll.GetInfoCommentList(ModelType,Id,P));
    }
}
