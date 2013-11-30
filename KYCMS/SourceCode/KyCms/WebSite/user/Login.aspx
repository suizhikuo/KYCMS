<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Users_Login" %>

<%@ Import Namespace="Ky.Common" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户登录</title>
    <link href="Css/Default.css" type="text/css" rel="Stylesheet" />

    <script language="javascript">
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
        currFrame.location.href='<%=Param.ApplicationRootPath%>/user/Login.aspx'
    } 
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" height="60%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td align="center">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td rowspan="3">
                            </td>
                            <td>
                                <img src="images/login_03.gif" width="192" height="68" alt="" /></td>
                            <td>
                                <img src="images/login_04.gif" width="291" height="68" alt="" /></td>
                            <td>
                                <img src="images/login_05.gif" width="57" height="68" alt="" /></td>
                            <td colspan="2" rowspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="images/login_07.gif" width="192" height="189" alt="" /></td>
                            <td background="images/login_bg.gif">
                                <table border="0" cellpadding="2" cellspacing="3" width="100%">
                                    <tbody>
                                        <tr>
                                            <td align="right" width="37%">
                                                <b>用户名：</b></td>
                                            <td colspan="2">
                                                <input id="txtUserName" maxlength="20" type="text" name="txtUserName" class="textbox" />
                                            </td>
                                        </tr>
                                        <tr style="font-weight: bold; color: #000000">
                                            <td align="right" style="height: 20px">
                                                <b>密 码：</b></td>
                                            <td colspan="2" style="height: 20px">
                                                <input id="txtPwd" maxlength="20" type="password" name="txtPwd" class="textbox" />
                                            </td>
                                        </tr>
                                        <tr id="TrValidCode" runat="server" visible="false">
                                            <td align="right" style="height: 20px">
                                                <b>验证码：</b></td>
                                            <td colspan="2">
                                                <input id="txtValidateCode" maxlength="6" type="text" name="txtValidateCode" class="textbox" style="width: 65px" />
                                                <asp:Image ID="imgCode" runat="server" ImageUrl="~/common/Code.aspx" Visible="false" onclick="this.src='../common/Code.aspx'" ToolTip="给我换一个" /></td>
                                        </tr>
                                        <tr style="font-weight: bold; color: #000000">
                                            <td align="right" style="height: 20px">
                                                记住密码：</td>
                                            <td colspan="2" style="height: 20px">
                                                <asp:DropDownList ID="rbCookie" runat="server">
                                                    <asp:ListItem Value="No">不保存</asp:ListItem>
                                                    <asp:ListItem Value="onehour">一小时</asp:ListItem>
                                                    <asp:ListItem Value="oneday">一天</asp:ListItem>
                                                    <asp:ListItem Value="oneweek">一周</asp:ListItem>
                                                    <asp:ListItem Value="onemonth">一月</asp:ListItem>
                                                    <asp:ListItem Value="oneyear">一年</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td colspan="2" height="25">
                                                <asp:Button ID="btnLogin" runat="server" Text=" 登录 " CssClass="btn" />
                                                <input id="btnReset" class="btn" name="submit2" type="reset" value=" 重置 " /></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td colspan="2">
                                                <a href="GetBackPwd.aspx">忘记密码</a>&nbsp; <a href="Reg.aspx">注册会员</a></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td>
                                <img src="images/login_09.gif" width="57" height="189" alt="" /></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <img src="images/login_10.gif" width="540" height="20" alt="" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
