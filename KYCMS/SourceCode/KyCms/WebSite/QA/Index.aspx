<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="QA_Index" %>

<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="uc1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Ky.Common" %>
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
                    &gt;&gt; 问答</td>
                <td align="right" width="50">
                    </td>
            </tr>
        </table>
        <table align="center" cellpadding="0" cellspacing="1" class="border" width="99%">
            <tr class="wzlist">
                <td align="left">
                    <a href="Index.aspx">所有问答</a> | <a href="../user/AddFeedback.aspx">提问</a>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" align="center" width="99%">
            <tr>
                <td valign="top" width="20%">
                    <table cellpadding="0" cellspacing="1" class="border">
                        <tr>
                            <td class="title">
                                问题分类</td>
                        </tr>
                        <tr>
                            <td>
                                <span style="color: #080">共有问题：<asp:Literal ID="LitTotal" runat="server"></asp:Literal><br />
                                    已解决问题数：<asp:Literal ID="LitEd" runat="server"></asp:Literal>
                                    <br />
                                    待解决问题数：<asp:Literal ID="LitIng" runat="server"></asp:Literal></span><hr style="border: solid 1px #ccc" />
                                <asp:TreeView ID="tvCategory" runat="server" ShowLines="True" EnableTheming="True"
                                    OnSelectedNodeChanged="tvCategory_SelectedNodeChanged" ExpandDepth="0">
                                </asp:TreeView>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 4px" valign="top">
                </td>
                <td valign="top" width="60%">
                    <table cellpadding="0" cellspacing="1" style="width: 100%;" class="border">
                        <tr class="title">
                            <td>
                                问答中</td>
                        </tr>
                        <asp:Repeater ID="rptING" runat="server">
                            <ItemTemplate>
                                <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                    <td style="text-align: left;">
                                        ·<a href='view.aspx?id=<%#Eval("ID") %>'>
                                            <%#Function.HtmlEncode(Eval("title").ToString()) %>
                                        </a>[<a href='List.aspx?cid=<%#Eval("categoryId")%>'><%#SetCategory(Eval("categoryId")) %></a>]
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="TrIngMore" runat="server" visible="false">
                            <td>
                                <a href="More.aspx?state=0">更多>>></a></td>
                        </tr>
                        <tr id="TrIngNo" runat="server" visible="false">
                            <td>
                                ·暂时没有问答</td>
                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="1" style="width: 100%;" class="border">
                        <tr class="title">
                            <td>
                                近 5 天解决的问题</td>
                        </tr>
                        <asp:Repeater ID="rptEd" runat="server">
                            <ItemTemplate>
                                <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                    <td style="text-align: left;">
                                        ·<a href='view.aspx?id=<%#Eval("ID") %>'>
                                            <%#Function.HtmlEncode(Eval("title").ToString()) %>
                                        </a>[<a href='List.aspx?cid=<%#Eval("categoryId")%>'><%#SetCategory(Eval("categoryId")) %></a>]
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="TrEdMore" runat="server" visible="false">
                            <td>
                                <a href="More.aspx?state=0">更多>>></a></td>
                        </tr>
                        <tr id="TrEdNo" runat="server" visible="false">
                            <td>
                                ·暂时没有问答</td>
                        </tr>
                    </table>
                </td>
                <td style="width: 4px" valign="top">
                </td>
                <td valign="top">
                    <table cellpadding="0" cellspacing="1" class="border">
                        <tr class="title">
                            <td colspan="2">
                                问答用户排行榜</td>
                        </tr>
                        <asp:Repeater ID="rptScoring" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        ·<a href='More.aspx?author=<%#Function.UrlEncode(Eval("author").ToString()) %>'><%#Eval("author") %></a></td>
                                    <td>
                                        <%#Eval("Sum") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="TrUser" runat="server" visible="false">
                            <td>
                                ·暂时没有问答用户</td>
                        </tr>
                    </table>
                    <br />
                    <img src="../images/adright.jpg" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
