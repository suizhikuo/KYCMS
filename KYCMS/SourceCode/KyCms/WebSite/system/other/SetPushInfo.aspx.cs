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
using System.Text;
using System.Text.RegularExpressions;
using Ky.BLL;
using Ky.Model;
using Ky.Common;

public partial class system_other_PushInfo : System.Web.UI.Page
{
    M_Ad Model = new M_Ad();
    bool IsAdd = true;
    int AdId = 0;
    B_Ad Bll = new B_Ad();
    B_AdCategory CategoryBll = new B_AdCategory();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(30);
        if (!IsPostBack)
        {
            txtOverdue.Text = DateTime.Now.AddMonths(1).ToShortDateString();
            BindCategory();
        }
        if (Request.QueryString["adid"] != null)
        {
            AdId = Function.CheckNumber(Request.QueryString["adid"]) ? int.Parse(Request.QueryString["adid"]) : 0;
            Model = Bll.GetModel(AdId);
            if (Model == null)
            {
                Response.Redirect("PushInfoList.aspx");
            }
            if (!IsPostBack)
            {
                BindOnUpdate();
            }
            IsAdd = false;
            btnSet.Text = "修改";
        }
    }
    protected void btnSet_Click(object sender, EventArgs e)
    {
        CheckInput();
        StringBuilder sb = new StringBuilder();
        #region 设置图片代码
        if (rbPic.Checked)
        {
            sb.Append("<a href=\"UpdatePushInfo.aspx?ReturnUrl=$");
            sb.Append(Server.UrlEncode(txtPicUrl.Text));
            sb.Append("$\" target=\"$");
            sb.Append(txtPicBlank.Checked ? "_blank" : "_self");
            sb.Append("$\">");
            sb.Append("<img src=\"");
            sb.Append(Param.ApplicationRootPath);
            sb.Append("/upload/Push/$");
            sb.Append(txtPicTitlePath.Text);
            sb.Append("$\" width=\"$");
            sb.Append(Function.CheckNumber(txtPicWidth.Text) ? int.Parse(txtPicWidth.Text) : 0);
            sb.Append("$px\" height=\"$");
            sb.Append(Function.CheckNumber(txtPicHeight.Text) ? int.Parse(txtPicHeight.Text) : 0);
            sb.Append("$px\"");
            sb.Append(" alt=\"$");
            sb.Append(txtPicAlt.Text);
            sb.Append("$\" border=\"0px\" />");
            sb.Append("</a>");
        }
        #endregion
        #region 设置Flash代码
        if (rbFlash.Checked)
        {
            sb.Append("<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=5,0,0,0\"");
            sb.Append(" width=\"$");
            sb.Append(Function.CheckNumber(txtFlashWidth.Text) ? int.Parse(txtFlashWidth.Text) : 0);
            sb.Append("$px\"");
            sb.Append(" height=\"$");
            sb.Append(Function.CheckNumber(txtFlashHeight.Text) ? int.Parse(txtFlashHeight.Text) : 0);
            sb.Append("$px\">");
            sb.Append("<param name=\"movie\" value=\"");
            sb.Append(Param.ApplicationRootPath);
            sb.Append("/upload/Push/$");
            sb.Append(txtFlashPath.Text);
            sb.Append("$\" />");
            sb.Append("<param name=\"quality\" value=\"high\" />");
            if (rblTransparent.SelectedValue == "transparent")
            {
                sb.Append("<param name=\"wmode\" value=\"$");
                sb.Append(rblTransparent.SelectedValue);
                sb.Append("$\" />");
            }
            sb.Append("<embed src=\"$");
            sb.Append(txtFlashPath.Text);
            sb.Append("$\"");
            sb.Append("quality=\"high\" pluginspage=\"http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash\" type=\"application/x-shockwave-flash\"");
            sb.Append(" width=\"$");
            sb.Append(Function.CheckNumber(txtFlashWidth.Text) ? int.Parse(txtFlashWidth.Text) : 0);
            sb.Append("$px\"");
            sb.Append(" height=\"$");
            sb.Append(Function.CheckNumber(txtFlashHeight.Text) ? int.Parse(txtFlashHeight.Text) : 0);
            sb.Append("$px\" /></object>");
        }
        #endregion
        #region 设置文字代码
        if (rbText.Checked)
        {
            sb.Append("<a href=\"UpdatePushInfo.aspx?ReturnUrl=$");
            sb.Append(Server.UrlEncode(txtTextLinkUrl.Text));
            sb.Append("$\" target=\"_blank\">$");
            sb.Append(txtTextTitle.Text);
            sb.Append("$</a>");
        }
        #endregion
        #region 设置代码代码
        if (rbCode.Checked)
        {
            //Regex rgx=new Regex(@"<a href=['""]http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            //MatchCollection matchs = rgx.Matches(txtCodeContent.Text);
            //if (matchs.Count > 0)
            //{
            //    string math = matchs[0].ToString();
            //    string test = math.Substring(8, 1);
            //    string url = Server.UrlEncode(math.Substring(9));
            //    string filterContent = "";
            //    if (test == "'")
            //    {
            //        filterContent = txtCodeContent.Text.Replace(math, "<a target=\"_blank\" href=\'UpdatePushInfo.aspx?ReturnUrl=$" + url + "$");
            //    }
            //    if (test == "\"")
            //    {
            //        filterContent = txtCodeContent.Text.Replace(math, "<a target=\"_blank\" href=\"UpdatePushInfo.aspx?ReturnUrl=$" + url + "$");
            //    }
            //    filterContent = filterContent.Replace("'", "\\'");
            //    sb.Append(filterContent);
            //}
            //else
            //{
            string filterContent = txtCodeContent.Text.Replace("'", "\\'");
            //sb.Append("<a target=\"_blank\" href=\"UpdatePushInfo.aspx?ReturnUrl=$$\">");
            sb.Append(filterContent);
            //sb.Append("</a>");
            //}
        }
        #endregion

        Model.Content = Server.HtmlEncode(sb.ToString());
        StringBuilder buildIdStr = new StringBuilder();
        Model.CategoryId = lstboxCategory.SelectedValue;
        int _temp = int.Parse(txtWeight.Text);
        if (_temp > 100)
        { Model.Weight = 100; }
        else if (_temp < 0)
        { Model.Weight = 0; }
        else
        { Model.Weight = _temp; }
        Model.EndTime = DateTime.Parse(txtOverdue.Text);
        Model.AdName = txtName.Text;
        int adType = 1;
        if (rbCode.Checked)
            adType = 4;
        if (rbFlash.Checked)
            adType = 2;
        if (rbPic.Checked)
            adType = 1;
        if (rbText.Checked)
            adType = 3;
        Model.AdType = adType;
        if (IsAdd)
        {
            Model.HitCount = 0;
            Bll.Add(Model);
        }
        else
        {
            Bll.Update(Model);
        }
        try
        {
            Bll.RefreshAd(lstboxCategory.SelectedValue);
        }
        catch (Exception exp)
        {
            Function.ShowSysMsg(1, "数据已更新.但在刷新JS文件时有异常发生:" + exp.Message + " 您需要手动刷新该广告所属广告位JS.</li><li><a href='other/PushCategoryList.aspx'>返回广告位列表</a></li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        Response.Redirect("PushInfoList.aspx");
    }

    /// <summary>
    /// 绑定广告位列表
    /// </summary>
    void BindCategory()
    {
        DataTable data = CategoryBll.GetList(100, 1, "IsDisabled=1").Tables[0];
        if (data.Rows.Count == 0)
        {
            Function.ShowSysMsg(0, "<li>没有可用的广告位,请先设置广告位.</li><li><a href='other/SetPushCategory.aspx'>添加广告位</a></li><li><a href='other/PushCategoryList.aspx'>广告位列表</a></li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        foreach (DataRow dr in data.Rows)
        {
            lstboxCategory.Items.Add(new ListItem(dr["CategoryName"].ToString(), dr["AdCategoryId"].ToString()));
        }
    }

    /// <summary>
    /// 在修改时绑定数据
    /// </summary>
    void BindOnUpdate()
    {
        txtName.Text = Model.AdName;
        rbCode.Checked = rbFlash.Checked = rbPic.Checked = rbText.Checked = false;
        switch (Model.AdType)
        {
            case 1:
                rbPic.Checked = true;
                break;
            case 2:
                rbFlash.Checked = true;
                break;
            case 3:
                rbText.Checked = true;
                break;
            case 4:
                rbCode.Checked = true;
                break;
        }
        #region 设置行显示
        HtmlTableRow tr1 = Page.FindControl("Tr1") as HtmlTableRow;
        HtmlTableRow tr2 = Page.FindControl("Tr2") as HtmlTableRow;
        tr1.Style.Add("display", "none");
        tr2.Style.Add("display", "none");
        if (rbPic.Checked)
        {
            Tr1.Style.Add("display", "''");
            Tr2.Style.Add("display", "''");
        }
        if (rbFlash.Checked)
        {
            Tr3.Style.Add("display", "''");
            Tr4.Style.Add("display", "''");
        }
        if (rbText.Checked)
            Tr5.Style.Add("display", "''");
        if (rbCode.Checked)
            Tr6.Style.Add("display", "''");
        #endregion


        string content = Server.HtmlDecode(Model.Content);
        #region 设置图片显示
        if (rbPic.Checked)
        {
            txtPicBlank.Checked = txtPicSelf.Checked = false;
            string[] parameters = content.Split('$');
            txtPicTitlePath.Text = parameters[5];
            if (parameters[3] == "_blank")
            {
                txtPicBlank.Checked = true;
            }
            if (parameters[3] == "_self")
            {
                txtPicSelf.Checked = true;
            }
            txtPicHeight.Text = parameters[9];
            txtPicWidth.Text = parameters[7];
            txtPicAlt.Text = parameters[11];
            txtPicUrl.Text = Server.UrlDecode(parameters[1]);
        }
        #endregion
        #region 设置Flash显示
        if (rbFlash.Checked)
        {
            string[] parameters = Model.Content.Split('$');
            txtFlashHeight.Text = parameters[3];
            txtFlashPath.Text = parameters[5];
            txtFlashWidth.Text = parameters[1];
            rblTransparent.SelectedIndex = parameters[7] == "transparent" ? 1 : 0;
        }
        #endregion
        #region 设置代码显示
        if (rbCode.Checked)
        {
            /*
             *修改时间:2008-01-11
             *作者:王晓东
             *修改原因:根据客户的要求,当广告类型为"代码"时,不进行任何处理.用户输入什么就是什么
             * 
             */

            //string[] paramerters = Model.Content.Replace("\\'", "'");//.Replace("UpdatePushInfo.aspx?ReturnUrl=", "").Split('$');
            ////string s2 = Server.UrlDecode(paramerters[1]);
            //StringBuilder sb = new StringBuilder();
            //sb.Append(Server.HtmlDecode(paramerters[0]));
            //sb.Append(Server.UrlDecode(paramerters[1]));
            //sb.Append(Server.HtmlDecode(paramerters[2]));
            //txtCodeContent.Text = sb.ToString();
            txtCodeContent.Text = content.Replace("\\'", "'");
        }
        #endregion
        #region 设置文字显示
        if (rbText.Checked)
        {
            string[] parameters = Model.Content.Split('$');
            txtTextTitle.Text = Server.HtmlDecode(parameters[3]);
            txtTextLinkUrl.Text = Server.UrlDecode(parameters[1]);
        }
        #endregion

        for (int i = 0; i < lstboxCategory.Items.Count; i++)
        {
            if (lstboxCategory.Items[i].Value == Model.CategoryId)
            { lstboxCategory.SelectedIndex = i; break; }
        }
        txtWeight.Text = Model.Weight.ToString();
        txtOverdue.Text = Model.EndTime.ToShortDateString();
    }

    /// <summary>
    /// 检查用户输入
    /// </summary>
    void CheckInput()
    {
        if (txtName.Text.Trim() == "")
        {
            Function.ShowSysMsg(0, "<li>请输入广告名称</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (!Function.CheckNumber(txtWeight.Text))
        {
            Function.ShowSysMsg(0, "<li>显示权重设置不正确,请修改.</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (lstboxCategory.SelectedIndex < 0)
        {
            Function.ShowSysMsg(0, "<li>请选择所属广告位</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (rbPic.Checked && txtPicTitlePath.Text.Trim() == "")
        {
            Function.ShowSysMsg(0, "<li>请上传图片</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (rbFlash.Checked && txtFlashPath.Text.Trim() == "")
        {
            Function.ShowSysMsg(0, "<li>请上传Flash</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        if (rbText.Checked && txtTextTitle.Text.Trim() == "")
        {
            Function.ShowSysMsg(0, "<li>请输入文字标题</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        try
        {
            DateTime.Parse(txtOverdue.Text);
        }
        catch
        {
            Function.ShowSysMsg(0, "<li>过期日期不正确,请检查.</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
    }
}
