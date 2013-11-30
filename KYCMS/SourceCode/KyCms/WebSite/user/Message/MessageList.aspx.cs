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

public partial class user_Message_MessageList : System.Web.UI.Page
{
    private B_WebMessage bll = new B_WebMessage();
    private M_WebMessage model = new M_WebMessage();
    private B_User buser = new B_User();
    private M_User muser = new M_User();
    private M_User muser1 = new M_User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataBaseList();
        }
    }

    private void DataBaseList()
    {
        string TypeId = Request.QueryString["TypeId"];
        string WhereStr = "";
        string SearchId = Request.QueryString["SearchId"];
        string KeyWord = Function.UrlDecode(Request.QueryString["KeyWord"]);

        if (SearchId == null)
        {
            SearchId = "";
        }

        
         if (TypeId == null || TypeId == "")
         {
           TypeId = "1";
         }

         #region 条件判断

         muser = buser.GetCookie();
         muser1 = buser.GetUser(muser.LogName);
        
            //收 发 草 垃圾
            if (TypeId == "2")
            {
                Label1.Text = "发件箱";
                WhereStr = " where SendId=" + muser.UserID + " and IsSend=1 and SendDel=0";
            }
            else
            {
                if (TypeId == "3")
                {
                    Label1.Text = "草稿箱";
                    WhereStr = " where SendId=" + muser.UserID + " and IsSend=0 and SendDel=0";
                }
                else
                {
                    if (TypeId == "4")
                    {
                        Label1.Text = "回收站";
                        WhereStr = " where (ReceiverId=" + muser.UserID + " and ReceiverDel=1) or (SendId=" + muser.UserID + " and SendDel=1)";
                    }
                    else
                    {
                        Label1.Text = "收件箱";

                        DataTable dt1 = new DataTable();
                        dt1 = bll.GetList(" where (AllUser=1 or UserGroupId=" + muser1.GroupID + ") and datediff(day,OverdueDate,getdate())<=0");
                        Repeater2.DataSource = dt1;
                        Repeater2.DataBind();


                        WhereStr = " where ReceiverId=" + muser.UserID + " and ReceiverDel=0 and IsSend=1";
                    }
                }
            }
            #endregion

            if (SearchId != "")
            {
                if (SearchId == "1" || SearchId == "0")
                {
                    WhereStr+= " and Title like '%" + KeyWord + "%'";
                }

                if (SearchId == "2")
                {
                    WhereStr+=" where Content like '%" + KeyWord + "%'";
                }
            }




        string P = Request.QueryString["p"];

        if (P == "" || P == null)
        {
            P = "1";
        }
        DataSet ds = bll.GetList(int.Parse(P), Pager.PageSize, WhereStr);
        Repeater1.DataSource = ds.Tables[0].DefaultView;
        Repeater1.DataBind();
        Pager.RecordCount = (int)ds.Tables[1].Rows[0][0];
        Pager.CurrentPageIndex = int.Parse(P);
        Pager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", Pager.CurrentPageIndex, Pager.PageCount, Pager.RecordCount, Pager.PageSize);
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string TypeId = Request.QueryString["TypeId"];
        muser = buser.GetCookie();

        if (TypeId == "" || TypeId == null)
        {
            TypeId = "1";
        }

        if (int.Parse(TypeId) > 4)
        {
            TypeId = "1";
        }
        int p = 0;

        if (this.Repeater1.Items.Count > 0)
        {
            for (int i = 0; i < this.Repeater1.Items.Count; i++)
            {
                if (((CheckBox)this.Repeater1.Items[i].FindControl("CheckBox1")).Checked)
                {
                    bll.UpdateDel(int.Parse(((TextBox)this.Repeater1.Items[i].FindControl("CID")).Text.ToString()), muser.UserID, int.Parse(TypeId));
                    p++;
                }
            }
            Function.ShowMsg(1, "<li>成功操作" + p + "项数据!</li><li><a href='Message/MessageList.aspx?TypeId=" + TypeId + "'>返回上一页</a></li>");
        }
        else
        {
            Function.ShowMsg(0, "<li>无任何数据可以操作</li><li><a href='Message/MessageList.aspx?TypeId=" + TypeId + "'>返回上一页</a></li>");
        }
    }

    /// <summary>
    /// 删除单一记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Repeater1_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        string TypeId = Request.QueryString["TypeId"];

        if(TypeId=="" || TypeId==null)
        {
            TypeId="1";
        }

        if(int.Parse(TypeId)>4)
        {
            TypeId="1";
        }

        if (e.CommandName == "Delete")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            bll.UpdateDel(id, ((M_User)buser.GetCookie()).UserID, int.Parse(TypeId));

            DataBaseList();
        }
    }

    public string GetIsRead(string IsRead)
    {
        string sGetIsRead = "";

        if (IsRead == "0")
        {
            sGetIsRead = "<font color=red><b>×</b></font>";
        }
        else
        {
            sGetIsRead = "<font color='#009933'><b>√</b></font>";
        }

        return sGetIsRead;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool PrintMode(int id)
    {
       string TypeId = Request.QueryString["TypeId"];

       if (TypeId == "1" || TypeId == "4")
        {
            if (id == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (id == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //搜索
    protected void Button2_Click(object sender, EventArgs e)
    {
        string sSearchId = SearchId.SelectedValue;
        string sTypeId = TypeId.SelectedValue;
        string sKeyWord = KeyWord.Text;

        Response.Redirect("MessageList.aspx?TypeId=" + sTypeId + "&SearchId=" + sSearchId + "&KeyWord=" + Function.UrlEncode(sKeyWord) + "");
        Response.End();
    }
}
