<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoticeList.aspx.cs" Inherits="system_other_NoticeList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公告列表</title>
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../js/SelectCheckBox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="NoticeList.aspx">会员后台公告</a> >> <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                    <a href="NoticeList.aspx">用户后台公告列表</a> | <a href="Notice.aspx">添加公告</a></td>
                <td align="right" width="300">
                    <a href="NoticeList.aspx?UserId=-1&TypeId=4">我发的公告</a> | <a href="NoticeList.aspx?UserId=0&TypeId=3">未审核公告</a> | <a href="NoticeList.aspx?UserId=0&TypeId=5">已过期公告</a>&nbsp;</td>
            </tr>
        </table>
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <tr class="title">
                        <td align="center" width="30" height="20">
                            <strong>全选</strong></td>
                        <td align="center">
                            <strong>公告标题</strong></td>
                        <td align="center">
                            <strong>发布人</strong></td>
                        <td align="center">
                            <strong>发布时间</strong></td>
                        <td align="center">
                            <strong>过期时间</strong></td>
                        <td align="center">
                            <strong>常规操作</strong></td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td width="30"><asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox><asp:TextBox Text='<%# DataBinder.Eval(Container, "DataItem.NoticeId","{0}")%>'  Style="display: none" ID="CID" runat="server"></asp:TextBox></td>
                        <td align="left"><%# Eval("Title") %></td>
                        <td width="80"><%# Eval("UserName") %></td>
                        <td width="100"><%# DataBinder.Eval(Container, "DataItem.AddDate", "{0:yyyy-MM-dd}") %></td>
                        <td width="100"><%# DataBinder.Eval(Container, "DataItem.OverdueDate", "{0:yyyy-MM-dd}") %></td>
                        <td width="160">
                            <a href="Notice.aspx?NoticeId=<%# Eval("NoticeId") %>">修改</a> | <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" CommandArgument='<%# Eval("NoticeId") %>' OnClientClick="return confirm('确定删除此公告吗?')">删除</asp:LinkButton> | 
                            <asp:LinkButton ID="LinkButton2" CommandName="IsState" OnClientClick="return confirm('确定更改操作吗?')" CommandArgument='<%# Eval("NoticeId") %>' runat="server"><%# GetIsState(DataBinder.Eval(Container, "DataItem.IsState", "{0}"))%></asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" align="center" width="99%">
            <tr>
                <td>
                    <webdiyer:aspnetpager id="Pager" runat="server" alwaysshow="True" firstpagetext="首页" lastpagetext="尾页" nextpagetext="下一页" pagesize="20" horizontalalign="Right" prevpagetext="上一页" showinputbox="Never" urlpageindexname="p" urlpaging="True" showcustominfosection="Left" width="99%">
                </webdiyer:aspnetpager>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" align="center" width="99%">
            <tr>
                <td height="50"><asp:Button ID="Button1" runat="server" Text="删除勾选记录" CssClass="btn" onmousedown="if(confirm('您确认删除选中记录？'))document.form1.Button1.click(); else return false;"
                        OnClick="Button1_Click"></asp:Button>&nbsp;&nbsp;&nbsp;<input id="checkDel" onclick="CheckDelBox(this)"
                            type="checkbox"><span id="ShowA">选择全部</span>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
