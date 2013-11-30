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
using Ky.Common;
using Ky.Model;

public partial class system_review_DetailReview : System.Web.UI.Page
{
    private B_Review ReviewBll = new B_Review();
    B_InfoOper InfoOperBll = new B_InfoOper();
    B_InfoModel InfoModelBll = new B_InfoModel();
    M_InfoModel InfoModel = null;
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    int InfoId = 0;
    int ModelId = 0;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty("Id"))
        {
            try
            {
                InfoId = int.Parse(Request.QueryString["Id"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty("ModelId"))
        {
            try
            {
                ModelId = int.Parse(Request.QueryString["ModelId"]);
            }
            catch { }
        }
        InfoModel = InfoModelBll.GetModel(ModelId);
        if(InfoModel==null)
        {
            Function.ShowSysMsg(0, "<li>所属模型不存在或已经被删除</li>");
        }

        if(!Page.IsPostBack)
        {
            //权限判断
            AdminGroupBll.Power_Judge(4);
            DataRow dr = InfoOperBll.GetInfo(InfoModel.TableName, InfoId);
            if (dr == null)
            {
                Function.ShowSysMsg(0, "<li>所属内容不存在或已经被删除</li>");
            }
            Title.Text = Function.HtmlEncode(dr["Title"]);
            DataBaseList();
        }
    }

    private void DataBaseList()
    {
        string P = Request.QueryString["p"];


        if (P == "" || P == null)
        {
            P = "1";
        }

        DataSet ds = ReviewBll.ReviewList(int.Parse(P), Pager.PageSize, " where ModelType="+ModelId+" and InfoId=" + InfoId);
        repReview.DataSource = ds.Tables[0].DefaultView;
        repReview.DataBind();
        Pager.RecordCount = (int)ds.Tables[1].Rows[0][0]; ;
        Pager.CurrentPageIndex = int.Parse(P);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
        ds.Dispose();
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

    public string GetIsCheck(string ischeck)
    {
        if (ischeck == "False")
        {
            return "<div title='点击通过审核'>未通过</div>";
        }
        else
        {
            return "<div title='点击取消审核'>审核通过</dvi>";
        }
    }

    protected void repReview_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            ReviewBll.DelReview(id);

            DataBaseList();
        }

        if (e.CommandName == "IsCheck")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            ReviewBll.UpdateIsCheck(id);
            DataBaseList();
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (this.repReview.Items.Count > 0)
        {
            for (int i = 0; i < this.repReview.Items.Count; i++)
            {
                if (((CheckBox)this.repReview.Items[i].FindControl("CheckBox1")).Checked)
                {
                    ReviewBll.DelReview(int.Parse(((TextBox)this.repReview.Items[i].FindControl("CID")).Text.ToString()));
                }
            }
        }
        else
        {
            Response.Write("<script language=javascript>alert('无任何信息！');</script>");
        }

        DataBaseList();
    }
}
