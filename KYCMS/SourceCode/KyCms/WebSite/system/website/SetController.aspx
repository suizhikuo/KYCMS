<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetController.aspx.cs" Inherits="System_website_SetController" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>设置我的控制台</title>
    <link href="../css/default.css"  type= "text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../JS/Common.js"></script> 
    <script type="text/javascript">
    function CheckValidate()
    {
       if($("txtControllerName").value.trim().length==0)
       {
           alert("链接名称必须填写");
           return false; 
       }
       if($("txtLinkURI").value.trim().length==0)
       {
           alert("链接指向必须填写");
           return false; 
       }
       if(!CheckNumber($("txtOrderNum").value.trim()))
       {
            alert("排序必须为非负整数");
            return false; 
       }
       return true;
    }       
    </script> 

</head>
<body>
 <table width="99%" border="0" cellpadding="1" cellspacing="0" class="wzdh" align="center">
 <tr>
     <td width="27" height="20">
         &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" alt="" /></td>
     <td>
         您现在的位置： <a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; 我的控制台设置</td>
 </tr>
</table>  
<form id="form1" runat="server">
<table width="99%" border="0" cellpadding="2" cellspacing="0" class="border" align="center">
    <tr>
   <td style="padding-left:3px">
       &nbsp;链接名称：<asp:TextBox ID="txtControllerName" runat="server" Width="100px"></asp:TextBox>
       链接指向：<asp:TextBox ID="txtLinkURI" runat="server" Width="250px"></asp:TextBox>
       排序：<asp:TextBox ID="txtOrderNum" runat="server" Width="30px"></asp:TextBox>
       <asp:Button ID="btnAdd" runat="server" Text="添加设置" CssClass="btn" OnClick="btnAdd_Click" OnClientClick="return CheckValidate()" />
   
   <asp:Button ID="btnSetDefault" runat="server" OnClick="btnSetDefault_Click" Text="恢复初始值设置" OnClientClick="return confirm('你确定要将控制台恢复初始值设置?');" CssClass="btn" />   
      </td> 
   </tr> 
</table>
   <asp:GridView GridLines="None"  ID="gvController" runat="server" CellSpacing="1" CssClass="border" HeaderStyle-CssClass="title" RowStyle-CssClass="tdbg" AutoGenerateColumns="False" OnRowCancelingEdit="gvController_RowCancelingEdit" OnRowEditing="gvController_RowEditing"   OnRowUpdating="gvController_RowUpdating" OnRowDeleting="gvController_RowDeleting" HorizontalAlign="Center" Width="99%" OnRowDataBound="gvController_RowDataBound">
            <Columns>
                <asp:BoundField DataField="ControllerName" HeaderText="链接名称" >
                    <ControlStyle Width="90%" />
                    <HeaderStyle Width="20%" />
                   
                </asp:BoundField>
                <asp:BoundField DataField="LinkURI" HeaderText="链接指向">
                    <ControlStyle Width="96%"  />
                    <HeaderStyle Width="48%" />
                     <ItemStyle HorizontalAlign="left" />
                </asp:BoundField>
                <asp:BoundField DataField="OrderNum" HeaderText="排序">
                    <ControlStyle Width="90%" />
                    <HeaderStyle Width="7%" />
                   
                </asp:BoundField>
                <asp:CommandField HeaderText="修改" ShowEditButton="True" EditText="编辑" UpdateText="修改" CancelText="取消">
                    <HeaderStyle Width="15%" />
                   
                </asp:CommandField>
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                   
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkBtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                            OnClientClick="return confirm('你确认删除该条设置吗?');" Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        

    </form>
    <asp:Literal ID="LitMsg" runat="server"></asp:Literal>
</body>
</html>
