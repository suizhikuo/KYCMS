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

using System.Data.SqlClient;
using Ky.SQLServerDAL;
using Ky.BLL;
using Ky.Model;

public partial class sys_template_TouJianLi : System.Web.UI.Page
{
    B_User UserBll = new B_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!UserBll.IsLogin())
        {
            Response.Write(UserBll.IsLogin());
        }
        else
        {
            M_User UserM = new M_User();
            UserM = UserBll.GetCookie();
            int UserId = int.Parse(UserM.UserID.ToString());
            
            //断断用户是否是企业用户
            string sqlUserType = "Select TypeId From KyUsers Where UserId='"+UserId+"'";
            DataTable userTypeDt = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy,CommandType.Text,sqlUserType,null);

            if (userTypeDt.Rows[0]["TypeId"].ToString() == "1")
            {
                //判断用户是否有简历存在
                string sqlStrjob = "select id from Ky_U_job where Uid='" + UserId + "'";
                DataTable dtjob = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.Text, sqlStrjob, null);
                if (dtjob.Rows.Count == 0)
                {
                    Response.Write("Not");
                }
                else
                {
                    string UserName = UserM.LogName;
                    int Status = 1;
                    string id = Request.QueryString["qId"].ToString();

                    string sqlStr = "Select * from Ky_U_Recruitment Where [Id]=" + id;
                    DataTable dt = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.Text, sqlStr, null);
                    int uId = int.Parse(dt.Rows[0]["Uid"].ToString());
                    string uName = dt.Rows[0]["dwname"].ToString();
                    int userType = (int)dt.Rows[0]["UserType"];

                    DateTime addTime = DateTime.Now;
                    UserBll.InsertResume(UserId, UserName, uId, uName,userType, int.Parse(id), Status, addTime);
                    Response.Write("True");
                }
            }
            else
            {
                Response.Write("NotUser");
            }
        }
    }
}
