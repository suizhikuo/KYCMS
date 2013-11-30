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

public partial class System_label_SetSpecial : System.Web.UI.Page
{
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            AdminGroupBll.Power_Judge(6); 
            StyleBind();
            BindSpeacil();
        }
    }

    #region 绑定样式所有列表
    private void StyleBind()
    {
        B_Style bll = new B_Style();
        ddlStyle.DataSource = bll.GetStyleByModel(0);
        ddlStyle.DataTextField = "Name";
        ddlStyle.DataValueField = "StyleID";
        ddlStyle.DataBind();
    }
    #endregion

    #region 绑定专题
    private void BindSpeacil()
    {
        B_Special bll = new B_Special();
        DataTable dt = bll.GetAllSpecial();
        foreach (DataRow dr in dt.Rows)
        {
            string colname = dr["SpecialCName"].ToString();
            int colid = Convert.ToInt32(dr["ID"].ToString());
            int depth = int.Parse(dr["Depth"].ToString());
            for (int i = 0; i < depth; i++)
            {
                colname = "├┄" + colname;
            }
            ddlSpecial.Items.Add(new ListItem(colname, colid.ToString()));
        }
        ddlSpecial.Items.Insert(0, new ListItem("当前专题","0"));
    }
    #endregion
}
