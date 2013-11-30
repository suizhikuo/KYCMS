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
using Ky.BLL.CommonModel;
using Ky.Model;
using Ky.Common;

public partial class system_infomodel_SearchStyleList : System.Web.UI.Page
{
    B_InfoModel InfoModelBll = new B_InfoModel();
    B_ModelField bllModelField = new B_ModelField();
    B_Style StyleBll = new B_Style();
    B_SysModelField systemBll = new B_SysModelField();
    protected static int ModelId = 0;
    protected static int ctmFildCount = 0;
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(system_infomodel_SearchStyleList));
        if (!string.IsNullOrEmpty(Request.QueryString["ModelId"]))
        {
            ModelId = int.Parse(Request.QueryString["ModelId"]);
        }
        if (ModelId == 0)
            ModelId = 1;
        GetCustomListDt(ModelId);
        M_InfoModel infoModel = InfoModelBll.GetModel(ModelId);
        if (infoModel == null)
            Function.ShowSysMsg(0, "<li>所选模型不存在或已经被删除</li>");
        if (!IsPostBack)
        {
            AdminGroupBll.Power_Judge(35);
            BindModel();
            ShowInfo();
        }
    }

    private void BindModel()
    {
        DataTable dt = InfoModelBll.GetList();
        repModel.DataSource = dt.DefaultView;
        repModel.DataBind();
        dt.Dispose();
    }

    private void ShowInfo()
    {
        DataRow dr = StyleBll.GetSearchStyle(ModelId);
        if (dr != null)
        {
            txtContent.Value = dr["content"].ToString();
            btnAddStyle.Text = "修改样式";
        }
        else
        {
            txtContent.Value = Param.ListStyle;
            btnAddStyle.Text = "添加样式";
        }
    }

    #region 返回系统字段与标签
    [AjaxPro.AjaxMethod]
    public DataTable GetSysFieldList(string str)
    {
        DataTable dt = systemBll.GetSysFieldListDt();
        for (int i = dt.Rows.Count - 1; i >= 0; i--)
        {
            string field = dt.Rows[i]["FieldValue"].ToString().ToLower();
            if (field == "{ky_next}" || field == "{ky_pre}" || field == "{ky_preurl}" || field == "{ky_nexturl}" || field == "{ky_dig}")
            {
                dt.Rows.RemoveAt(i);
            }
        }
        return dt;
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
        return GetCustomListDt(ModelId);
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
        for (int i = 0; i < dt.Rows.Count; i++)
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
        for (int i = 0; i < erArrayList.Count; i++)
        {
            dr = dt.NewRow();
            string[] tmp = (string[])erArrayList[i];
            dr["Alias"] = tmp[1];
            dr["Name"] = tmp[2];
            int pos = int.Parse(tmp[0]);
            dt.Rows.InsertAt(dr, pos + 1+ i);
        }
        ctmFildCount = dt.Rows.Count;
        return dt;
    }
    #endregion

    protected void btnAddStyle_Click(object sender, EventArgs e)
    {
        bool flag = false;
        if (btnAddStyle.Text == "添加样式")
        {
            if (txtContent.Value.ToString().Trim().Length == 0 || txtContent.Value == "")
                flag = StyleBll.AddSearchStyle(ModelId, Param.ListStyle);
            else
                flag = StyleBll.AddSearchStyle(ModelId, txtContent.Value.ToString());
            if (flag)
                ltMsg.Text = "<script>alert('添加成功');location.href('" + Request.Url.ToString() + "')</script>";
            else
                ltMsg.Text = "<script>alert('添加失败');location.href('" + Request.Url.ToString() + "')</script>";
        }
        else
        {
            if (txtContent.Value.ToString().Trim().Length == 0 || txtContent.Value == "")
                flag = StyleBll.UpdateSearchStyle(ModelId, Param.ListStyle);
            else
                flag = StyleBll.UpdateSearchStyle(ModelId, txtContent.Value.ToString());
            if (flag)
                ltMsg.Text = "<script>alert('修改成功');location.href('"+Request.Url.ToString()+"')</script>";
            else
                ltMsg.Text = "<script>alert('修改失败');location.href('" + Request.Url.ToString() + "')</script>";
        }
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.location.href='SearchStyleList.aspx'</script>");
    }
}
