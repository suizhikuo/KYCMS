﻿using System;
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
using Ky.BLL;
using Ky.Model;
using System.Text.RegularExpressions;
public partial class system_collection_EditObject : System.Web.UI.Page
{
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    private B_ModelField BModelField = new B_ModelField();
    private B_Channel ChannelBll = new B_Channel();
    private B_Column ColumnBll = new B_Column();
    private B_InfoModel InfoModelBll = new B_InfoModel();
    private B_SysModelField SysModelField = new B_SysModelField();
    private B_Collection CollectionBll = new B_Collection();
    private B_Superior SuperiorBll = new B_Superior();
    private M_InfoModel ModelM = new M_InfoModel();
    private M_Channel ChannelM = new M_Channel();
    private M_Column ColumnM = new M_Column();
    private M_Collection CollectionM = new M_Collection();
    private M_Special SpecialM = new M_Special();
    private B_Special SpecialBll = new B_Special();


    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(48);
        AjaxPro.Utility.RegisterTypeForAjax(typeof(system_collection_EditObject));
        if (!IsPostBack)
        {
            if (!(Request.QueryString["Id"] == null || Request.QueryString["Id"].Length == 0))
            {
                #region 边辑赋值
                BindSuperior();
                int id = int.Parse(Request.QueryString["Id"].ToString());

                CollectionM = CollectionBll.GetIdByCollection(id);
                
                BindTable(CollectionM.ColId);

                txtObjectName.Text = CollectionM.ObjectName;
                txtWebSite.Text = CollectionM.WebSite;

                ColumnM = ColumnBll.GetColumn(CollectionM.ColId);
                txtColumnId.Text = ColumnM.ColName;
                hidColumnId.Value = CollectionM.ColId.ToString(); 

                if (CollectionM.SpecialId != null && CollectionM.SpecialId.Length!=0)
                {
                    string[] specialIdArr = CollectionM.SpecialId.Split('|');
                    string notNullSpIdStr = string.Empty;
                    for (int i = 0; i < specialIdArr.Length;i++ )
                    {
                        if (specialIdArr[i].Length != 0)
                            notNullSpIdStr = notNullSpIdStr + specialIdArr[i]+"|";
                    }
                    string[] SpecialArr = notNullSpIdStr.Split('|');
                    string SpecialName = string.Empty;
                    for (int i = 0; i < SpecialArr.Length - 1; i++)
                    {
                        SpecialM = SpecialBll.GetSpecial(int.Parse(SpecialArr[i]));
                        if (i == SpecialArr.Length - 2)
                            SpecialName = SpecialName + SpecialM.SpecialCName;
                        else
                            SpecialName = SpecialName + SpecialM.SpecialCName + ",";
                    }
                    txtSpecialId.Text = SpecialName;
                    hidSpecialId.Value = CollectionM.SpecialId.ToString();
                }
                

                string charSet = CollectionM.CharSet;
                if (charSet == "0")
                    rdoCharSet.Items[0].Selected = true;
                else if (charSet == "1")
                    rdoCharSet.Items[1].Selected = true;

                txtListUrl.Text = CollectionM.ListPageUrl;
                txtObjectDemo.Text = CollectionM.ObjectDemo;
                txtListStart.Text = CollectionM.ListStartCode;
                txtListEnd.Text = CollectionM.ListEndCode;
                txtLinkStart.Text = CollectionM.LinkStartCode;
                txtLinkEnd.Text = CollectionM.LinkEndCode;

                //分页设置
                string pageSet = CollectionM.PageSet;
                if (pageSet != "")
                {
                    string[] pageArr = pageSet.Split('|');
                    int rdoId = int.Parse(pageArr[0].Split('┃')[1]);
                    switch (rdoId)
                    { 
                        case 0:
                            rdoPage0.Checked = true;
                            break;
                        case 1:
                            rdoPage1.Checked = true;
                            txtNextPageStart.Text = pageArr[1].Split('┃')[1];
                            txtNextPageEnd.Text = pageArr[2].Split('┃')[1];
                            break;
                        case 2:
                            rdoPage2.Checked = true;
                            txtUrlStr.Text = pageArr[1].Split('┃')[1];
                            txtStartId.Text = pageArr[2].Split('┃')[1];
                            txtEndId.Text = pageArr[3].Split('┃')[1];
                            break;
                        case 3:
                            rdoPage3.Checked = true;
                            txtUrlList.Text = pageArr[1].Split('┃')[1];
                            break;
                    }
                }

                //内容分页设置
                string conPageSet = CollectionM.ContentPageSet;
                if (conPageSet != "")
                {
                    string[] pageArr = conPageSet.Split('|');
                    int rdoId = int.Parse(pageArr[0].Split('┃')[1]);
                    switch (rdoId)
                    {
                        case 0:
                            rdoConPage1.Checked = true;
                            break;
                        case 1:
                            rdoConPage2.Checked = true;
                            txtConPageStart.Text = pageArr[1].Split('┃')[1];
                            txtConPageEnd.Text = pageArr[2].Split('┃')[1];
                            break;
                        case 2:
                            rdoConPage3.Checked = true;
                            txtConAddress.Text = pageArr[1].Split('┃')[1];
                            txtConStartId.Text = pageArr[2].Split('┃')[1];
                            txtConEndId.Text = pageArr[3].Split('┃')[1];
                            break;
                        case 3:
                            rdoConPage4.Checked = true;
                            txtConPageAddress.Text = pageArr[1].Split('┃')[1];
                            break;
                    }
                }


                //字段设置
                string fieldList = CollectionM.FieldListSet;
                if (fieldList != "")
                {
                    string[] fieldArr = fieldList.Split('|');
                    for (int i = 0; i < fieldArr.Length - 1; i++)
                    {
                        for (int j = 0; j < lbFildList.Items.Count; j++)
                        {
                            if (lbFildList.Items[j].Value == fieldArr[i].ToString().Split(',')[0].ToString())
                                lbFildList.Items[j].Selected = true;
                        }
                    }
                    hidFieldValue.Value = fieldList;
                }

                //简单过滤规则
                string simpleFilterRule = CollectionM.SimpleFilterRule;
                if (simpleFilterRule != "")
                {
                    string[] simFilRuleArr = simpleFilterRule.Split(',');
                    for (int i = 0; i < simFilRuleArr.Length - 1; i++)
                    {
                        for (int j = 0; j < chkSimpleFilter.Items.Count; j++)
                        {
                            if (chkSimpleFilter.Items[j].Value == simFilRuleArr[i])
                            {
                                chkSimpleFilter.Items[j].Selected = true;
                            }
                        }
                    }
                }

                //复杂过滤规则
                string complexityFilterRule = CollectionM.ComplexityFilterRule;
                string[] superiorArr = complexityFilterRule.Split(',');
                if (complexityFilterRule != "")
                {
                    for (int j = 0; j < superiorArr.Length; j++)
                    {
                        for (int i = 0; i < lbFilterRule.Items.Count; i++)
                        {
                            if (lbFilterRule.Items[i].Value == superiorArr[j])
                            {
                                lbFilterRule.Items[i].Selected = true;
                            }
                        }
                    }
                }

                //属性设置
                string protery = CollectionM.ProterySet;
                if (protery != "")
                {
                    string[] proteryArr = protery.Split(',');
                    for (int i = 0; i < proteryArr.Length - 1; i++)
                    {
                        for (int j = 0; j < chkPropetry.Items.Count; j++)
                        {
                            if (chkPropetry.Items[j].Value == proteryArr[i])
                                chkPropetry.Items[j].Selected = true;
                        }
                    }
                }

                //评分等级
                for (int i = 0; i < ddlStarLevel.Items.Count; i++)
                {
                    if (ddlStarLevel.Items[i].Value == CollectionM.StarLevel)
                        ddlStarLevel.Items[i].Selected = true;
                }

                txtHitCout.Text = CollectionM.HiteCount.ToString();
                #endregion
            }
        }
    }

    #region 绑定表的字段
    public void BindTable(int colid)
    {
        ColumnM = ColumnBll.GetColumn(colid);
        ChannelM = ChannelBll.GetChannel(ColumnM.ChId);
        DataTable dt = new DataTable();
        switch (ChannelM.ModelType)
        { 
            case 1:
                dt = SysModelField.CollArticleDt();
                break;
            case 2:
                dt = SysModelField.CollImageDt();
                break;
            case 3:
                dt = SysModelField.CollDownLoadDt();
                break;
            default:
                dt = BModelField.GetList(ChannelM.ModelType);
                DataRow dr = dt.NewRow();
                dr["Alias"] = "标题";
                dr["Name"] = "Title";
                dt.Rows.InsertAt(dr, 0);

                DataRow dr2 = dt.NewRow();
                dr2["Alias"] = "录入者";
                dr2["Name"] = "UName";
                dt.Rows.InsertAt(dr2,1);

                DataRow dr3 = dt.NewRow();
                dr3["Alias"] = "责任编辑";
                dr3["Name"] = "AdminUName";
                dt.Rows.InsertAt(dr3,2);

                DataRow dr4 = dt.NewRow();
                dr4["Alias"] = "添加日期";
                dr4["Name"] = "AddTime";
                dt.Rows.InsertAt(dr4,3);
                break;
        }
        lbFildList.DataSource = dt;
        lbFildList.DataTextField = "Alias";
        lbFildList.DataValueField = "Name";
        lbFildList.DataBind();
    }
    #endregion

    #region 绑定复杂过滤规则
    private void BindSuperior()
    {
        lbFilterRule.DataSource = SuperiorBll.GetList();
        lbFilterRule.DataTextField = "Name";
        lbFilterRule.DataValueField = "Id";
        lbFilterRule.DataBind();
    }
    #endregion

    #region 添加修改事件
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string[] fieldArr = null;

        string objectName = string.Empty;
        string webSite = string.Empty;
        int colId = 0;
        string specialId = string.Empty;
        string charSet = string.Empty;
        string listUrl = string.Empty;
        string objectDemo = string.Empty;
        string listStartCode = string.Empty;
        string listEndCode = string.Empty;
        string linkStartCode = string.Empty;
        string linkEndCode = string.Empty;

        string fieldValue = string.Empty;
        string pageSet = string.Empty;
        string contentPageSet = string.Empty;
        string simpleRule = string.Empty;
        string complexityFilterRule = string.Empty;
        string setProperty = string.Empty;
        string starLevel=string.Empty;
        int hitCout = 0;

        objectName = Request.Form["txtObjectName"];
        webSite = Request.Form["txtWebSite"];
        colId = int.Parse(Request.Form["hidColumnId"]);
        if(!(Request.Form["hidSpecialId"]==null||Request.Form["hidSpecialId"].Length==0))
        {
            specialId = Request.Form["hidSpecialId"];
        }
        charSet = Request.Form["rdoCharSet"];
        listUrl = Request.Form["txtListUrl"];
        objectDemo = Request.Form["txtObjectDemo"];
        listStartCode = Request.Form["txtListStart"];
        listEndCode = Request.Form["txtListEnd"];
        linkStartCode = Request.Form["txtLinkStart"];
        linkEndCode = Request.Form["txtLinkEnd"];

        #region 列表分页设置
        if (Request.Form["ListPaingType"] != null && Request.Form["ListPaingType"].Length != 0)
        {
            switch (int.Parse(Request.Form["ListPaingType"]))
            {
                case 0:
                    pageSet = pageSet + "pageSet┃0";
                    break;
                case 1:
                    pageSet = pageSet + "pageSet┃1|PageStartCode┃" + Request.Form["txtNextPageStart"] + "|";
                    pageSet = pageSet + "PageEndCode┃" + Request.Form["txtNextPageEnd"];
                    break;
                case 2:
                    pageSet = pageSet + "pageSet┃2|ListPageAddress┃" + Request.Form["txtUrlStr"] + "|";
                    pageSet = pageSet + "StartPageId┃" + Request.Form["txtStartId"] + "|";
                    pageSet = pageSet + "EndPageId┃" + Request.Form["txtEndId"];
                    break;
                case 3:
                    pageSet = pageSet + "pageSet┃3|PageListUrl┃" + Request.Form["txtUrlList"];
                    break;
            }
        }
        else
        {
            pageSet = pageSet + "pageSet┃0";
        }
        #endregion

        #region 内容分页设置
        if (Request.Form["ConPaingType"] != null && Request.Form["ConPaingType"].Length != 0)
        {
            switch (int.Parse(Request.Form["ConPaingType"]))
            {
                case 0:
                    contentPageSet = contentPageSet + "pageSet┃0";
                    break;
                case 1:
                    contentPageSet = contentPageSet + "pageSet┃1|PageStartCode┃" + Request.Form["txtConPageStart"] + "|";
                    contentPageSet = contentPageSet + "PageEndCode┃" + Request.Form["txtConPageEnd"];
                    break;
                case 2:
                    contentPageSet = contentPageSet + "pageSet┃2|ListPageAddress┃" + Request.Form["txtConAddress"] + "|";
                    contentPageSet = contentPageSet + "StartPageId┃" + Request.Form["txtConStartId"] + "|";
                    contentPageSet = contentPageSet + "EndPageId┃" + Request.Form["txtConEndId"];
                    break;
                case 3:
                    contentPageSet = contentPageSet + "pageSet┃3|PageListUrl┃" + Request.Form["txtConPageAddress"];
                    break;
            }
        }
        else
        {
            contentPageSet = contentPageSet + "pageSet┃0";
        }
        #endregion

        #region 字段列表设置
        if (!(Request.Form["lbFildList"] == null || Request.Form["lbFildList"].Length == 0))
        {
            fieldArr = Request.Form["lbFildList"].ToString().Split(',');
            for (int i = 0; i < fieldArr.Length; i++)
                fieldValue = fieldValue + fieldArr[i].ToString() + "," + Request.Form[fieldArr[i] + "Start"].ToString() + "," + Request.Form[fieldArr[i] + "End"].ToString() + "," + Request.Form[fieldArr[i] + "Default"].ToString() + "|";
        }
        #endregion

        #region 简单过滤规则
        for (int i = 0; i < chkSimpleFilter.Items.Count; i++)
        {
            if (chkSimpleFilter.Items[i].Selected == true)
            {
                simpleRule = simpleRule + chkSimpleFilter.Items[i].Value + ",";
            }
        }
        #endregion

        //复杂过滤规则
        if (!(Request.Form["lbFilterRule"] == null || Request.Form["lbFilterRule"].Length == 0))
        {
            complexityFilterRule = Request.Form["lbFilterRule"];
        }

        #region 属性设置
        for (int i = 0; i < chkPropetry.Items.Count; i++)
        {
            if (chkPropetry.Items[i].Selected == true)
            {
                setProperty = setProperty + chkPropetry.Items[i].Value + ",";
            }
        }
        #endregion

        //评分等级
        starLevel = Request.Form["ddlStarLevel"];

        //点击数
        if (!(Request.Form["txtHitCout"] == null || Request.Form["txtHitCout"].Length == 0))
        {
            hitCout = int.Parse(Request.Form["txtHitCout"]);
        }
        CollectionM.Id = int.Parse(Request.QueryString["id"].ToString());
        CollectionM.ObjectName = objectName;
        CollectionM.WebSite = webSite;
        CollectionM.ColId = colId;
        CollectionM.SpecialId = specialId;
        CollectionM.CharSet = charSet;
        CollectionM.ListPageUrl = listUrl;
        CollectionM.ObjectDemo = objectDemo;
        CollectionM.ListStartCode = listStartCode;
        CollectionM.ListEndCode = listEndCode;
        CollectionM.LinkStartCode = linkStartCode;
        CollectionM.LinkEndCode = linkEndCode;
        CollectionM.PageSet = pageSet;
        CollectionM.ContentPageSet = contentPageSet;
        CollectionM.FieldListSet = fieldValue;
        CollectionM.SimpleFilterRule = simpleRule;
        CollectionM.ComplexityFilterRule = complexityFilterRule;
        CollectionM.ProterySet = setProperty;
        CollectionM.StarLevel = starLevel;
        CollectionM.HiteCount = hitCout;
        CollectionBll.Update(CollectionM);
        Response.Redirect("CollectionManager.aspx");
    }
    #endregion


    #region 代码预览
    [AjaxPro.AjaxMethod]
    public string CodePre(object obj)
    {
        string linkStr = string.Empty;
        string paramStr = obj.ToString();
        string[] paramArr = paramStr.Split('|');
        string charSet = "gb2312";
        try
        {
            if (paramArr[5].ToString() != "0")
            {
                charSet = "UTF-8";
            }
            string htmlCode = CollectionBll.GetHtmlCode(paramArr[0], charSet);
            string listRegexStr = CollectionBll.TransferStr(paramArr[1]) + "((?:.|\n)*?)" + CollectionBll.TransferStr(paramArr[2]);
            string listHtmlCode = CollectionBll.GetRegValue(listRegexStr, htmlCode);
            string linkRegexStr = CollectionBll.TransferStr(paramArr[3]) + "((?:.|\n)*?)" + CollectionBll.TransferStr(paramArr[4]);
            MatchCollection match = Regex.Matches(listHtmlCode, linkRegexStr, RegexOptions.IgnoreCase);
            foreach (Match m in match)
            {
                linkStr = linkStr + m.Value.Replace(CollectionBll.TransferStr(paramArr[3]), "").Replace(CollectionBll.TransferStr(paramArr[4]), "") + "\r\n";
            }
        }
        catch
        { 
        }
        if (linkStr == "")
            linkStr = "你的参数据设置有误";
        return linkStr;
    }
    #endregion

    #region 采样测试
    [AjaxPro.AjaxMethod]
    public string CollectionTest(object obj)
    {
        string collectionStr = string.Empty;
        string[] paramArr = obj.ToString().Split('$');
        try
        {
            //列表页
            string[] listArr = paramArr[0].Split('|');
            string charSet="gb2312";
            if (listArr[5].ToString() != "0")
                charSet = "UTF-8";
            string htmlCode = CollectionBll.GetHtmlCode(listArr[0], charSet);
            string listRegexStr = CollectionBll.TransferStr(listArr[1]) + "((?:.|\n)*?)" + CollectionBll.TransferStr(listArr[2]);
            string listHtmlCode = CollectionBll.GetRegValue(listRegexStr, htmlCode);
            string linkRegexStr = CollectionBll.TransferStr(listArr[3]) + "((?:.|\n)*?)" + CollectionBll.TransferStr(listArr[4]);
            string linkStr = CollectionBll.LinkStr(listHtmlCode,listArr[0], linkRegexStr, listArr[6]);
            string[] linkArr = linkStr.Split(',');
            Random random = new Random();

            string linkRandomStr = string.Empty;
            if (listArr.Length > 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (i == 1)
                        linkRandomStr = linkRandomStr + linkArr[random.Next(linkArr.Length - 1)].ToString();
                    else
                        linkRandomStr = linkRandomStr + linkArr[random.Next(linkArr.Length - 1)].ToString() + ",";
                }
            }
            string[] randomLinkArr = linkRandomStr.Split(',');

            CollectionM.WebSite = listArr[6];
            CollectionM.FieldListSet = paramArr[2];
            CollectionM.CharSet = listArr[5];
            CollectionM.ColId = int.Parse(paramArr[3]);
            CollectionM.ContentPageSet = paramArr[4];
            CollectionM.SimpleFilterRule = paramArr[5];
            CollectionM.ComplexityFilterRule = paramArr[6];

            //内容页
            string ContentStr = string.Empty;
            for (int i = 0; i < randomLinkArr.Length; i++)
            {
                ContentStr = CollectionBll.GetContent(randomLinkArr[i], CollectionM);
                if (ContentStr != "" && ContentStr.Length != 0)
                {
                    string[] conArr = ContentStr.Split('┃');
                    for (int j = 0; j < paramArr[1].Split('|').Length - 1; j++)
                    {
                        collectionStr = collectionStr + paramArr[1].Split('|')[j].ToString() + "：" + conArr[1].Split('$')[j].ToString().Trim() + "\r\n\r\n";
                    }
                }
            }
        }
        catch
        { }
        if (collectionStr == "" || collectionStr.Length == 0)
            collectionStr = "采集参数据设置有误";
        
        return collectionStr;
    }
    #endregion

    #region 采样测试
    [AjaxPro.AjaxMethod]
    public string FieldPre(object obj)
    {
        string collectionStr = string.Empty;
        string[] paramArr = obj.ToString().Split('$');
        try
        {
        //列表页
        string[] listArr = paramArr[0].Split('|');
        string charSet = "gb2312";
        if (listArr[5].ToString() != "0")
            charSet = "UTF-8";
        string htmlCode = CollectionBll.GetHtmlCode(listArr[0], charSet);
        string listRegexStr = CollectionBll.TransferStr(listArr[1]) + "((?:.|\n)*?)" + CollectionBll.TransferStr(listArr[2]);
        string listHtmlCode = CollectionBll.GetRegValue(listRegexStr, htmlCode);
        string linkRegexStr = CollectionBll.TransferStr(listArr[3]) + "((?:.|\n)*?)" + CollectionBll.TransferStr(listArr[4]);
        string linkStr = CollectionBll.LinkStr(listHtmlCode,listArr[0], linkRegexStr, listArr[6]);
        string[] linkArr = linkStr.Split(',');
        Random random = new Random();

        string linkRandomStr = string.Empty;
        if (listArr.Length > 2)
        {
            for (int i = 0; i < 2; i++)
            {
                if (i == 1)
                    linkRandomStr = linkRandomStr + linkArr[random.Next(linkArr.Length - 1)].ToString();
                else
                    linkRandomStr = linkRandomStr + linkArr[random.Next(linkArr.Length - 1)].ToString() + ",";
            }
        }
        string[] randomLinkArr = linkRandomStr.Split(',');

        CollectionM.WebSite = listArr[6];
        CollectionM.FieldListSet = paramArr[2];
        CollectionM.CharSet = listArr[5];
        CollectionM.ColId = int.Parse(paramArr[3]);
        CollectionM.ContentPageSet = paramArr[4];
        CollectionM.SimpleFilterRule = paramArr[5];
        CollectionM.ComplexityFilterRule = paramArr[6];

        //内容页
        string ContentStr = string.Empty;
        for (int i = 0; i < randomLinkArr.Length-1; i++)
        {
            ContentStr = CollectionBll.GetContent(randomLinkArr[i], CollectionM);
            if (ContentStr != "" && ContentStr.Length != 0)
            {
                string[] conArr = ContentStr.Split('┃');
                for (int j = 0; j < paramArr[1].Split('|').Length - 1; j++)
                {
                    collectionStr = collectionStr + paramArr[1].Split('|')[j].ToString() + "：" + conArr[1].Split('$')[j].ToString() + "\r\n\r\n";
                }
            }
        }
    }
    catch
    { }
        if (collectionStr == "" || collectionStr.Length == 0)
            collectionStr = "采集参数据设置有误";

        return collectionStr;
    }
    #endregion

    #region 检测代码是否唯一
    [AjaxPro.AjaxMethod]
    public string CheckHtmlCode(object obj)
    {
        string[] paramArr = obj.ToString().Split('|');
        string htmlCode = CollectionBll.GetHtmlCode(paramArr[2], paramArr[0]);
        string regexStr = CollectionBll.TransferStr(paramArr[1]);
        string returnStr = string.Empty;
        MatchCollection match = Regex.Matches(htmlCode, regexStr, RegexOptions.IgnoreCase);
        if (match.Count > 1)
            returnStr = "此代码在源文件中不唯一";
        else if (match.Count == 1)
            returnStr = "此代码在源文件中唯一";
        else
            returnStr = "此代码在源文件中不存在";
        return returnStr;
    }
    #endregion

    #region 检测内容代码是否唯一
    [AjaxPro.AjaxMethod]
    public string CheckContentCode(object obj)
    {
        //列表页
        string returnStr = string.Empty;
        string[] listArr = obj.ToString().Split('|');
        string htmlCode = CollectionBll.GetHtmlCode(listArr[0], listArr[5]);
        string listRegexStr = CollectionBll.TransferStr(listArr[1]) + "((?:.|\n)*?)" + CollectionBll.TransferStr(listArr[2]);
        string listHtmlCode = CollectionBll.GetRegValue(listRegexStr, htmlCode);
        string linkRegexStr = CollectionBll.TransferStr(listArr[3]) + "((?:.|\n)*?)" + CollectionBll.TransferStr(listArr[4]);
        string linkStr = CollectionBll.LinkStr(listHtmlCode,listArr[0], linkRegexStr, listArr[6]);
        string[] linkArr = linkStr.Split(',');
        Random random = new Random();
        string linkRandomStr = linkArr[random.Next(linkArr.Length - 1)].ToString();
        string HtmlContentCode = CollectionBll.GetHtmlCode(linkRandomStr, listArr[5]);
        string conPageRegexStr = CollectionBll.TransferStr(listArr[7]);

        MatchCollection match = Regex.Matches(HtmlContentCode, conPageRegexStr, RegexOptions.IgnoreCase);
        if (match.Count > 1)
            returnStr = "此代码在源文件中不唯一";
        else if (match.Count == 1)
            returnStr = "此代码在源文件中唯一";
        else
            returnStr = "此代码在源文件中不存在";
        return returnStr;
    }
    #endregion
}
