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

public partial class system_label_CommonlyList : System.Web.UI.Page, ICallbackEventHandler
{
    B_Channel Bll = new B_Channel();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_ModelField ModelFieldBll = new B_ModelField();
    protected int modelId = 1;                           //模型的Id号
    protected void Page_Load(object sender, EventArgs e)
    {
        modelId = int.Parse(Request.QueryString["modelId"].ToString());
        //确定文章的属性

        AdminGroupBll.Power_Judge(6); //添加权限

        string rpc = Page.ClientScript.GetCallbackEventReference(this, "id", "UpdateChild", "null", "ShowError", false);
        string func = "function ListData(id) { " + rpc + "; }";
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ListData", func, true);
       if(!IsPostBack)
       {
           StyleBind();                       //绑定用户自定义样式
           BindData();                       //绑定频道栏目列表
           BindStyleCategory();        //绑定分类样式列表
           SystemModelField();         //绑定系统字段
       }
   }

   #region ajax
   private string _result;
   public string GetCallbackResult()
   {
       return _result;
   }

   public void RaiseCallbackEvent(string eventArgument)
   {

       if (!string.IsNullOrEmpty(eventArgument))
       {
           if (eventArgument != "0")
           {

               B_Column column = new B_Column();
               int chid = int.Parse(eventArgument);
               DataTable dt = column.GetFormatListItemByChannelId(chid);
               foreach (DataRow row in dt.Rows)
               {
                   _result += row["ColName"].ToString();
                   _result += ",";
                   _result += row["ColId"].ToString();
                   _result += "|";
               }
               if (_result == "")
               {
                   _result = _result.Substring(0, _result.Length - 1);
               }
               //_result = _result.Substring(0, _result.Length - 1);
           }
       }
   }
   #endregion

   #region 绑定样式
   private void StyleBind()
    {
        B_Style bll = new B_Style();
        DataTable dtStyle = bll.GetStyleByModel(modelId);
        ddlStyle.DataSource = dtStyle;
        ddlStyle.DataTextField = "Name";
        ddlStyle.DataValueField = "StyleID";
        ddlStyle.DataBind();
        DataTable commdt = bll.GetStyleByModel(0);
        if (dtStyle.Rows.Count <= 0 && commdt.Rows.Count<=0)
            ddlStyle.Items.Add(new ListItem("请创建样式", "custom"));
       for (int i = 0; i < commdt.Rows.Count; i++)
        {
            ListItem lstItem = new ListItem(commdt.Rows[i]["Name"].ToString(), commdt.Rows[i]["StyleID"].ToString());
            lstItem.Attributes.Add("style", "background-color:#D5E9F9;border:solid 1px #FFF;");
            ddlStyle.Items.Insert(i,lstItem);
        }
            ddlStyle.Items.Add(new ListItem("自定义", "0"));
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
        selectcolumn.Items.Insert(0,new ListItem("请选择系统样式字段",""));
    }
    #endregion

    #region 绑定频道与指定栏目
    void BindData()
    {
        ddlParent.DataSource = Bll.GetChannelByType(modelId);
        ddlParent.DataTextField = "ChName";
        ddlParent.DataValueField = "ChId";
        ddlParent.DataBind();
        ddlParent.Items.Insert(0,new ListItem("当前频道","0"));

        int chId = int.Parse(ddlParent.SelectedValue);
        B_Column column = new B_Column();
        ddlChild.DataSource = column.GetFormatListItemByChannelId(chId);
        ddlChild.DataTextField = "ColName";
        ddlChild.DataValueField = "ColId";
        ddlChild.DataBind();
        ddlChild.Items.Insert(0, new ListItem("当前栏目", "0"));
        ddlChild.Items.Insert(1, new ListItem("所有栏目", "all"));
    }
    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        M_Style mStyle = new M_Style();
        mStyle.StyleCategoryId = int.Parse(ddlStyleType.SelectedValue.ToString());
        mStyle.StyleCategoryId = 1;
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
