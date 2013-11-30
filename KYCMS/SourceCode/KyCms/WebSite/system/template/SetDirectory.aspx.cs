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
using System.Text.RegularExpressions;

using Ky.Common;
using System.IO;
using Ky.BLL;

public partial class System_TemplateList_SetDirectory : System.Web.UI.Page
{
    public string fileName;
    protected B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if(!IsPostBack)
        {
            AdminGroupBll.Power_Judge(8);
            fileName=Request.QueryString["fileName"].ToString();
            Page.DataBind();
        }
        
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        string oldFile = Request.QueryString["rePath"] + @"\" + Request.QueryString["fileName"].ToString();
        string newFile = Request.QueryString["rePath"] + @"\" + txtFileName.Text.ToString();
        string extName = Path.GetExtension(newFile).ToLower();
        bool flag = false;
        if (!(Request.QueryString["fileName"].ToString() == txtFileName.Text.ToString()))
        {

            if (Path.GetExtension(oldFile) == "")
            {
                string patt = @"^[a-zA-Z0-9_]+$";
                if (!Regex.IsMatch(txtFileName.Text.Trim(), patt, RegexOptions.IgnoreCase))
                {
                    Function.ShowSysMsg(0, "<li>修改目录失败</li><li>目录名称只能由数字、字母、下划线组成</li><li><a href='javascript:window.history.back(-1)'>返回上一页</a></li>");
                }
                foreach (string s in Param.TemplateAllowExtName)
                {
                    if (extName == s)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(oldFile);
                    dirInfo.MoveTo(newFile);
                }
                else
                {
                    ltMsg.Text = "<script>alert('你不能改名为动态网页的扩展名')</script>";
                    return;
                }
            }
            else
            {
                foreach (string s in Param.TemplateAllowExtName)
                {
                    if (extName == s)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(oldFile);
                    dirInfo.MoveTo(newFile);
                }
                else
                {
                    ltMsg.Text = "<script>alert('你不能改名为动态网页的扩展名')</script>";
                    return;
                }
            }
        }

        string parthstr = "";
        if (Request.QueryString["DirPath"] != "")
        {
            parthstr = "\"?DirPath=" + Request.QueryString["DirPath"] + "\"";
        }
        Response.Write("<script>dialogArguments.setx(" + parthstr + ");window.close();</script>");
    }
}
