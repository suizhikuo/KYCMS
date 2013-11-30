<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MoreReviewList.aspx.cs" Inherits="sys_template_MoreReviewList" %>
<html>
<body>
<%if(repReview.Items.Count==0) {%>没有发表任何评论<%} else{%>
<table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" style="word-wrap: break-word;word-break:break-all;table-layout:fixed">
<asp:Repeater ID="repReview" runat="server">
<HeaderTemplate>
<tr>
    <td width="20%">评论人</td><td width="60%">评论内容</td><td width="20%">评论时间</td>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr> 
    <td width="20%"><%# GetName(Eval("logname").ToString())%></td>
    <td width="60%" align="left"><%# GetReviewContent(Eval("ReviewContent").ToString())%></td>
    <td width="20%"><%# Eval("ReviewTime")%></td>
</tr>
</ItemTemplate>
</asp:Repeater>
<tr>
    <td colspan="3">
    总共<%=RecordCount %>条评论 当前第<%=PageIndex %>/<%=PageCount %>页面 每页<%=PageSize %>条评论 
    <asp:HyperLink ID="hlFirst" runat="server" Text="首页"></asp:HyperLink> 
    <asp:HyperLink ID="hlPre" runat="server" Text="上一页"></asp:HyperLink>
    <asp:HyperLink ID="hlNext" runat="server" Text="下一页"></asp:HyperLink>
    <asp:HyperLink ID="hlEnd" runat="server" Text="尾页"></asp:HyperLink>  
    </td>
</tr>
</table>
<%} %>
</body>
</html>
