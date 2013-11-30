<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegSpace.aspx.cs" Inherits="user_space_RegSpace" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../Css/default.css" type="text/css" rel="stylesheet" />

<script type="text/javascript" src="../../JS/Common.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>激活用户空间</title>
</head>
<body onload="showpass();changeTemplate();">
    <form id="form1" runat="server">
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="20">
                   <img src="../images/skin/default/you.gif" width="17" height="16"></td>
                <td>
                    您现在的位置： <a href="../welcome.aspx">用户后台</a> &gt;&gt;
                    <asp:Label ID="Label1" runat="server" Text="激活"></asp:Label>个人空间</td>
                <td width="116" align="center">
                    &nbsp;</td>
            </tr>
        </table>
        <table width="99%" cellspacing="0" cellpadding="0" class="wzlist" align="center">
            <tr>
                <td>
                    &nbsp;空间管理 | <a href="AlbumManage.aspx">相册管理</a> | <a href="MessageManage.aspx">留言管理</a>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
            <tr>
                <td colspan="3" class="title">
                    <asp:Label ID="Label2" runat="server" Text="激活"></asp:Label>空间</td>
            </tr>
            <tr>
                <td class="bqleft" style="height: 43px">
                    空间名称：</td>
                <td class="bqright" style="width: 316px; height: 43px;" valign="top">
                    <asp:TextBox ID="txtSpaceName" runat="server" Text="" Width="70%" MaxLength="30"></asp:TextBox><font
                        color="#FF0000"> *</font><span class="tips">将显示于空间首页当中</span></td>
                <td rowspan="5" class="bqright">
                    模板预览<br />
                    <img alt="模板预览" id='template' /></td>
            </tr>
            <tr>
                <td class="bqleft">
                    空间模板：</td>
                <td class="bqright" style="width: 40%">
                    <asp:DropDownList ID="ddlTemplateId" runat="server" onchange="changeTemplate()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="bqleft">
                    空间描述：</td>
                <td class="bqright" style="width: 40%">
                    <asp:TextBox ID="txtSpaceDescription" runat="server" Width="95%" Height="86px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tbody style="" runat="server" id="tbody">
                <tr>
                    <td class="bqleft">
                        查看权限：</td>
                    <td class="bqright" style="width: 40%" colspan="2">
                        <div>
                            <asp:RadioButtonList ID="rdBtnPower" runat="server" RepeatDirection="Horizontal"
                                ForeColor="#000040" onclick="javascript:showpass()">
                                <asp:ListItem Value="0" Selected="true">允许所有人</asp:ListItem>
                                <asp:ListItem Value="1">仅好友可见</asp:ListItem>
                                <asp:ListItem Value="2">密码访问</asp:ListItem>
                            </asp:RadioButtonList></div>
                        <div id="Password" style="display: none">
                            密码：<asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></div>
                    </td>
                </tr>
            </tbody>
            <tr>
                <td class="bqleft">
                </td>
                <td style="color: #ff0000; text-align: left; height: 23px; width: 316px;" class="bqright"
                    colspan="2">
                    <asp:Button ID="btnSaveCate" runat="server" Text="激 活" CssClass="btn" OnClick="btnSave_Click"
                        OnClientClick="return CheckValidate()" />
                    <asp:Literal ID="ltMsg" runat="server"></asp:Literal></td>
            </tr>
        </table>
    </form>
</body>
</html>

<script language="javascript">
function CheckValidate()
{
    if($("txtSpaceName").value.trim().length==0)
    {
        alert("个人空间名称必须填写");
        $("txtSpaceName").focus();
        return false;
    }
    if($("rdBtnPower_2").checked && $("txtPassword").value.trim().length==0)
    {
        alert("密码必须填写");
         $("txtPassword").focus();
        return false;
    }
}
function showpass()
{
if($("rdBtnPower_2").checked)
  {  Password.style.display="";}
else
    {Password.style.display="none";
    $("txtPassword").value="";}
}
function changeTemplate()
{
var index=$('ddlTemplateId').value;
    $('template').src="../../userspace/skin/template/"+index+".jpg";
}
</script>

