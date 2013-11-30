<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetAdmin.aspx.cs" Inherits="System_AddAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>创建管理员</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <script src="../../JS/Common.js" type="text/javascript"></script>
    <script src="../../JS/XmlHttp.js" type="text/javascript"></script>
</head>
<body style="margin: 0px">
    <form id="Form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 新增管理员</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="2" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                    <a href="AdminGroupList.aspx">管理员组列表</a> | <a href="PowerColumn.aspx">新增管理员组</a>
                    | <a href="AdminList.aspx">管理员列表</a> | <a href="SetAdmin.aspx">新增管理员</a></td>
                <td align="right" width="300">
                    &nbsp;</td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" style="width: 99%;" align="center">
            <tr>
                <td class="bqleft">
                    管理员登陆名：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtAdminLoginID" runat="server"></asp:TextBox>
                    <input id="btnChk" class="btn" type="button" value="重名检测" onclick="CheckName();" /><span style="color:Red">*</span>
                    </td>
            </tr>
            <tr>
                <td class="bqleft">
                    管理员姓名：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtAdminName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="bqleft">
                    管理员密码：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtAdminPWD" runat="server" MaxLength="18" TextMode="Password" Width="125px"></asp:TextBox><span style="color:Red">*</span>
                    <asp:Label ID="lbInfo" runat="server" CssClass="tips" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td class="bqleft">
                    请重复输入密码：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtAdminPWDAG" runat="server" MaxLength="18" TextMode="Password"
                        Width="125px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="bqleft">
                    选择管理组：</td>
                <td class="bqright">
                    <asp:DropDownList ID="DDlistGroup" runat="server" Width="83px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="bqleft">
                    是否允许多人登陆：</td>
                <td class="bqright">
                    <asp:RadioButtonList ID="AllowMultiLogin" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="True">是</asp:ListItem>
                        <asp:ListItem Value="False">否</asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
            </tr>
            <tr>
            <td class="bqleft"></td>
                <td class="bqright">
                    <asp:Button ID="btnSet" runat="server" Text=" 确定 " OnClick="btnSet_Click" CssClass="btn" OnClientClick="return chkInput();" />
                    <input id="Button1" class="btn" type="button" value=" 返回 " onclick="window.history.back()" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    function chkInput()
    {
        if($("txtAdminLoginID").value=="") 
        {
             alert("登陆名不能为空");
             $("txtAdminLoginID").focus();
            return false; 
        }

        if($("txtAdminPWD").value== "") 
        {
             alert("密码不能为空");
             $("txtAdminPWD").focus();
            return false; 
        }
        if($("txtAdminPWD").value.trim().length < 6 || $("txtAdminPWDAG").value.trim().length > 18)
       {
            alert("密码最少为6位，最大为18位");
             $("txtAdminPWD").focus();
            return false; 
       }
       if($("txtAdminPWD").value.trim() != $("txtAdminPWDAG").value.trim())
       {
            alert("两次输入的密码不一致");
             $("txtAdminPWD").focus();
            return false; 
       }
       return true;
    }
    function CheckName()
    {
      var loginName = $("txtAdminLoginID").value.trim();
      if(loginName.length==0) 
      {
          alert('检测的登录名必须填写') ;
          return;
      } 

      var flag = CheckHas("../common/CheckHas.aspx",loginName,"LoginName","KyAdmin")
      if(!flag)
      {
         alert("恭喜!该登录名可以使用"); 
      }  
      else
      {
         alert("该登录名已经存在"); 
      }   
    }
</script>