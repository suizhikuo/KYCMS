﻿using System;
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
using Ky.Model;

public partial class common_SelectPicEditor : System.Web.UI.Page
{
    private B_UpLoadPic up = new B_UpLoadPic();
    protected string ControlId = "";
    private B_SiteInfo BSiteInfo = new B_SiteInfo();
    private M_Site MSite = new M_Site();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ControlId"] != null && Request.QueryString["ControlId"] != "")
        {
           ControlId = Request.QueryString["ControlId"];
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string FilePath = File_PicPath.Text;
        string[] MyFilePath = FilePath.Split(new Char[] { '|' });

        string SelectNewSize = Request.Form["NewSizeType"];
        bool BiLi = false;
        string sMaxWidth = "";
        string sMaxHeight = "";

        if (SelectNewSize == "1")
        {
            BiLi = true;
        }

        if (!(NewSize.Checked))
        {
            sMaxWidth = "100";
            sMaxHeight = "100";
        }
        else
        {
            sMaxWidth = MaxWidth.Text;
            sMaxHeight = MaxHeight.Text;
        }

        if (NewSize.Checked && SelectNewSize=="0")
        {
            if (!Function.CheckNumber(sMaxWidth) || !Function.CheckNumber(sMaxHeight))
            {
                litMsg.Text = "<script language='javascript'>alert('缩略图宽度和高度只能够为数字');</script>"; return;
            }
        }

        if (NewSize.Checked && SelectNewSize == "1")
        {
            if (!Function.CheckNumber(BiLiValue.Text))
            {
                litMsg.Text = "<script language='javascript'>alert('缩略图比例只能够为数字');</script>"; return;
            }
        }
        //获得站点域名
        MSite=BSiteInfo.GetSiteModel();
        string SiteUrl = MSite.Domain;

        string sFilePicPath = "" + SiteUrl + "/upload/" + MyFilePath[0] + "/" + up.GetUpLoadPicPath(File1, "" + Param.ApplicationRootPath + "/upload/" + MyFilePath[0] + "/", WaterMark.Checked, NewSize.Checked, int.Parse(sMaxWidth), int.Parse(sMaxHeight), BiLi, int.Parse(BiLiValue.Text),int.Parse(MyFilePath[1]));
        FilePicPath.Text = sFilePicPath;

        litMsg.Text = "<script>$('ImgPre').src='" + sFilePicPath + "';$('HrefImg').href='"+ sFilePicPath + "'</script>";
    }
}
