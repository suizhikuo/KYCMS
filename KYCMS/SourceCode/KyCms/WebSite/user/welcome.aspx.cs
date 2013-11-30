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

public partial class User_Welcome : System.Web.UI.Page
{
    private B_Notice BNotice = new B_Notice();
    private B_UserGroup BUserGroup = new B_UserGroup();
    private M_UserGroup MUserGroup = new M_UserGroup();
    private B_User BUser = new B_User();
    private M_User MUser = new M_User();
    private B_SiteInfo BSiteInfo = new B_SiteInfo();
    private M_Site MSite = new M_Site();
    private B_InfoOper InfoOperBll = new B_InfoOper();
    private B_InfoModel InfoModelBll = new B_InfoModel();
    B_CustomForm BCustomForm = new B_CustomForm();
    B_UserMessage UserMessageBll = new B_UserMessage();
    B_Channel ChannelBll = new B_Channel();
    protected string MyProfile = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //登陆
            MUser = BUser.GetCookie();
            //系统公告
            rptNotice.DataSource = BNotice.GetTop(5);
            rptNotice.DataBind();

            M_User UserModel = new M_User();
            UserModel = BUser.GetUser(MUser.UserID);

            int UserId = UserModel.UserID;
            int GroupId = UserModel.GroupID;

            MUserGroup = BUserGroup.GetModel(GroupId);
            MyProfile ="SetUser.aspx";


            //系统参数
            MSite = BSiteInfo.GetSiteModel();

            int publishInfoSumCount = 0;
            int waitInfoSumCount = 0;
            DataTable dtInfo = new DataTable();
            dtInfo.Columns.Add("RowIndex", typeof(int));
            dtInfo.Columns.Add("Title", typeof(string));
            dtInfo.Columns.Add("Id", typeof(int));
            dtInfo.Columns.Add("AddTime", typeof(DateTime));
            DataTable modelDt = InfoModelBll.GetList();

            int rowIndex = 0;
            foreach (DataRow dr in modelDt.Rows)
            {
                int publishInfoCount = 0;
                int waitInfoCount = 0;
                string tableName = dr["TableName"].ToString();
                DataTable dt = InfoOperBll.GetUserInfoList(tableName, UserId, "", "", 0, "0", "-2,0,1,2,3", "", "", "", -1, 1, 5, ref publishInfoCount);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr2 = dt.Rows[i];
                    DataRow tempdr2 = dtInfo.NewRow();
                    tempdr2["RowIndex"] = rowIndex;
                    rowIndex++;
                    tempdr2["Title"] = dr2["Title"];
                    tempdr2["Id"] = dr2["Id"];
                    tempdr2["AddTime"] = dr2["AddTime"];
                    dtInfo.Rows.Add(tempdr2);
                }
                dt.Dispose();
                publishInfoSumCount += publishInfoCount;
                dt = InfoOperBll.GetUserInfoList(tableName, UserId, "", "", 0, "0", "0", "", "", "", -1, 1, 0, ref waitInfoCount);
                dt.Dispose();
                waitInfoSumCount += waitInfoCount;

            }

            DataView dv = new DataView(dtInfo);
            dv.Sort = "AddTime Desc";
            dv.RowFilter = "RowIndex<5";
            Repeater2.DataSource = dv;
            Repeater2.DataBind();
            dv.Dispose();



            //好友
            int total = 0;
            Repeater4.DataSource = BUser.ListGroupMember("KyUserFriend.UserId=" + UserId + " and FriendGroupId!=2", 5, 1, ref total);
            Repeater4.DataBind();

            DataTable cdt = new DataTable();
            cdt = BCustomForm.GetAll();

            cdt.DefaultView.RowFilter = "ShowForm=1";
            Rep_CustomForm.DataSource = cdt;
            Rep_CustomForm.DataBind();

            cdt.Clear();
            cdt.Dispose();

            //留言
            int recordCount = 0;
            DataTable mdt = UserMessageBll.GetMessageByUserId(UserModel.UserID, 1, 100000, ref recordCount);
            rptMsg.DataSource = mdt;
            rptMsg.DataBind();

            //投稿
            SetUserInfoNav();

        }
    }



    protected string SetCorpReg()
    {
        return "CorpReg.aspx?type=2&uid="+MUser.UserID;
    }

    private void SetUserInfoNav()
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

        //显示用户无法投稿信息
        if (tmpDt.DefaultView.Count == 0)
        {
            TrOnErr.Visible = true;
        }
        else
        {
            repChannel.DataSource = tmpDt.DefaultView;
            repChannel.DataBind();            
        }
        tmpDt.Dispose();
        dv.Dispose();
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
