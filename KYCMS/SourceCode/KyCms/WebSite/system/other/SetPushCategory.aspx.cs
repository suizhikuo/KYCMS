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
using System.IO;
using Ky.BLL;
using Ky.Model;
using Ky.Common;

public partial class system_other_PushCategory : System.Web.UI.Page
{
    bool IsAdd = true;
    int CategoryId = 0;
    M_AdCategory Model = new M_AdCategory();
    B_AdCategory Bll = new B_AdCategory();
    B_PowerGroup AdminGroupBll = new B_PowerGroup();
    B_Ad AdBll = new B_Ad();
    /// <summary>
    /// 页面加载
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(30);
        if (Request.QueryString["categoryId"] != null)
        {
            CategoryId = Function.CheckNumber(Request.QueryString["categoryId"]) ? int.Parse(Request.QueryString["categoryId"]) : 0;            
            if (!IsPostBack)
            {
                BindOnUpdate();
            }
            IsAdd = false;
            btnSet.Text = "修改";
        }        

    }

    /// <summary>
    /// 添加/修改
    /// </summary>
    protected void btnSet_Click(object sender, EventArgs e)
    {
        CheckInput();
        Model.CategoryName = txtCategoryName.Text;
        Model.Description = txtDescription.Text.Length > 50 ? txtDescription.Text.Substring(0, 46) + "..." : txtDescription.Text;
        Model.DisplayType = int.Parse(rblDisplayType.SelectedValue);
        Model.IsDisabled = int.Parse(rblIsDisable.SelectedValue);
        string width = Function.CheckNumber(txtWidth.Text) ? txtWidth.Text : "0";
        string height = Function.CheckNumber(txtHeigth.Text)? txtHeigth.Text : "0";
        string per = Function.CheckNumber(txtPer.Text) ? txtPer.Text : "1";
        //注意，我把版位广告的一行显示的列数保存到了广告位的宽高参数后面
        Model.WidthHeigth = width + "|" + height + "|" + txtPer.Text;
        if (IsAdd)
        {
            Bll.Add(Model);
            try
            {
                AdBll.RefreshAd(CategoryId.ToString());
            }
            catch (Exception)
            { Function.ShowSysMsg(1, "<li>数据已更新.但在刷新广告JS时I/O异常.请确保 Push 文件夹有写权限,然后手动刷新该广告位JS.</li><li><a href='other/PushCategoryList.aspx'>返回广告位列表</a></li><li><a href='javascript:window.history.back()'>返回上一步</a></li>"); }
        }
        else
        {
            Model.AdCategoryId = CategoryId;
            Bll.Update(Model);
            string jsPath = Param.SiteRootPath + "\\Push\\" + CategoryId + ".js";
            if (Model.IsDisabled==2)//如果是禁用，则删除JS文件
            {
                if (File.Exists(jsPath))
                {
                    try
                    { File.Delete(jsPath); }
                    catch (Exception)
                    { Function.ShowSysMsg(1, "<li>数据已更新。但在删除广告JS文件时I/O异常。您需要手动删除此文件</li><li><a href='other/PushCategoryList.aspx'>返回广告位列表</a></li><li><a href='other/PushCategoryList.aspx'>返回广告位列表</a></li>"); }
                }
            }
            else
            {
                try
                {
                    AdBll.RefreshAd(CategoryId.ToString());
                }
                catch (Exception)
                { Function.ShowSysMsg(1, "<li>数据已更新.但在刷新广告JS时I/O异常.请确保 Push 文件夹有写权限,然后手动刷新该广告位JS.</li><li><a href='other/PushCategoryList.aspx'>返回广告位列表</a></li><li><a href='javascript:window.history.back()'>返回上一步</a></li>"); }
            }
        }
        Function.ShowSysMsg(1,"<li>修改成功</li><li><a href='other/PushCategoryList.aspx'>返回广告位列表</a></li>");
    }

    /// <summary>
    /// 在修改时绑定数据
    /// </summary>
    void BindOnUpdate()
    {
        Model = Bll.GetModel(CategoryId);
        if (Model != null)
        {
            txtCategoryName.Text = Model.CategoryName;
            txtDescription.Text = Model.Description;
            string[] param = Model.WidthHeigth.Split('|');
            if (param.Length == 3)
            {
                txtHeigth.Text = param[1];
                txtWidth.Text = param[0];
                txtPer.Text = param[2];
            }
            rblDisplayType.SelectedIndex = Model.DisplayType - 1;
            rblIsDisable.SelectedIndex = Model.IsDisabled - 1;
            if (Model.DisplayType == 5)
            { TrMatrix.Attributes.Add("style","display:''"); }
        }
        else
        {
            Function.ShowSysMsg(0, "<li>没有获取到数据</li><li><a href='other/PushCategoryList.aspx'>返回广告位列表</a></li>");
        }
    }

    /// <summary>
    /// 检查用户输入
    /// </summary>
    void CheckInput()
    {
        if (txtCategoryName.Text.Trim() == "")
        {
            Function.ShowSysMsg(0,"<li>请输入广告位名称</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
        }
    }
}
