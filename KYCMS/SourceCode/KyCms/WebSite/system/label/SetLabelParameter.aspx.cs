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
using System.Text;

using Ky.BLL;
using Ky.Model;

public partial class System_Label_LabelSetParameter : System.Web.UI.Page, ICallbackEventHandler
{
    B_Channel Bll = new B_Channel();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(6); 
        string rpc = Page.ClientScript.GetCallbackEventReference(this, "id", "UpdateChild", "null", "ShowError", false);
        string rpc1 = Page.ClientScript.GetCallbackEventReference(this, "id", "UpdateChild1", "null", "ShowError", false);
        string rpc2 = Page.ClientScript.GetCallbackEventReference(this, "id", "UpdateChild2", "null", "ShowError", false);

        string func = "function ListData(id) { " + rpc + "; }";
        string func1 = "function ListData1(id) { " + rpc1 + "; }";
        string func2 = "function ListData2(id){" + rpc2 + ";}";
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ListData", func, true);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ListData1", func1, true);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ListData2", func2, true);
        AjaxPro.Utility.RegisterTypeForAjax(typeof(System_Label_LabelSetParameter));

        if(!IsPostBack)
        {
            StyleBind();
            BindData();
            BindColumn();
            BindStyleCategory();
        }
    }

    [AjaxPro.AjaxMethod]
    public DataTable GetFirstColumnList(string chId)
    {
        B_Column column = new B_Column();
        DataTable dt = column.GetFirstColumnByChannelId(int.Parse(chId)).ToTable();
        return dt;
    }

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

    #region 绑定样式所有列表
    private void StyleBind()
    {
        B_Style bll = new B_Style();
        ddlStyle.DataSource = bll.GetAllStyle();
        ddlStyle.DataTextField = "Name";
        ddlStyle.DataValueField = "StyleID";
        ddlStyle.DataBind();
        ddlStyle.Items.Add(new ListItem("自定义","0"));

        ddlColumnStyle.DataSource = bll.GetAllStyle();
        ddlColumnStyle.DataTextField = "Name";
        ddlColumnStyle.DataValueField = "StyleID";
        ddlColumnStyle.DataBind();
    }
    #endregion

    void BindData()
    {
        ddlParent.DataSource = Bll.GetChannelByType(1);
        ddlParent.DataTextField = "ChName";
        ddlParent.DataValueField = "ChId";
        ddlParent.DataBind();
        ddlParent.Items.Insert(0, new ListItem("当前频道","0"));

        ddlParent1.DataSource = Bll.GetChannelByType(1);
        ddlParent1.DataTextField = "ChName";
        ddlParent1.DataValueField = "ChId";
        ddlParent1.DataBind();

        int chId = int.Parse(ddlParent.SelectedValue);
        B_Column column = new B_Column();
        ddlChild.DataSource = column.GetFormatListItemByChannelId(chId);
        ddlChild.DataTextField = "ColName";
        ddlChild.DataValueField = "ColId";
        ddlChild.DataBind();
        ddlChild.Items.Insert(0, new ListItem("当前栏目", "0"));
        ddlChild.Items.Insert(1, new ListItem("所有栏目","all"));

        ddlChild1.DataSource = column.GetFormatListItemByChannelId(chId);
        ddlChild1.DataTextField = "ColName";
        ddlChild1.DataValueField = "ColId";
        ddlChild1.DataBind();
        ddlChild1.Items.Insert(0, new ListItem("当前栏目", "0"));

        //ddlChannelSite.DataSource = Bll.GetChannelByType(1);
        //ddlChannelSite.DataTextField = "ChName";
        //ddlChannelSite.DataValueField = "ChId";
        //ddlChannelSite.DataBind();
        //ddlChannelSite.Items.Insert(0, new ListItem("当前频道", "0"));

    }

    void BindColumn()
    {
        ddlChinel.DataSource = Bll.GetChannelByType(1);
        ddlChinel.DataTextField = "ChName";
        ddlChinel.DataValueField = "ChId";
        ddlChinel.DataBind();
        ddlChinel.Items.Insert(0, new ListItem("当前频道", "0"));
    }

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
            }
        }
    }

    protected void ddlChinel_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        B_Column bll = new B_Column();
        DataView dv = bll.GetFirstColumnByChannelId(int.Parse(ddlChinel.SelectedValue));
        lbColumn.DataSource = dv;
        lbColumn.DataTextField = "ColName";
        lbColumn.DataValueField = "ColId";
        lbColumn.DataBind();
    }

    //public void RaiseCallbackEvent(string eventArgument)
    //{

    //    if (!string.IsNullOrEmpty(eventArgument))
    //    {
    //        if (eventArgument != "0")
    //        {

    //            B_Column column = new B_Column();
    //            int chid = int.Parse(eventArgument);
    //            DataView dt = column.GetFirstColumnByChannelId(chid);
    //            for(int i=0;i<dt.Count;i++)
    //            {
    //                _result += dt[i]["ColName"].ToString();
    //                _result += ",";
    //                _result += dt[i]["ColId"].ToString();
    //                _result += "|";
    //            }
    //            if (_result == "")
    //            {
    //                _result = _result.Substring(0, _result.Length - 1);
    //            }
    //        }
    //    }
    //}
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string id = "1";
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
