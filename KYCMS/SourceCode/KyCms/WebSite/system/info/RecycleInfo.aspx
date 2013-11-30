<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecycleInfo.aspx.cs" Inherits="system_info_RecycleInfo" %>
<%@ Import Namespace="Ky.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Ky.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>回收站管理</title>
    <link href="../css/default.css" type="text/css" rel="Stylesheet" />

    <script src="../../js/Common.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="ChannelList.aspx">内容管理</a>
                    >> <a href="recyclechannel.aspx">回收站管理</a> >><asp:Literal ID="LitModelName" runat="server"></asp:Literal>回收站</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                    <a href="RecycleChannel.aspx">频道</a> | <a href="RecycleColumn.aspx">栏目</a> | <a href="RecycleSpecial.aspx">
                        专题</a><asp:Literal ID="LitRecycleNav" runat="server"></asp:Literal></td>
            </tr>
        </table>
        <table id="rptTable" class="border" cellpadding="0" cellspacing="1" width="99%" align="center">
            <asp:Repeater ID="rptRecycle" runat="server" OnItemCommand="rptRecycleItemCommand">
                <HeaderTemplate>
                    <tr class="title">
                        <td>
                            选择</td>
                        <td>
                            编号</td>
                        <td>
                            所属栏目</td>
                        <td>
                            标题</td>
                        <td>
                            添加时间</td>
                        <td>
                            常规操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td>
                            <asp:CheckBox ID="chkBox" runat="server" />
                        </td>
                        <td>
                            <asp:Literal ID="LitId" runat="server" Text='<%#Eval("Id") %>'></asp:Literal>
                        </td>
                        <td>
                            <%#Function.HtmlEncode(Eval("ColName")) %>
                        </td>
                        <td>
                            <%#Function.HtmlEncode(Eval("Title")) %>
                        </td>
                        <td>
                            <%#Eval("AddTime","{0:d}")%>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkbtnRestor" runat="server" CommandArgument='<%#Eval("Id")+"|"+Eval("ColId") %>'
                                CommandName="Restore" OnClientClick="return confirm('是否还原此项?');" Text="还原"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnDelete" runat="server" CommandArgument='<%#Eval("Id")+"|"+Eval("ColId") %>'
                                CommandName="Delete" OnClientClick="return confirm('是否删除此项?');" Text="删除"></asp:LinkButton>
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
                        ShowInputBox="Never" ShowNavigationToolTip="True" Width="100%">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
        <input id="chk" type="checkbox" onclick="SelectAll('chk','rptTable');" />全选
        <asp:Button ID="btnDelAll" runat="server" Text="删除所选项" CssClass="btn" OnClientClick="return confirm('是否删除所选项?')"
            OnClick="btnDelAll_Click" />
    </form>
</body>
</html>
