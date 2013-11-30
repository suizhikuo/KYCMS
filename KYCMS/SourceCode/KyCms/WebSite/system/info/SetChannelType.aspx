<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetChannelType.aspx.cs" Inherits="system_info_SetChannelType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>设置频道分类</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet"> 
</head>
<body>
    <form id="SetChannelType" runat="server">
    <table cellpadding="5">
    <tr>
        <td><b>设置分类：</b></td><td><asp:DropDownList ID="ddlChType" runat="server"></asp:DropDownList></td><td><asp:Button ID="btnSetChType" runat="server" Text=" 设置 " CssClass="btn" OnClick="btnSetChType_Click" /></td>
    </tr>
    </table> 
    </form>
</body>
</html>
