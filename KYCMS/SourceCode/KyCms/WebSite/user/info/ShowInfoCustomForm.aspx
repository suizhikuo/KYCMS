<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowInfoCustomForm.aspx.cs"
    Inherits="user_info_ShowInfoCustomForm" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../../js/Common.js"></script>
    <script src="../../JS/RiQi.js" type="text/javascript"></script>
</head>
<body>
    <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
        <tr>
            <td width="20">
                <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
            <td>
                您现在的位置：<a href="../welcome.aspx">用户后台管理</a> >> 其他功能 >>
                查看<asp:Label ID="CustomFormName" runat="server" Text="Label"></asp:Label>信息</td>
            <td width="50" align="right">
            </td>
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
            <tr>
                <td class="bqleft"></td>
                <td class="bqright" height="50"><input
                        id="Button2" type="button" value=" 返 回 " class="btn" onclick="javascript:window.location.href='CustomFormInfoList.aspx?CustomFormId=<%=Request.QueryString["CustomFormId"] %>'" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
