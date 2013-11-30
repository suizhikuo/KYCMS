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
using Ky.SQLServerDAL;
using Ky.Model;
public partial class userspace_ShowPic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int photoId = 0;
        if(Request.QueryString["FilePath"]!=null)
        {
            Image1.ImageUrl = Param.ApplicationRootPath + "/user/upload/" + Request.QueryString["FilePath"];
        }
        if (!string.IsNullOrEmpty(Request.QueryString["PhotoId"]))
        {
            photoId = Convert.ToInt32(Request.QueryString["PhotoId"]);
        }
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["FilePath"]))
            {
                Image1.ImageUrl = Param.ApplicationRootPath + "/user/upload/" + Request.QueryString["FilePath"];
                B_UserPhoto photoBll = new B_UserPhoto();
                M_UserPhoto photoModel = photoBll.GetPhotoByPhotoId(photoId);
                if (photoModel == null)
                    Function.ShowMsg(0, "<li>照片参数错误!</li><li><a href='javascript:history.back()'>返回上一级</a></li>");
                photoModel.VisitNum += 1;
                photoBll.UpdatePhoto(photoModel);
            }
        }
    }
}
