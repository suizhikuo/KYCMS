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
using Ky.BLL.CommonModel;
using Ky.Model;

public partial class userspace_SpaceTemplate : System.Web.UI.MasterPage
{
    protected string UserName = string.Empty;
    protected B_User UserBll = new B_User();
    M_User UserModel = new M_User();
    B_UserMessage UserMessageBll = new B_UserMessage();
    B_UserAlbum AlbumBll = new B_UserAlbum();
    M_UserAlbum AlbumModel = new M_UserAlbum();
    private B_InfoOper InfoOperBll = new B_InfoOper();
    private B_InfoModel InfoModelBll = new B_InfoModel();
    B_UserSpace SpaceBll = new B_UserSpace();
    M_UserSpace SpaceModel = null;
    protected string StyleCss = null;
    protected string SpaceName = "";
    protected int ColorId = 0;
    protected B_Create CreateBll = new B_Create();
    protected DataRow UserInfoDr = null;
    M_UserGroup UserGroupModel = null;
    B_UserGroup UserGroupBll = new B_UserGroup();
    protected string GroupName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (!string.IsNullOrEmpty(Request.QueryString["ColorId"]))
        {
            ColorId = Convert.ToInt32(Request.QueryString["ColorId"]);
        }
        if (!string.IsNullOrEmpty(Request.QueryString["UserName"]))
        {
            UserName = Request.QueryString["UserName"];
        }

