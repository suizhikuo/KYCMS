<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetColumn.aspx.cs" Inherits="system_collection_SetColumn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>选择栏目</title>
	<link rel="stylesheet" type="text/css" href="../css/default.css" />
	<script language="javascript" type="text/javascript">
		function setValue(id,name)
		{
			window.opener.document.all.hidColumnId.value=id;
			window.opener.document.all.txtColumnId.value=name;
			window.close();			
		}
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:TreeView ID="tvNav" runat="server" ExpandDepth="1" ShowLines="True" EnableViewState="false">
            </asp:TreeView>		    
    </div>
    </form>
</body>
</html>
