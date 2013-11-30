<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="user_Common_Report" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>举报</title>
    <link href="css/Default.css" rel="Stylesheet" type="text/css" /> 
</head>
<body>
    <form id="form1" runat="server">
   <table id="Tab1" runat="server" align="center" border="0" cellpadding="0" cellspacing="0"
            width="100%">
            <tr>
                <td valign="top">
                    <table border="0" cellpadding="0" cellspacing="1" class="border" align="center">
                        <tr class="wzlist">
                            <td height="25">举报信息&nbsp;&nbsp;<font color=red><asp:Literal ID="litMsg" runat="server"></asp:Literal></font>
                            </td>
                            
                        </tr>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="1" align="center" width="99%" bgcolor="white">
                        <tr bgcolor="#eef6fb">
                            <td height="35" align="right" width="100px">举报地址：
                                
                            </td>
                            <td>
                            <asp:Label ID="LbAddress" runat="server" ForeColor="red"></asp:Label>
                            </td>
                           
                        </tr>
                        <tr bgcolor="#eef6fb">
                            <td height="35" align="right">举报内容：
                            </td>
                            <td>
                                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Height="83px" Width="400px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" Text="提交内容" CssClass="btn" OnClick="btnSubmit_Click" />
        <input id="Button1" type="button" value="关闭本页" onclick="window.close()" class="btn" /></td>
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
                                请登陆后再操作 <a  href="#" onclick="javascript:window.close();">关闭</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
