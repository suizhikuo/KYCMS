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

public partial class system_other_Notice : System.Web.UI.Page
{
    private B_Notice BNotice = new B_Notice();
    private M_Notice model = new M_Notice();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    private B_Admin AdminBll = new B_Admin();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(46);
        if (!Page.IsPostBack)
        {
            //权限判断            

            string NoticeId = Request.QueryString["NoticeId"];

            if (NoticeId == null)
            {
                NoticeId = "";
            }

            if (NoticeId != "")
            {
                model = BNotice.Show(int.Parse(NoticeId));

                Title.Text = model.Title;
                Content.Text = model.Content;
                OverdueDate.Text = model.OverdueDate.ToShortDateString();
                IsPriority.Text = model.IsPriority.ToString();
                IsState.SelectedValue = model.IsState;
                UserName.Text = model.UserName;
            }
            else
            {
                M_LoginAdmin model = AdminBll.GetLoginModel();
                UserName.Text = model.AdminName.ToString();
                OverdueDate.Text = DateTime.Now.AddMonths(1).ToShortDateString();
            }
            OverdueDate.Attributes["Readonly"] = "true";
            AddDate.Text = DateTime.Now.ToShortDateString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string NoticeId = Request.QueryString["NoticeId"];
        if (NoticeId == null)
        {
            NoticeId = "";
        }

        if (Title.Text == "")
        {
            Label1.Text = "标题不能够为空！";
            Response.End();
        }

        if (IsPriority.Text == "")
        {
            Label2.Text = "优先级别不能够为空！";
            Response.End(); 
        }

        model.Title = Title.Text;
        model.Content = Content.Text;
        model.OverdueDate = DateTime.Parse(OverdueDate.Text);
        model.IsPriority = int.Parse(IsPriority.Text);
        model.IsState = IsState.SelectedValue;
        M_LoginAdmin loginModel = AdminBll.GetLoginModel();
        model.UserId = int.Parse(loginModel.UserId.ToString());
        model.UserName = loginModel.AdminName.ToString();
        model.AddDate = DateTime.Now;

        if (NoticeId == "")
        {
            model.TypeId = 1;
            BNotice.Insert(model);
        }
        else
        {
            model.TypeId = 2;
            model.NoticeId = int.Parse(NoticeId);
            BNotice.Update(model);
        }
        Function.ShowSysMsg(1, "<li>成功发布公告</li><li><a href='other/NoticeList.aspx'>返回公告列表</a></li>");
    }
}
