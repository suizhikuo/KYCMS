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

public partial class system_collection_SetColumn : System.Web.UI.Page
{
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(48);
        Response.Cache.SetNoStore();
        Bind();
    }

    //private void Bind()
    //{
    //    B_Channel channelBll = new B_Channel();
    //    B_Column columnBll = new B_Column();
    //    TreeNode rootNode = new TreeNode();
    //    DataView channelDv = channelBll.GetList(false);
    //    for (int i = 0; i < channelDv.Count; i++)
    //    {
    //        TreeNode channelNode = new TreeNode();
    //        channelNode.Text = channelDv[i]["ChName"].ToString();
    //        tvNav.Nodes.Add(channelNode);
    //    }
    //    for (int i = 0; i < channelDv.Count; i++)
    //    {
    //        DataView dv = columnBll.GetColumnListByChannelId((int)channelDv[i]["ChId"]);
    //        DataTable dt = dv.ToTable();
    //        dv.Dispose();
    //        BindColumn(0, tvNav.Nodes[i], dt, (int)channelDv[i]["ModelType"], (int)channelDv[i]["ChId"]);
    //    }
    //}

    //private void BindColumn(int colParentId, TreeNode tn, DataTable dt, int modelType, int chId)
    //{
    //    DataView dv = new DataView(dt);
    //    dv.RowFilter = "colParentId= " + colParentId;
    //    for (int i = 0; i < dv.Count; i++)
    //    {
    //        TreeNode columnNode = new TreeNode();
    //        columnNode.Text = dv[i]["ColName"].ToString();
    //        columnNode.NavigateUrl = "javascript:setValue("+dv[i]["ColId"]+",\'"+dv[i]["ColName"]+"\');";
    //        tn.ChildNodes.Add(columnNode);
    //        BindColumn((int)dv[i]["ColId"], tn.ChildNodes[i], dt, modelType, chId);
    //    }
    //}

    private void Bind()
    {
        int ChType = 1;

        B_Dictionary dictionBll = new B_Dictionary();
        DataTable chTypeDt = dictionBll.GetDictionary(ChType);

        for (int i = 0; i < chTypeDt.Rows.Count; i++)
        {
            TreeNode chTypeNode = new TreeNode();
            chTypeNode.Text = chTypeDt.Rows[i]["DicName"].ToString();
            chTypeNode.ImageUrl = "~/system/images/category.gif";
            chTypeNode.SelectAction = TreeNodeSelectAction.Expand;
            tvNav.Nodes.Add(chTypeNode);
        }
        TreeNode chTypeOtherNode = new TreeNode();
        chTypeOtherNode.Text = "其他";
        chTypeOtherNode.ImageUrl = "~/system/images/category.gif";
        chTypeOtherNode.SelectAction = TreeNodeSelectAction.Expand;
        tvNav.Nodes.Add(chTypeOtherNode);

        B_Channel channelBll = new B_Channel();
        B_Column columnBll = new B_Column();
        DataView channelDv = channelBll.GetList(false);

        for (int i = 0; i < tvNav.Nodes.Count - 1; i++)
        {
            int chType = int.Parse(chTypeDt.Rows[i]["id"].ToString());

            DataTable chDt = channelDv.ToTable();

            DataView chTypeDv = new DataView(chDt);
            chTypeDv.RowFilter = string.Format("[chtype]={0}", chType);
            for (int j = 0; j < chTypeDv.Count; j++)
            {
                TreeNode channelNode = new TreeNode();
                channelNode.Text = chTypeDv[j]["ChName"].ToString();
                channelNode.ImageUrl = "~/system/images/folder.gif";
                channelNode.NavigateUrl = "SetColumn.aspx?ChId=" + chTypeDv[j]["ChId"];
                tvNav.Nodes[i].ChildNodes.Add(channelNode);
            }

            for (int j = 0; j < chTypeDv.Count; j++)
            {
                DataView dv = columnBll.GetColumnListByChannelId((int)chTypeDv[j]["ChId"]);
                DataTable dt = dv.ToTable();
                dv.Dispose();
                BindColumn(0, tvNav.Nodes[i].ChildNodes[j], dt, (int)chTypeDv[j]["ModelType"], (int)chTypeDv[j]["ChId"]);
            }
            chDt.Dispose();
            chTypeDv.Dispose();
        }
        DataTable chDt2 = channelDv.ToTable();
        DataView chTypeDv2 = new DataView(chDt2);
        chTypeDv2.RowFilter = "[chtype]=0 or [chtype] is null";
        for (int j = 0; j < chTypeDv2.Count; j++)
        {
            TreeNode channelNode = new TreeNode();
            channelNode.Text = chTypeDv2[j]["ChName"].ToString();
            channelNode.ImageUrl = "~/system/images/folder.gif";
            channelNode.NavigateUrl = "SetColumn.aspx?ChId=" + chTypeDv2[j]["ChId"];
            tvNav.Nodes[tvNav.Nodes.Count - 1].ChildNodes.Add(channelNode);
        }
        for (int j = 0; j < chTypeDv2.Count; j++)
        {
            DataView dv = columnBll.GetColumnListByChannelId((int)chTypeDv2[j]["ChId"]);
            DataTable dt = dv.ToTable();
            dv.Dispose();
            BindColumn(0, tvNav.Nodes[tvNav.Nodes.Count - 1].ChildNodes[j], dt, (int)chTypeDv2[j]["ModelType"], (int)chTypeDv2[j]["ChId"]);
        }
        chDt2.Dispose();
        chTypeDv2.Dispose();
    }

    private void BindColumn(int colParentId, TreeNode tn, DataTable dt, int modelType, int chId)
    {
        DataView dv = new DataView(dt);
        dv.RowFilter = "colParentId= " + colParentId;
        for (int i = 0; i < dv.Count; i++)
        {
            TreeNode columnNode = new TreeNode();
            columnNode.Text = dv[i]["ColName"].ToString();
            columnNode.NavigateUrl = "javascript:setValue(" + dv[i]["ColId"] + ",\'" + dv[i]["ColName"] + "\');";
            tn.ChildNodes.Add(columnNode);
            BindColumn((int)dv[i]["ColId"], tn.ChildNodes[i], dt, modelType, chId);
        }
    }
}
