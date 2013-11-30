<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetLabelContent.aspx.cs" Inherits="System_Label_SetLabelContent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加与修改标签内容</title>
    <link rel="stylesheet" href="../css/default.css" type="text/css" />
    <script src="../../JS/Common.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
    function WindowOpen(url,n,w,h) 
    {
        var c=WinOpen(url,n,w,h);
        c.focus(); 
    }  
		function setx(values)
		{
			$('lblContent').focus();
			if (document.selection)
			{
				var range= document.selection.createRange();
				range.text = values;
			}			
		}

		function HidValue(hidvalue)
		{
			$("hidModelId").value=hidvalue;
		}

       function CheckValidate()
       {
            if($("txtLabelName").value.trim().length==0)
           {
                alert("标签名称必须填写");
                $("txtLabelName").focus();
                return false; 
           } 
            if($("lblContent").value.trim().length==0)
           {
                alert("标签内容必须填写");
                $("txtLabelName").focus();
                return false; 
           } 
           return true;
       }		
         
    </script>    
</head>
<body>
    <form id="form1" runat="server">
    <div>

		<table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
			<tr>
				<td height="24" width=20><img src="../images/skin/default/you.gif" align="absmiddle" /></td>
				<td align=left style="padding-top:3px;" >您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="../template/CreateFolder.aspx">标签&模板管理</a> >> <a href="LabelManager.aspx"> 标签管理</a> >>	<asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label></td>
				<td width="50" align="right"><img src="../images/skin/default/help.gif" align=absmiddle /></td>
			</tr>
		</table>

        <!--top-->
        <table width="99%" border="0" cellpadding="0" cellspacing="0" class="wzdh" align="center" style="margin-top:5px;">
            <tr>
                <td  height="26" align="left">&nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/System/Label/LabelManager.aspx">标签管理首页</asp:HyperLink> | <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/System/Label/SetLabelCategory.aspx">新增标签分类</asp:HyperLink> | <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/System/Label/setLabelContent.aspx">创建新标签</asp:HyperLink> | <a href="#" onclick="javascript:window.history.back();">返回</a></td>
                <td align="right">
                    <asp:DropDownList ID="ddlRedirectPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRedirectPage_SelectedIndexChanged">
                        <asp:ListItem>跳转类型至…</asp:ListItem>
                        <asp:ListItem Value="StyleManager.aspx">样式管理</asp:ListItem>
                        <asp:ListItem Value="LabelManager.aspx">标签管理</asp:ListItem>
                        <asp:ListItem Value="../Template/CreateFolder.aspx">模板管理</asp:ListItem>
                    </asp:DropDownList>&nbsp;
                </td>
            </tr>
        </table>
        <!--endtop--> 
        
        <!--body-->
        <table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center">
            
            <tr>
                <td class="bqleft">标签名称：</td>
				<td class="bqright">
					<asp:Label ID="lblPrefix" runat="server" Text="{Ky_" ForeColor="Red"></asp:Label>
					<asp:TextBox ID="txtLabelName" runat="server"></asp:TextBox>
					<asp:Label ID="lblPostfix" runat="server" Text="}" ForeColor="Red"></asp:Label>&nbsp;
                    <asp:DropDownList ID="dllLbCategory" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
                        
            <tr>
                <td class="bqleft">选择模型：</td>
				<td class="bqright">|

					<!--指定要打开所属模型的标签页面-->
					<asp:Repeater runat="server" ID="repModelList">
						<ItemTemplate>
							<a href="#"   onclick="javascript:WindowOpen('CommonlyList.aspx?modelId=<%# Eval("ModelId") %>','commonlist',750,590);HidValue(<%# Eval("ModelId") %>);" ><%# Eval("ModelName") %></a> |
						</ItemTemplate>
					</asp:Repeater>
					
					<!--保存创建的标签所属的模型-->
					<input id="hidModelId" runat="server" type="hidden" value="1" /> 
				</td>
            </tr>

			<tr>
				<td class="bqleft">通用标签：</td>
				<td class="bqright"><!--
					| <a href="#" onclick="WinOpenDialog('NewsRoutine.aspx','650','590')">模型常规</a> | 
					<a href="#"  onclick="WinOpenDialog('SetSpecial.aspx','750','590')" >专题模块</a> | 
					<a href="#" onclick="WinOpenDialog('SysParameter.aspx','650','590')">系统常用标签 |</a>  -->
					| <a href="#" onclick="javascript:WindowOpen('NewsRoutine.aspx?modelId=','commonlist',750,590)">模型常规</a> |
					  <a href="#" onclick="javascript:WindowOpen('SetSpecial.aspx?modelId=','commonlist',750,590)">专题模块</a> |
					  <a href="#" onclick="javascript:WindowOpen('SysParameter.aspx?modelId=','commonlist',750,590)">系统常用标签</a>
				</td>
			</tr>

            <tr>
                <td class="bqleft">标签内容：</td>
				<td class="bqright"><textarea id="lblContent" rows="8" style="width:98%" runat="server"></textarea></td>
            </tr>

            <tr>
                <td height="29" colspan="2" align="center"><asp:Button ID="btnSave" runat="server" Text="确认保存标签" CssClass="btn" OnClick="btnSave_Click" OnClientClick="return CheckValidate()" /> <asp:Button ID="btnReset" runat="server" Text="重置" CssClass="btn" OnClick="btnReset_Click" /></td>
            </tr>
                        
        </table>
        <!--endbody-->   
    </div>
    </form>
</body>
</html>