        UserModel = UserBll.GetUser(UserName);
        if (UserModel == null)
        {
            Function.ShowMsg(0, "<li>用户空间参数错误</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        }
        UserInfoDr = UserBll.GetUserAllInfo(UserModel.UserID);
        if(UserInfoDr==null)
        {
            Function.ShowMsg(0, "<li>用户空间参数错误</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        }
        int spaceTypeId = int.Parse(UserInfoDr["spacetypeid"].ToString());
        if (spaceTypeId != 1)
            Function.ShowMsg(0, "<li>用户空间参数错误</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        B_UserSpace.IsActive(UserModel.UserID, 2);
        UserGroupModel = UserGroupBll.GetModel(UserModel.GroupID);
        GroupName = UserGroupModel.UserGroupName;
        if (Request.Cookies["SpacePwd"] != null)
        {
            if (Request.Cookies["SpacePwd"]["UserId"] != UserModel.UserID.ToString())
            {
                Response.Cookies["SpacePwd"].Expires = DateTime.Now.AddDays(-1);
            }
        }
        SpaceModel = SpaceBll.GetUserSpaceById(UserModel.UserID);
        if (SpaceModel.TemplateId >= 18 && SpaceModel.TemplateId <= 24)
            StyleCss = "<link rel='stylesheet' type='text/css' href='skin/Space" + SpaceModel.TemplateId + ".css' />";
        else
            StyleCss = "<link rel='stylesheet' type='text/css' href='skin/Space18.css' />";
        SpaceName = SpaceModel.SpaceName;
        if (!IsPostBack)
        {
            SpacePrevPower();
            B_SiteInfo siteInfo = new B_SiteInfo();
            M_Site siteModel = siteInfo.GetSiteModel();
            lbCopyRight.Text = siteModel.CopyRight;
            repMyInfoBind();
            repMessageBind();
            repFriendBind();
            repAlbum();

        }

        AjaxPro.Utility.RegisterTypeForAjax(typeof(userspace_SpaceTemplate));
    }

    protected string UserInfo(string field)
    {
        DataRow dr = UserBll.GetUserAllInfo(UserModel.UserID);
        if (dr != null)
        {
            if (dr.Table.Columns.Contains(field))
                return dr[field].ToString();
            else
                return string.Empty;
        }
        else
            return string.Empty;
    }

    protected void SpacePrevPower()
    {
        //Response.End();
        #region 空间访问权限*开始
        int flag = SpaceBll.GetSapcePrevPowerByUserId(UserModel.UserID);
        #region 返回1仅好友可见情况
        if (flag == 1)
        {
            if (!UserBll.IsLogin())
                Function.ShowMsg(0, "<li>此用户空间只允许好友访问!</li><li>请先<a href='../user/login.aspx' target='_blank'>登录</a></li><li><a href='javascript:history.back();'>返回上一级</a></li>");

            #region 得到好友id串
            string whereStr = "KyUserFriend.UserId=" + UserModel.UserID.ToString() + " and FriendGroupId!=2";
            string friendIdStr = "";
            int total = 0;
            DataTable dt = UserBll.ListGroupMember(whereStr, 1000, 1, ref total);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                friendIdStr += Convert.ToInt32(dt.Rows[i]["FriendId"]) + ",";
            }

            if (friendIdStr.EndsWith(","))
                friendIdStr = friendIdStr.Substring(0, friendIdStr.Length - 1);
            #endregion
            bool temp = false;
            if (!string.IsNullOrEmpty(friendIdStr))
            {
                string[] id = friendIdStr.Split(',');
                for (int i = 0; i < id.Length; i++)
                {
                    if (Convert.ToInt32(id[i]) == UserBll.GetCookie().UserID)
                    {
                        temp = true;
                        break;
                    }
                }
            }
            if (!temp && UserModel.UserID != UserBll.GetCookie().UserID)
                Response.Redirect("ValidatePwd.aspx?UserName=" + UserName + "&OptionId=2");
        }
        #endregion
        #region 返回2密码访问
        else if (flag == 2)
        {
            if (!UserBll.IsLogin())
                Function.ShowMsg(0, "<li>此用户空间需要密码访问!</li><li>请先<a href='../user/login.aspx' target='_blank'>登录</a></li><li><a href='javascript:history.back();'>返回上一级</a></li>");
            //是否本人访问
            if (UserModel.UserID != UserBll.GetCookie().UserID)
            {
                //cookies是否为空
                if (HttpContext.Current.Request.Cookies["SpacePwd"] == null)
                {
                    Response.Redirect("ValidatePwd.aspx?UserName=" + UserName + "&OptionId=1");
                }
                //不是本人，cookies也不为空时
                else
                {
                    //判断cookies的LogId是否与先前登录的用户ID相等
                    if (HttpContext.Current.Request.Cookies["SpacePwd"]["LogId"] != UserBll.GetCookie().UserID.ToString())
                    {
                        Response.Cookies["SpacePwd"].Expires = DateTime.Now.AddDays(-1);
                        Response.Redirect("ValidatePwd.aspx?UserName=" + UserName + "&OptionId=1");
                    }
                    //cookies的UserId是否与当前的用户空间Id相等
                    if (HttpContext.Current.Request.Cookies["SpacePwd"]["UserId"] != UserModel.UserID.ToString())
                        Response.Redirect("ValidatePwd.aspx?UserName=" + UserName + "&OptionId=1");
                    //else
                    //    Response.Redirect("ValidatePwd.aspx?UserName=" + UserName + "&OptionId=2");
                }
            }
        }
        #endregion 空间访问权限*结束

        #endregion

    }
    protected void repMyInfoBind()
    {
        DataTable dtInfo = new DataTable();
        dtInfo.Columns.Add("Title", typeof(string));
        dtInfo.Columns.Add("Id", typeof(int));
        dtInfo.Columns.Add("AddTime", typeof(DateTime));
        // dtInfo.Columns.Add("RowIndex", typeof(int));
        // int rowIndex = 0;
        dtInfo.Columns.Add("ModelType", typeof(int));
        DataTable modelDt = InfoModelBll.GetList();

        foreach (DataRow dr in modelDt.Rows)
        {
            string tableName = dr["TableName"].ToString();
            int recordCount = 0;
            DataTable dt = InfoOperBll.GetUserInfoList(tableName, UserModel.UserID, "", "", 0, "0", "3", "", "", "", -1, 1, 10, ref recordCount);
            InfoNumber.Text = dt.Rows.Count.ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow tempDr = dtInfo.NewRow();
                tempDr["Title"] = dt.Rows[i]["Title"];
                tempDr["Id"] = dt.Rows[i]["id"];
                tempDr["AddTime"] = dt.Rows[i]["AddTime"];
                tempDr["ModelType"] = dt.Rows[i]["ModelType"];
                //tempDr["RowIndex"] = rowIndex;
                // rowIndex++;
                dtInfo.Rows.Add(tempDr);
            }
            dt.Dispose();
        }
        DataView dv = new DataView(dtInfo);
        dv.Sort = "AddTime desc";
        if (dv.Count <= 0)
        {
            showMore1.Visible = false;
            Label1.Text = "暂无稿件!";
            return;
        }
        while (dv.Count > 5)
            dv.Delete(dv.Count - 1);
        repMyInfo.DataSource = dv;
        repMyInfo.DataBind();

    }

    protected void repMessageBind()
    {
        DataTable dtMsg = new DataTable();
        dtMsg.Columns.Add("Title", typeof(string));
        dtMsg.Columns.Add("PostTime", typeof(string));
        dtMsg.Columns.Add("AnounName", typeof(string));
        dtMsg.Columns.Add("IsPrivacy", typeof(bool));
        dtMsg.Columns.Add("HomePage", typeof(string));
        int recordCount = 0;
        DataTable dt = UserMessageBll.GetMessageByUserId(UserModel.UserID, 1, 5, ref recordCount);
        if (dt.Rows.Count <= 0)
        {
            showMore.Visible = false;
            Label4.Text = "暂无留言!";
            return;
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dr = dtMsg.NewRow();
            dr["Title"] = dt.Rows[i]["Title"];
            dr["PostTime"] = dt.Rows[i]["PostTime"];
            dr["AnounName"] = dt.Rows[i]["AnounName"];
            dr["IsPrivacy"] = dt.Rows[i]["IsPrivacy"];
            dr["HomePage"] = dt.Rows[i]["HomePage"];
            dtMsg.Rows.Add(dr);
        }
        dt.Dispose();
        DataView dv = new DataView(dtMsg);
        dv.Sort = "PostTime desc";
        repMessage.DataSource = dv;
        repMessage.DataBind();

    }

    protected string ShowTitle(object title, object isPrivacy)
    {
        if (!UserBll.IsLogin())
        {
            if (Convert.ToBoolean(isPrivacy))
                return "该留言为悄悄话!";
            else
                return title.ToString();
        }
        else
        {
            if (HttpContext.Current.Request.Cookies["User"]["logN"] != "")
            {
                if (Convert.ToBoolean(isPrivacy) && HttpContext.Current.Request.Cookies["User"]["logN"] != UserModel.LogName)
                    return "该留言为悄悄话!";
                else
                    return title.ToString();
            }
            else
                return "该留言为悄悄话!";
        }
    }

    protected void repFriendBind()
    {
        string whereStr = "KyUserFriend.UserId=" + UserModel.UserID.ToString() + " and FriendGroupId!=2";
        int total = 0;
        DataTable dt = UserBll.ListGroupMember(whereStr, 10, 1, ref total);
        if (dt.Rows.Count <= 0)
        {
            Label2.Text = "暂无好友!";
            showMore2.Visible = false;
            return;
        }
        repFriend.DataSource = dt;
        repFriend.DataBind();
    }

    [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
    public string btnsetFriend(string uName)
    {

        UserModel = UserBll.GetUser(uName);
        if (!UserBll.IsLogin())
            return "你还未登录!请先登录";
        if (UserBll.GetCookie().LogName == UserModel.LogName)
            return "对不起，你不能添加自己为好友!";
        int flag = UserBll.AddFriend(UserBll.GetCookie().UserID, UserModel.LogName, 1);
        if (flag == 1)
            return "对不起,该用户已经是你的好友了";
        else if (flag == 2)
            return "对不起,您添加的用户不存在!"; 
        else
            return "好友添加成功!";
    }

    protected void btnSetFriend_Click(object sender, EventArgs e)
    {
        if (!UserBll.IsLogin())
            Function.ShowMsg(0, "<li>你还未登录!</li><li>请先<a href='../user/login.aspx' target='_blank'>登录</a></li><li><a href='javascript:history.back();'>返回上一级</a></li>");

        if (UserBll.GetCookie().LogName == UserModel.LogName)
            Function.ShowMsg(0, "<li>对不起，你不能添加自己为好友!</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        int flag = UserBll.AddFriend(UserBll.GetCookie().UserID, UserModel.LogName, 1);
        if (flag == 1)
            Function.ShowMsg(0, "<li>对不起,该用户已经是你的好友了!</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        else if (flag == 2)
            Function.ShowMsg(0, "<li>对不起,您添加的用户不存在!</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        else
            Function.ShowMsg(1, "<li>好友添加成功!</li><li><a href='javascript:history.back();'>返回上一级</a></li>");

    }

    protected void repAlbum()
    {
        int recordCount = 0;
        DataTable dt = AlbumBll.GetUserAlbumByUserId(UserModel.UserID, 1, 1, ref recordCount);
        if (dt.Rows.Count <= 0)
        {
            divAlbum.Visible = false; Label5.Text = "暂无相册!";
            return;
        }
        string logo = dt.Rows[0]["Logo"].ToString();
        Label3.Text = dt.Rows[0]["AlbumName"].ToString();
        if (logo == string.Empty)
            lbAlbum.Text = "<img src='../userspace/skin/images/xc.jpg' width=175px height=130px onclick=javascript:window.location.href='MyAlbum.aspx?UserName=" + UserName + "' style='cursor:hand'>";
        else
            lbAlbum.Text = "<img src='" + Param.ApplicationRootPath + "/user/upload/" + logo + "' width=175px height=130px onclick=javascript:window.location.href='MyAlbum.aspx?UserName=" + UserName + "' style='cursor:hand'>";
    }

    protected string GetAnounName(object homePage, object anounName)
    {
        return "<a href='" + Function.HtmlEncode(homePage) + "' title='主页:" + Function.HtmlEncode(homePage) + "' target='_blank'>" + Function.HtmlEncode(anounName) + "</a>";
    }

    protected string GetUrl(object id, object modeltype)
    {
        int _id = Convert.ToInt32(id);
        int _modelId = Convert.ToInt32(modeltype);
        return CreateBll.GetInfoUrl(_id, _modelId, 1);
    }

   

}
