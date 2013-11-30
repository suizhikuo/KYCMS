<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="QA_List" %>

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
        <table cellpadding="0" cellspacing="0" align="center" width="99%">
            <tr>
                <td colspan="3" valign="top">
                    <asp:DataList ID="listCategory" runat="server" RepeatColumns="3" DataKeyField="ID"
                        OnItemDataBound="listCategory_ItemDataBound" CellSpacing="1" CssClass="border" HorizontalAlign="Left" ShowFooter="False">
                        <ItemTemplate>
                            <li>
                                <asp:Literal ID="LitCategory" runat="server"></asp:Literal></li>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Literal ID="LitHeaderName" runat="server"></asp:Literal>
                        </HeaderTemplate>
                        <HeaderStyle CssClass="title"/>
                    </asp:DataList></td>
                <td rowspan="2" style="width: 4px" valign="top">
                </td>
                <td rowspan="2" valign="top" style="width: 20%">
                    <table cellpadding="0" cellspacing="1" class="border">
                        <tr>
                            <td class="title">
                                快到期的问题</td>
                        </tr>
                        <tr>
                            <td>
                            <asp:Repeater ID="rptEndDate" runat="server">
                                <ItemTemplate>
                                    ·<a href='view.aspx?id=<%#Eval("Id") %>'><%#Eval("title") %></a>
                                </ItemTemplate>
                            </asp:Repeater>
                            </td>
                        </tr>
                        <tr id="TrEndDate" runat="server" visible="false">
                            <td>·暂时没有快到期问答</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                <br />
                    <table id="Feedback_State" width="70%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="4">
                                <ul>
                                    <li>
                                        <asp:HyperLink ID="hyAll" runat="server" NavigateUrl="?all">全部问答</asp:HyperLink></li>
                                    <li id="Feedback_Selected">
                                        <asp:HyperLink ID="hyEd" runat="server" NavigateUrl='?state=1'>已完成</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hyIng" runat="server" NavigateUrl='?state=0'>问答中</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hyHigh" runat="server" NavigateUrl="?high=20">高分</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="hyZero" runat="server" NavigateUrl="?zero=true">零回答</asp:HyperLink></li>
                                </ul>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="1" style="width: 100%;" class="FeedbackBorder">
                        <asp:Repeater ID="rptING" runat="server" OnItemDataBound="rptING_DataBound">
                            <HeaderTemplate>
                                <tr class="tdbg">
                                    <td>
                                        标题</td>
                                    <td>
                                        回答数</td>
                                    <td>
                                        状态</td>
                                    <td>
                                        提问时间</td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                                    <td style="text-align: left;">
                                        <asp:Literal ID="LitSetImg" runat="server"></asp:Literal><a href='view.aspx?id=<%#Eval("ID") %>'>
                                            <%#Function.HtmlEncode(Eval("title").ToString()) %>
                                        </a>
                                    </td>
                                    <td>
                                        <asp:Literal ID="LitReplyCount" runat="server" Text='<%#Eval("ID") %>'></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Image ID="imgState" runat="server" /></td>
                                    <td>
                                        <asp:Literal ID="LitPostDate" runat="server"></asp:Literal></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="TrNoContent" runat="server" visible="false">
                            <td>·暂时没有问答</td>
                        </tr>
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
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" class="border" style="width: 99%" align="center">
            <tr>
                <td>
                    搜索：
                    <asp:DropDownList ID="ddlCategory" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlState" runat="server">
                        <asp:ListItem Value="-1">请选择状态</asp:ListItem>
                        <asp:ListItem Value="0">问答中</asp:ListItem>
                        <asp:ListItem Value="1">已完成</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="btn" OnClick="btnSearch_Click" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
