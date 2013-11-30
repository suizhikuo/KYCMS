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
using Ky.SQLServerDAL;
using Ky.Common;
public partial class user_space_ShowPhoto : System.Web.UI.Page
{
    B_UserAlbum AlbumBll = new B_UserAlbum();
    M_UserAlbum AlbumModel = new M_UserAlbum();
    B_UserPhoto PhotoBll = new B_UserPhoto();
    M_UserPhoto PhotoModel = new M_UserPhoto();
    B_User UserBll = new B_User();
    M_User UserModel = new M_User();
     protected int AlbumId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserBll.CheckIsLogin();
        UserModel = UserBll.GetUser(UserBll.GetCookie().LogName);
        B_UserSpace.IsActive(UserModel.UserID, 1);
        if (!string.IsNullOrEmpty(Request.QueryString["AlbumId"]))
        {
            try
            {
                AlbumId = int.Parse(Request.QueryString["AlbumId"]);
            }
            catch { }
        }
        AlbumModel = AlbumBll.GetAlbumById(AlbumId,UserModel.UserID);
        if (!IsPostBack)
        {
            repPhotoBind();
        }
    }
    protected void repPhotoBind()
    {
        int recordCount = 0;
        DataTable dt = PhotoBll.GetUserPhotoById(AlbumId, UserModel.UserID, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, ref recordCount);
        repPhoto.DataSource = dt;
        repPhoto.DataBind();
        AspNetPager.RecordCount = recordCount;
        AspNetPager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}张照片 每页显示{3}张", AspNetPager.CurrentPageIndex, AspNetPager.PageCount, AspNetPager.RecordCount, AspNetPager.PageSize);
    }
    protected void repPhoto_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        HiddenField hfId = (HiddenField)e.Item.FindControl("hfId");
        PhotoBll.DeletePhoto(hfId.Value,UserModel.UserID,1);
        repPhotoBind();
    }
    protected void repPhoto_ItemDataBound(object sender,RepeaterItemEventArgs e)
    {
        int recordCount = 0;
        DataTable dt = PhotoBll.GetUserPhotoById(AlbumId, UserModel.UserID,1,50, ref recordCount);
        if (dt.Rows.Count <= 0 && e.Item.ItemType==ListItemType.Footer)
        {
            Literal litMsg = (Literal)e.Item.FindControl("litMsg");
            litMsg.Text = "该相册下没有照片，请<a href='UploadPic.aspx?AlbumId="+AlbumId+"'>上传</a>！";
        }
        if(e.Item.ItemType==ListItemType.Header && AlbumId>0)
        {
            AlbumModel = AlbumBll.GetAlbumById(AlbumId, UserModel.UserID);
            Label lbRep = (Label)e.Item.FindControl("lbRepTitle");
            lbRep.Text = AlbumModel.AlbumName;
        }
    }
    protected void btnDeleteChecked_Click(object sender, EventArgs e)
    {
        string idStr=GetSelectIdStr();
        string[] id = idStr.Split(',');
        PhotoBll.DeletePhoto(idStr,UserModel.UserID,id.Length);
        repPhotoBind();
    }
    protected void AspNetPager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager.CurrentPageIndex = e.NewPageIndex;
        repPhotoBind();
    }

    #region 取得批量选择的ID
    private string GetSelectIdStr()
    {
        string idStr = string.Empty;
        foreach (RepeaterItem item in repPhoto.Items)
        {
            CheckBox cb = (CheckBox)item.FindControl("chkBoxDelete");
            HiddenField hf = (HiddenField)item.FindControl("hfId");
            if (cb.Checked)
            {
                idStr += hf.Value+",";
            }

        }
        if (idStr == "")
        {
            return "";
        }

        if (idStr.EndsWith(","))
        {
            idStr = idStr.Substring(0, idStr.Length - 1);
        }
        return idStr;
    }
    #endregion
}
