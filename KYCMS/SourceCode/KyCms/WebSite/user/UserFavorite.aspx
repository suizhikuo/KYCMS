<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserFavorite.aspx.cs" Inherits="user_User_Favorite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>加入收藏</title>
    <link href="Css/Default.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table id="Tab1" runat="server" align="center" border="0" cellpadding="0" cellspacing="0"
            width="100%">
            <tr>
                <td valign="top">
                    <table border="0" cellpadding="0" cellspacing="1" class="border" align="center">
                        <tr class="wzlist">
                            <td height="25">添加信息到我的收藏夹
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="1" align="center" width="99%" bgcolor="white">
                        <tr bgcolor="#eef6fb">
                            <td height="35" align="right">收藏说明：
                            </td>
                            <td>
                                <asp:TextBox ID="Title" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr bgcolor="#eef6fb">
                            <td height="35" align="right">收藏地址：
                            </td>
                            <td>
                                <asp:TextBox ID="Url" runat="server" Columns="40"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" height="55">
                                <asp:Button ID="Button1" runat="server" Text="收藏该信息" CssClass="btn" OnClick="Button1_Click" />
                                &nbsp;&nbsp;
                                <input id="Button2" type="button" value="关闭本页" class="btn" onclick="window.close()" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table id="Tab2" runat="server" align="center" border="0" cellpadding="0" cellspacing="0"
            width="100%">
            <tr>
                <td valign="top">
                    <table border="0" cellpadding="0" cellspacing="1" class="border" align="center">
                        <tr class="wzlist">
                            <td height="25">错误提示
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="1" align="center" width="99%" bgcolor="white">
                        <tr bgcolor="#eef6fb">
                            <td height="130" align="center">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>  <a  href="#" onclick="javascript:window.close();">关闭</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
