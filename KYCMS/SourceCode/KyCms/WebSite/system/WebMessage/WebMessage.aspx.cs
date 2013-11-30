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
using Ky.Model;
using Ky.BLL;
using Ky.Common;

public partial class system_WebMessage_WebMessage : System.Web.UI.Page
{
    private B_WebMessage bll = new B_WebMessage();
    private M_WebMessage model = new M_WebMessage();
    private B_User buser = new B_User();
    private M_User muser = new M_User();
    private B_UserGroup busergroup = new B_UserGroup();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminGroupBll.Power_Judge(47);
            UserGroupList.DataSource = busergroup.ManageList("order by UserGroupId desc");
            UserGroupList.DataTextField = "UserGroupName";
            UserGroupList.DataValueField = "UserGroupId";
            UserGroupList.DataBind();

            OverdueDate.Attributes["Readonly"] = "true";
            OverdueDate.Text = DateTime.Now.AddMonths(1).ToShortDateString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        B_SiteInfo bsiteinfo = new B_SiteInfo();

        string sSelectUserType = Request.Form["SelectUserType"];
        string sTitle = bsiteinfo.GetFiltering(Title.Text);
        string sContent = bsiteinfo.GetFiltering(Function.Encode(Content.Text));
        B_Admin adminBll = new B_Admin();
        M_LoginAdmin loginModel = adminBll.GetLoginModel();
        string sSendName = loginModel.AdminName.ToString();
        string sOverdueDate = OverdueDate.Text;

        model.SendId = 0;
        model.SendName = sSendName;
        model.Title = sTitle;
        model.Content = sContent;
        model.IsSend = 1;
        model.ReceiverDel = 0;
        model.SendDel = 0;
        model.OverdueDate = DateTime.Parse(sOverdueDate);
        model.AddDate = DateTime.Now;
        model.TypeId = 1;


        //所有用户
        if (sSelectUserType == "1")
        {
            model.ReceiverId = 0;
            model.ReceiverName = "";
            model.IsRead = 1;
            model.AllUser = 1;
            model.UserGroupId = 0;
            bll.Insert(model);

            Function.ShowSysMsg(1, "<li>成功向所有用户发送短消息！</li><li><a href='WebMessage/WebMessage.aspx'>继续发送短消息</a> <a href='WebMessage/WebMessageList.aspx'>返回短消息管理列表</a></li>");
        }

        //指定用户组
        if (sSelectUserType == "2")
        {
            model.ReceiverId = 0;
            model.ReceiverName = "";
            model.IsRead = 1;
            model.AllUser = 0;

            string MyUserGroupList = "";

            if (UserGroupList.Items.Count > 0)
            {
                for (int i = 0; i < UserGroupList.Items.Count; i++)
                {
                    if (UserGroupList.Items[i].Selected == true)
                    {
                        MyUserGroupList += UserGroupList.Items[i].Text+"、";
                        model.UserGroupId = int.Parse(UserGroupList.Items[i].Value.ToString());
                        bll.Insert(model);
                    }
                }
            }

            Function.ShowSysMsg(1, "<li>成功向" + MyUserGroupList.Substring(0, MyUserGroupList.Length - 1) + "组发送短消息！</li><li><a href='WebMessage/WebMessage.aspx'>继续发送短消息</a> <a href='WebMessage/WebMessageList.aspx'>返回短消息管理列表</a></li>");
        }


        //指定用户
        if (sSelectUserType == "3")
        {
            string sUserNmuber = UserNmuber.Text;
            if (sUserNmuber == "")
            {
                Function.ShowSysMsg(0, "<li>请输入用户</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }

            string MyUserNumber = "";

            for (int i = 0; i < Function.GetSplit(sUserNmuber, "|").Length; i++)
            {
                muser = buser.GetUser(Function.GetSplit(sUserNmuber, "|")[i]);

                if (muser!=null)
                {
                    MyUserNumber += Function.GetSplit(sUserNmuber, "|")[i] + "、";

                    model.ReceiverId = muser.UserID;
                    model.ReceiverName = muser.LogName;
                    model.IsRead = 0;
                    model.AllUser = 0;
                    model.UserGroupId = 0;
                    bll.Insert(model);
                }
            }
            Function.ShowSysMsg(1, "<li>成功向" + MyUserNumber.Substring(0, MyUserNumber.Length - 1) + "用户发送短消息！</li><li><a href='WebMessage/WebMessage.aspx'>继续发送短消息</a> <a href='WebMessage/WebMessageList.aspx'>返回短消息管理列表</a></li>");
        }
    }
}
