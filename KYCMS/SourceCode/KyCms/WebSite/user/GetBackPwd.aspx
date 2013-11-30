<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetBackPwd.aspx.cs" Inherits="user_GetBackPwd" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>找回密码</title>
    <link href="css/Default.css" type="text/css" rel="Stylesheet" />

    <script src="../js/Common.js" type="text/javascript"></script>

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
                <td align="left" style="padding-top: 3px">
                    您现在的位置：<asp:HyperLink ID="hylnkIndex" runat="server">站点首页</asp:HyperLink>
                    &gt;&gt; 找回密码</td>
                <td align="right" width="50">
                </td>
            </tr>
        </table>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="vInputName" runat="server">
                    <table cellpadding="0" cellspacing="1" class="border" style="width: 100%">
                        <tr>
                            <td class="title" colspan="2">
                                第一步：请输入您的用户名</td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                用户名：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtUserName" runat="server" MaxLength="20" CssClass="textbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                                    ErrorMessage="* 请输入用户名"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                            </td>
                            <td class="bqright">
                                <asp:Button ID="btnInputName" runat="server" CssClass="btn" Text="下一步" OnClick="btnInputName_Click" /></td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="vQuestion" runat="server">
                    <table cellpadding="0" cellspacing="1" class="border" style="width: 100%">
                        <tr>
                            <td class="title" colspan="2">
                                第二步：回答密码保护问题</td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                问题：</td>
                            <td class="bqright">
                                <asp:Label ID="lbQuestion" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                                您的答案：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtAnswer" runat="server" MaxLength="20" CssClass="textbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAnswer"
                                    ErrorMessage="* 请输入答案"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td class="bqleft">
                            </td>
                            <td class="bqright">
                                <asp:Button ID="btnQuestion" runat="server" CssClass="btn" Text="下一步" OnClick="btnQuestion_Click" /></td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</body>
</html>
