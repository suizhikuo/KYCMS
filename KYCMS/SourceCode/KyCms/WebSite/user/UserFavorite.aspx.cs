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

public partial class user_User_Favorite : System.Web.UI.Page
{
    private B_User buser = new B_User();
    private B_UserGroup busergroup = new B_UserGroup();
    private M_User muser = new M_User();
    private M_UserGroup musergroup = new M_UserGroup();
    private M_UserFavorite muserfavorite = new M_UserFavorite();
    private B_UserFavorite buserfavorite = new B_UserFavorite();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string sURL = Request.QueryString["URL"];
            string sTitle = Request.QueryString["Title"];

            if (!(buser.IsLogin()))
            {
                Tab1.Visible = false;
                Tab2.Visible = true;

                Label1.Text = "请登陆后使用!";
                return;
            }
            
            M_User muser1 = buser.GetCookie();
            musergroup = busergroup.GetModel(buser.GetUser(muser1.LogName).GroupID);

            string Power=musergroup.GroupPower;

            //权限判断
            string CollectionValue=busergroup.Power_UserGroup("Collection", 0, Power);
            
            if (CollectionValue== "0")
            {
                Tab1.Visible = false;
                Tab2.Visible = true;
                Label1.Text = "您所在的用户组无权收藏信息!";
                return;
            }


            //获取该用户已经收录信息的条数
            DataSet ds = buserfavorite.GetList(1, 1, " where UserId=" + muser1.UserID + "");

            if (int.Parse(CollectionValue) <= int.Parse(ds.Tables[1].Rows[0][0].ToString()))
            {
                Tab1.Visible = false;
                Tab2.Visible = true;
                Label1.Text = "您收藏的信息条数已经满足所在用户组设置的最大值!";
                return;
            }


            //一切通过
            Tab1.Visible = true;
            Tab2.Visible = false;

            Url.Text = sURL;
            Title.Text = sTitle;

            ds.Clear();
            ds.Dispose();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string sURL = Url.Text;
        string sTitle = Title.Text;
        M_User muser1 = buser.GetCookie();

        muserfavorite.Title = sTitle;
        muserfavorite.Url = sURL;
        muserfavorite.UserId = muser1.UserID;
        muserfavorite.AddDate = DateTime.Now;

        buserfavorite.Add(muserfavorite);
        Response.Write("<script language=javascript>alert('成功收藏该信息!');window.close();</script>");
        Response.End();
    }
}
