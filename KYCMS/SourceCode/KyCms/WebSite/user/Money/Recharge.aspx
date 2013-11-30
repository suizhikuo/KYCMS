<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Recharge.aspx.cs" Inherits="User_Recharge" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>充值卡充值</title>
    <link href="../Css/Default.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!--头部开始 -->
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td>
                    您现在的位置：<a href="../welcome.aspx">用户后台</a> >> 财富空间 >> 充值卡充值</td>
            </tr>
        </table>
        <table width="99%" cellspacing="0" cellpadding="0" class="wzlist" align="center">
            <tr>
                <td>
                    银行帐号管理 | <a href="Recharge.aspx">充值卡充值</a> | <a href="MoneyChange.aspx">财富兑换</a>
                    | <a href="MoneySend.aspx">财富赠送</a></td>
                <td align="right" width="300">
                    <a href="RechargeRecord.aspx">充值记录明细</a> | <a href="Log.aspx">消费明细</a> | 稿酬明细</td>
            </tr>
        </table>
        <!--头部结束 -->
        <table cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
            <tr>
                <td class="title" colspan="2">
                    充值卡充值</td>
            </tr>
            <tr>
                <td class="bqleft">
                    您登录本站的密码:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtUserPwd" runat="server" TextMode="Password" MaxLength="20" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserPwd" ErrorMessage="* 请输入密码"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="bqleft">
                    充值卡卡号:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtCardAccount" runat="server" MaxLength="15" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCardAccount"
                        ErrorMessage="* 请输入卡号"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="bqleft">
                    充值卡密码:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtCardPwd" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCardPwd" ErrorMessage="* 请输入密码"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    <td>
                        <asp:Button ID="Button1" runat="server" OnClick="btnCharge_Click" Text="给我充" CssClass="btn" />
                        <input id="Reset2" type="reset" value="重置" class="btn" /></td>
                </td>
            </tr>
        </table>
        <asp:Literal ID="LitMsg" runat="server"></asp:Literal>
    </form>
</body>
</html>
