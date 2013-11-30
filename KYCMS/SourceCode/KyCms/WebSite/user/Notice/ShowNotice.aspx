<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowNotice.aspx.cs" Inherits="user_Notice_ShowNotice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>详细公告</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：用户后台 >> 系统公告 >> 公告详细信息</td>
            </tr>
        </table>
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <tr class="title">
                <td align="left">
                    <strong><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></strong></td>
            </tr>
            <tr class="tdbg">
                <td align="center">
                    发布人：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label> &nbsp;&nbsp发布时间：<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label> &nbsp;&nbsp 过期时间： 
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr class="tdbg">
                <td align="left" style="line-height:130%">
                    &nbsp<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label> </td>
            </tr>
            <tr class="tdbg">
                <td align="center" height="34">
                    <input type="button" value="返回公告列表" onclick="window.location.href='NoticeList.aspx'" class="btn" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
