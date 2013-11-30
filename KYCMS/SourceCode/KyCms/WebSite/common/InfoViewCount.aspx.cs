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
using Ky.BLL.CommonModel;
using Ky.Model;

public partial class common_InfoViewCount : System.Web.UI.Page
{
    B_InfoOper InfoOperBll = new B_InfoOper();
    B_InfoModel InfoModelBll = new B_InfoModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        int modelType = 0;
        int id = 0;
        if (!string.IsNullOrEmpty(Request.QueryString["ModelId"]))
        {
            try
            {
                modelType = int.Parse(Request.QueryString["ModelId"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
        {
            try
            {
                id = int.Parse(Request.QueryString["Id"]);
            }
            catch { }
        }
        if (modelType == 0 || id==0)
        {
            return;
        }
        M_InfoModel infoModel = InfoModelBll.GetModel(modelType);
        if (infoModel != null)
        {
            InfoOperBll.AddHitCount(infoModel.TableName, id);
        }
    }
}
