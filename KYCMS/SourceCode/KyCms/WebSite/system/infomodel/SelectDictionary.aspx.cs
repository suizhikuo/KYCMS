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
using System.Text;
using Ky.BLL;
using Ky.Common;
using Ky.Model;

public partial class system_infomodel_SelectDictionary : System.Web.UI.Page
{
    B_Dictionary bll = new B_Dictionary();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_Dictionary DicBll = new B_Dictionary();
    int Id = 0;
    int TypeId = 0;
    protected string ControlId;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        string qryId = Request.QueryString["id"];
        if (!string.IsNullOrEmpty(qryId) && Function.CheckInteger(qryId))
        {
            Id = int.Parse(qryId);
        }

        string TypeId1 = Request.QueryString["TypeId"];
        if (!string.IsNullOrEmpty(TypeId1) && Function.CheckInteger(TypeId1))
        {
            TypeId = int.Parse(TypeId1);
        }
        ControlId = Request.QueryString["ControlId"];
        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        DataTable data = Id == 0 ? DicBll.GetParents() : DicBll.GetDictionary(Id);
        rptDictionary.DataSource = data;
        rptDictionary.DataBind();
    }

    protected void rptDictionary_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            if (TypeId == 1)
            {
                StringBuilder sb = new StringBuilder();

                DataTable dt = DicBll.GetDictionary(Convert.ToInt32(e.CommandArgument));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == dt.Rows.Count - 1)
                    {
                        sb.Append(dt.Rows[i]["DicName"].ToString());
                    }
                    else
                    {
                        sb.Append(dt.Rows[i]["DicName"].ToString() + "\\r\\n");
                    }
                }

                Response.Write("<script>window.dialogArguments.$('" + ControlId + "').value='" + sb.ToString() + "';window.close();</script>");
                Response.End();
            }
            else
            {
                if (TypeId == 2)
                {
                    M_Dictionary model = new M_Dictionary();
                    model = DicBll.GetModel(Convert.ToInt32(e.CommandArgument));
                    Response.Write("<script>window.dialogArguments.$('" + ControlId + "_Show').value='" + model.DicName + "';window.dialogArguments.$('" + ControlId + "').value='" + Convert.ToInt32(e.CommandArgument) + "';window.close();</script>");
                    Response.End();
                }
            }
        }
    }
}
