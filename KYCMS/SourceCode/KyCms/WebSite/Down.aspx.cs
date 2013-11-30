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
using Ky.BLL.CommonModel;
using Ky.Model;
using Ky.Common;
using System.Text.RegularExpressions;


public partial class Down : System.Web.UI.Page
{
    B_Create CreateBll = new B_Create();
    B_UserGroup UserGroupBll = new B_UserGroup();
    B_UserLog userLogBll = new B_UserLog();
    B_ViewLog viewLogBll = new B_ViewLog();
    B_User UserBll = new B_User();
    B_InfoModel InfoModelBll = new B_InfoModel();
    B_DownLoadaddress DownAddressBll = new B_DownLoadaddress();
    M_InfoModel InfoModel = null;
    B_DownLoad DownLoadBll = new B_DownLoad();
    int SId = 0;
    int AId = 0;
    int ModelId = 3;
    protected void Page_Load(object sender, EventArgs e)
    {
        DownLoadBll.ClearDownCount();
        if (!string.IsNullOrEmpty(Request.QueryString["SId"]))
        {
            try
            {
                SId = int.Parse(Request.QueryString["SId"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["AId"]))
        {
            try
            {
                AId = int.Parse(Request.QueryString["AId"]);
            }
            catch { }
        }

        DataRow adr = DownAddressBll.GetAddressPath(AId,SId);
        if (adr == null)
        {
            Function.ShowMsg(0,"<li>访问的内容不存在或已经被删除</li>");
        }
        int Id = (int)adr["downloaddataid"];
        DataRow dr = CreateBll.GetInfoById("kydownloaddata", Id);
        if (dr == null)
        {
            Function.ShowMsg(0,"<li>访问的内容不存在或已经被删除</li>");
            return;
        }
        bool server_isOpened = adr["isopened"].ToString() == string.Empty ||(bool)adr["isopened"]?true:false;
        if (!server_isOpened)
        {
            Function.ShowMsg(0,"<li>所属服务器已经被管理员禁用</li>");
            return;
        }
        InfoModel = InfoModelBll.GetModel(3);
        if (InfoModel == null)
        {
            Function.ShowMsg(0,"<li>所属内容模型不存在或已经被删除</li>");
            return;
        }

        CheckUrl();
        int chId = (int)dr["chid"];
        int colId = (int)dr["colid"];
        string title = (string)dr["title"];
        int pointCount = (int)dr["pointcount"];
        int payType = (int)dr["chargetype"];
        int isOpened = (int)dr["isopened"];
        string groupIdStr = (string)dr["groupidstr"];
        bool colIsOpened = (bool)dr["colisopened"];
        int chargeHourCount = (int)dr["chargehourcount"];
        int chargViewCount = (int)dr["chargeviewcount"];
        if (pointCount > 0 || isOpened == 0 || (isOpened == 2 && !colIsOpened))
        {
            M_User userLoginModel = UserBll.GetCookie();
            M_User userModel = UserBll.GetUser(userLoginModel.UserID);
            int userId = userModel.UserID;
            string userName = userModel.LogName;
            string userGroupId = userModel.GroupID.ToString();
            decimal goldNum = userModel.YellowBoy;
            DateTime userExpirtTime = userModel.ExpireTime;
            userLoginModel = null;
            M_UserGroup userGroupModel = UserGroupBll.GetModel(userModel.GroupID);
            string powerStr = userGroupModel.ColumnPower;
            #region 继承栏目认证
            if (isOpened == 2 && !colIsOpened)
            {
                bool isAccess = UserGroupBll.Power_ColumnPower(chId, colId, powerStr, 1);
                if (!isAccess)
                {
                    Function.ShowMsg(0,"<li>您所在的用户组无法访问该内容,请联系系统管理员</li>");
                }
            }
            #endregion

            #region 内容认证
            if (isOpened == 0 && groupIdStr.IndexOf("|" + userGroupId + "|") == -1)
            {
                Function.ShowMsg(0,"<li>您所在的用户组无法访问该内容,请联系系统管理员</li>");
            }
            #endregion

            #region 收费
            if (pointCount > 0)
            {
                int reduceType = int.Parse(UserGroupBll.Power_UserGroup("ChargingType", 0, powerStr));//重复计费方式
                int dayViewCount = int.Parse(UserGroupBll.Power_UserGroup("SmashMoney", 0, powerStr));//有效期每天最大浏览次数
                string msg = string.Empty;
                bool isPay = false;//是否付费
                isPay = userLogBll.CheckIsPay(payType, ModelId, Id, userId, chargeHourCount, chargViewCount);
                if (!isPay)
                {
                    bool flag = userLogBll.CheckReducePointCondition(reduceType, userId, goldNum, pointCount, userExpirtTime, dayViewCount, ref msg);
                    if (!flag)//不满足扣费条件
                    {
                        Function.ShowMsg(0,"<li>" + msg + "</li>");
                    }
                    else
                    {
                        //flag = userLogBll.ReducePoint(reduceType,pointCount,ModelId,Id,title,userId,userExpirtTime);
                        flag = userLogBll.ReducePoint(reduceType, pointCount, ModelId, Id, title, userId, userExpirtTime, userName, dayViewCount);
                        if (!flag)
                        {
                            Function.ShowMsg(0,"<li>扣费失败</li>");
                        }
                    }
                }
                M_ViewLog viewLogModel = new M_ViewLog();
                viewLogModel.UserId = userModel.UserID;
                viewLogModel.UserName = userModel.LogName;
                viewLogModel.ModelType = 1;
                viewLogModel.InfoId = Id;
                viewLogModel.AddTime = DateTime.Now;
                viewLogBll.Add(viewLogModel);
            }
            #endregion
            DownLoadBll.SetDownCount(Id);
            Response.Redirect(GetUrl(adr));
        }
        else
        {
            DownLoadBll.SetDownCount(Id);
            Response.Redirect(GetUrl(adr));
        }       
    }

    private string GetUrl(DataRow dr)
    {
        string serverAddress = dr["downloadserverdir"].ToString();
        string localPath = dr["addresspath"].ToString();
        if (localPath.ToLower().StartsWith("http://") || localPath.ToLower().StartsWith("https://") || localPath.ToLower().StartsWith("ftp://"))
            return localPath;
        if (serverAddress.Length == 0)
        {

                return "~/upload/" + InfoModel.UploadPath + "/" + localPath;

        }
        else
        {
            return serverAddress + localPath;
        }

    }  

    private void CheckUrl()
    {
        if (Request.UrlReferrer == null)
        {
            Function.ShowMsg(0,"<li>请勿非法盗链</li>");
        }
        string urlReferrer = Request.UrlReferrer.ToString();
        Match match1 = Regex.Match(urlReferrer,@".*?://(.*?)/.*",RegexOptions.IgnoreCase);
        Match match2 = Regex.Match(Request.Url.ToString(),@".*?://(.*?)/.*",RegexOptions.IgnoreCase);

        string referrerDomainName = match1.Groups.Count>1?match1.Groups[1].Value:string.Empty;
        string localDomainName = match2.Groups.Count>1?match2.Groups[1].Value:string.Empty;
        if (referrerDomainName.Length == 0 || referrerDomainName != localDomainName)
        {
            Function.ShowMsg(0,"<li>请勿非法盗链</li>");
        }
    }

}
