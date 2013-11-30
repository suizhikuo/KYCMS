<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="userspace_UserLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../user/Css/Default.css" type="text/css" rel="Stylesheet" />

<script type="text/javascript" src="../js/Common.js"></script>
<script type="text/javascript" src="../js/ShowTipsIframe.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户登录</title>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="2" cellspacing="0" style="width: 100%; border: 1px #0ff solid;
            height:100%;" background="../user/images/login_bg.gif">
            <tbody>
                <tr>
                    <td colspan='2' align="center">
                        用户登录
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <b>用户名：</b></td>
                    <td>
                        <input id="txtUserName" maxlength="20" type="text" name="txtUserName" />
                    </td>
                </tr>
                <tr style="font-weight: bold; color: #000000">
                    <td align="right">
                        <b>密 码：</b></td>
                    <td>
                        <input id="txtPwd" maxlength="20" type="password" name="txtPwd" />
                    </td>
                </tr>
                <tr id="TrValidCode" runat="server" visible="false">
                    <td align="right">
                        <b>验证码：</b></td>
                    <td>
                        <input id="txtValidateCode" maxlength="6" type="text" name="txtValidateCode" style="width: 65px" />
                        <asp:Image ID="imgCode" runat="server" ImageUrl="~/common/Code.aspx" Visible="false"
                            onclick="this.src='../common/Code.aspx'" ToolTip="给我换一个" /></td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text=" 登录 " CssClass="btn" OnClick="btnLogin_Click"
                            OnClientClick="return CheckValidate()" />
                        <input id="btnReset" class="btn" name="submit2" type="reset" value=" 重置 " /></td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td>
                        <a href="../user/GetBackPwd.aspx" target="_blank">忘记密码</a>&nbsp; <a href="../user/Reg.aspx"
                            target="_blank">注册会员</a><asp:Label ID="lbMsg" runat="server" Text=""></asp:Label></td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>

<script>
    function CheckValidate()
   {
//        if($('txtUserName').value.trim()=="")
//       {
//            alert('请输入用户名');
//            $('txtUserName').focus();
//            return false; 
//       } 
//        if($('txtPwd').value.trim()=="")
//       {
//            alert('请输入密码');
//            $('txtPwd').focus();
//            return false; 
//       } 
//        if($('txtValidateCode').value.trim()=="")
//       {
//            alert('请输入验证码');
//            $('txtValidateCode').focus();
//            return false; 
//       } 
       return true;
   } 
</script>

