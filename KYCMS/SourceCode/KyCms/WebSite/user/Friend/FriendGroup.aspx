<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FriendGroup.aspx.cs" Inherits="user_Friend_FriendGroup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>好友分组</title>
    <link href="../Css/Default.css" type="text/css" rel="Stylesheet" />

    <script src="../../js/Common.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
                <tr>
                    <td width="20">
                        <img align="absMiddle" src="../images/skin/default/you.gif" alt="arrow" /></td>
                    <td>
                        您现在的位置：<a href="../welcome.aspx">用户后台</a> &gt;&gt; <a href="SetFriend.aspx">我的好友</a>
                        &gt;&gt; 好友分组</td>
                    <td align="right" width="50">
                    </td>
                </tr>
            </table>
        </div>
        <table align="center" cellpadding="0" cellspacing="0" class="wzlist" width="99%">
            <tr>
                <td>
                    <a href="#" onclick="IsDisplay('NewGroup')">添加分组</a>
                </td>
            </tr>
        </table>
        <table id="NewGroup" cellpadding="0" cellspacing="1" class="border" width="99%" align="center"
            style="display: none">
            <tr>
                <td class="title">
                    添加分组
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtGroupName" runat="server" MaxLength="50" CssClass="textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="validateGrpName" runat="server" ErrorMessage="*"
                        Display="dynamic" ValidationGroup="AddGroup" ControlToValidate="txtGroupName"></asp:RequiredFieldValidator>
                    <asp:Button ID="btnAddGroup" runat="server" Text="添加" ValidationGroup="AddGroup"
                        CssClass="btn" OnClick="btnAddGroup_Click" />
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" align="center" width="99%">
            <tr>
                <td>
                    <asp:GridView ID="gvGroupList" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                        CellPadding="0" CellSpacing="1" CssClass="border" DataKeyNames="FriendGroupId"
                        GridLines="None" OnRowDataBound="gvGroupList_RowDataBound" OnRowCancelingEdit="gvGroupList_RowCancelingEdit"
                        OnRowDeleting="gvGroupList_RowDeleting" OnRowEditing="gvGroupList_RowEditing"
                        OnRowUpdating="gvGroupList_RowUpdating" Width="100%">
                        <RowStyle CssClass="tdbg" />
                        <HeaderStyle CssClass="title" />
                        <Columns>
                            <asp:TemplateField HeaderText="编号">
                                <ItemTemplate>
                                    <asp:Label ID="lbId" runat="server" Text='<%# Bind("FriendGroupId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="组名">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGroupName" runat="server" Text='<%# Bind("FriendGroupName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbGroupName" runat="server" Text='<%# Bind("FriendGroupName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="好友数">
                                <ItemTemplate>
                                    <asp:Label ID="lbGroupMember" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="修改" ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                        Text="更新"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="取消"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="编辑"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="删除" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnDel" runat="server" CausesValidation="False" CommandName="Delete"
                                        CommandArgument='<%#Eval("FriendGroupId") %>' OnClientClick="return confirm('删除此分组将同时删除此分组下的好友,确定删除此选项吗?')"
                                        Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lbUserId" runat="server" Text='<%# Bind("IsUserId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
    <asp:Literal ID="LitMsg" runat="server"></asp:Literal>
</body>
</html>
