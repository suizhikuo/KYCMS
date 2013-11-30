<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllUserGroupList.aspx.cs" Inherits="system_user_AllUserGroupList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 用户管理 >> 用户组管理</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                    <a href="GroupList.aspx">用户组管理首页</a> | <a href="UserGroup.aspx?TypeId=1">新增个人用户组</a> | <a href="UserGroup.aspx?TypeId=2">
                        新增企业用户组</a></td>
                <td align="right" width="240">
                   
                    &nbsp;</td>
            </tr>
        </table>
        <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr class="title">
                        <td width="12%">
                            用户名</td>
                        <td width="13%">最后登陆时间</td>
                        <td width="7%">登陆次数</td>
                        <td width="12%">
                            积分</td>
                        <td width="12%">
                            金币</td>
                        <td width="8%">
                            会员状态</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td width="12%">
                            <%#Eval("LogName")%>
                        </td>
                        <td width="13%">
                            <%#Eval("LastLoginTime")%>
                        </td>
                        <td width="7%">
                            <%#Eval("LoginNum")%>
                        </td>
                        <td width="12%">
                            <%#Eval("YellowBoy")%>
                        </td>
                        <td width="12%">
                            <%#Eval("Integral")%>
                        </td>
                        <td width="8%">
                            <asp:Label ID="lblislock" Text='<%#GetIsLock(Eval("IsLock"))%>' runat="server"></asp:Label></td>
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
