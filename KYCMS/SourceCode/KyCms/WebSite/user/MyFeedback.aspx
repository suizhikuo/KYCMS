<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyFeedback.aspx.cs" Inherits="user_MyFeedback" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的问答</title>
    <link href="css/Default.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table align="center" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
            <tr>
                <td width="20">
                    <img align="absMiddle" src="images/skin/default/you.gif" /></td>
                <td>
                    您现在的位置：<a href="welcome.aspx">用户后台</a> &gt;&gt; 我的问答</td>
                <td align="right" width="50">
                </td>
            </tr>
        </table>
        <table align="center" cellpadding="0" cellspacing="0" class="wzlist" width="99%">
            <tr>
                <td>
                    <a href="AddFeedback.aspx">提问</a>
                </td>
            </tr>
        </table>
        <table class="border" cellpadding="0" cellspacing="1" align="center">
            <asp:Repeater ID="rptFeedback" runat="server" OnItemDataBound="rptFeedback_ItemDataBound">
                <HeaderTemplate>
                    <tr class="title">
                        <td style="width:40%">
                            标题
                        </td>
                        <td>
                            回答数
                        </td>
                        <td>
                           状态
                        </td>
                        <td>
                            开始时间
                        </td>
                        <td>到期时间</td>
                        <td>
                            最后回复
                        </td>
                        <td>
                            最后回复时间
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td>
                           <a href='Feedback.aspx?id=<%#Eval("ID") %>'> <%#Eval("title") %></a>
                        </td>
                        <td>
                            <asp:Literal ID="LitReplyCount" runat="server" Text='<%#Eval("ID") %>'></asp:Literal>
                        </td>
                        <td>
                            <%#SetState(Eval("state")) %>
                        </td>
                        <td>
                            <%#Eval("replyDate","{0:d}") %>
                        </td>
                        <td><%#Convert.ToDateTime(Eval("endDate"))<DateTime.Now?Eval("endDate","{0:d}")+"<span style='color:red'>(已过期)</span>":Eval("endDate","{0:d}") %></td>
                        <td>
                            <asp:Literal ID="LitLastAuthor" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="LitLastDate" runat="server"></asp:Literal>
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
    </form>
</body>
</html>
