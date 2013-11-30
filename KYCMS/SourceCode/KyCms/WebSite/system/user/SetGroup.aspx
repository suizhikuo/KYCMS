<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetGroup.aspx.cs" Inherits="System_user_SetGroup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link href="../css/default.css" type="text/css" rel="stylesheet" />
    <script src="../../JS/Common.js" type="text/javascript"></script>
<script language='javascript' type="text/javascript">
var tID=0;
function ShowTabs(ID)
{

  if(ID!=tID)
  {
    document.all.TabTitle[tID].className='title5';
    document.all.TabTitle[ID].className='title6';
    document.all.Tabs[tID].style.display='none';
    document.all.Tabs[ID].style.display='';
    tID=ID;
  }
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr class="tdbg">
                <td width="99%" height="24" align="left">
                    &nbsp;&nbsp;<a href="GroupList.aspx">组管理首页</a> | 添加用户组
                </td>
                
            </tr>
        </table>
<!-- 头部结束 -->

<!-- 菜单开始 -->

<TABLE cellSpacing="0" cellPadding="0" width="99%" align="center" border="0" class="cd">
  <TBODY>
  <TR align="center">
    <TD id=TabTitle class="title6" onclick=ShowTabs(0)>分组信息</TD>
    <TD id=TabTitle class="title5" onclick=ShowTabs(1)>权限基本设置</TD>
   <TD id=TabTitle class="title5" onclick=ShowTabs(2)>财富空间</TD>
   <TD id=TabTitle class="title5" onclick=ShowTabs(3)>博客权限</TD>
   <TD id=TabTitle class="title5" onclick=ShowTabs(4)>圈子权限</TD>
   <TD id=TabTitle class="title5" onclick=ShowTabs(5)>频道权限</TD> 
   <TD id=TabTitle class="title5" onclick=ShowTabs(6)>论坛权限</TD>
    <TD>&nbsp;</TD></TR></TBODY></TABLE>
<!-- 菜单结束 -->
        <div align="center">
            <table class="editborder" cellspacing="1" cellpadding="0" width="99%" border="0">
                <tbody id="Tabs">
                    <tr class="tdbg">
                        <td class="bqleft">
                            组名称：
                        </td>
                        <td class="bqright">
                        <asp:TextBox ID="txtGroupName" runat="server" ></asp:TextBox>
                            </td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            组类型：
                        </td>
                        <td class="bqright">
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="133px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            组描述信息：
                        </td>
                        <td class="bqright">
                            <asp:TextBox ID="txtGroupDescription" runat="server" Width="273px"></asp:TextBox></td>
                    </tr>  
                   <tbody id="Tabs" style="display: none">
                     <tr>
	               <td class="bqleft">发布权限：</td>
                   <td class="bqright">

                   <asp:TextBox ID="asd" runat="server"></asp:TextBox>
                    倍</td>
                    </tr>
 </TBODY>
 
<!-- 财富空间权限 -->
        <TBODY id="Tabs" style="display: none">
          <tr>
           <td rowspan="2" class="bqleft">会员组自动升级：</td>
           <td class="bqright">
        </td>
          </tr>
         </TBODY>
 
<!-- 博客权限 -->
           <TBODY id="Tabs" style="display: none">
          <tr> <td class="bqleft">博客权限：</td>
            <td class="bqright">购物时可以享受的折扣率：
           </td>
         </tr>
         </TBODY>
 
 
 <!-- 圈子权限 -->
           <TBODY id="Tabs" style="display: none">
            <tr>
           <td rowspan="2" class="bqleft">允许创建圈子：</td>
           <td class="bqright">
               &nbsp;是
          
        否</td>
         </tr>
         </TBODY>
 

<!-- 频道权限 -->
           <TBODY id="Tabs" style="display: none">
          <tr> <td class="bqleft">频道权限：</td>
            <td class="bqright">购物时可以享受的折扣率：
             </td>
         </tr>
         </TBODY>

<!-- 论坛权限 -->
           <TBODY id="Tabs" style="display: none">
          <tr> <td class="bqleft">论坛权限：</td>
            <td class="bqright">对不起，您的网站还没有整个论坛！ 推荐整合“心动论坛”！</td>
         </tr>
        </tbody>
        <tfoot>
        <tr>
            <td colspan="2"><asp:Button ID="btnSetGroup" Text="确定" runat="server" CssClass="btn" /></td>
        </tr>
        </tfoot> 
        </table>
    </div>
    </form>
</body>
</html>
