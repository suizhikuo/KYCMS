<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectTemplate.aspx.cs" Inherits="System_common_SelectTemplate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>模版选择页</title>
</head>
<body scroll="no">
<div align="center">
<iframe id="frmSelect" src='SelectFile.aspx?ControlId=<%=ControlId%>&StartPath=<%=StartPath%> ' height="450" width="640" frameborder="0" marginheight="0" marginwidth="0" scrolling="auto">
</iframe>
</div>
</body>
</html>
