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
using Ky.Model;
using Ky.BLL;
using Ky.BLL.CommonModel;

public partial class common_DoFee : System.Web.UI.Page
{
    int ModelId = 0;
    int InfoId = 0;
    B_InfoModel InfoModelBll = new B_InfoModel();
    B_Create CreateBll = new B_Create();
    B_User UserBll = new B_User();
    B_UserGroup UserGroupBll = new B_UserGroup();
    B_UserLog UserLogBll = new B_UserLog();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["ModelId"]))
        {
            try
            {
                ModelId = int.Parse(Request.QueryString["ModelId"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["InfoId"]))
        {
            try
            {
                InfoId = int.Parse(Request.QueryString["InfoId"]);
            }
            catch { }
        }
        if (ModelId == 0 || InfoId == 0)
        {
            Function.ShowMsg(0, "<li>扣费参数错误</li>");
        }
        M_InfoModel infoModel = InfoModelBll.GetModel(ModelId);
        if (InfoModelBll == null)
        {
            Function.ShowMsg(0, "<li>模型参数错误</li>");
        }
        string tableName = infoModel.TableName;
        DataRow dr = CreateBll.GetInfoById(tableName, InfoId);
        if (dr == null)
        {
            if (InfoModelBll == null)
            {
                Function.ShowMsg(0, "<li>内容参数错误</li>");
            }
        }
        if (!UserBll.IsLogin())
        {
            Function.ShowMsg(0, "<li>该操作需要登陆</li>");
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
        bool isPay = false;
        isPay = UserLogBll.CheckIsPay(payType, modelId, InfoId, userId, chargeHourCount, chargViewCount);
        if (isPay)
        {
            Function.ShowMsg(2, "<li>该内容无需再次付费</li>");
        }

        if (!isPay)
        {
            bool flag = UserLogBll.CheckReducePointCondition(reduceType, userId, goldNum, pointCount, userExpirtTime, dayViewCount, ref msg);
            if (!flag)
            {
                Function.ShowMsg(0, "<li>" + msg + "</li>");
            }
            else
            {
                flag = UserLogBll.ReducePoint(reduceType, pointCount, modelId, InfoId, title, userId, userExpirtTime, userName, dayViewCount);
                if (!flag)
                {
                    Function.ShowMsg(0, "<li>扣费失败</li>");
                }
                else
                {
                    string backUrl = string.Empty;
                    if(Request.UrlReferrer!=null)
                    {
                        backUrl = Request.UrlReferrer.ToString();
                    }
                    else
                    {
                        backUrl ="javascript:history.back()";
                    }
                    Function.ShowMsg(1, "<li>扣费成功</li><li><a href=\"" + backUrl + "\">返回浏览内容</a></li>");
                }
            }
        }
    }
}
