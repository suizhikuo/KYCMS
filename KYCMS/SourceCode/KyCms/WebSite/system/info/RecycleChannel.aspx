<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecycleChannel.aspx.cs" Inherits="system_news_RecycleChnl" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Ky.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>频道回收站</title>
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
                        >> <a href="recyclechannel.aspx">回收站管理</a> >> 频道回收站</td>
                    <td width="50" align="right">
                        <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
                </tr>
            </table>
            <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
                <tr class="wzlist">
                    <td align="left">
                        <a href="RecycleChannel.aspx">频道</a> | <a href="RecycleColumn.aspx">栏目</a> | <a href="RecycleSpecial.aspx">
                            专题</a><asp:Literal ID="LitRecycleNav" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <table id="gvTable" width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
                <asp:Repeater ID="gvChnl" runat="server" OnItemCommand="gv_RowCommand" OnItemDataBound="gvChnl_RowDataBound">
                    <HeaderTemplate>
                        <tr class="title">
                            <td width="30">
                                选择</td>
                            <td width="30">
                                ID</td>
                            <td>
                                频道名称</td>
                            <td>
                                描述</td>
                            <td>
                                创建时间</td>
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
                                <%#Function.HtmlEncode(Eval("ChName")) %>
                            </td>
                            <td>
                                <%#Function.HtmlEncode(Eval("Description")) %>
                            </td>
                            <td>
                                <%#Eval("AddTime","{0:d}") %>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkbtnRstSpcl" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ID") %>'
                                    CommandName="Restore" OnClientClick="return confirm('是否还原该频道?')">还原</asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnDelSpcl" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ID") %>'
                                    CommandName="Del" OnClientClick="return confirm('此频道以及相关栏目,文章都将彻底删除,是否继续?')">删除</asp:LinkButton>
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
            <input id="chk" onclick="SelectAll('chk','gvTable');" type="checkbox" />全选
            <asp:Button ID="btnDeleteSelectd" runat="server" CausesValidation="False" OnClick="btnDeleteSelectd_Click"
                OnClientClick="return confirm('是否删除所选项?')" Text="删除所选项" CssClass="btn" />
        </div>
    </form>
</body>
</html>
