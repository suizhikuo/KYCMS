<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegLink.aspx.cs" Inherits="RegLink" %>

<%@ Register Src="../QA/Header.ascx" TagName="Header" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>申请友情链接</title>
    <link href="../user/css/Default.css" rel="Stylesheet" type="text/css" />
   <script type="text/javascript" src="../js/Common.js"></script> 
</head>
<body>
    <form id="form1" runat="server">
		<uc2:Header ID="Header1" runat="server" />
        <table align="center" cellpadding="0" cellspacing="1" class="wzdh" width="99%">
            <tr>
                <td height="24" width="20">
                    <img align="absMiddle" src="../user/images/skin/default/you.gif" /></td>
                <td align="left" style="padding-top: 3px">
                    您现在的位置：<asp:HyperLink ID="hylnk" runat="server">网站首页</asp:HyperLink> &gt;&gt; 申请友情链接</td>
                <td align="right" width="50">
                </td>
            </tr>
        </table>
        <table class="border" width="99%" align="center" cellpadding="0" cellspacing="1">
            <tr>
                <td class="bqleft">
                    本站名称：
                </td>
                <td class="bqright">
                    <asp:Label ID="lbMySiteName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                    本站图片链接：
                </td>
                <td class="bqright">
                    <asp:Image ID="imgMyLogo" runat="server" />
                    <asp:TextBox ID="txtMyPicLink" runat="server" Width="317px"></asp:TextBox>
                    <input id="btnCopyLogo" type="button" value="复制" class="btn" onclick="txtMyPicLink.focus();document.execCommand('selectall');document.execCommand('copy')"/>
                </td>
            </tr>
            <tr>
                <td class="bqleft" style="height: 24px">
                    本站文字链接：
                </td>
                <td class="bqright" style="height: 24px">
                    <asp:TextBox ID="txtMyTextLink" runat="server" Width="317px"></asp:TextBox>
                    <input id="btnCopyText" type="button" value="复制" class="btn" onclick="txtMyTextLink.focus();document.execCommand('selectall');document.execCommand('copy')" />
                </td>
            </tr>
        </table>
        <table class="border" width="99%" align="center" cellpadding="0" cellspacing="1">
        <tr class="title">
            <td colspan="2" class="bqright" align="center">
                申请友情链接
            </td>
        </tr>
            <tr>
                <td class="bqleft">
                    链接类型：
                </td>
                <td class="bqright">
                    <asp:RadioButton ID="rbTextLink" runat="server" GroupName="LinkType" Checked="true"  onclick="IsDisplay('LogoTr')"/>文字链接
                    <asp:RadioButton ID="rbPicLink" runat="server" GroupName="LinkType" onclick="IsDisplay('LogoTr');" />图片链接
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                    所属分类： 
                </td>
                <td class="bqright">
                    <asp:DropDownList ID="ddlLinkCategory" runat="server">
                    </asp:DropDownList> 
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                您站点的名称：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtRegSiteName" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRegSiteName"
                        ErrorMessage="* 请输入您的站点名称"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="bqleft">
               您站点的URL： 
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtRegUrl" runat="server" MaxLength="255"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRegUrl"
                        ErrorMessage="* 请输入您的站点URL" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtRegUrl"
                        Display="Dynamic" ErrorMessage="* 您输入的URL格式不正确" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator></td>
            </tr>
            <tr  id="LogoTr" style="display:none">
                <td class="bqleft">
                您站点的LOGO：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtRegLogo" runat="server" MaxLength="255"></asp:TextBox> </td>
            </tr>
            <tr>
                <td class="bqleft">
               您的联系名称：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtRegName" runat="server" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="bqleft">
               您的联系Email：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="* 请输入您的联系Email"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="* 您输入的Email格式不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td class="bqleft">
               站点描述：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" MaxLength="200"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td colspan="2" class="bqright" align="center">
                    <asp:Button ID="btnReg" runat="server" Text="提交" CssClass="btn" OnClick="btnReg_Click" />
                    <input id="btnReset" type="reset"
                        value="重置" class="btn" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
