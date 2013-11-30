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
using Ky.Common;
using System.Text.RegularExpressions;
using Ky.BLL;

public partial class system_infomodel_SetInfoModel : System.Web.UI.Page
{
    private B_InfoModel InfoModelBll = new B_InfoModel();
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();    
    protected int ModelId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(35);
        if (!string.IsNullOrEmpty(Request.QueryString["ModelId"]))
        {
            try
            {
                ModelId = int.Parse(Request.QueryString["ModelId"]);
            }
            catch { }
        }
        if (ModelId!=0)
        {
            Literal1.Text = "修改";
            M_InfoModel infoModel = InfoModelBll.GetModel(ModelId) ;
            if (infoModel == null)
            {
                Function.ShowSysMsg(0, "<li>模型不存在或已经被删除</li><li><a href='infomodel/ModelList.aspx'>返回模型管理列表</a></li>");
            }
            if (infoModel.IsSystem)
            {
                litU.Text = string.Empty;
            }
            if(!IsPostBack)
                GetInfo();
        }
      
    }
    private void GetInfo()
    {
        M_InfoModel infoModel = InfoModelBll.GetModel(ModelId);
        txtModelName.Text = infoModel.ModelName;
        txtModelDesc.Text = infoModel.ModelDesc;
        if (infoModel.TableName.ToLower().StartsWith("ky_u_"))
        {
            txtTableName.Text = infoModel.TableName.Substring(5, infoModel.TableName.Length - 5);
        }
        else
        {
            txtTableName.Text = infoModel.TableName;
        }
        txtTableName.Enabled = false;
        txtUploadPath.Text = infoModel.UploadPath;
        txtUploadSize.Text = infoModel.UploadSize.ToString();
        IsHtml.SelectedValue = infoModel.IsHtml.ToString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string modelName = txtModelName.Text.Trim();
        if(modelName==string.Empty)
        {
            Function.ShowSysMsg(0, "<li>模型名称必须填写</li><li><a href='javascript:history.back();'>返回上一页</a></li>");
        }
        string tableName = txtTableName.Text.Trim();
        if(tableName==string.Empty)
        {
            Function.ShowSysMsg(0, "<li>表名称必须填写</li><li><a href='javascript:history.back();'>返回上一页</a></li>");
        }
        string patt = "^[a-zA-Z0-9]+$";
        if(!Regex.IsMatch(tableName,patt,RegexOptions.IgnoreCase))
        {
            Function.ShowSysMsg(0, "<li>表名称必须由字母或数字组成</li><li><a href='javascript:history.back();'>返回上一页</a></li>");
        }
        string uploadPath = txtUploadPath.Text.Trim();
        if(uploadPath==string.Empty)
        {
             Function.ShowSysMsg(0, "<li>上传文件存放目录必须填写</li><li><a href='javascript:history.back();'>返回上一页</a></li>");
        }
        patt = "[a-zA-Z][a-zA-Z0-9]*$";
        if(!Regex.IsMatch(uploadPath,patt,RegexOptions.IgnoreCase)) 
        {
            Function.ShowSysMsg(0, "<li>存放目录必须以字母开头，由字母或数字组成</li><li><a href='javascript:history.back();'>返回上一页</a></li>");
        }
        string uploadSize = txtUploadSize.Text.Trim();
        if(!Function.CheckNumber(uploadSize))
        {
            Function.ShowSysMsg(0, "<li>允许上传的文件大小必须为0或正整数</li><li><a href='javascript:history.back();'>返回上一页</a></li>");
        }

        M_InfoModel infoModel = new M_InfoModel();
        infoModel.ModelId = ModelId;
        infoModel.ModelName = txtModelName.Text.Trim();
        infoModel.ModelDesc = txtModelDesc.Text.Trim();
        infoModel.TableName = litU.Text + txtTableName.Text.Trim();
        infoModel.UploadPath = txtUploadPath.Text.Trim();
        infoModel.UploadSize = int.Parse(txtUploadSize.Text.Trim());
        infoModel.ModelHtml = "";
        infoModel.IsHtml = bool.Parse(IsHtml.SelectedValue);
        if (infoModel.ModelId == 0)
        {
            bool isValidate = InfoModelBll.CheckTableValidate(infoModel.TableName);
            if (!isValidate)
            {
                Function.ShowSysMsg(0, "<li>所设置的表名已经存在</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
            }

            //isValidate = InfoModelBll.CheckUploadPathValidate(infoModel.UploadPath);
            //if (!isValidate)
            //{
            //    Function.ShowSysMsg(0, "<li>所设置文件存放目录已经存在</li><li><a href='javascript:history.back()'>返回上一页</a></li>");
            //}
            InfoModelBll.Add(infoModel);
        }
        else
        {
            InfoModelBll.Update(infoModel);
            B_Channel channelBll = new B_Channel();
            channelBll.ClearCache();
        }
        Function.ShowSysMsg(1, "<li>模型设置成功</li><li><a href='infomodel/ModelList.aspx'>返回模型管理列表</a></li>");
    }
}
