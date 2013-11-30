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
using Ky.Common;
using Ky.Model;

public partial class system_info_ColumnToTemplate : System.Web.UI.Page
{
    B_Channel ChannelBll = new B_Channel();
    B_Column ColumnBll = new B_Column();
    protected M_Channel ChannelModel = null;
    M_Column MColumn = new M_Column();
    B_Admin AdminBll = new B_Admin();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_InfoModel InfoModelBll = new B_InfoModel();
    M_InfoModel InfoModel = null;
    int ChId = 0;  

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(44);
        if (Request.QueryString["ChId"] != null && Request.QueryString["ChId"] != "")
        {
            try
            {
                ChId = int.Parse(Request.QueryString["ChId"]);
            }
            catch { }
        }
        DataView dv = ChannelBll.GetList(false);
        if (ChId == 0)
        {

            if (dv.Count > 0)
            {
                ChId = (int)dv[0]["ChId"];
            }
        }
        if (ChId == 0)
        {
            Function.ShowSysMsg(0, "<li>请先添加频道</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
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
        txtColumnTemplatePath.Attributes["Readonly"] = "true";
        txtInfoTemplatePath.Attributes["Readonly"] = "true";
        txtCommentTemplatePath.Attributes["Readonly"] = "true";
          
        if (!Page.IsPostBack)
        {
            for (int i = 0; i < dv.Count; i++)
            {
                ddlChannel.Items.Add(new ListItem(dv[i]["ChName"].ToString(), dv[i]["ChId"].ToString()));
                if (ChId == (int)dv[i]["ChId"])
                {
                    ddlChannel.Items[i].Selected = true;
                }
            }
            dv.Dispose();
            litNav.Text = ChannelModel.ChName;

            DataTable dt=ColumnBll.GetListItemByChannelId(ChId);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lsBoxColumn.Items.Add(new ListItem(GetDepth(int.Parse(dt.Rows[i]["Depth"].ToString())) + dt.Rows[i]["ColName"].ToString(), dt.Rows[i]["ColId"].ToString()));
            }
            dt.Dispose();
        }
    }

    public string GetDepth(int Depth)
    {
        string GetDepth="";

        if (Depth == 0)
        {
            GetDepth="";
        }
        else
        {
            for (int i = 0; i < Depth; i++)
            {
                GetDepth += "├┄";
            }
        }

        return GetDepth;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string ActionTable = "";
        MColumn.ColumnTemplatePath = txtColumnTemplatePath.Text;    //栏目
        MColumn.InfoTemplatePath = txtInfoTemplatePath.Text;        //内容
        MColumn.CommentTemplatePath = txtCommentTemplatePath.Text;  //评论



        bool sListBox1 = false;

        ActionTable = InfoModel.TableName;


        for (int i = 0; i < lsBoxColumn.Items.Count; i++)
        {
            if (lsBoxColumn.Items[i].Selected == true)
           {
              //更新栏目模板
               MColumn.ColId = int.Parse(lsBoxColumn.Items[i].Value);
              ColumnBll.UpdateTemplate(MColumn);

              //更新详细信息表
              if (txtInfoTemplatePath.Text != "")
              {
                  ColumnBll.UpdateActionTableTemplate(int.Parse(lsBoxColumn.Items[i].Value), ActionTable, txtInfoTemplatePath.Text);
              }

              //设置跳转参数
              sListBox1 = true;
           }
        }
        B_Log.Add(LogType.Update, "批量捆绑模板");

        if (sListBox1)
        {
            ColumnBll.ClearCache();
            Function.ShowSysMsg(1, "<li>捆绑成功</li><li>需要重新生成才生效</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
        }
        else
        {
            Function.ShowSysMsg(0, "<li>请选择栏目</li><li>至少要选择一个要捆绑的栏目</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");

        }
    }
}
