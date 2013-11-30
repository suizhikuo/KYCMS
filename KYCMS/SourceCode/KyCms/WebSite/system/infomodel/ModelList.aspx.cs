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
using Ky.Common;
using Ky.BLL;

public partial class system_infomodel_ModelList : System.Web.UI.Page
{
    private B_InfoModel InfoModelBll = new B_InfoModel();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminGroupBll.Power_Judge(35);
            Bind();
        }
    }

    private void Bind()
    {
        DataTable dt = InfoModelBll.GetList();
        RepModel.DataSource = dt.DefaultView;
        RepModel.DataBind();
        dt.Dispose();
    }

    protected void repModel_Delete(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int modelId = Convert.ToInt32(e.CommandArgument);
            bool flag = InfoModelBll.CheckExistsChannel(modelId);
            if (flag)
            {
                Function.ShowSysMsg(0, "<li>不能删除该模型，现有频道和频道回收站有频道属于该模型</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
            }
            InfoModelBll.Delete(modelId);
            Bind();
        }
    }

    protected string FormatIsSystem(object isSystem)
    {
        if (isSystem.ToString() != string.Empty)
        {
            return (bool)isSystem ? "<font style='color:red'>系统</font>" : "<font style='color:blue'>自定义</font>";
        }
        else
        {
            return string.Empty;
        }
    }

    protected bool FormatHidden(object isSystem)
    {
        if (isSystem.ToString() != string.Empty)
        {
            return (bool)isSystem ? false : true;
        }
        else
        {
            return false;
        }
    }
}
