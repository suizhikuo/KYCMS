<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetMessage.aspx.cs" Inherits="userspace_SetMessage2" %>

<link type="text/css" href="skin/space.css" rel='stylesheet' />
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script type="text/javascript" src="../js/Common.js"></script>

<script type="text/javascript" src="../js/ShowTipsIframe.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发送短消息</title>
</head>
<body style="margin: 0 auto;">
    <form id="form1" runat="server">
<%--   <%if (!buser.IsLogin())
     { %>
    <script>alert('你还未登录！请先登录');hiddenIframe();</script> 
     <% }%> 
--%>        <table class="border" cellspacing="0" cellpadding="0" border="0" style="width:100%; height:100%">
            <tbody>
                <tr>
                    <td style="background-color: #879092; font-weight: 800; color: Blue;" colspan='2'>
                        <span style="margin-left: 10%; float: left; padding: 5px;">发送短消息</span><span class="fr"
                            style="margin-right: 2%"> </span>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        收件人：</td>
                    <td class="bqright">
                        <asp:TextBox ID="ReceiverName" runat="server"></asp:TextBox>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        短消息主题：</td>
                    <td class="bqright">
                        <asp:TextBox ID="Title" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        短消息内容：</td>
                    <td class="bqright">
                        <asp:TextBox ID="Content" runat="server" Rows="10" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                    </td>
                    <td class="bqright">
                        <asp:Button ID="Button1" runat="server" Text="发送" OnClick="Button1_Click"  CssClass="btn"/>
                        <asp:Button ID="Button2" runat="server" Text="存草稿" OnClick="Button2_Click"  CssClass="btn"/>
                        <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label></td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
