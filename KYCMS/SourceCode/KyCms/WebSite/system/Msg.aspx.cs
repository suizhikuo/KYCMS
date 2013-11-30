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

public partial class system_Msg : System.Web.UI.Page
{
    public string ImgStr = "success";
    public string FlagStr = "√";
    public string Code = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        bool isSuccess = true;
        Header.Title = "操作成功";

        if (!string.IsNullOrEmpty(Request.QueryString["Flag"]))
        {
            isSuccess = Request.QueryString["Flag"]=="1"?true:false;
        }

        if (!string.IsNullOrEmpty(Request.QueryString["Code"]))
        {
            Code = Request.QueryString["Code"];
        }
      
        if (!isSuccess)
        {
            Header.Title = "操作失败";
            ImgStr = "fail";
            FlagStr = "×";
        }
        lbMsg.Text = Code;
    }
}
