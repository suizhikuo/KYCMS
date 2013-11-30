<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SiteCount.aspx.cs" Inherits="system_website_SiteCount" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>站点访问统计</title>
    <link type="text/css" rel="Stylesheet" href="../css/default.css" />
</head>
<body>
    <form id="form1" runat="server">
        <table align="center" border="0" cellpadding="1" cellspacing="2" class="wzdh" width="99%">
            <tr>
                <td height="20" width="27">
                    &nbsp;<img alt="" height="16" src="../images/skin/default/you.gif" width="17" /></td>
                <td>
                    您现在的位置： <a href="#">后台管理</a> &gt;&gt; 站点访问统计</td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="1" cellspacing="2" class="border" width="99%">
            <tr class="wzlist">
                <td>
                    <a href="SiteCount.aspx?type=year&filter=cur">年报表</a> | <a href="SiteCount.aspx?type=year&filter=Total">
                        全部年</a> | <a href="SiteCount.aspx?type=month&filter=cur">月报表</a> | <a href="SiteCount.aspx?type=month&filter=Total">
                            全部月</a> | <a href="SiteCount.aspx?type=week&filter=cur">星期报表</a> | <a href="SiteCount.aspx?type=week&filter=Total">
                                全部星期</a> | <a href="SiteCount.aspx?type=day&filter=cur">日报表</a> | <a href="SiteCount.aspx?type=day&filter=Total">
                                    全部日</a>
                </td>
            </tr>
        </table>
        <table id="rptTable" class="border" cellpadding="0" cellspacing="1" align="center">
            <asp:Repeater ID="rptSiteCount" runat="server">
                <HeaderTemplate>
                    <tr class="title">
                        <td style="width:20%">
                            <%#SetHeaderName() %>
                        </td>
                        <td style="width:15%">
                            访问次数
                        </td>
                        <td style="width:15%">
                            所占比重
                        </td>
                        <td>
                            比例图
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmousemove="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td>
                            <%#SetType(Eval("Type")) %>
                        </td>
                        <td>
                            <%#Eval("Num") %>
                        </td>
                        <td>
                            <%#Eval("Proportion") %>
                        </td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="1" style="width:100%;background-color:#767676">
                                <tr>
                                    <td style="background-color:#ffffff;height:7px">
                                        <asp:Image ID="Img" runat="server" ImageUrl="~/system/images/ico/vote.gif" Height="7px" Width='<%#SetImg(Eval("Proportion")) %>' />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
</body>
</html>
