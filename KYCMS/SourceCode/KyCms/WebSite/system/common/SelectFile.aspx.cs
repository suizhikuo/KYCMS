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
using System.IO;

public partial class Common_SelectFile : System.Web.UI.Page
{
    B_ViewFile Bll = new B_ViewFile();
    protected string Type = "0";
    protected string BasePath = string.Empty;
    protected string ControlId = string.Empty;
    protected string DirPath = string.Empty;
    protected string StartPath = string.Empty;
    protected string AbsPath = string.Empty;
    protected B_Admin AdminBll = new B_Admin();
    protected B_PowerGroup GroupBll = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        litMsg.Text = string.Empty;
        string dirPath = string.Empty;
        
        if (Request.QueryString["ControlId"] != null && Request.QueryString["ControlId"] != "")
        {
            ControlId = Request.QueryString["ControlId"];
        }
        if (Request.QueryString["StartPath"] != null && Request.QueryString["StartPath"] != "")
        {
            StartPath = Request.QueryString["StartPath"];
        }

        if (ControlId == "" || StartPath == "")
        {
            Response.Write("<script>alert('参数获取不正确');window.opener=null;window.close();</script>");
        }

        if (Request.QueryString["DirPath"] != null && Request.QueryString["DirPath"] != "")
        {
            DirPath = Request.QueryString["DirPath"];
        }
        else
        {
            DirPath = StartPath;
        }
        dirPath = DirPath.Replace("/", @"\");
        AbsPath = Param.SiteRootPath + dirPath;//当前的绝对路径
        //Response.Write(dirPath);
        //return;
        
        lbCurrentDirPath.Text = DirPath;//当前的相对路径
        hyperNav.Text = "返回上级目录";
        DirectoryInfo dirInfo = new DirectoryInfo(AbsPath);
        string currDirName = dirInfo.Name;//当前目录的名称
        int lastIndex = DirPath.LastIndexOf(currDirName);
        string parentDirPath = string.Empty;//父目录的名称
        if (lastIndex != -1)
        {
            parentDirPath = DirPath.Substring(0, lastIndex - 1);
        }
        hyperNav.NavigateUrl = "SelectFile.aspx?ControlId=" + Function.UrlEncode(ControlId) + "&StartPath=" + Function.UrlEncode(StartPath) + "&DirPath=" + Function.UrlEncode(parentDirPath);
        if (StartPath == DirPath)
        {
            hyperNav.NavigateUrl = "";
        }
        DataTable dt = Bll.GetFileList(AbsPath);
        repFile.DataSource = dt;
        repFile.DataBind();
    }

    protected string GetScriptStr(object path, object type,object name)
    {
        string returnStr = string.Empty;
        string newPath = path.ToString().Replace(Param.SiteRootPath,"").Replace(@"\","/");
        if (type.ToString() == "")
        {
            returnStr = "location.href(\"SelectFile.aspx?ControlId=" + Function.UrlEncode(ControlId) + "&StartPath="+Function.UrlEncode(StartPath)+"&DirPath=" + Function.UrlEncode(newPath) + "\")";
        }
        else
        {
            string tmpPath = path.ToString().Replace(Param.SiteRootPath, "").Replace(@"\", @"/");
            returnStr = "SetPath(\"" + tmpPath + "\",\"" + ControlId + "\")"; 
        }
        return returnStr;
    }

    protected string GetFileTypeIco(object type)
    {
        string fileType = type.ToString();
        string returnStr = string.Empty;
       
            switch (fileType.ToLower())
            {
                case "": returnStr = "<img src='../images/filetype/small_directory.gif'/>"; break;
                case ".txt": returnStr = "<img src='../images/filetype/small_txt.gif'/>"; break;
                case ".html": returnStr = "<img src='../images/filetype/small_html.gif'/>"; break;
                case ".htm": returnStr = "<img src='../images/filetype/small_html.gif'/>"; break;
                default: returnStr = "<img src='../images/filetype/small_unknown.gif'/>"; break;
            }
      
        return returnStr;
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        GroupBll.Power_Judge(8);
        bool flag = false;
        string localPath = fileUpload.PostedFile.FileName;
        string fileName = Path.GetFileName(localPath).ToLower();
        string extName = Path.GetExtension(localPath).ToLower();
        if (Type == "0")
        {
            foreach (string s in Param.TemplateAllowExtName)
            {
                if (extName == s)
                {
                    flag = true;
                    break;
                }
            }
        }
        if (!flag)
        {
            string alertStr = string.Empty;
            foreach (string s in Param.TemplateAllowExtName)
            {
                alertStr += s + " ";
            }
            litMsg.Text = "<script>alert('只允许上传" + alertStr + "类型的文件')</script>";
            return;
        }
        string savePath = AbsPath + @"\" + fileName;
        fileUpload.PostedFile.SaveAs(savePath);
        litMsg.Text = "<script>document.getElementById('btnRe').click();</script>";
    }
    protected void  btnCreate_Click(object sender, EventArgs e)
    {
        GroupBll.Power_Judge(8);
        string dirName = txtDirName.Text.Trim();
        if (dirName.Length == 0)
        {
            litMsg.Text = "<script>document.getElementById('btnRe').click();alert('新文件夹名称不能为空')</script>";
            return;
        }
        string createPath = AbsPath + @"\" + dirName;
        try
        {
            Directory.CreateDirectory(createPath);
            litMsg.Text = "<script>document.getElementById('btnRe').click();</script>";
        }
        catch
        {
            litMsg.Text = "<script>document.getElementById('btnRe').click();</script>";
        }
    }
}
