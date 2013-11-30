<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoticeList.aspx.cs" Inherits="user_Notice_NoticeList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公告列表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td>
                    您现在的位置：用户后台 >> 系统公告列表</td>
            </tr>
        </table>
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr class="title">
                        <td align="center">
                            <strong>公告标题</strong></td>
                        <td align="center">
                            <strong>发布人</strong></td>
                        <td align="center">
                            <strong>发布时间</strong></td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td align="left">
                            &nbsp <a href="ShowNotice.aspx?NoticeId=<%# Eval("NoticeId") %>"><%# Eval("Title") %></a></td>
                        <td width="80"><%# Eval("UserName") %></td>
                        <td width="100"><%# DataBinder.Eval(Container, "DataItem.AddDate", "{0:yyyy-MM-dd}") %></td>
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
    </form>
</body>
</html>
