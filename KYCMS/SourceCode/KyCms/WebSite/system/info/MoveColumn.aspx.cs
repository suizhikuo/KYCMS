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
using Ky.Model;

public partial class system_news_Move : System.Web.UI.Page
{
    B_Channel ChannelBll = new B_Channel();
    B_Column ColumnBll = new B_Column();
    protected int ChId = 0;
    protected M_Channel ChannelModel = null;
    B_PowerGroup AdminGroupBll = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(45);
        if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            try
            {
                ChId = int.Parse(Request.QueryString["ChId"]);
            }
            catch { }
        }
        ChannelModel = ChId == 0 ? null : ChannelBll.GetChannel(ChId);
        if (ChannelModel == null)
        {
            Response.Write("<script type='text/javascript'>alert('频道不存在或已经被删除');history.back();</script>");
            Response.End();
            return;
        }
        if (!IsPostBack)
        {
            BindLeft();
            BindRight();
        }
    }
    private void BindLeft()
    {
        DataTable dt = GetItemData(ChannelModel.ModelType, true);
        for (int i = 0; i < dt.Rows.Count;i++ )
        {
            lsbColumnLeft.Items.Add(new ListItem(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["Id"].ToString()));
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Flag"].ToString() == "False")
                lsbColumnLeft.Items[i].Attributes.Add("style", "color:red");
        }
    }
    private void BindRight()
    {
        DataTable dt = GetItemData(ChannelModel.ModelType, false);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lsbColumnRight.Items.Add(new ListItem(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["Id"].ToString()));
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Flag"].ToString() == "False")
            {
                lsbColumnRight.Items[i].Attributes.Add("style", "color:red");
            }
        }
    }

    private DataTable GetItemData(int modelType,bool isleft)
    {
        DataTable returnDt = new DataTable();
        returnDt.Columns.Add("Id", typeof(string));
        returnDt.Columns.Add("Name", typeof(string));
        returnDt.Columns.Add("Flag", typeof(bool));
        DataView dv = ChannelBll.GetChannelByType(modelType);
        for (int i = 0; i < dv.Count; i++)
        {
            int chId = (int)dv[i]["ChId"];
            DataTable dt = ColumnBll.GetFormatListItemByChannelId(chId);
            DataRow dr = returnDt.NewRow();
            if (isleft)
            {
                dr["Id"] = "0";
            }
            else
            {
                dr["Id"] = chId + "$";
            }
            
            dr["Name"] = dv[i]["ChName"]+"<频道>";
            dr["Flag"] = false;
            returnDt.Rows.Add(dr);
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                dr = returnDt.NewRow();
                if (isleft)
                {
                    int colId = (int)dt.Rows[j]["ColId"];
                    string colIdStr = ColumnBll.GetChildIdByColumnId(colId);
                    colIdStr = "|" + colIdStr.Replace(",", "|") + "|";
                    dr["Id"] = dt.Rows[j]["ColId"] + ","+colIdStr;
                }
                else
                {
                    dr["Id"] = dt.Rows[j]["ColId"];
                }
                dr["Name"] = "├┄" + dt.Rows[j]["ColName"];
                dr["Flag"] = true;
                returnDt.Rows.Add(dr);
            }
        }
        return returnDt;
    }
    protected void btnMove_Click(object sender, EventArgs e)
    {
        string selectColId = string.Empty;
        selectColId = lsbColumnLeft.SelectedValue;
        if(selectColId.Length==0)
        {
            Response.Write("<script>alert('请选择要移动的栏目');location.href('"+Request.Url.ToString()+"')</script>");
            return;
        }
        if(selectColId=="0")
        {
            Response.Write("<script>alert('频道不能移动');location.href('" + Request.Url.ToString() + "')</script>");
            return;
        }
        string targetId = string.Empty;
        targetId = lsbColumnRight.SelectedValue;
        if(targetId.Length==0)
        {
            Response.Write("<script>alert('请选择目标频道/栏目');location.href('" + Request.Url.ToString() + "')</script>");
            return;
        }
        bool isChannel = true;
        if (targetId.IndexOf("$") == -1)
        {
            isChannel = false;
            if (selectColId.IndexOf("|" + targetId + "|") != -1)
            {
                Response.Write("<script>alert('目标栏目不能是所选移动栏目或其子栏目');location.href('" + Request.Url.ToString() + "')</script>");
                return;
            }
        }
        else
        {
            targetId = targetId.Replace("$", "");
        }
        string[] idArray = selectColId.Split(',');
        selectColId = idArray[0];
        string childIdStr = idArray[1].Replace("|",",");
        if (childIdStr.StartsWith(",") && childIdStr.EndsWith(","))
        {
            childIdStr = childIdStr.Substring(0, childIdStr.Length - 1);
            childIdStr = childIdStr.Substring(1, childIdStr.Length - 1);
            ColumnBll.Move(int.Parse(selectColId), int.Parse(targetId), isChannel, childIdStr);
        }
        Response.Write("<script>parent.document.frames['LeftIframe'].location.reload();location.href('" + Request.Url.ToString() + "');</script>");
    }
}
