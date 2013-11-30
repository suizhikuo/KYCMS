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

public partial class user_Message_MessageRead : System.Web.UI.Page
{
    private B_WebMessage b_message = new B_WebMessage();
    private M_WebMessage m_message = new M_WebMessage();
    private M_User m_user = new M_User();
    private B_User b_user = new B_User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string Id=Request.QueryString["id"];
            string TypeId=Request.QueryString["TypeId"];

            if(Id=="" || Id==null || TypeId=="" || TypeId==null)
            {
                Response.Redirect("MessageList.aspx?TypeId="+TypeId+"");
                Response.End();
            }

            m_user=b_user.GetCookie();

            m_message=b_message.Show(int.Parse(Id),m_user.UserID);

            if (m_message == null)
            { 
                Response.Redirect("MessageList.aspx?TypeId="+TypeId+"");
                Response.End();
            }

            if (m_message.AllUser == 1 || (m_message.AllUser == 0 && m_message.UserGroupId != 0) || (m_message.AllUser == 0 && m_message.SendId == 0 && m_message.UserGroupId==0))
            {
                LinkButton1.Visible = false;
                ShowRe.Visible = false;
            }

            AddDate.Text = m_message.AddDate.ToString();
            SendName.Text = m_message.SendName;
            Title.Text = m_message.Title;
            Content.Text = Function.Decode(m_message.Content);
            Response.Write("<script type='text/javascript'>parent.LeftIframe.location.reload();</script>");
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string Id = Request.QueryString["id"];
        string TypeId = Request.QueryString["TypeId"];
        m_user = b_user.GetCookie();

        b_message.UpdateDel(int.Parse(Id), m_user.UserID, int.Parse(TypeId));

        Function.ShowMsg(1, "<li>成功删除指定数据!</li><li><a href='Message/MessageList.aspx?TypeId=" + TypeId + "'>返回列表</a></li>");
        Response.Write("<script type='text/javascript'>parent.LeftIframe.location.reload();</script>");
    }
}
