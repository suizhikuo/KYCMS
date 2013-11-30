<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SinglePageUrl.aspx.cs" Inherits="system_info_SinglePageUrl" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Html连接代码</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <script src="../../js/Common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="4" cellspacing="0" border="0" width="494" align="right">
            <tr>
                <td>
                    <table cellpadding="2" cellspacing="0" class="border" border="0" width="99%" align="center">
                        <tr class="title">
                            <td align="center">
                                [<asp:Label ID="FormName" runat="server" Text="Label"></asp:Label>] Html调用代码
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" Columns="50" Rows="7" TextMode="MultiLine"
                                    Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td height="30" align="center">
                                <input id="Button1" type="button" value=" 复制到剪贴板 " class="btn" onclick="copyToClipboard(document.form1.TextBox1.value)" />
                                &nbsp;
                                <input id="Button2" type="button" value=" 关闭对话框 " class="btn" onclick="window.close()" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
