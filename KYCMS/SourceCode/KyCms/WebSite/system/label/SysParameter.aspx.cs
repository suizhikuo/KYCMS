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

public partial class System_label_SysParameter : System.Web.UI.Page
{
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_Dictionary dictionary = new B_Dictionary();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(6);
        if (!IsPostBack)
        {
            linkBind();
        }
    }

    private void linkBind()
    {
        ddlLink.Items.Add(new ListItem("所有链接","0"));
        ddlLink.Items.Add(new ListItem("-----按类型筛选",""));
        ddlLink.Items.Add(new ListItem("文字链接","1"));
        ddlLink.Items.Add(new ListItem("图片链接","2"));
        DataTable dt = dictionary.GetDictionary(73);
        if (dt != null)
        {
            ddlLink.Items.Add(new ListItem("------按分类筛选", ""));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlLink.Items.Add(new ListItem(dt.Rows[i]["DicName"].ToString(), dt.Rows[i]["Id"].ToString()));
            }
        }
    }
}
