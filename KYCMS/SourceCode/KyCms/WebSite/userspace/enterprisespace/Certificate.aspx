<%@ Page Language="C#" MasterPageFile="~/userspace/enterprisespace/MasterPage.master" AutoEventWireup="true" %>
<%@ Import Namespace="Ky.Common" %>
<%@ Import Namespace="Ky.BLL" %>
<%@ Import Namespace="Ky.BLL.CommonModel" %>
<%@ Import Namespace="Ky.Model" %> 
<%@ Import Namespace="System.Data" %> 
<%@ Import Namespace="System.Data.SqlClient" %> 
<%@ Import Namespace="Ky.SQLServerDAL" %>
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
        Page.Title = "资质证书";
        userDr = userBll.GetUserAllInfo(userId);
        BindInfoList(userId);
    }

    void BindInfoList(int userId)
    {
        const int typeId = 76; //数据字典中企业新闻的键值编号 int typeId = 74;
        string sqlStr = "select * from [kyenterprise] where [userid]=@userid and [typeid]=@typeid";
        SqlParameter[] parameters = new SqlParameter[2];
        parameters[0] = new SqlParameter("@userid", userId);
        parameters[1] = new SqlParameter("@typeid", typeId);
        DataTable dtInfo = SqlHelper.ExecuteTable(SqlHelper.ConnectionStringKy, CommandType.Text, sqlStr, parameters);
        if (dtInfo.Rows.Count == 0)
        {
            TrInfo.Visible = true;
        }
        else
        {
            repInfoList.DataSource = dtInfo.DefaultView;
            repInfoList.DataBind();
            dtInfo.Dispose();
        }
    } 
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="685px" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="5">
                &nbsp;</td>
            <td height="400" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="3" align="left">
                            您现在的位置：资质证书</td>
                    </tr>
                    <tr>
                        <td width="5" height="30" class="rg01">
                        </td>
                        <td width="674" align="left" class="rg02">
                            <span class="savIcon"></span>资质证书</td>
                        <td width="5" height="30" class="rg03">
                        </td>
                    </tr>
                    <tr>
                        <td height="412" colspan="3" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="leftbk">
                                <tr>
                                    <td height="410" valign="top" align="left">
                                       
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <asp:Repeater runat="server" ID="repInfoList">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td style="border-bottom: 1px dashed #ccc; padding-left: 10px;">
                                                                     <img src="images/purarrow2.gif" /><a href='PreInfo.aspx?Id=<%#Eval("Id") %>&UId=<%#userId %>' target="_blank"><%#Eval("Title") %></a>
                                                                </td>
                                                               <td style="border-bottom: 1px dashed #ccc; padding-left: 10px; text-align:right">
                                                                    <%#Eval("AddTime") %>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <tr id="TrInfo" runat="server" visible="false"><td colspan="2">·暂无资质证书</td></tr>
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

