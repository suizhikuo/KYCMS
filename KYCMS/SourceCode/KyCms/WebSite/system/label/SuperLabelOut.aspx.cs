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
using Ky.BLL.CommonModel;
using Ky.Model;
using System.Xml;
using Ky.Common;
using System.IO;
using System.Text;

public partial class system_label_SuperLabelOut : System.Web.UI.Page
{
    private M_SuperLabel MSuperLabel = new M_SuperLabel();
    private B_SuperLabel BSuperLabel = new B_SuperLabel();
    string DirName = Param.SiteRootPath + @"\" + Param.ConfDirName;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataTable dt = new DataTable();
            dt = BSuperLabel.GetList(1, 1000000).Tables[0];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SuperLabel.Items.Add(new ListItem(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["SuperId"].ToString()));
                }
            }
            else
            {
                SuperLabel.Items.Add(new ListItem("无任何超级标签", "0"));
            }

            dt.Clear();
            dt.Dispose();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string filePath = DirName + @"\SuperLabel.xml";
        bool SuperLabelSelected = false;
        string InSuperId="";

        if (SuperLabel.Items.Count > 0)
        {
            for (int i = 0; i < SuperLabel.Items.Count; i++)
            {
                if (SuperLabel.Items[i].Selected == true)
                {
                    if (SuperLabel.Items[i].Value == "0")
                    {
                        Function.ShowSysMsg(0, "<li>请选择一个有效超级标签</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='label/SuperLabelList.aspx'>返回超级标签列表</a></li>");
                    }
                    else
                    {
                        InSuperId += SuperLabel.Items[i].Value + ",";
                        SuperLabelSelected = true;
                    }
                }
            }
        }
        else
        {
            Function.ShowSysMsg(0, "<li>请选择一个有效超级标签</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='label/SuperLabelList.aspx'>返回超级标签列表</a></li>");
        }

        if (SuperLabelSelected)
        {
            DataSet ds = BSuperLabel.SuperLabelOut(InSuperId.Substring(0, InSuperId.Length - 1));
            ds.WriteXml(filePath);
            ds.Clear();
            ds.Dispose();

            Function.ShowSysMsg(1, "<li>成功导出选择的超级标签</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='label/SuperLabelList.aspx'>返回超级标签列表</a></li>");
        }
        else
        {
            Function.ShowSysMsg(0, "<li>请选择一个有效超级标签</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='label/SuperLabelList.aspx'>返回超级标签列表</a></li>");
        }
    }
}
