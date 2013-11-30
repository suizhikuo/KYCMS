<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomFormInfoList.aspx.cs"
    Inherits="system_infomodel_CustomFormInfoList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <script src="../../js/Common.js" type="text/javascript"></script>
    <script>
    function UpdateFormField(CustomFormId,FieldName,Id)
    {
        WinOpenDialog('UpdateFormField.aspx?CustomFormId='+CustomFormId+'&FieldName='+FieldName+'&Id='+Id+'','500','170')
    }
    </script>
</head>
<body>
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
        <tr>
            <td height="24" width="20">
                <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
            <td align="left" style="padding-top: 3px;">
                您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="CustomFormList.aspx">表单列表</a>
                >> <asp:Label ID="CustomFormName" runat="server" Text="Label"></asp:Label>信息列表</td>
            <td width="50" align="right">
                <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
        </tr>
    </table>
    <form id="form1" runat="server">
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <asp:Repeater ID="CustomTableRep" runat="server" OnItemDataBound="CustomTableRep_ItemDataBound" OnItemCommand="CustomTableRep_Delete">
                <HeaderTemplate>
                    <tr class="title">
                        <td>编号</td>
                        <td>用户名</td>
                        <asp:Literal ID="lit_head" runat="server"></asp:Literal>
                        <td>操作</td>
                    </tr>
                    
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td>
                            <asp:Label ID="CustomFormFieldId" runat="server" Text='<%# Eval("Id") %>'></asp:Label></td>
                        <td><%# Eval("UName") %></td>
                        <asp:Literal ID="lit_item" runat="server"></asp:Literal>
                        <td> <a href="UpdateInfoCustomForm.aspx?CustomFormId=<%=Request.QueryString["CustomFormId"] %>&Id=<%#Eval("Id") %>">修改</a> | 
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm('你确定要删除该条信息吗?')">删除</asp:LinkButton> </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" align="center" width="99%">
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" PageSize="20" HorizontalAlign="Right" PrevPageText="上一页"
                        ShowInputBox="Never" UrlPageIndexName="p" UrlPaging="True" ShowCustomInfoSection="Left"
                        Width="99%">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" align="center" width="99%" runat="server" id="SearchTable">
            <tr>
                <td><asp:Literal ID="Lit_Search" runat="server"></asp:Literal>
                    &nbsp;<asp:Button ID="Btn_Search" runat="server" Text=" 搜 索 " CssClass="btn" OnClick="Btn_Search_Click" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
