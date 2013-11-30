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
using Ky.Common;

public partial class system_news_SetVote : System.Web.UI.Page
{
    B_Vote bll = new B_Vote();
    B_VoteCategory cateBll = new B_VoteCategory();
    M_Vote votemodel = new M_Vote();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    int SubjectId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(11);
        if (!Page.IsPostBack)
        {            
            BindCate();
        }

        if (Request.QueryString["ac"] != null && Request.QueryString["vid"] != null && Request.QueryString["ac"]=="up")
        {
            btnAdd.Text = "修改";
            SubjectId = Function.CheckNumber(Request.QueryString["vid"]) ? int.Parse(Request.QueryString["vid"]) : 0;
            if (!IsPostBack)
            {
                BindOnUpdate();
            }
        }
    }

    /// <summary>
    /// 绑定投票分类
    /// </summary>
    void BindCate()
    {
        ddlCategory.Items.Clear();
        DataTable dt = cateBll.GetList();
        if (dt.Rows.Count == 0)
        {
            Function.ShowSysMsg(0,"<li>无可用分类,请先添加分类</li><li><a href='vote/VoteCategory.aspx'>添加分类</a></li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        else
        {
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
        }

        txtStartTime.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
        txtEndTime.Text = DateTime.Now.Date.AddMonths(1).ToString("yyyy-MM-dd");
    }

    /// <summary>
    ///  在修改时加载数据
    /// </summary>
    /// <param name="id">投票Id</param>
    void BindOnUpdate()
    {
        DataTable dt = bll.GetSubject(SubjectId);
        if (dt.Rows.Count > 0)
        {
            lbInfo.Visible = false;
            txtDescription.Text = dt.Rows[0]["Subject"].ToString();
            string cateId = dt.Rows[0]["CategoryId"].ToString();
            for (int i = 0; i < ddlCategory.Items.Count; i++)
            {
                if (ddlCategory.Items[i].Value == cateId)
                {
                    ddlCategory.SelectedIndex = i;
                    break;
                }
            }
            txtStartTime.Text = dt.Rows[0]["StartDate"].ToString();
            txtEndTime.Text = dt.Rows[0]["EndDate"].ToString();
            chkIsLogin.Checked = dt.Rows[0]["RequireLogin"].ToString() == "True";
            ddlVoteNum.SelectedIndex = dt.Rows.Count - 1;
            ddlVoteNum.Enabled = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                I = i + 1;
                TextBox title = (TextBox)Page.FindControl("txtTitle" + I);
                title.Text = dt.Rows[i]["VoteTitle"].ToString();
                //保存VoteID到隐藏控件,供修改用
                Literal voteId = (Literal)Page.FindControl("LitVoteId" + I);
                voteId.Text = dt.Rows[i]["VoteId"].ToString();

                RadioButtonList more = (RadioButtonList)Page.FindControl("rblType" + I);
                more.SelectedIndex = dt.Rows[i]["IsMore"].ToString() == "True" ? 1 : 0;
                for (int k = 1; k <= 6; k++)
                {
                    NextItem().Text = dt.Rows[i]["ItemTitle" + k].ToString();
                    TextBox num = (TextBox)Page.FindControl("txtItemNum" + I + k);
                    num.Text = dt.Rows[i]["ItemNum" + k].ToString();
                }
                ResetM();
            }
        }
        else
        {
            Function.ShowSysMsg(0, "<li>未能获取到数据</li><li><a href='vote/Vote.aspx'>返回投票列表</a></li>");
        }
    }

    /// <summary>
    /// 添加/修改
    /// </summary>
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        int voteNum = int.Parse(ddlVoteNum.SelectedValue);
        //
        //检查必须的条件是否满足
        //
        if (txtDescription.Text.Trim() == "")
        {
            Function.ShowSysMsg(0, "<li>投票主题不能为空,请检查</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }

        for (int i = 1; i <= voteNum; i++)
        {
            TextBox title = (TextBox)Page.FindControl("txtTitle" + i);
            if (title.Text.Trim() == "")
            {
                Function.ShowSysMsg(0, "<li>投票项 " + i + " 不能为空,请检查</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
        }

        M_VoteSubject subModel = new M_VoteSubject();
        subModel.Subject = txtDescription.Text;
        subModel.CategoryId = int.Parse(ddlCategory.SelectedValue);
        try
        {
            subModel.EndDate = DateTime.Parse(txtEndTime.Text).Date;
            subModel.StartDate = DateTime.Parse(txtStartTime.Text).Date;
        }
        catch
        {
            Function.ShowSysMsg(0, "<li>输入日期格式不正确,请检查</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
        subModel.RequireLogin = chkIsLogin.Checked;

        if (SubjectId == 0)//新增
        {
            //添加投票Subject,并获取 SubjectID 以供后面添加投票用
            int subId = bll.AddSubject(subModel);

            //设置投票主题的SubjectId
            votemodel.SubjectId = subId;
        }
        for (int i = 1; i <= voteNum; i++)
        {
            I = i;
            TextBox title = (TextBox)Page.FindControl("txtTitle" + i);
            votemodel.VoteTitle = title.Text;
            RadioButtonList more = (RadioButtonList)Page.FindControl("rblType" + i);
            votemodel.IsMore = more.SelectedIndex == 1;
            if (SubjectId > 0)
            {
                Literal voteId = (Literal)Page.FindControl("LitVoteId" + i);
                votemodel.VoteId = int.Parse(voteId.Text);
            }
            votemodel.ItemTitle1 = NextItem().Text;
            votemodel.ItemTitle2 = NextItem().Text;
            votemodel.ItemTitle3 = NextItem().Text;
            votemodel.ItemTitle4 = NextItem().Text;
            votemodel.ItemTitle5 = NextItem().Text;
            votemodel.ItemTitle6 = NextItem().Text;
            ResetM();
            votemodel.ItemNum1 = NextNum();
            votemodel.ItemNum2 = NextNum();
            votemodel.ItemNum3 = NextNum();
            votemodel.ItemNum4 = NextNum();
            votemodel.ItemNum5 = NextNum();
            votemodel.ItemNum6 = NextNum();

            if (SubjectId == 0)
            {
                bll.AddVote(votemodel);
            }
            else
            {
                votemodel.SubjectId = SubjectId;
                subModel.SubjectId = SubjectId;
                bll.UpdateSubject(subModel);
                bll.UpdateVote(votemodel);
            }
            ResetM();
        }
        Function.ShowSysMsg(1, "<li>操作成功</li><li><a href='vote/Vote.aspx'>返回投票列表</a></li>");
    }

    protected TextBox NextItem()
    {
        TextBox item = (TextBox)Page.FindControl("txtItem" +I + M);
        M++;
        return item;
    }
    protected int NextNum()
    {
        TextBox item = (TextBox)Page.FindControl("txtItemNum" + I + M);
        M++;
        bool isNum = Function.CheckNumber(item.Text);
       if(!isNum)
       {
           return 0;
        }
        return int.Parse(item.Text);
    }

    protected void ResetM()
    {
        M = 1;
    }

    int M = 1;
    int I = 1;

}
