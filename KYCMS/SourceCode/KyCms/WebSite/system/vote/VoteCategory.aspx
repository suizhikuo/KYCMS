<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VoteCategory.aspx.cs" Inherits="system_news_VoteCategory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>投票分类</title>
    <link href="../css/default.css" rel="Stylesheet" type="text/css" />

    <script src="../../js/Common.js" type="text/javascript"></script>

    <script type="text/javascript">
        function chkInput()
        {
            if($("txtName").value=="")
            {
                alert("分类名不能为空");
               return false; 
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
                <tr>
                    <td height="24" width="20">
                        <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                    <td align="left" style="padding-top: 3px;">
                        您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="Vote.aspx">投票管理</a> >>
                        分类管理</td>
                    <td width="50" align="right">
                        <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
                </tr>
            </table>
        </div>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td>
                    <a href="Vote.aspx">所有投票</a> | <a href="SetVote.aspx">新增投票</a> | <a href="#" onclick="IsDisplay('AddNew');">
                        新增分类</a></td>
            </tr>
        </table>
        <table id="AddNew" cellpadding="0" cellspacing="0" class="border" align="center">
            <tr>
                <td class="title" colspan="2">
                    新增投票分类</td>
            </tr>
            <tr>
                <td class="bqleft">
                    分类名：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtName" runat="server" CssClass="textbox" MaxLength="50" ValidationGroup="addGroup"></asp:TextBox><asp:Button
                        ID="btnAdd" runat="server" CssClass="btn" OnClick="btnAdd_Click" Text="添加" ValidationGroup="addGroup"
                        OnClientClick="return chkInput();" /></td>
            </tr>
        </table>
        <asp:GridView ID="gvCate" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
            CellPadding="0" CellSpacing="1" align="center" CssClass="border" DataKeyNames="CategoryId"
            EmptyDataText="暂时没有数据." GridLines="None" OnRowDataBound="gvCate_RowDataBound"
            OnRowEditing="gvCate_RowEditing" OnRowUpdating="gvCate_RowUpdating" OnRowCancelingEdit="gvCate_RowCancelingEdit"
            OnRowDeleting="gvCate_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkBox" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="编号">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="名称">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNewName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="修改" ShowEditButton="True" />
                <asp:TemplateField ShowHeader="False" HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnDel" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="删除" OnClientClick="return confirm('是否删除此分类?')" CommandArgument='<%# Eval("CategoryId") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="tdbg" />
            <HeaderStyle CssClass="title" />
        </asp:GridView>
        <input id="chk" type="checkbox" onclick="SelectAll('chk','gvCate');" />全选
        <asp:Button ID="btnDeleteAll" runat="server" CssClass="btn" OnClientClick="return confirm('是否删除所选项?')"
            Text="删除所选项" OnClick="btnDeleteAll_Click" /></form>
    <asp:Literal ID="LitMsg" runat="server"></asp:Literal>
</body>
</html>
