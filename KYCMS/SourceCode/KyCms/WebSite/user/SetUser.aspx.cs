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
using Ky.Common;
using Ky.Model;
using System.IO;
using System.Text.RegularExpressions;
using Ky.BLL.CommonModel;

public partial class user_SetUser : System.Web.UI.Page
{
    protected M_User model = null;
    B_User bll = new B_User();
    private M_UserGroupModel MUserGroupModel = new M_UserGroupModel();
    private B_UserGroupModel BUserGroupModel = new B_UserGroupModel();

    private M_UserGroupModelField MUserGroupModelField = new M_UserGroupModelField();
    private B_UserGroupModelField BUserGroupModelField = new B_UserGroupModelField();
    protected B_InfoModel BInfoModel = new B_InfoModel();
    protected B_InfoOper BInfoOper = new B_InfoOper();
    private DataTable dtIsUser;
    protected B_ModelField BModelField = new B_ModelField();

    protected void Page_Load(object sender, EventArgs e)
    {
        model = bll.GetUser(bll.GetCookie().LogName);
        MUserGroupModel = BUserGroupModel.GetModel(model.TypeId);
        dtIsUser = BUserGroupModelField.GetIsUserList(model.TypeId);

        AjaxPro.Utility.RegisterTypeForAjax(typeof(user_SetUser));

        if (model != null)
        {
            if (!IsPostBack)
            {
                ModelHtml.Text = MUserGroupModel.ModelHtml;
                if (MUserGroupModel.IsValidate)
                {
                    Code.Visible = true;
                }
                else
                {
                    Code.Visible = false;
                }
                txtSecret.SelectedValue = model.Secret.ToString();
                ModelJs.Text = "<script>GetModelHtmlUser_User_1('"+model.TypeId+"','" + model.UserID + "')</script>";
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    [AjaxPro.AjaxMethod]
    public DataSet GetModelHtmlValue(string TypeId,string UserId)
    {
        MUserGroupModel = BUserGroupModel.GetModel(int.Parse(TypeId));
        DataTable dt = new DataTable();
        DataRow dr = BInfoOper.GetUserInfo(MUserGroupModel.TableName, int.Parse(UserId));
        dt = dr.Table.Copy();
        dt.Clear();
        dt.ImportRow(dr);
        dt.TableName = "DrInfo";

        DataSet ds = new DataSet();
        try
        {
            ds.Tables.Add(BUserGroupModelField.GetList(int.Parse(TypeId)).Copy());
            ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }

        return ds;
    }

    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        CheckInput();

        bll.ModifyOtherBasicInfo(model.UserID, model.Email, model.GroupID, int.Parse(txtSecret.SelectedValue));

        //自定义字段
        //定义DataTable
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("FieldName", typeof(string)));
        dt.Columns.Add(new DataColumn("FieldValue", typeof(string)));

        #region 系统默认字段
        DataRow dr0 = dt.NewRow();
        dr0[0] = "Id";
        dr0[1] = BInfoOper.GetUserInfo(MUserGroupModel.TableName, model.UserID)["Id"];
        dt.Rows.Add(dr0);

        DataRow dr1 = dt.NewRow();
        dr1[0] = "UId";
        dr1[1] = model.UserID;
        dt.Rows.Add(dr1);

        DataRow dr2 = dt.NewRow();
        dr2[0] = "AddTime";
        dr2[1] = DateTime.Now.ToString();
        dt.Rows.Add(dr2);

        DataRow dr3 = dt.NewRow();
        dr3[0] = "UpdateTime";
        dr3[1] = DateTime.Now.ToString();
        dt.Rows.Add(dr3);
        #endregion

        //以下是自动添加字段获得值
        for (int i = 0; i < dtIsUser.Rows.Count; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = dtIsUser.Rows[i]["Name"].ToString();

            //联动获取数据开始
            //二级联动
            if (dtIsUser.Rows[i]["Type"].ToString() == "ErLinkageType")
            {
                dr[1] = Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString()];
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr[0] = dtIsUser.Rows[i]["Name"].ToString() + "_Id";
                dr[1] = Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString() + "_Id"];
                dt.Rows.Add(dr);

                string SmallName = BModelField.GetFieldContent(dtIsUser.Rows[i]["Content"].ToString(), 2, 1);
                dr = dt.NewRow();
                dr[0] = SmallName;
                dr[1] = Request.Form["txt_" + SmallName];
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr[0] = SmallName + "_Id";
                dr[1] = Request.Form["txt_" + SmallName + "_Id"];
                dt.Rows.Add(dr);
            }
            else
            {
                switch (dtIsUser.Rows[i]["Type"].ToString())
                {
                    case "ListBoxType":
                        if (Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString() + ""] == "" || Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString() + ""] == null)
                        {
                            dr[1] = Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString() + ""];
                        }
                        else
                        {
                            dr[1] = Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString() + ""].Replace(" ", "").ToString();
                        }
                        break;
                    case "MultipleTextType":
                        dr[1] = Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString() + ""];
                        break;
                    default:
                        dr[1] = Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString() + ""];
                        break;
                }
                dt.Rows.Add(dr);
            }
        }
        BInfoModel.UpdateInfoModel(dt, MUserGroupModel.TableName);

        Function.ShowMsg(1, "<li>修改成功</li><li><a href='welcome.aspx'>返回站点首页</a></li>");
    }

    /// <summary>
    /// 检查用户输入
    /// </summary>
    public void CheckInput()
    {
        //验证自定义字段
        if (dtIsUser.Rows.Count > 0)
        {
            for (int i = 0; i < dtIsUser.Rows.Count; i++)
            {
                if (dtIsUser.Rows[i]["IsNotNull"].ToString() == "True")
                {
                    if (Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString()] == "" || Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString()] == null)
                    {
                        Function.ShowSysMsg(0, "<li>" + dtIsUser.Rows[i]["Alias"].ToString() + "不能够为空</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                    }
                }

                if (dtIsUser.Rows[i]["Type"].ToString() == "NumberType")
                {
                    if (Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString()] != "")
                    {
                        if (!Function.CheckNumber(Request.Form["txt_" + dtIsUser.Rows[i]["Name"].ToString()]))
                        {
                            Function.ShowSysMsg(0, "<li>" + dtIsUser.Rows[i]["Alias"].ToString() + "只能够是数字</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a></li>");
                        }
                    }
                }
            }
        }
    }
}
