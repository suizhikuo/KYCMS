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
using System.Net;
using System.Text;
using System.IO;
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class system_SystemInfo : System.Web.UI.Page
{
    B_Admin AdminBll = new B_Admin();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    M_Admin AdminModel = null;
    M_LoginAdmin LoginAdminModel = null;
    M_PowerGroup AdminGroupModel = null;
    B_KyCommon KyCommonBll = new B_KyCommon();
    B_Channel Channel = new B_Channel();
    B_User UserBll = new B_User();
    B_UserGroupModel UserGroupModelBll = new B_UserGroupModel();
    B_InfoModel InfoModelBll = new B_InfoModel();
    DataTable InfoModelDt = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminBll.CheckMulitLogin();
        LoginAdminModel = AdminBll.GetLoginModel();
        AdminModel = AdminBll.GetModel(LoginAdminModel.UserId);
        litUserName.Text = AdminModel.UserName;
        AdminGroupModel = AdminGroupBll.Show(AdminModel.GroupId);
        litGroupName.Text = AdminGroupModel.PowerName;

        lbNotice.Visible = true;
        lbNotice.Text = "<script language=\"javascript\" src=\"http://info.kycms.com/notice_info.js\"></script>";
        string dateStr = DateTime.Today.ToString("yyyy年MM月dd日");
        int weekNumber = (int)DateTime.Today.DayOfWeek;
        string weekStr = string.Empty;

        switch (weekNumber)
        {
            default:
            case 0: weekStr = "星期日"; break;
            case 1: weekStr = "星期一"; break;
            case 2: weekStr = "星期二"; break;
            case 3: weekStr = "星期三"; break;
            case 4: weekStr = "星期四"; break;
            case 5: weekStr = "星期五"; break;
            case 6: weekStr = "星期六"; break;
        }

        litDate.Text = dateStr + " " + weekStr;
        StringBuilder sb = new StringBuilder();
        sb.Append("共有会员： ");
        sb.Append(UserBll.GetUserCount(0, 0));
        sb.Append("人&nbsp;&nbsp;&nbsp;");

        DataTable userGroupModelDt = UserGroupModelBll.GetAll();
        for (int i = 0; i < userGroupModelDt.Rows.Count; i++)
        {
            DataRow dr = userGroupModelDt.Rows[i];
            int typeId = int.Parse(dr["id"].ToString());
            string name = "[" + dr["name"].ToString() + "]";

            sb.Append(name);
            sb.Append("：");
            int count = UserBll.GetUserCount(typeId, 0);
            sb.Append(count);
            if (i == userGroupModelDt.Rows.Count - 1)
            {
                sb.Append("人&nbsp;&nbsp;&nbsp;");
            }
            else
            {
                sb.Append("人&nbsp;&nbsp;&nbsp;");
            }

        }
        LitCount.Text = sb.ToString();

        //DataTable dt = InfoModelBll.GetList();
        //InfoModelDt = new DataTable();
        //InfoModelDt.Columns.Add("name", typeof(string));
        //InfoModelDt.Columns.Add("total", typeof(string));
        //InfoModelDt.Columns.Add("nocheck", typeof(string));
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    DataRow dr = dt.Rows[i];
        //    string name = dr["modelname"].ToString();
        //    string tableName = dr["tablename"].ToString();
        //    int totalCount = InfoModelBll.GetModelInfoCount(tableName, "[status] in(0,1,2,3)");
        //    int noCheckCount = InfoModelBll.GetModelInfoCount(tableName,"[status] in(0,1,2)");
        //    DataRow infoModelDr = InfoModelDt.NewRow();
        //    infoModelDr["name"] = name;
        //    infoModelDr["total"] = totalCount;
        //    infoModelDr["nocheck"] = noCheckCount;
        //    InfoModelDt.Rows.Add(infoModelDr);
        //}
        //repCount.DataSource = InfoModelDt.DefaultView;
        //repCount.DataBind();
        //InfoModelDt.Dispose();
    }
        

        


    protected void repCount_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            int index = e.Item.ItemIndex+1;
            if (index != InfoModelDt.Rows.Count && index % 2 == 0)
            {
                e.Item.Controls.Add(new LiteralControl("</tr><tr>"));
            }
        }
    }
   
}
