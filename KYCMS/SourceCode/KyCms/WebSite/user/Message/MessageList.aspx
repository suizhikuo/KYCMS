<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageList.aspx.cs" Inherits="user_Message_MessageList" %>

<%@ Import Namespace="Ky.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../../js/SelectCheckBox.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td>
                    您现在的位置：用户后台 >> 短消息管理 >>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    >> 所有短消息</td>
                <td width="50" align="right">
                </td>
            </tr>
        </table>
        <table width="99%" cellspacing="0" cellpadding="0" class="wzlist" align="center">
            <tr>
                <td>
                    <a href="MessageList.aspx?TypeId=1">短消息管理</a> | <a href="Message.aspx">发送短消息</a></td>
                <td align="right" width="300">
                    <a href="MessageList.aspx?TypeId=3">草稿箱</a> | <a href="MessageList.aspx?TypeId=1">收件箱</a>
                    | <a href="MessageList.aspx?TypeId=2">发件箱</a> | <a href="MessageList.aspx?TypeId=4">
                        回收站</a></td>
            </tr>
        </table>
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <tr class="title">
                <td align="center" width="30" height="20">
                    <strong>全选</strong></td>
                <td align="center">
                    <strong>短消息主题</strong></td>
                <%if (PrintMode(1))
                      { %>
                <td align="center" width="70">
                    <strong>发件人</strong></td>
                <%} %>
                <%if (PrintMode(2))
                      { %>
                <td align="center" width="70">
                    <strong>收件人</strong></td>
                <%} %>
                <td align="center" width="140">
                    <strong>发送日期</strong></td>
                <td align="center" width="50">
                    <strong>大小</strong></td>
                <td align="center" width="30">
                    <strong>已读</strong></td>
                <td align="center" width="40">
                    <strong>操作</strong></td>
            </tr>
            <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td>
                        </td>
                        <td align="left">
                            <a href="MessageRead.aspx?TypeId=<%=Request.QueryString["TypeId"] %>&id=<%# Eval("WMId") %>"><%# Eval("Title") %></a>
                        </td>
                        <td visible='<%# PrintMode(1)%>' runat="server">
                            <%# Eval("SendName") %>
                        </td>
                        <td visible='<%# PrintMode(2)%>' runat="server">
                            <%# Eval("ReceiverName") %>
                        </td>
                        <td>
                            <%# Eval("AddDate") %>
                        </td>
                        <td>
                            <%# Function.GetStrByByte(DataBinder.Eval(Container, "DataItem.Content", "{0}"))%>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox><asp:TextBox Text='<%# DataBinder.Eval(Container, "DataItem.WMId","{0}")%>'
                                Style="display: none" ID="CID" runat="server"></asp:TextBox></td>
                        <td align="left"><%if (Request.QueryString["TypeId"]=="3") {%>
                            <a href="Message.aspx?Action=Edit&MessageId=<%# Eval("WMId") %>"><%} else{%><a href="MessageRead.aspx?TypeId=<%=Request.QueryString["TypeId"] %>&id=<%# Eval("WMId") %>"><%} %><%# Eval("Title") %></a>
                        </td>
                        <td visible='<%# PrintMode(1)%>' runat="server">
                            <%# Eval("SendName") %>
                        </td>
                        <td visible='<%# PrintMode(2)%>' runat="server">
                            <%# Eval("ReceiverName") %>
                        </td>
                        <td>
                            <%# Eval("AddDate") %>
                        </td>
                        <td>
                            <%# Function.GetStrByByte(DataBinder.Eval(Container, "DataItem.Content", "{0}"))%>
                        </td>
                        <td>
                            <%# GetIsRead(DataBinder.Eval(Container, "DataItem.IsRead", "{0}"))%>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" CommandArgument='<%# Eval("WMId") %>'
                                OnClientClick="return confirm('确定删除此短消息吗?')">删除</asp:LinkButton></td>
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
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                    短消息搜索：<asp:DropDownList ID="TypeId" runat="server">
                        <asp:ListItem Value="1">收件箱</asp:ListItem>
                        <asp:ListItem Value="2">草稿箱</asp:ListItem>
                        <asp:ListItem Value="3">发件箱</asp:ListItem>
                        <asp:ListItem Value="4">回收站</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="SearchId" runat="server">
                        <asp:ListItem Value="0">搜索类型</asp:ListItem>
                        <asp:ListItem Value="1">短消息主题</asp:ListItem>
                        <asp:ListItem Value="2">短消息内容</asp:ListItem>
                    </asp:DropDownList><asp:TextBox ID="KeyWord" runat="server" Text="关键字" onclick="javascript:this.value=''"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text=" 搜 索 " CssClass="btn" OnClick="Button2_Click" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
