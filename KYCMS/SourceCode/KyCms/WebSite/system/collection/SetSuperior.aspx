<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetSuperior.aspx.cs" Inherits="system_collection_SuperiorSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加高级过滤规则</title>
	<link rel="stylesheet" href="../css/default.css" type="text/css" />
	<script language="javascript" type="text/javascript" src="../../js/Common.js"></script>
	<script language="javascript" type="text/javascript">
		function CheckValidate()
		{
			if($("txtSuperiorName").value=="")
			{
				alert("必须输入高级过滤规则名称");
				$("txtSuperiorName").focus();
				return false;
			}

			if($("txtStartCode").value=="")
			{
				alert("必须输入过滤开始代码");
				$("txtStartCode").focus();
				return false;
			}

			if($("txtEndCode").value=="")
			{
				alert("必须输入过滤结束代码");
				$("txtEndCode").focus();
				return false;
			}
		}
	</script>
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
                    <a href="CollectionManager.aspx">管理采集</a> |
					<a id="A1" href="SetSuperior.aspx">添加过滤<img src="../images/comment_add.gif" border="0" /></a>
					<a href="SuperiorManger.aspx">过滤管理</a> |
					<a href="CollectionAddressManager.aspx">采集历史管理<img src="../images/comment_add.gif" border="0" /></a> 
                </td>
            </tr>
        </table>

		<table border="0" cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
			<tr>
				<td class="bqleft">过滤规则名称：</td>
				<td class="bqright"><asp:TextBox ID="txtSuperiorName" runat="server"></asp:TextBox>&nbsp;<span style="color:Red">*</span></td>
			</tr>
			<tr>
				<td class="bqleft">过滤开始代码：</td>
				<td class="bqright">
					<asp:TextBox ID="txtStartCode" runat="server" Width="500" Height="50" TextMode="multiLine"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="bqleft">过滤结束代码：</td>
				<td class="bqright">
					<asp:TextBox ID="txtEndCode" runat="server" Width="500" Height="50" TextMode="multiLine"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td colspan="2" align="center">
					<asp:Button ID="btnAdd" runat="server" Text=" 添 加 " CssClass="btn" OnClientClick="return CheckValidate()" OnClick="btnAdd_Click" /> <asp:Button ID="btnReset" runat="server" Text=" 取 消 " CssClass="btn" />
				</td>
			</tr>	
		</table>		
    </div>
    </form>
</body>
</html>
