<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateFolder.aspx.cs" Inherits="System_TemplateList_CreateFolder" %>
<%@ Import Namespace="Ky.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>创建目录</title>
    <link rel="stylesheet" href="../css/default.css" type="text/css" />
    <script type="text/javascript" src="../../js/Common.js"></script> 
    <script type="text/javascript" src="../../js/SelectFile.js"></script>
	<script language="javascript" type="text/javascript">
		function setx(result)
		{
			if(result==null)
			{
				result="";
			}
			window.location.href="CreateFolder.aspx"+result;
		}
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
			<tr>
				<td height="24" width=20><img src="../images/skin/default/you.gif" align="absmiddle" /></td>
				<td align="left" style="padding-top:3px;" >
					您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="CreateFolder.aspx">标签&模板管理</a> >>  列表
				</td>
				<td width="50" align="right"><img src="../images/skin/default/help.gif" align="absmiddle" /></td>
			</tr>
		</table>
        <!--top-->    
         <table width="99%" cellspacing="1" cellpadding="0"  class="border" align="center">
            <tr class="wzlist">
				<td align="left">
					<a href="CreateFolder.aspx">模板管理</a> | 
					<a href="../Label/LabelManager.aspx">标签管理</a> | 
					<a href="../Label/StyleManager.aspx">样式管理</a>  | 
					<a  href="#" onclick="javascript:window.history.back();">返 回</a>
				</td>
			</tr>
        </table>
        <!--endtop-->
        <!--body-->
        <table width="600px" cellpadding="2" border="0" cellspacing="1" class="border" align="center">
            <asp:Repeater ID="repFile" runat="server" OnItemCommand="repFileReName_ItemCommand">
                <HeaderTemplate>
                    <tr class="title"><td width="20%">名称</td><td width="20%">大小</td><td width="25%">修改时间</td><td>操作</td></tr>
                </HeaderTemplate>
                
                <ItemTemplate>
                    <tr value="<%#Eval("Path")%>|<%#Eval("Type")%>" class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <a onclick='<%#GetScriptStr(Eval("Path"),Eval("Type"),Eval("Name"))%>'>
							<td class="mouseStyle" align="left"><%#GetFileTypeIco(Eval("Type"))%> 
								<asp:Label ID="lblFileName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
							</td>
							<td class="mouseStyle;"> <%#Eval("Size") %><span style="color:#F00;">byte</span></td>
							<td align="center" class="mouseStyle"><%#Eval("UpdateTime")%></td>
						</a>
							<td align="left">&nbsp;
								<a href="#"  onclick="WinOpenDialog('SetDirectory.aspx?fileName=<%# Function.UrlEncode(Eval("Name").ToString()) %>&DirPath=<%=Function.UrlEncode(DirPath) %>&rePath=<%=Server.UrlEncode(rePath) %>','502','123')">改名</a> | 
								<asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('你确认要删除吗？')" >删除</asp:LinkButton><%#GetFileType(Eval("Type"),Eval("Name")) %>
							</td>                       
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center">
            <tr class="tdbg">
				<td width="20%" align="left">目录名称：</td>
				<td align="left" width="25%"><asp:TextBox ID="txtForderName" runat="server" Width="200"></asp:TextBox></td>
				<td align="left" width="15%"><asp:Button ID="btnCreateFolder" runat="server" Text="创建目录"  OnClick="btnCreateFolder_Click" CssClass="btn" /></td>
				<td width="30%"><asp:FileUpload ID="fileUploadTemplate" runat="server" CssClass="btn"  /></td>
				<td width="10%"><asp:Button ID="btnTemplateUpLoad" runat="server" Text="上传模板" OnClick="btnTemplateUpLoad_Click"  CssClass="btn"  /></td>
			</tr>
        </table>
        <!--endbody-->   
    </div>
   </form>
</body>
</html>
