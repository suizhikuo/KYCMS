<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebMessageBatchDel.aspx.cs"
    Inherits="system_WebMessage_WebMessageBatchDel" %>

<%@ Register Src="top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>批量删除短消息</title>
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="WebMessageList.aspx">短消息管理</a> >> 批量删除短消息</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <uc1:top ID="Top1" runat="server" />
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0" id="Table1" runat="server">
            <tbody>
                <tr>
                    <td class="bqleft" height="40">
                        按用户批量删除短消息：</td>
                    <td class="bqright">
                        <asp:TextBox ID="AllUser" runat="server" Columns="40"></asp:TextBox>
                        <asp:Button ID="Button1"
                            runat="server" Text="删 除" CssClass="btn" OnClick="Button1_Click" onmousedown="if(confirm('您确认删除选中记录？'))document.form1.Button1.click(); else return false;"/>
                        * 可用 | 隔开，输入多个用户名</td>
                </tr>
                <tr>
                    <td class="bqleft" height="40">
                        按日期批量删除短消息：</td>
                    <td class="bqright">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="1">一天前</asp:ListItem>
                            <asp:ListItem Value="3">三天前</asp:ListItem>
                            <asp:ListItem Value="3">一星期前</asp:ListItem>
                            <asp:ListItem Value="30">一个月前</asp:ListItem>
                            <asp:ListItem Value="60">两个月前</asp:ListItem>
                            <asp:ListItem Value="180">半年前</asp:ListItem>
                            <asp:ListItem Value="0">所有短消息</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="Button2" runat="server"
                            Text="删 除" CssClass="btn" onmousedown="if(confirm('您确认删除选中记录？'))document.form1.Button2.click(); else return false;" OnClick="Button2_Click" />
                        注意：本功能仅删除回收站短消息</td>
                </tr>
            </tbody>
        </table>
        <table width="400" align="center" class="border3" cellspacing="1" cellpadding="0" id="Table2" runat="server">
            <tr>
                <td bgcolor="#eef6fb" height="24" align="center">
                    成功删除
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                    条记录</td>
            </tr>
            <tr>
                <td height="80" align="center"><a href="WebMessageBatchDel.aspx">返回上一页</a></td>
            </tr>
        </table>
    </form>
</body>
</html>
