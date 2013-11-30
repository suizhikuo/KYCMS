<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectDictionary.aspx.cs"
    Inherits="system_infomodel_SelectDictionary" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>选择数据字典</title>
    <base target="_self">
    </base>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../../js/Common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="1" class="border" width="99%" align="center">
            <asp:Repeater ID="rptDictionary" runat="server" OnItemCommand="rptDictionary_ItemCommand">
                <HeaderTemplate>
                    <tr class="title">
                        <td>
                            ID</td>
                        <td>
                            名称</td>
                        <td>
                            选择</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td>
                            <asp:Literal ID="LitId" runat="server" Text='<%#Eval("ID") %>'></asp:Literal></td>
                        <td>
                            <a href='?ControlId=<%=Request.QueryString["ControlId"] %>&id=<%#Eval("ID") %>&TypeId=<%=Request.QueryString["TypeId"] %>' title="点击进入下一级"><%#Eval("DicName") %></a>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkbtnDel" runat="server" CommandName="Select" CommandArgument='<%#Eval("ID") %>'>选择</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table cellpadding="4" cellspacing="1" class="border" width="99%" align="center">
            <tr class="tdbg">
                <td>【<a href='?ControlId=<%=Request.QueryString["ControlId"] %>&TypeId=<%=Request.QueryString["TypeId"] %>'>返回顶级列表</a>】 【<a href='javascript:' onclick="window.close()">关 闭</a>】</td>
                
            </tr>
        </table>
    </form>
</body>
</html>
