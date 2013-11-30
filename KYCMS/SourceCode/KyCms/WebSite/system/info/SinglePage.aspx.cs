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
using Ky.Common;
using Ky.Model;

public partial class system_info_SinglePage : System.Web.UI.Page
{
    private B_SinglePage BSinglePage = new B_SinglePage();
    private M_SinglePage MsinglePage = new M_SinglePage();
    protected int SingleId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["SingleId"]))
        {
            try
            {
                SingleId = int.Parse(Request.QueryString["SingleId"]);
            }
            catch { }
        }

        if (!Page.IsPostBack)
        {
            ParPath.Text = Param.ApplicationRootPath;

            if (SingleId != 0)
            {
                GetModel();
            }
        }
    }
    
    private void GetModel()
    {
        MsinglePage = BSinglePage.GetModel(SingleId);

        txtName.Text=MsinglePage.Name;
        txtFolderPath.Text = MsinglePage.FolderPath.Substring(1, MsinglePage.FolderPath.Length-1);
        txtFileName.Text=MsinglePage.FileName;
        txtFileExtend.Text=MsinglePage.FileExtend;
        txtTemplatePath.Text=MsinglePage.TemplatePath;
        txtContent.Text=MsinglePage.Content;
    }

    //保存
    protected void Button1_Click(object sender, EventArgs e)
    {
        MsinglePage.Name = txtName.Text;
        MsinglePage.FolderPath = "/" + txtFolderPath.Text;
        MsinglePage.FileName = txtFileName.Text;
        MsinglePage.FileExtend = txtFileExtend.Text;
        MsinglePage.TemplatePath = txtTemplatePath.Text;
        MsinglePage.Content = txtContent.Text;
        MsinglePage.AddTime = DateTime.Now;

        if (SingleId != 0)
        {
            MsinglePage.SingleId = SingleId;
            BSinglePage.Update(MsinglePage);
            Function.ShowSysMsg(1, "<li>修改单页信息成功!</li><li><a href='info/SinglePage.aspx'>继续添加</a> <a href='info/SinglePageList.aspx'>单页列表</a></li>");
        }
        else
        {
            BSinglePage.Add(MsinglePage);
            Function.ShowSysMsg(1, "<li>添加单页信息成功!</li><li><a href='info/SinglePage.aspx'>继续添加</a> <a href='info/SinglePageList.aspx'>单页列表</a></li>");
        }
    }

    //保存并生成
    protected void Button2_Click(object sender, EventArgs e)
    {
        MsinglePage.Name = txtName.Text;
        MsinglePage.FolderPath = "/"+txtFolderPath.Text;
        MsinglePage.FileName = txtFileName.Text;
        MsinglePage.FileExtend = txtFileExtend.Text;
        MsinglePage.TemplatePath = txtTemplatePath.Text;
        MsinglePage.Content = txtContent.Text;
        MsinglePage.AddTime = DateTime.Now;

        if (SingleId != 0)
        {
            MsinglePage.SingleId = SingleId;
            BSinglePage.Update(MsinglePage);

            //生成
            B_Create bcreatebll = new B_Create();
            if (bcreatebll.CreateSinglePage(SingleId))
            {
                Function.ShowSysMsg(1, "<li>修改并生成单页信息成功!</li><li><a href='info/SinglePage.aspx?SingleId=" + SingleId + "'>重新修改</a> <a href='info/SinglePage.aspx'>继续添加</a> <a href='info/SinglePageList.aspx'>单页列表</a></li>");
            }
            else
            {
                Function.ShowSysMsg(0, "<li>修改并生成单页信息失败!</li><li><a href='info/SinglePage.aspx?SingleId=" + SingleId + "'>重新修改</a> <a href='info/SinglePage.aspx'>继续添加</a> <a href='info/SinglePageList.aspx'>单页列表</a></li>");
            }
        }
        else
        {
            SingleId = BSinglePage.Add(MsinglePage);

            //生成
            B_Create bcreatebll = new B_Create();
            if (bcreatebll.CreateSinglePage(SingleId))
            {
                Function.ShowSysMsg(1, "<li>添加并生成单页信息成功!</li><li><a href='info/SinglePage.aspx'>继续添加</a> <a href='info/SinglePageList.aspx'>单页列表</a></li>");
            }
            else
            {
                Function.ShowSysMsg(0, "<li>添加并生成单页信息失败!</li><li><a href='info/SinglePage.aspx'>继续添加</a> <a href='info/SinglePageList.aspx'>单页列表</a></li>");
            }
        }
    }
}
