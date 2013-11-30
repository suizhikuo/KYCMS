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

public partial class user_Money_MoneyChange : System.Web.UI.Page
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

            Muser=Buser.GetCookie();

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
                //SpareDay.Text = Function.DateDiff(Muser_1.ExpireTime, DateTime.Now);
            }

            ExpireTime.Text = Muser_1.ExpireTime.ToString();
            Money.Text = Muser_1.YellowBoy.ToString();
            IntegralLable.Text = Muser_1.Integral.ToString();

            //汇率
            Msite=Bsiteinfo.GetSiteModel();

            //积分
            UserIntegral.Text = Msite.G_Score.ToString();
            UserIntegral_1.Text = Msite.G_Score.ToString();
            UserIntegral_2.Text = Msite.G_Score.ToString();
      

            //金币
            UserYellowBoy.Text = Msite.GNumber.ToString();
            UserYellowBoy_1.Text = Msite.GNumber.ToString();
            UserYellowBoy_2.Text = Msite.GNumber.ToString();
            GUnitName.Text = Msite.GUnitName.ToString();
            GUnitName_1.Text = Msite.GUnitName.ToString();
            GUnitName_9.Text = Msite.GUnitName.ToString();

            //有效期
            UserExpireDay.Text = Msite.G_Day.ToString();
            UserExpireDay_1.Text = Msite.G_Day.ToString();
            UserExpireDay_2.Text = Msite.G_Day.ToString();            
        }
    }

    [AjaxPro.AjaxMethod]
    public string GetTimeString(string Str)
    {
        DateTime dt=new DateTime();
        dt = DateTime.Parse(Str);

        if (dt < DateTime.Now)
        {
            return "0天";
        }
        else
        {
            return Function.DateDiff(dt, DateTime.Now);
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string MyChangeValue = ChangeValue.Text;

        string MyMoneyType = MoneyType.SelectedValue;
        string MyMoneyType1 = MoneyType1.SelectedValue;

        string MyPassWord = PassWord.Text;
        //
        Muser = Buser.GetCookie();

        M_User Muser_1 = new M_User();
        int UserId=Muser.UserID;
        Muser_1 = Buser.GetUser(UserId);

        string MyUserIntegral=UserIntegral.Text;
        string MyUserYellowBoy=UserYellowBoy.Text;
        string MyUserExpireDay=UserExpireDay.Text;

        string SuLabel = "";
        string SucLabel = "";
        string SucLabelValue = "";

        #region 验证判断
        if (!Function.CheckNumberNotZero(MyChangeValue))
        {
            Function.ShowMsg(0, "<li>请输入一个大于0的整数</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }

        if (MyMoneyType == "0" || MyMoneyType1 == "0")
        {
            Function.ShowMsg(0, "<li>请选择转换栏目</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }

        if (MyPassWord == "" || MyPassWord == null)
        {
            Function.ShowMsg(0, "<li>请输入登陆密码</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }


        if (Muser_1.UserPwd != Function.MD5Encrypt(MyPassWord))
        {
            Function.ShowMsg(0, "<li>登陆密码输入错误</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        #endregion

        B_Money BMoney = new B_Money();

        #region 数值判断
        #region 金币判断
        if (MyMoneyType == "1")    //如果是金币
        {
            SuLabel = "" + GUnitName.Text + "金币";

            if (Muser_1.YellowBoy < int.Parse(MyChangeValue))
            {
                Function.ShowMsg(0, "<li>金币不足,请重新输入</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
            else
            {
                //金币
                if (MyMoneyType1=="1")
                {
                    Function.ShowMsg(0, "<li>金币无需再次换成金币</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                }

                //积分
                if (MyMoneyType1 == "2")
                {
                    BMoney.YellowBoy(-decimal.Parse(MyChangeValue), UserId);    //更新金币(减少)
                    BMoney.Integral(int.Parse(MyChangeValue) * int.Parse(MyUserIntegral) / int.Parse(MyUserYellowBoy), UserId); //积分

                    SucLabel = "点积分";
                    SucLabelValue = (int.Parse(MyChangeValue) * int.Parse(MyUserIntegral) / int.Parse(MyUserYellowBoy)).ToString();
                }

                //有效期
                if (MyMoneyType1 == "3")
                {
                    BMoney.YellowBoy(-decimal.Parse(MyChangeValue), UserId);    //更新金币(减少)
                    BMoney.ExpireTime(int.Parse(MyChangeValue) * int.Parse(MyUserExpireDay) / int.Parse(MyUserYellowBoy), UserId); //有效期

                    SucLabel = "天有效期";
                    SucLabelValue = (int.Parse(MyChangeValue) * int.Parse(MyUserExpireDay) / int.Parse(MyUserYellowBoy)).ToString();
                }
            }
        }
        #endregion

        #region 积分判断
        if (MyMoneyType == "2")    //如果是积分
        {
            SuLabel = "点积分";
            if (Muser_1.Integral < int.Parse(MyChangeValue))
            {
                Function.ShowMsg(0, "<li>积分不足,请重新输入</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
            else
            {
                //积分
                if (MyMoneyType1 == "2")
                {
                    Function.ShowMsg(0, "<li>积分无需再次换成积分</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                }

                //金币
                if (MyMoneyType1 == "1")
                {
                    BMoney.Integral(-int.Parse(MyChangeValue), UserId);    //更新积分(减少)
                    BMoney.YellowBoy(decimal.Parse(MyChangeValue) * decimal.Parse(MyUserYellowBoy) / decimal.Parse(MyUserIntegral), UserId); //金币

                    SucLabel = "" + GUnitName.Text + "金币";
                    SucLabelValue = (int.Parse(MyChangeValue) * decimal.Parse(MyUserYellowBoy) / int.Parse(MyUserIntegral)).ToString();
                }

                //有效期
                if (MyMoneyType1 == "3")
                {
                    BMoney.Integral(-int.Parse(MyChangeValue), UserId);    //更新积分(减少)
                    BMoney.ExpireTime(int.Parse(MyChangeValue) * int.Parse(MyUserExpireDay) / int.Parse(MyUserIntegral), UserId); //有效期.

                    SucLabel = "天有效期";
                    SucLabelValue = (int.Parse(MyChangeValue) * int.Parse(MyUserExpireDay) / int.Parse(MyUserIntegral)).ToString();
                }
            }
        }
        #endregion

        #region 有效期判断
        if (MyMoneyType == "3")    //如果是有效期
        {
            SuLabel = "天有效期";
            TimeSpan ts1 = new TimeSpan(Muser_1.ExpireTime.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);

            if (ts1.Subtract(ts2).Days < int.Parse(MyChangeValue))
            {
                Function.ShowMsg(0, "<li>有效期天数不足,请重新输入</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            }
            else
            {
                //有效期
                if (MyMoneyType1 == "3")
                {
                    Function.ShowMsg(0, "<li>有效期无需再次换成有效期</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                }

                //金币
                if (MyMoneyType1 == "1")
                {
                    BMoney.ExpireTime(-int.Parse(MyChangeValue), UserId);    //更新有效期(减少)
                    BMoney.YellowBoy(decimal.Parse(MyChangeValue) * decimal.Parse(MyUserYellowBoy) / decimal.Parse(MyUserExpireDay), UserId); //金币

                    SucLabel = "" + GUnitName.Text + "金币";
                    SucLabelValue = (decimal.Parse(MyChangeValue) * decimal.Parse(MyUserYellowBoy) / int.Parse(MyUserExpireDay)).ToString();
                }

                //积分
                if (MyMoneyType1 == "2")
                {
                    BMoney.ExpireTime(-int.Parse(MyChangeValue), UserId);    //更新积分(减少)
                    BMoney.Integral(int.Parse(MyChangeValue) * int.Parse(MyUserIntegral) / int.Parse(MyUserExpireDay), UserId); //积分

                    SucLabel = "点积分";
                    SucLabelValue = (int.Parse(MyChangeValue) * int.Parse(MyUserIntegral) / int.Parse(MyUserExpireDay)).ToString();
                }
            }
        }
        #endregion
        #endregion

        //记录日志
        B_UserLog logBll = new B_UserLog();
        M_UserLog logModel = new M_UserLog();
        logModel.AddTime = DateTime.Now;
        logModel.Description = "成功将" + MyChangeValue + "" + SuLabel + "兑换成" + SucLabelValue + "" + SucLabel;
        logModel.InfoId = 0;
        logModel.ModelType = 0;
        logModel.Point = 0;
        logModel.UserId = Muser_1.UserID;
        logModel.UserName = Muser_1.LogName;
        logBll.Add(logModel);

        Function.ShowMsg(1, "<li>成功将" + MyChangeValue + "" + SuLabel + "兑换成" + SucLabelValue + "" + SucLabel + "</li><li><a href='Money/MoneyChange.aspx'>返回财富兑换</a></li>");
    }
}
