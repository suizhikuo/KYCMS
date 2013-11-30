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

public partial class system_collection_CollectionManager : System.Web.UI.Page
{
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_Collection CollectionBll = new B_Collection();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(48);
        if(!IsPostBack)
        {
            CollectionBind();    
        }
    }

    #region 绑定采集
    private void CollectionBind()
    {
        repCollection.DataSource = CollectionBll.GetList();
        repCollection.DataBind();
    }
    #endregion

    protected void repCollection_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        HiddenField hidCollection = e.Item.FindControl("hidCollectionId") as HiddenField;
        CollectionBll.Delete(int.Parse(hidCollection.Value));
        CollectionBind();
    }
}
