<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroupList.aspx.cs" Inherits="system_user_GroupList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户组权限列表</title>
    <LINK href="../css/default.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 用户组管理</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                    <table cellpadding="2" cellspacing="0" border="0">
                        <tr>
                            <td><a href="GroupList.aspx">用户组管理首页</a></td>
                            <asp:Repeater ID="RepUserGroupModel" runat="server">
                                <ItemTemplate>
                                    <td> | <a href=UserGroup.aspx?TypeId=<%# Eval("Id") %>>新增<%# Eval("Name") %>组</a></td>
                                </ItemTemplate>
                        </asp:Repeater>
                        </tr>
                    </table>                    
                </td>
            </tr>
        </table>
        <!-- 头部结束 -->
        <table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <tr class="title">
                        <td width="13%" nowrap>
                            组名称</td>
                        <td width="13%" nowrap>
                            组类型</td>
                        <td nowrap>
                            会员组介绍</td>
                        <td nowrap>
                            用户数量</td>
                        <td nowrap>
                            操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td nowrap><%# Eval("UserGroupName") %></td>
                        <td nowrap><%# GetTypeId(int.Parse(DataBinder.Eval(Container, "DataItem.TypeId", "{0}")))%></td>
                        <td nowrap><%# Eval("UserGroupContent") %></td>
                        <td nowrap><%# GetUserGroupNum(int.Parse(DataBinder.Eval(Container, "DataItem.UserGroupId", "{0}")))%>人</td>
                        <td nowrap><asp:LinkButton ID="LinkButton2" runat="server" Enabled='<%# GetIsSystem(int.Parse(DataBinder.Eval(Container, "DataItem.IsSystem", "{0}"))) %>' CommandName="DefaultGroup" CommandArgument='<%# Eval("UserGroupId") %>'>设置注册默认组</asp:LinkButton> | 
                            <a href="UpdateUserGroup.aspx?id=<%# Eval("UserGroupId") %>&TypeId=<%# Eval("TypeId") %>">修改</a> | <asp:LinkButton ID="LinkButton1" runat="server" Enabled='<%# GetIsSystem(int.Parse(DataBinder.Eval(Container, "DataItem.IsSystem", "{0}"))) %>' CommandName="Delete" CommandArgument='<%# Eval("UserGroupId") %>' OnClientClick="return confirm('确认删除该用户组?')">删除</asp:LinkButton> | <a href="UserList.aspx?TypeId=<%# Eval("UserGroupId") %>">列出会员</a></td>
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
