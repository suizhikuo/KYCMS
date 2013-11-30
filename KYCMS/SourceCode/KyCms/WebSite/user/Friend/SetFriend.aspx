<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetFriend.aspx.cs" Inherits="User_Friend_SetFriend" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的好友</title>
    <link href="../Css/Default.css" type="text/css" rel="Stylesheet" />

    <script src="../../js/Common.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table align="center" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
            <tr>
                <td width="20">
                    <img align="absMiddle" alt="arrow" src="../images/skin/default/you.gif" /></td>
                <td>
                    您现在的位置：<a href="../welcome.aspx">用户后台</a> &gt;&gt; <a href="SetFriend.aspx">我的好友</a>
                    &gt;&gt; <a href="FriendGroup.aspx">好友分组</a>
                </td>
                <td align="right" width="50">
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" class="wzlist" width="99%" align="center">
            <tr>
                <td>
                    <asp:Panel ID="pnlGroup" runat="server">                    
                    </asp:Panel>
                </td>
                
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" width="99%" align="center"
            style="display: none;" id="AddNewFriend">
            <tr>
                <td>
                    请输入对方名称:<asp:TextBox ID="txtUserName" runat="server" CssClass="textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                        Display="Dynamic" ErrorMessage="* 请输入对方名称"></asp:RequiredFieldValidator>
                    将此好友加入:<asp:DropDownList ID="ddlUserGroup" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="btnAdd" runat="server" Text="加为好友" CssClass="btn" OnClick="btnAdd_Click" /></td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" align="center" width="99%" class="border">
            <asp:Repeater ID="rptFriendList" runat="server" OnItemCommand="rptFriendList_ItemCommand"
                OnItemDataBound="rptFriendList_ItemDataBound">
                <HeaderTemplate>
                    <tr class="title">
                        <td>
                            <%if (Request.QueryString["gid"] != null)
                              {
                                  if (Request.QueryString["gid"] == "2")
                                  {
                                      Response.Write("用户名称");
                                  }
                                  else
                                  {
                                      Response.Write("好友名称");
                                  }
                              }
                              else
                              {
                                  Response.Write("好友名称");
                              }
                            %>
                        </td>
                        <td>
                            常规操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td>
                            <a href='ViewFriend.aspx?fid=<%#Eval("FriendId") %>'>
                                <%#Eval("LogName") %>
                            </a>
                        </td>
                        <td>
                            <a href='ViewFriend.aspx?fid=<%#Eval("FriendId") %>'>查看资料</a>
                            <asp:LinkButton ID="lnkbtnSet" CausesValidation="false" runat="server" CommandArgument='<%#Eval("ID") %>'
                                CommandName="SetBlack" OnClientClick="return confirm('是否将此好友列入黑名单?')">列入黑名单</asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnDelete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("ID") %>'
                                CausesValidation="false">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table align="center" class="border">
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" CustomInfoSectionWidth="10%"
                        FirstPageText="首页" HorizontalAlign="Right" LastPageText="尾页" NextPageText="下一页"
                        OnPageChanging="Pager_PageChanging" PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left"
                        ShowInputBox="Never" ShowNavigationToolTip="True" Width="99%">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
    </form>
    <asp:Literal ID="LitMsg" runat="server"></asp:Literal>
</body>
</html>
