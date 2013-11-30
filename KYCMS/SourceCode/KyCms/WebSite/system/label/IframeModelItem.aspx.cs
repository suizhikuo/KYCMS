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

public partial class system_label_IframeModelItem : System.Web.UI.Page
{
    B_InfoModel InfoModelBll = new B_InfoModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        ModelBind();
    }

    //获得模型列表
    private void ModelBind()
    {
        repModelList.DataSource = InfoModelBll.GetList();
        repModelList.DataBind();
    }
}
