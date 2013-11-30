<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PushInfoList.aspx.cs" Inherits="system_other_PushInfoList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>广告列表</title>
    <link href="../css/default.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="../../js/Common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="PushInfoList.aspx" > 广告管理</a> >> 广告位列表</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td>
                    <a href="setpushinfo.aspx">添加广告</a> | <a href="setpushcategory.aspx">添加广告位</a> | <a href="pushinfolist.aspx">广告列表</a> | <a href="PushCategoryList.aspx">广告位列表</a></td>
            </tr>
        </table>
        <table id="rptTable" style="width: 99%" class="border" cellpadding="0" cellspacing="1"
            align="center">
            <asp:Repeater ID="rptAdCategory" runat="server" OnItemCommand="rptItemCommand" OnItemDataBound="rptItemDataBound">
                <HeaderTemplate>
                    <tr class="title">
                        <td>
                            选择</td>
                        <td>
                            编号</td>
                        <td>
                            名称
                        </td>
                        <td>
                            所属广告位
                        </td>
                        <td>
                            类型
                        </td>
                        <td>
                            过期时间
                        </td>
                        <td>
                            显示权重
                        </td>
                        <td>
                            点击次数
                        </td>
                        <td>
                            常规操作
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseout="this.className='tdbg'" onmouseover="this.className='tdbgmouseover'">
                        <td>
                            <asp:CheckBox ID="chkBox" runat="server" />
                        </td>
                        <td>
                            <asp:Literal ID="LitId" runat="server" Text='<%#Eval("AdId") %>'></asp:Literal>
                        </td>
                        <td>
                            <a href="setpushinfo.aspx?adid=<%#Eval("AdId") %>"><%#Eval("AdName") %></a>
                        </td>
                        <td>
                            <%#SetCategoryName(Eval("CategoryName"))%>
                        </td>
                        <td>
                            <asp:Literal ID="LitType" runat="server" Text='<%#Eval("AdType") %>'></asp:Literal>
                        </td>
                        <td>
                            <%#SetDate(Eval("EndTime"))%>
                        </td>
                        <td>
                            <%#Eval("Weight") %>
                        </td>
                        <td>
                            <%#Eval("HitCount") %>
                        </td>
                        <td>
                            <a href="SetPushInfo.aspx?adid=<%#Eval("AdId") %>">修改</a>
                            <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClientClick="return confirm('是否删除此广告?')"
                                CommandArgument='<%#Eval("AdId")+"|"+Eval("CategoryId") %>' CommandName="Delete">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table class="border" cellpadding="0" cellspacing="1" align="center">
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
        <input id="chk" type="checkbox" onclick="SelectAll('chk','rptTable')" />全选<asp:Button
            ID="DeleteAll" runat="server" Text="删除所选项" CssClass="btn" OnClick="DeleteAll_Click"
            OnClientClick="return confirm('是否删除所选项?');" />
                       <br /> <br /><span class="tips">注意:在下列情况下,您需要手动刷新广告位JS:<br />·批量删除广告<br />·有已过期广告</span>
    </form>
</body>
</html>
