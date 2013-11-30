<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Activate.aspx.cs" Inherits="user_Activate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>激活您的账户</title>
    <link href="css/Default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
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
                    &gt;&gt; 激活帐户</td>
                <td align="right" width="50">
                </td>
            </tr>
        </table>
        <asp:Label ID="lbState" runat="server" Text=""></asp:Label><asp:Label ID="lbInfo"
            runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
