<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MoneyList.aspx.cs" Inherits="user_Money_MoneyList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>财富空间</title>
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td>
                    您现在的位置：用户后台 >> 财富空间 >>我的财富信息</td>
            </tr>
        </table>
        <table width="99%" cellspacing="0" cellpadding="0" class="wzlist" align="center">
            <tr>
                <td>
                    银行帐号管理 | <a href="Recharge.aspx">充值卡充值</a> | <a href="MoneyChange.aspx">财富兑换</a> | <a href="MoneySend.aspx">财富赠送</a></td>
                <td align="right" width="300">
                    <a href="RechargeRecord.aspx">充值记录明细</a> | <a href="Log.aspx">消费明细</a> | 稿酬明细
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
