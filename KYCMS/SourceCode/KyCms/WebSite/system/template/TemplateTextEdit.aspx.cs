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

using System.IO;
using Ky.BLL;
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class System_templateList_TemplateTextEdit : System.Web.UI.Page
{
    protected string FilePath = string.Empty;
    protected string ShowPath = string.Empty;
    protected string FileName = string.Empty;
    protected B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected static string SkipPageUrl = string.Empty;
    B_InfoModel InfoModelBll = new B_InfoModel();
    #region 页面加载事件
    protected void Page_Load(object sender, EventArgs e)
    {  
        FilePath = Request.QueryString["filePath"].ToString();
        if(!IsPostBack)
        {
            SkipPageUrl = Request.ServerVariables["HTTP_REFERER"].ToString();
            ModelBind();



            AdminGroupBll.Power_Judge(8);
            BindCategory();
            string _filePath = FilePath.ToLower();
            string _template = Param.SiteRootPath.ToLower() + "\\template";
            if (!_filePath.StartsWith(_template))
            {
                Function.ShowSysMsg(0, "<li>路径获取错误</li><li>请不要非法操作</li>");
            }
            StreamReader sr = new StreamReader(FilePath, System.Text.Encoding.GetEncoding("UTF-8"));
            string content = sr.ReadToEnd();
            sr.Close();
            lblContent.Value = content;
        }
        FileName = Path.GetFileName(FilePath);
        ShowPath = FilePath.Replace(Param.SiteRootPath, "").Replace("\\", "/");
        AjaxPro.Utility.RegisterTypeForAjax(typeof(System_templateList_TemplateTextEdit));
    }
    #endregion

    [AjaxPro.AjaxMethod]
    public DataTable GetLabelList(string categoryId)
    {
        DataTable dt = null;
        if (int.Parse(categoryId) >= 0)
        {
            B_LabelContent bll = new B_LabelContent();
            int recordCount = 0;
            dt = bll.GetLbCategoryIdList(int.Parse(categoryId), 1, 1000000, ref recordCount);
        }
        else
        {
            B_SuperLabel bll = new B_SuperLabel();
            dt = bll.GetList(1, 1000000).Tables[0];
        }
        return dt;
    }



    #region 绑定类别
    private void BindCategory()
    {
        ddlCategory.Items.Clear();
        ddlCategory.Items.Add(new ListItem("一级样式", "0"));
        B_LbCategory bll = new B_LbCategory();
        DataTable dt = bll.GetListItemByLabelId();
        foreach (DataRow dr in dt.Rows)
        {
            string colname = dr["Name"].ToString();
            int colid = Convert.ToInt32(dr["LbCategoryID"].ToString());
            int depth = int.Parse(dr["Depth"].ToString());
            for (int i = 0; i < depth; i++)
            {
                colname = "├┄" + colname;
            }
            ddlCategory.Items.Add(new ListItem(colname, colid.ToString()));
        }
        dt.Dispose();
        ddlCategory.Items.Add(new ListItem("超级标签", "-1"));
    }
    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        StreamWriter sw = new StreamWriter(FilePath, false, System.Text.Encoding.GetEncoding("UTF-8"));
        sw.Write(lblContent.Value);
        sw.Flush();
        sw.Close();
        Response.Redirect(SkipPageUrl);        
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        StreamReader sr = new StreamReader(FilePath, System.Text.Encoding.GetEncoding("UTF-8"));
        string content = sr.ReadToEnd();
        sr.Close();
        lblContent.Value = content;
    }

    //获得模型列表
    private void ModelBind()
    {
        repModelList.DataSource = InfoModelBll.GetList();
        repModelList.DataBind();
    }
}
