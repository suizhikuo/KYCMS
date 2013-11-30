<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="user_Feedback" %>

<%@ Import Namespace="Ky.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看问答</title>
    <link href="css/Default.css" rel="Stylesheet" type="text/css" />

    <script src="../js/Common.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table align="center" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
            <tr>
                <td width="20">
                    <img align="absMiddle" src="images/skin/default/you.gif" /></td>
                <td>
                    您现在的位置：<a href="welcome.aspx">用户后台</a> &gt;&gt; 查看问答</td>
                <td align="right" width="50">
                </td>
            </tr>
        </table>
        <table align="center" cellpadding="0" cellspacing="0" class="wzlist" width="99%">
            <tr>
                <td>
                    <a href="MyFeedback.aspx">我的问答</a> | <a href="AddFeedback.aspx">提问</a>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" align="center">
            <tr class="title">
                <td colspan="2">
                    <asp:Literal ID="LitPostTitle" runat="server"></asp:Literal>
                    （<img src="../images/reward.gif" />悬赏分：<asp:Literal ID="LitReward" runat="server"></asp:Literal>）</td>
            </tr>
            <tr>
                <td class="bqright" style="width: 150px;">
                    <table>
                        <tr>
                            <td>
                                <strong>您自己</strong>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="LitPostAuthorGroup" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="LitPostDate" runat="server"></asp:Literal>
                                <asp:Button ID="btnEnd" runat="server" CausesValidation="False" CssClass="btn" OnClick="btnEnd_Click"
                                    Text="结贴" /></td>
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
                                        <img src="../images/reward.gif" />得分：<%#Eval("Scoring") %></td>
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
        <asp:Panel ID="replyPanel" runat="server" Width="100%">
            <table cellpadding="0" cellspacing="1" class="border" align="center">
                <tr>
                    <td class="bqright">
                        我要回复:
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox TextMode="multiLine" MaxLength="2000" ID="txtReply" runat="server" Height="100px"
                            Width="414px" CssClass="textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReply"
                            ErrorMessage="* 内容不能为空"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnOk" runat="server" Text="发表回复" CssClass="btn" OnClick="btnOk_Click" />
                        <input id="Reset1" class="btn" type="reset" value="重置" /></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="UserTable" runat="server" Visible="false" Width="100%">
            <table align="center" cellpadding="0" cellspacing="1" class="border">
                <tr class="title">
                    <td colspan="2">
                        请给回复者加分(可用分：<asp:Literal ID="LitAddReward" runat="server"></asp:Literal>)</td>
                </tr>
                <asp:Repeater ID="rptIntegral" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="bqleft">
                                <asp:Literal ID="LitReplyId" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Literal><asp:Literal
                                    ID="LitReplyAuthor" runat="server" Text='<%#Eval("author") %>'></asp:Literal>：
                            </td>
                            <td class="bqright">
                                <asp:TextBox ID="txtIntegral" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td class="bqleft">
                    </td>
                    <td class="bqright">
                        <asp:Button ID="btnOver" runat="server" Text="完成" CssClass="btn" OnClick="btnOver_Click" /></td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
