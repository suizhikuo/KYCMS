<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ColumnList.aspx.cs" Inherits="System_Delete_ColumNavigati" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>栏目管理</title>
    <meta content="MSHTML 6.00.3790.4064" name="GENERATOR" />
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />

    <script src="../../JS/Common.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="20" height="24">
                    <img src="../images/skin/default/you.gif" width="17" height="16" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href='ChannelList.aspx'>频道管理</a> &gt;&gt; [<asp:Literal ID="litNav" runat="server"></asp:Literal>] 栏目管理</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="1" class="border" style="width: 99%"
            align="center">
            <tr class="wzlist">
                <td>
                    <a href='SetColumn.aspx?ChId=<%=ChId %>'>添加栏目</a> |
                    <asp:HyperLink ID="hyperInfo" runat="server"></asp:HyperLink><img src="../images/comment_add.gif" border="0" />
                    | <a href="ColumnToTemplate.aspx?ChId=<%=ChId %>">批量设置</a> | <a href='MoveColumn.aspx?ChId=<%=ChId %>''>
                        栏目移动</a>
                </td>
            </tr>
        </table>
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <asp:Repeater ID="repColumn" runat="server" OnItemCommand="rep_ItemCommand">
                <HeaderTemplate>
                    <tr class="title">
                        <td style="width: 6%">
                            编号</td>
                        <td style="width: 28%">
                            栏目名称</td>
                        <td align="center" style="width: 30%">
                            栏目描述</td>
                        <td style="width: 10%">
                            栏目状态</td>
                        <td style="width: 25%" align="center">
                            功能操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td>
                            <asp:Label ID="lblColID" runat="server" Text='<%# Eval("ColId") %>' Visible="True"></asp:Label></td>
                        <td align="left">
                            <asp:LinkButton ID="linkbtnChar" runat="server" CommandName="emblme" ForeColor="Red"
                                Font-Bold="True" Font-Size="Medium"></asp:LinkButton>
                            &nbsp;
                            <asp:Label ID="lblColParentId" runat="server" Text='<%# Eval("ColParentId") %>' Visible="False"></asp:Label>
                            <a href='InfoList.aspx?ChId=<%#ChId %>&ColId=<%#Eval("ColId") %>'>
                                        <%# Eval("ColName") %></a> <a href='<%#Url %>?ChId=<%#ChId %>&ColId=<%#Eval("ColId") %>'><img src='../images/comment_add.gif' border='0' align="absmiddle"/></a>
                        </td>
                        <td align="left">
                            <%# Eval("Description") %>
                        </td>
                        <td>
                            <%#GetIsOpened(Eval("IsOpened"))%>
                        </td>
                        <td>
                            <a href='../preview/PreColumn.aspx?ColId=<%#Eval("ColId") %>' target="_blank">预览</a> | <a href="SetColumn.aspx?ChId=<%#ChId %>&ChildColId=<%#Eval("ColId") %>">添加子栏目</a> | <a
                                href='SetColumn.aspx?ChId=<%#ChId %>&ColId=<%#Eval("ColId") %>'>修改</a> |
                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteOne" OnClientClick="return confirm('你确认删除该栏目到回收站吗?\r\n注意：相关子栏目和内容也将一起删除到回收站');">删除 </asp:LinkButton>
                        </td>
                    </tr>
                    <asp:Repeater ID="repChildColumn" runat="server" OnItemCommand="repChidColumn_ItemCommand">
                        <ItemTemplate>
                            <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                <td>
                                    <asp:Label ID="lblColIDTwo" runat="server" Text='<%# Eval("ColId") %>' Visible="True"></asp:Label></td>
                                <td align="left">
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblColIDZi" runat="server" Text='<%# Eval("ColId") %>'
                                        Visible="False"></asp:Label>
                                    <asp:Label ID="lblColParentIdTwo" runat="server" Text='<%# Eval("ColParentId") %>'
                                        Visible="False"></asp:Label>
                                    <a href='InfoList.aspx?ChId=<%#ChId %>&ColId=<%#Eval("ColId") %>'>
                                        <%# Eval("ColName") %>
                                    </a> <a href='<%#Url %>?ChId=<%#ChId %>&ColId=<%#Eval("ColId") %>'><img src='../images/comment_add.gif' align="absmiddle" border='0'/></a>
                                </td>
                                <td align="left">
                                    <%# Eval("Description") %>
                                </td>
                                <td>
                                    <%#GetIsOpened(Eval("IsOpened"))%>
                                </td>
                                <td align="center">
                                    <a href='../preview/PreColumn.aspx?ColId=<%#Eval("ColId") %>' target="_blank">预览</a> | <a href="SetColumn.aspx?ChId=<%#ChId %>&ChildColId=<%#Eval("ColId") %>">添加子栏目</a> | <a
                                        href='SetColumn.aspx?ChId=<%#ChId %>&ColId=<%#Eval("ColId") %>'>修改</a> |
                                    <asp:LinkButton ID="btnDeleteTwo" runat="server" CommandName="DeleteTwo" OnClientClick="return confirm('你确认删除该栏目到回收站吗?\r\n注意：相关子栏目和内容也将一起删除到回收站');">删除</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
</body>
</html>
