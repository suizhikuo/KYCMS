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
using Ky.BLL.CommonModel;

public partial class system_user_UserGroup : System.Web.UI.Page
{
    private B_Channel BChannel = new B_Channel();
    private B_Column BColumn = new B_Column();
    private B_PowerGroup Bpowergroup = new B_PowerGroup();
    private M_PowerGroup Mpowergroup = new M_PowerGroup();
    private M_UserGroup MUserGroup = new M_UserGroup();
    private B_UserGroup BUserGroup = new B_UserGroup();
    private B_UserGroupModel BUserGroupModel = new B_UserGroupModel();

    protected void Page_Load(object sender, EventArgs e)
    {
        Literal1.Text = "";
        if (!Page.IsPostBack)
        {
            Bpowergroup.Power_Judge(13);
            string TypeId = Request.QueryString["TypeId"];

            //用户注册模型
            RepUserGroupModel.DataSource = BUserGroupModel.GetAll();
            RepUserGroupModel.DataBind();

            //绑定内容管理Repeater
            DataRepeater1();
        }
    }
    private void DataRepeater1()
    {
        //新定义DataTable
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("ChId", typeof(string)));
        dt.Columns.Add(new DataColumn("Name", typeof(string)));
        dt.Columns.Add(new DataColumn("ColId", typeof(string)));
        dt.Columns.Add(new DataColumn("Depth", typeof(string)));
        dt.Columns.Add(new DataColumn("TableNum", typeof(int)));

        //获取频道
        DataTable dt1 = BChannel.GetList(false).ToTable();

        string sSelectBoxValue = "";

        for (int i = 0, t = 1; i < dt1.Rows.Count; i++, t++)
        {
            DataRow dr1 = dt.NewRow();
            dr1[0] = dt1.Rows[i]["ChId"].ToString();
            dr1[1] = dt1.Rows[i]["ChName"].ToString();
            dr1[2] = "0";
            dr1[3] = "0";
            dr1[4] = t;
            dt.Rows.Add(dr1);

            DataTable dt2 = new DataTable();
            dt2 = BColumn.GetListItemByChannelId(int.Parse(dt1.Rows[i]["ChId"].ToString()));

            for (int p = 0; p < dt2.Rows.Count; p++)
            {
                t++;
                DataRow dr2 = dt.NewRow();
                dr2[0] = dt1.Rows[i]["ChId"].ToString();
                dr2[1] = dt2.Rows[p]["ColName"].ToString();
                dr2[2] = dt2.Rows[p]["ColId"].ToString();
                dr2[3] = dt2.Rows[p]["Depth"].ToString();
                dr2[4] = t;
                dt.Rows.Add(dr2);
            }
            if (i == dt1.Rows.Count - 1)
            {
                sSelectBoxValue += dt1.Rows[i]["ChId"].ToString();
            }
            else
            {
                sSelectBoxValue += dt1.Rows[i]["ChId"].ToString() + ",";
            }
        }

        Repeater1.DataSource = dt;
        Repeater1.DataBind();

        //取除Repeater1最大行
        TableNum.Text = Repeater1.Items.Count.ToString();
    }

    /// <summary>
    /// 返回图片条件
    /// </summary>
    /// <param name="ChId"></param>
    /// <param name="ColId"></param>
    /// <param name="Depth"></param>
    /// <returns></returns>
    public string GetImgNum(int ChId, int ColId, int Depth)
    {
        if (ColId == 0) //频道
        {
            return GetImgList(1, 0, 0);
        }
        else
        {
            if (BColumn.ChkHasChildByColId(ColId))
            {
                return GetImgList(1, 0, Depth + 1);
            }
            else
            {
                return GetImgList(0, 1, Depth + 1);
            }
        }
    }

    /// <summary>
    /// 返回图片
    /// </summary>
    /// <param name="Add"></param>
    /// <param name="Del"></param>
    /// <param name="Depth"></param>
    /// <returns></returns>
    public string GetImgList(int Add, int Del, int Depth)
    {
        string sGetImgList = "";

        string AddImg = "<img src='../../images/+.gif' border=0 align='absmiddle'>";
        string DelImg = "<img src='../../images/-.gif' border=0 align='absmiddle'>";
        string DepthList = "<img src='../../images/tree_line.gif' border=0 align='absmiddle'>";

        if (Depth == 0)
        {
            sGetImgList = AddImg;
        }
        else
        {
            for (int i = 0; i < Depth; i++)
            {
                sGetImgList += DepthList;
            }

            if (Add != 0)
            {
                sGetImgList += AddImg;
            }
            else
            {
                sGetImgList += DelImg;
            }
        }

        return sGetImgList;
    }


    //保存
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sGroupPower = "";
        string TypeId = Request.QueryString["TypeId"];

        string sContribute_0 = Contribute_0.Text;
        string sCollection = Collection.Text;

        string sInvite = Invite.Text;
        string sIssueManuscript = IssueManuscript.Text;
        string sSmashMoney = SmashMoney.Text;
       
        if (!Function.CheckNumber(sContribute_0) || !Function.CheckNumber(sCollection) || !Function.CheckNumber(sInvite) || !Function.CheckNumber(sIssueManuscript) || !Function.CheckNumber(sSmashMoney))
        {
            Function.ShowSysMsg(0, "<li>所有栏目设置只能够为数字</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }

        #region 投稿
        sGroupPower += "Contribute=" + sContribute_0 + "|";
        #endregion

        #region 收藏
        sGroupPower += ",Collection=" + sCollection + "|";
        #endregion

        #region 邀请
        sGroupPower += ",Invite=" + sInvite + "|";
        #endregion

        #region 发布稿件
        sGroupPower += ",IssueManuscript=" + sIssueManuscript + "|";
        #endregion

        #region 计费方式
        sGroupPower += ",ChargingType=" + ChargingType.SelectedValue + "|";
        #endregion

        #region 扣费方式
        sGroupPower += ",SmashMoney=" + sSmashMoney + "|";
        #endregion

        #region 注册认证
        sGroupPower += ",Status=" + Status.SelectedValue + "";
        #endregion


        string sUserGroupName = UserGroupName.Text;
        string sUserGroupContent = UserGroupContent.Text;

        #region 获得栏目权限
        string sColumnPower = "";
        for (int r = 0, t = 1; r < Repeater1.Items.Count; r++, t++)
        {
            sColumnPower += "" + ((TextBox)(Repeater1).Items[r].FindControl("ChId")).Text + "@" + ((TextBox)(Repeater1).Items[r].FindControl("ColId")).Text + "=";
            for (int p = 1; p <= 3; p++)
            {
                if (Request.Form["ChIdColumnId_" + t + "_" + p + ""] == "1")
                {
                    sColumnPower += "1|";
                }
                else
                {
                    sColumnPower += "0|";
                }
            }

            //去掉最后一个","
            if (r != Repeater1.Items.Count - 1)
            {
                sColumnPower += ",";
            }
        }
        #endregion

        MUserGroup.UserGroupName = sUserGroupName;
        MUserGroup.UserGroupContent = sUserGroupContent;
        MUserGroup.TypeId = int.Parse(Request.QueryString["TypeId"]);
        MUserGroup.GroupPower = sGroupPower;
        MUserGroup.ColumnPower = sColumnPower;
        MUserGroup.IsSystem = 0;
        MUserGroup.AddDate = DateTime.Now;

        BUserGroup.Add(MUserGroup);

        Function.ShowSysMsg(1, "<li>成功新增用户组</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a> <a href='user/GroupList.aspx'>返回列表</a></li>");
    }

}
