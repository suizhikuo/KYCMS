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

public partial class system_label_SuperLabelOrder : System.Web.UI.Page
{
    private B_PowerGroup AdminGroupBll = new B_PowerGroup();
    private B_InfoModel InfoModelBll = new B_InfoModel();
    private M_LabelContent model = new M_LabelContent();
    private B_LabelContent bll = new B_LabelContent();
    private B_ModelField BModelField = new B_ModelField();
    private B_SuperLabel BSuperLabel = new B_SuperLabel();
    protected string DataTable1 = "";
    protected string DataTable2 = "";
    protected string DataBaseType = "";
    protected string DataBaseConn = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        AdminGroupBll.Power_Judge(9);
        Response.Cache.SetNoStore();
        DataTable1 = Request.QueryString["DataTable1"];
        DataTable2 = Request.QueryString["DataTable2"];
        DataBaseType = Request.QueryString["DataBaseType"];
        DataBaseConn = Request.QueryString["DataBaseConn"];
        Literal1.Text = "";

        if (!Page.IsPostBack)
        {
            DataTable dt = new DataTable();

            if (DataBaseType == "3")
            {
                dt = BSuperLabel.DataBaseTypeSql(DataBaseConn, DataBaseType, "select COLUMN_NAME,DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + DataTable1 + "'");
            }
            else
            {
                dt = BModelField.GetTableAllFieldAndType(DataTable1);
            }

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DbFieldList1.Items.Add(new ListItem(dt.Rows[i]["column_name"].ToString(), dt.Rows[i]["column_name"].ToString() + "$" + dt.Rows[i]["data_type"].ToString()));
                }
            }

            dt.Clear();
            dt.Dispose();

