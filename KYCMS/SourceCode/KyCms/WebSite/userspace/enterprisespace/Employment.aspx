<%@ Page Language="C#" MasterPageFile="~/userspace/enterprisespace/MasterPage.master" AutoEventWireup="true" %>
<%@ Import Namespace="Ky.Common" %>
<%@ Import Namespace="Ky.BLL" %>
<%@ Import Namespace="Ky.BLL.CommonModel" %>
<%@ Import Namespace="Ky.Model" %> 
<%@ Import Namespace="System.Data" %> 
<%@ Import Namespace="System.Data.SqlClient" %> 
<%@ Import Namespace="Ky.SQLServerDAL" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<script runat="server" language="c#">
    B_User userBll = new B_User();
    DataRow userDr = null;
    int userId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
        {
            userId = Convert.ToInt32(Request.QueryString["uid"]);
        }
        Page.Title = "企业招聘";
        userDr = userBll.GetUserAllInfo(userId);
        BindInfoList(userId); 
    }

    void BindInfoList(int userId)
    {
        string sqlStr = "select top 200 * from Ky_U_Recruitment where Uid=@userid";
        SqlParameter[] parameters = new SqlParameter[1];
        parameters[0] = new SqlParameter("@userid", userId);
        DataTable dtInfo = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.Text, sqlStr, parameters);
        repEmploy.DataSource = dtInfo.DefaultView;
        repEmploy.DataBind();
        dtInfo.Dispose();
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="685px" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="5">
                &nbsp;</td>
            <td height="400" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="3" align="left">
                            您现在的位置：企业招聘</td>
                    </tr>
                    <tr>
                        <td width="5" height="30" class="rg01">
                        </td>
                        <td width="674" align="left" class="rg02">
                            <span class="savIcon"></span>企业招聘</td>
                        <td width="5" height="30" class="rg03">
                        </td>
                    </tr>
                    <tr>
                        <td height="412" colspan="3" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="leftbk">
                                <tr>
                                    <td height="410" valign="top" align="left">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <asp:Repeater runat="server" ID="repEmploy">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td style="border-bottom: 1px dashed #ccc; padding-left: 10px;">
                                                            <img src="images/purarrow2.gif" /><a href='../../Info.aspx?ModelId=9&Id=<%#Eval("Id") %>' target="_blank"><%#Eval("Title") %></a>
                                                        </td>
                                                        <td style="border-bottom: 1px dashed #ccc; padding-left: 10px; text-align: right">
                                                            <%#Eval("AddTime") %>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
