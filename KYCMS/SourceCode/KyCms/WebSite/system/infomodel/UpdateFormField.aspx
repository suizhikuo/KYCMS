<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateFormField.aspx.cs"
    Inherits="system_infomodel_UpdateFormField" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改表单字段内容</title>
    <base target="_self"></base>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <script src="../../js/RiQi.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="4" cellspacing="0" border="0" width="494" align="right">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" class="border" border="0" width="99%" align="center">
                        <tr class="title">
                            <td align="center">修改<asp:Label ID="FormName" runat="server" Text="Label"></asp:Label>字段内容
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table class="border" cellspacing="1" cellpadding="0" width="99%" border="0">
                                    <tr>
                                        <td align="right" class="bqleft"><asp:Literal ID="Alias" runat="server"></asp:Literal></td>
                                        <td class="bqright"><asp:Literal ID="ShowStyle" runat="server"></asp:Literal>
                                            <%# GetShowStyle(Eval("Name", "{0}"), Eval("IsNotNull", "{0}"), Eval("Type", "{0}"), Eval("Content", "{0}"), Eval("Description", "{0}"))%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="center">
                                <asp:Button ID="Button1" runat="server" Text=" 确认提交 " CssClass="btn" OnClick="Button1_Click" />
                                
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
