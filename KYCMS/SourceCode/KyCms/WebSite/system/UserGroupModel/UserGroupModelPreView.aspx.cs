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
using Ky.BLL.CommonModel;
using Ky.Model;
using Ky.Common;
using Ky.BLL;

public partial class system_UserGroupModel_UserGroupModelPreView : System.Web.UI.Page
{
    private M_UserGroupModel MUserGroupModel = new M_UserGroupModel();
    private B_UserGroupModel BUserGroupModel = new B_UserGroupModel();
    protected int ModelId = 0;
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminGroupBll.Power_Judge(49);

            if (!string.IsNullOrEmpty(Request.QueryString["ModelId"]))
            {
                try
                {
                    ModelId = int.Parse(Request.QueryString["ModelId"]);
                }
                catch { }
            }

            MUserGroupModel = BUserGroupModel.GetModel(ModelId);
            ModelHtml.Text = MUserGroupModel.ModelHtml;
        }
    }
}
