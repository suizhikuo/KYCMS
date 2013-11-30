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

public partial class user_space_UploadPhoto : System.Web.UI.Page
{
    private B_UpLoadPic up = new B_UpLoadPic();
    protected string ControlId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ControlId"] != null && Request.QueryString["ControlId"] != "")
        {
            ControlId = Request.QueryString["ControlId"];
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string FilePath = File_PicPath.Text;
        string SelectNewSize = Request.Form["NewSizeType"];
        bool BiLi = false;
        string sMaxWidth = "";
        string sMaxHeight = "";

        if (SelectNewSize == "1")
        {
            BiLi = true;
        }

        if (!(NewSize.Checked))
        {
            sMaxWidth = "100";
            sMaxHeight = "100";
        }
        else
        {
            sMaxWidth = MaxWidth.Text;
            sMaxHeight = MaxHeight.Text;
        }

        if (NewSize.Checked && SelectNewSize == "0")
        {
            if (!Function.CheckNumber(sMaxWidth) || !Function.CheckNumber(sMaxHeight))
            {
                litMsg.Text = "<script language='javascript'>alert('缩略图宽度和高度只能够为数字');</script>"; return;
            }
        }

        if (NewSize.Checked && SelectNewSize == "1")
        {
            if (!Function.CheckNumber(BiLiValue.Text))
            {
                litMsg.Text = "<script language='javascript'>alert('缩略图比例只能够为数字');</script>"; return;
            }
        }

        string sFilePicPath = up.GetUpLoadPicPath(File1, "" + Param.ApplicationRootPath + "/user/upload/", WaterMark.Checked, NewSize.Checked, int.Parse(sMaxWidth), int.Parse(sMaxHeight), BiLi, int.Parse(BiLiValue.Text),0);
        FilePicPath.Text = sFilePicPath;

        litMsg.Text = "<script>$('ImgPre').src='" + Param.ApplicationRootPath + "/user/upload/" + sFilePicPath + "';$('HrefImg').href='" + Param.ApplicationRootPath + "/upload/" + sFilePicPath + "'</script>";
    }
}
