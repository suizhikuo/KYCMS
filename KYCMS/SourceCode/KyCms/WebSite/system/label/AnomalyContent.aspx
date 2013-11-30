<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnomalyContent.aspx.cs" Inherits="system_label_AnomalyContent" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Ky.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>操作法规则标签</title>
	<link rel="stylesheet" href="../css/default.css" type="text/css" />
	<script language="javascript" src="../../js/Common.js" type="text/javascript"></script>
	<script language="javascript" type="text/javascript">
		//预览代码
		function PreListFun()
		{
			FieldPre($("txtContent").value);
		}

	
       function CheckValidate()
       {
            if($("txtName").value.trim().length==0)
           {
                alert("标签名称必须填写");
                $("txtName").focus();
                return false; 
           } 
            if($("txtContent").value.trim().length==0)
           {
                alert("标签内容必须填写");
                $("txtContent").focus();
                return false; 
           } 
           return true;
       }

		function setx(obj)
		{
			$('txtContent').focus();
			if (document.selection)
			{
				var range= document.selection.createRange();
				range.text = "<a href=\""+obj.id+"\">"+coder(obj.title)+"</a>";
			}			
		}

		//不规则处理
		//代码预览
		function FieldPre(val)
		{
			document.getElementById("preList").innerHTML="正在处理数据. . . ";
			system_label_AnomalyContent.AnomalyContent(val,FieldPre_CallBack);
		}
	    
		function FieldPre_CallBack(res)
		{
			document.getElementById("preList").innerHTML=res.value;
		}
		
	</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
		<table class="wzdh" cellpadding="1" cellspacing="0" width="99%" align="center">
			<tr>
				<td align="left" style="padding-top:3px;" >
					您现在的位置：<a href="../SystemInfo.aspx">后台管理</a>
					>> <a href="../template/CreateFolder.aspx">标签&模板管理</a> 
					>> <a href="LabelManager.aspx"> 标签管理</a> 
					>> 添加不规则数据</td>
				<td align="right" width="50"><img src="../images/skin/default/help.gif" /></td>
			</tr>
		</table>

		<table class="border" cellpadding="0" cellspacing="0" width="99%" align="center">
			<tr>
				<td width="45%" valign="top">
					<table cellpadding="2" cellspacing="2" width="99%" align="center">
						<tr>
							<td valign="top">
								<table width="100%">
									<tr>
										<td align="left">
													标签名称：<asp:Label ID="lblPrefix" runat="server" Text="{Ky_" ForeColor="Red"></asp:Label>
													<asp:TextBox ID="txtName" runat="server" Width="80" Height="15"></asp:TextBox>
													<asp:Label ID="lblPostfix" runat="server" Text="}" ForeColor="Red"></asp:Label>
										</td>

										<td align="right">
													频道：<asp:DropDownList ID="ddlCh" runat="server" Width="80" OnSelectedIndexChanged="ddlCh_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td>
								<table width="99%" cellspacing="1" cellpadding="0" border="0" class="border">
									<asp:Repeater ID="repAnomaly" runat="server" OnItemCommand="repAnomaly_ItemCommand">
										<HeaderTemplate>
											<tr class="title">
												<td width="18%">栏目名称</td>
												<td width="67%">内容名称</td>
												<td width="15%">操作</td>
											</tr>
										</HeaderTemplate>
										<ItemTemplate>
											<tr style="background: #f3f3f3;" onmouseover="this.style.background='#C8E2F9'" onmouseout="this.style.background='#f3f3f3'">
												<td><%# Function.HtmlEncode(Eval("ColName"))%></td>
												<td><%# Function.HtmlEncode(Eval("Title"))%></td>
												<td align="center">
													<asp:HiddenField ID="hidAnomalyId" runat="server" Value=<%#Eval("Id") %> />
													<asp:LinkButton ID="linkbtnDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('你确定要删除吗？');"> 删除</asp:LinkButton>
												</td>
											</tr>
										</ItemTemplate>
									</asp:Repeater>
								  <tr>
									<td colspan="3">
										<webdiyer:AspNetPager ID="pageAnomaly" runat="server" AlwaysShow="True" FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="20" HorizontalAlign="Right"  PrevPageText="上一页" ShowInputBox="Never" UrlPageIndexName="" ShowCustomInfoSection="Left" Width="99%" OnPageChanging="pageAnomaly_PageChanging"></webdiyer:AspNetPager>
									</td>
								 </tr>
								</table>
							</td>
						</tr>
					</table>
				</td>
				<td style="border-left:solid 1px #CCC;">&nbsp;</td>
				<td width="55%">
					<table cellpadding="2" cellspacing="2" width="99%" align="center">
						<tr><td>不规则标签格式：<br />{$ky row="1" length="10" style="Color:F00;font-size:14px;" target="_blank"/}</td></tr>
						<tr><td><textarea id="txtContent" style="width:100%;border:solid 1px #CCC;" rows="15" runat="server"></textarea></td></tr>
						<tr><td widt="500" align="center"><input id="Submit1" type="button" value=" 预览列表 " onclick="PreListFun()" class="btn" /></td></tr>
						<tr><td widt="500" height="300" id="preList" style="border:solid 1px #CCC;" valign="top">&nbsp;</td></tr>
					</table>
				</td>
			</tr>
			<tr> 
				<td colspan="3" align="center" style="border-top:solid 1px #CCC;">
					<asp:Button ID="btnSave" runat="server" Text=" 保 存 " CssClass="btn" OnClientClick="return CheckValidate()"  OnClick="btnSave_Click" />
					<asp:Button ID="btnReset" runat="server" Text=" 取 消 " CssClass="btn" OnClick="btnReset_Click" />					
				</td>
			</tr>
		</table>
    </div>    
    </div>
    </form>
</body>
</html>
