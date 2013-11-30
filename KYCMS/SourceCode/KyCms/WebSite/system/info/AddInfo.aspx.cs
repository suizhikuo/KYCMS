
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
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class system_info_AddInfo : System.Web.UI.Page
{
    protected int ArticleId = 0;
    protected int ChannelId = 0;
    protected int ColumnId = 0;
    B_Channel ChannelBll = new B_Channel();
    protected B_Column ColumnBll = new B_Column();
    B_Admin AdminBll = new B_Admin();
    M_LoginAdmin AdminModel = null;
    protected M_Channel ChannelModel = null;
    protected M_Column ColumnModel = null;
    B_KyCommon KyCommonBll = new B_KyCommon();
    protected M_Site SiteModel = new M_Site();
    protected B_SiteInfo SiteBll = new B_SiteInfo();
    B_Create CreateBll = new B_Create();
    protected B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected M_Admin AdminUserModel = null;
    private B_ShowFieldStyle BShowFieldStyle = new B_ShowFieldStyle();
    private B_InfoModel BInfoModel = new B_InfoModel();
    private M_InfoModel MInfoModel = new M_InfoModel();
    protected string TableName = "";
    protected B_ModelField BModelField = new B_ModelField();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        AdminModel = AdminBll.GetLoginModel();
        AdminUserModel = AdminBll.GetModel(AdminModel.UserId);

        if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            try
            {
                ChannelId = int.Parse(Request.QueryString["ChId"]);
            }
            catch { }
        }

        ChannelModel = ChannelId <= 0 ? null : ChannelBll.GetChannel(ChannelId);
        MInfoModel = BInfoModel.GetModel(ChannelModel.ModelType);

        if (!Page.IsPostBack)
        {
            txtTemplatePath.Attributes.Add("readonly", "");


            if (!ColumnBll.ChkHasColumnByChId(ChannelId))
            {
                Function.ShowSysMsg(0, "<li>本频道下没有栏目，不能添加信息!</li><li>建议您先添加栏目</li><li><a href='info/SetColumn.aspx?ChId=" + ChannelId + "'>添加栏目</a> <a href='info/ColumnList.aspx?ChId=" + ChannelId + "'>栏目管理</a></li>");
            }

            if (!string.IsNullOrEmpty(Request.QueryString["ColId"]))
            {
                try
                {
                    ColumnId = int.Parse(Request.QueryString["ColId"]);
                }
                catch { }
            }

            litNav.Text = ChannelModel.TypeName + "管理 &gt;&gt; <a href='InfoList.aspx?ChId=" + ChannelId + "'>站点" + ChannelModel.TypeName + "列表</a> &gt;&gt; 设置" + ChannelModel.TypeName;

            //绑定自定义字段
            ModelHtml.Text = MInfoModel.ModelHtml;

            FilePicPath.Text = MInfoModel.UploadPath + "|" + MInfoModel.UploadSize.ToString();

            TableName = MInfoModel.TableName;

            BindSpeacil();
            BindGroup();
        }
    }

    #region 绑定用户组
    private void BindGroup()
    {
        B_UserGroup groupBll = new B_UserGroup();
        DataTable dt = groupBll.ManageList("");
        chkBoxGroupIdStr.DataTextField = "UserGroupName";
        chkBoxGroupIdStr.DataValueField = "UserGroupId";
        chkBoxGroupIdStr.DataSource = dt;
        chkBoxGroupIdStr.DataBind();

        dt.Clear();
        dt.Dispose();
    }
    #endregion

    /// <summary>
    /// 返回样式
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Type"></param>
    /// <param name="Content"></param>
    /// <param name="Description"></param>
    /// <returns></returns>
    public string GetShowStyle(string Name, string IsNotNull, string Type, string Content, string Description)
    {
        return BShowFieldStyle.ShowStyleField(Name, IsNotNull, Type, Content, Description,null);
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        CheckValidate();
        int sColId = int.Parse(Request.Form["ddlColId"]);

        #region 系统字段获取值
        string sTitle = txtTitle.Text;
        string sTitleColor = txtTitleColor.Text;
        string sTitleFontType = ddlTitleFontType.SelectedValue;

        int sTitleType = 1;
        if (rbImg.Checked == true)
        {
            sTitleType = 2;
        }
        string sTitleImgPath = txtTitleImgPath.Text;
        int sUId = AdminModel.UserId;
        string sUName = AdminModel.LoginName;
        string sUserType = "1";
        int sAdminUId = AdminModel.UserId;
        string sAdminUName = AdminModel.LoginName;
        int sStatus = 3;
        int sHitCount = int.Parse(txtHitCount.Text);
        DateTime sAddTime = DateTime.Now;
        DateTime sUpdateTime = DateTime.Now;
        string sTemplatePath = txtTemplatePath.Text;
        int sPageType = int.Parse(rdBtnPageType.SelectedValue);

        int sIsCreated = 0;
        if (chkBoxIsCreate.Checked)
        {
            sIsCreated = 1;
        }
        int sUserCateId = 0;
        int sPointCount = int.Parse(txtPointCount.Text);
        string rdBtnChargeType = Request.Form["ChargeType"];
        int sChargeType = 0;

        if (rdBtnChargeType == "rdBtnChargeType1")
        {
            sChargeType = 1;
        }
        else if (rdBtnChargeType == "rdBtnChargeType2")
        {
            sChargeType = 2;
        }
        else if (rdBtnChargeType == "rdBtnChargeType3")
        {
            sChargeType = 3;
        }
        else if (rdBtnChargeType == "rdBtnChargeType4")
        {
            sChargeType = 4;
        }
        else if (rdBtnChargeType == "rdBtnChargeType5")
        {
            sChargeType = 5;
        }
        else if (rdBtnChargeType == "rdBtnChargeType6")
        {
            sChargeType = 6;
        }

        int sChargeHourCount = int.Parse(txtChargeHourCount.Text);
        int sChargeViewCount = int.Parse(txtChargeViewCount.Text);
        int sIsOpened = int.Parse(rdBtnIsOpened.SelectedValue);

        string sGroupIdStr = "";

        if (sIsOpened == 0)
        {
            sGroupIdStr = "|";
            foreach (ListItem li in chkBoxGroupIdStr.Items)
            {
                if (li.Selected)
                {
                    sGroupIdStr += li.Value + "|";
                }
            }
        }

        int sIsDeleted = 0;

        int sIsRecommend = 0;
        if (chkBoxIsRecommend.Checked)
        {
            sIsRecommend = 1;
        }

        int sIsTop = 0;
        if (chkBoxIsTop.Checked)
        {
            sIsTop = 1;
        }

        int sIsFocus = 0;
        if (chkBoxIsFocus.Checked)
        {
            sIsFocus = 1;
        }

        int sIsSideShow = 0;
        if (chkBoxIsSideShow.Checked)
        {
            sIsSideShow = 1;
        }

        #region 关键字
        string sTagIdStr = string.Empty;
        string sTagNameStr = txtTagNameStr.Text.Trim();
        sTagNameStr = Regex.Replace(sTagNameStr, @"\s+", "|", RegexOptions.IgnoreCase);
        if (sTagNameStr.Length != 0)
        {
            if (sTagNameStr.StartsWith("|"))
                sTagNameStr = sTagNameStr.Substring(1, sTagNameStr.Length - 1);
            if (sTagNameStr.EndsWith("|"))
                sTagNameStr = sTagNameStr.Substring(0, sTagNameStr.Length - 1);
            B_Tag tagBll = new B_Tag();
            DataRow dr = tagBll.AddTagStr(sTagNameStr, ChannelModel.ModelType, 0, "后台管理员");
            if (dr != null)
            {
                sTagIdStr = "|" + dr[0] + "|";
                sTagNameStr = "|" + dr[1] + "|";
            }
            else
            {
                sTagIdStr = "";
                sTagNameStr = "";
            }
        }
        #endregion

        int sIsAllowComment = 0;
        if (chkBoxIsAllowComment.Checked)
        {
            sIsAllowComment = 1;
        }

        string idStr = "";
        string sSpecialIdStr = "";
        for (int i = 0; i < lBoxTopicIdStr.Items.Count; i++)
        {
            if (lBoxTopicIdStr.Items[i].Selected)
            {
                idStr += lBoxTopicIdStr.Items[i].Value + "|";
            }
        }
        if (idStr != "")
        {
            sSpecialIdStr = "|" + idStr;
        }

        //if (sIsCreated)
        //{
        //}
        #endregion

        //定义DataTable
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("FieldName", typeof(string)));
        dt.Columns.Add(new DataColumn("FieldValue", typeof(string)));

        #region
        DataRow dr0 = dt.NewRow();
        dr0[0] = "ColId";
        dr0[1] = sColId;
        dt.Rows.Add(dr0);

        DataRow dr1 = dt.NewRow();
        dr1[0] = "Title";
        dr1[1] = sTitle;
        dt.Rows.Add(dr1);

        DataRow dr2 = dt.NewRow();
        dr2[0] = "TitleColor";
        dr2[1] = sTitleColor;
        dt.Rows.Add(dr2);

        DataRow dr3 = dt.NewRow();
        dr3[0] = "TitleFontType";
        dr3[1] = sTitleFontType;
        dt.Rows.Add(dr3);

        DataRow dr4 = dt.NewRow();
        dr4[0] = "TitleType";
        dr4[1] = sTitleType;
        dt.Rows.Add(dr4);

        DataRow dr5 = dt.NewRow();
        dr5[0] = "TitleImgPath";
        dr5[1] = sTitleImgPath;
        dt.Rows.Add(dr5);

        DataRow dr6 = dt.NewRow();
        dr6[0] = "UId";
        dr6[1] = sUId;
        dt.Rows.Add(dr6);

        DataRow dr7 = dt.NewRow();
        dr7[0] = "UName";
        dr7[1] = sUName;
        dt.Rows.Add(dr7);

        DataRow dr8 = dt.NewRow();
        dr8[0] = "UserType";
        dr8[1] = sUserType;
        dt.Rows.Add(dr8);

        DataRow dr9 = dt.NewRow();
        dr9[0] = "AdminUId";
        dr9[1] = sAdminUId;
        dt.Rows.Add(dr9);

        DataRow dr10 = dt.NewRow();
        dr10[0] = "AdminUName";
        dr10[1] = sAdminUName;
        dt.Rows.Add(dr10);

        DataRow dr11 = dt.NewRow();
        dr11[0] = "Status";
        dr11[1] = sStatus;
        dt.Rows.Add(dr11);

        DataRow dr12 = dt.NewRow();
        dr12[0] = "HitCount";
        dr12[1] = sHitCount;
        dt.Rows.Add(dr12);

        DataRow dr13 = dt.NewRow();
        dr13[0] = "AddTime";
        dr13[1] = sAddTime;
        dt.Rows.Add(dr13);

        DataRow dr14 = dt.NewRow();
        dr14[0] = "UpdateTime";
        dr14[1] = sUpdateTime;
        dt.Rows.Add(dr14);

        DataRow dr15 = dt.NewRow();
        dr15[0] = "TemplatePath";
        dr15[1] = sTemplatePath;
        dt.Rows.Add(dr15);

        DataRow dr16 = dt.NewRow();
        dr16[0] = "PageType";
        dr16[1] = sPageType;
        dt.Rows.Add(dr16);

        DataRow dr17 = dt.NewRow();
        dr17[0] = "IsCreated";
        dr17[1] = sIsCreated;
        dt.Rows.Add(dr17);

        DataRow dr18 = dt.NewRow();
        dr18[0] = "UserCateId";
        dr18[1] = sUserCateId;
        dt.Rows.Add(dr18);

        DataRow dr19 = dt.NewRow();
        dr19[0] = "PointCount";
        dr19[1] = sPointCount;
        dt.Rows.Add(dr19);

        DataRow dr20 = dt.NewRow();
        dr20[0] = "ChargeType";
        dr20[1] = sChargeType;
        dt.Rows.Add(dr20);

        DataRow dr21 = dt.NewRow();
        dr21[0] = "ChargeHourCount";
        dr21[1] = sChargeHourCount;
        dt.Rows.Add(dr21);

        DataRow dr22 = dt.NewRow();
        dr22[0] = "ChargeViewCount";
        dr22[1] = sChargeViewCount;
        dt.Rows.Add(dr22);

        DataRow dr23 = dt.NewRow();
        dr23[0] = "IsOpened";
        dr23[1] = sIsOpened;
        dt.Rows.Add(dr23);

        DataRow dr24 = dt.NewRow();
        dr24[0] = "GroupIdStr";
        dr24[1] = sGroupIdStr;
        dt.Rows.Add(dr24);

        DataRow dr25 = dt.NewRow();
        dr25[0] = "IsDeleted";
        dr25[1] = sIsDeleted;
        dt.Rows.Add(dr25);

        DataRow dr26 = dt.NewRow();
        dr26[0] = "IsRecommend";
        dr26[1] = sIsRecommend;
        dt.Rows.Add(dr26);

        DataRow dr27 = dt.NewRow();
        dr27[0] = "IsTop";
        dr27[1] = sIsTop;
        dt.Rows.Add(dr27);

        DataRow dr28 = dt.NewRow();
        dr28[0] = "IsFocus";
        dr28[1] = sIsFocus;
        dt.Rows.Add(dr28);

        DataRow dr29 = dt.NewRow();
        dr29[0] = "IsSideShow";
        dr29[1] = sIsSideShow;
        dt.Rows.Add(dr29);

        DataRow dr30 = dt.NewRow();
        dr30[0] = "TagIdStr";
        dr30[1] = sTagIdStr;
        dt.Rows.Add(dr30);

        DataRow dr31 = dt.NewRow();
        dr31[0] = "TagNameStr";
        dr31[1] = sTagNameStr;
        dt.Rows.Add(dr31);

        DataRow dr32 = dt.NewRow();
        dr32[0] = "IsAllowComment";
        dr32[1] = sIsAllowComment;
        dt.Rows.Add(dr32);

        DataRow dr33 = dt.NewRow();
        dr33[0] = "SpecialIdStr";
        dr33[1] = sSpecialIdStr;
        dt.Rows.Add(dr33);
        #endregion

        //以下是自动添加字段获得值
        DataTable dt1 = new DataTable();
        dt1 = BModelField.GetList(ChannelModel.ModelType);

        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = dt1.Rows[i]["Name"].ToString();

            //联动获取数据开始
            //二级联动
            if (dt1.Rows[i]["Type"].ToString() == "ErLinkageType")
            {
                dr[1] = Request.Form["txt_" + dt1.Rows[i]["Name"].ToString()];
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr[0] = dt1.Rows[i]["Name"].ToString() + "_Id";
                dr[1] = Request.Form["txt_" + dt1.Rows[i]["Name"].ToString()+"_Id"];
                dt.Rows.Add(dr);

                string SmallName=BModelField.GetFieldContent(dt1.Rows[i]["Content"].ToString(), 2, 1);
                dr = dt.NewRow();
                dr[0] = SmallName;
                dr[1] = Request.Form["txt_" + SmallName];
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr[0] = SmallName+"_Id";
                dr[1] = Request.Form["txt_" + SmallName+"_Id"];
                dt.Rows.Add(dr);  
            }
            else
            {
                switch (dt1.Rows[i]["Type"].ToString())
                {
                    case "ListBoxType":
                        if (Request.Form["txt_" + dt1.Rows[i]["Name"].ToString() + ""] == "" || Request.Form["txt_" + dt1.Rows[i]["Name"].ToString() + ""] == null)
                        {
                            dr[1] = Request.Form["txt_" + dt1.Rows[i]["Name"].ToString() + ""];
                        }
                        else
                        {
                            dr[1] = Request.Form["txt_" + dt1.Rows[i]["Name"].ToString() + ""].Replace(" ", "").ToString();
                        }
                        dr[1] = "," + dr[1] + ",";
                        break;
                    case "MultipleTextType":
                        dr[1] = Request.Form["txt_" + dt1.Rows[i]["Name"].ToString() + ""];
                        break;
                    default:
                        dr[1] = Request.Form["txt_" + dt1.Rows[i]["Name"].ToString() + ""];
                        break;
                }
                dt.Rows.Add(dr);
            }
        }

        //添加信息
        int infoId = BInfoModel.AddInfoModel(dt, MInfoModel.TableName);
        if (sIsCreated == 1)
        {
            DataRow dr = CreateBll.GetInfoById(MInfoModel.TableName, infoId);
            CreateBll.CreateSingleInfo(dr);
        }


        Function.ShowSysMsg(1, "<li>成功添加信息</li><li><a href='info/InfoList.aspx?ChId=" + ChannelId + "&ColId=" + sColId + "'>返回信息列表</a> <a href='info/AddInfo.aspx?ChId=" + ChannelId + "&ColId=" + sColId + "'>继续添加</a></li>");
    }



    #region  绑定专题
    public void BindSpeacil()
    {
        B_Special specialBll = new B_Special();
        lBoxTopicIdStr.Items.Clear();
        DataTable dt = specialBll.GetChannelSpecial(ChannelId);
        DataView dvParent = new DataView(dt);
        dvParent.RowFilter = "ParentId=0";
        for (int i = 0; i < dvParent.Count; i++)
        {
            int parentId = Convert.ToInt32(dvParent[i]["Id"]);
            lBoxTopicIdStr.Items.Add(new ListItem(dvParent[i]["SpecialCName"].ToString(), parentId.ToString()));
            DataView dvChild = new DataView(dt);
            dvChild.RowFilter = "ParentId=" + parentId;
            for (int j = 0; j < dvChild.Count; j++)
            {
                lBoxTopicIdStr.Items.Add(new ListItem("└" + dvChild[j]["SpecialCName"], dvChild[j]["Id"].ToString()));
            }
        }

        dt.Clear();
        dt.Dispose();
    }

    #endregion

    #region  验证文本框输入是否合法
    private bool CheckValidate()
    {
        const string numPattern = @"\d+$";
        
        //判断所选栏目是否允许添加文章
        int colId = int.Parse(Request.Form["ddlColId"]); 
        if (colId == 0)
        {
            Function.ShowSysMsg(0, "<li>请选择栏目</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        bool flag = ColumnBll.ChkHasChildByColId(colId);

        if (flag && !ColumnBll.GetColumn(colId).IsAllowAddInfo|| !AdminGroupBll.Power_Channel(ChannelId, colId, AdminUserModel.GroupId, 2))
        {
            Function.ShowSysMsg(0, "<li>所选择的栏目不能添加文章！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }

        if (!AdminGroupBll.Power_Channel(ChannelId, int.Parse(Request.Form["ddlColId"]), AdminUserModel.GroupId, 2))
        {
            Function.ShowSysMsg(0, "<li>你无权添加本栏目下信息！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }

        if (txtTitle.Text.Trim() == "")
        {
            Function.ShowSysMsg(0, "<li>该标题必须填写！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        if (rbImg.Checked)
        {
            if (Request.Form["txtTitleImgPath"].Trim() == "")
            {
                Function.ShowSysMsg(0, "<li>图片地址必须填写！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
        }

        //点击数
        if (txtHitCount.Text.Trim() == "")
        {
            Function.ShowSysMsg(0, "<li>点击数必须填写！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        if (Regex.IsMatch(txtHitCount.Text.Trim(), numPattern))
        {
            if (int.Parse(txtHitCount.Text.Trim()) < 0)
            {
                Function.ShowSysMsg(0, "<li>点击数必须为非负数！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
        }
        else
        {
            Function.ShowSysMsg(0, "<li>点击数必须为非负数！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }

        if (Request.Form["txtTemplatePath"].Trim() == "")
        {
            Function.ShowSysMsg(0, "<li>模板路径必须填写！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }

        // 重复收费方式
        if (rdBtnChargeType2.Checked)
        {
            if (txtChargeHourCount.Text.Trim() == "")
            {
                Function.ShowSysMsg(0, "<li>请输入距离上次收费时间！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
            if (Regex.IsMatch(txtChargeHourCount.Text.Trim(), numPattern))
            {
                if (int.Parse(txtChargeHourCount.Text.Trim()) < 0)
                {
                    Function.ShowSysMsg(0, "<li>请正确输入'距离上次收费时间后重新收费的小时数！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                }
            }
            else
            {
                Function.ShowSysMsg(0, "<li>请正确输入'距离上次收费时间后重新收费的小时数！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
        }
        if (rdBtnChargeType3.Checked)
        {
            if (txtChargeViewCount.Text.Trim() == "")
            {
                Function.ShowSysMsg(0, "<li>请输入会员重复阅读此文章后重新收费次数！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
            if (Regex.IsMatch(txtChargeViewCount.Text.Trim(), numPattern))
            {
                if (int.Parse(txtChargeViewCount.Text.Trim()) < 0)
                {
                    Function.ShowSysMsg(0, "<li>请正确输入'会员重复阅读此文章后重新收费次数'！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                }
            }
            else
            {
                Function.ShowSysMsg(0, "<li>请正确输入'会员重复阅读此文章后重新收费次数'！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
        }

        //验证自定义字段
        DataTable dt = new DataTable();
        dt = BModelField.GetList(ChannelModel.ModelType);

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["IsNotNull"].ToString() == "True")
                {
                    if (Request.Form["txt_" + dt.Rows[i]["Name"].ToString()] == "")
                    {
                        Function.ShowSysMsg(0, "<li>"+dt.Rows[i]["Alias"].ToString()+"不能够为空！</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                    }
                }

                if (dt.Rows[i]["Type"].ToString() == "NumberType" && dt.Rows[i]["IsNotNull"].ToString() == "True")
                {
                    if (!Function.CheckNumber(Request.Form["txt_" + dt.Rows[i]["Name"].ToString()]))
                    {
                        Function.ShowMsg(0, "<li>" + dt.Rows[i]["Alias"].ToString() + "只能够是数字</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                    }
                }
            }
        }

        dt.Clear();
        dt.Dispose();

        return true;
    }
    #endregion

}

