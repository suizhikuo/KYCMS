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
using Ky.Model;
using Ky.BLL.CommonModel;
using Ky.Common;
using System.Text.RegularExpressions;

public partial class system_label_AnomalyContent : System.Web.UI.Page
{
    B_PowerGroup AdminGroupBll = new B_PowerGroup();

    B_Anomaly AnomalyBll = new B_Anomaly();
    B_Channel ChannelBll = new B_Channel();
    B_Create CreateBll = new B_Create();
    B_InfoModel InfoModelBll = new B_InfoModel();


    M_Channel ChannelM = new M_Channel();
    M_InfoModel InfoModelM = new M_InfoModel();
    public static int Chid = 1;
    protected static string SkipPageUrl = string.Empty;


    #region 页面加载事件
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(10);
        AjaxPro.Utility.RegisterTypeForAjax(typeof(system_label_AnomalyContent));
        if(!IsPostBack)
        {
            SkipPageUrl = Request.ServerVariables["HTTP_REFERER"].ToString();

            ChannelBind();
            RepChannelBind(Chid);
            if (Request.QueryString["labelCategoryId"] != null)
            {
                btnSave.Text = "修改标签";
                btnReset.Visible = false;
                M_LabelContent model = new M_LabelContent();
                B_LabelContent bll = new B_LabelContent();
                model = bll.GetLabelContentId(int.Parse(Request.QueryString["labelCategoryId"]));
                txtName.Text = model.Name.Replace("{Ky_", "").Replace("}", "");
                txtContent.Value = model.AnomalyStyle;
            }
        }
    }
    #endregion

    #region 绑定所有符合条件的频道
    private void ChannelBind()
    {
        ddlCh.DataSource = ChannelBll.GetList(false);
        ddlCh.DataTextField = "ChName";
        ddlCh.DataValueField = "ChId";
        ddlCh.DataBind();
    }
    #endregion

    #region 不规则分页事件
    protected void pageAnomaly_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        pageAnomaly.CurrentPageIndex = e.NewPageIndex;
        RepChannelBind(Chid);
    }
    #endregion


    #region 选择频道下接列表框事件
    protected void ddlCh_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCh.SelectedValue != null && ddlCh.SelectedValue.Length != 0)
        {
            Chid = int.Parse(ddlCh.SelectedValue);
            RepChannelBind(Chid);
        }
    }
    #endregion


    #region 提取不规则数据
    private void RepChannelBind(int chid)
    {
        int recrodCount = 0;
        ChannelM = ChannelBll.GetChannel(chid);
        if (ChannelM != null)
        {
            repAnomaly.DataSource = AnomalyBll.GetList(chid,pageAnomaly.CurrentPageIndex,pageAnomaly.PageSize,ref recrodCount);
            repAnomaly.DataBind();
            pageAnomaly.RecordCount = recrodCount;
            pageAnomaly.CustomInfoHTML = string.Format("共{0}条记录 每页{1}条", pageAnomaly.RecordCount, pageAnomaly.PageSize);
        }
    }
    #endregion


    #region 处理内容对应地址
    public string GetAStr(object objInfoId)
    {
        int infoId = int.Parse(objInfoId.ToString());
        ChannelM = ChannelBll.GetChannel(Chid);
        int modelId = ChannelM.ModelType;
        InfoModelM = InfoModelBll.GetModel(modelId);                                                                                    //取得对应Id的模板信息
        string tableName = InfoModelM.TableName;                                                                                        //取得模型的表名
        DataRow dr = CreateBll.GetInfoById(tableName, infoId);
        string getUrl = CreateBll.GetInfoUrl(dr, 1);
        return getUrl;
    }
    #endregion


    #region 删除不规则标签
    protected void repAnomaly_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        HiddenField hidden = (HiddenField)e.Item.FindControl("hidAnomalyId");
        AnomalyBll.Delete(int.Parse(hidden.Value));
        RepChannelBind(Chid);
    }
    #endregion


    protected void btnSave_Click(object sender, EventArgs e)
    {
        M_LabelContent model = new M_LabelContent();
        B_LabelContent bll = new B_LabelContent();
        B_KyCommon bllCom = new B_KyCommon();
        bool flag = false;
        if (!(txtName.Text.ToString().Substring(0, 2).ToLower() == "s_"))
        {
            model.Name = lblPrefix.Text.ToString() + txtName.Text.Trim() + lblPostfix.Text.ToString();
            model.LbCategoryId = 1;
            model.Content = GetContent(txtContent.Value);
            model.AnomalyStyle = txtContent.Value;
            ChannelM = ChannelBll.GetChannel(Chid);
            int modelId = ChannelM.ModelType;
            model.ModeType = modelId;
            flag = bllCom.CheckHas(model.Name, "Name", "KyLabelContent");
            if (btnSave.Text == "修改标签")
            {
                model.LabelCategoryID = int.Parse(Request.QueryString["labelCategoryId"]);
                bll.Update(model);
                Response.Redirect(SkipPageUrl);
            }
            else
            {
                if (!flag)
                {
                    bll.Add(model);
                    Response.Redirect(SkipPageUrl);
                }
                else
                    Response.Write("<script>alert('此标签己存在');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('此标签与超级标签冲突');</script>");
        }        
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.location.href='AnomalyContent.aspx'</script>");
    }

    //不规则标签处理
    [AjaxPro.AjaxMethod]
    public string AnomalyContent(object obj)
    {
        #region modify
        //int recrodCount = 0;
        //string styleContent = string.Empty;
        //string returnValue = obj.ToString();
        //string[] styleArr = null;
        //ChannelM = ChannelBll.GetChannel(Chid);
        //if (ChannelM != null)
        //{
        //    //标签设置的参数
        //    string row = string.Empty;
        //    string length = string.Empty;
        //    string style = string.Empty;
        //    string target = string.Empty;

        //    //标签参数值
        //    int rowValue = 0;
        //    int lengthValue = 0;

        //    //参数标识
        //    bool paramFlag = true;
        //    string errorInfo = string.Empty;

        //    string getValue = string.Empty;
        //    int modelId = ChannelM.ModelType;
        //    InfoModelM = InfoModelBll.GetModel(modelId);                                                                                    //取得对应Id的模板信息
        //    string tableName = InfoModelM.TableName;                                                                                        //取得模型的表名
        //    DataTable dt = AnomalyBll.GetList(Chid, 1, 20, ref recrodCount);
        //    styleContent = GetLabel(obj.ToString());
        //    styleArr = styleContent.Split('|');
        //    for (int i = 0; i < styleArr.Length; i++)
        //    {
        //        GetParamValue(styleArr[i], "row", ref row);
        //        GetParamValue(styleArr[i], "length", ref length);
        //        GetParamValue(styleArr[i], "style", ref style);
        //        GetParamValue(styleArr[i], "target", ref target);

        //        if (Function.CheckNumber(row) && int.Parse(row) >= 1)
        //            rowValue = int.Parse(row) - 1;
        //        else
        //        {
        //            paramFlag = false;
        //            errorInfo = "row的参数值不是数字并且数字是大于等于一";
        //        }

        //        if (Function.CheckNumber(length) && int.Parse(length) >= 0)
        //            lengthValue = int.Parse(length);
        //        else
        //        {
        //            paramFlag = false;
        //            errorInfo = "length的参数值不是数字并且数字是大于零";
        //        }

        //        if (paramFlag)
        //        {
        //            if (int.Parse(row) <= dt.Rows.Count)
        //            {
        //                if (style != string.Empty && target != string.Empty)
        //                    getValue = "<a href=\"" + GetAStr(dt.Rows[rowValue]["InfoId"]) + "\" style=\"" + style + "\" target=\"" + target + "\" >" + Function.SubStr(dt.Rows[rowValue]["Title"].ToString(), lengthValue) + "</a>";
        //                else if (style != string.Empty)
        //                    getValue = "<a href=\"" + GetAStr(dt.Rows[rowValue]["InfoId"]) + "\" style=\"" + style + "\">" + Function.SubStr(dt.Rows[rowValue]["Title"].ToString(), lengthValue) + "</a>";
        //                else if (target != string.Empty)
        //                    getValue = "<a href=\"" + GetAStr(dt.Rows[rowValue]["InfoId"]) + "\" target=\"" + target + "\" >" + Function.SubStr(dt.Rows[rowValue]["Title"].ToString(), lengthValue) + "</a>";
        //                else
        //                    getValue = "<a href=\"" + GetAStr(dt.Rows[rowValue]["InfoId"]) + " >" + Function.SubStr(dt.Rows[rowValue]["Title"].ToString(), lengthValue) + "</a>";
        //                returnValue = returnValue.Replace(styleArr[i].ToString(), getValue);
        //            }
        //            else
        //            {
        //                returnValue = returnValue.Replace(styleArr[i].ToString(), "&nbsp;");
        //            }
        //        }
        //        else
        //        {
        //            return errorInfo;
        //        }
        //    }

        //}
        //return returnValue;
        #endregion
        if (obj.ToString().Trim().Length != 0)
            return GetContent(obj.ToString());
        else
            return "你没有设置样式";
    }

    #region 处理处理样式
    private string GetContent(string obj)
    {
        int recrodCount = 0;
        string styleContent = string.Empty;
        string returnValue = obj;
        string[] styleArr = null;
        ChannelM = ChannelBll.GetChannel(Chid);
        if (ChannelM != null)
        {
            //标签设置的参数
            string row = string.Empty;
            string length = string.Empty;
            string style = string.Empty;
            string target = string.Empty;

            //标签参数值
            int rowValue = 0;
            int lengthValue = 0;

            //参数标识
            bool paramFlag = true;
            string errorInfo = string.Empty;

            string getValue = string.Empty;
            int modelId = ChannelM.ModelType;
            InfoModelM = InfoModelBll.GetModel(modelId);                                                                                    //取得对应Id的模板信息
            string tableName = InfoModelM.TableName;                                                                                        //取得模型的表名
            DataTable dt = AnomalyBll.GetList(Chid, 1, 20, ref recrodCount);
            styleContent = GetLabel(obj.ToString());
            styleArr = styleContent.Split('|');
            for (int i = 0; i < styleArr.Length; i++)
            {
                GetParamValue(styleArr[i], "row", ref row);
                GetParamValue(styleArr[i], "length", ref length);
                GetParamValue(styleArr[i], "style", ref style);
                GetParamValue(styleArr[i], "target", ref target);

                if (Function.CheckNumber(row) && int.Parse(row) >= 1)
                    rowValue = int.Parse(row) - 1;
                else
                {
                    paramFlag = false;
                    errorInfo = "row的参数值不是数字并且数字是大于等于一";
                }

                if (Function.CheckNumber(length) && int.Parse(length) >= 0)
                    lengthValue = int.Parse(length);
                else
                {
                    paramFlag = false;
                    errorInfo = "length的参数值不是数字并且数字是大于零";
                }

                if (paramFlag)
                {
                    if (int.Parse(row) <= dt.Rows.Count)
                    {
                        if (style != string.Empty && target != string.Empty)
                            getValue = "<a href=\"" + GetAStr(dt.Rows[rowValue]["InfoId"]) + "\" style=\"" + style + "\" target=\"" + target + "\" >" + Function.SubStr(dt.Rows[rowValue]["Title"].ToString(), lengthValue) + "</a>";
                        else if (style != string.Empty)
                            getValue = "<a href=\"" + GetAStr(dt.Rows[rowValue]["InfoId"]) + "\" style=\"" + style + "\">" + Function.SubStr(dt.Rows[rowValue]["Title"].ToString(), lengthValue) + "</a>";
                        else if (target != string.Empty)
                            getValue = "<a href=\"" + GetAStr(dt.Rows[rowValue]["InfoId"]) + "\" target=\"" + target + "\" >" + Function.SubStr(dt.Rows[rowValue]["Title"].ToString(), lengthValue) + "</a>";
                        else
                            getValue = "<a href=\"" + GetAStr(dt.Rows[rowValue]["InfoId"]) + " >" + Function.SubStr(dt.Rows[rowValue]["Title"].ToString(), lengthValue) + "</a>";
                        returnValue = returnValue.Replace(styleArr[i].ToString(), getValue);
                    }
                    else
                    {
                        returnValue = returnValue.Replace(styleArr[i].ToString(), "&nbsp;");
                    }
                }
                else
                {
                    return errorInfo;
                }
            }

        }
        return returnValue;
    }
    #endregion

    #region 将标签名称替换为标签内容
    private string GetLabel(string styleContent)
    {
        string returnValue = string.Empty;
        MatchCollection matches = Regex.Matches(styleContent, @"{\$ky.*?/}", RegexOptions.IgnoreCase);
        int i = 0;
        foreach (Match m in matches)
        {
            i++;
            if (matches.Count != i)
                returnValue = returnValue + m.Value + "|";
            else
                returnValue = returnValue + m.Value;
        }
        return returnValue;
    }
    #endregion

    #region 取得对应函数所需参数的值
    private void GetParamValue(string paramStr, string paramName, ref string paramValue)
    {
        MatchCollection mc = Regex.Matches(paramStr, @"{\$Ky.*?\b" + paramName + @"=""(.*?)"".*?/}", RegexOptions.IgnoreCase);
        if (mc.Count > 0 && mc[0].Groups.Count > 1 && mc[0].Groups[1].Value != "")
        {
            paramValue = mc[0].Groups[1].Value.ToLower();
        }
    }
    #endregion

}
