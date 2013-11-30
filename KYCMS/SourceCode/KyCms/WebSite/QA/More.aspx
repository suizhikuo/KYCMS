<%@ Page Language="C#" AutoEventWireup="true" CodeFile="More.aspx.cs" Inherits="QA_More" %>

<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="uc1" %>

<%@ Import Namespace="Ky.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>问答</title>
    <link href="../user/css/Default.css" type="text/css" rel="Stylesheet" />

    <script src="../js/Common.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <table align="center" cellpadding="0" cellspacing="1" class="wzdh" width="99%">
            <tr>
                <td width="20">
                    <img align="absMiddle" src="../system/images/skin/default/you.gif" /></td>
                <td align="left" style="padding-top: 3px">
                    您现在的位置：<asp:HyperLink ID="hylnk" runat="server">网站首页</asp:HyperLink>
                    &gt;&gt; <a href="Index.aspx">问答</a></td>
                <td align="right" width="50">
                    </td>
            </tr>
        </table>
        <table align="center" cellpadding="0" cellspacing="1" class="border" width="99%">
            <tr class="wzlist">
                <td align="left">
                    <a href="Index.aspx">问答首页</a> | <a href="../user/AddFeedback.aspx">提问</a>
                </td>
            </tr>
        </table>
        <table class="border" cellpadding="0" cellspacing="1" width="99%" align="center">
            <tr class="title">
                <td>
                    <asp:Literal ID="LitTitle" runat="server"></asp:Literal></td>
            </tr>
            <asp:Repeater ID="rptContent" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            ·<a href='view.aspx?id=<%#Eval("Id") %>'><%#Function.HtmlEncode(Eval("title").ToString())%></a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" width="100%">
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" CustomInfoSectionWidth="10%"
                        FirstPageText="首页" HorizontalAlign="Right" LastPageText="尾页" NextPageText="下一页"
                        OnPageChanging="Pager_PageChanging" PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left"
                        ShowInputBox="Never" ShowNavigationToolTip="True" Width="99%">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
