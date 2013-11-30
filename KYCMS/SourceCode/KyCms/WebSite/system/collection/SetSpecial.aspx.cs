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

public partial class system_collection_SetSpecial : System.Web.UI.Page
{
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_Special bll = new B_Special();
    private int Chid=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(48);
        Response.Cache.SetNoStore();
        if (Request.QueryString["colid"] != null && Request.QueryString["colid"].Length!=0)
            Chid = int.Parse(Request.QueryString["colid"]);
        BindSpeacil();
    }

    #region  绑定专题
    public void BindSpeacil()
    {
        B_Special specialBll = new B_Special();
        lBoxTopicIdStr.Items.Clear();
        DataTable dt = specialBll.GetChannelSpecial(Chid);
        DataView dvParent = new DataView(dt);
        dvParent.RowFilter = "ParentId=0";
        for (int i = 0; i < dvParent.Count; i++)
        {
            int parentId = Convert.ToInt32(dvParent[i]["Id"]);
            lBoxTopicIdStr.Items.Add(new ListItem(dvParent[i]["SpecialCName"].ToString(), parentId.ToString()));
            DataView dvChild = new DataView(dt);
            dvChild.RowFilter = "ParentId=" + parentId;
            for (int j = 0; j < dvChild.Count; j++)
            {
                lBoxTopicIdStr.Items.Add(new ListItem("└" + dvChild[j]["SpecialCName"], dvChild[j]["Id"].ToString()));
            }
        }
    }

    #endregion

    #region 使用目录
    //private void BindSpeacil()
    //{
    //    DataTable dt = bll.GetSpecials(0);
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        TreeNode ParentNode = new TreeNode();
    //        ParentNode.Text = dt.Rows[i]["SpecialCName"].ToString();
    //        ParentNode.NavigateUrl = "javascript:setValue(" + dt.Rows[i]["id"] + ",\'" + dt.Rows[i]["SpecialCName"] + "\');";
    //        tvNav.Nodes.Add(ParentNode);
    //    }
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        BindSpecialChild((int)dt.Rows[i]["id"], tvNav.Nodes[i]);
    //    }
    //}

    //private void BindSpecialChild(int ParentId, TreeNode tn)
    //{
    //    DataTable dt = bll.GetSpecialByParentId(ParentId);
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        TreeNode specialNode = new TreeNode();
    //        specialNode.Text = dt.Rows[i]["SpecialCName"].ToString();
    //        specialNode.NavigateUrl = "javascript:setValue(" + dt.Rows[i]["id"] + ",\'" + dt.Rows[i]["SpecialCName"] + "\');";
    //        tn.ChildNodes.Add(specialNode);
    //        BindSpecialChild((int)dt.Rows[i]["id"], tn.ChildNodes[i]);
    //    }
    //}
    #endregion
}
