<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeQA.aspx.cs" Inherits="user_changeQA" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码保护</title>
    <link href="css/default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
                <tr>
                    <td width="20">
                        <img align="absMiddle" src="images/skin/default/you.gif" /></td>
                    <td>
                        您现在的位置：<a href="welcome.aspx">用户后台</a> &gt;&gt; 修改密码问题</td>
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
            <asp:Panel ID="mainPanel" runat="server" Width="100%">
                <table align="center" border="0" cellpadding="2" cellspacing="1" class="border" width="99%">
                    <tr>
                        <td class="bqleft" width="80">
                            请回答保护问题：</td>
                        <td class="bqright">
                            <asp:Label ID="lbQuestion" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bqleft" style="height: 24px">
                            答案：</td>
                        <td class="bqright" style="height: 24px">
                            <asp:TextBox ID="txtAnswer" runat="server" CssClass="textbox" MaxLength="20" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            设置新提示问题：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtNewQuestion" runat="server" MaxLength="50" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            设置新的答案：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtNewAnswer" runat="server" MaxLength="20" CssClass="textbox" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                        </td>
                        <td class="bqright" height="40">
                            <asp:Button ID="btnOk" runat="server" CssClass="btn" Text=" 修 改 " OnClick="btnOk_Click" />
                            <input id="Reset1" class="btn" type="reset" value=" 重 置 " /></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
