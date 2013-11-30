<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModelList.aspx.cs" Inherits="system_infomodel_ModelList" %>

<html>
<head runat="server">
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/Common.js"></script>
</head>
<body>
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
        <tr>
            <td height="24" width="20">
                <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
            <td align="left" style="padding-top: 3px;">
                您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 模型管理</td>
            <td width="50" align="right">
                <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
        </tr>
    </table>
    <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
        <tr class="wzlist">
            <td align="left">
                <a href="SetInfoModel.aspx">添加模型</a> | <a href="ModelOut.aspx">导出内容模型</a> | <a href="ModelIn.aspx">导入内容模型</a></td>
            <td align="right" width="300">
            </td>
        </tr>
    </table>
    <form id="ModelListForm" runat="server">
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <asp:Repeater ID="RepModel" runat="server" OnItemCommand="repModel_Delete">
                <HeaderTemplate>
                    <tr class="title">
                        <td width="8%">
                            模型编号</td>
                        <td width="12%">
                            模块名称</td>
                        <td width="15%">
                            表名</td>
                        <td width="7%">
                            类型</td>
                        <td width="28%">
                            描述</td>
                        <td width="30%">
                            操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td align="center">
                            <%#Eval("ModelId") %>
                        </td>
                        <td align="center">
                            <%#Eval("ModelName") %>
                        </td>
                        <td align="center">
                            <%#Eval("TableName") %>
                        </td>
                        <td align="center">
                            <%#FormatIsSystem(Eval("IsSystem"))%>
                        </td>
                        <td>
                            <%#Eval("ModelDesc") %>
                        </td>
                        <td align="center" nowrap>
                        <table cellpadding=0 cellspacing=0 border=0>
                        <tr>
                            <td nowrap><a href="ModelPreView.aspx?ModelId=<%#Eval("ModelId") %>">预览</a> | <a href='SetInfoModel.aspx?ModelId=<%#Eval("ModelId") %>'>修改</a></td>
                            <td runat="server" visible='<%#FormatHidden(Eval("IsSystem")) %>' nowrap>&nbsp| <a href="javascript:" onclick="WinOpenDialog('CopyModelTable.aspx?ModelId=<%#Eval("ModelId") %>','400','160')">复制</a> | <a href='FieldList.aspx?ModelId=<%#Eval("ModelId")%>'>字段列表</a> | <asp:LinkButton ID="lnkDelete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%#Eval("ModelId") %>'
                                    OnClientClick="return confirm('你确定要删除该自定义模型吗?')"></asp:LinkButton></a>
                            </td>
                        </tr>
                        </table>

                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
</body>
</html>
