<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetSpecialInfo.aspx.cs" Inherits="system_info_SetSpecialInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>内容所属专题设置</title>
    <link href="../css/default.css" rel="Stylesheet" type="text/css" />
    <base target=_self />  
</head>
<body>
    <form id="form1" runat="server">
   <div align=center>
        <asp:ListBox ID="lsBoxSpeacil" runat="server" Height="234px" Rows="5" SelectionMode="Multiple"
            Width="335px"></asp:ListBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" OnClick="btnSubmit_Click"
            Text="设置所属专题" Width="119px" />
        <input id="btnClear" type="button" value="清除选择" style="width: 56px" class="btn"  onclick="ClearSelected()" /> 
        <input id="btnClose" type="button" value="关闭" style="width: 56px" class="btn"  onclick="CloseWindow()" />
</div> 
    </form>
</body>
</html>
<script type="text/javascript">
function CloseWindow()
{
    window.opener = null;
    window.close(); 
    dialogArguments.location.reload();
     
}
function ClearSelected()
{
   
    document.getElementById("lsBoxSpeacil").selectedIndex = -1;
  
}
</script>