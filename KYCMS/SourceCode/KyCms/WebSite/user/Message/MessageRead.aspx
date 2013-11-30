<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageRead.aspx.cs" Inherits="user_Message_MessageRead" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td>
                    您现在的位置：用户后台 >> 短消息管理 >> 发送短消息</td>
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
        <table width='99%' border='0' align='center' cellpadding='2' cellspacing='1' class='border'>
            <tr class='title'>
                <td height='22' align='center'>
                    <strong>阅 读 短 消 息</strong></td>
            </tr>
            <tr class='tdbg'>
                <td align='center'>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">删除消息</asp:LinkButton> &nbsp; <a href="Message.aspx">发送消息</a> &nbsp; <span id="ShowRe" runat="server"><a href="Message.aspx?Action=Re&MessageId=<%=Request.QueryString["id"] %>">回复消息</a>&nbsp;</span> <a href="Message.aspx?Action=Fw&MessageId=<%=Request.QueryString["id"] %>">转发消息</a>
                </td>
            </tr>
            <tr class='tdbg'>
                <td>
                    在<b><asp:Label ID="AddDate" runat="server" Text="Label"></asp:Label>，<asp:Label
                        ID="SendName" runat="server" Text="Label"></asp:Label></b>给您发送短消息！
                </td>
            </tr>
            <tr class='tdbg'>
                <td>
                    <b>消息主题：</b><asp:Label ID="Title" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Content" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
    </form>
</body>
</html>
