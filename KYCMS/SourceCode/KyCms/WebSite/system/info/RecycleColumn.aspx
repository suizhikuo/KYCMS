<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecycleColumn.aspx.cs" Inherits="system_news_RecycleCol" %>
<%@ Import Namespace="Ky.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>栏目回收站</title>
    <link href="../css/default.css" type="text/css" rel="Stylesheet" />

    <script src="../../js/Common.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
                <tr>
                    <td height="24" width="20">
                        <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                    <td align="left" style="padding-top: 3px;">
                        您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="ChannelList.aspx">内容管理</a>
                        >> <a href="recyclechannel.aspx">回收站管理</a> >> 栏目回收站</td>
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
            <table id="gvTable" width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
                <asp:Repeater ID="gvCol" runat="server" OnItemCommand="gv_RowCommand" OnItemDataBound="gvCol_RowDataBound">
                    <HeaderTemplate>
                        <tr class="title">
                            <td width="30px">
                                选择</td>
                            <td width="30px">
                                ID</td>
                            <td>
                                名称</td>
                            <td>
                                所属频道</td>
                            <td>
                                描述</td>
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
                                <asp:Literal ID="lbId" runat="server" Text='<%#Eval("ID") %>'></asp:Literal>
                            </td>
                            <td>
                                <%#Function.HtmlEncode(Eval("ColName")) %>
                            </td>
                            <td>
                                <%#Function.HtmlEncode(Eval("ChName")) %>
                            </td>
                            <td>
                                <%#Function.HtmlEncode(Eval("Description")) %>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkbtnRstCol" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ID")+"|"+Eval("ChId")+"|"+Eval("ColParentId") %>'
                                    CommandName="Restore" OnClientClick="return confirm('是否还原该栏目?')">还原</asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnDelCol" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ID") %>'
                                    CommandName="Del" OnClientClick="return confirm('此栏目以及相关子栏目,文章都将被彻底删除,是否继续?')">删除</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table cellpadding="0" cellspacing="1" class="border" width="99%" align="center">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="Pager" runat="server" Width="100%" ShowNavigationToolTip="True"
                            ShowInputBox="Never" ShowCustomInfoSection="Left" PrevPageText="上一页" PageSize="20"
                            OnPageChanging="Pager_PageChanging" NextPageText="下一页" LastPageText="尾页" HorizontalAlign="Right"
                            FirstPageText="首页" CustomInfoSectionWidth="10%" AlwaysShow="True">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
            <input id="chk" onclick="SelectAll('chk','gvTable');" type="checkbox" />全选
            <asp:Button ID="btnDeleteSelectd" runat="server" CausesValidation="False" OnClick="btnDeleteSelectd_Click"
                OnClientClick="return confirm('是否删除所选项?')" Text="删除所选项" CssClass="btn" />
            <asp:Literal ID="LitMsg" runat="server"></asp:Literal><br />
        </div>
    </form>
</body>
</html>
