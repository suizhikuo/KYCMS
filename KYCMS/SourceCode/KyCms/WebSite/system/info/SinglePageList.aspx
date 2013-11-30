<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SinglePageList.aspx.cs" Inherits="system_info_SinglePageList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../css/default.css" type="text/css" rel="stylesheet">
    <script src="../../js/Common.js" type="text/javascript"></script>
</head>
<body>
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
        <tr>
            <td height="24" width="20">
                <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
            <td align="left" style="padding-top: 3px;">
                您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="ChannelList.aspx">内容管理</a> &gt;&gt; 单页管理</td>
            <td width="50" align="right">
                <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
        </tr>
    </table>
    <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
        <tr class="wzlist">
            <td align="left">
                <a href="SinglePage.aspx">新增单页</a>
            </td>
        </tr>
    </table>
    <form id="form1" runat="server">
    <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <tr class="title">
                        <td align="center" height="20">
                            <strong>单页名称</strong></td>
                        <td align="center">
                            <strong>更新时间</strong></td>
                            <td><strong>Html连接代码</strong></td>
                        <td align="center">
                            <strong>操作</strong></td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("AddTime")%></td>
                        <td><a href="javascript:" onclick="WinOpenDialog('SinglePageUrl.aspx?SingleId=<%#Eval("SingleId")%>','500','230')">Html连接代码</a></td>
                        <td><asp:LinkButton ID="LinkButton2" runat="server" CommandName="Create" CommandArgument='<%# Eval("SingleId") %>'>生成该单页</asp:LinkButton> | <a href="SinglePage.aspx?SingleId=<%# Eval("SingleId") %>">修改</a> | 
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" CommandArgument='<%# Eval("SingleId") %>' OnClientClick="return confirm('确定删除此单页吗?')">删除</asp:LinkButton></td>
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
    </form>
</body>
</html>
