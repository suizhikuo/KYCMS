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
using Ky.Model;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class other_CustomForm : System.Web.UI.Page
{
    private B_ShowFieldStyle BShowFieldStyle = new B_ShowFieldStyle();
    private B_CustomFormField BCustomFormField = new B_CustomFormField();
    protected int CustomFormId = 0;
    private B_CustomForm BCustomForm = new B_CustomForm();
    private M_CustomForm MCustomForm = new M_CustomForm();
    private B_InfoModel BInfoModel = new B_InfoModel();
    private DataTable dtIsUser;
    private B_User BUser = new B_User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["CustomFormId"]))
        {
            try
            {
                CustomFormId = int.Parse(Request.QueryString["CustomFormId"]);
            }
            catch { }
        }

        dtIsUser = BCustomFormField.GetIsUserList(CustomFormId);
        MCustomForm = BCustomForm.GetModel(CustomFormId);

        if (!Page.IsPostBack)
        {
            //权限验证
            GetIsOk();

            if (dtIsUser.Rows.Count > 0)
            {
                Response.Write("document.write(\"<script type='text/javascript' src='" + Param.ApplicationRootPath + "/js/Common.js'></script><script src='" + Param.ApplicationRootPath + "/js/RiQi.js'type='text/javascript'></script>\");");
                Response.Write("document.write(\"<form name='form1' method='post' action='" + Param.ApplicationRootPath + "/other/AddInfoForm.aspx?CustomFormId=" + CustomFormId + "' id='form1'>\");");
                Response.Write("document.write(\"<input name='FilePicPath' type='text' value='" + MCustomForm.UploadPath + "|" + MCustomForm.UploadSize + "' id='FilePicPath' style='display: none'>\");");
                Response.Write("document.write(\"<table border='0' cellpadding='0' cellspacing='1' class='border' style='width: 99%' align='center'>\");");

                for (int i = 0; i < dtIsUser.Rows.Count; i++)
                {
                    Response.Write("document.write(\"<tr class='tdbg'>\");");
                    Response.Write("document.write(\"<td align='right' class='bqleft'>\");");
                    Response.Write("document.write(\"" + dtIsUser.Rows[i]["Alias"].ToString() + "：\");");
                    Response.Write("document.write(\"</td>\");");
                    Response.Write("document.write(\"<td class='bqright'>\");");
                    Response.Write("document.write(\"" + GetShowStyle(dtIsUser.Rows[i]["Name"].ToString(), dtIsUser.Rows[i]["IsNotNull"].ToString(), dtIsUser.Rows[i]["Type"].ToString(), dtIsUser.Rows[i]["Content"].ToString(), dtIsUser.Rows[i]["Description"].ToString()).Replace("\"","") + "\");");
                    Response.Write("document.write(\"</td>\");");
                    Response.Write("document.write(\"</tr>\");");
                }
                if (MCustomForm.IsValidate)
                {
                    Response.Write("document.write(\"<tr class='tdbg'><td align='right' class='bqleft'>验证码：</td><td class='bqright'>\");");
                    Response.Write("document.write(\"<input type='text' size='10' name='txtValidate'> <img src='" + Param.ApplicationRootPath + "/Common/Code.aspx' id='IMG1' onclick=this.src='" + Param.ApplicationRootPath + "/Common/Code.aspx' alt='给我换一个'>\");");
                    Response.Write("document.write(\"</td></tr>\");");
                }
                Response.Write("document.write(\"<tr class='tdbg'><td height='40' align='right' class='bqleft'></td><td class='bqright'>\");");
                Response.Write("document.write(\"<input type='submit' value=' 提 交 ' class='btn'>\");");
                Response.Write("document.write(\"</td></tr>\");");
                
                Response.Write("document.write(\"</table>\");");
                Response.Write("document.write(\"</form>\");");
            }

            dtIsUser.Clear();
            dtIsUser.Dispose();
        }
    }

    public string GetShowStyle(string Name, string IsNotNull, string Type, string Content, string Description)
    {
        return BShowFieldStyle.ShowStyleField(Name, IsNotNull, Type, Content, Description, null);
    }

    private void GetIsOk()
    {
        //时间限制
        if (MCustomForm.IsUnlockTime)
        {
            if (DateTime.Parse(MCustomForm.StartTime.ToShortDateString()) > DateTime.Parse(DateTime.Now.ToShortDateString()))
            {
                Response.Write("document.write(\"" + MCustomForm.FormName + "启用了时间限制，还不能使用" + MCustomForm.FormName + "\")");
                Response.End();
            }

            if (DateTime.Parse(MCustomForm.EndTime.ToShortDateString()) < DateTime.Parse(DateTime.Now.ToShortDateString()))
            {
                Response.Write("document.write(\"" + MCustomForm.FormName + "启用了时间限制，目前已经过期\")");
                Response.End();
            }
        }

        //用户组权限
        if (MCustomForm.UserGroup != "|")
        {
            if (!BUser.IsLogin())
            {
                Response.Write("document.write(\"请登陆后使用" + MCustomForm.FormName + "功能！<a href='"+Param.ApplicationRootPath + "/user/Login.aspx'>登陆</a>\")");
                Response.End();
            }
            else
            {
                if (MCustomForm.UserGroup.IndexOf("|" + BUser.GetUser(BUser.GetCookie().UserID).GroupID + "|") == -1)
                {
                    Response.Write("document.write(\"你所在的用户组无权使用" + MCustomForm.FormName + "功能\")");
                    Response.End();
                }
            }
        }
    }
}
