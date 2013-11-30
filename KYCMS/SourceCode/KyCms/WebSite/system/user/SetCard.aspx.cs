using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using Ky.Model;
using Ky.BLL;
using Ky.Common;

public partial class System_user_AddCard : System.Web.UI.Page
{
    B_Card card = new B_Card();
    B_Admin admin = new B_Admin();
    M_LoginAdmin adminModel;
    B_PowerGroup power = new B_PowerGroup();
    B_User user = new B_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        power.Power_Judge(5);
        adminModel = admin.GetLoginModel();
        LitMsg.Text = string.Empty;
        if (!IsPostBack)
        {
            if (Request.QueryString["action"] != null && Request.QueryString["key"] != null)
            {
                if (Request.QueryString["action"] == "view")
                {
                    BindCardByAccout(Function.UrlDecode(Request.QueryString["key"].ToString()));
                    mvAddCard.ActiveViewIndex = 2;
                }
            }
            else
            {
                mvAddCard.ActiveViewIndex = 0;
                txtOverdueDate.Text = DateTime.Now.AddMonths(1).ToShortDateString();
                BindCardType(ref ddlCardType);
            }
        }
    }

    /// <summary>
    /// 查看某张卡的信息
    /// </summary>
    /// <param name="key"></param>
    void BindCardByAccout(string key)
    {
        M_Card model = card.GetCard(key);
        M_User userModel = null;
        if (model != null)
        {
            userModel=user.GetUser(model.UserID);
            lbviewAccount.Text = model.CardAccount;
            lbviewAdminID.Text = model.AdminID.ToString();
            lbviewAdminN.Text = model.AdminName;
            lbviewDay.Text = model.CardDay.ToString();
            lbviewIsused.Text = model.IsUsed == true ? "是" : "否";
            lbviewOverdue.Text = model.OverdueDate.ToShortDateString();
            lbviewPoint.Text = model.CardPoint.ToString();
            lbviewPwd.Text = model.Password;
            lbviewType.Text = model.Type == CardType.PointCard ? "点卡" : "月卡";
            lbviewUID.Text = model.UserID == 0 ? "-" : model.UserID.ToString();
            lbviewUN.Text = userModel == null ? "-" : userModel.LogName;
            lbViewTitle.Text = model.CardAccount + " 的信息";
        }
    }

    /// <summary>
    /// 绑定卡类型
    /// </summary>
    void BindCardType(ref DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("点卡", ((int)CardType.PointCard).ToString()));//点卡为0,月卡为1,与M_Card.cs中的定义一致
        ddl.Items.Add(new ListItem("月卡", ((int)CardType.MonthCard).ToString()));
    }

    /// <summary>
    /// 添加新卡
    /// </summary>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (adminModel != null)
            {
                M_Card model = new M_Card();
                model.AdminName = adminModel.AdminName;
                model.AdminID = adminModel.UserId;
                int cardType = int.Parse(ddlCardType.SelectedValue);
                if (cardType == 0)//点卡
                {
                    model.Type = CardType.PointCard;
                    model.CardDay = 0;
                    try
                    {
                        model.CardPoint = int.Parse(txtPoint.Text);
                    }
                    catch
                    {
                        Function.ShowSysMsg(0,"<li>对不起，点数输入格式不正确。请重新输入</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
                    }
                }
                if (cardType == 1)//月卡
                {
                    model.Type = CardType.MonthCard;
                    try
                    {
                        model.CardDay = int.Parse(txtDay.Text);
                    }
                    catch
                    {
                        Function.ShowSysMsg(0, "<li>对不起，天数输入格式不正确。请重新输入</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
                    }
                    model.CardPoint = 0;
                }
                model.CardAccount = GeneratPwd(txtCardPrifix.Text);                
                model.IsUsed = false;
                try
                {
                    model.OverdueDate = DateTime.Parse(txtOverdueDate.Text).Date;
                }
                catch
                {
                    Function.ShowSysMsg(0, "<li>对不起，过期日期栏输入格式不正确。请重新输入</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
                }
                
                model.Password = txtPassword.Text;

                string cardAccount = card.Add(model);

                lbAccount.Text = cardAccount;
                lbPwd.Text = txtPassword.Text;
                lbType.Text = ddlCardType.SelectedItem.Text;
                if (cardType == 1)
                {
                    B_Log.Add(LogType.Add, "新增月卡成功。卡号："+cardAccount);
                }
                else if (cardType == 0)
                {
                    B_Log.Add(LogType.Add, "新增点卡成功。卡号："+cardAccount);
                }
                mvAddCard.ActiveViewIndex = 1;
            }
        }
        else
        {
            Response.Redirect("../Login.aspx");
        }
    }

    /// <summary>
    /// 批量生成卡后,转到添加新卡
    /// </summary>
    protected void lnkbtnGoOn_Click(object sender, EventArgs e)
    {
        mvAddCard.ActiveViewIndex = 0;
    }

    /// <summary>
    /// 查看卡列表
    /// </summary>
    protected void btnViewList_Click(object sender, EventArgs e)
    {
        Response.Redirect("Card.aspx");
    }

    /// <summary>
    /// 转到添加一张卡
    /// </summary>
    protected void btnAddm_Click(object sender, EventArgs e)
    {
        txtPassword.Text = "";
        BindCardType(ref ddlCardType);
        mvAddCard.ActiveViewIndex = 0;
    }

    /// <summary>
    /// 批量生成时根据规则产生密码
    /// </summary>
    /// <returns>密码</returns>
    string GeneratPwd(string input)
    {        
        string serial = "";
        if (!string.IsNullOrEmpty(input))
        {
            string str = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            string[] codes = str.Split(',');
            
            Random rnd = new Random();
            char[] chs = input.ToCharArray();
            for (int i = 0; i < chs.Length; i++)
            {
                switch (chs[i])
                {
                    case '@':
                        serial += codes[rnd.Next(10, 35)].ToUpper();
                        break;
                    case '#':
                        serial += codes[rnd.Next(0, 9)];
                        break;
                    case '$':
                        serial += codes[rnd.Next(0, 35)].ToUpper();
                        break;
                    default:
                        serial += chs[i];
                        break;
                }
            }            
        }
        return serial;
    }

    /// <summary>
    /// 批量生成
    /// </summary>
    protected void btnAddMore_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

                M_Card model = new M_Card();

                model.AdminName = adminModel.AdminName;
                model.AdminID = adminModel.UserId;
                int cardType = int.Parse(ddlMoreType.SelectedValue);
                if (cardType == 0)//点卡
                {
                    model.Type = CardType.PointCard;
                    model.CardDay = 0;
                    try
                    {
                        model.CardPoint = int.Parse(txtMorePoint.Text);
                    }
                    catch
                    {
                        Function.ShowSysMsg(0, "<li>对不起，点数输入格式不正确。请重新输入</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
                    }
                }
                if (cardType == 1)//月卡
                {
                    model.Type = CardType.MonthCard;
                    try
                    {
                        model.CardDay = int.Parse(txtMoreDay.Text);
                    }
                    catch
                    {
                        Function.ShowSysMsg(0, "<li>对不起，天数输入格式不正确。请重新输入</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
                    }
                    model.CardPoint = 0;
                }                                
                model.IsUsed = false;
                try
                {
                    model.OverdueDate = DateTime.Parse(txtMoreOverdue.Text);
                }
                catch
                {
                    Function.ShowSysMsg(0, "<li>对不起，过期日期栏输入格式不正确。请重新输入</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
                }

                int num = 0;
                try
                {
                    num = int.Parse(txtMoreNum.Text);
                }
                catch
                {
                    Function.ShowSysMsg(0, "<li>对不起，张数输入格式不正确。请重新输入</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
                }
                string[] accounts = new string[num];
                string[] pwds = new string[num];

                for (int i = 0; i < num; i++)
                {
                    string pwd = GeneratPwd(txtMorePwd.Text);
                    model.Password = pwd;
                    model.CardAccount = GeneratPwd(txtMorePrifix.Text);
                    string ac = card.Add(model);
                    accounts[i] = ac;
                    pwds[i] = pwd;
                    System.Threading.Thread.Sleep(50);
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("卡号",typeof(string));
                dt.Columns.Add("密码",typeof(string));
                for (int i = 0; i < accounts.Length; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = i + 1;
                    dr[1] = accounts[i];
                    dr[2] = pwds[i];
                    dt.Rows.Add(dr);
                }
                gvListMore.DataSource = dt;
                gvListMore.DataBind();
                lbMoreCount.Text = gvListMore.Rows.Count.ToString();
                mvAddCard.ActiveViewIndex = 4;
            }

        else
        {
            Response.Redirect("../Login.aspx");
        }
    }

    /// <summary>
    /// 设置卡列表鼠标样式
    /// </summary>
    protected void gvListMore_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='tdbgmouseover'");
            e.Row.Attributes.Add("onmouseout", "this.className='tdbg'");
        }
    }

    /// <summary>
    /// 转到批量添加
    /// </summary>
    protected void lnkbtnMore_Click(object sender, EventArgs e)
    {
        BindCardType(ref ddlMoreType);
        txtMoreOverdue.Text = DateTime.Now.AddMonths(1).ToShortDateString();
        mvAddCard.ActiveViewIndex = 3;        
    }
}
