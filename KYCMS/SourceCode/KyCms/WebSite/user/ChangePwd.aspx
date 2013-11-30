<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="Users_ChangePwd" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
    <link href="Css/Default.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table align="center" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
            <tr>
                <td width="20">
                    <img align="absMiddle" src="images/skin/default/you.gif" /></td>
                <td>
                    您现在的位置：<a href="welcome.aspx">用户后台</a> &gt;&gt; 修改密码</td>
                <td align="right" width="50">
                </td>
            </tr>
        </table>
        <table align="center" cellpadding="0" cellspacing="0" class="wzlist" width="99%">
            <tr>
                <td>
                    <a href="SetUser.aspx">个人资料维护</a> | <a href="ChangePwd.aspx">修改密码</a> | <a href="changeQA.aspx">
                        修改密码保护</a> &nbsp;</td>
            </tr>
        </table>
        <table cellpadding="2" cellspacing="1" class="border" style="width: 99%" align="center">
            <tr>
                <td class="bqleft">
                    用户名:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtUserName" runat="server" MaxLength="20" CssClass="textbox" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="bqleft">
                    原密码:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" MaxLength="20" CssClass="textbox"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="bqleft">
                    新密码:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtNewpwd" runat="server" TextMode="Password" MaxLength="20" CssClass="textbox"></asp:TextBox><span class="tips">6-20 字符</span></td>
            </tr>
            <tr>
                <td class="bqleft" style="height: 25px">
                    确认新密码:</td>
                <td class="bqright" style="height: 25px">
                    <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password" MaxLength="20"
                        CssClass="textbox"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="bqleft">
                </td>
                <td class="bqright" height="40">
                    <asp:Button ID="btnOk" runat="server" CssClass="btn" Text=" 修 改 " OnClick="btnOk_Click" />
                    <input id="Reset1" class="btn" type="reset" value=" 重 置 " /></td>
            </tr>
        </table>
    </form>
</body>
</html>
