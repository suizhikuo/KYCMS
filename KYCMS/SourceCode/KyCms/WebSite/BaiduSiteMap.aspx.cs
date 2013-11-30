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
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Ky.Common;

public partial class BaiduSetMap : System.Web.UI.Page
{
    B_InfoModel InfoModelBll = new B_InfoModel();
    B_Create CreateBll = new B_Create();
    const string TABLE_NAME = "kyarticle";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Response.ContentType = "application/xml";
        DataTable dt = CreateBll.GetInfo(TABLE_NAME, 1, 100);

        MemoryStream ms = new MemoryStream();
        XmlTextWriter xmlTW = new XmlTextWriter(ms, Encoding.UTF8);
        xmlTW.Formatting = Formatting.Indented;
        xmlTW.WriteStartDocument();
        xmlTW.WriteStartElement("document");
        xmlTW.WriteElementString("webSite", CreateBll.SiteModel.Domain);
        xmlTW.WriteElementString("webMaster", CreateBll.SiteModel.EmailServerUserName);
        xmlTW.WriteElementString("updatePeri", "15");

        foreach (DataRow dr in dt.Rows)
        {
            xmlTW.WriteStartElement("item");
            xmlTW.WriteElementString("title", dr["title"].ToString());
            string infoUrl = CreateBll.GetInfoUrl(dr,1).ToLower();
            if(!infoUrl.StartsWith("http://")&&!infoUrl.StartsWith("https://")&&!infoUrl.StartsWith("ftp://"))
            {
                if(Param.ApplicationRootPath==string.Empty)
                {
                    infoUrl = CreateBll.SiteModel.Domain+infoUrl;
                }
                else
                {
                    infoUrl = infoUrl.Replace(Param.ApplicationRootPath.ToLower(),string.Empty);
                    infoUrl = CreateBll.SiteModel.Domain+infoUrl;
                }
            }
            xmlTW.WriteElementString("link", infoUrl);
            xmlTW.WriteElementString("description",dr["shortcontent"].ToString());
            xmlTW.WriteElementString("text", Regex.Replace(dr["content"].ToString(), "<.+?>", "", RegexOptions.IgnoreCase));

            string imgUrl = string.Empty;
            if (dr["titleimgpath"].ToString() != string.Empty)
            {
               imgUrl = CreateBll.SiteModel.Domain + "/upload/" + dr["uploadPath"] + "/" + dr["titleimgpath"];
            }
            xmlTW.WriteElementString("image", imgUrl);
            xmlTW.WriteElementString("headlineImg", string.Empty);
            string keywords = dr["tagnamestr"].ToString();
            if (keywords.StartsWith("|") && keywords.EndsWith("|"))
            {
                keywords = keywords.Substring(0, keywords.Length - 1);
                keywords = keywords.Substring(1, keywords.Length - 1);
                keywords = keywords.Replace("|"," ");
            }
            xmlTW.WriteElementString("keywords", keywords);
            xmlTW.WriteElementString("category", dr["chname"].ToString());
            xmlTW.WriteElementString("author", dr["author"].ToString());
            xmlTW.WriteElementString("source", dr["source"].ToString());
            xmlTW.WriteElementString("pubDate", dr["addtime"].ToString());
            xmlTW.WriteEndElement();
        }
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
