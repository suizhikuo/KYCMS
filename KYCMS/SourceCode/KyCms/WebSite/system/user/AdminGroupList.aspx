<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminGroupList.aspx.cs" Inherits="system_user_AdminGroupList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员组列表</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet">
</head>
<body>
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
        <tr>
            <td height="24" width="20">
                <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
            <td align="left" style="padding-top: 3px;">
                您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 管理员组列表</td>
            <td width="50" align="right">
                <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
        </tr>
    </table>
    <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
        <tr class="wzlist">
            <td align="left">
                <a href="AdminGroupList.aspx">管理员组列表</a> | <a href="PowerColumn.aspx">新增管理员组</a>
                | <a href="AdminList.aspx">管理员列表</a> | <a href="SetAdmin.aspx">新增管理员</a></td>
            <td align="right" width="300">
                &nbsp;</td>
        </tr>
    </table>
    <form id="form1" runat="server">
        <table border="0" width="99%" align="center" class="border" cellpadding="0" cellspacing="1">
            <asp:Repeater ID="repAdminGroup" runat="server" OnItemCommand="repAdminGroup_Delete">
                <HeaderTemplate>
                    <tr class="title">
                        <td width="15%">
                            组名称</td>
                        <td width="25%">
                            组描述</td>
                        <td width="10%">
                            成员数量</td>
                        <td width="15%">
                            角色模型</td>
                        <td width="10%">
                            系统组</td>
                        <td width="15%">
                            操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td>
                            <%#Eval("PowerName") %>
                        </td>
                        <td align="center">
                            <%#Eval("PowerContent") %>
                        </td>
                        <td>
                            <%#GetAdminGroupUserCount(Eval("PowerId"))%>
                        </td>
                        <td>
                            <%#Eval("PowerModel")%>
                        </td>
                        <td>
                            <%#GetIsSystem(Eval("IsSystem"))%>
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container,"DataItem.PowerId",   "EditPowerColumn.aspx?PowerId={0}") %>' Enabled='<%# GetIsSystem(int.Parse(DataBinder.Eval(Container, "DataItem.IsSystem", "{0}"))) %>'>设置</asp:HyperLink> |
                            <asp:LinkButton ID="lnkbtnDelete" runat="server" CommandArgument='<%#Eval("PowerId") %>'  OnClientClick="return confirm('你确定删除些管理员组吗?')"
                                Text="删除" Enabled='<%# GetIsSystem(int.Parse(DataBinder.Eval(Container, "DataItem.IsSystem", "{0}"))) %>' CommandName="delete"></asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
    <asp:Literal ID="litMsg" runat="server"></asp:Literal>
</body>
</html>
