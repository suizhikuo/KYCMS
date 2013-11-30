<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeedbackList.aspx.cs" Inherits="system_FeedbackList" %>

<%@ Import Namespace="Ky.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的反馈</title>
    <link href="../css/Default.css" type="text/css" rel="Stylesheet" />

    <script src="../../js/Common.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table align="center" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
            <tr>
                <td>
                    <img align="absMiddle" src="../images/skin/default/you.gif" /></td>
                <td>
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href="../other/NoticeList.aspx">用户管理</a> &gt;&gt; 用户问答</td>
                <td align="right" width="50">
                    <img align="absMiddle" src="../images/skin/default/help.gif" /></td>
            </tr>
        </table>
        <table align="center" cellpadding="0" cellspacing="0" class="border" width="99%">
            <tr class="wzlist">
                <td>
                    <a href="FeedbackList.aspx"></a>
                    <asp:LinkButton ID="lnkbtnAll" runat="server" CausesValidation="False" OnClick="lnkbtnAll_Click">所有问答</asp:LinkButton>
                </td>
                <td align="right">
                    按状态查看：<asp:DropDownList ID="ddlStateHeader" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStateHeader_SelectedIndexChanged">
                        <asp:ListItem Value="-1">请选择状态</asp:ListItem>
                        <asp:ListItem Value="0">问答中</asp:ListItem>
                        <asp:ListItem Value="1">已完成</asp:ListItem>
                        <asp:ListItem Value="2">锁定</asp:ListItem>
                    </asp:DropDownList>
                    按分类查看：<asp:DropDownList ID="ddlCategoryHeader" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlCategoryHeader_SelectedIndexChanged">
                    </asp:DropDownList></td>
            </tr>
        </table>
        <table id="rptTable" class="border" cellpadding="0" cellspacing="1" align="center">
            <asp:Repeater ID="rptFeedback" runat="server" OnItemCommand="rptFeedback_ItemCommand" OnItemDataBound="rptFeedback_ItemDataBound">
                <HeaderTemplate>
                    <tr class="title">
                        <td>
                            选择</td>
                        <td>
                            主题</td>
                        <td>
                            回答数
                        </td>
                        <td>
                            分类</td>
                        <td>
                            状态</td>
                        <td>
                            开始日期</td>
                        <td>
                            最后回复</td>
                        <td>
                            回复人</td>
                        <td>
                            常规操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td>
                            <asp:CheckBox ID="chkBox" runat="server" />
                            <asp:Label ID="lbId" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label></td>
                        <td>
                            <a href='Feedback.aspx?id=<%#Eval("ID") %>'>
                                <%# Function.HtmlEncode(Eval("title").ToString()) %>
                            </a>
                        </td>
                        <td>
                        <asp:Literal ID="LitReplyCount" runat="server" Text='<%#Eval("ID") %>'></asp:Literal>
                        </td>
                        <td>
                            <%#SetCategory(Eval("categoryId")) %>
                        </td>
                        <td>
                            <%#SetState(Eval("state")) %>
                        </td>
                        <td>
                            <%#Eval("replyDate","{0:d}") %>
                        </td>
                        <td>
                            <asp:Literal ID="LitLastAuthor" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="LitLastDate" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkbtnDelete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("ID") %>'
                                OnClientClick="return confirm('是否删除此问答?');">删除</asp:LinkButton></td>
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
        <table align="center" width="99%">
            <tr>
                <td>
                    <input type="checkbox" id="chk" onclick="SelectAll('chk','rptTable');" />全选
                    <asp:Button ID="btnDeleteAll" runat="server" Text="删除所选项" OnClientClick="return confirm('是否删除所选问答?');"
                        OnClick="btnDeleteAll_Click" CssClass="btn" />
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
            <tr>
                <td>
                    问题搜索：
                    <asp:DropDownList ID="ddlCategory" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlState" runat="server">
                        <asp:ListItem Value="-1">所有状态</asp:ListItem>
                        <asp:ListItem Value="0">问答中</asp:ListItem>
                        <asp:ListItem Value="1">已完成</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="btn" OnClick="btnSearch_Click" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
