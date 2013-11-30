<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowJS.aspx.cs" Inherits="system_other_ShowJS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>广告调用代码</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script src="../../js/Common.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table class="border" cellpadding="0" cellspacing="1" width="99" align="center">
            <tr class="title">
                <td>
                    调用代码</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtJscode" runat="server" Width="99%" Rows="6" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center">
                    <input id="btnCopy" class="btn" type="button" value=" 复 制 " onclick="txtJscode.focus();document.execCommand('selectall');document.execCommand('copy');window.close();" />
                    <input id="btnCancel" class="btn" type="button" value="取消" onclick="window.close();" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
