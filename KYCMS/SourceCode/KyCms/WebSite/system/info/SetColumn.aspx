<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetColumn.aspx.cs" Inherits="System_ColumnManage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>栏目设置</title>
<link href="../Css/default.css" type="text/css" rel="stylesheet">
<script src="../../JS/Common.js" type="text/javascript"></script>
<script src="../../js/XmlHttp.js" type="text/javascript"></script>

</head>
<body onload="SetChildSite()">

 <table width="99%" border="0" cellpadding="1" cellspacing="2" class="wzdh" align="center">
 <tr>
     <td width="27" height="20">
         &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" alt="" /></td>
     <td>
         您现在的位置： <a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href="ChannelList.aspx">频道管理</a> &gt;&gt; <asp:HyperLink ID="hyperColumnNav" runat="server"></asp:HyperLink> &gt;&gt; <asp:Literal ID="litNav" runat="server"></asp:Literal></td>
 </tr>
</table>

           <TABLE cellSpacing="0" cellPadding="0" width="99%" align="center" border="0" class="cd">
           <tbody>
                <tr align='center'>
                    <td id='TabTitle0' onclick=ShowTabs(0) class="title6">基本设置</td>
                    <td id='TabTitle1' onclick=ShowTabs(1) class="title5">页面设置</td>
                    <td id='TabTitle2' onclick=ShowTabs(2) class="title5">收费设置</td> 
                     <td>&nbsp;</td>              
                </tr></tbody>
            </table>
             <form id="Form1" runat=server>
          <table class="editborder" cellspacing="1" cellpadding="0" width="99%" border="0" align="center">
                <tbody id="Tabs0">
                    <tr id="ColParentId">
                        <td class="bqleft" >
                           所属栏目：</td>
                        <td class="bqright">
                            <asp:DropDownList ID="ddlColumn" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="bqleft" >
                            栏目中文名：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtColName" runat="server" Width="186px" MaxLength="50" ></asp:TextBox> <font color="red">*&nbsp;<a href="#" onclick='GetPinYin()' >自动设置英文名</a></font>
                            </td>
                    </tr>
                    <tr>
                        <td class="bqleft" >
                            栏目英文名：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtColDirName" runat="server" Width="186px" MaxLength="50"></asp:TextBox> <font color="red">*</font> 以字母开头，由字母和数字组成</td>
                    </tr>
                    <tr>
                        <td class="bqleft" >
                            是否是外部栏目：</td>
                        <td class="bqright">
                            <asp:RadioButton ID="rbIsOuterColumn0" runat="server" GroupName="IsOuterColumn"
                                Text="内部栏目" onclick="SetChildSite()" Checked="True" />
                            &nbsp;  
                            <asp:RadioButton ID="rbIsOuterColumn1"  runat="server" GroupName="IsOuterColumn" Text="外部栏目" onclick="SetChildSite()" /></td>
                    </tr>
                    <tr id="trOuterColumnUrl" runat="server" style="display:none">
                        <td class="bqleft" >
                            外部栏目链接地址：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtOuterColumnUrl" runat="server" Width="290px" MaxLength="255"></asp:TextBox> <font color="red">*</font> (如:www.baidu.com)</td>
                    </tr>
               
                             <tr>
                        <td class="bqleft" >
                            栏目页模板：</td>
                        <td class="bqright">
                           <asp:TextBox ID="txtColumnTemplatePath" runat="server" Width="290px"></asp:TextBox>
                        <input type="button" value="选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtColumnTemplatePath')+'&StartPath='+escape('/Template'),650,480)" class="btn"/> <font color="red">*</font></td>
                    </tr>
                    <tr>
                        <td class="bqleft" >
                            内容页模板：</td>
                        <td class="bqright">
                       <asp:TextBox ID="txtInfoTemplatePath" runat="server" Width="290px"></asp:TextBox>
                        <input  type="button" value="选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtInfoTemplatePath')+'&StartPath='+escape('/Template'),650,480)" class="btn"/> <font color="red">*</font></td>
                    </tr>
                    <tr>
                        <td class="bqleft" >
                            评论页模板：</td>
                        <td class="bqright">
                        <asp:TextBox ID="txtCommentTemplatePath" runat="server" Width="290px"></asp:TextBox>
                        <input type="button" value="选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtCommentTemplatePath')+'&StartPath='+escape('/Template'),650,480)" class="btn"/> <font color="red">*</font></td>
                    </tr>  
                    <tr>
                        <td class="bqleft">
                            栏目页扩展名：</td>
                        <td class="bqright">
                        <asp:RadioButtonList ID="rblColumnPageType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Text=".html" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="2" Text=".htm"></asp:ListItem>
                            <asp:ListItem Value="3" Text=".shtml"></asp:ListItem>
                            <asp:ListItem Value="4" Text=".aspx"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            内容页扩展名：</td>
                        <td class="bqright">
                        <asp:RadioButtonList ID="rblInfoPageType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Text=".html" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="2" Text=".htm"></asp:ListItem>
                            <asp:ListItem Value="3" Text=".shtml"></asp:ListItem>
                            <asp:ListItem Value="4" Text=".aspx"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                       <tr>
                        <td class="bqleft" >
                            栏目图片地址：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtColumnImgPath" runat="server" Width="290px" MaxLength="255"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="bqleft" >
                            栏目说明：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="290px"></asp:TextBox></td>
                    </tr>
                </tbody>
                <tbody id="Tabs1" style="display: none">
                    
                    <tr>
                        <td class="bqleft" >
                            有子栏目时是否允许添加内容：</td>
                        <td class="bqright">
                         <asp:RadioButtonList ID="rblIsAllowAddInfo" runat="server" CellPadding="0" CellSpacing="0"
                                RepeatDirection="Horizontal" Width="125px">
                                <asp:ListItem Value="True" >允许</asp:ListItem>
                                <asp:ListItem Value="False" Selected="True">不允许</asp:ListItem>
                            </asp:RadioButtonList>
                         </td>
                    </tr>
                            <tr>
                        <td class="bqleft" >
                            栏目排序编号：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtSort" runat="server" Width="46px" Text="10" MaxLength="10"></asp:TextBox> <font color="red">*</font>
                            </td>
                        </tr>
                    <tr>
                        <td class="bqleft" >
                            是否允许发表评论：</td>
                        <td class="bqright">
                        <asp:RadioButtonList ID="rblIsAllowComment" runat="server" CellPadding="0" CellSpacing="0"
                                RepeatDirection="Horizontal" Width="125px">
                                <asp:ListItem Value="True" Selected="True">允许</asp:ListItem>
                                <asp:ListItem Value="False">不允许</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="bqleft" >
                            评论是否需要审核：</td>
                        <td class="bqright">
                         <asp:RadioButtonList ID="rblIsCheckComment" runat="server" CellPadding="0" CellSpacing="0"
                                RepeatDirection="Horizontal" Width="125px">
                                <asp:ListItem Value="True">审核</asp:ListItem>
                                <asp:ListItem Value="False"  Selected="True">不审核</asp:ListItem>
                            </asp:RadioButtonList>
                         </td>
                    </tr>
                      <tr>
                        <td class="bqleft" >
                            栏目META关键词：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtKeyword" runat="server" TextMode="MultiLine" Width="290px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="bqleft" >
                            栏目META网页描述：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="290px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="bqleft" >
                            栏目访问权限：</td>
                        <td class="bqright">
                         <asp:RadioButtonList ID="rblIsOpened" runat="server" CellPadding="0" CellSpacing="0"
                                RepeatDirection="Horizontal" Width="121px">
                                <asp:ListItem Value="True" Selected="True">开放</asp:ListItem>
                                <asp:ListItem Value="False">认证</asp:ListItem>
                            </asp:RadioButtonList>
                         </td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            允许查看的会员组：</td>
                        <td class="bqright">
                            <asp:CheckBoxList ID="cblGroupIdStr2" runat="server"  RepeatDirection="Horizontal">
                            </asp:CheckBoxList>
                            &nbsp;[当栏目设置为认证时有效]</td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            允许浏览内容的会员组：</td>
                        <td class="bqright">
                         <asp:CheckBoxList ID="cblGroupIdStr1" runat="server"  RepeatDirection="Horizontal">
                            </asp:CheckBoxList>
                            &nbsp;[当栏目设置为认证时有效]
                        </td>
                    </tr>
                  
                    <tr>
                        <td class="bqleft">
                            允许录入的会员组：</td>
                        <td class="bqright">
                        <asp:CheckBoxList ID="cblGroupIdStr3" runat="server"  RepeatDirection="Horizontal">
                            </asp:CheckBoxList>
                           
                        </td>
                    </tr>
                    <tr>
                </tbody>
    
                <tbody id="Tabs2" style="display: none">
                    <tr>
                        <td class="bqleft" >
                            积分奖励：</td>
                        <td class="bqright">
                         <asp:TextBox ID="txtScoreReward" runat="server" Width="60px" Text="0" MaxLength="10"></asp:TextBox>分&nbsp;(发一条内容获得多少积分)
                        </td>
                    </tr>
                    <tr>
                        <td class="bqleft" >
                            收费点数：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtPointCount" runat="server" Width="60px" Text="0" MaxLength="10"></asp:TextBox>点</td>
                    </tr>
                    <tr>
                        <td class="bqleft" >
                            重复收费方式：</td>
                        <td class="bqright">
                            <asp:RadioButton ID="rbChargeType1" runat="server" GroupName="PayMoney" Text="不重复收费" Checked="True" />
                            <br />
                            <asp:RadioButton ID="rbChargeType2" runat="server" GroupName="PayMoney"
                                Text="距离上次收费时间" /><asp:TextBox ID="txtChargeHourCount" runat="server" Width="34px" Text="24" MaxLength="5"></asp:TextBox>小时后收费<br />
                            <asp:RadioButton ID="rbChargeType3" runat="server" GroupName="PayMoney"
                                Text="会员重复浏览此内容" /><asp:TextBox ID="txtChargeViewCount" runat="server" Width="23px" Text="10" MaxLength="5"></asp:TextBox>次后重新收费<br />
                            <asp:RadioButton ID="rbChargeType4" runat="server" Text="上述两者都满足时重新收费" GroupName="PayMoney" /><br />
                            <asp:RadioButton ID="rbChargeType5" runat="server" Text="上述两者任一个满足时就重新收费" GroupName="PayMoney" /><br />
                            <asp:RadioButton ID="rbChargeType6" runat="server" Text="每阅读一次就重复收费一次（建议不要使用）" GroupName="PayMoney" /></td>
                    </tr>
                   
                    </tbody>
                <tfoot>
                <tr>
                    <td colspan="2" align="center" style="height: 30px">
                        <asp:Button ID="btnOK" runat="server" Text="确 定"  OnClientClick="return CheckValidate()" CssClass="btn" OnClick="btnOK_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input
                            id="Reset1" type="reset" value="取消" class="btn" onclick="javascript:history.back()" /></td>
                </tr>
                </tfoot>
            </table>
    </form>
   <asp:Literal ID="litMsg" runat="server"></asp:Literal> 
