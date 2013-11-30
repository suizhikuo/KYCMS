<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DictionaryList.aspx.cs" Inherits="system_website_DictionaryList" %>
<%@ Import Namespace="Ky.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>数据字典管理</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/Common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" border="0" cellpadding="1" cellspacing="0" class="wzdh" width="99%">
                <tr>
                    <td height="20" width="27">
                        &nbsp;<img alt="" height="16" src="../images/skin/default/you.gif" width="17" /></td>
                    <td>
                        您现在的位置： <a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href="DictionaryList.aspx">数据字典管理</a><asp:Literal ID="LitNav"
                            runat="server"></asp:Literal></td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="1" class="border" width="99%" align="center">
                <tr class="wzlist">
                    <td><a href="DictionaryList.aspx?id=0">返回字典首页</a></td>
                </tr>
            </table>
                        <asp:GridView ID="gvDictionary" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellSpacing="1" GridLines="None" Width="99%" DataKeyNames="ID" OnRowCancelingEdit="gvDictionary_RowCancelingEdit" OnRowDeleting="gvDictionary_RowDeleting" OnRowEditing="gvDictionary_RowEditing" OnRowUpdating="gvDictionary_RowUpdating" CssClass="border" HorizontalAlign="Center" OnRowDataBound="gvDictionary_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="选择">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkBox" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                                <asp:TemplateField HeaderText="名称">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("DicName") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                            Display="Dynamic" ErrorMessage="* 请输入名称" ValidationGroup="updata"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="LitDicName" runat="server" Text='<%#Eval("DicName") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="所属字典">
                                    <ItemTemplate>
                                        <%# SetParentName(Eval("ParentId")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="排序值">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSort" runat="server" Text='<%# Bind("Sort") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSort"
                                            Display="Dynamic" ErrorMessage="* 请输入排序值" ValidationGroup="updata"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSort"
                                            Display="Dynamic" ErrorMessage="* 您输入的排序值不正确" ValidationExpression="\d+" ValidationGroup="updata"></asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Literal ID="litSort" runat="server" Text='<%# Bind("Sort") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="常规操作" ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkbtnUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                            Text="更新" ValidationGroup="updata"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkbtnCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                            Text="取消"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="编辑"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkbtnDel" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="删除" OnClientClick="return confirm('警告：删除字典可能造成程序异常！\r\n\r\n删除此字典将同时删除子字典，是否继续？')"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="tdbg" />
                            <HeaderStyle CssClass="title" />
                            <EmptyDataTemplate>
                                <span class="error">没有数据</span>
                            </EmptyDataTemplate>
                        </asp:GridView>
           <table class="border" width="99%" cellpadding="0" cellspacing="1" align="center">
           <tr class="wzlist">
            <td>
                <input id="chk" type="checkbox" onclick="SelectAll('chk','gvDictionary')" />全选 <asp:Button ID="btnDel" runat="server" Text="删除所选项" CssClass="btn" OnClientClick="return confirm('警告：删除字典可能会导致程序异常！\r\n\r\n删除此字典将同时删除其子字典，是否继续？')" OnClick="btnDel_Click" /></td>
           </tr>
            </table>
            <table class="border" cellpadding="0" cellspacing="1" width="99%" align="center">
                <tr class="title"><td colspan="2">新增字典</td></tr>
                <tr>
                    <td class="bqleft">
                        所属字典：</td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlDictionary" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="bqleft">名称：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtNewName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewName"
                            ErrorMessage="* 请输入名称" ValidationGroup="new"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        排序值：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtNewSort" runat="server">5</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNewSort"
                            ErrorMessage="* 请输入排序值" ValidationGroup="new" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNewSort"
                            Display="Dynamic" ErrorMessage="* 排序值不正确" ValidationExpression="\d+" ValidationGroup="new"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td class="bqleft"></td>
                    <td class="bqright">
                        <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="btn" OnClick="btnAdd_Click" ValidationGroup="new" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
