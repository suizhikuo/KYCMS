<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewFriend.aspx.cs" Inherits="user_Friend_ViewFriend" %>

<%@ Register Src="../../common/Linkage.ascx" TagName="Linkage" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看好友</title>
    <link href="../Css/Default.css" type="text/css" rel="Stylesheet" />

    <script src="../../js/Common.js" type="text/javascript"></script>
    <script src="../../js/RiQi.js" type="text/javascript"></script>
    <script src="../../js/InfoModel.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table align="center" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
            <tr>
                <td width="20">
                    <img align="absMiddle" alt="arrow" src="../images/skin/default/you.gif" /></td>
                <td>
                    您现在的位置：<a href="../welcome.aspx">用户后台</a> &gt;&gt; <a href="SetFriend.aspx">我的好友</a>
                    &gt;&gt; 好友资料<uc1:Linkage ID="Linkage1" runat="server" />
                </td>
                <td align="right" width="50">
                </td>
            </tr>
        </table>
        <table align="center" cellpadding="0" cellspacing="0" class="wzlist" width="99%">
            <tr>
                <td>
                    <a href="SetFriend.aspx">我的好友</a> | <a href="FriendGroup.aspx">设置分组</a>
                </td>
            </tr>
        </table>
        <table cellspacing="1" cellpadding="0"  class="error" style="text-align:left" width="99%" align="center"
            runat="server" visible="false" id="InfoTable">
            <tr>
                <td>
                    对不起,该用户隐藏了自己的信息.</td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
        <asp:Literal ID="LitUserInfo" runat="server"></asp:Literal></table>
    </form>
</body>
</html>
