<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminList.aspx.cs" Inherits="GroupManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>

    <LINK href="../css/default.css" type=text/css rel=stylesheet>
    <meta content="MSHTML 6.00.3790.4064" name="GENERATOR">
       
</head>
<body>
    
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">    
    <tr>
        <td height="24" width=20><img src="../images/skin/default/you.gif" align=absmiddle /></td>
        <td align="left" style="padding-top:3px;" >您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 管理员列表</td>
        <td width="50" align="right"><img src="../images/skin/default/help.gif" align=absmiddle /></td>
    </tr>
</table>
 <table width="99%" cellspacing="1" cellpadding="0"  class="border" align="center">
    <tr class="wzlist">
     <td align="left"><a href="AdminGroupList.aspx">管理员组列表</a> | <a href="PowerColumn.aspx">新增管理员组</a> | <a href="AdminList.aspx">管理员列表</a> | <a href="SetAdmin.aspx">新增管理员</a></td>
     <td align="right" width="300"> &nbsp;</td>
    </tr>
    </table>  
 <form runat="server" id="form1">
            <asp:GridView ID="GridViewAdminList" runat="server" AutoGenerateColumns="False"
                Width="99%" style="text-align: left" OnRowDataBound="GridViewAdminList_RowDataBound" OnRowCommand="GridViewAdminList_RowCommand" BorderStyle="Solid" CellSpacing="1" align="center" CssClass="border" GridLines="None" AllowPaging="True" OnPageIndexChanging="GridViewAdminList_PageIndexChanging" PageSize="15">
                <Columns>
                    <asp:BoundField DataField="UserId" HeaderText="ID" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UserName" HeaderText="管理员昵称" />
                    <asp:BoundField DataField="GroupName" HeaderText="所属管理组" />
                    <asp:TemplateField HeaderText="多人登陆">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblAllowMultiLogin" runat="server" Text='<%# createAllowMultiLogin(Container.DataItem) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="LastLoginIP" HeaderText="最后登陆IP" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LastLoginTime" HeaderText="最后登陆时间" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LoginTime" HeaderText="登陆次数" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href='SetAdmin.aspx?UserId=<%#Eval("UserId") %>'>修改设置</a>|<asp:LinkButton ID="linbtnDeletOne"  runat="server" Width="30px" CommandArgument='<%# Eval("UserId") %>' OnClientClick="return confirm('是否删除该管理员?')" CommandName="DeleteOne">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="title" HorizontalAlign="Center" />
                <RowStyle CssClass="tdbg" HorizontalAlign="Center" />
                <PagerStyle Font-Bold="True" Font-Overline="False" Font-Underline="True" ForeColor="Black"
                    HorizontalAlign="Center" />
            </asp:GridView>
    </form>
</body>
</html>
