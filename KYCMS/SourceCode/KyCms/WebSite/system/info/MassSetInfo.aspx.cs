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

public partial class System_news_MassSet : System.Web.UI.Page
{
    B_Channel ChannelBll = new B_Channel();
    B_Column ColumnBll = new B_Column();
    B_InfoOper InfoOperBll = new B_InfoOper();
    B_SiteInfo SiteBll = new B_SiteInfo();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_InfoModel InfoModelBll = new B_InfoModel();
    M_InfoModel InfoModel = null;
    int ChId = -1;
    int ColId = -1;
    protected M_Channel ChannelModel = null;
    string IdStr = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(43);
        litMsg.Text = "";
        if (!string.IsNullOrEmpty(Request.QueryString["IdStr"]))
            IdStr = Request.QueryString["IdStr"];
        if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            try
            {
                ChId = int.Parse(Request.QueryString["ChId"]);
            }
            catch { }
        }
        ChannelModel = ChannelBll.GetChannel(ChId);
        if (ChannelModel == null)
        {
            Function.ShowSysMsg(0, "<li>所属频道不存在或已经被删除</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        InfoModel = InfoModelBll.GetModel(ChannelModel.ModelType);
        if (InfoModel == null)
        {
            Function.ShowSysMsg(0, "<li>所属模型不存在或已经被删除</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        if (!string.IsNullOrEmpty(Request.QueryString["ColId"]))
        {
            try
            {
                ColId = int.Parse(Request.QueryString["ColId"]);
            }
            catch { }
        }

        txtTemplatePath.Attributes.Add("readonly", "");

        if (!IsPostBack)
        {
            BindGroup();
            txtByArticleIdStr.Text = IdStr;
            BindLeft();
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
    }
    #endregion

    private void BindLeft()
    {
        DataTable dt = GetItemData(true);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lsbColumnLeft.Items.Add(new ListItem(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["Id"].ToString()));
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Flag"].ToString() == "False")
                lsbColumnLeft.Items[i].Attributes.Add("style", "color:red");
        }
    }

    private DataTable GetItemData(bool isLeft)
    {
        DataTable returnDt = new DataTable();
        returnDt.Columns.Add("Id", typeof(string));
        returnDt.Columns.Add("Name", typeof(string));
        returnDt.Columns.Add("Flag", typeof(bool));
        DataView dv = ChannelBll.GetChannelByType(ChannelModel.ModelType);
        for (int i = 0; i < dv.Count; i++)
        {
            int chId = (int)dv[i]["ChId"];
            DataTable dt = ColumnBll.GetFormatListItemByChannelId(chId);
            DataRow dr = returnDt.NewRow();
            if (isLeft)
            {
                dr["Id"] = "0";
            }
            else
            {
                dr["Id"] = "1";
            }
            dr["Name"] = dv[i]["ChName"] + "<频道>";
            dr["Flag"] = false;
            returnDt.Rows.Add(dr);
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                dr = returnDt.NewRow();
                if (isLeft)
                {
                    dr["Id"] = dt.Rows[j]["ColId"];
                }
                else
                {
                    dr["Id"] = dt.Rows[j]["ColId"];
                }
                dr["Name"] = "├┄" + dt.Rows[j]["ColName"];
                dr["Flag"] = true;
                returnDt.Rows.Add(dr);
            }
        }
        return returnDt;
    }

    protected void btnMassSet_Click(object sender, EventArgs e)
    {
        string idStr = txtByArticleIdStr.Text.Trim();
        string selectColId = "0";
        bool groupIdStrFlag = false;
        bool chargeHourCountFlag = false;
        bool chargeViewCountFlag = false;
        string groupIdStr = "";
        int hitCount = 0;
        int chargeType = 1;
        #region 指定ID
        if (rdBtnByArticleIdStr.Checked)
        {
            if (txtByArticleIdStr.Text.Trim().Length == 0)
            {
                Response.Write("<script>alert('请输入指定要批量设置的" + ChannelModel.TypeName + "ID');history.back();</script>");
                return;
            }
            else
            {
                idStr = txtByArticleIdStr.Text.Trim();
                if (idStr.IndexOf(",,") != -1)
                {
                    Response.Write("<script>alert('指定的ID输入不合法');history.back();</script>");
                    return;
                }
                string[] arrayId = idStr.Split(',');
                for (int i = 0; i < arrayId.Length; i++)
                {
                    if (arrayId[i].Length > 10)
                    {
                        Response.Write("<script>alert('指定的ID输入不合法');history.back();</script>");
                        return;
                    }
                }
                if (idStr.StartsWith(","))
                    idStr = idStr.Substring(1, idStr.Length - 1);
                if (idStr.EndsWith(","))
                    idStr = idStr.Substring(0, idStr.Length - 1);
            }
        }
        #endregion 指定ID
        #region 指定栏目
        else if (rdBtnByColumnIdStr.Checked)
        {
            selectColId = lsbColumnLeft.SelectedValue;
            if (selectColId.Length == 0)
            {
                Response.Write("<script>alert('请选择要指定" + ChannelModel.TypeName + "的栏目');history.back();</script>");
                return;
            }
            if (selectColId == "0")
            {
                Response.Write("<script>alert('指定" + ChannelModel.TypeName + "能在频道下');history.back();</script>");
                return;
            }
        }
        #endregion 指定栏目
        #region 属性设置
        #region 关键字
        string tagIdStr = string.Empty;
        string tagNameStr = string.Empty;
        if (chkBoxPropterty1.Checked)
        {
            if (tagNameStr.Length != 0)
            {
                if (tagNameStr.StartsWith("|"))
                    tagNameStr = tagNameStr.Substring(1, tagNameStr.Length - 1);
                if (tagNameStr.EndsWith("|"))
                    tagNameStr = tagNameStr.Substring(0, tagNameStr.Length - 1);
                B_Tag tagBll = new B_Tag();
                DataRow dr = tagBll.AddTagStr(tagNameStr, ChannelModel.ModelType, 0, "后台管理员");
                if (dr != null)
                {
                    tagIdStr = "|" + dr[0] + "|";
                    tagNameStr = "|" + dr[1] + "|";
                }
                else
                {
                    tagIdStr = "";
                    tagNameStr = "";
                }
            }
        }
        #endregion


        #region 关键字

        #endregion

        if (chkBoxPropterty5.Checked)
        {
            if (Request.Form["txtTemplatePath"].Trim() == "")
            {
                litMsg.Text = "<script>alert('模板路径必须选择');</script>";
                return;
            }
        }
        if (chkBoxPropterty7.Checked)
        {
            if (txtHitsCount.Text.Trim() != "")
            {
                hitCount = Convert.ToInt32(txtHitsCount.Text.Trim());
            }
        }
        if (chkBoxPropterty10.Checked)
        {
            if (txtPointCount.Text.Trim() == "")
            {
                litMsg.Text = "<script>alert('收取金币个数必须填写');</script>";
                return;
            }
        }
        if (rdBtnIsOpened.SelectedValue == "0")
        {
            groupIdStrFlag = true;
            string groupIdstr = string.Empty;
            foreach (ListItem li in chkBoxGroupIdStr.Items)
            {
                if (li.Selected)
                {
                    groupIdstr += li.Value + "|";
                }
            }
            groupIdStr = "|" + groupIdstr;
        }
        else
        {
            groupIdStr = "";
        }
        if (rdBtnChargeType2.Checked || rdBtnChargeType4.Checked || rdBtnChargeType5.Checked)
        {
            chargeHourCountFlag = true;
            if (txtChargeHourCount.Text.Trim() == "")
                txtChargeHourCount.Text = "0";
        }
        if (rdBtnChargeType3.Checked || rdBtnChargeType4.Checked || rdBtnChargeType5.Checked)
        {
            chargeViewCountFlag = true;
            if (txtChargeViewCount.Text.Trim() == "")
                txtChargeViewCount.Text = "0";
        }
        if (rdBtnChargeType1.Checked)
            chargeType = 1;
        else if (rdBtnChargeType2.Checked)
            chargeType = 2;
        else if (rdBtnChargeType3.Checked)
            chargeType = 3;
        else if (rdBtnChargeType4.Checked)
            chargeType = 4;
        else if (rdBtnChargeType5.Checked)
            chargeType = 5;
        else
            chargeType = 6;
        #endregion
        InfoOperBll.MassSetInfo(InfoModel.TableName, idStr, Convert.ToInt32(selectColId), chkBoxPropterty1.Checked, tagIdStr, tagNameStr, chkBoxPropterty4.Checked, chkBoxIsTop.Checked, chkBoxPropterty2.Checked, chkBoxIsRecommend.Checked, chkBoxPropterty3.Checked, chkBoxIsFocus.Checked, chkBoxPropterty5.Checked, txtTemplatePath.Text.Trim(), chkBoxPropterty7.Checked, hitCount, chkBoxPropterty8.Checked, Convert.ToInt32(rdBtnIsOpened.SelectedValue), groupIdStrFlag, groupIdStr, chkBoxPropterty10.Checked, Convert.ToInt32(txtPointCount.Text.Trim()), chkBoxPropterty9.Checked, chargeType, chargeHourCountFlag, Convert.ToInt32(txtChargeHourCount.Text.Trim()), chargeViewCountFlag, Convert.ToInt32(txtChargeViewCount.Text.Trim()), chkBoxPropterty6.Checked, Convert.ToInt32(rdBtnPageType.SelectedValue));
        Function.ShowSysMsg(1, "<li>批量设置成功</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
    }
}
