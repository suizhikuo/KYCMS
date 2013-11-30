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

public partial class user_Msg : System.Web.UI.Page
{
    public string ImgStr = "";
    protected string Code="";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Code"]))
            {
                Code = Request.QueryString["Code"];
            }

            if (!string.IsNullOrEmpty(Request.QueryString["Flag"]))
            {
                if (Request.QueryString["Flag"] == "1")
                {
                    Header.Title = "操作成功";
                    MsgTitle.Text = "操作成功";
                    ImgStr = "Msg_1";
                }
                else
                {
                    if(Request.QueryString["Flag"] == "0")
                    {
                        Header.Title = "操作失败";
                        MsgTitle.Text = "操作失败";
                        ImgStr = "Msg_0";
                    }
                    else
                    {
                        Header.Title = "系统提示";
                        MsgTitle.Text = "系统提示";
                        ImgStr = "Msg_2";
                    }
                }
            }

            if (Code == "" && Request.QueryString["Flag"] == "2")
            {
                Code = "对不起，该次访问暂时遇到了问题!";
                Header.Title = "访问出错";
            }           

            lbMsg.Text = Code;
        }
    }
}
