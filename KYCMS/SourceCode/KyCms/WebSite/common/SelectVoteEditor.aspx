<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectVoteEditor.aspx.cs" Inherits="common_SelectVoteEditor" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>选择投票标签</title>
    <link href="../user/css/default.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
    
   function insertChar(charValue)
    {
        var oEditor = window.parent.InnerDialogLoaded() ;
	    oEditor.FCK.InsertHtml(charValue) ;
	    window.parent.Cancel() ;
    }
   </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CellPadding="2" Width="444" ItemStyle-HorizontalAlign="center" HorizontalAlign="Center">
             <ItemTemplate>
                 <div id='<%# Eval("LabelName") %>' onclick="insertChar(this.id)" style='cursor:hand;border:solid 1px #9c9c9c;text-align:center;width:100%'><%# Eval("LabelName")%></div>
             </ItemTemplate>
        </asp:DataList>
        <asp:literal id="Lit_Page" runat="server"></asp:literal>
    </form>
</body>
</html>
