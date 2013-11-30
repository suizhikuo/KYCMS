<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TagCategoryList.aspx.cs" Inherits="System_Tag_TagCategoryList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>关键字类别列表</title>
    <link href="../css/default.css" type="text/css" rel="Stylesheet" /> 
   <script type="text/javascript" src="../../JS/Common.js"></script> 
    <script type="text/javascript">
   function CheckValidate()
   {
        if($("txtName").value.trim().length==0)
       {
            alert("Tag类别名称必须填写");
            return false; 
       } 
       return true;
   }
   
    </script> 
</head>
<body>
     <table width="99%" border="0" cellpadding="1" cellspacing="2" class="wzdh" align="center">
 <tr>
     <td width="27" height="20">
         &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" alt="" /></td>
     <td>
         您现在的位置： <a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; 关键字类别管理</td>
 </tr>
</table>  
    <form id="form1" runat="server">
    <table width="99%" align="center" class="border" cellpadding="2">
        <tr>
             <td style="padding-left:3px">
                类别名称：<asp:TextBox ID="txtName" MaxLength="20" runat="server"></asp:TextBox>
                类别描述：<asp:TextBox ID="txtDesc" MaxLength="100" runat="server" Width="318px"></asp:TextBox> 
                <asp:Button ID="btnSubmit" Text="添加关键字类别" runat="server" CssClass="btn" OnClick="btnSubmit_Click" OnClientClick="return CheckValidate()" Width="100px" />
             </td>
        </tr> 
</table>
           
           <asp:GridView HorizontalAlign="Center" ID="gvTagCategory" runat="server" CellPadding="0" CellSpacing="1" CssClass="border" GridLines="None" AutoGenerateColumns="False" HeaderStyle-CssClass="title" RowStyle-CssClass="tdbg" Width="99%" OnRowEditing="gvTagCategory_RowEditing" OnRowCancelingEdit="gvTagCategory_RowCancelingEdit" OnRowUpdating="gvTagCategory_RowUpdating" OnRowDeleting="gvTagCategory_RowDeleting" OnRowDataBound="gvTagCategory_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="类别编号">
                    <HeaderStyle Width="15%" />
                    <ItemTemplate>
                        <%# Eval("TagCategoryId") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="类别名称">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' MaxLength="20" Width="96%"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle Width="20%" />
                    <ItemTemplate>
                        <%# Eval("Name") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="类别描述">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDesc" runat="server" Text='<%# Bind("Desc") %>' MaxLength="100" Width="96%"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle Width="40%" />
                    <ItemTemplate>
                        <%# Eval("Desc") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="修改" ShowEditButton="True" EditText="编辑" UpdateText="修改" CancelText="取消">
                    <HeaderStyle Width="15%" />
                </asp:CommandField>
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkBtnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="删除" OnClientClick="return confirm('你确认要删除该关键字类别吗?');"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="tdbg" />
            <HeaderStyle CssClass="title" />
        </asp:GridView>  
            
    </form>
   <asp:Literal ID="LitMsg" runat="server"></asp:Literal> 
</body>
</html>
