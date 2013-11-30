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
using System.Xml;
using System.IO;
using System.Text;
using Ky.BLL;
using Ky.Model;
using Ky.Common;
using Ky.BLL.CommonModel;

public partial class Rss : System.Web.UI.Page
{
    B_Create CreateBll = new B_Create();
    B_Column ColumnBll = new B_Column();
    B_Channel ChannelBll = new B_Channel();
    B_InfoOper InfoOperBll = new B_InfoOper();
    B_InfoModel InfoModelBll = new B_InfoModel();
    int chId = 0;
    string colId = "0";
    bool includeSub = false;
    M_Channel ChannelModel = null;
    M_Column ColumnModel = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Response.Cache.SetNoStore();
        Response.ContentType = "application/xml";
        if (!string.IsNullOrEmpty(Request.QueryString["chid"]))
        {
            try
            {
                chId = int.Parse(Request.QueryString["chid"]);
            }
            catch { }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["colid"]))
        {
            try
            {
                colId =Request.QueryString["colid"];
            }
            catch { }
        }
        if (colId == "0"&&chId==0)
        {
            return;
        }
        if (!string.IsNullOrEmpty(Request.QueryString["includesub"]))
        {
            includeSub = true;
        }
        int currChId = chId;
        if (colId != "0")
        {
            ColumnModel = ColumnBll.GetColumn(int.Parse(colId));
            if (ColumnModel == null)
                Function.ShowMsg(0, "<li>所属栏目不存在或已经被删除</li>");
            currChId = ColumnModel.ChId;
        }

        ChannelModel = ChannelBll.GetChannel(currChId);
        if (ChannelModel == null)
            Function.ShowMsg(0, "<li>所属频道不存在或已经被删除</li>");
        bool isDisabled = ChannelModel.IsDisabled;
        if (isDisabled)
            Function.ShowMsg(0, "<li>所属频道已经被管理员禁用</li>");
        M_InfoModel infoModel = InfoModelBll.GetModel(ChannelModel.ModelType);
        if(infoModel==null)
            Function.ShowMsg(0, "<li>所属模型不存在或已经被删除</li>");
        MemoryStream ms = new MemoryStream();
        XmlTextWriter xmlTW = new XmlTextWriter(ms,Encoding.UTF8);
        xmlTW.Formatting = Formatting.Indented;
        xmlTW.WriteStartDocument();
            xmlTW.WriteStartElement("rss");
                xmlTW.WriteAttributeString("version", "2.0");
                    xmlTW.WriteStartElement("channel");
                    if (chId == 0)
                    {
                        xmlTW.WriteElementString("title", ColumnModel.ColName);
                        xmlTW.WriteElementString("link", CreateBll.GetColumnUrl(int.Parse(colId), 1));
                        xmlTW.WriteElementString("description", ColumnModel.Description);
                    }
                    else
                    {
                        xmlTW.WriteElementString("title", ChannelModel.ChName);
                        xmlTW.WriteElementString("link", CreateBll.GetChannelUrl(chId));
                        xmlTW.WriteElementString("description", ChannelModel.Description);
                    }
                    if (includeSub)
                    {
                        colId = ColumnBll.GetChildIdByColumnId(int.Parse(colId));
                    }
                    DataTable dt = InfoOperBll.GetRssInfoList(infoModel.TableName, chId,colId);
                  
                    foreach (DataRow dr in dt.Rows)
                    {
                        xmlTW.WriteStartElement("item");
                            xmlTW.WriteElementString("title", dr["title"].ToString());
                            xmlTW.WriteElementString("link",CreateBll.GetInfoUrl(dr));
                            xmlTW.WriteElementString("description", "");
                            xmlTW.WriteElementString("pubdate", dr["addtime"].ToString());
                        xmlTW.WriteEndElement();

                    }

                    xmlTW.WriteEndElement();
                xmlTW.WriteEndElement();
        xmlTW.WriteEndDocument();
        xmlTW.Flush();
        byte[] buffer = ms.ToArray();
        Response.Write(Encoding.UTF8.GetString(buffer));
        Response.End(); 
        xmlTW.Close();
        ms.Close();
        ms.Dispose();
       
    }
}
