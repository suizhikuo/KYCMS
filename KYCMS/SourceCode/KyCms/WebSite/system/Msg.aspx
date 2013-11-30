<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Msg.aspx.cs" Inherits="system_Msg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
<link href="images/msg/css.css" rel="stylesheet" type="text/css">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="60%" height="60%">
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" align="center" width="100%">
                        <tr>
                            <td>
                                <img src="images/msg/<%=ImgStr %>.gif" width="88" height="24" align="absmiddle">
                            </td>
                            <td background="images/msg/bg1.gif" width="100%">
                            </td>
                            <td width="1%">
                                <img src="images/msg/bg2.gif" border="0" /></td>
                        </tr>
                        <tr>
                            <td colspan="3" class="td-3" bgcolor="#F9F7FA">
                                <table width="99%" align="center" cellpadding="0" cellspacing="0" height="80%">
                                    <tr bgcolor="#FFFFFF">
                                        <td width="30%">
                                            <table align="right">
                                                <tr>
                                                    <td>
                                                        <font color="red"><b>操作描述：</b></font></td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <font color="red" class="f24"><b><%=FlagStr %></b></font></td>
                                                </tr>
                                                <tr>
                                                    <td height="30">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td height="130" style="line-height: 200%" width="70%">
                                            <asp:Label ID="lbMsg" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="3"></td>
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
