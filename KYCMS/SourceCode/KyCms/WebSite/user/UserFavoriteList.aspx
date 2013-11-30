<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserFavoriteList.aspx.cs"
    Inherits="user_UserFavoriteList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的收藏夹</title>
    <link href="Css/default.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../js/SelectCheckBox.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="20">
                    <img src="images/skin/default/you.gif" align="absmiddle" /></td>
                <td>
                    您现在的位置：用户后台 >> 我的收藏夹 </td>
                <td width="50" align="right">
                </td>
            </tr>
        </table>
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <tr class="title">
                <td align="center" width="30" height="20">
                    <strong>全选</strong></td>
                <td align="center">
                    <strong>收藏标题</strong></td>
                <td align="center">
                    <strong>收藏日期</strong></td>
                <td align="center" width="40">
                    <strong>操作</strong></td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox><asp:TextBox Text='<%# DataBinder.Eval(Container, "DataItem.Id","{0}")%>'
                                Style="display: none" ID="CID" runat="server"></asp:TextBox></td>
                        <td>
                            <a href="<%# Eval("Url") %>" target="_blank"><%# Eval("Title") %></a>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container, "DataItem.AddDate", "{0}")%>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>'
                                OnClientClick="return confirm('确定删除此收藏信息吗?')">删除</asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" align="center" width="99%">
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" PageSize="20" HorizontalAlign="Right" PrevPageText="上一页"
                        ShowInputBox="Never" UrlPageIndexName="p" UrlPaging="True" ShowCustomInfoSection="Left"
                        Width="99%">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" align="center" width="99%">
            <tr>
                <td height="50">
                    <asp:Button ID="Button1" runat="server" Text="删除勾选记录" CssClass="btn" onmousedown="if(confirm('您确认删除选中记录？'))document.form1.Button1.click(); else return false;"
                        OnClick="Button1_Click"></asp:Button>&nbsp;&nbsp;&nbsp;<input id="checkDel" onclick="CheckDelBox(this)"
                            type="checkbox"><span id="ShowA">选择全部</span>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