</body>
</html>
<script language="javascript" type="text/javascript">

 function SetChildSite()
{
    if($("rbIsOuterColumn0").checked)
    {
        $("trOuterColumnUrl").style.display = "none";
    }
    else
    {
        $("trOuterColumnUrl").style.display = "";
    }
}
   
function CheckValidate()
{
     var colIdStr = '<asp:Literal ID="litColIdStr" runat="server"></asp:Literal>';
     var colId = "|"+$('ddlColumn').value+"|";
     if(colIdStr.indexOf(colId)!=-1)
    {
         alert("所属栏目不能为当前栏目或子栏目");
         return false; 
    }  
     if($("txtColName").value.trim().length==0)
    {
        alert("栏目名称必须填写");
        return false;
    }
   var dirName = $("txtColDirName").value.trim();
   var patt = /^[a-zA-Z][0-9a-zA-Z]*$/
   if(!patt.test(dirName))
   {
       alert("栏目英文名必须以字母开头，必须是字母和数字组成");
       return false; 
   }

   if($("rbIsOuterColumn1").checked&&$("txtOuterColumnUrl").value.trim().length==0)
   {
       alert('设置栏目为外部栏目，外部链接地址必须填写');
       return false; 
   }
   if($("txtColumnTemplatePath").value.trim().length==0)
   {
        alert("栏目页模板必须选择");
       return false; 
   }
   if($("txtInfoTemplatePath").value.trim().length==0)
   {
       alert("内容页模板必须选择");
       return false ;
   }
   if($("txtCommentTemplatePath").value.trim().length==0)
   {
       alert("评论页模板必须选择");
       return false; 
   }
   if($("txtDescription").value.trim().length>255)
   {
       alert("栏目描述不能超过255个字");
       return false; 
   }
   
   if(!CheckNumber($("txtSort").value.trim()))
   {
        alert("栏目排序编号必须是0或者正整数");
        return false; 
   } 
   
   if($("txtKeyword").value.trim().length>100)
   {
       alert("栏目META关键字不能超过100个字");
       return false; 
   }
   
   if($("txtContent").value.trim().length>300)
   {
       alert("栏目META网页描述不能超过300个字");
       return false; 
   }

   if(!CheckNumber($("txtScoreReward").value.trim()))
   {
        alert("积分奖励必须为0或正整数");
        return false; 
   }
   if(!CheckNumber($("txtPointCount").value.trim()))
   {
        alert("收费点数必须是0或正整数");
        return false; 
   }

   if(($("rbChargeType4").checked||$("rbChargeType5").checked||$("rbChargeType2").checked)&&!CheckNumber($("txtChargeHourCount").value.trim()))
   {
        alert("重复收费时间必须是0或正整数");
        return false; 
   }
   if(($("rbChargeType4").checked||$("rbChargeType5").checked||$("rbChargeType3").checked)&&!CheckNumber($("txtChargeViewCount").value.trim()))
   {
        alert("重复收费浏览次数必须是0或正整数");
        return false; 
   }  

   return true;
}
function GetPinYin()
{
    if(<%=ColumnId %>==0)
     System_ColumnManage.GetPinYin(document.getElementById("txtColName").value,CallBack) ;
}


function CallBack(result)
{
   
   $('txtColDirName').value = result.value;
}
</script>
