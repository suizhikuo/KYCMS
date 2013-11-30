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

public partial class system_label_SuperLabelIn : System.Web.UI.Page
{
    private M_SuperLabel MSuperLabel = new M_SuperLabel();
    private B_SuperLabel BSuperLabel = new B_SuperLabel();
    string DirName = Param.SiteRootPath + @"\" + Param.ConfDirName;
    private DataTable dt=new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        string filePath = DirName + @"\SuperLabel.xml";

        if (!File.Exists(filePath))
        {
            Function.ShowSysMsg(0, "<li>很抱歉，你站点目录下不存在可以导入的超级标签文件</li><li>请手动拷贝超级标签文件到站点目录/conf/SuperLabel.xml</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='label/SuperLabelList.aspx'>返回超级标签列表</a></li>");
        }

        //dt.Columns.Add(new DataColumn("SuperId",typeof(string)));
        dt.Columns.Add(new DataColumn("Name",typeof(string)));
        dt.Columns.Add(new DataColumn("LbCategoryName",typeof(string)));
        dt.Columns.Add(new DataColumn("LbCategoryId",typeof(int)));
        dt.Columns.Add(new DataColumn("DataBaseType",typeof(int)));
        dt.Columns.Add(new DataColumn("SuperDes",typeof(string)));
        dt.Columns.Add(new DataColumn("IsUnlockPage",typeof(string)));
        dt.Columns.Add(new DataColumn("PageSize",typeof(int)));
        dt.Columns.Add(new DataColumn("HostTable",typeof(string)));
        dt.Columns.Add(new DataColumn("GuestTable",typeof(string)));
        dt.Columns.Add(new DataColumn("SqlStr",typeof(string)));
        dt.Columns.Add(new DataColumn("Content",typeof(string)));
        //dt.Columns.Add(new DataColumn("AddTime", typeof(string)));

        try
        {
            DataSet ds = new DataSet();
            ds.ReadXml(filePath);

            DataRow drNew = null;
            int intRow = ds.Tables["Table"].Rows.Count;

            for (int i = 0; i < intRow; i++)
            {
                drNew = dt.NewRow();
                //drNew["SuperId"] = ds.Tables["Table"].Rows[i]["SuperId"];
                drNew["Name"] = ds.Tables["Table"].Rows[i]["Name"];
                drNew["LbCategoryName"] = ds.Tables["Table"].Rows[i]["LbCategoryName"];
                drNew["LbCategoryId"] = ds.Tables["Table"].Rows[i]["LbCategoryId"];
                drNew["DataBaseType"] = ds.Tables["Table"].Rows[i]["DataBaseType"];
                drNew["SuperDes"] = ds.Tables["Table"].Rows[i]["SuperDes"];
                drNew["IsUnlockPage"] = ds.Tables["Table"].Rows[i]["IsUnlockPage"];
                drNew["PageSize"] = ds.Tables["Table"].Rows[i]["PageSize"];
                drNew["HostTable"] = ds.Tables["Table"].Rows[i]["HostTable"];
                drNew["GuestTable"] = ds.Tables["Table"].Rows[i]["GuestTable"];
                drNew["SqlStr"] = ds.Tables["Table"].Rows[i]["SqlStr"];
                drNew["Content"] = ds.Tables["Table"].Rows[i]["Content"];
                //drNew["AddTime"] = ds.Tables["Table"].Rows[i]["AddTime"];
                dt.Rows.Add(drNew);
            }
        }
        catch
        {
            Function.ShowSysMsg(0, "<li>读取超级标签文件失败</li><li>请确认需要导入的超级标签文件符合我们的规则</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='label/SuperLabelList.aspx'>返回超级标签列表</a></li>");
        }

        if (!Page.IsPostBack)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0,p=1; i < dt.Rows.Count; i++,p++)
                {
                    SuperLabel.Items.Add(new ListItem(dt.Rows[i]["Name"].ToString(), p.ToString()));
                }
            }
            else
            {
                SuperLabel.Items.Add(new ListItem("无任何超级标签", "0"));
            }
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        bool SuperLabelSelected = false;

        if (SuperLabel.Items.Count > 0)
        {
            int SuperId;

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
                        SuperId=int.Parse(SuperLabel.Items[i].Value)-1;

                        MSuperLabel.Name = dt.Rows[SuperId]["Name"].ToString();
                        MSuperLabel.LbCategoryName = dt.Rows[SuperId]["LbCategoryName"].ToString();
                        MSuperLabel.LbCategoryId = int.Parse(dt.Rows[SuperId]["LbCategoryId"].ToString());
                        MSuperLabel.DataBaseType = int.Parse(dt.Rows[SuperId]["DataBaseType"].ToString());
                        MSuperLabel.SuperDes = dt.Rows[SuperId]["SuperDes"].ToString();
                        MSuperLabel.IsUnlockPage = bool.Parse(dt.Rows[SuperId]["IsUnlockPage"].ToString());
                        MSuperLabel.HostTable = dt.Rows[SuperId]["HostTable"].ToString();
                        MSuperLabel.GuestTable = dt.Rows[SuperId]["GuestTable"].ToString();
                        MSuperLabel.SqlStr = dt.Rows[SuperId]["SqlStr"].ToString();
                        MSuperLabel.Content = dt.Rows[SuperId]["Content"].ToString();
                        MSuperLabel.AddTime = DateTime.Now;
                        MSuperLabel.PageSize = int.Parse(dt.Rows[SuperId]["PageSize"].ToString());

                        BSuperLabel.Add(MSuperLabel);

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
            dt.Clear();
            dt.Dispose();

            Function.ShowSysMsg(1, "<li>成功导入选择的超级标签</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='label/SuperLabelList.aspx'>返回超级标签列表</a></li>");
        }
        else
        {
            Function.ShowSysMsg(0, "<li>请选择一个有效超级标签</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='label/SuperLabelList.aspx'>返回超级标签列表</a></li>");
        }
    }
}
