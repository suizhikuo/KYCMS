<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecycleSpecial.aspx.cs" Inherits="system_news_RecycleSpeacil" %>
<%@ Import Namespace="Ky.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>专题回收站</title>
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
                        您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="ChannelList.aspx">内容管理</a> >> <a href="recyclechannel.aspx">回收站管理</a> >> 专题回收站</td>
                    <td width="50" align="right">
                        <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
                </tr>
            </table>
            <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
                <tr class="wzlist">
                    <td align="left">
                        <a href="RecycleChannel.aspx">频道</a> | <a href="RecycleColumn.aspx">栏目</a> |
                        <a href="RecycleSpecial.aspx">专题</a><asp:Literal ID="LitRecycleNav" runat="server"></asp:Literal></td>
                </tr>
            </table>
            <table id="spclTable" cellpadding="0" cellspacing="1" class="border" align="center"
                style="width: 99%">
                <asp:Repeater ID="gvSpcl" runat="server" OnItemCommand="gv_RowCommand" OnItemDataBound="gvSpcl_RowDataBound">
                    <HeaderTemplate>
                        <tr class="title">
                            <td width="30">
                                选择</td>
                            <td width="30">
                                ID</td>
                            <td>
                                专题名</td>
                            <td>
                                二级域名</td>
                            <td>
                                描述</td>
                            <td>
                                添加日期</td>
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
                                <%#Function.HtmlEncode(Eval("SpecialCName")) %>
                            </td>
                            <td>
                               <%#Function.HtmlEncode(Eval("SpecialDomain")) %>
                            </td>
                            <td>
                                <%#Function.HtmlEncode(Eval("SpecialRemark")) %>
                            </td>
                            <td>
                               <%#Eval("SpecialAddTime","{0:d}") %>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkbtnRstChnl" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ID")+"|"+Eval("ParentId") %>'
                                    CommandName="Restore" OnClientClick="return confirm('是否还原该专题?')">还原</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ID") %>'
                                    CommandName="Del" OnClientClick="return confirm('此专题以及专题下的文章都将彻底删除,是否继续?')">删除</asp:LinkButton>
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
            <input id="chk" onclick="SelectAll('chk','spclTable');" type="checkbox" />全选
            <asp:Button ID="btnDeleteSelectd" runat="server" CausesValidation="False" OnClick="btnDeleteSelectd_Click"
                OnClientClick="return confirm('是否删除所选项?')" Text="删除所选项" CssClass="btn" />
        </div>
    </form>
</body>
</html>
