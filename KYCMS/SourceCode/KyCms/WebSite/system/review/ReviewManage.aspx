<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewManage.aspx.cs" Inherits="System_review_ReviewManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Ky.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>评论管理</title>
    <link rel="stylesheet" href="../css/default.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27" height="24">
                    &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" /></td>
                <td>
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 用户评论管理</td>
                <td width="116" align="center">
                    &nbsp;</td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left" width="260">
                   <a href="ReviewManage.aspx?ModelId=<%=ModelId %>">待审核的评论</a> | <a href="ReviewManage.aspx?ModelId=<%=ModelId %>&IsCheck=true">已审核的评论</a></td>
                <td align="right"><asp:DropDownList ID="ddlModel" runat="server" onchange="location.href='ReviewManage.aspx?ModelId='+this.value"></asp:DropDownList> 
                    </td>
            </tr>
        </table>
       
        <table width="100%" cellpadding="0" border="0" cellspacing="0">
            <asp:Repeater ID="repInfo" runat="server" OnItemDataBound="repInfo_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <table style="margin-top: 5px;" width="99%" cellspacing="1" cellpadding="0" border="0"
                                class="border" align="center">
                                <tr class="title">
                                    <td colspan="4">
                                        <table width="100%" cellpadding="2" cellspacing="0">
                                            <tr class="title">
                                              <td width="75%" style="text-align: left;">
                                        <asp:HiddenField ID="hidId" runat="server" Value='<%# Eval("Id") %>' /><a href="DetailReview.aspx?Id=<%# Eval("Id") %>&ModelId=<%#ModelId %>">
                                            <%# Eval("Title") %></a>
                                        </span>
                                    </td>
                                    <td width="25%">
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('确定删除此信息下面的所有评论吗?')">删除此文章下的所有评论</asp:LinkButton></td>  
                                            </tr>
                                        </table>
                                    </td>
                                    
                                </tr>

                                            <asp:Repeater ID="repReview" runat="server" OnItemCommand="Repeater2_ItemCommand">
                                                <ItemTemplate>
                                                    <tr class="tdbg">
                                                        <td width="60%" align="left" style="word-warp: break-word; word-break: break-all">
                                                            <%# Function.UbbToHtml(Eval("ReviewContent").ToString())%>
                                                        </td>
                                                        <td width="10%">
                                                            <%# GetName(Eval("LogName").ToString())%>
                                                        </td>
                                                        <td width="15%">
                                                            <%# Eval("ReviewTime","{0:yyyy-MM-dd}")%>
                                                        </td>
                                                        <td width="17%">
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('确定删除此评论吗?')">删除</asp:LinkButton></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" align="center" width="99%">
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" PageSize="10" HorizontalAlign="Right" PrevPageText="上一页"
                        ShowInputBox="Never" UrlPageIndexName="p" UrlPaging="True" ShowCustomInfoSection="Left"
                        Width="99%">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
