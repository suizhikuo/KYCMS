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
using Openlab.Web.Upload;

public partial class common_Progress : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string uploadId = Request.QueryString["UploadID"];
        string scriptText = "";
        string scriptUploading = "pb.setSize({0}, {1});";
        string scriptClearTimer = "ClearTimer();";
        string scriptUploadComplete = "pb.UploadComplete();" + scriptClearTimer;
        string scriptUploadError = "pb.UploadError();";

        string length = "";
        string read = "";

        Openlab.Web.Upload.Progress progress = HttpUploadModule.GetProgress(uploadId, Application);
        if (progress != null)
        {
            // 如果正在接收数据，利用脚本来通知前端进度条
            //
            if (progress.State == UploadState.ReceivingData)
            {
                length = (progress.ContentLength / 1024).ToString();
                read = (progress.BytesRead / 1024).ToString();
                scriptText = string.Format(scriptUploading, length, read);
            }
            else if (progress.State == UploadState.Complete)
            {
                scriptText = scriptUploadComplete;
            }
            else
            {
                scriptText = scriptUploadError;
            }
        }
        else
        {
            //scriptText = scriptUploadError;
        }
        Response.Clear();
        Response.Write(scriptText);
        Response.End();
    }
}
