<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoLogin.aspx.cs" Inherits="user_DoLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户登录</title>
    <link href="css/Default.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" cellpadding="0" cellspacing="0" height="70" width="99%">
                <tr>
                    <td align="left" width="40%">
                        <img src="images/logo.jpg" /></td>
                    <td align="center">
                        <img src="images/banner.gif" /></td>
                </tr>
            </table>
            <table align="center" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
                <tr>
                    <td width="20">
                        <img align="absMiddle" src="images/skin/default/you.gif" /></td>
                    <td>
                        您现在的位置：<asp:HyperLink ID="hylnkIndex" runat="server">站点首页</asp:HyperLink>
                        &gt;&gt; 登录成功</td>
                    <td align="right" width="50">
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" class="border" width="99%" align="center">
                <tr class="title">
                    <td>
                        登录成功</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lbUserName" runat="server"></asp:Label>，欢迎您回来。3 秒后自动转向到您最初请求的页面。<br />
                        如果您的浏览器没有自动转向，请点击这里：<br />
                        <asp:HyperLink ID="hyRefer" runat="server"></asp:HyperLink>
                        <br />
                        <br />
                        或者您可以
                        <br />
                        <asp:HyperLink ID="hyMain" runat="server">返回用户中心</asp:HyperLink>
                        <asp:HyperLink ID="hyIndex" runat="server">返回网站首页</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
