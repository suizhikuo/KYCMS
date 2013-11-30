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

public partial class System_Label_SetLabelContent : System.Web.UI.Page
{
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_InfoModel InfoModelBll = new B_InfoModel();
    protected static string SkipPageUrl = string.Empty;

    #region 页面加载事件
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(6);
        if(!IsPostBack)
        {
            SkipPageUrl = Request.ServerVariables["HTTP_REFERER"].ToString();

            ModelBind();  //绑定模型列表
            lblInfo.Text = "创建标签";
            BindStyleCategory();
            if (Request.QueryString["labelCategoryId"]!=null)
            {
                lblInfo.Text = "修改标签";
                btnSave.Text = "修改标签";
                btnReset.Visible = false;
                M_LabelContent model = new M_LabelContent();
                B_LabelContent bll = new B_LabelContent();
                model = bll.GetLabelContentId(int.Parse(Request.QueryString["labelCategoryId"]));
                txtLabelName.Text = model.Name.Replace("{Ky_", "").Replace("}", "");
                lblContent.Value = model.Content;
                for (int i = 0; i < dllLbCategory.Items.Count;i++ )
                {
                    if (dllLbCategory.Items[i].Value==model.LbCategoryId.ToString())
                    {
                        dllLbCategory.Items[i].Selected = true;
                    }
                }
            }
            
        }
    }
    #endregion


    #region 绑定标签类别
    private void BindStyleCategory()
    {
        dllLbCategory.Items.Clear();
        dllLbCategory.Items.Add(new ListItem("请选择类别", "0"));
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
            dllLbCategory.Items.Add(new ListItem(colname, colid.ToString()));
        }
    }
    #endregion


    #region 下拉框页面转向
    protected void ddlRedirectPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(ddlRedirectPage.SelectedValue.ToString());
    }
    #endregion


    #region 添加与修改标签
    protected void btnSave_Click(object sender, EventArgs e)
    {
        M_LabelContent model = new M_LabelContent();
        B_LabelContent bll = new B_LabelContent();
        B_KyCommon bllCom = new B_KyCommon();
        bool flag = false;
        if (txtLabelName.Text.Length==1 || !(txtLabelName.Text.ToString().Substring(0, 2).ToLower() == "s_"))
        {
            model.Name = lblPrefix.Text.ToString() + txtLabelName.Text.Trim() + lblPostfix.Text.ToString();
            model.LbCategoryId = int.Parse(dllLbCategory.SelectedValue.ToString());
            model.Content = lblContent.Value;
            model.AnomalyStyle = string.Empty;
            model.ModeType = int.Parse(hidModelId.Value.ToString());

            flag = bllCom.CheckHas(model.Name, "Name", "KyLabelContent");
            if (btnSave.Text == "修改标签")
            {
                model.LabelCategoryID = int.Parse(Request.QueryString["labelCategoryId"]);
                model.AnomalyStyle = string.Empty;
                bll.Update(model);
                Response.Redirect(SkipPageUrl);
            }
            else
            {
                if (!flag)
                {
                    bll.Add(model);
                    Response.Redirect(SkipPageUrl);
                }
                else
                    Response.Write("<script>alert('此标签已存在');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('此标签与超级标签冲突');</script>");
        }
    }
    #endregion


    #region 获得模型列表
    private void ModelBind()
    {
        repModelList.DataSource = InfoModelBll.GetList();
        repModelList.DataBind();
    }
    #endregion

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("SetLabelContent.aspx");
    }
}
