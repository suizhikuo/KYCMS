<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddFeedback.aspx.cs" Inherits="user_AddFeedback" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>提问</title>
    <link href="css/Default.css" type="text/css" rel="Stylesheet" />
    <script src="../js/Common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table align="center" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
            <tr>
                <td width="20">
                    <img align="absMiddle" src="images/skin/default/you.gif" /></td>
                <td>
                    您现在的位置：<a href="welcome.aspx">用户后台</a> &gt;&gt; 提问</td>
                <td align="right" width="50">
                </td>
            </tr>
        </table>
        <table align="center" cellpadding="0" cellspacing="0" class="wzlist" width="99%">
            <tr>
                <td>
                    <a href="MyFeedback.aspx">我的问答</a>
                </td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="2" cellspacing="1" class="border" width="99%">
            <tr>
                <td class="bqleft" width="80">
                    标题：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtTitle" runat="server" Width="275px" MaxLength="100" CssClass="textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                        Display="Dynamic" ErrorMessage="*标题不能为空"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="bqleft" width="80">
                    内容：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtContent" runat="server" Height="179px" TextMode="MultiLine" Width="542px" CssClass="textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContent"
                        Display="Dynamic" ErrorMessage="*内容不能为空"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="bqleft">
                    所属分类：</td>
                <td class="bqright">
                    <asp:ListBox ID="lsbCategory" runat="server" Height="287px" Width="211px"></asp:ListBox></td>
            </tr>
            <tr>
                <td class="bqleft">
                    悬赏分：</td>
                <td class="bqright">
                    <asp:DropDownList ID="ddlReward" runat="server">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>80</asp:ListItem>
                        <asp:ListItem>100</asp:ListItem>
                    </asp:DropDownList>
                    您当前的积分：<asp:Literal ID="LitUserIntergral" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td class="bqleft">
                </td>
                <td class="bqright">
                    <asp:Button ID="btnOk" runat="server" CssClass="btn" OnClick="btnOk_Click" Text="投递" />
                    <input id="Reset1" class="btn" type="reset" value="重置" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
