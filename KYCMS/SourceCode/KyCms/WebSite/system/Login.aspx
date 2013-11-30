<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="System_Login"
    EnableEventValidation="false" %>
   <%@ Import Namespace="Ky.Common" %> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理员登陆</title>
    <link href="css/default.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" src="../JS/Common.js"></script>

    <script type="text/javascript">
      
   var currFrame;
    function SetFrame(val)
    {
       if(val.parent!=val)
       {
            SetFrame(val.parent);
       }
       else
       {
            currFrame = val;
       }
    }
    SetFrame(this);
    if(currFrame!=window)
    {
        currFrame.location.href='<%=Param.ApplicationRootPath%>/system/Login.aspx'
    } 

   function CheckValidate()
   {
        if($("txtAdminName").value.trim().length==0)
       {
           alert('用户名不能为空');
          return false; 
       }
       if($("txtAdminPass").value.trim().length==0)
       {
           alert('密码不能为空');
          return false; 
       }
        if($("txtAdminRzm")!=null&&$("txtAdminRzm").value.trim().length==0)
       {
           alert('认证码不能为空');
           return false; 
       }
        if($("txtValidate").value.trim().length==0)
       {
           alert('验证码不能为空');
           return false; 
       }
       return true;
   }


    </script>

</head>
<body>
    <form id="AdminLoginFrm" runat="server">
  
        <table width="100%" cellpadding="2" cellspacing="0" border="0" height="40%">
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <table width="415" cellpadding="0" cellspacing="1" border="0" align="center" bgcolor="#3399CC">
                                    <tr>
                                        <td bgcolor="white">
                                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td>
                                                        <img src="images/logo_1.gif" /></td>
                                                </tr>
                                                <tr>
                                                    <td height="180">
                                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                            <tr>
                                                                <td background="images/logo_bg_2.gif" width="17">
                                                                </td>
                                                                <td background="images/logo_bg_1.gif" height="180" width="375">
                                                                    <table cellspacing="3" cellpadding="0" width="100%" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td width="37%" align="right">
                                                                                    <b>用户名：</b></td>
                                                                                <td colspan="2">
                                                                                    <asp:TextBox ID="txtAdminName" runat="server" Width="120px" MaxLength="20" CssClass="LoginInput">51aspx</asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <b>密 码：</b></td>
                                                                                <td colspan="2">
                                                                                    <asp:TextBox ID="txtAdminPass" runat="server" TextMode="Password" Width="120px" MaxLength="15" CssClass="LoginInput"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <%if (IsOpenRZM)
                                     {%>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <b>认证码：</b></td>
                                                                                <td colspan="2">
                                                                                    <asp:TextBox ID="txtAdminRzm" runat="server" TextMode="Password" Width="120px" MaxLength="15" CssClass="LoginInput"></asp:TextBox></td>
                                                                            </tr>
                                                                            <%} %>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <b>验证码：</b></td>
                                                                                <td width="12%" valign="middle">
                                                                                    <asp:TextBox ID="txtValidate" runat="server" CssClass="LoginInput" Width="50px"></asp:TextBox>
                                                                                </td>
                                                                                <td width="51%" valign="bottom">
                                                                                    <img src="../Common/Code.aspx" id="IMG1" runat="server" onclick="this.src='../Common/Code.aspx'"
                                                                                        alt="给我换一个" />&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="3">
                                                                                    <asp:Button ID="btnSubmit" runat="server" Text=" 登 陆 " CssClass="btn" OnClick="btnSubmit_Click"
                                                                                        OnClientClick="return  CheckValidate();" />
                                                                                    <input class="btn" type="reset" value=" 重 置 " name="submit2" id="btnReset" /></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                                <td background="images/logo_bg_2.gif" width="19">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <img src="images/logo_2.gif" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
