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
using System.IO;
using Ky.BLL;
using Ky.Model;
using System.Text.RegularExpressions;

public partial class System_TemplateList_CreateFolder : System.Web.UI.Page
{

    #region 定义变量
    protected string DirPath = string.Empty;
    protected string Type = "0";
    public string AbsPath = string.Empty;
    protected B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected string rePath = string.Empty;
    #endregion


    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {           
           
        AdminGroupBll.Power_Judge(8);
        string pathstr;
        if (Request.QueryString["DirPath"]==null)
        {
            AbsPath = Server.MapPath("../../Template/");
        }
        else
        {
            DirPath = Request.QueryString["DirPath"];
            pathstr = DirPath.Replace("/", @"\");
            AbsPath = @Server.MapPath("../../Template/").Replace(@"\Template\", "") + pathstr;        
        }

        try
        {
            HttpContext.Current.Session["filePath"] = AbsPath;
            rePath = AbsPath;
            DataTable dt = GetFileList(AbsPath);
            repFile.DataSource = dt;
            repFile.DataBind();
            Page.DataBind();
        }
        catch(Exception cxe)
        { string a = cxe.Message; }
    }
    #endregion

    #region 创建目录
    protected void btnCreateFolder_Click(object sender, EventArgs e)
    {
        string patt = @"^[a-zA-Z0-9_\w]+$";
        if (!Regex.IsMatch(txtForderName.Text.Trim(), patt, RegexOptions.IgnoreCase))
        {
            Function.ShowSysMsg(0, "<li>创建目录失败</li><li>目录名称只能由数字、字母、下划线组成</li><li><a href='javascript:window.history.back(-1)'>返回上一页</a></li>");
        }
        string path = HttpContext.Current.Session["filePath"] + @"\" + txtForderName.Text.Trim();
        try
        {
            Directory.CreateDirectory(path);
        }
        catch
        {
            Response.Write("<Script>alert('创建目录失败!');</script>");
        }
        if (Request.QueryString["DirPath"] == null)
            Response.Redirect("CreateFolder.aspx");
        else
            Response.Redirect("CreateFolder.aspx?DirPath=" + Request.QueryString["DirPath"]);
    }
    #endregion

    #region 创建文件表操作结构
    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Path", typeof(string));
        dt.Columns.Add("UpdateTime", typeof(string));
        dt.Columns.Add("Type", typeof(string));
        dt.Columns.Add("Size",typeof(Int64));
        return dt;
    }
    #endregion

    #region 给文件表赋值并返回
    public DataTable GetFileList(string dirPath)
    {
        DataTable dt = CreateDataTable();
        string[] ArrayDir = Directory.GetDirectories(dirPath);
        string[] ArrayFile = Directory.GetFiles(dirPath);
        
        foreach (string s in ArrayDir)
        {
            DirectoryInfo dir = new DirectoryInfo(s);
            DataRow dr = dt.NewRow();
            dr["Name"] = dir.Name;
            dr["Path"] = s;
            dr["UpdateTime"] = dir.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            dr["Type"] = "";
            dr["Size"] = DirSize(dir);
            dt.Rows.Add(dr);
            dir = null;
        }

        foreach (string s in ArrayFile)
        {
            DirectoryInfo dir = new DirectoryInfo(s);
            FileInfo file = new FileInfo(s);
            DataRow dr = dt.NewRow();
            dr["Name"] = file.Name;
            dr["Path"] = s;
            dr["UpdateTime"] = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            dr["Type"] = Path.GetExtension(s).ToLower();
            dr["Size"] = file.Length;
            dt.Rows.Add(dr);
            file = null;
        }
        return dt;
    }
    #endregion

    #region 计算目录的大小
    private  long DirSize(DirectoryInfo d)
    {
        long Size = 0;
        // Add file sizes.
        FileInfo[] fis = d.GetFiles();
        foreach (FileInfo fi in fis)
        {
            Size += fi.Length;
        }
        // Add subdirectory sizes.
        DirectoryInfo[] dis = d.GetDirectories();
        foreach (DirectoryInfo di in dis)
        {
            Size += DirSize(di);
        }
        return (Size);
    }
    #endregion

    #region 获得文件类型
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
            case ".config": returnStr = "<img src='../images/filetype/small_html.gif'/>"; break;
            case ".Config": returnStr = "<img src='../images/filetype/small_html.gif'/>"; break;
            case ".Css": returnStr = "<img src='../images/filetype/small_html.gif'/>"; break;
            case ".css": returnStr = "<img src='../images/filetype/small_html.gif'/>"; break;
            default: returnStr = "<img src='../images/filetype/small_unknown.gif'/>"; break;
        }

