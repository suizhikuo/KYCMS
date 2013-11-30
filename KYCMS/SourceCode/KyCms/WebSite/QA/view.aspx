<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="QA_View" %>

<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Import Namespace="Ky.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看问答</title>
    <link href="../user/css/Default.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <table align="center" cellpadding="0" cellspacing="1" class="wzdh" width="99%">
            <tr>
                <td height="24" width="20">
                    <img align="absMiddle" src="../system/images/skin/default/you.gif" /></td>
                <td align="left" style="padding-top: 3px">
                    您现在的位置：<asp:HyperLink ID="hylnk" runat="server">网站首页</asp:HyperLink>
                    &gt;&gt; <a href="Index.aspx">问答</a> &gt;&gt; 查看问答</td>
                <td align="right" width="50">
                </td>
            </tr>
        </table>
        <table align="center" cellpadding="0" cellspacing="1" class="border" width="99%">
            <tr class="wzlist">
                <td align="left">
                    <a href="Index.aspx">所有问答</a> | <a href="../user/AddFeedback.aspx">提问</a>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" align="center">
            <tr class="title">
                <td colspan="2" align="left">
                    <asp:Image ID="imgState" runat="server" /> <asp:Literal ID="LitPostTitle" runat="server"></asp:Literal> [<asp:Literal ID="LitState" runat="server"></asp:Literal>]
                    </td>
            </tr>
            <tr class="bqright">
                <td colspan="2">
                   <img src="../images/reward.gif" /><span style="color:#FF3300">悬赏分：<asp:Literal ID="LitReward" runat="server"></asp:Literal></span></td>
            </tr>
            <tr>
                <td class="bqright" style="width: 150px;">
                    <table>
                        <tr>
                            <td>
                               <asp:Literal ID="LitPostAuthor" runat="server"></asp:Literal> 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="LitPostAuthorGroup" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="LitPostDate" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="bqright">
                    <asp:Literal ID="LitContent" runat="server"></asp:Literal>
                </td>
            </tr>
            <asp:Repeater ID="rptFeedback" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="bqright" style="width: 150px;" valign="top">
                            <table>
                                <tr>
                                    <td>
                                        <%# Eval("author") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%#SetUserGroup(Eval("author"))%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        回复时间:<%#Eval("replyDate","{0:d}") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        得分：<%#SetScroing(Eval("Scoring")) %></td>
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
        <asp:Panel ID="replyPanel" runat="server" Width="100%" Visible="false">
            <table align="center" cellpadding="0" cellspacing="1" class="border">
                <tr>
                    <td class="bqright">
                        我要回复:
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtReply" runat="server" CssClass="textbox" Height="100px" MaxLength="2000"
                            TextMode="multiLine" Width="414px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReply"
                            ErrorMessage="* 内容不能为空"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnOk" runat="server" CssClass="btn" OnClick="btnOk_Click"
                            Text="发表回复" />
                        <input id="Reset1" class="btn" type="reset" value="重置" /></td>
                </tr>
            </table>
        </asp:Panel>
    </form>
    <table align="center" cellpadding="0" cellspacing="0" class="border" style="width: 99%">
        <tr id="TrLogin" runat="server" visible="false">
            <td>
                请<a href='../user/login.aspx?ReturnUrl=<%= ReturnUrl %>'>登录</a>或<a href="../user/reg.aspx">注册新用户</a>以回复该主题</td>
        </tr>
        <tr id="TrLock" runat="server" visible="false">
            <td>
                该主题已完成或已被锁定,不能回复.</td>
        </tr>
    </table>
    <asp:Literal ID="LitMsg" runat="server"></asp:Literal>
</body>
</html>
