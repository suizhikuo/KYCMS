<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IframeModelItem.aspx.cs" Inherits="system_label_IframeModelItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link rel="stylesheet" href="../css/default.css" type="text/css" />
    <script type="text/javascript" src="../../JS/Common.js"></script>
    <script language="javascript" type="text/javascript">
		var menuHit=0;
		function ShowModelList()
		{
			if(menuHit==0)
			{
				modelMenuList.style.display="";
				menuHit=menuHit+1;
			}
			else
			{
				modelMenuList.style.display="none";	
				menuHit=menuHit-1;
			}
		}

		function showMenu()
		{
				modelMenuList.style.display="";
				menuHit=1;
		}
    </script>
</head>
<body style="margin:0px;">
    <form id="form1" runat="server">
	<div id="modelMenuList" style="display:block;position:absolute; width:100px; padding:0px; margin-top:0px; border:0px;" class="wzlist border">
			<div style="width:100%; height:100%; padding:0px;">
				<table cellpadding="0" border="0" cellspacing="0" width="100%">
					<asp:Repeater runat="server" ID="repModelList">
						<ItemTemplate>
							<tr>
								<a href="SetStyle.aspx?modelId=<%# Eval("ModelId") %>" target="ContentIframe">
									<td style="cursor:hand;" onmouseover="showMenu();javascript:this.style.backgroundColor='#CCCCCC'" onmouseout="showMenu();javascript:style.backgroundColor='#eef6fb'">&nbsp;&nbsp;<%# Eval("ModelName") %>
									</td>
								</a>
							</tr>
						</ItemTemplate>
						<FooterTemplate>
							<tr>
								<a href="SetStyle.aspx?modelId=0">
									<td style="cursor:hand;" onmouseover="showMenu();javascript:this.style.backgroundColor='#CCCCCC'" onmouseout="showMenu();javascript:style.backgroundColor='#eef6fb'">&nbsp;&nbsp;通用样式
									</td>
								</a>
							</tr>
						</FooterTemplate>
					</asp:Repeater>
				</table>
			</div>
		</div>    
     </form>
</body>
</html>
