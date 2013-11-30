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
using System.IO;

public partial class System_website_SetSpeacils : System.Web.UI.Page
{
    B_Special special = new B_Special();
    int Key = 0;
    B_Admin admin = new B_Admin();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(3);
        txtTemplet.Attributes.Add("readonly", "readonly");
        txtPic.Attributes.Add("readonly", "readonly");
        if (!IsPostBack)
        {
            BindChannel();
            BindSpeacil();
        }
        //如果是修改专题
        if (Request.QueryString["Action"] != null && Request.QueryString["key"] != null && Request.QueryString["Action"] == "Update")
        {
            Key = Function.CheckNumber(Request.QueryString["key"]) ? int.Parse(Request.QueryString["key"]) : 0;
            if (!IsPostBack)
            {
                BindOnUpdate();
            }
        }
    }

    /// <summary>
    /// 根据专题ID获取专题信息
    /// </summary>
    /// <param name="key"></param>
    void BindOnUpdate()
    {
        M_Special model = special.GetSpecial(Key);
        if (model != null)
        {
            hyViewImg.NavigateUrl = Param.ApplicationRootPath + "/upload/special_img" + model.PicSavePath;
            hyViewImg.Target = "_blank";
            hyViewImg.Visible = true;
            btnAdd.Text = " 修 改 ";
            txtAddTime.Text = model.SpecialAddTime.ToString();
            txtIsdelete.Text = model.IsDeleted.ToString();
            txtIsdelete.Visible = false;
            txtAddTime.Visible = false;
            txtCName.Text = model.SpecialCName;
            txtEName.Text = model.SpecialEName;
            txtEName.Enabled = false;
            txtDomain.Text = model.SpecialDomain;
            txtRemark.Text = model.SpecialRemark;
            txtTemplet.Text = model.SpecialTemplet;
            ddlItemNum.SelectedIndex = model.SpecialItemNum;
            txtPic.Text = model.PicSavePath.StartsWith("/") ? model.PicSavePath.Substring(1, model.PicSavePath.Length-1) : "";
            for (int i = 0; i < rblExtension.Items.Count; i++)
            {
                if (model.Extension == rblExtension.Items[i].Value)
                {
                    rblExtension.SelectedIndex = i;
                    break;
                }
            }
            rblIsRcmd.SelectedIndex = model.IsCommand == true ? 0 : 1;
            rblIsLock.SelectedIndex = model.IsLock == true ? 0 : 1;

            //填充自设内容
            string[] contents = model.SpecialContent.Split('|');
            for (int i = 1; i < 11; i++)
            {
                TextBox ctt = (TextBox)Page.FindControl("txtItemContent" + i);
                ctt.Text = contents[i - 1];
            }

            //在修改专题时,使得不能设置专题为自己的父专题
            for (int m = 0; m < ddlSpeacil.Items.Count; m++)
            {
                if (model.ID.ToString() == ddlSpeacil.Items[m].Value)
                {
                    ddlSpeacil.Items[m].Enabled = false;
                    break;
                }
            }

            //在修改专题时,选中他的父专题
            for (int m = 0; m < ddlSpeacil.Items.Count; m++)
            {
                if (model.ParentID.ToString() == ddlSpeacil.Items[m].Value)
                {
                    ddlSpeacil.Items[m].Selected = true;
                    break;
                }
            }

            //选中专题所属频道
            for (int n = 0; n < ddlChannel.Items.Count; n++)
            {
                if (model.SiteID.ToString() == ddlChannel.Items[n].Value)
                {
                    ddlChannel.Items[n].Selected = true;
                    break;
                }
            }

            //选中专题路径
            for (int i = 0; i < ddlDirType.Items.Count; i++)
            {
                if (ddlDirType.Items[i].Value == model.SaveDirType)
                {
                    ddlDirType.Items[i].Selected = true;
                    break;
                }
            }
        }
    }

    /// <summary>
    /// 绑定频道
    /// </summary>
    void BindChannel()
    {
        B_Channel channel = new B_Channel();
        ddlChannel.DataSource = channel.GetChannelByType(0);
        ddlChannel.DataTextField = "ChName";
        ddlChannel.DataValueField = "ChId";
        ddlChannel.DataBind();
        ddlChannel.Items.Insert(0, new ListItem("设为全站专题", "0"));
    }

    /// <summary>
    /// 绑定专题
    /// </summary>
    void BindSpeacil()
    {
        //因为无论是新添加还是修改,都不能使专题的父专题为某个子专题,所以参数为 0
        ddlSpeacil.DataSource = special.GetSpecials(0);
        ddlSpeacil.DataTextField = "SpecialCName";
        ddlSpeacil.DataValueField = "ID";
        ddlSpeacil.DataBind();
        ddlSpeacil.Items.Insert(0, new ListItem("无父专题", "0"));
    }


    
    /// <summary>
    /// 添加/修改专题
    /// </summary>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        M_Special model = new M_Special();
        if (txtCName.Text.Trim() == "" || txtEName.Text.Trim() == "")
        {
            Function.ShowSysMsg(0, "<li>专题中文名和英文名不能为空</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        else
        {
            model.SpecialCName = txtCName.Text; 
            model.SpecialEName = txtEName.Text;
        }
        string content = string.Empty;
        for (int i = 1; i <= 10; i++)
        {
            TextBox ctt = (TextBox)Page.FindControl("txtItemContent" + i);
            if (ctt.Text.Trim() != "")
            {
                content += ctt.Text;
            }
            content += "|";
        }
        content = content.Substring(0, content.Length - 1);        
        model.IsCommand = rblIsRcmd.SelectedValue == "1";
        model.IsLock = rblIsLock.SelectedValue == "1";
        model.MetaKeyWord = "";
        model.MetaRemark = "";
        model.ParentID = int.Parse(ddlSpeacil.SelectedValue);
        model.SaveDirType = ddlDirType.SelectedValue;
        model.SiteID = int.Parse(ddlChannel.SelectedValue);
        model.SpecialAddTime = DateTime.Now;        
        model.SpecialDomain = txtDomain.Text;        
        B_SiteInfo site = new B_SiteInfo();
        model.SpecialRemark = site.GetFiltering(txtRemark.Text);
        model.SpecialContent = site.GetFiltering(content);
        model.SpecialItemNum = int.Parse(ddlItemNum.SelectedValue);
        model.Extension = rblExtension.SelectedValue;
        model.PicSavePath = "/" + txtPic.Text;
        if (txtTemplet.Text.Trim() == "")
        {
            Function.ShowSysMsg(0, "<li>专题模板路径不能为空</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        else
        {
            model.SpecialTemplet = txtTemplet.Text;
        }
        if (Key != 0)
        {
            model.ID = Key;
            model.SpecialAddTime = DateTime.Parse(txtAddTime.Text);
            model.IsDeleted = Boolean.Parse(txtIsdelete.Text);
            special.Update(model);
            Response.Redirect("SpecialList.aspx");
        }
        else
        {
            B_KyCommon kycomm = new B_KyCommon();
            if (kycomm.CheckHas(txtEName.Text, "SpecialEName", "KySpecial"))
            {
                Function.ShowSysMsg(0, "<li>专题英文名重复,请修改</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
            else
            {
                special.Add(model);
                Response.Redirect("SpecialList.aspx");
            }
        }
    }
}
