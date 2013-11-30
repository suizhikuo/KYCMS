<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Link.aspx.cs" Inherits="system_other_Link" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=Title %>
    </title>

    <script type="text/javascript" src="../../js/Common.js"></script>

    <link type="text/css" href="../css/default.css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="LinkList.aspx">友情链接管理</a>
                    >> 设置友情链接</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td>
                    <a href="LinkList.aspx">所有友情链接</a></td>
            </tr>
        </table>
        <table class="border" width="99%" align="center" cellpadding="0" cellspacing="1">
            <tr>
                <td class="bqleft">
                    链接类型：
                </td>
                <td class="bqright">
                    <asp:RadioButton ID="rbTextLink" runat="server" GroupName="LinkType" Checked="true" />文字链接
                    <asp:RadioButton ID="rbPicLink" runat="server" GroupName="LinkType" />图片链接
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
                    站点名称：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtRegSiteName" runat="server" MaxLength="50"></asp:TextBox><span style="color:Red">*</span>
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                    站点URL：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtRegUrl" runat="server" MaxLength="255"></asp:TextBox><span style="color:Red">*</span>
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                    站点LOGO：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtRegLogo" runat="server" MaxLength="255"></asp:TextBox><span class="tips">当为图片链接时必填</span>
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                    站长名称：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtRegName" runat="server" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                    联系Email：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr id="TrStatus" runat="server">
                <td class="bqleft">
                    审核状态：</td>
                <td class="bqright">
                    &nbsp;<asp:Label ID="lbStatus" runat="server"></asp:Label>
                    <asp:Button ID="btnSetPass" runat="server" Text="通过审核" OnClick="btnSetPass_Click" /></td>
            </tr>
            <tr id="TrIsDisable" runat="server">
                <td class="bqleft">
                    是否停用：</td>
                <td class="bqright">
                    <asp:Label ID="lbIsDisable" runat="server"></asp:Label>
                    <asp:Button ID="btnDisable" runat="server" OnClick="btnDisable_Click" />
                </td>
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
                <td class="bqleft">
                </td>
                <td class="bqright">
                    <asp:Button ID="btnReg" runat="server" Text="修改" CssClass="btn" OnClick="btnUpdate_Click" />
                    <input id="btnReset" type="reset" value="重置" class="btn" />
                </td>
            </tr>
        </table>
    </form>
    <asp:Literal ID="LitMsg" runat="server"></asp:Literal>
</body>
</html>
