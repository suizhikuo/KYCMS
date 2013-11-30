<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetRecommand.aspx.cs" Inherits="user_SetRecommand" %>

<html>
<head runat="server">
    <title>推广奖励</title>
    <link href="Css/Default.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table align="center" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
            <tr>
                <td width="20">
                    <img align="absMiddle" src="images/skin/default/you.gif" /></td>
                <td>
                    您现在的位置：<a href="welcome.aspx">用户后台</a> &gt;&gt; 推广奖励</td>
                <td align="right" width="50">
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" align="center" runat="server"
            id="MainTable">
            <tr>
                <td>
                    复制下面的代码给您的好友,若您的好友在本站注册成功,您可以得到
                    <asp:Label ID="lbIntegral" runat="server" Text="" ForeColor="red"></asp:Label>
                    的推广积分.</td>
            </tr>
            <tr>
                <td>
                    推荐代码:<asp:TextBox ID="txtUrl" runat="server" Width="389px" CssClass="textbox"></asp:TextBox>&nbsp;<input
                        id="btnCopy" class="btn" type="button" value="复制" onclick="txtUrl.focus();document.execCommand('selectall');document.execCommand('copy');this.value='已复制'" /></td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" runat="server" align="center"
            id="InfoTable">
            <tr>
                <td>
                    对不起,本站暂时关闭了推广奖励功能.
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
