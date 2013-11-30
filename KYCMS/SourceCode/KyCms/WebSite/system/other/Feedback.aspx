<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="system_Feedback" %>
<%@ Import Namespace="Ky.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=Title %>
    </title>
    <link href="../css/Default.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table align="center" cellpadding="0" cellspacing="1" class="wzdh" width="99%">
            <tr>
                <td width="20">
                    <img align="absMiddle" src="../images/skin/default/you.gif" /></td>
                <td align="left" style="padding-top: 3px">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href="../other/NoticeList.aspx">用户管理</a> &gt;&gt; 查看问答</td>
                <td align="right" width="50">
                    <img align="absMiddle" src="../images/skin/default/help.gif" /></td>
            </tr>
        </table>
        <table align="center" cellpadding="0" cellspacing="1" class="border" width="99%">
            <tr class="wzlist">
                <td align="left">
                    <a href="FeedbackList.aspx">所有问答</a>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" align="center">
            <tr class="title">
                <td colspan="2">
                    <asp:Literal ID="LitPostTitle" runat="server"></asp:Literal>
                    （<img src="../../images/reward.gif" />悬赏分：<asp:Literal ID="LitReward" runat="server"></asp:Literal>）</td>
            </tr>
            <tr>
                <td class="bqright" style="width: 150px;">
                    <table>
                        <tr>
                            <td>
                                作者：<asp:Literal ID="LitPostAuthor" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                用户组：<asp:Literal ID="LitPostAuthorGroup" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                发表日期：<asp:Literal ID="LitPostDate" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                IP：<asp:Literal ID="LitIp" runat="server"></asp:Literal></td>
                        </tr>
                    </table>
                </td>
                <td class="bqright">
                    <asp:Literal ID="LitContent" runat="server"></asp:Literal>
                </td>
            </tr>
            <asp:Repeater ID="rptFeedback" runat="server" OnItemCommand="rptFeedback_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td class="bqright" style="width: 150px;">
                            <table>
                                <tr>
                                    <td>
                                        作者：<%# Eval("author") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        用户组：<%#SetUserGroup(Eval("author"))%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        回复时间:<%#Eval("replyDate") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        IP：<%#Eval("Ip") %></td>
                                </tr>
                                <tr>
                                    <td>
                                       <img src="../../images/reward.gif" />得分：<%#Eval("Scoring") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/del.gif" /><asp:LinkButton ID="lnkbtnDel" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="Del" OnClientClick="return confirm('是否删除此回复？')">删除</asp:LinkButton></td>
                                </tr>
                            </table>
                        </td>
                        <td class="bqright">
                            <%# Function.HtmlEncode(Eval("content").ToString())%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table align="center" cellpadding="0" cellspacing="1" class="border" width="99%">
            <tr class="title">
                <td align="center" colspan="2">
                    <strong>设置</strong></td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    设置处理状态：</td>
                <td class="bqright">
                    <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="0">问答中</asp:ListItem>
                        <asp:ListItem Value="1">已完成</asp:ListItem>
                        <asp:ListItem Value="2">锁定</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Button ID="btnSetState" runat="server" Text="设置" CssClass="btn" OnClick="btnSetState_Click"
                        CausesValidation="False" /></td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    修改分类：</td>
                <td class="bqright">
                    从当前分类:<asp:Literal ID="LitCategory" runat="server"></asp:Literal>
                    移动到 <asp:DropDownList ID="ddlCategory" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="btnSetTrans" runat="server" Text="设置" CssClass="btn" CausesValidation="False"
                        OnClick="btnSetTrans_Click" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
