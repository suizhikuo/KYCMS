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

public partial class system_infomodel_ModelOut : System.Web.UI.Page
{
    private M_InfoModel model = new M_InfoModel();
    private B_InfoModel bll = new B_InfoModel();
    string DirName = Param.SiteRootPath + @"\" + Param.ConfDirName;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataTable dt = new DataTable();
            dt = bll.GetList();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MyModel.Items.Add(new ListItem(dt.Rows[i]["ModelName"].ToString(), dt.Rows[i]["ModelId"].ToString()));
                }
            }
            else
            {
                MyModel.Items.Add(new ListItem("无任内容模型", "0"));
            }

            dt.Clear();
            dt.Dispose();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string filePath = DirName + @"\Ky_Model.xml";
        bool ModelSelected = false;
        string InModelId = "";

        if (MyModel.Items.Count > 0)
        {
            for (int i = 0; i < MyModel.Items.Count; i++)
            {
                if (MyModel.Items[i].Selected == true)
                {
                    if (MyModel.Items[i].Value == "0")
                    {
                        Function.ShowSysMsg(0, "<li>请选择一个有效内容模型</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/ModelList.aspx'>返回内容模型列表</a></li>");
                    }
                    else
                    {
                        InModelId += MyModel.Items[i].Value + ",";
                        ModelSelected = true;
                    }
                }
            }
        }
        else
        {
            Function.ShowSysMsg(0, "<li>请选择一个有效内容模型</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/ModelList.aspx'>返回内容模型列表</a></li>");
        }

        if (ModelSelected)
        {
            DataSet ds = bll.ModelOut(InModelId.Substring(0, InModelId.Length - 1));
            ds.WriteXml(filePath);
            ds.Clear();
            ds.Dispose();

            Function.ShowSysMsg(1, "<li>成功导出选择的内容模型</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/ModelList.aspx'>返回内容模型列表</a></li>");
        }
        else
        {
            Function.ShowSysMsg(0, "<li>请选择一个有效的内容模型</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='infomodel/ModelList.aspx'>返回内容模型列表</a></li>");
        }
    }
}
