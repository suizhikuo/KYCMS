<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidatePwd.aspx.cs" Inherits="userspace_ValidatePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link type="text/css" href="skin/space.css" rel='stylesheet'/>
<script type="text/javascript" src="../js/Common.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnPwdOk">
        <div runat="server" id="divSpacePwd" visible="false">
            请输入空间访问密码：<asp:TextBox ID="txtspacePwd" runat="server" TextMode="Password" Width="105px"></asp:TextBox>&nbsp;<asp:Button ID="btnPwdOk" runat="server" Text="确 定"  CssClass="btn" OnClientClick="return checkSpacePwd()" OnClick="btnPwdOk_Click" />
        </div>
       <div id="divIsFriend"  visible="false" runat="server"> 对不起,此用户空间只允许好友访问!&nbsp;<a href="javascript:window.close();" >关闭窗口</a></div> 
    </form>
</body>
</html>
<script language="javascript">
function checkSpacePwd()
{
    if($('txtspacePwd').value.trim().length==0)
   {
       alert("密码必须填写");
       $('txtspacePwd').focus();
       return false; 
   } 
}
</script>