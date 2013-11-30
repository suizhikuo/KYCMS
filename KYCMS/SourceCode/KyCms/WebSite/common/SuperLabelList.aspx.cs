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
using Ky.Common;
using Ky.Model;
using System.Text.RegularExpressions;
using System.Text;

public partial class common_SuperLabelList : System.Web.UI.Page
{
    private B_SuperLabel BSuperLabel = new B_SuperLabel();
    private M_SuperLabel MSuperLabel = new M_SuperLabel();
    protected int SuperId = 0;
    private B_Create BCreate = new B_Create();
    protected string SqlContent = "";
    protected string[] MySqlContent;
    protected int page = 1;

    protected string ColumnsContent = "";
    protected string[] MyColumnsContent;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (!string.IsNullOrEmpty(Request.QueryString["SuperId"]))
        {
            try
            {
                SuperId = int.Parse(Request.QueryString["SuperId"]);
            }
            catch { }
        }

        MSuperLabel = BSuperLabel.GetModel(SuperId);
        SqlContent = MSuperLabel.Content;
        MySqlContent = new string[3];
        GetStyle(MySqlContent);

        //循环列
        ColumnsContent = MySqlContent[1];
        MyColumnsContent = new string[3];
        GetStyleColumns(MyColumnsContent);

        if (!Page.IsPostBack)
        {
            DataBindList();
        }
    }

    private void DataBindList()
    {
        if (SuperId == 0)
        {
            Response.Write("超级标签参数错误！");
            Response.End();
        }
        else
        {
            if (MSuperLabel == null)
            {
                Response.Write("该超级标签不存在，或者已经被删除！");
                Response.End();
            }
            else
            {
                string Sqlstr = MSuperLabel.SqlStr;
                DataTable dt = new DataTable();
                dt = BSuperLabel.CheckSql(Sqlstr);
                string MyGetSuperLabel = "";

                if (!string.IsNullOrEmpty(Request.QueryString["page"]))
                {
                    try
                    {
                        page = int.Parse(Request.QueryString["page"]);
                    }
                    catch { }
                }

                if (dt == null)
                {
                    Response.Write("该超级标签Sql语句存在错误！");
                    Response.End();
                }
                else
                {
                    int PageSize = MSuperLabel.PageSize;
                    int DtCount = dt.Rows.Count;

                    #region 分页
                    if (MSuperLabel.IsUnlockPage)
                    {
                        string MyLitPage = "";
                        int TatalPage;

                        if (DtCount % PageSize == 0)
                        {
                            TatalPage = DtCount / PageSize;
                        }
                        else
                        {
                            TatalPage = (DtCount / PageSize) + 1;
                        }

                        MyLitPage += "<table align=\"center\" cellpadding=\"2\"><tr><td>总记录：" + DtCount + "条</td><td>每页：" + PageSize + "条</td><td>当前：" + page + "/" + TatalPage + "</td>";

                        if (page == 1)
                        {
                            MyLitPage += "<td>首页</td>";
                        }
                        else
                        {
                            MyLitPage += "<td><a href=\"javascript:SuperLabelPage('" + Param.ApplicationRootPath + "/common/SuperLabelList.aspx?SuperId=" + SuperId + "&page=1','SuperLabel_Div_" + SuperId + "')\">首页</a></td>";
                        }

                        if (page > 1)
                        {
                            MyLitPage += "<td><a href=\"javascript:SuperLabelPage('" + Param.ApplicationRootPath + "/common/SuperLabelList.aspx?SuperId=" + SuperId + "&page=" + (page - 1) + "','SuperLabel_Div_" + SuperId + "')\">上一页</a></td>";
                        }
                        else
                        {
                            MyLitPage += "<td>上一页</td>";
                        }

                        if (page == (TatalPage))
                        {
                            MyLitPage += "<td>下一页</td><td>尾页</td>";
                        }
                        else
                        {
                            MyLitPage += "<td><a href=\"javascript:SuperLabelPage('" + Param.ApplicationRootPath + "/common/SuperLabelList.aspx?SuperId=" + SuperId + "&page=" + (page + 1) + "','SuperLabel_Div_" + SuperId + "')\">下一页</a><td><a href=\"javascript:SuperLabelPage('" + Param.ApplicationRootPath + "/common/SuperLabelList.aspx?SuperId=" + SuperId + "&page=" + TatalPage + "','SuperLabel_Div_" + SuperId + "')\">尾页</a></td></td>";
                        }

                        MyLitPage += "</tr></table>";

                        Lit_Page.Text = MyLitPage;

                        DataTable dt1 = BCreate.GetPagedTable(dt, page, PageSize);

                        //定制需求
                        MyGetSuperLabel += MySqlContent[0];
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            if (MySqlContent[1].Trim().ToLower().IndexOf("<ky_loop_columns>") > 0 && MySqlContent[1].Trim().ToLower().IndexOf("</ky_loop_columns>") > 0)
                            {
                                MyGetSuperLabel += MyColumnsContent[0];
                                for (int n = 0; n < MSuperLabel.NumColumns; n++, i++)
                                {
                                    if (i == dt1.Rows.Count)
                                    {
                                        MyGetSuperLabel += MyColumnsContent[0] + MyColumnsContent[2];
                                    }
                                    else
                                    {
                                        MyGetSuperLabel += "" + StrValue(dt1.Rows[i], MSuperLabel.HostTable, MyColumnsContent[1]) + "";
                                    }
                                }
                                MyGetSuperLabel += MyColumnsContent[2];
                            }
                            else
                            {
                                MyGetSuperLabel += "" + StrValue(dt1.Rows[i], MSuperLabel.HostTable, MySqlContent[1]) + "";
                            }
                        }
                        MyGetSuperLabel += MySqlContent[2];

                        Lit_Table.Text = MyGetSuperLabel;
                    }
                    else
                    {
                        //定制需求
                        MyGetSuperLabel += MySqlContent[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (MySqlContent[1].Trim().ToLower().IndexOf("<ky_loop_columns>") > 0 && MySqlContent[1].Trim().ToLower().IndexOf("</ky_loop_columns>") > 0)
                            {
                                MyGetSuperLabel += MyColumnsContent[0];
                                for (int n = 0; n < MSuperLabel.NumColumns; n++, i++)
                                {
                                    if (i == dt.Rows.Count)
                                    {
                                        MyGetSuperLabel += MyColumnsContent[0] + MyColumnsContent[2];
                                    }
                                    else
                                    {
                                        MyGetSuperLabel += "" + StrValue(dt.Rows[i], MSuperLabel.HostTable, MyColumnsContent[1]) + "";
                                    }
                                }
                                MyGetSuperLabel += MyColumnsContent[2];
                            }
                            else
                            {
                                MyGetSuperLabel += "" + StrValue(dt.Rows[i], MSuperLabel.HostTable, MySqlContent[1]) + "";
                            }
                        }
                        MyGetSuperLabel += MySqlContent[2];

                        Lit_Table.Text = MyGetSuperLabel;
                    }

                    dt.Clear();
                    dt.Dispose();

                    #endregion
                }
            }
        }
    }

    protected void GetStyle(string[] content)
    {
        Match match = Regex.Match(SqlContent, @"((?:.|\n)*?)<ky_loop>((?:.|\n)*?)</ky_loop>((?:.|\n)*)", RegexOptions.IgnoreCase);
        for (int i = 0; i < 3; i++)
        {
            content[i] = match.Groups[i + 1].Value;
        }
    }

    protected void GetStyleColumns(string[] content)
    {
        Match match = Regex.Match(ColumnsContent, @"((?:.|\n)*?)<ky_loop_columns>((?:.|\n)*?)</ky_loop_columns>((?:.|\n)*)", RegexOptions.IgnoreCase);
        for (int i = 0; i < 3; i++)
        {
            content[i] = match.Groups[i + 1].Value;
        }
    }

    public string StrValue(DataRow dr, string HostTable, string MyContent)
    {
        StringBuilder sb = new StringBuilder(MyContent);
        MatchCollection matches = BCreate.GetStyleFileldName(MyContent);

        string MySbValue = sb.ToString();

        foreach (Match m in matches)
        {
            if (m.Groups.Count > 1)
            {
                if (m.Groups[1].Value.ToLower() == "infourl")
                {
                    MySbValue = MySbValue.Replace(m.Value, "" + BCreate.GetInfoUrl(int.Parse(dr["Id"].ToString()), MSuperLabel.HostTable) + "");
                }
                else
                {
                    if (m.Groups[1].Value.ToLower() == "title")
                    {
                        MySbValue = MySbValue.Replace(m.Value, "" + Function.Encode(dr["" + m.Groups[1].Value + ""].ToString()) + "");
                    }
                    else
                    {
                        MySbValue = MySbValue.Replace(m.Value, "" + dr["" + m.Groups[1].Value + ""].ToString() + "");
                    }
                }
            }
        }
        return MySbValue.ToString();
    }
}
