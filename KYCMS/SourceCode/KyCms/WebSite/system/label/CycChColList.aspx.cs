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

public partial class system_label_CycChColList : System.Web.UI.Page
{
    B_Channel Bll = new B_Channel();
    M_Channel ChannelModel = new M_Channel();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected int modelId = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        modelId = int.Parse(Request.QueryString["modelId"].ToString());
        AjaxPro.Utility.RegisterTypeForAjax(typeof(system_label_CycChColList));   //ajax注册
        if (!IsPostBack)
        {
            StyleBind();
            BindChinnel();
            BindStyleCategory();
            SystemModelField();
        }
    }


    #region 绑定样式
    private void StyleBind()
    {
        //引用内容样式
        B_Style bll = new B_Style();
        DataTable dtStyle = bll.GetStyleByModel(modelId);
        ddlStyle.DataSource = dtStyle;
        ddlStyle.DataTextField = "Name";
        ddlStyle.DataValueField = "StyleID";
        ddlStyle.DataBind();
        DataTable commdt = bll.GetStyleByModel(0);
        if (dtStyle.Rows.Count <= 0 && commdt.Rows.Count <= 0)
            ddlStyle.Items.Add(new ListItem("请创建样式", "custom"));
        for (int i = 0; i < commdt.Rows.Count; i++)
        {
            ListItem lstItem = new ListItem(commdt.Rows[i]["Name"].ToString(), commdt.Rows[i]["StyleID"].ToString());
            lstItem.Attributes.Add("style", "background-color:#D5E9F9;border:solid 1px #FFF;");
            ddlStyle.Items.Insert(i, lstItem);
        }
        ddlStyle.Items.Add(new ListItem("自定义", "0"));

        //栏目样式
        ddlColumnStyle.DataSource = bll.GetStyleByModel(modelId);
        ddlColumnStyle.DataTextField = "Name";
        ddlColumnStyle.DataValueField = "StyleID";
        ddlColumnStyle.DataBind();
        for (int i = 0; i < commdt.Rows.Count; i++)
        {
            ListItem lstItem = new ListItem(commdt.Rows[i]["Name"].ToString(), commdt.Rows[i]["StyleID"].ToString());
            lstItem.Attributes.Add("style", "background-color:#D5E9F9;border:solid 1px #FFF;");
            ddlColumnStyle.Items.Insert(i, lstItem);
        }
    }
    #endregion

    #region 绑了样式类别
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
    #endregion

    #region 绑定系统字段
    void SystemModelField()
    {
        B_SysModelField sysModelFieldBll = new B_SysModelField();
        selectcolumn.DataSource = sysModelFieldBll.GetSysFieldListDt();
        selectcolumn.DataTextField = "FieldName";
        selectcolumn.DataValueField = "FieldValue";
        selectcolumn.DataBind();
        selectcolumn.Items.Insert(0, new ListItem("请选择系统样式字段", ""));
    }
    #endregion


    #region 绑定频道
    void BindChinnel()
    {
        ddlChinel.DataSource = Bll.GetChannelByType(modelId);
        ddlChinel.DataTextField = "ChName";
        ddlChinel.DataValueField = "ChId";
        ddlChinel.DataBind();
        ddlChinel.Items.Insert(0, new ListItem("当前频道", "0"));
    }
    #endregion

    #region 获得相应频道的根栏目
    [AjaxPro.AjaxMethod]
    public DataTable GetFirstColumnList(string chId)
    {
        B_Column column = new B_Column();
        DataTable dt = column.GetFirstColumnByChannelId(int.Parse(chId)).ToTable();
        return dt;
    }
    #endregion


    protected void btnSave_Click(object sender, EventArgs e)
    {

        M_Style mStyle = new M_Style();
        mStyle.StyleCategoryId = int.Parse(ddlStyleType.SelectedValue.ToString());
        mStyle.Name = txtTypeName.Text.Trim();

        B_KyCommon bllCom = new B_KyCommon();
        bool flag = bllCom.CheckHas(mStyle.Name, "Name", "KyStyle");

        mStyle.Content = test.Value.Trim();
        mStyle.Type = modelId;
        B_Style bllStyle = new B_Style();
        if (btnSave.Text == "添加样式")
        {
            if (!flag)
            {
                bllStyle.AddStyle(mStyle);
                StyleBind();
            }
            else
            {
                Response.Write("<script>alert('己存在此样式')</script>");
                StyleBind();
            }
        }
    }
}
