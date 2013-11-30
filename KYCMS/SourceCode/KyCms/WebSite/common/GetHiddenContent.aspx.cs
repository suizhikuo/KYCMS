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
using Ky.Common;

public partial class common_GetHiddenContent : System.Web.UI.Page
{
    B_Create CreateBll = new B_Create();
    B_UserGroup UserGroupBll = new B_UserGroup();
    B_UserLog userLogBll = new B_UserLog();
    B_ViewLog viewLogBll = new B_ViewLog();
    B_User UserBll = new B_User();

    string TableName = string.Empty;
    int InfoId = 0;
    string ParamStr = string.Empty;
    int PageIndex = 1;
    int PageCount = 0;
    public int Status = 0;
    public string HiddenContent = string.Empty;
    public string ScriptFunctoin = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (!string.IsNullOrEmpty(Request.Form["tablename"]) && !string.IsNullOrEmpty(Request.Form["paramstr"]) && !string.IsNullOrEmpty(Request.Form["id"]) & !string.IsNullOrEmpty(Request.Form["pageindex"]) && !string.IsNullOrEmpty(Request.Form["pagecount"]))
        {
            try
            {
                TableName = Request.Form["tablename"];
                ParamStr = Request.Form["paramstr"];
                InfoId = int.Parse(Request.Form["id"]);
                PageIndex = int.Parse(Request.Form["pageindex"]);
                PageCount = int.Parse(Request.Form["pagecount"]);
            }
            catch { }
        }
        if (ParamStr.Length == 0 || InfoId == 0)
        {
            return;
        }
        DataRow dr = CreateBll.GetInfoById(TableName, InfoId);
        if (!UserBll.IsLogin())
        {
            HiddenContent = CreateBll.Info_Ajax(ParamStr, dr, PageIndex, PageCount,0);
            Response.Write(HiddenContent);
            return;
        }
       
        
        int pointCount = int.Parse(dr["pointcount"].ToString());
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
        int payType = (int)dr["chargetype"];
        string title = (string)dr["title"];
        int reduceType = int.Parse(UserGroupBll.Power_UserGroup("ChargingType", 0, powerStr));//重复计费方式
        int dayViewCount = int.Parse(UserGroupBll.Power_UserGroup("SmashMoney", 0, powerStr));//有效期每天最大浏览次数
        int chargeHourCount = (int)dr["chargehourcount"];
        int chargViewCount = (int)dr["chargeviewcount"];
        int modelId = (int)dr["modelid"];
        string msg = string.Empty;
        bool isPay = false;//是否付费

        isPay = userLogBll.CheckIsPay(payType, modelId, InfoId, userId, chargeHourCount, chargViewCount);

        if (!isPay)
        {
           
            HiddenContent = CreateBll.Info_Ajax(ParamStr, dr, PageIndex, PageCount, 1);
            Response.Write(HiddenContent);
            return;
        }
        else
        {
            HiddenContent = CreateBll.Info_Ajax(ParamStr, dr, PageIndex, PageCount, 2);
            if (PageIndex == 1)
            {
                M_ViewLog viewLogModel = new M_ViewLog();
                viewLogModel.UserId = userModel.UserID;
                viewLogModel.UserName = userModel.LogName;
                viewLogModel.ModelType = modelId;
                viewLogModel.InfoId = InfoId;
                viewLogModel.AddTime = DateTime.Now;
                viewLogBll.Add(viewLogModel);
            }
            Response.Write(HiddenContent);
            return;

        }
    }
}
