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
using System.Text;
using System.Text.RegularExpressions;

public partial class system_SetImage : System.Web.UI.Page
{
    protected B_Column ColumnBll = new B_Column();
    protected int ChannelId = 0;
    B_Admin admin = new B_Admin();
    M_LoginAdmin adminModel = null;
    protected int ImgId = 0;
    protected int ColId = 0;
    B_Img imageBll = new B_Img();
    string flag = "";
    M_Image model = null;
    protected B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected M_Admin AdminUserModel = null;
    B_Admin AdminBll = new B_Admin();
    protected M_Channel ChannelModel = null;
    B_Channel ChannelBll = new B_Channel();
    B_Create CreateBll = new B_Create();
    B_InfoModel InfoModelBll = new B_InfoModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        adminModel = admin.GetLoginModel();
        M_InfoModel infoModel = InfoModelBll.GetModel(2);
        FilePicPath.Text = infoModel.UploadPath + "|" + infoModel.UploadSize;
        AdminUserModel = AdminBll.GetModel(adminModel.UserId);
        if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            ChannelId = Function.CheckNumberNotZero(Request.QueryString["ChId"]) == true ? int.Parse(Request.QueryString["ChId"]) : 0;
        }
        if (!string.IsNullOrEmpty(Request.QueryString["ColId"]))
        {
            ColId = Function.CheckNumber(Request.QueryString["ColId"]) ? int.Parse(Request.QueryString["ColId"]) : 0;
        }
        ChannelModel = ChannelId <= 0 ? null : ChannelBll.GetChannel(ChannelId);
        if (ChannelModel == null || ChannelModel.ModelType != 2)
        {
            Function.ShowSysMsg(0,"<li>频道参数错误</li><li><a href='javascript:window.history.back();'>返回上一步</a></li>");
            return;
        }
        litNav.Text = ChannelModel.TypeName + "管理 &gt;&gt; <a href='InfoList.aspx?ChId=" + ChannelId + "'>站点" + ChannelModel.TypeName + "列表</a>&gt;&gt;设置" + ChannelModel.TypeName;
        txtTemplatePath.Attributes.Add("readonly", "readonly");

        if (!IsPostBack)
        {
            BindData();
        }

        if (Request.QueryString["ChId"] != null && Request.QueryString["ColId"] != null && Request.QueryString["Id"] != null)
        {
            ColId = Function.CheckNumber(Request.QueryString["ColId"]) == true ? int.Parse(Request.QueryString["ColId"]) : 0;
            ImgId = Function.CheckNumber(Request.QueryString["Id"]) == true ? int.Parse(Request.QueryString["Id"]) : 0;
            if (ImgId > 0 && !AdminGroupBll.Power_Channel(ChannelId, ColId, AdminUserModel.GroupId, 3))
            {
                Function.ShowSysMsg(0, "<li>你没有该栏目下的修改权限</li>");
            }
            model = imageBll.GetItem(ImgId);
            if (ChannelId > 0 && ColId > 0 && ImgId > 0 && model != null)
            {
                flag = "Update";
                if (!IsPostBack)
                {
                    BindDataOnUpdate();
                }
            }
            else
            {
                Function.ShowSysMsg(0,"<li>参数错误</li><li><a href='javascript:window.history.back();'>返回上一步</a></li>");
            }
            
        }
    }

    /// <summary>
    /// 在修改时绑定数据
    /// </summary>
    void BindDataOnUpdate()
    {
        txtTitle.Text = model.Title;
        for (int i = 0; i < ddlFontType.Items.Count; i++)
        {
            if (model.TitleFontType.ToString() == ddlFontType.Items[i].Value)
            {
                ddlFontType.SelectedIndex = i;
                break;
            }
        }
        txtHeaderColor.Text = model.TitleColor;
        if (model.TitleType == 1)
        {
            rbTextTitle.Checked = true;
        }
        if (model.TitleType == 2)
        {
           rbPicTitle.Checked = true;
           TitleImgPath.Style.Clear();
           TitleImgPath.Style.Add("style","display:''");
        }
        string[] imgArray = model.ImgPath.Split('|');
        int imgNum = 0;
        for (int i = 0; i < imgArray.Length; i++)
        {
            if (imgArray[i] != "")
            {
                imgs.Items.Add(new ListItem(imgArray[i], imgArray[i]));
                imgNum += 1;
            }
        }
        countImg.Text = imgNum.ToString();
        txtPicTitlePath.Text = model.TitleImgPath;
        txtHitCount.Text = model.HitCount.ToString();
        txtTemplatePath.Text = model.TemplatePath;
        for (int i = 0; i < 4; i++)
        {
            if (model.PageType.ToString() == rblPageType.Items[i].Value)
            {
                rblPageType.SelectedIndex = i;
                break;
            }
        }
        if (model.IsFocus)
        {
            property.Items[2].Selected = true;
        }
        if (model.IsRecommend)
        {
            property.Items[0].Selected = true;
        }
        if (model.IsTop)
        {
            property.Items[1].Selected = true;
        }
        if (model.IsSideShow)
        {
            property.Items[3].Selected = true;
        }
        if (model.IsAllowComment)
        {
            property.Items[4].Selected = true;
        }
        for (int i = 0; i < 3; i++)
        {
            if (model.IsOpened.ToString() == rblIsOpened.Items[i].Value)
            {
                rblIsOpened.SelectedIndex = i;
                break;
            }
        }
        string[] groupId = model.GroupIdStr.Split('|');
        for (int i = 0; i < groupId.Length; i++)
        {
            if (groupId[i] != "")
            {
                for (int m = 0; m < UserGroup.Items.Count; m++)
                {
                    if (groupId[i] == UserGroup.Items[m].Value)
                    {
                        UserGroup.Items[m].Selected = true;
                    }
                }
            }
        }
        string tagNameStr = model.TagNameStr; 

        //Response.End();
        if (!string.IsNullOrEmpty(tagNameStr))
        {
            if (tagNameStr.StartsWith("|") && tagNameStr.EndsWith("|"))
            {
                tagNameStr = tagNameStr.Substring(0, tagNameStr.Length - 1);
                tagNameStr = tagNameStr.Substring(1, tagNameStr.Length - 1);
            }
        }
        tagNameStr = tagNameStr.Replace("|", " ");
        txtTagNameStr.Text = tagNameStr;


        txtContent.Text = model.Content;
        string[] spclIdArray = model.SpecialIdStr.Split('|');
        for (int i = 0; i < spclIdArray.Length; i++)
        {
            if (spclIdArray[i] != "")
            {
                for (int m = 0; m < lBoxTopicIdStr.Items.Count; m++)
                {
                    if (spclIdArray[i] == lBoxTopicIdStr.Items[m].Value)
                    {
                        lBoxTopicIdStr.Items[m].Selected = true;
                    }
                }
            }
        }
        txtPointCount.Text = model.PointCount.ToString();
        for (int i = 1; i < 7; i++)
        {
            RadioButton chargeType = Page.FindControl("rdBtnChargeType" + i) as RadioButton;
            chargeType.Checked = false;
            if (model.ChargeType == i)
            {
                chargeType.Checked = true;
                break;
            }
        }

        //添加时间
        txtAddTime.Text = model.AddTime.ToString();

        txtChargeHourCount.Text = model.ChargeHourCount.ToString();
        txtChargeViewCount.Text = model.ChargeViewCount.ToString();
        btnAdd.Text = "修改";
    }

    /// <summary>
    ///绑定专题和用户组
    /// </summary>
    void BindData()
    {
        //绑定专题列表
        B_Special specialBll = new B_Special();
        DataTable dt = specialBll.GetChannelSpecial(ChannelId);
        if (dt != null)
        {
            DataView dvParent = new DataView(dt);
            dvParent.RowFilter = "ParentId=0";
            lBoxTopicIdStr.Items.Clear();
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
        }

        //绑定用户组
        B_UserGroup userGroup = new B_UserGroup();
        DataTable g = userGroup.ManageList("");
        if (g != null)
        {
            for (int i = 0; i < g.Rows.Count; i++)
            {
                UserGroup.Items.Add(new ListItem(g.Rows[i]["UserGroupName"].ToString(), g.Rows[i]["UserGroupId"].ToString()));
            }
        }
    }

    /// <summary>
    /// 添加/修改
    /// </summary>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        CheckInput();
        if (flag != "Update")//说明是新增
        {
            model = new M_Image();
            //model.AddTime = DateTime.Now;

            //添加时间
            if (txtAddTime.Text.Trim().Length != 0)
            {
                if (Function.IsDate(txtAddTime.Text.Trim().ToString()))
                    model.AddTime = DateTime.Parse(txtAddTime.Text.Trim().ToString());
                else
                    Function.ShowSysMsg(0, "<li>你输入的日期格式不对</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
            else
                model.AddTime = DateTime.Now;


            model.IsCreated = false;
            model.IsDeleted = false;
            model.Status = 3;
        }
        else
        {
            //添加时间
            if (txtAddTime.Text.Trim().Length != 0)
            {
                if (Function.IsDate(txtAddTime.Text.Trim().ToString()))
                    model.AddTime = DateTime.Parse(txtAddTime.Text.Trim().ToString());
                else
                    Function.ShowSysMsg(0, "<li>你输入的日期格式不对</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
            else
                model.AddTime = DateTime.Now;        
        }
        model.AdminUId = adminModel.UserId;
        model.AdminUName = adminModel.AdminName;
        model.ChargeHourCount = Function.CheckNumber(txtChargeHourCount.Text) == true ? int.Parse(txtChargeHourCount.Text) : 0;
        for (int i = 1; i < 7; i++)
        {
            RadioButton chargType = Page.FindControl("rdBtnChargeType" + i) as RadioButton;
            if (chargType.Checked)
            {
                model.ChargeType = i;
                break;
            }
        }
        model.ChargeViewCount = Function.CheckNumber(txtChargeViewCount.Text) == true ? int.Parse(txtChargeViewCount.Text) : 0;
        model.ColId = int.Parse(Request.Form["ddlColumn"]);
        B_SiteInfo site=new B_SiteInfo();
        model.Content = site.GetFiltering(txtContent.Text);
        string GroupId="";
        for (int i = 0; i < UserGroup.Items.Count; i++)
        {
            if (UserGroup.Items[i].Selected)
            {
                GroupId += "|"+UserGroup.Items[i].Value;
            }
        }
        model.GroupIdStr = GroupId == "" ? "" : GroupId + "|";
        model.HitCount = Function.CheckNumber(txtHitCount.Text) == true ? int.Parse(txtHitCount.Text) : 0;
        model.ImgPath = string.IsNullOrEmpty(Request.Form["imgs"]) == true ? "" : "|" + Request.Form["imgs"].Replace(",", "|") + "|";
        model.IsAllowComment = property.Items[4].Selected; 
        model.IsFocus = property.Items[2].Selected;
        model.IsOpened = int.Parse(rblIsOpened.SelectedValue);
        model.IsRecommend = property.Items[0].Selected;
        model.IsSideShow = (!rbTextTitle.Checked) && property.Items[3].Selected;
        model.IsTop = property.Items[1].Selected;
        model.PageType = rblPageType.SelectedIndex + 1;
        model.PointCount = Function.CheckNumber(txtPointCount.Text) == true ? int.Parse(txtPointCount.Text) : 0;
        string spclId = "";
        for (int i = 0; i < lBoxTopicIdStr.Items.Count; i++)
        {
            if (lBoxTopicIdStr.Items[i].Selected)
            {
                spclId += "|" + lBoxTopicIdStr.Items[i].Value + "|";
            }
        }
        model.SpecialIdStr = spclId;       
        #region 关键字
        string tagIdStr = string.Empty;
        string nameStr = txtTagNameStr.Text.Trim();
        nameStr = Regex.Replace(nameStr, @"\s+", "|", RegexOptions.IgnoreCase);
        if (nameStr.Length != 0)
        {
            if (nameStr.StartsWith("|"))
                nameStr = nameStr.Substring(1, nameStr.Length - 1);
            if (nameStr.EndsWith("|"))
                nameStr = nameStr.Substring(0, nameStr.Length - 1);
            B_Tag tagBll = new B_Tag();
            DataRow dr = tagBll.AddTagStr(nameStr, ChannelModel.ModelType, 0, "后台管理员");
            if (dr != null)
            {
                tagIdStr = "|" + dr[0] + "|";
                nameStr = "|" + dr[1] + "|";
            }
            else
            {
                tagIdStr = "";
                nameStr = "";
            }
        }
        model.TagIdStr = tagIdStr;
        model.TagNameStr = nameStr;
        #endregion
        model.TemplatePath = txtTemplatePath.Text;
        model.Title = site.GetFiltering(txtTitle.Text);
        model.TitleColor = txtHeaderColor.Text;
        model.TitleFontType = int.Parse(ddlFontType.SelectedValue);
        model.TitleImgPath = rbPicTitle.Checked ? txtPicTitlePath.Text : "";
        model.TitleType = rbTextTitle.Checked ? 1 : 2;
        model.UId = adminModel.UserId;
        model.UName = adminModel.AdminName;
        model.UpdateTime = DateTime.Now;
        model.UserType = 1;

        if (flag != "Update")
        {
            ImgId = imageBll.Add(model);

            if (property.Items[5].Selected)
            {
                DataRow dr = CreateBll.GetInfoById("kyimage", ImgId);
                CreateBll.CreateInfo(dr);
            }
            
            Response.Redirect("InfoList.aspx?ChId=" + ChannelId + "&ColId=" + Request.Form["ddlColumn"]);
        }
        else
        {
            imageBll.Update(model);
            if (property.Items[5].Selected)
            {
                DataRow dr = CreateBll.GetInfoById("kyimage", ImgId);
                CreateBll.CreateSingleInfo(dr);
            }
            Response.Redirect("InfoList.aspx?ChId=" + ChannelId + "&ColId=" + Request.Form["ddlColumn"]);
        }
    }

    private void CheckInput()
    {
        if (txtTitle.Text.Trim() == "")
        {
            Function.ShowSysMsg(0, "<li>请输入标题</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        int colId = int.Parse(Request.Form["ddlColumn"]);
        if (colId==-1)
        {
            Function.ShowSysMsg(0, "<li>请选择栏目</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        bool flag = ColumnBll.ChkHasChildByColId(colId);
        if (flag && !ColumnBll.GetColumn(colId).IsAllowAddInfo || !AdminGroupBll.Power_Channel(ChannelId, colId, AdminUserModel.GroupId, 2))
        {
            Function.ShowSysMsg(0, "<li>所选择的栏目不能添加文章</li><li><a href='info/ColumnList.aspx?ChId=3'>返回栏目列表</a></li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (rbPicTitle.Checked && txtPicTitlePath.Text.Trim() == "")
        {
            Function.ShowSysMsg(0, "<li>请选择图片标题路径</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (rdBtnChargeType2.Checked && (!Function.CheckNumber(txtChargeHourCount.Text)))
        {
            Function.ShowSysMsg(0, "<li>收费时间不正确,请修改</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (rdBtnChargeType3.Checked && (!Function.CheckNumber(txtChargeViewCount.Text)))
        {
            Function.ShowSysMsg(0, "<li>重复阅读收费不正确,请修改</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
    }
}
