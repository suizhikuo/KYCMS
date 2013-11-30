<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SuperLabelIn.aspx.cs" Inherits="system_label_SuperLabelIn" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
        <tr>
            <td height="24" width="20">
                <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
            <td align="left" style="padding-top: 3px;">
                您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href="SuperLabelList.aspx">超级标签管理</a>
                &gt;&gt; 导入超级标签</td>
            <td width="50" align="right">
                <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
        </tr>
    </table>
    <form id="form1" runat="server">
    <table width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
            <tr>
                <td width="420"><asp:ListBox ID="SuperLabel" runat="server" Width="400px" Height="246px" Rows="15" SelectionMode="Multiple">
                </asp:ListBox></td>
                <td>1、请选择需要导入的超级标签名称<br />2、导入的超级标签文件保存在:站点目录/conf/SuperLabel.xml<br />3、如没有超级标签文件,请手动拷贝超级标签文件到站点目录/conf/SuperLabel.xml<br />4、导入超级标签后,请确保超级标签名称不相同<p></p><asp:Button ID="Button1" runat="server" CssClass="btn" Text=" 导入超级标签  " OnClick="Button1_Click" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
