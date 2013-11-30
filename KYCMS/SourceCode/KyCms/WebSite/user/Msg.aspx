<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Msg.aspx.cs" Inherits="user_Msg" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/css.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" height="60%" cellpadding="2" cellspacing="0" border="0">
            <tr>
                <td>
                    <table width="450" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="LightGrey">
                        <tr>
                            <td class="sucessbg" height="25" align="center" colspan="2">
                                <asp:Label ID="MsgTitle" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td height="140" bgcolor="#f5f5f5">
                                <table width="99%" align="center" cellpadding="2">
                                    <tr>
                                        <td width="20%" align="center">
                                            <img src="images/<%=ImgStr %>.gif" /></td>
                                        <td width="80%">
                                            <table width="98%" align="center" cellpadding="6" cellspacing="0" border="0"> 
                                                <tr>
                                                    <td style="line-height:200%"><asp:Label ID="lbMsg" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="f10">&copy;2007-2010 CopyRight kycms Inc. All Rights Reserved</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
