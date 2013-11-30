<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetailReview.aspx.cs" Inherits="system_review_DetailReview" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Ky.Common" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看详细评论</title>
    <link rel="stylesheet" href="../css/default.css" type="text/css" />
    <script language="javascript" src="../../js/SelectCheckBox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27" height="24">
                    &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" /></td>
                <td>
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href='ReviewManage.aspx'>用户评论管理</a> >> 详细评论信息</td>
                <td width="116" align="center">
                    &nbsp;</td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr>
                <td colspan="6">
                    <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center">
                        <tr class="title">
                            <td width="83%" style="text-align: left;">
                                <asp:Label ID="Title" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <asp:Repeater ID="repReview" runat="server" OnItemCommand="repReview_ItemCommand">
                <ItemTemplate>
                    <tr class="tdbg">
                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox><asp:TextBox Text='<%# DataBinder.Eval(Container, "DataItem.id","{0}")%>'
                                Style="display: none" ID="CID" runat="server"></asp:TextBox></td>
                        <td width="45%" align="left" style="word-warp: break-word; word-break: break-all">
                            <%# Function.UbbToHtml(Eval("ReviewContent").ToString())%>
                        </td>
                        <td width="10%">
                            <%# GetName(Eval("LogName").ToString())%>
                        </td>
                        <td width="20%">
                            <%# Eval("ReviewTime")%>
                        </td>
                        <td width="15%">
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="IsCheck" CommandArgument='<%# Eval("Id") %>'><%# GetIsCheck(Eval("IsCheck").ToString())%></asp:LinkButton></td>
                        <td width="10%">
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>'
                                OnClientClick="return confirm('确定删除此评论吗?')">删除</asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" align="center" width="99%">
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" PageSize="10" HorizontalAlign="Right" PrevPageText="上一页"
                        ShowInputBox="Never" UrlPageIndexName="p" UrlPaging="True" ShowCustomInfoSection="Left"
                        Width="99%">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" align="center" width="99%">
            <tr>
                <td height="50">
                    <asp:Button ID="btnDelete" runat="server" Text="删除勾选记录" CssClass="btn" onmousedown="if(confirm('您确认删除选中记录？'))document.getElementById('btnDelete').click(); else return false;"
                        OnClick="btnDelete_Click"></asp:Button>&nbsp;&nbsp;&nbsp;<input id="checkDel" onclick="CheckDelBox(this)"
                            type="checkbox"><span id="ShowA">选择全部</span>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