        return returnStr;
    }
    #endregion

    #region 返回文所在的路径
    protected string GetScriptStr(object path, object type, object name)
    {
        string returnStr = string.Empty;
        string newPath = path.ToString().Replace(Param.SiteRootPath, "").Replace(@"\", "/");
        if (type.ToString() == "")
        {
            returnStr = "location.href(\"CreateFolder.aspx?DirPath=" + Function.UrlEncode(newPath) + "\")";
        }
        return returnStr;
    }
    #endregion

    #region 删除
    protected void repFileReName_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        

        Label lblFileName = (Label)e.Item.FindControl("lblFileName");
        string delPath = HttpContext.Current.Session["filePath"] + @"\" + lblFileName.Text;
        if (Path.GetExtension(delPath) == "")
        {
            try
            {
                Directory.Delete(delPath, true);
            }
            catch { }
        }
        else
        {
            File.Delete(delPath);
        }
        
        if (Request.QueryString["DirPath"] == null)
            Response.Redirect("CreateFolder.aspx");
        else
            Response.Redirect("CreateFolder.aspx?DirPath=" + Request.QueryString["DirPath"]);
    }
    #endregion

    #region 删除文件夹下的所有文件
    public void DeleteFolder(string dir)
    {
        
        foreach (string d in Directory.GetFileSystemEntries(dir))
        {
            if (File.Exists(d))
                File.Delete(d);//直接删除其中的文件   
            else
                DeleteFolder(d);//递归删除子文件夹   
        }
        Directory.Delete(dir);//删除已空文件夹
       
    }
    #endregion

    #region 
    public string GetFileType(object type,object name)
    {
        string fileType = type.ToString();
        string filepath = HttpContext.Current.Session["filePath"] + @"\" + name.ToString();
        string returnStr = string.Empty;
        if (Request.QueryString["DirPath"] == "" || Request.QueryString["DirPath"] == null)
        {
            switch (fileType.ToLower())
            {
                case ".html": returnStr = " | <a href=TemplateTextEdit.aspx?filePath=" + Server.UrlEncode(filepath) + ">文本编辑</a> | <a href='TemplateHtmlEdit.aspx?filePath=" + Server.UrlEncode(filepath) + "'>HTML编辑</a> | " + "<a href=../../Template/" + name.ToString() + " target=\"_blank\">预览</a>"; break;
                case ".htm": returnStr = " | <a href=TemplateTextEdit.aspx?filePath=" + Server.UrlEncode(filepath) + ">文本编辑</a>  | <a href='TemplateHtmlEdit.aspx?filePath=" + Server.UrlEncode(filepath) + "'>HTML编辑</a> | " + "<a href=../../Template/" + name.ToString() + " target=\"_blank\">预览</a>"; break;
                case ".Config": returnStr = " | <a href=TemplateTextEdit.aspx?filePath=" + Server.UrlEncode(filepath) + ">文本编辑</a> | <a href='TemplateHtmlEdit.aspx?filePath=" + Server.UrlEncode(filepath) + "'>HTML编辑</a> | " + "<a href=../../Template/" + name.ToString() + " target=\"_blank\">预览</a>"; break;
                case ".config": returnStr = " | <a href=TemplateTextEdit.aspx?filePath=" + Server.UrlEncode(filepath) + ">文本编辑</a> | <a href='TemplateHtmlEdit.aspx?filePath=" + Server.UrlEncode(filepath) + "'>HTML编辑</a> | " + "<a href=../../Template/" + name.ToString() + " target=\"_blank\">预览</a>"; break;
                case ".Css": returnStr = " | <a href=TemplateTextEdit.aspx?filePath=" + Server.UrlEncode(filepath) + ">文本编辑</a> | " + "<a href=../../Template/" + name.ToString() + " target=\"_blank\">预览</a>"; break;
                case ".css": returnStr = " | <a href=TemplateTextEdit.aspx?filePath=" + Server.UrlEncode(filepath) + ">文本编辑</a> | " + "<a href=../../Template/" + name.ToString() + " target=\"_blank\">预览</a>"; break;
            }
        }
        else
        {
            switch (fileType.ToLower())
            {
                case ".html": returnStr = " | <a href=TemplateTextEdit.aspx?filePath=" + Server.UrlEncode(filepath) + ">文本编辑</a> | <a href='TemplateHtmlEdit.aspx?filePath=" + Server.UrlEncode(filepath) + "'>HTML编辑</a> | " + "<a href=../../Template/" + Request.QueryString["DirPath"].Replace("/Template/", "") + "/" + name.ToString() + " target=\"_blank\">预览</a>"; break;
                case ".htm": returnStr = " | <a href=TemplateTextEdit.aspx?filePath=" + Server.UrlEncode(filepath) + ">文本编辑</a> | <a href='TemplateHtmlEdit.aspx?filePath=" + Server.UrlEncode(filepath) + "'>HTML编辑</a> | " + "<a href=../../Template/" + Request.QueryString["DirPath"].Replace("/Template/", "") + "/" + name.ToString() + " target=\"_blank\">预览</a>"; break;
                case ".Config": returnStr = " | <a href=TemplateTextEdit.aspx?filePath=" + Server.UrlEncode(filepath) + ">文本编辑</a> | <a href='TemplateHtmlEdit.aspx?filePath=" + Server.UrlEncode(filepath) + "'>HTML编辑</a> | " + "<a href=../../Template/" + name.ToString() + " target=\"_blank\">预览</a>"; break;
                case ".config": returnStr = " | <a href=TemplateTextEdit.aspx?filePath=" + Server.UrlEncode(filepath) + ">文本编辑</a> | <a href='TemplateHtmlEdit.aspx?filePath=" + Server.UrlEncode(filepath) + "'>HTML编辑</a> | " + "<a href=../../Template/" + name.ToString() + " target=\"_blank\">预览</a>"; break;
                case ".Css": returnStr = " | <a href=TemplateTextEdit.aspx?filePath=" + Server.UrlEncode(filepath) + ">文本编辑</a> | " + "<a href=../../Template/" + name.ToString() + " target=\"_blank\">预览</a>"; break;
                case ".css": returnStr = " | <a href=TemplateTextEdit.aspx?filePath=" + Server.UrlEncode(filepath) + ">文本编辑</a> | " + "<a href=../../Template/" + name.ToString() + " target=\"_blank\">预览</a>"; break;
            }
        }

        return returnStr;
    }
    #endregion


    protected void btnTemplateUpLoad_Click(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(8);
        bool flag = false;
        string localPath = fileUploadTemplate.PostedFile.FileName;
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
            Response.Write("<script>alert('不允许上传此类型的文件')</script>");
            return;
        }
        string savePath = AbsPath + @"\" + fileName;
        fileUploadTemplate.PostedFile.SaveAs(savePath);
        if (Request.QueryString["DirPath"] == null)
            Response.Redirect("CreateFolder.aspx");
        else
            Response.Redirect("CreateFolder.aspx?DirPath=" + Request.QueryString["DirPath"]);
    }
}