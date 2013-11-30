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

public partial class Info : System.Web.UI.Page
{
    B_InfoModel InfoModelBll = new B_InfoModel();
    B_InfoOper InfoOperBll = new B_InfoOper();
    B_Article ArticleBll = new B_Article();
    B_Create CreateBll = new B_Create();
    B_UserGroup UserGroupBll = new B_UserGroup();
    B_UserLog userLogBll = new B_UserLog();
    B_ViewLog viewLogBll = new B_ViewLog();
    B_User UserBll = new B_User();

    int Id = 0;
    int P = 1;
    int ModelId = 0;
    int PageSize = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
        {
            try
            {
                Id = int.Parse(Request.QueryString["Id"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["ModelId"]))
        {
            try
            {
                ModelId = int.Parse(Request.QueryString["ModelId"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["P"]))
        {
            try
            {
                P = int.Parse(Request.QueryString["P"]);
            }
            catch { }
        }
       //取得模型
        M_InfoModel infoModel = InfoModelBll.GetModel(ModelId);
        if (infoModel == null)
        {
            Function.ShowMsg(0, "<li>所属内容模型不存在或已经被删除</li>");
        }
        string tableName = infoModel.TableName;
        if(tableName.Length==0)
        {
            Function.ShowMsg(0, "<li>所属内容模型不存在或已经被删除</li>");
        }
            
        DataRow dr = CreateBll.GetInfoById(tableName,Id);
        if (dr == null)
        {
            Function.ShowMsg(0, "<li>访问的内容不存在或已经被删除</li>");
        }
        bool isChDisabled = (bool)dr["isdisabled"];
        if (isChDisabled)
        {
            Function.ShowMsg(0,"<li>所属频道已经被管理员禁用</li>");
        }
        bool isDeleted = (bool)dr["isdeleted"];
        if (isDeleted)
        {
            Function.ShowMsg(0, "<li>访问的内容不存在或已经被删除</li>");
        }
        int status = (int)dr["status"];
        if (status != 3)
        {
            Function.ShowMsg(0, "<li>访问的内容不存在或已经被删除</li>");
        }
        PageSize = CreateBll.TotalContentPageNumber(dr);
        if (ModelId == 3)
        {
            Response.Write(CreateBll.GetInfo(dr, P,  PageSize));
            return;
        }
        string outerUrl = string.Empty;
        if (ModelId == 1)
        {
            outerUrl = dr["outerurl"].ToString(); 
            if (outerUrl.Length != 0)
                Response.Redirect(outerUrl);
        }
        
        string infoUrl = CreateBll.GetInfoUrl(Id, ModelId, 1);
        if (infoUrl.ToLower().Trim().IndexOf(".htm") != -1 || infoUrl.ToLower().Trim().IndexOf(".html") != -1 || infoUrl.ToLower().Trim().IndexOf(".shtml") != -1)
        {
            Response.Redirect(infoUrl);
        }
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
        string viewUName = string.Empty;
        string viewUName2 = string.Empty;
        string viewEndTime = string.Empty;
        
        if (ModelId == 1)
        {
            viewUName = dr["viewuname"].ToString();
            viewUName2 = dr["viewuname2"].ToString();
            viewEndTime = dr["viewendtime"].ToString();
        }

        if (isOpened == 0 || (isOpened == 2 && !colIsOpened) || viewUName.Length != 0)
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
        
            #region 文章签收
            if (ModelId == 1 && viewUName.Length != 0)
            {
                if (viewUName.IndexOf("|" + userName + "|") == -1)
                {
                    Function.ShowMsg(0, "<li>该内容页只允许 " + viewUName.Replace("|", "&nbsp;&nbsp;") + "签收用户浏览</li>");
                }
                else if (viewEndTime.Length != 0 && DateTime.Parse(viewEndTime) < DateTime.Now)
                {
                    Function.ShowMsg(0, "<li>已经超过有效的签收时间</li>");
                }
                else
                {
                    string vName = string.Empty;
                    if (viewUName2.Length == 0)
                    {
                        vName = "|" + userName + "|";
                    }
                    else
                    {
                        vName = viewUName2 + userName + "|";
                    }
                    ArticleBll.SetViewState(Id, vName);
                }
            }
            #endregion

            #region 继承栏目认证
            if (isOpened == 2 && !colIsOpened)
            {
                bool isAccess = UserGroupBll.Power_ColumnPower(chId, colId, powerStr, 1);
                if (!isAccess)
                {
                    Function.ShowMsg(0, "<li>您所在的用户组无法访问该内容,请联系系统管理员</li>");
                }
            }
            #endregion

            #region 内容认证
            if (isOpened == 0 && groupIdStr.IndexOf("|" + userGroupId + "|") == -1)
            {
                Function.ShowMsg(0, "<li>您所在的用户组无法访问该内容,请联系系统管理员</li>");
            }
            #endregion

            Response.Write(CreateBll.GetInfo(dr, P, PageSize));
        }
        else
        {
            Response.Write(CreateBll.GetInfo(dr, P, PageSize));
        }
    }


}
