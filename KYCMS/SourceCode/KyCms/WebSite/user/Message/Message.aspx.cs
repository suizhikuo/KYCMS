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
using System.Text;

public partial class user_Message_Message : System.Web.UI.Page
{
    private B_WebMessage bll = new B_WebMessage();
    private M_WebMessage model = new M_WebMessage();
    private B_User buser = new B_User();
    private M_User muser = new M_User();
    private B_WebMessage b_message = new B_WebMessage();
    private M_WebMessage m_message = new M_WebMessage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string Action = Request.QueryString["Action"];
            string Id = Request.QueryString["MessageId"];
            string sReceiverName = Request.QueryString["ReceiverName"];
            muser = buser.GetCookie();
            //好友
            int total = 0;

            DataTable dt = new DataTable();
            dt = buser.ListGroupMember("KyUserFriend.UserId=" + muser.UserID + " and FriendGroupId!=2", 1000, 1, ref total);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    UserFriend.Items.Add(new ListItem(dt.Rows[i]["LogName"].ToString(), dt.Rows[i]["LogName"].ToString()));
                }
            }

            if (Action == null)
            {
                Action = "";
            }

            if (Id == null)
            {
                Id = "";
            }

            if (sReceiverName == null)
            {
                sReceiverName = "";
            }

            if (sReceiverName != "")
            {
                ReceiverName.Text = sReceiverName;
            }

            if (Action != "" || Id != "")
            {
                m_message = b_message.Show(int.Parse(Id), muser.UserID);

                if (m_message.AllUser == 0 && m_message.UserGroupId == 0)
                {
                    if (Action == "Re")
                    {
                        ReceiverName.Text = m_message.SendName;
                        Title.Text = "Re：" + m_message.Title + "";
                        Content.Text = "======在 " + m_message.AddDate + " 您来信中写道：======\r\n<br/>" + Function.Decode(m_message.Content) + "\n=======================================\n";
                    }
                }
                if (Action == "Fw")
                {
                    Title.Text = "Fw：" + m_message.Title + "";
                    Content.Text = "======下面是转发信息======\n原发件人：" + m_message.SendName + "\n<br/>原发件内容：\n" + Function.Decode(m_message.Content) + "\n======================================\n";
                }

                if (m_message.IsSend == 0)
                {
                    if (Action == "Edit")
                    {
                        ReceiverName.Text = m_message.ReceiverName;
                        Title.Text = m_message.Title;
                        Content.Text = Function.Decode(m_message.Content);
                    }
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        B_SiteInfo bsiteinfo = new B_SiteInfo();

        model.SendId = buser.GetCookie().UserID;
        model.SendName = buser.GetCookie().LogName;
        model.Title = bsiteinfo.GetFiltering(Title.Text);
        model.Content = bsiteinfo.GetFiltering(Function.Encode(Content.Text));
        model.IsSend = 1;
        model.ReceiverDel = 0;
        model.SendDel = 0;
        model.AddDate = DateTime.Now;
        model.OverdueDate = DateTime.Now;
        model.TypeId = 1;

        string sReceiverName = ReceiverName.Text;
        if (sReceiverName == "")
        {
            Function.ShowMsg(0, "<li>请输入用户</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }

        if (Title.Text.ToString() == "")
        {
            Function.ShowMsg(0, "<li>请输入标题</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }

        if (Content.Text.ToString() == "")
        {
            Function.ShowMsg(0, "<li>请输入内容</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }

        string AllUserName = "";

        for (int i = 0; i < Function.GetSplit(sReceiverName, "|").Length; i++)
        {
            muser = buser.GetUser(Function.GetSplit(sReceiverName, "|")[i]);
            if (muser != null)
            {
                if (muser.UserID != 0)
                {
                    model.ReceiverId = muser.UserID;
                    model.ReceiverName = muser.LogName;
                    model.IsRead = 0;
                    model.AllUser = 0;
                    model.UserGroupId = 0;
                    bll.Insert(model);

                    AllUserName += "[" + muser.LogName + "]";
                }
            }
        }
        if (AllUserName == "")
            Function.ShowMsg(0, "<li>没有符合条件的用户</li><li><a href='Message/MessageList.aspx?TypeId=1'>返回短消息列表</a></li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        else
            Function.ShowMsg(1, "<li>成功给" + AllUserName + "用户发送短消息!</li><li><a href='Message/MessageList.aspx?TypeId=1'>返回短消息列表</a></li>");
    }


    //存草稿
    protected void Button2_Click(object sender, EventArgs e)
    {
        string sTitle = Title.Text;
        string sContent = Function.Encode(Content.Text);

        model.SendId = buser.GetCookie().UserID;
        model.SendName = buser.GetCookie().LogName;
        model.Title = sTitle;
        model.Content = sContent;
        model.IsSend = 0;
        model.ReceiverDel = 0;
        model.SendDel = 0;
        model.AddDate = DateTime.Now;
        model.OverdueDate = DateTime.Now;
        model.TypeId = 1;

        string sReceiverName = ReceiverName.Text;
        if (sReceiverName == "")
        {
            Function.ShowMsg(0, "<li>请输入用户!</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }

        if (Title.Text.ToString() == "")
        {
            Function.ShowMsg(0, "<li>请输入标题!</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }

        if (Content.Text.ToString() == "")
        {
            Function.ShowMsg(0, "<li>请输入内容!</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        string AllUserName = "";
        for (int i = 0; i < Function.GetSplit(sReceiverName, "|").Length; i++)
        {
            muser = buser.GetUser(Function.GetSplit(sReceiverName, "|")[i]);
            if (muser != null)
            {
                if (muser.UserID != 0)
                {
                    model.ReceiverId = muser.UserID;
                    model.ReceiverName = muser.LogName;
                    model.IsRead = 0;
                    model.AllUser = 0;
                    model.UserGroupId = 0;
                    bll.Insert(model);
                }
                AllUserName += "[" + muser.LogName + "]";
            }
        }
        if (AllUserName == "")
            Function.ShowMsg(0, "<li>没有符合条件的用户</li><li><a href='Message/MessageList.aspx?TypeId=1'>返回短消息列表</a></li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        else
            Function.ShowMsg(1, "<li>成功保存草稿</li><li><a href='Message/MessageList.aspx?TypeId=1'>返回短消息列表</a></li>");
    }
}
