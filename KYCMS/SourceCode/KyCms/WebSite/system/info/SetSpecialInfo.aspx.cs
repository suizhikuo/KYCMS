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
using Ky.BLL.CommonModel;
using Ky.Model;
using Ky.Common;

public partial class system_info_SetSpecialInfo : System.Web.UI.Page
{
    int InfoId = 0;
    int ModelId = 0;
    B_InfoOper InfoOperBll = new B_InfoOper();
    B_InfoModel InfoModelBll = new B_InfoModel();
    M_InfoModel InfoModel = null;
    DataRow InfoDr = null;
    B_Article ArticleBll = new B_Article();
    B_Special SpeacilBll = new B_Special();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_Create CreateBll = new B_Create();
    int ChId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(3);
        Response.Cache.SetNoStore();
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
        {
            try
            {
                InfoId = int.Parse(Request.QueryString["Id"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["ModelId"]))
        {
            try
            {
                ModelId = int.Parse(Request.QueryString["ModelId"]);
            }
            catch { }
        }
        InfoModel = InfoModelBll.GetModel(ModelId);
        if (InfoModel == null)
        {
            Response.Write("<script>alert('所属模型不存在或已经被删除');window.close();</script>");
            Response.End();
            return;
        }
        InfoDr = CreateBll.GetInfoById(InfoModel.TableName, InfoId);
        ChId = (int)InfoDr["chid"];
        if (InfoDr == null)
        {
            Function.ShowSysMsg(0, "<li>所属内容不存在或已经被删除</li>");
        }
        if (!IsPostBack)
        {
            Bind();
            SetListItem();
        }
    }

    private void Bind()
    {
        lsBoxSpeacil.Items.Clear();
        DataTable dt = SpeacilBll.GetChannelSpecial(ChId);
        DataView dvParent = new DataView(dt);
        dvParent.RowFilter = "ParentId=0";
        for (int i = 0; i < dvParent.Count; i++)
        {
            int parentId = Convert.ToInt32(dvParent[i]["Id"]);
            lsBoxSpeacil.Items.Add(new ListItem(dvParent[i]["SpecialCName"].ToString(), parentId.ToString()));
            DataView dvChild = new DataView(dt);
            dvChild.RowFilter = "ParentId=" + parentId;
            for (int j = 0; j < dvChild.Count; j++)
            {
                lsBoxSpeacil.Items.Add(new ListItem("└"+dvChild[j]["SpecialCName"], dvChild[j]["Id"].ToString()));
            }
        }
    }

    private void SetListItem()
    {
        string SpecialIdStr = InfoDr["SpecialIdStr"].ToString();
        if (SpecialIdStr.StartsWith("|"))
        {
            SpecialIdStr = SpecialIdStr.Substring(1, SpecialIdStr.Length - 1);
        }
        if (SpecialIdStr.EndsWith("|"))
        {
            SpecialIdStr = SpecialIdStr.Substring(0, SpecialIdStr.Length - 1);
        }
        string[] SpecialId = SpecialIdStr.Split('|');
        foreach (string s in SpecialId)
        {
            foreach (ListItem li in lsBoxSpeacil.Items)
            {
                if (s == li.Value)
                {
                    li.Selected = true;
                }
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string specialIdStr = string.Empty;
        foreach (ListItem li in lsBoxSpeacil.Items)
        {
            if (li.Selected)
            {
                specialIdStr = specialIdStr+li.Value + "|";
            }
        }
        if (specialIdStr.Length > 0)
        {
            specialIdStr = "|" + specialIdStr;
        }
        InfoOperBll.SetInfoSpecial(InfoModel.TableName, InfoId, specialIdStr);
        Response.Write("<script>window.close();dialogArguments.location.href=dialogArguments.location.href</script>");
    }
}
