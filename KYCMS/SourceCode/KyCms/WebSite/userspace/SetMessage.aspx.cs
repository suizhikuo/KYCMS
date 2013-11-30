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
public partial class userspace_SetMessage2 : System.Web.UI.Page
{
    private B_WebMessage bll = new B_WebMessage();
    private M_WebMessage model = new M_WebMessage();
    protected B_User buser = new B_User();
    private M_User muser = new M_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["UserName"]))
             ReceiverName.Text= Request.QueryString["UserName"];


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Set(true);
    }
    protected void Set(bool isSet)
    {
        B_SiteInfo bsiteinfo = new B_SiteInfo();
        model.SendId = buser.GetCookie().UserID;
        model.SendName = buser.GetCookie().LogName;
        model.Title = bsiteinfo.GetFiltering(Title.Text);
        model.Content = bsiteinfo.GetFiltering(Function.Encode(Content.Text));
        if (isSet)
            model.IsSend = 1;
        else
            model.IsSend = 0;
        model.ReceiverDel = 0;
        model.SendDel = 0;
        model.AddDate = DateTime.Now;
        model.OverdueDate = DateTime.Now;
        model.TypeId = 1;

        string sReceiverName = ReceiverName.Text;
        if (sReceiverName == "")
        {
            lbMsg.Text = "<script>alert('请输入收件人')</script>";
            return;
        }
        if (Title.Text.ToString() == "")
        {
            lbMsg.Text = "<script>alert('请输入标题')</script>";
            return;
        }

        if (Content.Text.ToString() == "")
        {
            lbMsg.Text = "<script>alert('请输入内容')</script>";
            return;
        }

        string AllUserName = "";

        muser = buser.GetUser(sReceiverName);
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
                AllUserName = muser.LogName;
            }
        }
        if (AllUserName == "")
        {
            lbMsg.Text = "<script>alert('没有符合条件的用户')</script>";
            return;
        }
        else
        {
            if (isSet)
            {
                lbMsg.Text = "<script>alert('成功给用户" + AllUserName + "发送短消息');hiddenIframe();</script>";
                return;
            }
            else
            {
                lbMsg.Text = "<script>alert('成功保存草稿');hiddenIframe()</script>";
                return;
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Set(false);
    }
}
