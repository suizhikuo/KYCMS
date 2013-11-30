<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Card.aspx.cs" Inherits="System_user_Card" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户卡管理</title>
    <link href="../css/default.css" type="text/css" rel="Stylesheet" />

    <script src="../../JS/Common.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <!-- 头部开始 -->
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 用户管理 >> 充值卡管理
                </td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td>
                    <a href="SetCard.aspx">添加新卡</a> |
                    <asp:LinkButton ID="lnkbtnAll" runat="server" OnClick="lnkbtnAll_Click">所有卡</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lnkbtnUnused" runat="server" OnClick="lnkbtnUnused_Click">未使用的充值卡</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lnkbtnUsed" runat="server" OnClick="lnkbtnUsed_Click">已使用的充值卡</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lnkbtnOverdue" runat="server" OnClick="lnkbtnOverdue_Click">已过期的充值卡</asp:LinkButton></td>
                <td align="right">
                    每页显示：
                    <asp:TextBox ID="txtPageSize" runat="server" Style="width: 40px">20</asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPageSize"
                        Display="Dynamic" ErrorMessage="*必须是个正整数" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>条<asp:Button
                            ID="btnView" runat="server" Text="查看" OnClick="btnView_Click" CssClass="btn" /></td>
            </tr>
        </table>
        <!-- 头部结束 -->
        <asp:GridView ID="gvCardList" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
            CellSpacing="1" align="center" CssClass="border" DataKeyNames="CardAccount" GridLines="None"
            OnRowDataBound="gvCardList_RowDataBound" OnRowDeleting="gvCardList_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkBox" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="卡号">
                    <ItemTemplate>
                        <a href='<%# ViewCard(Eval("CardAccount")) %>'>
                            <%#Eval("CardAccount")%>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="已消费">
                    <ItemTemplate>
                        <asp:Label ID="lbIsUsed" runat="server" Text='<%# Bind("IsUsed") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CardPoint" HeaderText="点数" />
                <asp:BoundField DataField="CardDay" HeaderText="天数" />
                <asp:BoundField DataField="AdminName" HeaderText="操作员" />
                <asp:TemplateField HeaderText="过期日期">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("OverdueDate", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            OnClientClick="return confirm('确定要删除此项吗?')" Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="tdbg" />
            <EmptyDataTemplate>
                <asp:Label ID="lbEmptyData" runat="server" CssClass="error" Text="暂时没有数据"></asp:Label>
            </EmptyDataTemplate>
            <HeaderStyle CssClass="title" />
        </asp:GridView>
        <table width="99%" border="0" cellpadding="0" cellspacing="0" align="center" class="border">
            <tr>
                <td>
                    <asp:Panel ID="pnlpageIndex" runat="server" Width="100%">
                        <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" CustomInfoSectionWidth="10%"
                            FirstPageText="首页" HorizontalAlign="Right" LastPageText="尾页" NextPageText="下一页"
                            OnPageChanging="Pager_PageChanging" PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left"
                            ShowInputBox="Never" ShowNavigationToolTip="True" Width="100%">
                        </webdiyer:AspNetPager>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <input id="chk" type="checkbox" onclick="SelectAll('chk','gvCardList');" />全选
        <asp:Button ID="btnDeleteSelectd" runat="server" Text="删除选中的项" CausesValidation="False"
            OnClick="btnDeleteSelectd_Click" OnClientClick="return confirm('确定删除这些选项吗?')"
            CssClass="btn" />
    </form>
    <asp:Literal ID="LitMsg" runat="server"></asp:Literal>
</body>
</html>
