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
using Ky.BLL.CommonModel;
using Ky.Common;
using Ky.Model;
using Ky.BLL;

public partial class system_infomodel_TransferCodeHtml : System.Web.UI.Page
{
    private B_CustomForm BCustomForm = new B_CustomForm();
    private M_CustomForm MCustomForm = new M_CustomForm();
    protected int CustomFormId = 0;
    private DataTable dtIsUser;
    private B_ShowFieldStyle BShowFieldStyle = new B_ShowFieldStyle();
    private B_CustomFormField BCustomFormField = new B_CustomFormField();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(33);
        Response.Cache.SetNoStore();

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

        //判断是否有字段
        if (dtIsUser.Rows.Count<1)
        {
            Response.Write("<script>alert('该表单下还没有添加字段，不能够调用');window.close();</script>");
            Response.End();
        }


        //判断是否起用了时间限制
        if (MCustomForm.IsUnlockTime)
        {
            if (DateTime.Parse(MCustomForm.StartTime.ToShortDateString()) > DateTime.Parse(DateTime.Now.ToShortDateString()))
            {
                Response.Write("<script>alert('" + MCustomForm.FormName + "启用了时间限制，还不能使用" + MCustomForm.FormName + "');window.close();</script>");
                Response.End();
            }

            if (DateTime.Parse(MCustomForm.EndTime.ToShortDateString()) < DateTime.Parse(DateTime.Now.ToShortDateString()))
            {
                Response.Write("<script>alert('" + MCustomForm.FormName + "启用了时间限制，目前已经过期');window.close();</script>");
                Response.End();
            }
        }

        if (!Page.IsPostBack)
        {
            FormName.Text = MCustomForm.FormName;
            string MyText="";

            MyText += "<script type=\"text/javascript\" src=\"" + Param.ApplicationRootPath + "/js/Common.js\"></script>\r\n<script src=\"" + Param.ApplicationRootPath + "/js/RiQi.js\" type=\"text/javascript\"></script>\r\n";
            MyText += "<form name=\"form1\" method=\"post\" action=\"" + Param.ApplicationRootPath + "/other/AddInfoForm.aspx?CustomFormId=" + CustomFormId + "\" id=\"form1\">\r\n<input name=\"FilePicPath\" type=\"text\" value=\"" + MCustomForm.UploadPath + "|" + MCustomForm.UploadSize + "\" id=\"FilePicPath\" style=\"display: none\">\r\n";
            MyText += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"1\" class=\"border\" style=\"width: 99%\" align=\"center\">\r\n";

            for (int i = 0; i < dtIsUser.Rows.Count; i++)
            {
                MyText += "<tr class=\"tdbg\">\r\n";
                MyText += "<td align=\"right\" class=\"bqleft\">" + dtIsUser.Rows[i]["Alias"].ToString() + "：</td>\r\n";
                MyText += "<td class=\"bqright\">" + GetShowStyle(dtIsUser.Rows[i]["Name"].ToString(), dtIsUser.Rows[i]["IsNotNull"].ToString(), dtIsUser.Rows[i]["Type"].ToString(), dtIsUser.Rows[i]["Content"].ToString(), dtIsUser.Rows[i]["Description"].ToString()) + "</td>\r\n";
                MyText += "</tr>\r\n";
            }

            if (MCustomForm.IsValidate)
            {
                MyText += "<tr class=\"tdbg\">\r\n<td align=\"right\" class=\"bqleft\">验证码：</td>\r\n<td class=\"bqright\"><input type=\"text\" size=\"10\" name=\"txtValidate\"> <img src=\"" + Param.ApplicationRootPath + "/Common/Code.aspx\" id=\"IMG1\" onclick=this.src=\"" + Param.ApplicationRootPath + "/Common/Code.aspx\" alt=\"给我换一个\">\r\n</td>\r\n</tr>\r\n";
            }
            MyText += "<tr class=\"tdbg\">\r\n<td height=\"40\" align=\"right\" class=\"bqleft\"></td>\r\n<td class=\"bqright\"><input type=\"submit\" value=\" 提 交 \" class=\"btn\">\r\n</td>\r\n</tr>\r\n";
            MyText += "</table>\r\n";
            MyText+="</form>";

            TextBox1.Text = MyText;
        }
    }

    public string GetShowStyle(string Name, string IsNotNull, string Type, string Content, string Description)
    {
        return BShowFieldStyle.ShowStyleField(Name, IsNotNull, Type, Content, Description, null);
    }
}
