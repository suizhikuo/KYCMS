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
using Ky.Common;
using Ky.Model;
using System.Text;
public partial class system_user_UserInfo : System.Web.UI.Page
{
    int UID = 0;
    B_Admin admin = new B_Admin();
    protected int I = 3;
    protected string JScript = "";
    M_User model = null;
    B_PowerGroup power = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
//        power.Power_Judge(17);
//        if (Request.QueryString["uid"] != null)
//        {
//            try
//            {
//                UID = int.Parse(Request.QueryString["uid"]);
//            }
//            catch { Response.Redirect("UserList.aspx?type=1"); }            
//            if (!IsPostBack)
//            {
//                B_User user = new B_User();
//                model = user.GetUser(UID);
//                BindData();
                
//                if (model.Type == 2)
//                {
//                    I = 2;
//                    Tab1.Visible = Tab2.Visible = false;
//                    Tbody1.Visible = Tbody2.Visible = false;
//                    Tbody3.Attributes.Remove("style");
//                    Tab3.Attributes.Remove("onclick");
//                }
//                else if (model.Type == 1)
//                {
//                    I = 3;
//                    Tab3.Visible = false;
//                    JScript = @"
//    <script type='text/javascript'>
//    
//function ShowTabs(ID)
//{                
//        for(var i=1;i<" + I + @";i++)
//        {
//           var tab = document.getElementById('Tab'+i);
//           tab.className='title5';
//           var tbody=document.getElementById('Tbody'+i);
//           tbody.style.display='none';
//           if(ID==i)
//           {
//             var targetTab=document.getElementById('Tab'+i);
//             targetTab.className='title6';
//             var targetBody=document.getElementById('Tbody'+i);
//             targetBody.style.display='';
//           }
//        }
//    }
//    </script>";
//                }

//            }
//        }

    }

    //void BindData()
    //{
    //    if (model != null)
    //    {
    //        lbLogName.Text = Function.HtmlEncode(model.LogName);
    //        lbNickName.Text = Function.HtmlEncode(model.NickName);
    //        lbEmail.Text = Function.HtmlEncode(model.Email);
    //        lbRealName.Text = Function.HtmlEncode(model.RealName);
    //        switch (model.Sex)
    //        {
    //            case 0:
    //                lbSex.Text = "男";
    //                break;
    //            case 1:
    //                lbSex.Text = "女";
    //                break;
    //            case 2:
    //            default:
    //                lbSex.Text = "保密";
    //                break;
    //        }
    //        lbBirthday.Text = Function.HtmlEncode(model.BirthDay);
    //        lbNation.Text = Function.HtmlEncode(model.Nationnality);
    //        lbNative.Text = Function.HtmlEncode(model.NativePlace);
    //        lbCity.Text = Function.HtmlEncode(model.Province + " " + model.City);
    //        lbAddress.Text = Function.HtmlEncode(model.Adress);
    //        lbPostCode.Text = Function.HtmlEncode(model.PostCode);
    //        lbAutoGraph.Text = Function.HtmlEncode(model.AutoGraph);
    //        imgHead.ImageUrl = Param.ApplicationRootPath + "/user/upload/userface/" + model.HeadImg;
    //        imgHead.ToolTip = model.LogName+" 的头像";
    //        lbNature.Text = Function.HtmlEncode(model.Nature);
    //        lbStature.Text = Function.HtmlEncode(model.Stature);
    //        lbLike.Text = Function.HtmlEncode(model.Like);
    //        lbOrgenazation.Text = Function.HtmlEncode(model.Organization);
    //        lbWork.Text = Function.HtmlEncode(model.Work);
    //        lbSchoolRecord.Text = Function.HtmlEncode(model.SchoolRecord);
    //        lbPhone.Text = Function.HtmlEncode(model.FPhone);
    //        lbMobile.Text = Function.HtmlEncode(model.Mobile);
    //        switch (model.IsMarry)
    //        {
    //            case 0:
    //                lbMarry.Text = "已婚";
    //                break;
    //            case 1:
    //                lbMarry.Text = "未婚";
    //                break;
    //            case 2:
    //            default:
    //                lbMarry.Text = "保密";
    //                break;
    //            case 3:
    //                lbMarry.Text = "离异";
    //                break;
    //        }
    //        lbQQ.Text = Function.HtmlEncode(model.QQ);
    //        lbMSN.Text = Function.HtmlEncode(model.Msn);
    //        lbYellowboy.Text = Function.HtmlEncode(model.YellowBoy.ToString());
    //        lbCharm.Text = Function.HtmlEncode(model.Charm.ToString());
    //        lbPopulation.Text = Function.HtmlEncode(model.Popularity.ToString());
    //        lbActive.Text = Function.HtmlEncode(model.Active.ToString());
    //        lbLock.Text = model.IsLock == true ? "锁定" : "正常";
    //        lbRegTime.Text = Function.HtmlEncode(model.RegTime.ToString());
    //        lbOnlineTime.Text = Function.HtmlEncode(model.OnlineTime.ToString());
    //        lbIsOnline.Text = model.OnlineType == true ? "在线" : "离线";
    //        lbLoginNum.Text = Function.HtmlEncode(model.LoginNum.ToString());
    //        lbLastLogTime.Text = Function.HtmlEncode(model.LastLoginTime.ToString());
    //        lbCPName.Text = Function.HtmlEncode(model.CPName);
    //        lbCPLogo.Text = Function.HtmlEncode(model.CPLogo);
    //        lbCPType.Text = Function.HtmlEncode(model.CPType);
    //        lbCPTrade.Text = Function.HtmlEncode(model.CPTrade);
    //        lbContact.Text = Function.HtmlEncode(model.CPContact);
    //        lbCNEmail.Text = Function.HtmlEncode(model.CPEmail);
    //        lbFax.Text = Function.HtmlEncode(model.CPFax);
    //        lbCPAddress.Text = Function.HtmlEncode(model.CPAddress);
    //        lbCPSite.Text = Function.HtmlEncode(model.CPSite);
    //        lbCPDescription.Text = Function.HtmlEncode(model.CPDescription);
    //        lbCPSize.Text = Function.HtmlEncode(model.CPSize.ToString());
    //        lbCPPerson.Text = Function.HtmlEncode(model.CPArtificialPerson);
    //        lbCPLicense.Text = Function.HtmlEncode(model.CPLicense);
    //    }
    //}
}
