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
using Ky.Common;

public partial class QA_Index : System.Web.UI.Page
{
    B_Feedback feedback = new B_Feedback();
    B_Dictionary dictionary = new B_Dictionary();
    B_Create createBll = new B_Create();
    const int cid = 8;
    protected void Page_Load(object sender, EventArgs e)
    {
        hylnk.NavigateUrl = createBll.GetIndexUrl();
        if (!IsPostBack)
        {
            BindData();
            BindCategory();
        }
    }

    /// <summary>
    /// 绑定内容
    /// </summary>
    void BindData()
    {
        //问答中
        DataTable dataIng = feedback.GetList(20, 1, "parentId=0 and state=0").Tables[0];
        rptING.DataSource = dataIng;
        rptING.DataBind();
        if (dataIng.Rows.Count == 0)
        { TrIngNo.Visible = true; }
        if (dataIng.Rows.Count > 20)
        { TrIngMore.Visible = true; }
        //已解决
        DataTable dataEd = feedback.GetList(20, 1, "parentId=0 and state=1 and datediff(day,replyDate,getDate())<=5").Tables[0];
        rptEd.DataSource = dataEd;
        rptEd.DataBind();
        if (dataEd.Rows.Count == 0)
        { TrEdNo.Visible = true; }
        if (dataEd.Rows.Count > 20)
        { TrEdMore.Visible = true; }
        //积分排行榜
        DataTable dataHigh = feedback.GetHighScoringAuthor();
        rptScoring.DataSource = dataHigh;
        rptScoring.DataBind();
        if (dataHigh.Rows.Count == 0)
        { TrUser.Visible = true; }
        //统计
        DataTable count = feedback.Count();
        LitEd.Text = count.Rows[0]["Finished"].ToString();
        LitIng.Text = count.Rows[0]["Answing"].ToString();
        LitTotal.Text = count.Rows[0]["Total"].ToString();
    }
    /// <summary>
    /// 绑定分类
    /// </summary>
    void BindCategory()
    {
        DataTable topData = dictionary.GetDictionary(cid);
        for (int i = 0; i < topData.Rows.Count; i++)
        {
            TreeNode N = new TreeNode(topData.Rows[i]["DicName"].ToString(), topData.Rows[i]["ID"].ToString());
            DoBind(Convert.ToInt32(topData.Rows[i]["ID"]), N);
            tvCategory.Nodes.Add(N);
        }
    }
    void DoBind(int id, TreeNode N)
    {
        DataTable nodes = dictionary.GetDictionary(id);
        for (int i = 0; i < nodes.Rows.Count; i++)
        {
            TreeNode node = new TreeNode(nodes.Rows[i]["DicName"].ToString(), nodes.Rows[i]["ID"].ToString());
            N.ChildNodes.Add(node);
            DoBind(Convert.ToInt32(nodes.Rows[i]["ID"]), node);
        }

    }
    protected void tvCategory_SelectedNodeChanged(object sender, EventArgs e)
    {
        Response.Redirect("List.aspx?cid=" + tvCategory.SelectedValue);
    }

    protected string SetCategory(object categoryId)
    {
        string returnStr = "无分类";
        if (categoryId != null)
        {
            M_Dictionary model = dictionary.GetModel(Convert.ToInt32(categoryId));
            if (model != null)
            {
                returnStr = model.DicName;
            }
        }
        return returnStr;
    }
}
