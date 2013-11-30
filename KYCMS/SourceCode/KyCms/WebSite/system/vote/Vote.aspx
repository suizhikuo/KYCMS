<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vote.aspx.cs" Inherits="system_news_Vote" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>投票管理</title>
    <link href="../css/default.css" rel="Stylesheet" type="text/css" />

    <script src="../../js/Common.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="Vote.aspx">投票系统</a> >> 投票列表</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                    <a href="Vote.aspx">所有投票</a> | <a href="SetVote.aspx">新增投票</a> | <a href="VoteCategory.aspx">
                        分类管理</a> |
                    <asp:LinkButton ID="lnkbtnOverdue" runat="server" CausesValidation="False" OnClick="lnkbtnOverdue_Click">过期投票</asp:LinkButton></td>
                <td align="right" width="500">
                    按分类查看：<asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                    </asp:DropDownList>&nbsp;</td>
            </tr>
        </table>
        <table id="VoteTable" cellpadding="0" cellspacing="1" class="border" style="width: 99%"
            align="center">
                <asp:Repeater ID="rptVote" runat="server" OnItemCommand="rptVote_ItemCommand">
                    <HeaderTemplate>
                        <tr class="title">
                            <td>
                                选择</td>
                            <td>
                                ID</td>
                            <td>
                                投票主题</td>
                            <td>
                                所属分类</td>
                            <td>
                                开始日期</td>
                            <td>
                                结束日期</td>
                            <td>
                                常规操作</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="tdbg" style="text-align: center;" onmouseover="this.className='tdbgmouseover'"
                            onmouseout="this.className='tdbg'">
                            <td>
                                <asp:CheckBox ID="chkBox" runat="server" />
                            </td>
                            <td>
                                <asp:Literal ID="lbId" runat="server" Text='<%#Eval("VoteSubjectId") %>'></asp:Literal>
                            </td>
                            <td>
                                <a href="ViewVote.aspx?vid=<%#Eval("VoteSubjectId") %>">
                                    <%#Eval("Subject") %>
                                </a>
                            </td>
                            <td>
                                <%#SetCategoryName(Eval("CategoryName")) %>
                            </td>
                            <td>
                                <%#Eval("StartDate","{0:d}") %>
                            </td>
                            <td>
                                <%#SetDate(Eval("EndDate"))%>
                            </td>
                            <td>
                                <a href="SetVote.aspx?ac=up&vid=<%#Eval("VoteSubjectId") %>">修改</a> <a href="ViewVote.aspx?vid=<%#Eval("VoteSubjectId") %>">
                                    查看数据</a>
                                <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("VoteSubjectId") %>'
                                    CommandName="Delete" OnClientClick="return confirm('确定删除此投票吗?')">删除</asp:LinkButton>
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
        <input id="chk" onclick="SelectAll('chk','VoteTable');" type="checkbox" />全选
        <asp:Button ID="btnDeleteSelectd" runat="server" CausesValidation="False" OnClick="btnDeleteSelectd_Click"
            OnClientClick="return confirm('是否删除所选项?')" Text="删除选中的项" CssClass="btn" />
    </form>
</body>
</html>
