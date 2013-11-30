<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetLabelCategory.aspx.cs" Inherits="System_AddLabelType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加与修改标签样式分类</title>
    <link rel="stylesheet" href="../css/default.css" type="text/css" />
    <style type="text/css">
    <!--
    .STYLE1 {color: #FF0000}
    .STYLE2 {color: #0000FF}
    -->
    </style>
   <script language="Javascript" type="TEXT/JAVASCRIPT" src="../../js/Common.js"></script>
   <script language="Javascript" typE="Text/javascript">
   			function CheckValidate()
			{
                if($("txtLabelTypeName").value.trim().length==0)
               {
                    alert("标签名称必须填写");
                    $("txtLabelTypeName").focus();
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
				<td height="24" width=20><img src="../images/skin/default/you.gif" align=absmiddle /></td>
				<td align=left style="padding-top:3px;" >您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="../template/CreateFolder.aspx">标签&模板管理</a> >> <a href="LabelManager.aspx"> 标签管理</a> >> 新增标签分类</td>
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
    
        <table width="99%" border=0 cellpadding=2 cellspacing=1 class=border align="center">
          <tbody>
            <tr>
              <td class="bqleft">标签分类名称：</td>
              <td class="bqright"><asp:TextBox ID="txtLabelTypeName" runat="server" Width="40%" MaxLength="200"></asp:TextBox>                                  </td>
            </tr>
            <tr>
              <td align=right class="bqleft">所属分类：</td>
              <td class="bqright" valign="middle">
                  <asp:DropDownList ID="dropLabelType" runat="server">
                  </asp:DropDownList>&nbsp;<asp:Label ID="Label1" runat="server" Text="注意：添加标签的层数最好不要超过两层" ForeColor="Red"></asp:Label>                                                                    
              </td>
            </tr>
            <tr>
              <td align=right  class="bqleft">说明：</td>
              <td class="bqright"><asp:TextBox ID="txtExplain" TextMode="multiLine" Rows="6" Columns="50" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
              <td height="29" colspan="2" align=center>
                  <asp:Button ID="btnSave" CssClass="btn" runat="server" Text="保存创建" OnClick="btnSave_Click" OnClientClick="return CheckValidate()" /> 
                  <asp:Button ID="btnReset" CssClass="btn" runat="server" Text="重新填写" OnClick="btnReset_Click" /></td>
            </tr>
          </tbody>
        </table>

    </div>
    </form>
</body>
</html>