            DataTable dt1 = new DataTable();
            if (DataBaseType == "3")
            {
                dt1 = BSuperLabel.DataBaseTypeSql(DataBaseConn, DataBaseType, "select COLUMN_NAME,DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + DataTable2 + "'");
            }
            else
            {
                dt1 = BModelField.GetTableAllFieldAndType(DataTable2);
            }

            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    DbFieldList2.Items.Add(new ListItem(dt1.Rows[i]["column_name"].ToString(), dt1.Rows[i]["column_name"].ToString() + "$" + dt1.Rows[i]["data_type"].ToString()));
                }
            }

            dt1.Clear();
            dt1.Dispose();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("FieldName", typeof(string)));
        dt.Columns.Add(new DataColumn("FieldType", typeof(string)));
        dt.Columns.Add(new DataColumn("OrderId", typeof(int)));
        dt.Columns.Add(new DataColumn("TermLink", typeof(string)));
        int p = 0;
        bool MyDbField = false;

        if (DbFieldList2.Items.Count > 0)
        {
            MyDbField = true;
        }

        if (DbFieldList1.Items.Count > 0)
        {
            for (int i = 0; i < DbFieldList1.Items.Count; i++)
            {
                if (DbFieldList1.Items[i].Selected)
                {
                    DataRow dr = dt.NewRow();
                    if (MyDbField)
                    {
                        dr[0] = DataTable1 + "." + DbFieldList1.Items[i].Text;
                    }
                    else
                    {
                        dr[0] = DbFieldList1.Items[i].Text;
                    }
                    dr[1] = DbFieldList1.Items[i].Value.Replace(DbFieldList1.Items[i].Text + "$", "");
                    dr[2] = p;
                    dr[3] = " ASC";
                    dt.Rows.Add(dr);
                    p++;
                }
            }
        }

        if (DbFieldList2.Items.Count > 0)
        {
            for (int i = 0; i < DbFieldList2.Items.Count; i++)
            {
                if (DbFieldList2.Items[i].Selected)
                {
                    DataRow dr2 = dt.NewRow();
                    dr2[0] = DataTable2 + "." + DbFieldList2.Items[i].Text;
                    dr2[1] = DbFieldList2.Items[i].Value.Replace(DbFieldList2.Items[i].Text + "$", "");
                    dr2[2] = p;
                    dr2[3] = " ASC";
                    dt.Rows.Add(dr2);
                    p++;
                }
            }
        }

        if (dt.Rows.Count == 0)
        {
            Literal1.Text = "<script language=javascript>alert('请选择查询条件字段')</script>";
            return;
        }

        dt.DefaultView.Sort = "OrderId";
        Repeater1.DataSource = dt;
        Repeater1.DataBind();

        dt.Clear();
        dt.Dispose();
    }

    protected void Repeater1_Move(object sender, RepeaterCommandEventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("FieldName", typeof(string)));
        dt.Columns.Add(new DataColumn("FieldType", typeof(string)));
        dt.Columns.Add(new DataColumn("OrderId", typeof(int)));
        dt.Columns.Add(new DataColumn("TermLink", typeof(string)));

        //上移
        if (e.CommandName == "MoveUp")
        {
            int OrderId = Convert.ToInt32(e.CommandArgument);

            if (OrderId != 0)
            {
                for (int i = 0; i < Repeater1.Items.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = ((Label)this.Repeater1.Items[i].FindControl("LabelFieldName")).Text;
                    dr[1] = ((Label)this.Repeater1.Items[i].FindControl("LabelFieldType")).Text;
                    if (int.Parse(((TextBox)this.Repeater1.Items[i].FindControl("OrderId")).Text) == OrderId)
                    {
                        dr[2] = int.Parse(((TextBox)this.Repeater1.Items[i].FindControl("OrderId")).Text) - 1;
                    }
                    else if (int.Parse(((TextBox)this.Repeater1.Items[i].FindControl("OrderId")).Text) + 1 == OrderId)
                    {
                        dr[2] = int.Parse(((TextBox)this.Repeater1.Items[i].FindControl("OrderId")).Text) + 1;
                    }
                    else
                    {
                        dr[2] = int.Parse(((TextBox)this.Repeater1.Items[i].FindControl("OrderId")).Text);
                    }
                    dr[3] = ((DropDownList)this.Repeater1.Items[i].FindControl("TermLink")).SelectedValue;
                    dt.Rows.Add(dr);
                }

                dt.DefaultView.Sort = "OrderId";
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        //下移
        if (e.CommandName == "MoveDown")
        {
            int OrderId = Convert.ToInt32(e.CommandArgument);

            if (OrderId != Repeater1.Items.Count - 1)
            {
                for (int i = 0; i < Repeater1.Items.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = ((Label)this.Repeater1.Items[i].FindControl("LabelFieldName")).Text;
                    dr[1] = ((Label)this.Repeater1.Items[i].FindControl("LabelFieldType")).Text;
                    if (int.Parse(((TextBox)this.Repeater1.Items[i].FindControl("OrderId")).Text) == OrderId)
                    {
                        dr[2] = int.Parse(((TextBox)this.Repeater1.Items[i].FindControl("OrderId")).Text) + 1;
                    }
                    else if (int.Parse(((TextBox)this.Repeater1.Items[i].FindControl("OrderId")).Text) - 1 == OrderId)
                    {
                        dr[2] = int.Parse(((TextBox)this.Repeater1.Items[i].FindControl("OrderId")).Text) - 1;
                    }
                    else
                    {
                        dr[2] = int.Parse(((TextBox)this.Repeater1.Items[i].FindControl("OrderId")).Text);
                    }
                    dr[3] = ((DropDownList)this.Repeater1.Items[i].FindControl("TermLink")).SelectedValue;
                    dt.Rows.Add(dr);
                }

                dt.DefaultView.Sort = "OrderId";
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        //删除
        if (e.CommandName == "Delete")
        {
            int OrderId = Convert.ToInt32(e.CommandArgument);

            for (int i = 0, p = 0; i < Repeater1.Items.Count; i++)
            {
                if (int.Parse(((TextBox)this.Repeater1.Items[i].FindControl("OrderId")).Text) != OrderId)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = ((Label)this.Repeater1.Items[i].FindControl("LabelFieldName")).Text;
                    dr[1] = ((Label)this.Repeater1.Items[i].FindControl("LabelFieldType")).Text;
                    dr[2] = p;
                    dr[3] = ((DropDownList)this.Repeater1.Items[i].FindControl("TermLink")).SelectedValue;
                    dt.Rows.Add(dr);
                    p++;
                }
            }

            dt.DefaultView.Sort = "OrderId";
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        dt.Clear();
        dt.Dispose();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Repeater1.Items.Count == 0)
        {
            Literal1.Text = "<script language=javascript>alert('请选择查询条件字段')</script>";
            return;
        }

        string MySql = " Order by ";

        for (int i = 0; i < Repeater1.Items.Count; i++)
        {
            if (i == Repeater1.Items.Count - 1)
            {
                MySql += "" + ((Label)this.Repeater1.Items[i].FindControl("LabelFieldName")).Text + "" + ((DropDownList)this.Repeater1.Items[i].FindControl("TermLink")).SelectedValue + "";
            }
            else
            {
                MySql += "" + ((Label)this.Repeater1.Items[i].FindControl("LabelFieldName")).Text + "" + ((DropDownList)this.Repeater1.Items[i].FindControl("TermLink")).SelectedValue + ",";
            }
        }

        //Response.Write(MySql);

        Response.Write("<script>window.dialogArguments.$('SuperLabelOrderText').value=\"" + MySql + "\";window.close();</script>");
        Response.End();
    }
}
