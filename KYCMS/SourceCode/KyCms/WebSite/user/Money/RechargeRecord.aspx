<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RechargeRecord.aspx.cs" Inherits="user_RechargeRecord" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>充值记录明细</title>
    <link href="../css/Default.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!--头部开始 -->
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td>
                    您现在的位置：<a href="../welcome.aspx">用户后台</a> >> 财富空间 >> 充值记录</td>
            </tr>
        </table>
        <table width="99%" cellspacing="0" cellpadding="0" class="wzlist" align="center">
            <tr>
                <td>
                    银行帐号管理 | <a href="Recharge.aspx">充值卡充值</a> | <a href="MoneyChange.aspx">财富兑换</a>
                    | <a href="MoneySend.aspx">财富赠送</a></td>
                <td align="right" width="300">
                    <a href="RechargeRecord.aspx">充值记录明细</a> | <a href="Log.aspx">消费明细</a> | 稿酬明细
                </td>
            </tr>
        </table>
        <!--头部结束 -->
        <table class="border" cellpadding="0" cellspacing="1" align="center">
            <asp:Repeater ID="rptRecord" runat="server">
                <HeaderTemplate>
                    <tr class="title">
                        <td>
                            用户编号</td>
                        <td>
                            卡号</td>
                        <td>
                            点数</td>
                        <td>
                            天数</td>
                        <td>
                            充值日期</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td>
                            <%#Eval("UserId") %>
                        </td>
                        <td>
                            <%#Eval("CardAccount") %>
                        </td>
                        <td>
                            <%#Eval("CardPoint") %>
                        </td>
                        <td>
                            <%#Eval("CardDay") %>
                        </td>
                        <td>
                            <%#Eval("RechargeDate") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" align="center" width="99%">
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" CustomInfoSectionWidth="10%"
                        FirstPageText="首页" HorizontalAlign="Right" LastPageText="尾页" NextPageText="下一页"
                        OnPageChanging="Pager_PageChanging" PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left"
                        ShowInputBox="Never" ShowNavigationToolTip="True" Width="99%">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
