using System;
using System.Xml;
using System.Configuration;
using System.Web;
using System.Text;

namespace Ky.Common
{
    public class Param
    {
        public static string ApplicationRootPath = ((HttpContext.Current.Request.ApplicationPath == "/") ? "" : HttpContext.Current.Request.ApplicationPath);
        public static string ConfDirName = ConfigurationManager.AppSettings["ConfDirName"];
        public static byte[] Iv_64 = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["Iv_64"]);
        public static byte[] Key_64 = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["Key_64"]);
        public static string ListStyle = "<table cellpadding=0 cellspacing=1 width=\"1000px\" height=\"100px\" style=\"border:solid 1px gray\" align=\"center\">\r\n<tr><td>检索</td></tr>\r\n</table>\r\n<table cellpadding=\"0\" cellspacing=\"1\" width=\"1000px\" height=\"22px\" align=\"center\">\r\n<tr><td>当前位置： {@curr_nav} >> 信息列表</td></tr>\r\n</table>\r\n<table align=\"center\" cellspacing=\"1\" cellpadding=\"0\" style=\"width:1000px;background-color:gray\">\r\n<tr height=\"28px\" style=\"text-align:center;font-weight:bold;background-color:#a3c7e2\">\r\n<td width=\"600px\">标 题</td>\r\n<td width=\"200px\">点击数</td>\r\n<td width=\"200px\">添加时间</td>\r\n</tr>\r\n<ky_loop>\r\n<tr height=\"22px\" style=\"background-color:white\"><td style=\"padding-left:2px\">● [<a href=\"list.aspx?chid={ky_chid}&colid={ky_colid}\">{ky_colname}</a>]<a href=\"{ky_infourl}\" target='_blank'>{ky_title}</a></td><td align=center>{ky_hitcount}次</td><td align=center>{ky_addtime}</td></tr>\r\n</ky_loop>\r\n</table>\r\n<table cellpadding=\"0\" cellspacing=\"1\" border=\"0\" align=\"center\" width=1000px>\r\n<tr height=\"22px\"><td>{@page_nav}</td></tr>\r\n</table>\r\n<table cellpadding=\"0\" cellspacing=\"0\" width=\"1000px\" height=\"100px\" style=\"border:solid 1px gray\" align=\"center\">\r\n<tr><td>请自行修改</td></tr>\r\n</table>";
        public static string Path = ConfigurationManager.AppSettings["WebDAL"];
        public static string Publish = ConfigurationManager.AppSettings["Publish"];
        public static string RzmNumber = GetRZMStr();
        public static string SiteRootPath = HttpContext.Current.Request.PhysicalApplicationPath.Substring(0, HttpContext.Current.Request.PhysicalApplicationPath.Length - 1).ToString();
        public static string[] TemplateAllowExtName = ConfigurationManager.AppSettings["TemplateExtName"].Split(new char[] { '|' });

        public static string GetConStr()
        {
            XmlDocument document = new XmlDocument();
            document.Load(HttpContext.Current.Server.MapPath(@"~/kycon.config"));
            XmlNode node = document.ChildNodes[1];
            return node.ChildNodes[0].ChildNodes[0].Attributes["value"].Value;
        }

        public static string GetRZMStr()
        {
            XmlDocument document = new XmlDocument();
            document.Load(HttpContext.Current.Server.MapPath(@"~/kycon.config"));
            XmlNode node = document.ChildNodes[1];
            return node.ChildNodes[0].ChildNodes[1].Attributes["value"].Value;
        }

        public static void SetConstr(string conStr)
        {
            XmlDocument document = new XmlDocument();
            document.Load(HttpContext.Current.Server.MapPath(@"~/kycon.config"));
            XmlNode node = document.ChildNodes[1];
            node.ChildNodes[0].ChildNodes[0].Attributes["value"].Value = conStr;
            document.Load(HttpContext.Current.Server.MapPath(@"~/kycon.config"));
        }

        public static void SetRZMStr(string rzmStr)
        {
            XmlDocument document = new XmlDocument();
            document.Load(HttpContext.Current.Server.MapPath(@"~/kycon.config"));
            XmlNode node = document.ChildNodes[1];
            node.ChildNodes[0].ChildNodes[1].Attributes["value"].Value = rzmStr;
            document.Load(HttpContext.Current.Server.MapPath(@"~/kycon.config"));
        }
    }
}

