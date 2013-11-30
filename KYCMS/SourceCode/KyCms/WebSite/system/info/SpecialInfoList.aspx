<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SpecialInfoList.aspx.cs" Inherits="System_Info_SpeacilInfoList" %>
<%@ Import Namespace="Ky.Common" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>专题文章</title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />
    <script src="../../js/Common.js" type="text/javascript"></script> 

</head>
<body>
<table width="99%" border="0" cellpadding="1" cellspacing="2" class="wzdh" align="center">
 <tr>
     <td width="27" height="20">
         &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" alt="" /></td>
     <td>
         您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href='SpecialList.aspx'>专题管理</a> &gt;&gt; <asp:Literal runat="server" ID="litSpeacilName"></asp:Literal></td>
 </tr>
</table>  
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="1" class="border" align="center">
    <asp:Repeater ID="RepSpecial" runat="server" EnableViewState="false">
    <HeaderTemplate>
   <tr class="title">
    
    <td width="35%">内容标题</td>
   <td width="10%">所属模型</td>  
    <td width="10%">录入者</td> 
    <td width="10%">点击数</td>
    <td width="15%">属 性</td> 
    <td width="10%">审核状态</td>
    <td width="10%">操 作</td> 
   </tr> 
    </HeaderTemplate> 
    <ItemTemplate>
    <tr class="tdbg" onMouseOver="this.className='tdbgmouseover'" onMouseOut="this.className='tdbg'">
       
       <td align="left"><a href='../preview/PreInfo.aspx?Id=<%#Eval("Id") %>&ModelId=<%#Eval("ModelId") %>' target="_blank"><%#Function.HtmlEncode(Eval("Title")) %></a></td>
       <td><%#Eval("ModelName") %></td> 
       <td><%#Eval("UName") %></td>
       <td><%#Eval("HitCount")%></td>
       <td><%#GetPropertyName(Eval("TitleType"),Eval("IsTop"),Eval("IsRecommend"),Eval("IsFocus"),Eval("IsSideShow")) %></td>
       <td><%#GetStatusName(Eval("Status"))%></td>
       <td width="10%"><a href="javascript:WinOpenDialog('SetSpecialInfo.aspx?Id=<%#Eval("Id") %>&ModelId=<%#Eval("ModelId") %>',350,300)">设置</a></td> 
    </tr>
    </ItemTemplate> 
    </asp:Repeater> 
    </table>
      <table cellpadding="0" cellspacing="0"  align="center" width="99%">
        <tr>
            <td>
               <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" FirstPageText="首页"
               LastPageText="尾页" NextPageText="下一页" 
               PageSize="20" PrevPageText="上一页"  ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoSectionWidth="10%" ShowNavigationToolTip="True" Width="99%" HorizontalAlign="Right" OnPageChanging="Pager_PageChanging">
           </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>   
    </form>
</body>
</html>
