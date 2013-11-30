<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserGroupModelFieldList.aspx.cs"
    Inherits="system_UserGroupModel_UserGroupModelFieldList" %>
    <%@ Import Namespace="Ky.BLL.CommonModel" %>
<%@ Import Namespace="Ky.Common" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
        <tr>
            <td height="24" width="20">
                <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
            <td align="left" style="padding-top: 3px;">
                您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="UserGroupModelList.aspx">用户注册模型列表</a>
                >> 字段列表</td>
            <td width="50" align="right">
                <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
        </tr>
    </table>
    <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
        <tr class="wzlist">
            <td align="left">
                当前用户注册模型：[<asp:Label ID="ModelName" runat="server" Text="Label"></asp:Label>] &nbsp;
                &nbsp;&nbsp; <a href="UserGroupModelField.aspx?ModelId=<%=Request.QueryString["ModelId"] %>">
                    添加字段</a> | <a href="UserGroupModelPreView.aspx?ModelId=<%=Request.QueryString["ModelId"] %>">
                        用户注册模型预览</a> | <a href="ModeldFieldHtml.aspx?ModelId=<%=Request.QueryString["ModelId"] %>">
                            生成静态Html代码</a>
            </td>
        </tr>
    </table>
    <form id="form1" runat="server">
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <tr class="title">
                <td width="10%">
                    字段名</td>
                <td width="15%">
                    字段别名</td>
                <td width="20%">
                    字段类型</td>
                <td width="10%">
                    字段级别</td>
                <td width="10%">
                    是否必填</td>
                <td width="10%">
                    排序</td>
                <td width="25%">
                    管理操作</td>
            </tr>
            <asp:Repeater ID="RepSystemModel" runat="server">
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td align="center">
                            <%#Eval("Name")%>
                        </td>
                        <td align="center">
                            <%#Eval("Alias")%>
                        </td>
                        <td align="center">
                            <%# Eval("Type","{0}")%>
                        </td>
                        <td>
                            <font color="#339900">系统</font></td>
                        <td align="center">
                            <%#Eval("IsNotNull")%>
                        </td>
                        <td>
                        </td>
                        <td align="center">
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="RepUserGroupModelField" runat="server" OnItemCommand="RepUserGroupModelField_ItemCommand">
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td align="center">
                            <%#Eval("Name")%>
                        </td>
                        <td align="center">
                            <%#Eval("Alias")%>
                        </td>
                        <td align="center">
                            <%# B_ModelField.GetFieldType(Eval("Type","{0}"))%>
                        </td>
                        <td>自定义</td>
                        <td align="center">
                            <%# Function.GetStyleTrue(Eval("IsNotNull","{0}"))%>
                        </td>
                        <td><asp:LinkButton ID="LinkButton2" runat="server" CommandName="UpMove" CommandArgument='<%# Eval("FieldId") %>'>上移</asp:LinkButton> | <asp:LinkButton ID="LinkButton3" runat="server" CommandName="DownMove" CommandArgument='<%# Eval("FieldId") %>'>下移</asp:LinkButton>
                        </td>
                        <td align="center"><a href="UserGroupModelField.aspx?FieldId=<%# Eval("FieldId") %>&ModelId=<%# Eval("ModelId") %>">修改</a> | <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" CommandArgument='<%# Eval("FieldId") %>' OnClientClick="return confirm('确定删除此字段吗?')">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
    </form>
</body>
</html>
