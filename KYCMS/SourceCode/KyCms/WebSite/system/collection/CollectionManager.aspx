<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CollectionManager.aspx.cs" Inherits="system_collection_CollectionManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>采集列表管理</title>
	<link rel="stylesheet" href="../css/default.css" type="text/css" />
	<script language="javascript" type="text/javascript" src="../../js/Common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
				<tr>
					<td width="20" height="24">
						<img src="../images/skin/default/you.gif" width="17" height="16" /></td>
					<td align="left" style="padding-top: 3px;">
						您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href="../user/LogList.aspx">扩展功能</a> &gt;&gt; 采集管理</td>
					<td width="50" align="right">
						<img src="../images/skin/default/help.gif" align="absmiddle" /></td>
				</tr>
		</table>

        <table border="0" cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
            <tr class="wzlist">
                <td>
                    <a id="hyperInfo" href="SetObject.aspx">添加采集<img src="../images/comment_add.gif" border="0" /></a> |
                    <a href="CollectionManager.aspx">采集管理</a> |
					<a id="A1" href="SetSuperior.aspx">添加过滤<img src="../images/comment_add.gif" border="0" /></a> | 
					<a href="SuperiorManger.aspx">过滤管理</a> |
					<a href="CollectionAddressManager.aspx">采集历史管理<img src="../images/comment_add.gif" border="0" /></a> 
                </td>
            </tr>
        </table>

        <div style="margin-top:5px; text-align:center;">
            <table  width="99%" cellspacing="1" cellpadding="0" border="0" class="border">
             <asp:Repeater ID="repCollection" runat="server" OnItemCommand="repCollection_ItemCommand">
                <HeaderTemplate>
                    <tr class="title" >
                        <td width="5%">编号</td><td width="25%">项目名称</td><td width="20%">目标站点</td><td width="30%">备注</td><td width="20%">操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
						<td><%# Eval("Id") %></td>
						<td><%# Eval("objectName") %></td>
						<td><%# Eval("webSite") %></td>
						<td><%#Eval("objectdemo") %></td>
						<td>
							<a href="EditObject.aspx?id=<%# Eval("Id") %>">修改</a> | 
							<asp:HiddenField ID="hidCollectionId" Value=<%# Eval("Id") %> runat="server" />
							<asp:LinkButton ID="linkBtnDelete" runat="server" OnClientClick="return confirm('你确定要删除吗？');">删除</asp:LinkButton> | 
							<a href="Collection.aspx?id=<%# Eval("Id") %>">采集</a>
						</td>
					</tr>
                </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>

    </div>
    </form>
</body>
</html>
