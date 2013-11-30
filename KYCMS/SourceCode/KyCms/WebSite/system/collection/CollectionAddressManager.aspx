<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CollectionAddressManager.aspx.cs" Inherits="system_collection_CollectionAddressManager" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>采集地址管理</title>
	<link rel="stylesheet" href="../css/default.css" type="text/css" />
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

        <table border="0" cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center" style="background-color: #eef6fb;">
            <tr>
                <td style="padding-top:6px;">
                     <a id="hyperInfo" href="SetObject.aspx">添加采集</a> | <a href="CollectionManager.aspx">管理采集</a> | <a id="A1" href="SetSuperior.aspx">添加过滤</a> | <a href="SuperiorManger.aspx">过滤管理</a> | <a href="CollectionAddressManager.aspx">采集历史管理</a> 
                </td>
				<td align="right">
					<asp:LinkButton ID="linkBtnSecceed" runat="server" OnClick="linkBtnSecceed_Click">采集成功</asp:LinkButton> | <asp:LinkButton ID="linkBtnBaulk" runat="server" OnClick="linkBtnBaulk_Click">采集失败</asp:LinkButton> | <asp:LinkButton ID="linBtnkCollection" runat="server" OnClick="linBtnkCollection_Click">采集失败数据</asp:LinkButton> | 选择项目：
					<asp:DropDownList ID="ddlCollection" runat="server" Width="100" AutoPostBack="True" OnSelectedIndexChanged="ddlCollection_SelectedIndexChanged">
					</asp:DropDownList>
				</td>
            </tr>
        </table>


        <div style="margin-top:5px; text-align:center;">
            <table  width="99%" cellspacing="1" cellpadding="0" border="0" class="border">
             <asp:Repeater ID="repCollectionAddress" runat="server">
                <HeaderTemplate>
                    <tr class="title" >
                        <td width="20%">编号</td><td width="55%">链接地址</td><td width="25%">状态</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
						<td><%# Eval("Id") %><asp:HiddenField ID="hidCollectionId" Value=<%# Eval("Id") %> runat="server" /></td>
						<td><%# Eval("CollectionUrl") %></td>
						<td><%# StateStr(Eval("State")) %></td>
					</tr>
                </ItemTemplate>
                </asp:Repeater>
            </table>

			<table  width="99%" cellspacing="0" cellpadding="0" border="0" class="0" style="margin-top:5px;">
				  <tr>
					<td align="left">
						<asp:Button ID="btnDelSecceed" runat="server" Text="删除成功数据" CssClass="btn" OnClick="btnDelSecceed_Click" />
					</td>	
					<td align="right">
						<asp:Button ID="btnDelBaulk" runat="server" Text="删除失败数据" CssClass="btn" OnClick="btnDelBaulk_Click" />
					</td>
				  </tr>
				  <tr>
					<td colspan="2">
						<webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="20" HorizontalAlign="Right"  PrevPageText="上一页" ShowInputBox="Never" UrlPageIndexName="" ShowCustomInfoSection="Left" Width="99%" OnPageChanging="AspNetPager1_PageChanging" ></webdiyer:AspNetPager>
					</td>
				 </tr>
			</table>
        </div>
    </div>
    </form>
</body>
</html>
