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
using Ky.Common;
using System.Data.SqlClient;

public partial class system_label_SuperLabel : System.Web.UI.Page
{
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    private B_InfoModel InfoModelBll = new B_InfoModel();
    private M_LabelContent model = new M_LabelContent();
    private B_LabelContent bll = new B_LabelContent();
    private B_ModelField BModelField = new B_ModelField();
    private B_SuperLabel BSuperLabel = new B_SuperLabel();
    private M_SuperLabel MSuperLabel = new M_SuperLabel();
    protected string strConnection;
    protected int SuperId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(9);
        AjaxPro.Utility.RegisterTypeForAjax(typeof(system_label_SuperLabel));

        if (!string.IsNullOrEmpty(Request.QueryString["SuperId"]))
        {
            try
            {
                SuperId = int.Parse(Request.QueryString["SuperId"]);
            }
            catch { }
        }

        if (!Page.IsPostBack)
        {
            //BindStyleCategory();
            Table1.Visible = true;
            Table2.Visible = false;
            Table3.Visible = false;

            if (SuperId != 0)
            {
                txtName.Attributes.Add("readonly", "");
                GetShow();
            }
        }
    }

    #region 绑定标签类别
    private void BindStyleCategory()
    {
        dllLbCategory.Items.Clear();
        dllLbCategory.Items.Add(new ListItem("请选择类别", "0"));
        B_LbCategory bll = new B_LbCategory();
        DataTable dt = bll.GetListItemByLabelId();
        foreach (DataRow dr in dt.Rows)
        {
            string colname = dr["Name"].ToString();
            int colid = Convert.ToInt32(dr["LbCategoryID"].ToString());
            int depth = int.Parse(dr["Depth"].ToString());
            for (int i = 0; i < depth; i++)
            {
                colname = "├┄" + colname;
            }
            dllLbCategory.Items.Add(new ListItem(colname, colid.ToString()));
        }
        dt.Clear();
        dt.Dispose();
    }
    #endregion

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (SuperId == 0)
        {
            if (txtName.Text.Trim().Length == 0)
            {
                Function.ShowSysMsg(0, "<li>请输入超级标签名称</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='label/SuperLabelList.aspx'>返回超级标签管理</a></li>");
            }

            if (BSuperLabel.CheckName("{Ky_S_" + txtName.Text + "}") == 1)
            {
                Function.ShowSysMsg(0, "<li>该超级标签名称已经存在</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='label/SuperLabelList.aspx'>返回超级标签管理</a></li>");
            }
        }

        string sName = txtName.Text.Replace("|", "");
        //string sLbCategoryName = txtLbCategoryName.Text.Replace("|", "");
        //string sLbCategoryId = txtLbCategoryId.Text;

        string sLbCategoryName = "";
        string sLbCategoryId = "0";
        string sDataBaseType = DataBaseType.SelectedValue;
        string sSuperDes = txtSuperDes.Text.Replace("|", "");

        #region 外部数据库
        if (sDataBaseType == "3")
        {
            string sSqlIp = SqlIp.Text;
            string sSqlName = SqlName.Text;
            string sSqlUserName = SqlUserName.Text;
            string sSqlPassWord = SqlPassWord.Text;

            try
            {
                strConnection = "user id=" + sSqlUserName + ";password=" + sSqlPassWord + ";";
                strConnection += "initial catalog=" + sSqlName + ";Server=" + sSqlIp + ";";
                strConnection += "Connect Timeout=60";

                SqlConnection objConnection = new SqlConnection(strConnection);
                objConnection.Open();
                objConnection.Close();
            }
            catch
            {
                Function.ShowSysMsg(0, "<li>数据库连接失败</li><li><a href='javascript:window.history.back()'>返回上一步</a></li>");
            }
        }
        #endregion

        Table1.Visible = false;
        Table2.Visible = true;
        Table3.Visible = false;

        DataTable dt = new DataTable();

        if (sDataBaseType == "1")
        {
            dt = BModelField.GetAllTable();


        }
        else
        {
            if (sDataBaseType == "3")
            {
                dt = BSuperLabel.DataBaseTypeSql(strConnection, sDataBaseType, "select name from [sysobjects] where xtype='U' order by name");
            }
        }

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataTable1.Items.Add(new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["name"].ToString()));
            DataTable2.Items.Add(new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["name"].ToString()));
        }

        TableValue.Text = sName + "|" + sLbCategoryName + "|" + sLbCategoryId + "|" + sDataBaseType + "|" + sSuperDes;
        TxtDataBaseConn.Text = strConnection;
    }

    [AjaxPro.AjaxMethod]
    public DataTable GetOption(string str, string DataBaseType, string DataBaseConn)
    {
        DataTable dt = new DataTable();
        if (DataBaseType == "1")
        {
            dt = BModelField.GetTableAllField(str);
        }
        else
        {
            if (DataBaseType == "3")
            {
                dt = BSuperLabel.DataBaseTypeSql(DataBaseConn, DataBaseType, "select a.name from syscolumns a,sysobjects b where a.id=b.id and b.name='" + str + "' order by a.colid");
            }
        }

        return dt;
    }

    [AjaxPro.AjaxMethod]
    public string CheckSql(string sql, string DataBaseType, string DataBaseConn)
    {
        DataTable dt = new DataTable();

        if (DataBaseType == "3")
        {
            dt = BSuperLabel.DataBaseTypeSql(DataBaseConn, "3", BSuperLabel.FiltrateWhereSql(sql));
        }
        else
        {
            dt = BSuperLabel.CheckSql(BSuperLabel.FiltrateWhereSql(sql));
        }

        if (dt == null)
        {
            return "该Sql语句存在错误，请检测后再执行！";
        }
        else
        {
            return "该Sql语句正常！";
        }
    }

    [AjaxPro.AjaxMethod]
    public string CheckSqlConn(string SqlIp, string SqlName, string SqlUserName, string SqlPassWord)
    {
        string CheckSqlConn = "很抱歉,数据库连接失败";

        try
        {
            string strConnection = "user id=" + SqlUserName + ";password=" + SqlPassWord + ";";
            strConnection += "initial catalog=" + SqlName + ";Server=" + SqlIp + ";";
            strConnection += "Connect Timeout=60";

            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();


            if (objConnection.State == ConnectionState.Open)
            {
                CheckSqlConn = "恭喜您,数据库连接成功";
            }
        }
        catch
        {
            CheckSqlConn = "很抱歉,数据库连接失败";
        }

        return CheckSqlConn;
    }

    //最后一步
    protected void Button3_Click(object sender, EventArgs e)
    {
        Table1.Visible = false;
        Table2.Visible = false;
        Table3.Visible = true;

        TxtSqlStr.Text = SuperLabelSqlText.Text;
        TxtIsUnlockPage.Text = IsUnlockPage.SelectedValue;
        //TxtHostTable.Text = DataTable1.SelectedValue;
        //TxtGuestTable.Text = DataTable2.SelectedValue;
        TxtNumColumns.Text = NumColumns.SelectedValue;
        TxtPageSize.Text = PageSize.Text;
        TxtIsHtml.Text = IsHtml.SelectedValue;

        if (DataTable1.SelectedValue != "0")
        {
            TxtHostTable.Text = DataTable1.SelectedValue;
            TxtGuestTable.Text = DataTable2.SelectedValue;
        }

        if (!Function.CheckNumberNotZero(PageSize.Text))
        {
            Function.ShowSysMsg(0, "<li>每页显示条数只能够是数字</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='label/SuperLabelList.aspx'>返回超级标签列表</a>");
        }

        DataTable dt = new DataTable();

        if (TableValue.Text.Trim().Split('|')[3] == "3")
        {
            dt = BSuperLabel.DataBaseTypeSql(TxtDataBaseConn.Text, "3", BSuperLabel.FiltrateWhereSql(SuperLabelSqlText.Text.Trim()));
        }
        else
        {
            dt = BSuperLabel.CheckSql(BSuperLabel.FiltrateWhereSql(SuperLabelSqlText.Text.Trim()));
        }

        if (dt == null)
        {
            Function.ShowSysMsg(0, "<li>该Sql语句存在错误，不能够编辑样式内容</li><li><a href='javascript:window.history.back()'>返回上一步</a> <a href='label/SuperLabelList.aspx'>返回超级标签列表</a>");
        }

        bool SqlId = false;
        DataTable dt1 = new DataTable();
        dt1.Columns.Add(new DataColumn("FieldName", typeof(string)));

        for (int i = 0; i < dt.Columns.Count; i++)
        {
            DataRow dr = dt1.NewRow();
            dr[0] = dt.Columns[i].ToString();

            if (dt.Columns[i].ToString() == "Id")
            {
                SqlId = true;
            }

            dt1.Rows.Add(dr);
        }

        //如果是模型表，就自动添加一个URL连接字段
        if (SqlId && BSuperLabel.IsModelTable(DataTable1.SelectedValue))
        {
            DataRow dr2 = dt1.NewRow();
            dr2[0] = "InfoUrl";

            dt1.Rows.Add(dr2);
        }
        DataList1.DataSource = dt1;
        DataList1.DataBind();

        if (SuperId == 0)
        {
            test.Text = "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\">\r\n<Ky_Loop>\r\n<tr>\r\n<Ky_Loop_Columns>\r\n<td>·//这里编写你需要显示的代码</td>\r\n</Ky_Loop_Columns>\r\n</tr>\r\n</Ky_Loop>\r\n</table>";
        }

        dt.Clear();
        dt.Dispose();
        dt1.Clear();
        dt1.Dispose();
    }

    //保存
    protected void Button11_Click(object sender, EventArgs e)
    {
        string txtTableValue = TableValue.Text;

        string[] MyTableValue = txtTableValue.Split(new Char[] { '|' });

        //int LbCategoryId = 0;

        //if (MyTableValue[2] == "0")
        //{
        //    if (MyTableValue[1].Length > 0)
        //    {
        //        B_LbCategory blbcate = new B_LbCategory();
        //        M_LbCategory mlbcate = new M_LbCategory();

        //        mlbcate.Name = MyTableValue[1];
        //        mlbcate.ParentID = 0;
        //        mlbcate.Desc = "";
        //        LbCategoryId = blbcate.Add(mlbcate);
        //    }
        //}
        //else
        //{
        //    LbCategoryId = int.Parse(MyTableValue[2]);
        //}

        if (SuperId == 0)
        {
            if (BSuperLabel.CheckName("{Ky_S_" + MyTableValue[0] + "}") == 1)
            {
                Function.ShowSysMsg(0, "<li>该超级标签名称已经存在</li><li><a href='javascript:window.history.back(-1)'>返回上一步</a> <a href='label/SuperLabelList.aspx'>返回超级标签列表</a>");
            }
        }
        MSuperLabel.Name = "{Ky_S_" + MyTableValue[0] + "}";

        //MSuperLabel.LbCategoryName=MyTableValue[1];
        //MSuperLabel.LbCategoryId = LbCategoryId;

        MSuperLabel.LbCategoryName = "";
        MSuperLabel.LbCategoryId = 0;

        MSuperLabel.DataBaseType = int.Parse(MyTableValue[3]);
        MSuperLabel.SuperDes = MyTableValue[4];
        MSuperLabel.IsUnlockPage = bool.Parse(TxtIsUnlockPage.Text);
        MSuperLabel.HostTable = TxtHostTable.Text;
        MSuperLabel.GuestTable = TxtGuestTable.Text;
        MSuperLabel.SqlStr = TxtSqlStr.Text;
        MSuperLabel.Content = test.Text;
        MSuperLabel.AddTime = DateTime.Now;
        MSuperLabel.PageSize = int.Parse(TxtPageSize.Text);
        MSuperLabel.NumColumns = int.Parse(TxtNumColumns.Text);
        MSuperLabel.IsHtml = bool.Parse(TxtIsHtml.Text);
        MSuperLabel.DataBaseConn = TxtDataBaseConn.Text.Trim();

        if (SuperId == 0)
        {
            BSuperLabel.Add(MSuperLabel);
            Function.ShowSysMsg(1, "<li>成功添加超级标签</li><li><a href='label/SuperLabel.aspx'>继续添加超级标签</a> <a href='label/SuperLabelList.aspx'>返回超级标签列表</a></li>");
        }
        else
        {
            MSuperLabel.SuperId = SuperId;
            BSuperLabel.Update(MSuperLabel);

            Function.ShowSysMsg(1, "<li>成功修改超级标签!</li><li><a href='label/SuperLabel.aspx?SuperId=" + SuperId + "'>重新修改超级标签</a> <a href='label/SuperLabel.aspx'>添加超级标签</a> <a href='label/SuperLabelList.aspx'>返回超级标签列表</a></li>");
        }
    }

    //显示值
    private void GetShow()
    {
        MSuperLabel = BSuperLabel.GetModel(SuperId);

        txtName.Text = MSuperLabel.Name.Replace("{Ky_S_", "").Replace("}", "");
        DataBaseType.SelectedValue = MSuperLabel.DataBaseType.ToString();
        txtSuperDes.Text = MSuperLabel.SuperDes;

        if (MSuperLabel.DataBaseType == 2)
        {
            IsHtml2.SelectedValue = MSuperLabel.IsHtml.ToString();
            TxtStrSql1.Text = MSuperLabel.SqlStr;
        }
        else
        {
            //txtLbCategoryName.Text = MSuperLabel.LbCategoryName;
            //txtLbCategoryId.Text = MSuperLabel.LbCategoryId.ToString();

            txtLbCategoryName.Text = "";
            txtLbCategoryId.Text = "0";

            TxtHostTable.Text = MSuperLabel.HostTable;
            TxtGuestTable.Text = MSuperLabel.GuestTable;
            TxtNumColumns.Text = MSuperLabel.NumColumns.ToString();
            SuperLabelSqlText.Text = MSuperLabel.SqlStr;
            IsUnlockPage.SelectedValue = MSuperLabel.IsUnlockPage.ToString();
            TxtPageSize.Text = MSuperLabel.PageSize.ToString();
            test.Text = MSuperLabel.Content;
            PageSize.Text = MSuperLabel.PageSize.ToString();
            NumColumns.SelectedValue = MSuperLabel.NumColumns.ToString();
            IsHtml.SelectedValue = MSuperLabel.IsHtml.ToString();
            TxtDataBaseConn.Text = MSuperLabel.DataBaseConn;

            if (MSuperLabel.DataBaseType == 3)
            {
                SqlIp.Text = MSuperLabel.DataBaseConn.Split(';')[3].Split('=')[1];
                SqlName.Text = MSuperLabel.DataBaseConn.Split(';')[2].Split('=')[1];
                SqlUserName.Text = MSuperLabel.DataBaseConn.Split(';')[0].Split('=')[1];
                SqlPassWord.Text = MSuperLabel.DataBaseConn.Split(';')[1].Split('=')[1];
            }
        }
    }

    //外部数据源保存
    protected void Button13_Click(object sender, EventArgs e)
    {
        MSuperLabel.LbCategoryName = "";
        MSuperLabel.LbCategoryId = 0;
        MSuperLabel.Name = "{Ky_S_" + txtName.Text + "}";
        MSuperLabel.DataBaseType = int.Parse(DataBaseType.SelectedValue);
        MSuperLabel.SuperDes = txtSuperDes.Text;
        MSuperLabel.IsUnlockPage = false;
        MSuperLabel.HostTable = "";
        MSuperLabel.GuestTable = "";
        MSuperLabel.SqlStr = TxtStrSql1.Text;
        MSuperLabel.Content = "";
        MSuperLabel.AddTime = DateTime.Now;
        MSuperLabel.PageSize = 0;
        MSuperLabel.NumColumns = 0;
        MSuperLabel.IsHtml = bool.Parse(IsHtml2.SelectedValue);

        if (SuperId == 0)
        {
            BSuperLabel.Add(MSuperLabel);
            Function.ShowSysMsg(1, "<li>成功添加超级标签</li><li><a href='label/SuperLabel.aspx'>继续添加超级标签</a> <a href='label/SuperLabelList.aspx'>返回超级标签列表</a></li>");
        }
        else
        {
            MSuperLabel.SuperId = SuperId;
            BSuperLabel.Update(MSuperLabel);

            Function.ShowSysMsg(1, "<li>成功修改超级标签!</li><li><a href='label/SuperLabel.aspx?SuperId=" + SuperId + "'>重新修改超级标签</a> <a href='label/SuperLabel.aspx'>添加超级标签</a> <a href='label/SuperLabelList.aspx'>返回超级标签列表</a></li>");
        }
    }
}
