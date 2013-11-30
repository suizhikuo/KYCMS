<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomFormList.aspx.cs" Inherits="system_infomodel_CustomFormList" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script src="../../js/Common.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 自定义表单管理</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                    <a href="CustomForm.aspx">新增表单</a>
                </td>
            </tr>
        </table>
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <asp:Repeater ID="RepCustomForm" runat="server" OnItemCommand="repCustomForm_Delete">
                <HeaderTemplate>
                    <tr class="title">
                        <td width="66">
                            表单编号</td>
                        <td width="100">
                            表单名称</td>
                        <td width="120">
                            表名</td>
                        <td>
                            描述</td>
                        <td width="40%">
                            操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td align="center" width="66">
                            <%#Eval("CustomFormId") %>
                        </td>
                        <td align="center" width="100">
                            <a href="CustomFormInfoList.aspx?CustomFormId=<%#Eval("CustomFormId")%>" title="点击进入列表">
                                <%#Eval("FormName")%>
                            </a>
                        </td>
                        <td align="center" width="120">
                            <%#Eval("TableName") %>
                        </td>
                        <td>
                            <%#Eval("FormDesc")%>
                        </td>
                        <td align="center">
                            <a href="javascript:" onclick="WinOpenDialog('TransferCodeHtml.aspx?CustomFormId=<%#Eval("CustomFormId")%>','600','500')">HTML调用</a> | <a href="javascript:" onclick="WinOpenDialog('TransferCode.aspx?CustomFormId=<%#Eval("CustomFormId")%>','500','230')">JS调用</a> | <a href="CustomFormPreView.aspx?CustomFormId=<%#Eval("CustomFormId") %>">浏览</a> | <a href='CustomForm.aspx?CustomFormId=<%#Eval("CustomFormId") %>'>修改</a> | <a href='CustomFormFieldList.aspx?CustomFormId=<%#Eval("CustomFormId")%>'>字段列表</a>&nbsp;|&nbsp;<asp:LinkButton ID="lnkDelete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%#Eval("CustomFormId") %>' OnClientClick="return confirm('你确定要删除该自定义表单吗?')"></asp:LinkButton></a> </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
</body>
</html>
