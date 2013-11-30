<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportList.aspx.cs" Inherits="system_other_ReportList" %>
<%@ Import Namespace="Ky.Common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>举报管理</title>
    <link href="../css/default.css" type="text/css" rel="Stylesheet" /> 
   <script type="text/javascript" src="../../JS/Common.js"></script>  
</head>
<body>  
  <form id="form1" runat="server">
<table width="99%" border="0" cellpadding="1" cellspacing="0" class="wzdh" align="center">
 <tr>
     <td width="27" height="20">
         &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" alt="" /></td>
     <td>
         您现在的位置： <a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; 举报管理</td>
 </tr>
</table>  
<table cellpadding="0" cellspacing="1" class="border" align="center" width="99%">
        <tr>
            <td>
             &nbsp;<a href="ReportList.aspx">所有</a> | <a href="ReportList.aspx?Type=0">未处理</a> | <a href="ReportList.aspx?Type=1">已处理</a> | <a href="ReportList.aspx?Type=2">已关闭</a>  
            </td>
           <td align="right">
            <script type="text/javascript">
            function SelectAll()
            { 
                  var s = $("tbReport").getElementsByTagName("INPUT")
                    for(var i=0;i<s.length;i++)
                    {
                        if(s[i].type=="checkbox")
                        {
                            s[i].checked=$("cbAll").checked;
                        }
                    }
            }   
           function CheckSelected()
          {
            var s = $("tbReport").getElementsByTagName("INPUT")
            var flag = false; 
            for(var i=0;i<s.length;i++)
            {
                if(s[i].type=="checkbox"&&s[i].checked)
                {
                    flag = true;
                }
            }
           if(!flag) 
          { 
            alert('请选择要删除的举报记录');
            return false; 
           }
          else
          {
            return confirm('你确定要删除选择的举报记录吗?');
          }  
          }  
            </script> 
           </td> 
        </tr>
    </table>  

    <table cellpadding="0" cellspacing="1" class="border" align="center" id="tbReport">
   <asp:Repeater ID="repReport" runat="server" OnItemCommand="repReport_ItemCommand">
   <HeaderTemplate>
        <tr class="title">
            <td width="5%">选择</td> 
            <td width="5%">编号</td>
            <td width="22%">举报内容</td>
            <td>链接地址</td> 
            <td width="7%">状态</td> 
            <td width="8%">举报用户</td>
            <td width="10%">举报时间</td>
            <td width="18%">操作</td> 
        </tr>
   </HeaderTemplate>
   <ItemTemplate>
        <tr class="tdbg" onMouseOver="this.className='tdbgmouseover'" onMouseOut="this.className='tdbg'">
          <td><asp:CheckBox ID="chk" runat="server" /></td> 
          <td><asp:Literal ID="litId" runat="server" Text='<%# Eval("ReportId")%>'></asp:Literal></td>
          <td align="left"><%# Function.HtmlEncode(Eval("Content"))%></td>
          <td align="left"><a href='<%# Eval("Url")%>' target="_blank"><%# Eval("Url")%></a></td>
          <td><%# GetStatus(Eval("IsComplete"))%></td>
          <td><%# Eval("UserName")%></td>
          <td><%# Eval("AddTime","{0:d}")%></td>
          <td>
          <asp:LinkButton ID="Set" runat="server" CommandName="set" Enabled='<%# GetEnabled(Eval("IsComplete"))%>' CommandArgument='<%# Eval("ReportId")%>' Text="处理"/> |
          <asp:LinkButton ID="Close" runat="server" CommandName="close" Enabled='<%# GetEnabled(Eval("IsComplete"))%>' CommandArgument='<%# Eval("ReportId")%>' Text="关闭"/> |
          <asp:LinkButton ID="Delete" runat="server" CommandName="delete"  CommandArgument='<%# Eval("ReportId")%>' Text="删除" OnClientClick="return confirm('确定要删除该举报信息吗?')"/> 
          </td>
        </tr>
    </ItemTemplate> 
   </asp:Repeater>
   </table>
   <table width="99%" align="center" cellpadding="2" cellspacing="0" border="0">
    <tr>
        <td>
            <input type="checkbox" id="cbAll" onclick="SelectAll()"/><label for="cbAll">全选该页</label> <asp:Button ID="btnDelete" runat="server" Text="批量删除" cssclass="btn" OnClientClick="return CheckSelected();" OnClick="btnDelete_Click"/></td>
    </tr>
   </table>
   </form>
     <table cellpadding="0" cellspacing="1"  align="center" width="99%" border="0">
        <tr>
            <td>
               <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" FirstPageText="首页"
               LastPageText="尾页" NextPageText="下一页"  PageSize="20" HorizontalAlign="Right"  PrevPageText="上一页" ShowInputBox="Never" UrlPageIndexName="p" UrlPaging="True" ShowCustomInfoSection="Left" Width="99%">
        </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>  
</body> 
</html>
