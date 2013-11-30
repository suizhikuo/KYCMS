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
using Ky.Common;
using Ky.BLL;
using Ky.Model;

public partial class common_UpLoadMultiPicEditor : System.Web.UI.Page
{
    private B_UpLoadPic up = new B_UpLoadPic();
    private B_SiteInfo BSiteInfo = new B_SiteInfo();
    private M_Site MSite = new M_Site();

    protected void Page_Load(object sender, EventArgs e)
    {
        Literal1.Text = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string FilePath = File_PicPath.Text;
        string[] MyFilePath = FilePath.Split(new Char[] { '|' });

        //获得站点域名
        MSite = BSiteInfo.GetSiteModel();
        string SiteUrl = MSite.Domain;

        if (File1.Value != "")
        {
            string sFilePicPath1 = "" + SiteUrl + "/upload/" + MyFilePath[0] + "/" + up.GetUpLoadPicPath(File1, "" + Param.ApplicationRootPath + "/upload/" + MyFilePath[0] + "/", WaterMark.Checked, false, 0, 0, false, 0, int.Parse(MyFilePath[1]));
            Literal1.Text="<script language=javascript>setImg('" + sFilePicPath1 + "');</script>";
        }

        if (File2.Value != "")
        {
            string sFilePicPath2 = "" + SiteUrl + "/upload/" + MyFilePath[0] + "/" + up.GetUpLoadPicPath(File2, "" + Param.ApplicationRootPath + "/upload/" + MyFilePath[0] + "/", WaterMark.Checked, false, 0, 0, false, 0, int.Parse(MyFilePath[1]));
            Literal2.Text = "<script language=javascript>setImg('" + sFilePicPath2 + "');</script>";
        }

        if (File3.Value != "")
        {
            string sFilePicPath3 = "" + SiteUrl + "/upload/" + MyFilePath[0] + "/" + up.GetUpLoadPicPath(File3, "" + Param.ApplicationRootPath + "/upload/" + MyFilePath[0] + "/", WaterMark.Checked, false, 0, 0, false, 0, int.Parse(MyFilePath[1]));
            Literal3.Text = "<script language=javascript>setImg('" + sFilePicPath3 + "');</script>";
        }

        if (File4.Value != "")
        {
            string sFilePicPath4 = "" + SiteUrl + "/upload/" + MyFilePath[0] + "/" + up.GetUpLoadPicPath(File4, "" + Param.ApplicationRootPath + "/upload/" + MyFilePath[0] + "/", WaterMark.Checked, false, 0, 0, false, 0, int.Parse(MyFilePath[1]));
            Literal4.Text = "<script language=javascript>setImg('" + sFilePicPath4 + "');</script>";
        }

        if (File5.Value != "")
        {
            string sFilePicPath5 = "" + SiteUrl + "/upload/" + MyFilePath[0] + "/" + up.GetUpLoadPicPath(File5, "" + Param.ApplicationRootPath + "/upload/" + MyFilePath[0] + "/", WaterMark.Checked, false, 0, 0, false, 0, int.Parse(MyFilePath[1]));
            Literal5.Text = "<script language=javascript>setImg('" + sFilePicPath5 + "');</script>";
        }

        if (File6.Value != "")
        {
            string sFilePicPath6 = "" + SiteUrl + "/upload/" + MyFilePath[0] + "/" + up.GetUpLoadPicPath(File6, "" + Param.ApplicationRootPath + "/upload/" + MyFilePath[0] + "/", WaterMark.Checked, false, 0, 0, false, 0, int.Parse(MyFilePath[1]));
            Literal6.Text = "<script language=javascript>setImg('" + sFilePicPath6 + "');</script>";
        }


        Literal7.Text = "<script language=javascript>window.close();</script>";

    }
}
