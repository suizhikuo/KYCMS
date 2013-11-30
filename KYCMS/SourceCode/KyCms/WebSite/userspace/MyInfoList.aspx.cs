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
using Ky.SQLServerDAL;
using Ky.Model;
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class userspace_MyInfoList : System.Web.UI.Page
{
    B_UserGroup UserGroupBll = new B_UserGroup();
    B_User UserBll = new B_User();
    B_Create CreateBll = new B_Create();
    M_User UserModel = null;
    M_UserGroup UserGroupModel = null;
    protected string UserName = string.Empty;
    B_InfoModel InfoModelBll = new B_InfoModel();
    M_InfoModel InfoModel = null;
    B_InfoOper InfoOperBll = new B_InfoOper();
    DataTable dtModel = new DataTable();
    protected int ModelId = 0;
    protected string TableName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["UserName"]))
        {
            UserName = Request.QueryString["UserName"];
        }
        UserModel = UserBll.GetUser(UserName);
        if (UserModel == null)
            Function.ShowMsg(0, "<li>用户空间参数错误</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        B_UserSpace.IsActive(UserModel.UserID, 2);
        B_UserSpace spaceBll = new B_UserSpace();
        M_UserSpace spaceModel = spaceBll.GetUserSpaceById(UserModel.UserID);
        Page.Title = spaceModel.SpaceName + "--我的稿件列表";
        UserGroupModel = UserGroupBll.GetModel(UserModel.GroupID);
        if (!string.IsNullOrEmpty(Request.QueryString["ModelId"]))
        {
            ModelId = int.Parse(Request.QueryString["ModelId"]);
        }
        if (ModelId < 0)
            Function.ShowMsg(0, "<li>模型参数错误!</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        if (!IsPostBack)
        {
            repModelBind();
            if (ModelId > 0)
                repContentListBind(ModelId);
        }
    }

    protected string GetUrl(object id, object modeltype)
    {
        int _id = (int)id;
        int _modelId = (int)modeltype;
        return CreateBll.GetInfoUrl(_id, _modelId, 1);
    }
    protected void repModelBind()
    {
        dtModel.Columns.Add("ModelId", typeof(string));
        dtModel.Columns.Add("TableName", typeof(string));
        dtModel.Columns.Add("ModelName", typeof(string));
        DataTable dtTemp = InfoModelBll.GetList();
        foreach (DataRow dr in dtTemp.Rows)
        {
            DataRow drModel = dtModel.NewRow();
            drModel["ModelId"] = dr["ModelId"];
            drModel["TableName"] = dr["TableName"];
            drModel["ModelName"] = dr["ModelName"];
            dtModel.Rows.Add(drModel);
        }
        dtTemp.Dispose();
        ArrayList indexArrayList = new ArrayList();
        for (int i = 0; i < dtModel.Rows.Count; i++)
        {
            DataRow dr = dtModel.Rows[i];
            TableName = dr["TableName"].ToString();
            int modelId = int.Parse(dr["ModelId"].ToString());
            if (modelId == 2 || !InfoOperBll.IsExistsInfoByUserId(TableName, UserModel.UserID))
            {
                indexArrayList.Add(i);
            }
        }
        int length = indexArrayList.Count;
        for (int i = length - 1; i >= 0; i--)
        {
            int index = (int)indexArrayList[i];
            dtModel.Rows.RemoveAt(index);
        }
        DataView dvModel = new DataView(dtModel);
        if (ModelId > 0)
            dvModel.RowFilter = "ModelId=" + ModelId;
        repModel.DataSource = dvModel;
        if (dvModel.Table.Rows.Count <= 0)
        {
            lbMsg.Text = "<div class='modelTitle'>所有稿件列表</div><div style='padding:5px'>尚未添加任何稿件!</div>";
            return;
        }

        repModel.DataBind();

        dtModel.Dispose();
    }
    //repModel-->repContentBind()
    protected void repItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (ModelId > 0)
        {
            HtmlControl divshowMore = (HtmlControl)e.Item.FindControl("divShowMore");
            divshowMore.Visible = false;
            return;
        }
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataTable dtContent = new DataTable();
            dtContent.Columns.Add("Id", typeof(int));
            dtContent.Columns.Add("Title", typeof(string));
            dtContent.Columns.Add("RowIndex", typeof(int));
            dtContent.Columns.Add("AddTime", typeof(DateTime));
            dtContent.Columns.Add("ModelType", typeof(int));
            int rowIndex = 0;

            TableName = dtModel.Rows[e.Item.ItemIndex]["TableName"].ToString();
            int recordCount = 0;
            DataTable dt = InfoOperBll.GetUserInfoList(TableName, UserModel.UserID, "", "", 0, "0", "3", "", "", "", -1, 1, 10, ref recordCount);
            foreach (DataRow dr in dt.Rows)
            {
                DataRow dr2 = dtContent.NewRow();
                dr2["Id"] = dr["Id"];
                dr2["Title"] = dr["Title"];
                dr2["RowIndex"] = rowIndex;
                dr2["AddTime"] = dr["AddTime"];
                dr2["ModelType"] = dr["ModelType"];
                dtContent.Rows.Add(dr2);
                rowIndex++;
            }
            DataView dv = new DataView(dtContent);
            dv.Sort = "AddTime desc";
            dv.RowFilter = "RowIndex<5";
            Repeater repContent = (Repeater)e.Item.FindControl("repContent");
            repContent.DataSource = dv;

            repContent.DataBind();

            dv.Dispose();
        }
    }

    protected void repContentListBind(int modelId)
    {
        AspNetPager.Visible = true;
        InfoModel = InfoModelBll.GetModel(modelId);
        if (InfoModel == null)
            Function.ShowMsg(0, "<li>模型参数错误!</li><li><a href='javascript:history.back();'>返回上一级</a></li>");
        DataTable dtContent = new DataTable();
        dtContent.Columns.Add("Id", typeof(int));
        dtContent.Columns.Add("Title", typeof(string));
        dtContent.Columns.Add("RowIndex", typeof(int));
        dtContent.Columns.Add("AddTime", typeof(DateTime));
        dtContent.Columns.Add("ModelType", typeof(int));
        int rowIndex = 0;

        TableName = InfoModel.TableName;
        int recordCount = 0;
        DataTable dt = InfoOperBll.GetUserInfoList(TableName, UserModel.UserID, "", "", 0, "0", "3", "", "", "", -1, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, ref recordCount);
        if (dt.Rows.Count <= 0)
        {
            Label1.Text = "<font color=blue>暂无任何稿件!</font>"; return;
        }

        foreach (DataRow dr in dt.Rows)
        {
            DataRow dr2 = dtContent.NewRow();
            dr2["Id"] = dr["Id"];
            dr2["Title"] = dr["Title"];
            dr2["RowIndex"] = rowIndex;
            rowIndex++;
            dr2["AddTime"] = dr["AddTime"];
            dr2["ModelType"] = dr["ModelType"];
            dtContent.Rows.Add(dr2);
        }
        dt.Dispose();
        DataView dv = new DataView(dtContent);
        dv.Sort = "AddTime desc";
        dv.RowFilter = "RowIndex<10";
        repContentList.DataSource = dv;
        repContentList.DataBind();
        AspNetPager.RecordCount = recordCount;
        AspNetPager.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条留言 每页显示{3}条", AspNetPager.CurrentPageIndex, AspNetPager.PageCount, AspNetPager.RecordCount, AspNetPager.PageSize);

        dv.Dispose();
    }
    protected void AspNetPager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager.CurrentPageIndex = e.NewPageIndex;
        repContentListBind(ModelId);
    }
}

