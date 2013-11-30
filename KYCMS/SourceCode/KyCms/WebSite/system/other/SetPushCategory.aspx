<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetPushCategory.aspx.cs"
    Inherits="system_other_PushCategory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设置广告位</title>
    <link href="../css/default.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="../../js/Common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="pushinfolist.aspx">广告管理</a>
                    >> 添加广告位</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td>
                    <a href="setpushinfo.aspx">添加广告</a> | <a href="setpushcategory.aspx">添加广告位</a> |
                    <a href="pushinfolist.aspx">广告列表</a> | <a href="PushCategoryList.aspx">广告位列表</a></td>
            </tr>
        </table>
        <table style="width: 99%" class="border" cellpadding="0" cellspacing="1" align="center">
            <tr>
                <td class="bqleft">
                    广告位名称：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtCategoryName" runat="server" MaxLength="50"></asp:TextBox><span
                        style="color: Red">*</span></td>
            </tr>
            <tr>
                <td class="bqleft">
                    显示方式：</td>
                <td class="bqright">
                    <asp:RadioButtonList ID="rblDisplayType" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow" onclick="if($('rblDisplayType_4').checked)$('TrMatrix').style.display='';else $('TrMatrix').style.display='none'">
                        <asp:ListItem Value="1" Selected="True">矩形横幅</asp:ListItem>
                        <asp:ListItem Value="2">对联</asp:ListItem>
                        <asp:ListItem Value="3">随屏移动</asp:ListItem>
                        <asp:ListItem Value="4">随机浮动</asp:ListItem>
                        <asp:ListItem Value="5">版位广告</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td class="bqleft">
                    宽高：</td>
                <td class="bqright">
                    宽<asp:TextBox ID="txtWidth" runat="server" Width="27px" MaxLength="4"></asp:TextBox>px
                    高<asp:TextBox ID="txtHeigth" runat="server" Width="27px" MaxLength="4"></asp:TextBox>px</td>
            </tr>
            <tr id="TrMatrix" runat="server" style="display: none">
                <td class="bqleft">
                    排列方式：</td>
                <td class="bqright">
                    一行<asp:TextBox ID="txtPer" runat="server" MaxLength="2" Width="27px">5</asp:TextBox>列
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                    状态：</td>
                <td class="bqright">
                    <asp:RadioButtonList ID="rblIsDisable" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1" Selected="True">正常</asp:ListItem>
                        <asp:ListItem Value="2">禁用</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td class="bqleft">
                    描述：</td>
                <td class="bqright">
                    <asp:TextBox ID="txtDescription" runat="server" Height="70px" TextMode="MultiLine"
                        Width="254px" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="bqleft">
                </td>
                <td class="bqright">
                    <asp:Button ID="btnSet" runat="server" CssClass="btn" Text="添加" OnClick="btnSet_Click" />
                    <input id="btnReset" class="btn" type="reset" value="重置" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
