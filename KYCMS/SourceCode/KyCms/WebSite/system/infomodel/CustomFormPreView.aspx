<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomFormPreView.aspx.cs"
    Inherits="system_infomodel_CustomFormPreView" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../../js/Common.js"></script>
    <script src="../../JS/RiQi.js" type="text/javascript"></script>
</head>
<body>
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
        <tr>
            <td height="24" width="20">
                <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
            <td align="left" style="padding-top: 3px;">
                您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href="CustomFormList.aspx">
                    表单管理</a> &gt;&gt; 表单预览</td>
            <td width="50" align="right">
                <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
        </tr>
    </table>
    <form id="form1" runat="server"><asp:TextBox ID="FilePicPath" runat="server" Style="display: none">news</asp:TextBox>
        <table class="border" cellspacing="1" cellpadding="0" width="99%" border="0" align="center">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td width="30%" align="right" class="bqleft">
                            <%# Eval("Alias")%>：</td>
                        <td class="bqright">
                            <%# GetShowStyle(Eval("Name", "{0}"), Eval("IsNotNull", "{0}"), Eval("Type", "{0}"), Eval("Content", "{0}"), Eval("Description", "{0}"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
</body>
</html>
