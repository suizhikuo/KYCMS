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

public partial class system_create_Createing : System.Web.UI.Page
{
    B_Admin AdminBll = new B_Admin();
    B_PowerGroup GroupBll = new B_PowerGroup();
    B_SiteInfo SiteBll = new B_SiteInfo();
    B_Create CreateBll = new B_Create();
    B_InfoModel InfoModelBll = new B_InfoModel();
    M_Site SiteModel = null;
    string type = string.Empty;
    int RecordCount = 0;
    private static int modelId = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        GroupBll.Power_Judge(7);
        Response.Cache.SetNoStore();
        Response.Buffer = false;
        SiteModel = SiteBll.GetSiteModel();
        string htmlstr = "<html><head><link rel='stylesheet' href='../css/default.css' type='text/css' /></head><body>\r\n<br/><br/>\r\n<div align='center'><div style='width:500px;border:solid 1px gray;height:24px' align='left'><img id='tp' height='22px' src='../images/loading.gif' width='0px'></div>\r\n</div></div>\r\n<table width='500px' align='center'><tr><td align='center' width='250px'><span id='tn'>0%</span></td><td align='center' width='250px' id='finallytd'>共<span id='total'>0</span>条</td></tr></table><script>\r\nfunction SetPr(val,curr){ \r\n document.getElementById('tp').style.width = val;document.getElementById('tn').innerText=val; \r\n}\r\nfunction SetTotal(val){ document.getElementById('total').innerText=val;}</script>\r\n</body>\r\n";
        Response.Write(htmlstr);
        Response.Flush();
        if (!string.IsNullOrEmpty(Request.QueryString["Type"]))
        {
            type = Request.QueryString["Type"].ToLower();
            if(Request.QueryString["modelId"]!=null)
                modelId = int.Parse(Request.QueryString["modelId"].ToString());
        }
        switch (type)
        {
            case "index": CreateIndex(); break;                                                   //生成全站首页
            case "channel": CreateChannel(); break;                                            //生成频道页
            case "column": CreateColumn(); break;                                              //生成栏目页
            case "infoall": CreateInfo(modelId); break;                                         //生成指定模型的所有数据
            case "info": CreateInfoByIdStr(modelId); break;                                 //内容列表处生成静态
            case "infoid": CreateInfoId(modelId); break;                                      //将指定Id范围内的内容生成静态
            case "lastinfocount": CreateLastInfoRecord(modelId); break;            //生成最新多少条记录             
            case "infodate": CreateInfoDate(modelId); break;                             //生成指定日期范围内的记录
            case "infocolumn": CreateInfoColumn(modelId); break;                     //生成指定栏目下的内容
            case "columnall": CreateColumnAll(); break;
            case "special": CreateSpecial(); break;
        }
        string browserIndex = string.Empty;
        if (type == "index")
            browserIndex = "<td><a href=\""+CreateBll.GetIndexUrl()+"\" target='_blank'>浏览首页</a></td>";
        Response.Write("<table align='center' width='500px'><tr><td align='left'><a href='CreateNews.aspx?modelId="+modelId+"'>继续生成</a></td>" + browserIndex + "<td align='right'><a href='javascript:history.back()'>返回上一页</a></td></tr></table>");
        Response.Flush();
    }

    protected void CreateIndex()
    {
        Response.Write("<script>SetTotal(1)</script>\r\n");
        Response.Flush();
        CreateBll.CreateIndexPage();
        Response.Write("<script>SetPr('100.0%','1')</script>\r\n");
        Response.Write("<script>document.getElementById('finallytd').innerText = '生成完毕'</script>");
        
        Response.Flush();
        CreateBll.ClearHashTable();

    }

    #region 频道生成
    protected void CreateChannel()
    {

        string chIdStr = Session["createchid"].ToString();
        string[] chIdArray = chIdStr.Split(',');
        RecordCount = chIdArray.Length;
        Response.Write("<script>SetTotal(" + RecordCount + ")</script>\r\n");
        Response.Flush();

        for (int i = 1; i <= RecordCount; i++)
        {
            string per = ((i * 100) / RecordCount).ToString("F1");
            CreateBll.CreateChannelPage(int.Parse(chIdArray[i - 1]));
            Response.Write("<script>SetPr('" + per + "%'," + i + ")</script>\r\n");
            Response.Flush();

        }
        Response.Write("<script>SetPr('100.0%'," + RecordCount + ")</script>");
        Response.Write("<script>document.getElementById('finallytd').innerText = '生成完毕'</script>");
        Response.Flush();
        Session["createchid"] = null;
        CreateBll.ClearHashTable();
    }
    #endregion

    #region 发布所有栏目
    protected void CreateColumnAll()
    {
        B_Column bll = new B_Column();
        DataTable dt = bll.GetList(false).ToTable();
        RecordCount = dt.Rows.Count;
        Response.Write("<script>SetTotal(" + RecordCount + ")</script>\r\n");
        Response.Flush();

        for (int i = 1; i <= RecordCount; i++)
        {
            string per = ((i * 100) / RecordCount).ToString("F1");
            CreateBll.CreateColumnlPage((int)dt.Rows[i-1]["ColId"]);
            Response.Write("<script>SetPr('" + per + "%'," + i + ")</script>\r\n");
            Response.Flush();
        }
        Response.Write("<script>SetPr('100.0%'," + RecordCount + ")</script>");
        Response.Write("<script>document.getElementById('finallytd').innerText = '生成完毕'</script>");
        Response.Flush();
        CreateBll.ClearHashTable();
    }
    #endregion

    #region 栏目生成
    protected void CreateColumn()
    {
        string colIdStr = Session["createcolid"].ToString();
        string[] colArray = colIdStr.Split(',');
        RecordCount = colArray.Length;
        Response.Write("<script>SetTotal(" + RecordCount + ")</script>\r\n");
        Response.Flush();

        for (int i = 1; i <= RecordCount; i++)
        {
            string per = ((i * 100) / RecordCount).ToString("F1");
            CreateBll.CreateColumnlPage(int.Parse(colArray[i - 1]));
            Response.Write("<script>SetPr('" + per + "%'," + i + ")</script>\r\n");
            Response.Flush();
        }
        Response.Write("<script>SetPr('100.0%'," + RecordCount + ")</script>");
        Response.Write("<script>document.getElementById('finallytd').innerText = '生成完毕'</script>");
        Response.Flush();
        CreateBll.ClearHashTable();
        Session["createcolid"] = null;
    }
    #endregion
   
    #region 将指定模型的所有生成静态
    protected void CreateInfo(int modelIdNum)
    {
        M_InfoModel infoModelM = InfoModelBll.GetModel(modelIdNum);                                                       //取得对应Id的模板信息
        string tableName = infoModelM.TableName;                                                                          //取得模型的表名
        string modelName = infoModelM.ModelName;

        B_SiteInfo bllSite = new B_SiteInfo();
        M_InfoSite mInfoSite = bllSite.GetInfoModel();
        int pageSize = mInfoSite.InfoCreateNum;

        int pageIndex = 1;                                                                                                //初始化页的索引号
        int recordCount = 0;                                                                                              //统计要生成新闻的条数
        int pageTotl = 0;                                                                                                 //统计总页数

        B_Create createBll = new B_Create();
        createBll.InfoRecordCount(tableName, "", ref recordCount);

        pageTotl = (recordCount - 1) / pageSize + 1;
        Response.Write("<script>SetTotal(" + recordCount + ")</script>\r\n");
         Response.Flush();
        string currentPer = "0.0";
        for (int crti = 1; crti <= pageTotl; crti++)
        {
            pageIndex = crti;

            DataTable dt = createBll.GetInfo(tableName, pageIndex, pageSize);
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                int currIndex = pageSize * (crti - 1) + i;
                string per = ((double)currIndex * 100 / (double)recordCount).ToString("F1");
                CreateBll.CreateInfo(dt.Rows[i - 1]);
                if (currentPer != per)
                {
                    currentPer = per;
                    Response.Write("<script>SetPr('" + per + "%'," + currIndex + ")</script>\r\n");
                    Response.Flush();
                }
            }
            dt.Dispose();
        }

        Response.Write("<script>SetPr('100.0%'," + recordCount + ")</script>");
        Response.Write("<script>document.getElementById('finallytd').innerText = '生成完毕'</script>");
        Response.Flush();
        CreateBll.ClearHashTable();
    }
    #endregion

    #region 将指定Id范围内的文章静态生成
    protected void CreateInfoId(int modelIdNum)
    {
        M_InfoModel infoModelM = InfoModelBll.GetModel(modelIdNum);                                                       //取得对应Id的模板信息
        string tableName = infoModelM.TableName;                                                                                        //取得模型的表名

        int startId = int.Parse(Request.QueryString["startid"].ToString());
        int endId = int.Parse(Request.QueryString["endid"].ToString());
        B_Create CreateBll = new B_Create();
        B_SiteInfo bllSite = new B_SiteInfo();
        M_InfoSite mInfoSite = bllSite.GetInfoModel();
        int pageSize = mInfoSite.InfoCreateNum;
        int pageIndex = 1;
        int recordCount = 0;
        int pageTotl = 0;

        string wheStr = " and i.id in(select id from " + tableName + " where id>=" + startId + " and id<=" + endId + ") ";

        CreateBll.InfoRecordCount(tableName, wheStr, ref recordCount);

        pageTotl = (recordCount - 1) / pageSize + 1;
        Response.Write("<script>SetTotal(" + recordCount + ")</script>\r\n");
        Response.Flush();
        string currentPer = "0.0";
        for (int crti = 1; crti <= pageTotl; crti++)
        {
            pageIndex = crti;

            DataTable dt = CreateBll.GetIdRange(tableName, startId, endId, pageIndex, pageSize);
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                int currIndex = pageSize * (crti - 1) + i;
                string per = ((double)currIndex * 100 / (double)recordCount).ToString("F1");
                CreateBll.CreateInfo(dt.Rows[i - 1]);
                if (currentPer != per)
                {
                    currentPer = per;
                    Response.Write("<script>SetPr('" + per + "%'," + currIndex + ")</script>\r\n");
                    Response.Flush();
                }
            }
            dt.Dispose();
        }

        Response.Write("<script>SetPr('100.0%'," + recordCount + ")</script>");
        Response.Write("<script>document.getElementById('finallytd').innerText = '生成完毕'</script>");
        Response.Flush();
        CreateBll.ClearHashTable();
    }
    #endregion

    #region 将最新多少条文章生成静态
    protected void CreateLastInfoRecord(int modelId)
    {
        M_InfoModel infoModelM = InfoModelBll.GetModel(modelId);                                                       //取得对应Id的模板信息
        string tableName = infoModelM.TableName;                                                                                        //取得模型的表名

        int newRecord = int.Parse(Request.QueryString["newsrecordcount"].ToString());
        B_Create CreateBll = new B_Create();

        B_SiteInfo bllSite = new B_SiteInfo();
        M_InfoSite mInfoSite = bllSite.GetInfoModel();
        int pageSize = mInfoSite.InfoCreateNum;
        int pageIndex = 1;
        int recordCount = CreateBll.LastInfoCount(tableName, newRecord);
        int pageTotl = 0;
                
        pageTotl = (recordCount - 1) / pageSize + 1;
        Response.Write("<script>SetTotal(" + recordCount + ")</script>\r\n");
        Response.Flush();
        string currentPer = "0.0";
        for (int crti = 1; crti <= pageTotl; crti++)
        {
            pageIndex = crti;
            DataTable dt = CreateBll.GetNewRecordNum(tableName, newRecord, pageIndex, pageSize);
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                int currIndex = pageSize * (crti - 1) + i;
                string per = ((double)currIndex * 100 / (double)recordCount).ToString("F1");
                CreateBll.CreateInfo(dt.Rows[i - 1]);
                if (currentPer != per)
                {
                    currentPer = per;
                    Response.Write("<script>SetPr('" + per + "%'," + currIndex + ")</script>\r\n");
                    Response.Flush();
                }
            }
            dt.Dispose();
        }

        Response.Write("<script>SetPr('100.0%'," + recordCount + ")</script>");
        Response.Write("<script>document.getElementById('finallytd').innerText = '生成完毕'</script>");
        Response.Flush();
        CreateBll.ClearHashTable();
    }
    #endregion

    #region 将指定日期范围内的文章生成静态
    protected void CreateInfoDate(int modelId)
    {
        M_InfoModel infoModelM = InfoModelBll.GetModel(modelId);                                                       //取得对应Id的模板信息
        string tableName = infoModelM.TableName; 

        string startDate = Request.QueryString["startdate"].ToString();
        string endDate = Request.QueryString["enddate"].ToString();
        
        B_Create CreateBll = new B_Create();
        B_SiteInfo bllSite = new B_SiteInfo();
        M_InfoSite mInfoSite = bllSite.GetInfoModel();
        int pageSize = mInfoSite.InfoCreateNum;


        int pageIndex = 1;
        int recordCount = 0;
        int pageTotl = 0;

        B_Create bllCreate = new B_Create();
        string wheStr = "and i.AddTime>=\'" + startDate + "\' and i.AddTime<=\'" + endDate + "\'";
        CreateBll.InfoRecordCount(tableName,wheStr,ref recordCount);

        pageTotl = (recordCount - 1) / pageSize + 1;
        Response.Write("<script>SetTotal(" + recordCount + ")</script>\r\n");
        Response.Flush();
        string currentPer = "0.0";
        for (int crti = 1; crti <= pageTotl; crti++)
        {
            pageIndex = crti;
            DataTable dt = CreateBll.GetDateRange(tableName, startDate, endDate, pageIndex, pageSize);
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                int currIndex = pageSize * (crti - 1) + i;
                string per = ((double)currIndex * 100 / (double)recordCount).ToString("F1");
                CreateBll.CreateInfo(dt.Rows[i - 1]);
                if (currentPer != per)
                {
                    currentPer = per;
                    Response.Write("<script>SetPr('" + per + "%'," + currIndex + ")</script>\r\n");
                    Response.Flush();
                }
            }
            dt.Dispose();
        }

        Response.Write("<script>SetPr('100.0%'," + recordCount + ")</script>");
        Response.Write("<script>document.getElementById('finallytd').innerText = '生成完毕'</script>");
        Response.Flush();
        CreateBll.ClearHashTable();
    }
    #endregion

    #region 生成当前栏目下的文章
    protected void CreateInfoColumn(int modelId)
    {
        M_InfoModel infoModelM = InfoModelBll.GetModel(modelId);                                                       //取得对应Id的模板信息
        string tableName = infoModelM.TableName; 

        B_Create CreateBll = new B_Create();

        B_SiteInfo bllSite = new B_SiteInfo();
        M_InfoSite mInfoSite = bllSite.GetInfoModel();
        int pageSize = mInfoSite.InfoCreateNum;
        int pageIndex = 1;
        int recordCount = 0;
        int pageTotl = 0;

        string infoColId = Session["newscolumnid"].ToString();
        string wheStr = " and i.colid in(" + infoColId + ")";
        CreateBll.InfoRecordCount(tableName, wheStr,ref recordCount);

        pageTotl = (recordCount - 1) / pageSize + 1;
        Response.Write("<script>SetTotal(" + recordCount + ")</script>\r\n");
        Response.Flush();
        string currentPer = "0.0";
        for (int crti = 1; crti <= pageTotl; crti++)
        {
            pageIndex = crti;
            DataTable dt = CreateBll.GetColumnAll(tableName, infoColId,pageIndex, pageSize);
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                int currIndex = pageSize * (crti - 1) + i;
                string per = ((double)currIndex * 100 / (double)recordCount).ToString("F1");
                CreateBll.CreateInfo(dt.Rows[i - 1]);
                if (currentPer != per)
                {
                    currentPer = per;
                    Response.Write("<script>SetPr('" + per + "%'," + currIndex + ")</script>\r\n");
                    Response.Flush();
                }
            }
            dt.Dispose();
        }

        Response.Write("<script>SetPr('100.0%'," + recordCount + ")</script>");
        Response.Write("<script>document.getElementById('finallytd').innerText = '生成完毕'</script>");
        Response.Flush();
        CreateBll.ClearHashTable();
    }
    #endregion

    #region 发布指定ID文章
    protected void CreateInfoByIdStr(int modelId)
    {
        string infoIdStr = Session["CreateInfoIdStr"].ToString();
        
        string[] IdArray = infoIdStr.Split(',');
        RecordCount = IdArray.Length;
        Response.Write("<script>SetTotal(" + RecordCount + ")</script>\r\n");
        Response.Flush();
        string currentPer = "0.0";
        for (int i = 1; i <= RecordCount; i++)
        {
            string per = ((double)(i * 100) / (double)RecordCount).ToString("F1");

            M_InfoModel infoModelM = InfoModelBll.GetModel(modelId);
            string tableName = infoModelM.TableName;
            DataRow dr = CreateBll.GetInfoById(tableName, int.Parse(IdArray[i - 1]));
            CreateBll.CreateInfo(dr);
            if (currentPer != per)
            {
                currentPer = per;
                Response.Write("<script>SetPr('" + per + "%'," + i + ")</script>\r\n");
                Response.Flush();
            }
        }
        Response.Write("<script>SetPr('100%'," + RecordCount + ")</script>");
        Response.Write("<script>document.getElementById('finallytd').innerText = '生成完毕'</script>");
        Response.Flush();
        CreateBll.ClearHashTable();
        Session["CreateNewsIdStr"] = null;
    }
    #endregion

    #region 生成专题
    protected void CreateSpecial()
    {
        string spIdStr = Session["createspecialstr"].ToString();
        string[] spIdArray = spIdStr.Split(',');
        RecordCount = spIdArray.Length;
        Response.Write("<script>SetTotal(" + RecordCount + ")</script>\r\n");
        Response.Flush();
        for (int i = 1; i <= RecordCount; i++)
        {
            string per = ((i * 100) / RecordCount).ToString("F1");
            CreateBll.CreateSpecialPage(int.Parse(spIdArray[i - 1]));
            Response.Write("<script>SetPr('" + per + "%'," + i + ")</script>\r\n");
            Response.Flush();

        }
        Response.Write("<script>SetPr('100.0%'," + RecordCount + ")</script>");
        Response.Write("<script>document.getElementById('finallytd').innerText = '生成完毕'</script>");
        Response.Flush();
        Session["createspecialstr"] = null;
        CreateBll.ClearHashTable();
    }
    #endregion

}
