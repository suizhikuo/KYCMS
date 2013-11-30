<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetUser.aspx.cs" Inherits="user_SetUser" %>

<%@ Register Src="../common/Linkage.ascx" TagName="Linkage" TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改注册信息</title>
    <link href="Css/Default.css" rel="Stylesheet" type="text/css" />

    <script src="../js/Common.js" type="text/javascript"></script>
    <script src="../JS/InfoModel.js" type="text/javascript"></script>
    <script src="../JS/RiQi.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
                <tr>
                    <td width="20">
                        <img align="absMiddle" src="images/skin/default/you.gif" /></td>
                    <td>
                        您现在的位置：<a href="welcome.aspx">用户后台</a>&gt;&gt; <a href="SetUser.aspx">资料维护</a>&gt;&gt;
                        修改资料<uc1:Linkage ID="Linkage1" runat="server" />
                    </td>
                    <td align="right" width="50">
                    </td>
                </tr>
            </table>
        </div>
        <table align="center" cellpadding="0" cellspacing="1" class="wzlist" width="99%">
            <tr>
                <td>
                    <a href="SetUser.aspx">资料维护</a> | <a href="ChangePwd.aspx">修改密码</a> | <a href="changeQA.aspx">
                        修改密码保护</a><asp:TextBox ID="FilePicPath" runat="server" style="display:none">User|0</asp:TextBox></td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" width="100%" align="center">
            <tr>
                <td class="bqleft">
                    隐私设定：</td>
                <td class="bqright">
                    <asp:RadioButtonList ID="txtSecret" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">公开</asp:ListItem>
                        <asp:ListItem Value="0">隐藏</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <asp:Literal ID="ModelHtml" runat="server"></asp:Literal><tr id="Code" runat="server">
                <td class="bqleft">
                    验证码：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtCode" runat="server" MaxLength="6" CssClass="textbox"></asp:TextBox>
                    <img src="../common/Code.aspx" align="absMiddle" onclick="this.src='../common/code.aspx'"
                        alt="给我换一个" /></td>
            </tr>
            <tr>
                <td class="bqleft">
                </td>
                <td class="bqright">
                    <asp:Button ID="txtSubmit" runat="server" Text=" 修 改 " OnClick="txtSubmit_Click"
                        CssClass="btn" />
                    <input id="Reset1" type="reset" value=" 重 置 " class="btn" /></td>
            </tr>
        </table>
        <asp:Literal ID="ModelJs" runat="server"></asp:Literal>
    </form>
</body>
</html>