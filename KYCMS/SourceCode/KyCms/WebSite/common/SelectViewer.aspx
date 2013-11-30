<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectViewer.aspx.cs" Inherits="common_SelectViewer" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>选择签收用户</title>
    <link href="../user/css/default.css" type="text/css" rel="stylesheet" />
    <base target="_self"/>
    <script type="text/javascript" src="../js/Common.js"></script>
<script type="text/javascript" language="javascript">
    function Insert(val,UserId)
   {
       var tmp="";
        if(val!="")
        {
            tmp=window.dialogArguments.$(val).value;
            array=tmp.split('|');
            for(var i=0;i<array.length;i++)
            {
                if(array[i]==$("Text_"+UserId).value)
               {
                    return;
               } 
            }
            if(tmp.length==0)
            window.dialogArguments.$(val).value+=$("Text_"+UserId).value;
            else
            window.dialogArguments.$(val).value+="|"+$("Text_"+UserId).value;
            
        }
        else
        {
            alert("非法操作");
        }
   } 
 </script>
</head>
<body>
    <form id="form1" runat="server">
           <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
    <tr>
        <td align=left style="padding-top:3px;" >
            <strong>
            签收用户列表</strong>&nbsp;&nbsp; 搜索用户名<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>&nbsp;<asp:Button
                ID="Button1" runat="server" CssClass="btn" Text="搜 索" OnClick="Button1_Click" /></td>
    </tr>
</table>
<table width="99%" align="center" class="border" cellspacing="1" cellpadding="0" >
<asp:Repeater ID="RepUserList" runat="server" >
    <HeaderTemplate>
         <tr class="title">
            <td>用户名</td>
            <td >所属用户组</td> 
            <td>会员状态</td>
            <td>操作</td>    
        </tr> 
    </HeaderTemplate>
   <ItemTemplate>
        <tr class=tdbg onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
            <td width="17%"><asp:Label Text='<%#Eval("LogName")%>' runat="server" ID="lbLogName"></asp:Label>
            <input  type="text" name="Text_<%#Eval("UserId")%>" value="<%#Eval("LogName")%>" style="display:none" /></td>
            <td width="13%"><%#Eval("UserGroupName")%></td>  
            <td width="8%"><asp:Label ID="lblislock" Text='<%#GetIsLock(Eval("IsLock"))%>' runat="server"></asp:Label></td>
            <td width="8%"><input  type="button" value="插入" onclick="Insert('<%=ControlId %>',<%#Eval("UserId") %>)" class="btn"/></td>
        </tr> 
    </ItemTemplate> 
    </asp:Repeater>
    </table>
    <table cellpadding="0" cellspacing="0"  align="center" width="99%">
        <tr>
            <td align="left" colspan="2">
                &nbsp;&nbsp;
                <webdiyer:AspNetPager ID="AspNetPager" runat="server" AlwaysShow="True" FirstPageText="首页"
               LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager_PageChanging"
               PageSize="10" PrevPageText="上一页"  ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoSectionWidth="10%" ShowNavigationToolTip="True" Width="99%" HorizontalAlign="Right">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
   <asp:Literal ID="litMsg" runat="server" Visible="false"></asp:Literal>       </form>
</body>
</html>
