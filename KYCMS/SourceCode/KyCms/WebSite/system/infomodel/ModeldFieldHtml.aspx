<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModeldFieldHtml.aspx.cs"
    Inherits="system_infomodel_ModeldFieldHtml" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <script src="../../js/Common.js" type="text/javascript"></script>
</head>
<body>
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
        <tr>
            <td height="24" width="20">
                <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
            <td align="left" style="padding-top: 3px;">
                您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="ModelList.aspx">模型列表</a> >>  <a href="FieldList.aspx?ModelId=<%=Request.QueryString["ModelId"] %>">字段列表</a>
                >> 生成静态Html</td>
            <td width="50" align="right">
                <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
        </tr>
    </table>
    <form id="form1" runat="server">
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <tr class="tdbg">
                <td class="bqleft">
                    系统默认样式：
                </td>
                <td class="bqright"><asp:TextBox ID="SysModelHtml" runat="server" Rows="12" TextMode="MultiLine" Width="95%" style="display:none"></asp:TextBox>
                    <input id="Button2" type="button" value=" 复制样式 "  onclick="copyToClipboard(document.form1.SysModelHtml.value)" style="display:none" />&nbsp;
                    <input id="Button4" type="button" value=" 显示系统样式 " onclick="SysModelHtml.style.display='';Button2.style.display='';" />&nbsp;
                    <input id="Button5" type="button" value=" 隐藏系统样式 " onclick="SysModelHtml.style.display='none';Button2.style.display='none';" />
                    
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    <br />
                    自定义样式：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtModelHtml" runat="server" Rows="25" TextMode="MultiLine" Width="95%"></asp:TextBox>
            </tr>
            <tr>
                <td class="bqleft">
                <td class="bqright" height="50"><asp:Button ID="Button1" runat="server" Text=" 确 认 " OnClick="Button1_Click" />
                    &nbsp;&nbsp;
                    <input id="Reset1" type="reset" value=" 取 消 " />
                    &nbsp;&nbsp;
                    <input id="Button3" type="button" value=" 返 回 " onclick="javascript:window.location.href='FieldList.aspx?ModelId=<%=Request.QueryString["ModelId"] %>'" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
