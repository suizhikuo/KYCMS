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
using Ky.BLL;
using Ky.BLL.CommonModel;
using Ky.Model;

public partial class system_info_UploadImg : System.Web.UI.Page
{
    string picSavePath = "";
    B_InfoModel InfoModelBll = new B_InfoModel();
    const int MODELID = 2;
    B_Admin AdminBll = new B_Admin();
    protected void Page_Load(object sender, EventArgs e)
    {
        LitMsg.Text = "";
        AdminBll.CheckMulitLogin();
        M_InfoModel infoModel = InfoModelBll.GetModel(MODELID);
        picSavePath = Param.ApplicationRootPath + "/upload/" + infoModel.UploadPath+"/";
        if (!string.IsNullOrEmpty(Request.QueryString["type"]))
        {
            if (Request.QueryString["type"] == "View")//从SetImage.aspx中查看已上传图片
            {
                uploadTable.Visible = false;
                ViewImg.ImageUrl = picSavePath + Request.QueryString["img"];
                imgTable.Visible = true;
            }
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        M_InfoModel info = InfoModelBll.GetModel(2);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        int maxWidth = Function.CheckNumber(txtMaxWidth.Text) == true ? int.Parse(txtMaxWidth.Text) : 0;
        int maxHeight = Function.CheckNumber(txtMaxHeight.Text) == true ? int.Parse(txtMaxHeight.Text) : 0;
        int bili = Function.CheckNumber(txtBili.Text) == true ? int.Parse(txtBili.Text) : 0;
        for (int i = 1; i < 13; i++)
        {
            HtmlInputFile file = Page.FindControl("File" + i) as HtmlInputFile;
            if (file.PostedFile != null && file.PostedFile.FileName != "")
            {
                B_UpLoadPic up = new B_UpLoadPic();
                string imgName = up.GetUpLoadPicPath(file, picSavePath, IsWatermark.Checked, IsNewSize.Checked, maxWidth, maxHeight, IsBiLi.Checked, bili,info.UploadSize);
                sb.Append(imgName);
                sb.Append(",");
            }
        }

        //返回文件名
        if (sb.ToString() == "")
        {
            LitMsg.Text = "<script type='text/javascript'>alert('未上传任何图片')</script>";
            return;
        }
        else
        {
            imgNames.Text = sb.ToString();
            btnReturnValue.Visible = true;
            btnUpload.Visible = false;
        }
    }
}
