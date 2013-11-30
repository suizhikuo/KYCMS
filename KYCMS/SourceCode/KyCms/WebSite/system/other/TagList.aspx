<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TagList.aspx.cs" Inherits="System_Tag_TagList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Ky.Common" %>
<%@ Import Namespace="Ky.BLL" %>


<script type="text/javascript" src="../../js/Common.js"></script>

<script type="text/javascript">
function AlertClear()
{
   var searchCount = $('txtSearchCount').value.trim();
   if(!CheckNumberNotZero(searchCount))
   {
        alert('清理关键字搜索次数的条件必须为正整数') ;
       return false; 
   }
  
   if(confirm('你确认要清理搜索次数小于'+searchCount+'次的关键字吗?'))
   {
        return true;
   }
   else
   {
        return false;
   }
}
function CheckValidate()
{
    if($("txtTagName").value.trim().length==0)
   {
        alert("关键字名称必须填写");
       return false; 
   }
   return true; 
}
</script>
<html>
<head runat="server">
    <title>TAG管理</title>
    <link href="../css/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
         <table width="99%" border="0" cellpadding="1" cellspacing="0" class="wzdh" align="center">
 <tr>
     <td width="27" height="20">
         &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" alt="" /></td>
     <td>
         您现在的位置： <a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; 关键字管理</td>
 </tr>
</table>  
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="1" class="border" align="center" width="99%">
        <tr>
            <td>
                 关键字名称：<asp:TextBox ID="txtTagName" runat="server" MaxLength="20" Columns="5"></asp:TextBox>
                 所属类别：<asp:DropDownList ID="ddlTagCategoryId" runat="server"></asp:DropDownList>
                 所属系统：<asp:DropDownList ID="ddlModelType" runat="server"></asp:DropDownList>
                 <asp:Button ID="btnSubmit" runat="server" CssClass="btn" OnClick="btnSubmit_Click" OnClientClick="return CheckValidate()" Text="添加关键字" /></td>
             <td align="right"> 清理搜索次数小于<asp:TextBox ID="txtSearchCount" runat="server" MaxLength="10" Width="30px"></asp:TextBox>
                次的关键字
                <asp:Button ID="btnClear" runat="server" CssClass="btn" OnClick="btnClear_Click" OnClientClick="return AlertClear()"
                    Text=" 清理 " />
                    </td>
                </tr>
    </table> 
    <table cellpadding="0" cellspacing="1" class="border" align="center" onmouseover="if(event.srcElement.parentElement.tagName=='TR')event.srcElement.parentElement.className='tdbgmouseover';"    onmouseout="if(event.srcElement.parentElement.tagName=='TR')event.srcElement.parentElement.className='tdbg';">
   <asp:Repeater ID="repTag" runat="server" EnableViewState="false">
   <HeaderTemplate>
        <tr class="title">
            <td width="30%">关键字名称</td>
            <td width="10%">关键字类别</td>
            <td width="10%">所属模块</td> 
            <td width="10%">昨日搜索次数</td>
            <td width="10%">今日搜索次数</td>
            <td width="15%">总搜索次数</td>
            <td width="15%">添加者</td>
        </tr>
   </HeaderTemplate>
   <ItemTemplate>
        <tr class="tdbg" >
          <td><%# Function.HtmlEncode(Eval("TagName"))%></td>
          <td><%# Eval("TagCategoryName")%></td>
          <td><%# Eval("ModelName")%></td>
          <td><%# Eval("YesterdaySearchCount")%></td>
          <td><%# Eval("DaySearchCount")%></td>
          <td><%# Eval("TotalSearchCount")%></td>
          <td><%# Function.HtmlEncode(Eval("UserName"))%></td>
        </tr>
    </ItemTemplate> 
   </asp:Repeater>
    </table>
   <table cellpadding="0" cellspacing="1" class="border" align="center" width="99%">
        <tr>
            <td>
               <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" FirstPageText="首页"
               LastPageText="尾页" NextPageText="下一页"  PageSize="20" HorizontalAlign="Right"  PrevPageText="上一页" ShowInputBox="Never" UrlPageIndexName="p" UrlPaging="True" ShowCustomInfoSection="Left" Width="99%">
        </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>  
        
    </form>
   <asp:Literal ID="LitMsg" runat="server"></asp:Literal> 
</body>
</html>
