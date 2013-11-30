<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectFile.aspx.cs" Inherits="Common_SelectFile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <title>选择页</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/Common.js"></script> 
    <script type="text/javascript" src="../../js/SelectFile.js"></script>
</head>
<body scroll="yes">
    <form id="form1" runat="server"> 
   <table width="600px"  border="0"   cellpadding="0" cellspacing="0" align="center">
   <tr>
   <td width="300px"><asp:HyperLink ID="hyperNav" runat="server" ImageUrl="../../images/ico/up.gif"></asp:HyperLink><a href="javascript:location.href=location.href;" id="btnRe"><img src="../images/ico/reload.gif"  alt="刷新" border="0"/></a><a href=" " onclick="return SetShow('tbUpload')"><img src="../images/ico/addfile.gif"  alt="添加新文件" border="0"  /></a><a href=" " onclick="return SetShow('tbCreate')"><img src="../images/ico/adddir.gif"  alt="创建新文件夹" border="0"  /></a></td>
   <td width="300px" align="right">当前目录:<asp:Label ID="lbCurrentDirPath" runat="server"></asp:Label></td> 
   </tr>
   </table> 
   <table align="center" style="width: 600px;display:none" id="tbUpload">
   <tr>
        <td>上传文件：<input type="file" id="fileUpload" runat="server"  class="btn"/>
            <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="上传" Width="55px" CssClass="btn" /></td>
   </tr>
   </table>
   <table align="center" style="width: 600px;display:none" id="tbCreate">
   <tr>
        <td>新文件夹名称：<asp:TextBox ID="txtDirName" runat="server" Height="14px"></asp:TextBox>
            <asp:Button ID="btnCreate" runat="server" Text="创建" Width="55px" OnClick="btnCreate_Click" CssClass="btn"  /></td>
   </tr>
   </table>
   <table width="600px"cellpadding="2" border="0" cellspacing="1" class="border" align="center">
    <asp:Repeater ID="repFile" runat="server">
   <HeaderTemplate>
        <tr class="title">
           <td width="350px">名称</td>
          <td width="150px">修改时间</td> 
            <td width="100px">类型</td>
        </tr>
   </HeaderTemplate> 
   <ItemTemplate>
        <tr value="<%#Eval("Path")%>|<%#Eval("Type")%>" class="tdbg" style="cursor:hand" onclick='<%#GetScriptStr(Eval("Path"),Eval("Type"),Eval("Name"))%>' onMouseOver="this.className='tdbgmouseover'" onMouseOut="this.className='tdbg'">
            <td><%#Eval("Name")%></td>
           <td align="center"><%#Eval("UpdateTime")%></td> 
            <td class="tc"><%#GetFileTypeIco(Eval("Type"))%></td>
        </tr>
   </ItemTemplate>
    </asp:Repeater>
   </table> 
  
    </form>
   <asp:Literal ID="litMsg" runat="server"></asp:Literal> 
</body>
</html>

