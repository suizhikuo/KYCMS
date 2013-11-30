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
using Ky.Model;
using Ky.BLL;
using Ky.BLL.CommonModel;
using Ky.Common;

public partial class Users_Main : System.Web.UI.Page
{
    protected string SiteIndex = "Index.aspx";
    protected string MyProfile = "";
    protected string UserName = "";
    B_Create CreateBll = new B_Create();
    B_User UserBll = new B_User();
    protected M_User userModel = new M_User();
    B_Channel ChannelBll = new B_Channel();
    private B_UserGroup BUserGroup = new B_UserGroup();
    private M_UserGroup MUserGroup = new M_UserGroup();
    protected DataRow dr;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();   
        SiteIndex = CreateBll.GetIndexUrl();
        userModel = UserBll.GetUser(UserBll.GetCookie().UserID);
        MUserGroup = BUserGroup.GetModel(userModel.GroupID);
        if (userModel != null)
        {
            MyProfile = "SetUser.aspx";
        }

        dr = UserBll.GetUserAllInfo(userModel.UserID);

        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        const int type = 3;
        DataTable tmpDt = new DataTable();
        tmpDt.Columns.Add("ChId", typeof(int));
        tmpDt.Columns.Add("ChName", typeof(string));
        tmpDt.Columns.Add("ModelType", typeof(int));

        DataView dv = ChannelBll.GetList(false);
        for (int i = 0; i < dv.Count; i++)
        {
            int chId = (int)dv[i]["ChId"];
            int modelType = (int)dv[i]["ModelType"];
            if (modelType == 2)
            {
                continue;
            }
            bool flag = BUserGroup.Power_ColumnPower(chId, 0, MUserGroup.ColumnPower, type);
            if (flag)
            {
                DataRow tdr = tmpDt.NewRow();
                tdr["ChId"] = dv[i]["ChId"];
                tdr["ChName"] = dv[i]["ChName"];
                tdr["ModelType"] = dv[i]["ModelType"];
                tmpDt.Rows.Add(tdr);
            }
        }
        //显示无法投稿
        if (tmpDt.DefaultView.Count == 0)
        { OnErr.Visible = true; }
        else
        {
            repChannel.DataSource = tmpDt.DefaultView;
            repChannel.DataBind();
        }
        tmpDt.Dispose();
        dv.Dispose();
    }

    protected string GetSpaceUrl()
    {
        if (dr != null)
        {
            int userSpaceTypeId = int.Parse(dr["spacetypeid"].ToString());
            switch (userSpaceTypeId)
            {
                default:
                case 1:
                    return "../userspace/MyInfoList.aspx?UserName=" + Function.UrlEncode(userModel.LogName);
                case 2:
                    return "../userspace/enterprisespace/index.aspx?UId=" + userModel.UserID;
            }
        }
        else
        {
            return string.Empty;
        }
    }

    protected string GetInfoUrl(object modelId, object chId)
    {
        int tModelId = (int)modelId;
        int tChId = (int)chId;
        if (tModelId == 2)
        {
            return "#";
        }
        else
        {
            switch (tModelId)
            {
                default:
                    return "AddInfo.aspx?ChId=" + tChId;
                case 1:
                    return "SetArticle.aspx?ChId=" + tChId;
                case 3:
                    return "SetDownLoad.aspx?ChId=" + tChId;
            }
        }
    }
}
