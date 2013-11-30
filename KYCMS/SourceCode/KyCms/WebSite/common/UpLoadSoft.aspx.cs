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

public partial class common_UpLoadSoft : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 使用UploadID来唯一标识是当前的上传
            //
            string ControlId = Request.QueryString["ControlId"];

            if (Request.QueryString["UploadID"] == null)
                Response.Redirect("UpLoadSoft.aspx?ControlId=" + ControlId + "&UploadID=" + Guid.NewGuid().ToString());

            // 当提交的时候，开始加载进度条
            //
            btnUpload.Attributes.Add("onclick", "window.setTimeout('LoadProgressInfo()', 100)");
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        B_SoftUpLoad bll = new B_SoftUpLoad();

        //string FilePath = Request.QueryString["FilePath"];
        string ControlId = Request.QueryString["ControlId"];
        string FilePath = File_PicPath.Text;

        string[] MyFilePath = FilePath.Split('|');

        // 后端处理方法和普通的上传是一样的
        //litMsg.Text = "<script>$('ImgPre').src='" + Param.ApplicationRootPath + "/upload/" + FilePath + "/" + sFilePicPath + "';$('HrefImg').href='" + Param.ApplicationRootPath + "/upload/" + FilePath + "/" + sFilePicPath + "'</script>";
        //
        //string filename = this.uploadFile.PostedFile.FileName;
        //filename = filename.Substring(filename.LastIndexOf("\\"));
        //this.uploadFile.PostedFile.SaveAs("C:\\temp\\" + filename);
        string GetFilePath = bll.UpLoadSoft(uploadFile, "" + Param.ApplicationRootPath + "/upload/" + MyFilePath[0] + "/");
        Response.Write("<script language='javascript'>window.dialogArguments.$('" + ControlId + "').value='" + GetFilePath + "';window.close();</script>");

        // 上传完后使用脚本通知前端进度条
        //
        Response.End();
    }
}
