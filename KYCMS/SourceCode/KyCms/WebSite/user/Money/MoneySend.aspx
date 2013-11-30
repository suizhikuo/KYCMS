<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MoneySend.aspx.cs" Inherits="user_Money_MoneySend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/Default.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" src="../../js/SelectMoney.js"></script>

</head>
<body onload="GetTime()">
    <form id="form1" runat="server">
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td>
                    您现在的位置：用户后台 >> 财富空间 >> 财富赠送</td>
            </tr>
        </table>
        <table width="99%" cellspacing="0" cellpadding="0" class="wzlist" align="center">
            <tr>
                <td>
                    银行帐号管理 | <a href="Recharge.aspx">充值卡充值</a> | <a href="MoneyChange.aspx">财富兑换</a>
                    | <a href="MoneySend.aspx">财富赠送</a></td>
                <td align="right" width="300">
                    <a href="RechargeRecord.aspx">充值记录明细</a> | <a href="Log.aspx">消费明细</a>  | 稿酬明细
                </td>
            </tr>
        </table>
        <!--头部结束 -->
        <table cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
            <tr>
                <td class="title" colspan="2">
                    <strong>财富赠送</strong></td>
            </tr>
            <tr class="wzlist">
                <td align="right" width="120">
                    您的财富信息：</td>
                <td height="25">
                    <font color="red">
                        <asp:Label ID="LoginName" runat="server" Text="网友"></asp:Label></font>您好：您是<font
                            color="red"><asp:Label ID="UserType" runat="server" Text="普通"></asp:Label></font>用户，您的有效期还剩余<font
                                color="red"><asp:Label ID="SpareDay" runat="server" Text="0"></asp:Label></font>，
                    您一共有<font color="red"><asp:Label ID="Money" runat="server" Text="0"></asp:Label></font><asp:Label
                        ID="GUnitName_9" runat="server" Text="个"></asp:Label>金币,<font color="red"><asp:Label
                            ID="IntegralLable" runat="server" Text="0"></asp:Label></font>点积分。<asp:TextBox ID="ExpireTime"
                                runat="server" Style="display: none"></asp:TextBox></td>
            </tr>
            <tr class="wzlist">
                <td rowspan="3" align="right" width="120">
                    进行转账操作：</td>
                <td>
                    将数量<asp:TextBox ID="ChangeValue" runat="server" Columns="4" MaxLength="4" onkeyup="value=value.replace(/[^\d]/g,'');SelectChangeValue2()">0</asp:TextBox><asp:Label
                        ID="GUnitNameLable" runat="server"></asp:Label>
                    的
                    <asp:DropDownList ID="MoneyType" runat="server" onchange="SelectMoneyType2()">
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                        <asp:ListItem Value="1">金币</asp:ListItem>
                        <asp:ListItem Value="2">积分</asp:ListItem>
                        <asp:ListItem Value="3">有效期</asp:ListItem>
                    </asp:DropDownList>
                    转账给用户
                    <asp:TextBox ID="SendUser" runat="server" onkeyup="SelectSendUser()"></asp:TextBox>
                </td>
            </tr>
            <tr class="wzlist">
                <td>
                    当前您设置将 <font color="red">
                        <asp:Label ID="SelectChangeValueLable" runat="server" Text="0"></asp:Label></font><asp:Label
                            ID="GUnitNameLable_1" runat="server" Text=""></asp:Label>转账给<font color="red"><asp:Label
                                ID="SendUserLable" runat="server" Text=""></asp:Label></font></td>
            </tr>
            <tr class="wzlist">
                <td>
                    请输入您的登录密码：<asp:TextBox ID="PassWord" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text=" 马上赠送 " OnClientClick="return isok2();"
                        CssClass="btn" OnClick="Button1_Click" /></td>
            </tr>
        </table>
    </form>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</body>
</html>
