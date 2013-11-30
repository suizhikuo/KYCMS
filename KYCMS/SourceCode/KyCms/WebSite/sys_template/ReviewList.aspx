<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewList.aspx.cs" Inherits="sys_template_ReviewList" %>
<%@ Import Namespace="Ky.Common" %>
<%@ Import Namespace="Ky.BLL" %>
<div style="text-align:left; font-weight:600; font-size:14;">网友评论：</div>
<table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" style="word-wrap: break-word;word-break:break-all;table-layout:fixed">
    <asp:Repeater ID="repReviewList" runat="server">

        <HeaderTemplate>
            <tr>
                <td width="20%">评论人</td><td width="60%">评论内容</td><td width="20%">评论时间</td>
            </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                    <td width="20%"><%# GetName(Eval("logname").ToString())%></td>
					<td width="60%" align="left"><%# Function.UbbToHtml(Eval("ReviewContent").ToString())%></td>
					<td width="20%"><%# Eval("ReviewTime")%></td>
            </tr>
        </ItemTemplate>
		<FooterTemplate>
			<tr><td align="right" colspan="3"><a href="<%=Param.ApplicationRootPath %>/Comment.aspx?P=1&ModelType=<%=modelType %>&Id=<%= id%>">更多...</a></td></tr>
		</FooterTemplate>		
		
    </asp:Repeater>
</table>
