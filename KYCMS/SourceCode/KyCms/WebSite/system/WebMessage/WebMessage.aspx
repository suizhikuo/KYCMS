<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebMessage.aspx.cs" Inherits="system_WebMessage_WebMessage" %>

<%@ Register Src="top.ascx" TagName="top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>站内短消息</title>
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../../js/RiQi.js"></script>

    <script type="text/javascript" src="../../js/Common.js"></script>

    <script>
   function isok()
   {
        var obj=document.getElementsByName("SelectUserType"); 
          for(var i=0;i<obj.length;i++)   
          {   
            if(obj[i].checked   ==   true)   
            {   
                if(obj[i].value=="3")
                {
                    if($("UserNmuber").value=="")
                    {
                        alert("请输入用户名称");
                        $("UserNmuber").focus();
                        return false;
                    }
                } 
                break;   
            } 
          }  
          
          if($("Title").value=="")
          {
            alert("请输入短消息标题")
            $("Title").focus();
            return false;
          }   
          
          if($("Content").value=="")
          {
            alert("请输入短消息内容")
            $("Content").focus();
            return false;
          }      
        return true;
   }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="WebMessageList.aspx">短消息管理</a> >> 发送短消息</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <uc1:top ID="Top1" runat="server" />
        <table width="99%" border="0" cellpadding="0" cellspacing="1" class="border" align="center">
            <tbody>
                <tr>
                    <td class="bqleft">
                        收件人：</td>
                    <td class="bqright">
                        <table cellpadding="2" cellspacing="0" border="0">
                            <tr>
                                <td nowrap>
                                    <input id="SelectUserType_0" name="SelectUserType" type="radio" value="1" checked />
                                    所有用户
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td nowrap valign="top">
                                    <input id="SelectUserType_1" name="SelectUserType" type="radio" value="2" />指定用户组</td>
                                <td valign="top">
                                    <asp:CheckBoxList ID="UserGroupList" runat="server" RepeatDirection="Horizontal">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="SelectUserType_2" name="SelectUserType" type="radio" value="3" />指定用户名</td>
                                <td>
                                    <asp:TextBox ID="UserNmuber" runat="server" Columns="50"></asp:TextBox>
                                    多个用户请用“|”隔开</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        短消息主题：</td>
                    <td class="bqright">
                        <asp:TextBox ID="Title" runat="server" Columns="35"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        短消息内容：</td>
                    <td class="bqright">
                        <asp:TextBox ID="Content" runat="server" Columns="45" Rows="8" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        过期时间：</td>
                    <td class="bqright">
                        <asp:TextBox ID="OverdueDate" runat="server" onblur="setday(this);" onclick="setday(this);"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" align="center" height="50">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" Text=" 发 送 " onmousedown="isok()"
                            OnClick="Button1_Click" />
                        <input type='button' class="btn" value=" 取 消 " onclick="from1.reset()"></td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
