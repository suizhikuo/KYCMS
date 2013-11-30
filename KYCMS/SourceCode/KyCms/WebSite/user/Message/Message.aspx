<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="user_Message_Message" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td>
                    您现在的位置：用户后台 >> 短消息管理 >> 发送短消息</td>
                <td width="50" align="right">
                </td>
            </tr>
        </table>
        <table width="99%" cellspacing="0" cellpadding="0" class="wzlist" align="center">
            <tr>
                <td>
                    <a href="MessageList.aspx?TypeId=1">短消息管理</a> | <a href="Message.aspx">发送短消息</a></td>
                <td align="right" width="300">
                    <a href="MessageList.aspx?TypeId=3">草稿箱</a> | <a href="MessageList.aspx?TypeId=1">收件箱</a>
                    | <a href="MessageList.aspx?TypeId=2">发件箱</a> | <a href="MessageList.aspx?TypeId=4">
                        回收站</a></td>
            </tr>
        </table>
        <table width="99%" border="0" cellpadding="0" cellspacing="1" class="border" align="center">
            <tbody>
                <tr>
                    <td class="bqleft">
                        收件人：</td>
                    <td class="bqright">
                        <asp:TextBox ID="ReceiverName" runat="server" Columns="40"></asp:TextBox>&nbsp;
                        <asp:DropDownList ID="UserFriend" runat="server" onchange="SelectFromFriend()">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        短消息主题：</td>
                    <td class="bqright">
                        <asp:TextBox ID="Title" runat="server" Columns="25"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft" style="height: 22px">
                        短消息内容：</td>
                    <td class="bqright" style="height: 22px">
                        <asp:TextBox ID="Content" runat="server" Columns="60" Rows="10" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" align="center" height="50">
                        <asp:Button ID="Button1" runat="server" Text=" 发送 " CssClass="btn" OnClick="Button1_Click" />
                        &nbsp; &nbsp;
                        <asp:Button ID="Button2" runat="server" Text=" 存草稿 " CssClass="btn" OnClick="Button2_Click" /></td>
                </tr>
            </tbody>
        </table>

        <script type="text/javascript">
        
            var sReceiverName = document.getElementById("ReceiverName");
            var sUserFriend = document.getElementById("UserFriend");        
            function SelectFromFriend()
            {

                if(sUserFriend.selectedIndex==0)
                {
                    return false;
                }
                var selectedFriend = sUserFriend.value;
                
                if(sReceiverName.value !='')
                {
                    var users = sReceiverName.value.split(',');
                    for(var i=0;i<users.length;i++)
                    {
                        if(users[i]==selectedFriend)
                        {
                            return false;
                        }
                    }
                    sReceiverName.value +="|"+selectedFriend;
                }
                else
                {
                    sReceiverName.value =selectedFriend;
                }
            }
        </script>

    </form>
</body>
</html>
