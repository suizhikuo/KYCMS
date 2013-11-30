<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogList.aspx.cs" Inherits="System_user_LogList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Ky.BLL" %>
<%@ Import Namespace="Ky.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>操作日志</title>
    <link href="../css/default.css" rel="stylesheet" type="text/css" /> 
    <script type="text/javascript" src="../../js/Common.js"></script> 
   <script type="text/javascript" src="../../js/RiQi.js"></script> 
   <script type="text/javascript">
function CheckValidate()
{
   var dayCount = $('txtDayCount').value.trim();
   if(!CheckNumberNotZero(dayCount))
   {
       alert("清理日志的天数必须为整正数");
       return false;
   }
   if(confirm('你确认要清理'+dayCount+'天前的日志记录吗?'))
   {
        return true;
   }
   else
   {
        return false;
   }
}
   </script> 
</head>
<body><form id="form1" runat="server">
      
     <table width="99%" border="0" cellpadding="1" cellspacing="0" class="wzdh" align="center">
     <tr>
     <td width="27" height="20">&nbsp;<img src="../images/skin/default/you.gif" width="17" height="16"/></td>
     <td >您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; 日志管理</td>
     </tr>
     </table>
     <table class="border" cellpadding="0" cellspacing="1" align="center">
     <tr>
        <td>
        操作类型：<asp:DropDownList ID="ddlLogType" runat="server">            
        <asp:ListItem Value="0" Text="所有类型"></asp:ListItem>
        <asp:ListItem Value="1" Text="登陆/退出"></asp:ListItem>
         <asp:ListItem Value="2" Text="添加操作"></asp:ListItem>
        <asp:ListItem Value="3" Text="修改操作"></asp:ListItem>
        <asp:ListItem Value="4" Text="清除操作"></asp:ListItem> 
        </asp:DropDownList>
        操作者：<asp:TextBox ID="txtUserName" runat="server" Width="75" MaxLength="20"></asp:TextBox>
        起始日期：<asp:TextBox ID="txtStartTime" runat="server" Width="60"  MaxLength="10" Columns="10" onblur="setday(this);" onclick="setday(this);" ></asp:TextBox>
        截止日期：<asp:TextBox ID="txtEndTime" runat="server" Width="60" MaxLength="10" Columns="10" onblur="setday(this);" onclick="setday(this);" ></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text=" 查询" CssClass="btn" OnClick="btnSearch_Click" />
       </td><td align="right">
         清理
            <asp:TextBox ID="txtDayCount" runat="server" Width="50" MaxLength="5"></asp:TextBox>
            天前的日志 <asp:Button ID="btnClear" runat="server" CssClass="btn" OnClick="btnClear_Click" OnClientClick="return CheckValidate()"
                Text="清理" /></td> 
     </tr> 
     </table> 
    <table class="border" cellpadding="0" cellspacing="1" align="center">
    <asp:Repeater ID="repLog" runat="server">
    <HeaderTemplate>
        <tr class="title">
              <td width="6%">编号</td>
              <td width="10%">操作者</td>
              <td width="30%">操作描述</td>
              <td width="15%">IP地址</td>
              <td width="16%">操作时间</td>
              <td width="7%">操作类型</td>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="tdbg" onMouseOver="this.className='tdbgmouseover'" onMouseOut="this.className='tdbg'">
              <td><%#Eval("LogId") %></td>
              <td><%#Eval("UserName") %></td>
              <td align="left">&nbsp;<%#Function.HtmlEncode(Eval("Description")) %></td>
              <td><%#Eval("IpAddress") %></td>
              <td><%#Eval("LogTime","{0:yyyy-MM-dd HH:mm:ss}") %></td>
              <td><%#B_Log.GetNameByLogType(Eval("LogType"))%></td>
        </tr>
    </ItemTemplate> 
    </asp:Repeater>
    </table>
       <table cellpadding="0" cellspacing="1" class="border" align="center" width="99%">
        <tr>
            <td>
               <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" FirstPageText="首页"
               LastPageText="尾页" NextPageText="下一页"  PageSize="20" HorizontalAlign="Right"  PrevPageText="上一页" ShowInputBox="Never" ShowCustomInfoSection="Left" Width="99%" OnPageChanging="Pager_PageChanging">
        </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>  
    </form>
   <asp:Literal ID="litMsg" runat="server"></asp:Literal> 
</body>
</html>
