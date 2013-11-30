<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Notice.aspx.cs" Inherits="system_other_Notice" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户公告管理</title>

    <link href="../Css/default.css" type="text/css" rel="stylesheet" />
   <script type="text/javascript" src="../../js/RiQi.js"></script> 
    <script language="javascript">
    function isok()
    {
        if(document.form1.Title.value=="")
        {
            alert("标题不能够为空！")
            document.form1.Title.focus();
            return false;
        }
        if(document.form1.IsPriority.value=="")
        {
            alert("优先级别为1-100之间的有效数字")
            document.form1.IsPriority.focus();
            return false;
        }
        
        if(isNaN(document.form1.IsPriority.value))   
        {   
            alert("优先级别只能够是数字");   
            document.form1.IsPriority.focus();  
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
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="NoticeList.aspx">会员后台公告</a> >> 添加公告</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                    <a href="NoticeList.aspx">用户后台公告列表</a> | <a href="Notice.aspx">添加公告</a></td>
                <td align="right" width="300">
                    <a href="NoticeList.aspx?UserId=-1&TypeId=4">我发的公告</a> | <a href="NoticeList.aspx?UserId=0&TypeId=3">未审核公告</a> | <a href="NoticeList.aspx?UserId=0&TypeId=5">已过期公告</a>&nbsp;</td>
            </tr>
        </table>
        <table width="99%" border="0" cellpadding="0" cellspacing="1" class="border" align="center">
            <tbody>
                <tr>
                    <td class="bqleft">
                        标题：</td>
                    <td class="bqright">
                        <asp:TextBox ID="Title" runat="server"></asp:TextBox><asp:Label ID="Label1" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        公告内容：</td>
                    <td class="bqright">
                        <asp:TextBox ID="Content" runat="server" Columns="45" Rows="6" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        过期时间：</td>
                    <td class="bqright">
                        <asp:TextBox ID="OverdueDate" runat="server" onblur="setday(this);" onclick="setday(this);"></asp:TextBox></td>
                </tr>
                <tr class="bqleft">
                    <td class="bqleft">
                        优先级别：</td>
                    <td class="bqright">
                        <asp:TextBox ID="IsPriority" runat="server" MaxLength="2" onkeyup="value=value.replace(/[^\d]/g,'')">0</asp:TextBox>
                        <asp:Label ID="Label2" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        公告状态：</td>
                    <td class="bqright"><asp:RadioButtonList ID="IsState" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>草稿</asp:ListItem>
                            <asp:ListItem Selected="True">审核通过</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        发布人：</td>
                    <td class="bqright">
                        <asp:Label ID="UserName" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        发布时间：</td>
                    <td class="bqright">
                        <asp:Label ID="AddDate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" align="center" height="30">
                        <asp:Button ID="Button1" runat="server" Text=" 提交 " CssClass="btn" onmousedown="isok()" OnClick="Button1_Click" />
                        <input id="Button2" type="button" value="取 消" class="btn" /></td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
