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
using Ky.Common;
using Ky.BLL;
using Ky.Model;

public partial class user_Money_MoneySend : System.Web.UI.Page
{
    private M_User Muser = new M_User();
    private B_User Buser = new B_User();
    private B_SiteInfo Bsiteinfo = new B_SiteInfo();
    private M_Site Msite = new M_Site();

    protected void Page_Load(object sender, EventArgs e)
    {
        Literal1.Text = "";
        if (!Page.IsPostBack)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(user_Money_MoneyChange));

            Muser = Buser.GetCookie();

            LoginName.Text = Muser.LogName;

            //
            M_User Muser_1 = new M_User();
            Muser_1 = Buser.GetUser(Muser.UserID);

            //判断过期时间
            if (Muser_1.ExpireTime < DateTime.Now)
            {
                UserType.Text = "普通";
                SpareDay.Text = "0天";
            }
            else
            {
                UserType.Text = "包月";
            }

            ExpireTime.Text = Muser_1.ExpireTime.ToString();
            Money.Text = Muser_1.YellowBoy.ToString();
            IntegralLable.Text = Muser_1.Integral.ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string MyChangeValue = ChangeValue.Text;

        string MyMoneyType = MoneyType.SelectedValue;
        string MySendUser = SendUser.Text;
        string MyMoneyType_1 = MoneyType.SelectedItem.Text;
        string MyGUnitName = "";

        //汇率
        Msite = Bsiteinfo.GetSiteModel();

        if (MyMoneyType == "1")
        {
            MyGUnitName = Msite.GUnitName.ToString();
        }

        if (MyMoneyType == "2")
        {
            MyGUnitName = "点";
        }

        if (MyMoneyType == "3")
        {
            MyGUnitName = "天";
        }

        string MyPassWord = PassWord.Text;
        //
        Muser = Buser.GetCookie();

        M_User Muser_1 = new M_User();
        int UserId = Muser.UserID;
        Muser_1 = Buser.GetUser(UserId);

        #region 验证判断
        if (!Function.CheckNumberNotZero(MyChangeValue))
        {
            Function.ShowMsg(0, "<li>请输入一个大于0的整数</li><li><a href='Money/MoneySend.aspx'>返回上一步</a></li>");
        }

        if (MyMoneyType == "0")
        {
            Function.ShowMsg(0, "<li>请选择转换栏目</li><li><a href='Money/MoneySend.aspx'>返回上一步</a></li>");
        }

        if (MySendUser == "0")
        {
            Function.ShowMsg(0, "<li>请输入赠送用户名称</li><li><a href='Money/MoneySend.aspx>返回上一步</a></li>");
        }

        if (MyPassWord == "" || MyPassWord == null)
        {
            Function.ShowMsg(0, "<li>请输入登陆密码</li><li><a href='Money/MoneySend.aspx'>返回上一步</a></li>");
        }


        if (Muser_1.UserPwd != Function.MD5Encrypt(MyPassWord))
        {
            Function.ShowMsg(0, "<li>登陆密码输入错误</li><li><a href='Money/MoneySend.aspx'>返回上一步</a></li>");
        }
        #endregion

        #region 判断用户输入赠送用户的合法性

        B_Money BMoney = new B_Money();

        if (Buser.GetUser(MySendUser) == null)
        {
            Function.ShowMsg(0, "<li>赠送的用户不存在</li><li><a href='Money/MoneySend.aspx'>返回上一步</a></li>");
        }
        else
        {
            int SendUserId=Buser.GetUser(MySendUser).UserID;
            if (MyMoneyType == "1")
            {
                if (Muser_1.YellowBoy < int.Parse(MyChangeValue))
                {
                    Function.ShowMsg(0, "<li>金币不足,请重新输入</li><li><a href='Money/MoneySend.aspx'>返回上一步</a></li>");
                }
                else
                {
                    BMoney.YellowBoy(decimal.Parse(MyChangeValue), SendUserId);
                    BMoney.YellowBoy(-decimal.Parse(MyChangeValue), UserId);
                }
            }

            if (MyMoneyType == "2")
            {
                if (Muser_1.Integral < int.Parse(MyChangeValue))
                {
                    Function.ShowMsg(0, "<li>积分不足,请重新输入</li><li><a href='Money/MoneySend.aspx'>返回上一步</a></li>");
                }
                else
                {
                    BMoney.Integral(int.Parse(MyChangeValue), SendUserId);
                    BMoney.Integral(-int.Parse(MyChangeValue), UserId);
                }
            }

            if (MyMoneyType == "3")
            {
                TimeSpan ts1 = new TimeSpan(Muser_1.ExpireTime.Ticks);
                TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);

                if (ts1.Subtract(ts2).Days < int.Parse(MyChangeValue))
                {
                    Function.ShowMsg(0, "<li>有效期天数不足,请重新输入</li><li><a href='Money/MoneySend.aspx'>返回上一步</a></li>");
                }
                else
                {
                    BMoney.ExpireTime(int.Parse(MyChangeValue), SendUserId);
                    BMoney.ExpireTime(-int.Parse(MyChangeValue), UserId);
                }
            }
        }

        #endregion
        //记录日志
        B_UserLog logBll = new B_UserLog();
        M_UserLog logModel = new M_UserLog();
        logModel.AddTime = DateTime.Now;
        logModel.Description = "成功赠送给[" + MySendUser + "]" + MyChangeValue + "" + MyGUnitName + "" + MyMoneyType_1;
        logModel.InfoId = 0;
        logModel.ModelType = 0;
        logModel.Point = 0;
        logModel.UserId = Muser_1.UserID;
        logModel.UserName = Muser_1.LogName;
        logBll.Add(logModel);

        Function.ShowMsg(1, "<li>成功赠送给[" + MySendUser + "]" + MyChangeValue + "" + MyGUnitName + "" + MyMoneyType_1 + "</li><li><a href='Money/MoneySend.aspx'>返回财富赠送</a></li>");
    }
}
