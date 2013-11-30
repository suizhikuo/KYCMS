<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SuperSearchTerm.aspx.cs"
    Inherits="system_label_SuperSearchTerm" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>生成查询条件</title>
    <base target="_self">
    </base>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../../js/SuperLabel.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" align="center" class="border" cellspacing="1" cellpadding="0">
            <tr class="tdbg">
                <td align="center">
                    主表查询字段</td>
                <td align="center">
                    从表查询字段</td>
            </tr>
            <tr class="tdbg">
                <td align="center">
                    <asp:ListBox ID="DbFieldList1" runat="server" Width="260" SelectionMode="Multiple"
                        Height="216" Rows="15"></asp:ListBox></td>
                <td align="center">
                    <asp:ListBox ID="DbFieldList2" runat="server" Width="260" SelectionMode="Multiple"
                        Height="216" Rows="15"></asp:ListBox></td>
            </tr>
            <tr>
                <td colspan="2" align="center" height="30" valign="bottom">
                    <asp:Button ID="Button1" runat="server" Text=" 设置查询条件 " CssClass="btn" OnClick="Button1_Click" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <table align="center" class="border" cellspacing="1" cellpadding="0">
                        <tr class="title">
                            <td nowrap>
                                字段名称</td>
                            <td nowrap>
                                字段类型</td>
                            <td nowrap>
                                条件约束</td>
                            <td nowrap>
                                条件对象</td>
                                <td>条件连接</td>
                            <td nowrap>
                                条件层次</td>
                        </tr>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_Move">
                            <ItemTemplate>
                                <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                    <td>
                                        <asp:TextBox ID="OrderId" runat="server" Columns="2" Text='<%#Eval("OrderId") %>'
                                            Style="display: none"></asp:TextBox><asp:Label ID="LabelFieldName" runat="server"
                                                Text='<%# Eval("FieldName") %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="LabelFieldType" runat="server" Text='<%# Eval("FieldType") %>'></asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="TermDropDownList" runat="server" SelectedValue='<%# Eval("TermDropDownList") %>'>
                                            <asp:ListItem Value="0">-请选择-</asp:ListItem>
                                            <asp:ListItem Value="1">等于</asp:ListItem>
                                            <asp:ListItem Value="2">大于</asp:ListItem>
                                            <asp:ListItem Value="3">小于</asp:ListItem>
                                            <asp:ListItem Value="4">大于等于</asp:ListItem>
                                            <asp:ListItem Value="5">小于等于</asp:ListItem>
                                            <asp:ListItem Value="6">不等于</asp:ListItem>
                                            <asp:ListItem Value="7">在</asp:ListItem>
                                            <asp:ListItem Value="8">象</asp:ListItem>
                                            <asp:ListItem Value="9">不在</asp:ListItem>
                                            <asp:ListItem Value="10">不象</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:TextBox ID="TermValue" runat="server" Columns="8" Text='<%# Eval("TermValue") %>'></asp:TextBox></td>
                                    <td>
                                        <asp:DropDownList ID="TermLink" runat="server" SelectedValue='<%# Eval("TermLink") %>'>
                                            <asp:ListItem Value="">不连接</asp:ListItem>
                                            <asp:ListItem Value=" and ">and</asp:ListItem>
                                            <asp:ListItem Value=" or ">or</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td nowrap>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="MoveUp" CommandArgument='<%#Eval("OrderId") %>'>上移</asp:LinkButton>
                                        |
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="MoveDown" CommandArgument='<%#Eval("OrderId") %>'>下移</asp:LinkButton>
                                        |
                                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Delete" CommandArgument='<%#Eval("OrderId") %>'>删除</asp:LinkButton></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" height="50" align="center">
                    <asp:Button ID="Button2" runat="server" Text=" 生成查询条件 " CssClass="btn" OnClick="Button2_Click" /></td>
            </tr>
        </table>
    </form>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</body>
</html>
