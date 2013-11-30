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
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class System_news_MassMoveInfo : System.Web.UI.Page
{
    B_Channel ChannelBll = new B_Channel();
    B_Column ColumnBll = new B_Column();
    B_InfoOper InfoOperBll = new B_InfoOper();
    int ChId = -1;
    int ColId = -1;
    protected M_Channel ChannelModel = null;
    string IdStr = string.Empty;
    B_Admin AdminBll = new B_Admin();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_InfoModel InfoModelBll = new B_InfoModel();
    M_InfoModel InfoModel = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(42);
        litMsg.Text = "";
        if (!string.IsNullOrEmpty(Request.QueryString["IdStr"]))
            IdStr = Request.QueryString["IdStr"];
        if (!string.IsNullOrEmpty(Request.QueryString["ChId"]))
        {
            try
            {
                ChId = int.Parse(Request.QueryString["ChId"]);
            }
            catch { }
        }
        ChannelModel = ChannelBll.GetChannel(ChId);
        if (ChannelModel == null)
        {
            Function.ShowSysMsg(0, "<li>所属频道不存在或已经被删除</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        InfoModel = InfoModelBll.GetModel(ChannelModel.ModelType);
        if (InfoModel == null)
        {
            Function.ShowSysMsg(0, "<li>所属模型不存在或已经被删除</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        if (!string.IsNullOrEmpty(Request.QueryString["ColId"]))
        {
            try
            {
                ColId = int.Parse(Request.QueryString["ColId"]);
            }
            catch { }
        }
        
        if (!IsPostBack)
        {
            txtByArticleIdStr.Text = IdStr;
            BindLeft();
            BindRight();
        }
    }
    private void BindLeft()
    {
        DataTable dt = GetItemData(true);
        for (int i = 0; i < dt.Rows.Count; i++)
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
        DataTable dt = GetItemData(false);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            lsbColumnRight.Items.Add(new ListItem(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["Id"].ToString()));
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Flag"].ToString() == "False")
                lsbColumnRight.Items[i].Attributes.Add("style", "color:red");
        }
    }
    private DataTable GetItemData(bool isLeft)
    {
        DataTable returnDt = new DataTable();
        returnDt.Columns.Add("Id", typeof(string));
        returnDt.Columns.Add("Name", typeof(string));
        returnDt.Columns.Add("Flag", typeof(bool));
        DataView dv = ChannelBll.GetChannelByType(ChannelModel.ModelType);
        for (int i = 0; i < dv.Count; i++)
        {
            int chId = (int)dv[i]["ChId"];
            DataTable dt = ColumnBll.GetFormatListItemByChannelId(chId);
            DataRow dr = returnDt.NewRow();
            if (isLeft)
            {
                dr["Id"] = "0";
            }
            else
            {
                dr["Id"] = "1";
            }
            dr["Name"] = dv[i]["ChName"] + "<频道>";
            dr["Flag"] = false;
            returnDt.Rows.Add(dr);
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                dr = returnDt.NewRow();
                if (isLeft)
                {
                    dr["Id"] = dt.Rows[j]["ColId"];
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
    protected void Set_Click(object sender, EventArgs e)
    {
        string selectColId = "0";
        string targetId = string.Empty;
        string IdStr = string.Empty;
        targetId = lsbColumnRight.SelectedValue;
        if (targetId == "1")
        {
            Response.Write("<script>alert('目标内容不能移动到频道下');history.back();</script>");
            return;
        }
        if (targetId.Length == 0)
        {
            Response.Write("<script>alert('请选择目标内容的频道/栏目');history.back();</script>");
            return;
        }
        //指定ID
        if (rdBtnByArticleIdStr.Checked)
        {
            if (txtByArticleIdStr.Text.Trim().Length == 0)
            {
                Response.Write("<script>alert('请输入指定要移动的内容ID');history.back();</script>");
                return;
            }
            else
            {
                IdStr = txtByArticleIdStr.Text.Trim();
                string[] arrayId = IdStr.Split(',');
                for (int i = 0; i < arrayId.Length; i++)
                {
                    if (arrayId[i].Length > 10)
                    {
                        Response.Write("<script>alert('指定的ID输入不合法');history.back();</script>");
                        return;
                    }
                }
                if (IdStr.IndexOf(",,") != -1)
                {
                    Response.Write("<script>alert('指定的ID输入不合法');history.back();</script>");
                    return;
                }
                if (IdStr.StartsWith(","))
                    IdStr = IdStr.Substring(1, IdStr.Length - 1);
                if (IdStr.EndsWith(","))
                    IdStr = IdStr.Substring(0, IdStr.Length - 1);
            }
        }//指定ID
        //指定栏目
        else if (rdBtnByColumnIdStr.Checked)
        {
            selectColId = lsbColumnLeft.SelectedValue;
            if (selectColId.Length == 0)
            {
                Response.Write("<script>alert('请选择要指定内容的栏目');history.back();</script>");
                return;
            }
            if (selectColId == "0")
            {
                Response.Write("<script>alert('指定内容不能在频道下');history.back();</script>");
                return;
            }
            if (selectColId == targetId)
            {
                Response.Write("<script>alert('目标栏目不能是所选栏目或其子栏目/栏目');history.back();</script>");
                return;
            }
        }//指定栏目
        InfoOperBll.MassMoveInfo(InfoModel.TableName, IdStr, Convert.ToInt32(selectColId), Convert.ToInt32(targetId));
        Function.ShowSysMsg(1, "<li>批量移动成功</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
            

    }
}
