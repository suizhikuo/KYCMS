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

public partial class common_UpLoadFile : System.Web.UI.Page
{
    private B_UpLoadFile BUpLoadFile = new B_UpLoadFile();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string FilePath = File_PicPath.Text;
        string[] MyFilePath = FilePath.Split(new Char[] { '|' });

        string ControlId = Request.QueryString["ControlId"];
        string FilePicPath = BUpLoadFile.GetUpLoadFile(File1, "" + Param.ApplicationRootPath + "/upload/" + MyFilePath[0] + "/", int.Parse(MyFilePath[1]));

        Response.Write("<script>window.dialogArguments.$('" + ControlId + "').value='" + FilePicPath + "';window.close();</script>");
        Response.End();
    }
}
