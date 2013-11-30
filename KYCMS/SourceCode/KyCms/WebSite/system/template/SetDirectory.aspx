<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetDirectory.aspx.cs" Inherits="System_TemplateList_SetDirectory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加与修改目录</title>
    <link rel="stylesheet" href="../css/default.css" type="text/css" />
    <base target="_self" />
</head>
<body style="background-color:#D4D0C8;">
    <form id="form1" runat="server">
    <div>
        <div style="height:30px; margin-top:10px;">
            <div style="margin-top:5px;" class="tl fl">&nbsp;修改的名称：</div>
            <div class="fr">
                <div><asp:Button ID="btnOk" runat="server"  Text="确 定" CssClass="btn" OnClick="btnOk_Click"/>&nbsp;&nbsp;</div>
                <div style="margin-top:5px;"><input id="btnCancel" type="button" class="btn" value="取 消" onclick="javascript:window.close();" />&nbsp;&nbsp;</div>
            </div>
        </div>
        <div class="tl"  style="margin-top:5px;">&nbsp;<asp:TextBox ID="txtFileName" runat="server" Width="480" Text='<%# fileName %>'></asp:TextBox></div>
		<asp:Literal ID="ltMsg" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
