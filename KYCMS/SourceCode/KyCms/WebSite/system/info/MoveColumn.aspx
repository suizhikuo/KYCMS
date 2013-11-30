<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MoveColumn.aspx.cs" Inherits="system_news_Move" EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>移动栏目</title>
   <link href="../Css/default.css" type="text/css" rel="stylesheet" /> 
   <script language="javascript" type="text/javascript" src="../../js/Common.js"></script>
   
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" class="wzdh" style="width: 99%" align="center">
        <tr>
            <td width="27" height="24">
                &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16"></td>
             <td><a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href='ChannelList.aspx'>频道管理</a>  &gt;&gt; 移动栏目</td>
        </tr>
    </table>
       <table cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
       <tr>
            <td width="40%" align="center">
                <asp:ListBox ID="lsbColumnLeft" runat="server" Height="400px" Width="300px"></asp:ListBox></td>
               <td align="center">
                   <asp:Button ID="btnMove" runat="server" CssClass="btn" Height="30px" OnClick="btnMove_Click" OnClientClick="return CheckValidate();"
                       Text="移动 ->>" Width="65px" /></td> 
            <td width="40%" align="center">
                <asp:ListBox ID="lsbColumnRight" runat="server" Height="400px" Width="300px"></asp:ListBox></td> 
       </tr>
       </table> 
        
    
    </form>
</body>
</html>
<script type="text/javascript">
function CheckValidate()
{
   var selectColId = "";
   selectColId = $("lsbColumnLeft").value;
   if(selectColId.length==0)
   {
       alert("请选择要移动的栏目");
       return false; 
   }
   if(selectColId==0)
   {
       alert("频道不能移动");
       return false; 
   }
   var targetId = "";
   targetId = $("lsbColumnRight").value;
   if(targetId.length==0)
   {
        alert("请选择目标频道/栏目");
       return false; 
   }
   if(targetId.indexOf("$")==-1)
   {
        if(selectColId.indexOf("|"+targetId+"|")!=-1)
       {
             alert("目标栏目不能是所选移动栏目或其子栏目");
             return false; 
       } 
   }
    
   return true;
}
</script>