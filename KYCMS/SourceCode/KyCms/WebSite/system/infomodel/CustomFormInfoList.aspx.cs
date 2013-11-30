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
using Ky.BLL.CommonModel;
using Ky.Common;
using Ky.Model;

public partial class system_infomodel_CustomFormInfoList : System.Web.UI.Page
{
    private B_InfoOper BInfoOper = new B_InfoOper();
    protected int CustomFormId = 0;
    private M_CustomForm MCustomForm = new M_CustomForm();
    private B_CustomForm BCustomForm = new B_CustomForm();
    private B_CustomFormField BCustomFormField = new B_CustomFormField();
    private M_CustomFormField MCustomFormField = new M_CustomFormField();
    private DataRow drInfo;
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected DataSet dsSearch;

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(33);

        if (!string.IsNullOrEmpty(Request.QueryString["CustomFormId"]))
        {
            try
            {
                CustomFormId = int.Parse(Request.QueryString["CustomFormId"]);
            }
            catch { }
        }

        MCustomForm = BCustomForm.GetModel(CustomFormId);

        dsSearch = BCustomFormField.ListSearch(CustomFormId);

        if (MCustomForm == null)
        {
            Function.ShowSysMsg(0, "<li>表单不存在或已经被删除</li><li><a href='infomodel/CustomFormList.aspx'>返回表单管理列表</a></li>");
        }

        if (!Page.IsPostBack)
        {
            CustomFormName.Text = MCustomForm.FormName;
            GetAll();

            //列表搜索项
            GetListSearch();
        }
    }

    private void GetAll()
    {
        string P = Request.QueryString["p"];

        if (P == "" || P == null)
        {
            P = "1";
        }

        string SearchForm = Request.QueryString["SearchForm"];
        string strWhere = "";

        if (SearchForm == "1")
        {
            if (dsSearch.Tables[0].Rows.Count > 0)
            {
                strWhere += "where [" + Request.QueryString["SearchTextField"] + "] like '%"+Request.QueryString["KeyWord"]+"%'";
            }

            if (dsSearch.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < dsSearch.Tables[1].Rows.Count; i++)
                {
                    strWhere += " and [" + dsSearch.Tables[1].Rows[i]["Name"].ToString() + "]='" + Function.UrlDecode(Request.QueryString["txt_" + dsSearch.Tables[1].Rows[i]["Name"].ToString() + ""]) + "'";
                }
            }
        }
        else
        {
            strWhere = "";
        }

        DataSet ds = BInfoOper.GetCustomTableList(MCustomForm.TableName, int.Parse(P), Pager.PageSize, strWhere);
        CustomTableRep.DataSource = ds.Tables[0].DefaultView;
        CustomTableRep.DataBind();

        Pager.RecordCount = (int)ds.Tables[1].Rows[0][0]; ;
        Pager.CurrentPageIndex = int.Parse(P);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    protected void CustomTableRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataTable dt = new DataTable();
        dt = BCustomFormField.GetTitleList(CustomFormId);

        if (e.Item.ItemType == ListItemType.Header)
        {
            //列举出所有的字段当头部 
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("<td>"+dt.Rows[i]["Alias"].ToString()+"</td>");
            }
            (e.Item.FindControl("lit_head") as Literal).Text = sb.ToString();
        }

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
        {
            //行ID
            int Id = int.Parse((e.Item.FindControl("CustomFormFieldId") as Label).Text);
            drInfo = BInfoOper.GetInfo(MCustomForm.TableName, Id);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Type"].ToString() == "MultipleTextType" || dt.Rows[i]["Type"].ToString() == "MultipleHtmlType" || dt.Rows[i]["Type"].ToString() == "DateType" || dt.Rows[i]["Type"].ToString() == "RadomType")
                {
                    sb.Append("<td>" + Function.Encode(drInfo["" + dt.Rows[i]["Name"].ToString() + ""].ToString()) + "</td>");
                }
                else
                {
                    sb.Append("<td title='单击修改此内容' onclick=UpdateFormField('" + CustomFormId + "','" + dt.Rows[i]["Name"].ToString() + "','" + Id + "') class='mouseStyle'>" + Function.Encode(drInfo["" + dt.Rows[i]["Name"].ToString() + ""].ToString()) + "</td>");
                }
            }
            (e.Item.FindControl("lit_item") as Literal).Text = sb.ToString();
        }
    }

    protected void CustomTableRep_Delete(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int Id = Convert.ToInt32(e.CommandArgument);
            BInfoOper.CompleteDeleteInfo(MCustomForm.TableName, Id);

            GetAll();
        }
    }

    //返回搜索项
    private void GetListSearch()
    {
        if (dsSearch != null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("");

            if (dsSearch.Tables[0].Rows.Count > 0 || dsSearch.Tables[1].Rows.Count > 0)
            {
                if (dsSearch.Tables[0].Rows.Count > 0)
                {
                    sb.Append("内容搜索：<select name=\"txt_SearchText\">");
                    for (int i = 0; i < dsSearch.Tables[0].Rows.Count; i++)
                    {
                        sb.Append("<option value=\"" + dsSearch.Tables[0].Rows[i]["Name"].ToString() + "\">" + dsSearch.Tables[0].Rows[i]["Alias"].ToString() + "</option>");
                    }
                    sb.Append("</select><input type=\"text\" size=\"20\" name=\"txt_KeyWord\">");
                }

                if (dsSearch.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSearch.Tables[1].Rows.Count; i++)
                    {
                        sb.Append("<select name=\"txt_" + dsSearch.Tables[1].Rows[i]["Name"].ToString() + "\">");
                        for (int p = 0; p < dsSearch.Tables[1].Rows[i]["Content"].ToString().Split(new Char[] { '|' }).Length; p++)
                        {
                            sb.Append("<option value=\"" + dsSearch.Tables[1].Rows[i]["Content"].ToString().Split(new Char[] { '|' })[p] + "\">" + dsSearch.Tables[1].Rows[i]["Content"].ToString().Split(new Char[] { '|' })[p] + "</option>");
                        }
                        sb.Append("</select>");
                    }
                }
            }
            else
            {
                Btn_Search.Visible = false;
                SearchTable.Visible = false;
            }

            dsSearch.Clear();
            dsSearch.Dispose();
            Lit_Search.Text = sb.ToString();
        }
        else
        {
            Btn_Search.Visible = false;
            SearchTable.Visible = false;
        }
    }

    //搜索
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        string MySearch = "";
        if (dsSearch.Tables[0].Rows.Count > 0)
        {
            MySearch += "&KeyWord="+Request.Form["txt_KeyWord"]+"&SearchTextField="+Request.Form["txt_SearchText"]+"";
        }

        if (dsSearch.Tables[1].Rows.Count > 0)
        {
            for (int i = 0; i < dsSearch.Tables[1].Rows.Count; i++)
            {
                
               MySearch += "&txt_" + dsSearch.Tables[1].Rows[i]["Name"].ToString() + "=" + Function.UrlEncode(Request.Form["txt_" + dsSearch.Tables[1].Rows[i]["Name"].ToString() + ""]) + "";
            }
        }
        dsSearch.Clear();
        dsSearch.Dispose();
        Response.Redirect("CustomFormInfoList.aspx?CustomFormId=" + CustomFormId + "&SearchForm=1" + MySearch + "", true);
    }
}
