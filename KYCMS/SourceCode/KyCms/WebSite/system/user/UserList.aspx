<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="System_user_UserList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>用户列表</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/XmlHttp.js"></script>
    <script type="text/javascript" src="../../js/Common.js"></script>
</head>
<body>
    <form id="Form2" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 用户管理 >> 
                    <asp:Literal ID="LitUserType" runat="server"></asp:Literal></td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table align="center" cellpadding="0" cellspacing="1" class="border" width="99%">
            <tr class="wzlist">
                <td align="left">
                    <asp:Repeater ID="RepUserGroupModel" runat="server">
                        <ItemTemplate>
                            <a href="SetUser.aspx?TypeId=<%# Eval("Id") %>">新增<%# Eval("Name") %></a> | 
                        </ItemTemplate>
                    </asp:Repeater>
                  </td>
            </tr>
        </table>
        <table class="border" width="99%" align="center" cellpadding="1" cellspacing="1">
            <tr>
                <td>
                    用户组：<asp:DropDownList ID="ddlUserGroup" runat="server">
                    </asp:DropDownList>
                    时间：<asp:DropDownList ID="ddlLastLoginTime" runat="server">
                    <asp:ListItem Value="0">全部</asp:ListItem>
                    <asp:ListItem Value="1">三个月未登录</asp:ListItem>
                    <asp:ListItem Value="2">半年未登录</asp:ListItem>
                    <asp:ListItem Value="3">一年未登录</asp:ListItem>
                    </asp:DropDownList>
                    用户名：<asp:TextBox ID="txtSearchUserName" runat="server"></asp:TextBox>
                    <asp:Button
                        ID="btnSearch" runat="server" Text=" 搜 索 " CssClass="btn" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
        <table id="rptUserList" width="99%" align="center" class="border" cellspacing="1"
            cellpadding="0">
            <asp:Repeater ID="RepUserList" runat="server" OnItemCommand="RepUserList_ItemCommand">
                <HeaderTemplate>
                    <tr class="title">
                        <td>
                            选择</td>
                            <td><a href='UserList.aspx?TypeId=<%=Request.QueryString["TypeId"] %>&Order=UserID'><font color="white">用户Id↓</font></a></td>
                        <td>
                            用户名</td>
                        <td>
                            所属用户组</td>
                        <td>
                            最后登陆时间</td>
                        <td><a href='UserList.aspx?TypeId=<%=Request.QueryString["TypeId"] %>&Order=LoginNum'><font color="white">登录次数↓</font></a></td>
                        <td><a href='UserList.aspx?TypeId=<%=Request.QueryString["TypeId"] %>&Order=Integral'><font color="white">积分↓</font></a></td>
                        <td><a href='UserList.aspx?TypeId=<%=Request.QueryString["TypeId"] %>&Order=YellowBoy'><font color="white">金币↓</font></a></td>
                        <td>
                            会员状态</td>
                        <td>
                            常规操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td align="center">
                            <asp:CheckBox ID="cboxSelect" runat="server" />
                        </td>
                        <td><%# Eval("UserID") %></td>
                        <td>
                        <%# Eval("LogName") %>
                        <asp:Literal ID="LitId" runat="server" Text='<%#Eval("UserID") %>' Visible="false"></asp:Literal>
                        </td>
                        <td>
                            <%#Eval("UserGroupName")%>
                        </td>
                        <td>
                            <%#Eval("LastLoginTime")%>
                        </td>
                        <td>
                            <%#Eval("LoginNum")%>
                        </td>
                        <td><%#Eval("Integral")%></td>
                        <td><%#Eval("YellowBoy")%></td>
                        <td>
                            <%#Eval("IsLock").ToString()=="True"?"<span style='color:red'>锁定</span>":"正常"%>
                        </td>
                        <td>
                            <a href='SetUser.aspx?TypeId=<%# Eval("TypeId") %>&uid=<%# Eval("UserID") %>'>修改 </a>
                            <asp:LinkButton ID="linkbtnLockUser" runat="server" CommandName="Lock" CommandArgument='<%#Eval("UserID")%>'
                                Text='<%#Eval("IsLock").ToString()=="True"?"解锁":"锁定"%>'></asp:LinkButton>
                               
                               <asp:LinkButton ID="lnkStatus" runat="server" CommandName="status" CommandArgument='<%#Eval("UserId")+","+Eval("Status")%>' Text="认证" Enabled='<%#Eval("Status").ToString()=="1"?false:true %>'></asp:LinkButton> 
                            
                            <asp:LinkButton ID="lnkDelete" CommandName="Delete" CommandArgument='<%#Eval("UserID")%>'
                                runat="server" OnClientClick="return confirm('删除会员将删除此会员的部分相关资源,包括:\r\n\r\n·用户收藏\r\n·用户专栏(不包括投递的文章)\r\n·用户好友列表\r\n\r\n是否继续?')">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table cellpadding="0" cellspacing="0" align="center" width="99%" class="border">
            <tr>
                <td align="left" colspan="2">
                    <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页"  PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoSectionWidth="10%" ShowNavigationToolTip="True" Width="99%" HorizontalAlign="Right" OnPageChanging="AspNetPager_PageChanging">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
        <table cellpadding="2" cellspacing="0" border="0" width="99%" align="center">
            <tr>
                <td height="30"><input type="checkbox" id="chk" onclick="SelectAll('chk','rptUserList')" />全选
        <asp:Button ID="btnDeleteMore" runat="server" Text="删除所选项" CssClass="btn" OnClick="btnDeleteMore_Click"
            OnClientClick="return confirm('删除会员将删除此会员的部分相关资源,是否继续?')" /></td>
            </tr>
        </table>
        
    </form>
</body>
</html>
