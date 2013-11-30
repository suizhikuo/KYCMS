<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Log.aspx.cs" Inherits="user_Log" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户日志</title>
    <link href="../css/Default.css" type="text/css" rel="Stylesheet" />
    <script src="../../js/Common.js" type="text/javascript"></script>
    <script src="../../js/RiQi.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
            <tr>
                <td width="20">
                    <img align="absMiddle" src="../images/skin/default/you.gif" /></td>
                <td>
                    您现在的位置：用户后台 &gt;&gt; 用户日志</td>
                <td align="right" width="50">
                    </td>
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
    <table align="center" cellpadding="0" cellspacing="1" class="border" width="99%">
        <tr>
            <td>
                开始日期:<asp:TextBox ID="txtStartDate" runat="server" CssClass="textbox" onblur="setday(this);" onclick="setday(this);"></asp:TextBox>&nbsp;
                结束日期:<asp:TextBox ID="txtEndDate" runat="server" CssClass="textbox" onblur="setday(this);" onclick="setday(this);"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="btn" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="1" class="border" align="center" width="99%">
        <asp:Repeater ID="rptLog" runat="server">
            <HeaderTemplate>
                <tr class="title">
                    <td>
                        编号
                    </td>
                    <td>
                        用户编号
                    </td>
                    <td>
                        用户名
                    </td>
                    <td>
                        描述
                    </td>
                    <td>
                        信息编号
                    </td>
                    <td>
                        类型
                    </td>
                    <td>
                        金币
                    </td>
                    <td>
                        日期
                    </td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tdbg" onmouseout="this.className='tdbg'" onmouseover="this.className='tdbgmouseover'">
                    <td>
                        <%#Eval("ID") %>
                    </td>
                    <td>
                        <%#Eval("UserId") %>
                    </td>
                    <td>
                        <%#Eval("UserName") %>
                    </td>
                    <td>
                        <%#Eval("Description") %>
                    </td>
                    <td>
                        <%#Eval("InfoId") %>
                    </td>
                    <td>
                        <%#SetModel(Eval("ModelType")) %>
                    </td>
                    <td>
                        <%#Eval("Point") %>
                    </td>
                    <td>
                        <%#Eval("AddTime") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
            <table class="border" align="center">
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
        <asp:Literal ID="LitMsg" runat="server"></asp:Literal>
    </form>
</body>
</html>
