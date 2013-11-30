<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserGroupModelList.aspx.cs" Inherits="system_UserGroupModel_UserGroupModelList" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <LINK href="../css/default.css" type=text/css rel=stylesheet>
</head>
<body>
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
        <tr>
            <td height="24" width="20">
                <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
            <td align="left" style="padding-top: 3px;">
                您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 用户注册模型管理</td>
            <td width="50" align="right">
                <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
        </tr>
    </table>
    <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
        <tr class="wzlist">
            <td align="left">
                <a href="UserGroupModel.aspx">添加用户注册模型</a></td>
            <td align="right" width="300">
            </td>
        </tr>
    </table>
    <form id="form1" runat="server">
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <asp:Repeater ID="RepUserGroupModel" runat="server" OnItemCommand="repUserGroupModel_Delete">
                <HeaderTemplate>
                    <tr class="title">
                        <td width="66">
                            用户组编号</td>
                        <td width="100">
                            用户组名称</td>
                        <td>
                            表名</td>
                        <td width="20%">
                            描述</td>
                            <td>注册默认用户组</td>
                        <td width="30%">
                            操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td align="center" width="66">
                            <%#Eval("Id") %>
                        </td>
                        <td align="center" width="100"><%#Eval("Name")%>
                            </a>
                        </td>
                        <td align="center" nowrap>
                            <%#Eval("TableName") %>
                        </td>
                        <td>
                            <%#Eval("Content")%>
                        </td>
                        <td nowrap><%# GetUserGroup(Eval("UserGroupId","{0}")) %></td>
                        <td align="center" nowrap><a href="UserGroupModelPreView.aspx?ModelId=<%#Eval("Id") %>">浏览</a> | <a href='UserGroupModel.aspx?Id=<%#Eval("Id") %>'>修改</a> | <a href='UserGroupModelFieldList.aspx?ModelId=<%#Eval("Id")%>'>字段列表</a>&nbsp;|&nbsp;<asp:LinkButton ID="lnkDelete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm('你确定要删除该用户注册模型吗?')"></asp:LinkButton></a> </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
</body>
</html>
