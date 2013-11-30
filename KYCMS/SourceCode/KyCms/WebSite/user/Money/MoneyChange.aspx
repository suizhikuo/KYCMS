<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MoneyChange.aspx.cs" Inherits="user_Money_MoneyChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>财富兑换</title>
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
                    您现在的位置：用户后台 >> 财富空间 >> 财富兑换</td>
            </tr>
        </table>
        <table width="99%" cellspacing="0" cellpadding="0" class="wzlist" align="center">
            <tr>
                <td>
                    银行帐号管理 | <a href="Recharge.aspx">充值卡充值</a> | <a href="MoneyChange.aspx">财富兑换</a>
                    | <a href="MoneySend.aspx">财富赠送</a></td>
                <td align="right" width="300">
                    <a href="RechargeRecord.aspx">充值记录明细</a> | 消费明细 | 稿酬明细
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
            <tr>
                <td class="title" colspan="2">
                    <strong>财富兑换</strong></td>
            </tr>
            <tr class="wzlist">
                <td align="right" width="120">
                    您的财富信息：</td>
                <td height="25">
                    <font color="red">
                        <asp:Label ID="LoginName" runat="server" Text="网友"></asp:Label></font>您好：您是<font
                            color="red"><asp:Label ID="UserType" runat="server" Text="普通"></asp:Label></font>用户，您的有效期还剩余<font
                                color="red"><asp:Label ID="SpareDay" runat="server" Text="0"></asp:Label></font>，
                    您一共有<font color="red"><asp:Label ID="Money" runat="server" Text="0"></asp:Label></font><asp:Label ID="GUnitName_9"
                                    runat="server" Text="个"></asp:Label>金币,<font color="red"><asp:Label ID="IntegralLable" runat="server" Text="0"></asp:Label></font>点积分。<asp:TextBox
                        ID="ExpireTime" runat="server" Style="display: none"></asp:TextBox></td>
            </tr>
            <tr class="wzlist">
                <td align="right" height="25">
                    当前兑换汇率：</td>
                <td>
                    <font color="red">
                        <asp:Label ID="UserIntegral_2" runat="server" Text="0"></asp:Label></font><asp:Label
                            ID="GUnitName_2" runat="server" Text="点"></asp:Label>积分可兑换<font color="red"><asp:Label
                                ID="UserYellowBoy_2" runat="server" Text="0"></asp:Label></font><asp:Label ID="GUnitName"
                                    runat="server" Text="个"></asp:Label>金币。<br />
                    <font color="red">
                        <asp:Label ID="UserIntegral_1" runat="server" Text="0"></asp:Label></font>点积分可以兑换<font
                            color="red"><asp:Label ID="UserExpireDay_2" runat="server" Text="0"></asp:Label></font>天有效期时间。<br />
                    <font color="red">
                        <asp:Label ID="UserYellowBoy_1" runat="server" Text="0"></asp:Label></font><asp:Label
                            ID="GUnitName_1" runat="server" Text="个"></asp:Label>金币可以兑换<font color="red"><asp:Label
                                ID="UserExpireDay_1" runat="server" Text="0"></asp:Label></font><asp:Label ID="GUnitName_3"
                                    runat="server" Text="天"></asp:Label>有效期时间。
                    <asp:TextBox ID="UserIntegral" runat="server" Style="display: none" Columns="2"></asp:TextBox>
                    <asp:TextBox ID="UserYellowBoy" runat="server" Style="display: none" Columns="2"></asp:TextBox>
                    <asp:TextBox ID="UserExpireDay" runat="server" Style="display: none" Columns="2"></asp:TextBox></td>
            </tr>
            <tr class="wzlist">
                <td rowspan="3" align="right">
                    进行兑换操作：</td>
                <td height="25">
                    将数量<asp:TextBox ID="ChangeValue" runat="server" Columns="5" onkeyup="value=value.replace(/[^\d]/g,'');SelectChangeValue()" MaxLength="4">0</asp:TextBox>
                    的<asp:DropDownList ID="MoneyType" runat="server" onchange="SelectMoneyType()">
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                        <asp:ListItem Value="1">金币</asp:ListItem>
                        <asp:ListItem Value="2">积分</asp:ListItem>
                        <asp:ListItem Value="3">有效期</asp:ListItem>
                    </asp:DropDownList>
                    转换成
                    <asp:DropDownList ID="MoneyType1" runat="server" onchange="SelectMoneyType1()">
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                        <asp:ListItem Value="1">金币</asp:ListItem>
                        <asp:ListItem Value="2">积分</asp:ListItem>
                        <asp:ListItem Value="3">有效期</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="wzlist">
                <td height="25">
                    当前您设置将 <font color="red">
                        <asp:Label ID="ChangeValueLable" runat="server" Text="0"></asp:Label></font><asp:Label
                            ID="GUnitNameLabel" runat="server"></asp:Label><font color="red"><span id="MoneyTypeDiv_1"></span></font>转换成<font
                                color="red"><asp:Label ID="ChangeVlaueLable2" runat="server" Text="0"></asp:Label></font><asp:Label
                                    ID="GUnitNameLabel2" runat="server" Text=""></asp:Label><font color="red"><span id="MoneyTypeDiv_2"></span></font>
                </td>
            </tr>
            <tr class="wzlist">
                <td height="25">
                    请输入您的登录密码：<asp:TextBox ID="PassWord" runat="server" TextMode="Password"></asp:TextBox>&nbsp;
                    <asp:Button ID="Button1" runat="server" Text=" 开始兑换 " CssClass="btn" OnClientClick="return isok();" OnClick="Button1_Click" /></td>
            </tr>
        </table>
    </form>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</body>
</html>
