<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowPic.aspx.cs" Inherits="userspace_ShowPic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body onload="window.opener.location.reload()">
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" />
    </div>
    </form>
</body>
</html>
