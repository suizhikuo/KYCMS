<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="user_Left" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>导航</title>
    <link href="css/Default.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <table cellpadding="0" cellspacing="0" id="leftTable">
        <tr>
            <td>
            </td>
            <td class="vr" rowspan="4">
            </td>
        </tr>
        <tr>
            <td><table cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="30">
                            <asp:Label ID="lbHello" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" class="redInfo" id="redInfo" runat="server"
                    visible="false">
                    <tr>
                        <td>
                            <ul>
                                <asp:Literal ID="lbRed" runat="server"></asp:Literal>
                            </ul>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" class="blueInfo" id="blueInfo" runat="server"
                    visible="false">
                    <tr>
                        <td>
                            <ul>
                                <asp:Literal ID="lbBlue" runat="server"></asp:Literal>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="UserInfo">
            <td>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                <img src="../user/images/myprofile.jpg" /></td>
                    </tr>
                    <tr>
                        <td>
                            <ul>
                                <li>所属用户组：<asp:Label ID="GroupName" runat="server"></asp:Label></li>
                                <li>最后登录时间：<asp:Label ID="lbLoingTime" runat="server" Text="Label"></asp:Label></li>
                                <li>最后登录IP：<asp:Label ID="lbLoginIp" runat="server" Text="Label"></asp:Label></li>
                                <li>金币：<asp:Label ID="YellowBoy" runat="server" Text="0"></asp:Label></li>
                                <li>积分：<asp:Label ID="Integral" runat="server" Text="0"></asp:Label></li>
                                <li>发表文章：<asp:Label ID="Label1" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;[<asp:Label
                                    ID="Label2" runat="server" Text="0"></asp:Label>
                                    条待审]</li>
                                <li>发表评论：<asp:Label ID="Label3" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;[<asp:Label
                                    ID="Label4" runat="server" Text="Label"></asp:Label>
                                    条待审]</li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="vr" rowspan="1">
            </td>
        </tr>
    </table>
</body>
</html>
