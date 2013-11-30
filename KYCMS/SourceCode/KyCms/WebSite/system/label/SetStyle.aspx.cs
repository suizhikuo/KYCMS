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
using System.Data.SqlClient;
using Ky.SQLServerDAL;
using Ky.BLL.CommonModel;

public partial class System_Label_SetStyle : System.Web.UI.Page
{
    B_ModelField bllModelField = new B_ModelField();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_SysModelField systemBll = new B_SysModelField();
    B_UserGroupModel UserModelBll = new B_UserGroupModel();
    B_UserGroupModelField UserCustomFieldBll = new B_UserGroupModelField();
    protected static int isShowTr = 1;
    protected static int ctmFildCount = 0;

    protected static string SkipPageUrl = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(10);
        if (!IsPostBack)
        {
            SkipPageUrl = Request.ServerVariables["HTTP_REFERER"].ToString();

            UserModelBind();
            if (Request.QueryString["modelId"] != null)
            {
                isShowTr = int.Parse(Request.QueryString["modelId"].ToString());
            }
            GetCustomListDt(isShowTr);

            BindStyleCategory();    //绑定类别样式
            if (Request.QueryString["StyleId"] == null)
            {
                btnSave.Text = "添加样式";
            }
            else
            {
                btnSave.Text = "修改样式";
                B_Style bStyle = new B_Style();
                M_Style mStyle = bStyle.GetStyle(int.Parse(Request.QueryString["StyleId"].ToString()));
                txtTypeName.Text = mStyle.Name;
                int styleCategory = mStyle.StyleCategoryId;
                test.Value = mStyle.Content.ToString();
                for (int i = 0; i < ddlStyleType.Items.Count; i++)
                {
                    if (ddlStyleType.Items[i].Value.ToString() == styleCategory.ToString())
                        ddlStyleType.Items[i].Selected = true;
                }
            }
            AjaxPro.Utility.RegisterTypeForAjax(typeof(System_Label_SetStyle));
        }

    }

    #region 返回系统字段与标签
    [AjaxPro.AjaxMethod]
    public DataTable GetSysFieldList(string str)
    {
        return systemBll.GetSysFieldListDt();
    }
    #endregion

    #region 返回文章字段与标签
    [AjaxPro.AjaxMethod]
    public DataTable GetArticleList(string str)
    {
        return systemBll.GetArticleListDt();
    }
    #endregion

    #region 返回图片模型字段与标签
    [AjaxPro.AjaxMethod]
    public DataTable GetImageList(string str)
    {
        return systemBll.GetImageListDt();
    }
    #endregion

    #region 返回下载模型字段与标签
    [AjaxPro.AjaxMethod]
    public DataTable GetDownLoadList(string str)
    {
        return systemBll.GetDownLoadListDt();
    }
    #endregion

    #region 返回用户自定义模型字段与标签
    [AjaxPro.AjaxMethod]
    public DataTable GetCustomList(string str)
    {
        return GetCustomListDt(isShowTr);
    }
    #endregion

    #region 取得用户自定义字段的列表
    public DataTable GetCustomListDt(int modelId)
    {
        DataTable dt = bllModelField.GetList(modelId);
        DataRow dr = dt.NewRow();
        dr["Alias"] = "搜索链接";
        dr["Name"] = "$search$";
        dt.Rows.Add(dr);

        ArrayList erArrayList = new ArrayList();
        for (int i = 0; i < dt.Rows.Count;i++)
        {
            string[] erArray = new string[3];
            DataRow tdr = dt.Rows[i];
            if (tdr["type"].ToString().ToLower() == "erlinkagetype")
            {
                erArray[0] = i.ToString();
                erArray[1] = bllModelField.GetFieldContent(tdr["content"].ToString(), 1, 1);
                erArray[2] = bllModelField.GetFieldContent(tdr["content"].ToString(), 2, 1);
                erArrayList.Add(erArray);
            }
        }
        for(int i=0;i<erArrayList.Count;i++)
        {
              dr = dt.NewRow();
             string[] tmp = (string[])erArrayList[i];
             dr["Alias"] = tmp[1];
             dr["Name"] = tmp[2];
             int pos = int.Parse(tmp[0]);
             dt.Rows.InsertAt(dr, pos+1+i);
        }
        ctmFildCount = dt.Rows.Count;
        return dt;
    }
    #endregion

    protected void ddlRedirectPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(ddlRedirectPage.SelectedValue.ToString());
    }

    private void BindStyleCategory()
    {
        ddlStyleType.Items.Clear();
        ddlStyleType.Items.Add(new ListItem("选择所属栏目", "0"));
        B_StyleCategory bll = new B_StyleCategory();
        DataTable dt = bll.GetListItemByStyleId();
        foreach (DataRow dr in dt.Rows)
        {
            string colname = dr["Name"].ToString();
            int colid = Convert.ToInt32(dr["StyleCategoryID"].ToString());
            int depth = int.Parse(dr["Depth"].ToString());
            for (int i = 0; i < depth; i++)
            {
                colname = "├┄" + colname;
            }
            ddlStyleType.Items.Add(new ListItem(colname, colid.ToString()));
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string id;
        if (Request.QueryString["id"] == null)
        {
            id = Request.QueryString["modelId"].ToString();
        }
        else
        {
            id = Request.QueryString["id"].ToString();
        }
        M_Style mStyle = new M_Style();
        mStyle.StyleCategoryId = int.Parse(ddlStyleType.SelectedValue.ToString());
        mStyle.Name = txtTypeName.Text.Trim();

        B_KyCommon bllCom = new B_KyCommon();
        bool flag = bllCom.CheckHas(mStyle.Name, "Name", "KyStyle");

        mStyle.Content = test.Value.Trim();
        mStyle.Type = int.Parse(id);
        B_Style bllStyle = new B_Style();
        if (btnSave.Text == "添加样式")
        {
            if (!flag)
            {
                bllStyle.AddStyle(mStyle);
                Response.Redirect(SkipPageUrl);
            }
            else
                Response.Write("<script>alert('此样式已存在')</script>");
        }
        else
        {
                mStyle.StyleID = int.Parse(Request.QueryString["StyleId"].ToString());
                bllStyle.UpadteStyle(mStyle);
                Response.Redirect(SkipPageUrl);
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SetStyle.aspx");
    }

    public void UserModelBind()
    {
        repUserModelList.DataSource = UserModelBll.GetAll();
        repUserModelList.DataBind();
    }

    #region 返回用户系统字段与标签
    [AjaxPro.AjaxMethod]
    public DataTable GetUserSysFieldList(string str)
    {
        return systemBll.UserSysField();
    }
    #endregion

    #region 返回用户自定义模型字段与标签
    [AjaxPro.AjaxMethod]
    public DataTable GetUserModelCustomListDt(object id)
    {
        return GetUserModelCustomListDtField(int.Parse(id.ToString()));
    }
    #endregion

    #region 取得用户模型自定义字段的列表
    public DataTable GetUserModelCustomListDtField(int modelId)
    {
        DataTable dt = UserCustomFieldBll.GetList(modelId);
        return dt;
    }
    #endregion
}
