<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddStyleType.aspx.cs" Inherits="System_AddStyleType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加样式分类</title>
    <link rel="stylesheet" href="../css/default.css" type="text/css" />
   <script language="javascript" type="text/javascript" src="../../js/Common.js"></script>
   <script language="javascript" type="text/javascript">
			function CheckValidate()
			{
                if($("txtStyleTypeName").value.trim().length==0)
               {
                    alert("样式名称必须填写");
                    $("txtStyleTypeName").focus();
                    return false; 
               } 
               return true;			
           }

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
    <style type="text/css">
    <!--
    .STYLE1 {color: #FF0000}
    .STYLE2 {color: #0000FF}
    -->
    </style>    
</head>
<body>
    <form id="form1" runat="server">
    <div>
	<table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
		<tr>
			<td height="24" width=20><img src="../images/skin/default/you.gif" align=absmiddle /></td>
			<td align=left style="padding-top:3px;" >您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="../template/CreateFolder.aspx">标签&模板管理</a> >> <a href="StyleManager.aspx"> 样式管理</a> >> 新增样式分类</td>
			<td width="50" align="right"><img src="../images/skin/default/help.gif" align=absmiddle /></td>
		</tr>
	</table>

    <table width="99%" border="0" cellpadding="0" cellspacing="0" class="wzdh" align="center" style="margin-top:5px;">
        <tr><td  height="26" align="left">&nbsp;
					<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/System/Label/StyleManager.aspx">样式管理首页</asp:HyperLink> | 
					<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/System/Label/AddStyleType.aspx">新增样式分类</asp:HyperLink> | 
					<span style="border:solid 1px #CCCCCC; padding:0px 0px 0px 0px ; background-color:#FFFFFF;"><a href="#" onclick="ShowModelList()">&nbsp;创建新样式 &nbsp;<img id="imgdrp" style="vertical-align:middle;" src="../images/skin/default/sitelist.gif" alt="" border="0" /></a></span> | 
					<a href="#" onclick="javascript:window.history.back();">返回</a>
				</td>
        <td align="right">
                <asp:DropDownList ID="ddlRedirectPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRedirectPage_SelectedIndexChanged">
                    <asp:ListItem>跳转类型至…</asp:ListItem>
                    <asp:ListItem Value="StyleManager.aspx">样式管理</asp:ListItem>
                    <asp:ListItem Value="LabelManager.aspx">标签管理</asp:ListItem>
                    <asp:ListItem Value="../Template/CreateFolder.aspx">模板管理</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;
         </td>
         </tr>
    </table>
    <table width="99%" border=0 cellpadding=2 cellspacing=1 class=border align="center">
      <tbody>
        <tr>
          <td class="bqleft">样式分类名称：</td>
          <td class="bqright"><asp:TextBox ID="txtStyleTypeName" runat="server" Width="40%" MaxLength="200"></asp:TextBox>                                  </td>
        </tr>
        <tr>
          <td align=right class="bqleft" style="height: 25px">所属分类：</td>
          <td class="bqright" style="height: 25px">
                <asp:DropDownList ID="dropType" runat="server">
                </asp:DropDownList>&nbsp;<asp:Label ID="Label1" runat="server" Text="注意：添加样式的层数最好不要超过两层" ForeColor="Red" ></asp:Label>                                                              
          </td>
        </tr>
        <tr>
          <td align=right  class="bqleft">说明：</td>
          <td class="bqright"><asp:TextBox ID="txtExplain" TextMode="multiLine" Rows="6" Columns="60" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
          <td height="29" colspan="2" align=center>
              <asp:Button ID="btnSave" CssClass="btn" runat="server" Text="保存创建" OnClick="btnSave_Click" OnClientClick="return CheckValidate()" /> 
              <asp:Button ID="btnReset" CssClass="btn" runat="server" Text="重新填写" OnClick="btnReset_Click" />
        </tr>
      </tbody>
    </table>
    </div>

<div id="modelMenuList" style="display:none;position:absolute;top:0px; margin-top:66px; margin-left:190px; width:100px; padding:0px;" class="wzlist border" onmouseout="ShowModelList()">
		<div style="width:100%; height:100%; padding:0px;">
			<iframe src="IframeModelItem.aspx" frameborder="0" scrolling="no" width="100%"></iframe>
		</div>
	</div>
    </form>
</body>
</html>
