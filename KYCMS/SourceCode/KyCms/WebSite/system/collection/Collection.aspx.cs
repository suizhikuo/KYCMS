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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using Ky.BLL;
using Ky.BLL.CommonModel;
using Ky.Model;
using Ky.SQLServerDAL;


public partial class system_collection_Collection : System.Web.UI.Page
{
    private B_Collection CollectionBll = new B_Collection();
    private B_CollectionAddress CollectionAddressBll = new B_CollectionAddress();
    private M_Collection CollectionM = new M_Collection();
    private M_CollectionAddress CollectionAddressM = new M_CollectionAddress();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(48);
        if (Request.QueryString["id"] != null || Request.QueryString["id"].Length != 0)
        {
            string htmlstr = "<html><head><link rel='stylesheet' href='../css/default.css' type='text/css' /></head><body>\r\n<br/><br/>\r\n<table width='500px' align='center'><tr><td align='left' width='410px' id='info' colspan=\"2\">&nbsp;</td></tr></table><div align='center'><div style='width:500px;border:solid 1px black' align='left'><img id='tp' height='22px' src='../images/loading.gif' width='0px'></div>\r\n</div></div>\r\n<table width='500px' align='center'><tr><td align='center' width='250px'><span id='tn'>0%</span></td><td align='center' width='250px' id='finallytd'>共<span id='total'>0</span>条</td></tr></table><script>\r\nfunction SetPr(val,curr){ \r\n document.getElementById('tp').style.width = val;document.getElementById('tn').innerText=val; \r\n}\r\nfunction SetTotal(val){ document.getElementById('total').innerText=val;} function Info(val){document.getElementById('info').innerText=val;}\r\n</script>\r\n</body>\r\n";
             Response.Write(htmlstr);
             Response.Flush();
             if (Request.QueryString["type"] != null && Request.QueryString["type"].Length != 0)
                 CollectionStateFalse(int.Parse(Request.QueryString["id"].ToString()));
             else
                 ColectionData(int.Parse(Request.QueryString["id"].ToString()));
        }
    }

    private void ColectionData(int id)
    {
        CollectionM = CollectionBll.GetIdByCollection(id);
        string getlinkStr = CollectionBll.ListPageLink(CollectionM);
        string[] linkArr = getlinkStr.Split(',');
        string[] resultLinkArr = null;
        string linkStr = string.Empty;
        for (int i = 0; i < linkArr.Length;i++ )
        {
            if (linkArr[i] != "")
            {
                if (CollectionAddressBll.IsCheckAddress(linkArr[i]))
                {
                    CollectionAddressM.ColectionId = CollectionM.Id;
                    CollectionAddressM.CollectionUrl = linkArr[i];
                    CollectionAddressM.State = false;
                    CollectionAddressBll.Add(CollectionAddressM);
                    linkStr = linkStr + linkArr[i] + ",";
                }
            }
        }
                                                  
        resultLinkArr = linkStr.Split(',');
        int RecordCount = resultLinkArr.Length - 1;
        Response.Write("<script>SetTotal(" + RecordCount + ")</script>\r\n");
        Response.Flush();
        for (int i = 0; i < RecordCount; i++)
        {
            string per = ((i * 100) / RecordCount).ToString("F1");
            bool result = CollectionBll.AddCollectionData(resultLinkArr[i].ToString(), CollectionM);
            if (result)
                 CollectionAddressBll.UpdateSate(resultLinkArr[i]);
             Response.Write("<script>Info('正在采集：" + resultLinkArr[i] + "')</script>\r\n");
            Response.Write("<script>SetPr('" + per + "%'," + i + ")</script>\r\n");
            Response.Flush();
        }                                            
        Response.Write("<script>SetPr('100.0%'," + RecordCount + ")</script>");
        Response.Write("<script>document.getElementById('finallytd').innerText = '采集完毕'</script>");
        Response.Write("<script>Info(' ')</script>\r\n");
        Response.Write("<table align='center' width='500px'><tr><td align='left'><a href='CollectionManager.aspx'>继续采集</a></td><td align='right'><a href='javascript:history.back()'>返回上一页</a></td></tr></table>");
        Response.Flush();
        if (linkStr == string.Empty && getlinkStr.Length != 0)
        {
            Response.Write("<script>Info('注意：你所采集的数据已有部分入库了')</script>\r\n");
        }
    }

    private void CollectionStateFalse(int collId)
    {
        CollectionM = CollectionBll.GetIdByCollection(collId);
        DataTable dt = CollectionAddressBll.GetCollIdByCollAddress(collId);
        if (dt == null)
        {
            Response.Write("<script>Info('没有找到要采集的地址')</script>\r\n");
            return;
        }
        int RecordCount = dt.Rows.Count;
        Response.Write("<script>SetTotal(" + RecordCount + ")</script>\r\n");
        Response.Flush();
        for (int i = 0; i < RecordCount; i++)
        {
            string per = ((i * 100) / RecordCount).ToString("F1");
            bool result = CollectionBll.AddCollectionData(dt.Rows[i]["CollectionUrl"].ToString(), CollectionM);
            if (result)
                CollectionAddressBll.UpdateSate(dt.Rows[i]["CollectionUrl"].ToString());
            Response.Write("<script>Info('正在采集：" + dt.Rows[i]["CollectionUrl"].ToString() + "')</script>\r\n");
            Response.Write("<script>SetPr('" + per + "%'," + i + ")</script>\r\n");
            Response.Flush();
        }
        Response.Write("<script>SetPr('100.0%'," + RecordCount + ")</script>");
        Response.Write("<script>document.getElementById('finallytd').innerText = '采集完毕'</script>");
        Response.Write("<script>Info(' ')</script>\r\n");
        Response.Write("<table align='center' width='500px'><tr><td align='left'><a href='CollectionManager.aspx'>继续采集</a></td><td align='right'><a href='javascript:history.back()'>返回上一页</a></td></tr></table>");
        Response.Flush();  
    }
}
