<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LinkList.aspx.cs" Inherits="system_info_LinkList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Ky.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>友情链接列表</title>

    <script type="text/javascript" src="../../js/Common.js"></script>

    <link type="text/css" href="../css/default.css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="linklist.aspx">友情链接管理</a> >> 友情链接列表</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td>
                    <asp:LinkButton ID="lnkbtnAll" runat="server" OnClick="lnkbtnAll_Click">所有友情链接</asp:LinkButton>
                    | <a href="Link.aspx?action=add">添加友情链接</a></td>
                <td align="right">
                    按类型查看：<asp:DropDownList ID="ddlHeaderLinkType" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlHeaderLinkType_SelectedIndexChanged">
                    </asp:DropDownList>
                    按分类查看：<asp:DropDownList ID="ddlHeaderCategory" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlHeaderCategory_SelectedIndexChanged">
                    </asp:DropDownList></td>
            </tr>
        </table>
        <table id="rptTable" class="border" align="center" width="99%" cellpadding="0" cellspacing="1">
            <asp:Repeater ID="rptLink" runat="server" OnItemCommand="rptLinkItemCommand" OnItemDataBound="rptItemDataBound">
                <HeaderTemplate>
                    <tr class="title">
                        <td>
                            选择</td>
                        <td>
                            编号</td>
                        <td>
                            站点名称</td>
                        <td>
                            链接类型</td>
                        <td>
                            所属分类</td>
                        <td>
                            站长名称</td>
                        <td>
                            联系Email</td>
                        <td>
                            申请时间</td>
                        <td>
                            状态</td>
                        <td>
                            常规操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td>
                            <asp:CheckBox ID="chkBox" runat="server" /></td>
                        <td>
                            <asp:Literal ID="LitId" runat="server" Text='<%#Eval("LinkId") %>'></asp:Literal></td>
                        <td>
                            <a href="Link.aspx?LinkId=<%#Eval("LinkId") %>" title="修改">
                                <%#Function.HtmlEncode(Eval("SiteName").ToString()) %>
                            </a>
                        </td>
                        <td>
                            <%#Eval("LinkType").ToString()=="1"?"文字链接":"图片链接" %>
                        </td>
                        <td>
                            <%#Eval("LinkCategory") %>
                        </td>
                        <td>
                            <%#Function.HtmlEncode(Eval("OwnerName").ToString()) %>
                        </td>
                        <td>
                            <a href="mailto:<%#Eval("Email") %>" title="发送邮件"><%#Eval("Email") %></a>
                        </td>
                        <td>
                            <%#Eval("AddTime","{0:d}") %>
                        </td>
                        <td>
                            <asp:Label ID="lbStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                            <asp:Label ID="lbIsDisable" runat="server" Text='<%#Eval("IsDisable") %>'></asp:Label>
                        </td>
                        <td>
                            <a href="Link.aspx?LinkId=<%#Eval("LinkId") %>">修改</a>
                            <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClientClick="return confirm('是否删除此友情链接?')"
                                CommandArgument='<%#Eval("LinkId") %>' CommandName="Delete">删除</asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnPass" runat="server" CommandArgument='<%#Eval("LinkId") %>'
                                CommandName="Pass">通过</asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnDisable" runat="server" CommandArgument='<%#Eval("LinkId") +"|"+Eval("IsDisable")%>'
                                CommandName="Disable">停用</asp:LinkButton>
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
        <input type="checkbox" id="chk" onclick="SelectAll('chk','rptTable');" />全选
        <asp:Button ID="btnDelAll" runat="server" CssClass="btn" Text="删除所选项" OnClientClick="return confirm('是否删除所选项?')"
            OnClick="btnDelAll_Click" />
    </form>
</body>
</html>
