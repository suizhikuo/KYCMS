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

public partial class user_ViewResume : System.Web.UI.Page
{
    B_User UserBll = new B_User();
    B_Create CreateBll = new B_Create();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            Response.Redirect(CreateBll.GetIndexUrl());
        }
        else
        {
            int id = Function.CheckInteger(Request.QueryString["id"]) ? int.Parse(Request.QueryString["id"]) : 0;
            DataTable data = UserBll.ViewResume("Ky_U_Job.[id]=" + id);
            foreach (DataRow dr in data.Rows)
            {
                litUserName.Text = lbTrueName.Text = Function.HtmlEncode(dr["TrueName"]);
                lbSex.Text = Function.HtmlEncode(dr["Sex"]);
                lbBirth.Text = Function.HtmlEncode(dr["Birthday"]);
                lbCity.Text = Function.HtmlEncode(dr["City"]);
                lbexperience.Text = Function.HtmlEncode(dr["experience"]);
                lbHeight.Text = Function.HtmlEncode(dr["Height"]);
                lbDegree.Text = Function.HtmlEncode(dr["Degree"]);
                lbAress.Text = Function.HtmlEncode(dr["Address"]);
                lbEmail.Text = Function.HtmlEncode(dr["Email"]);
                lbPhone.Text = Function.HtmlEncode(dr["Phone"]);
                lbWorktype.Text = Function.HtmlEncode(dr["Type"]);
                lbIndustry.Text = Function.HtmlEncode(dr["Industry"]);
                lbPosts.Text = Function.HtmlEncode(dr["Posts"]);
                lbPostsArea.Text = Function.HtmlEncode(dr["Area"]);
                lbPostsTypes.Text = Function.HtmlEncode(dr["Types"]);
                lbPostsMoney.Text = Function.HtmlEncode(dr["Money"]);
                lbTimes.Text = Function.HtmlEncode(dr["Times"]);
                lbDirection.Text = Function.HtmlEncode(dr["Drection"]);
                lbMore.Text = Function.HtmlEncode(dr["more"]);
                imgPic.ImageUrl = dr["Picture"].ToString();
                imgPic.AlternateText = dr["TrueName"] + "的照片";
                //lbProfessionType.Text = Function.HtmlEncode(dr["ProfessionalType"]);
                lbGeographical.Text = Function.HtmlEncode(dr["Geographical"]);
                lbQq.Text = Function.HtmlEncode(dr["qq"]);
            }
            UserBll.UpdateResume(id, 2);
        }
    }
}
