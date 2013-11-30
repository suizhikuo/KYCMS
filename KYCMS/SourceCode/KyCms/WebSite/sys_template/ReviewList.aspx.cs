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

public partial class sys_template_ReviewList : System.Web.UI.Page
{
    protected int id = 0;
    protected int modelType = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Request.Form["ModelType"] != null && Request.Form["ModelType"].Length != 0 && Request.Form["Id"] != null && Request.Form["Id"].Length != 0))
            Response.End();
        modelType = int.Parse(Request.Form["ModelType"]);
        id = int.Parse(Request.Form["Id"]);
        B_Review bll = new B_Review();
        DataTable dt = bll.GetList(modelType,id,true);
        repReviewList.DataSource = dt;
        repReviewList.DataBind();
    }
    //得到用记的名字
    public string GetName(string loginName)
    {
        if (loginName == "")
            return "匿名";
        return loginName;
    }

  
}
