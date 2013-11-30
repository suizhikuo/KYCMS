<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CopyModelTable.aspx.cs" Inherits="system_infomodel_CopyModelTable" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>快速复制自定义模型表</title>
    <base target="_self"></base>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../../js/Common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="2" cellspacing="0" border="0" width="98%" align="right">
            <tr>
                <td>
                    <table cellpadding="2" cellspacing="0" class="border" border="0" width="99%" align="center">
                        <tr class="title">
                            <td align="center" colspan="2">快速复制<asp:Label ID="ModelName" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">模型表名：</td>
                                <td>Ky_U_<asp:TextBox ID="ModelTable" runat="server"></asp:TextBox><asp:Button ID="Button3" runat="server" Text="Button" Height="0px" Width="0px" /></td>
                        </tr>
                        <tr>
                            <td height="50" align="center" colspan="2">
                                <asp:Button ID="Button1" runat="server" Text=" 确认复制 " CssClass="btn" OnClick="Button1_Click" />
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
