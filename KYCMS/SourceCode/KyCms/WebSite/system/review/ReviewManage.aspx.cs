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

public partial class System_review_ReviewManage : System.Web.UI.Page
{
    private B_Review ReviewBll = new B_Review();
    private B_InfoModel InfoModelBll = new B_InfoModel();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    M_InfoModel InfoModel = null;
    protected int ModelId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(4);
        if (!string.IsNullOrEmpty(Request.QueryString["ModelId"]))
        {
            try
            {
                ModelId = int.Parse(Request.QueryString["ModelId"]);
            }
            catch { }
        }
        
        if (ModelId == 0)
        {
            ModelId = 1;
        }
        InfoModel = InfoModelBll.GetModel(ModelId);
        if (InfoModel == null)
        {
            Function.ShowMsg(0, "<li>所属模型不存在或已经被删除</li>");
        }
        if(!Page.IsPostBack)
        {
            BindModel();
            ReviewBind();
        }
    }

    private void BindModel()
    {
        DataTable dt = InfoModelBll.GetList();
        ddlModel.DataTextField = "ModelName";
        ddlModel.DataValueField = "ModelId";
        ddlModel.DataSource = dt.DefaultView;
        ddlModel.DataBind();
        
        ddlModel.SelectedValue = ModelId.ToString();
    }

    private void ReviewBind()
    {
        string P = Request.QueryString["p"];
        string IsCheck = Request.QueryString["IsCheck"];
        bool MyIsCheck = true;

        if (P == "" || P == null)
        {
            P = "1";
        }

        if (IsCheck == "" || IsCheck == null || IsCheck == "false")
        {
            MyIsCheck = false;
        }

        DataSet ds = ReviewBll.ManageList(InfoModel.TableName,ModelId,int.Parse(P), Pager.PageSize, MyIsCheck);
        repInfo.DataSource = ds.Tables[0].DefaultView;
        repInfo.DataBind();
        Pager.RecordCount = (int)ds.Tables[1].Rows[0][0]; ;
        Pager.CurrentPageIndex = int.Parse(P);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    //取得到用记的名字
    public string GetName(string logname)
    {
        if (logname == "" || logname == null)
        {
            return "匿名";
        }
        else
        {
            return logname;
        }
    }

    //
    protected void repInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater child = (Repeater)e.Item.FindControl("repReview");
        HiddenField id = (HiddenField)e.Item.FindControl("hidId");
        int key = int.Parse(id.Value);
        string IsCheck = Request.QueryString["IsCheck"];
        bool MyIsCheck = true;

        if (IsCheck == "" || IsCheck == null || IsCheck == "false")
        {
            MyIsCheck = false;
        }

        DataTable dt = ReviewBll.GetList(ModelId, key, MyIsCheck);
        child.DataSource = dt;
        child.DataBind();
        dt.Dispose();
    }

    protected void Repeater1_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            ReviewBll.DelReviewByInfoId(1, id);

            ReviewBind();
        }
    }

    /// <summary>
    /// 删除评论
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Repeater2_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = int.Parse(e.CommandArgument.ToString());

            ReviewBll.DelReview(id);

            ReviewBind();
        }
    }
}
