<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetChannel.aspx.cs" Inherits="System_Add_KyChanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../Css/default.css" type="text/css" rel="stylesheet">
<script src="../../JS/Common.js" type="text/javascript"></script>
<title>频道设置</title>
</head>
<body onload="SetChildSite()">
    <form id="form1" runat="server">
 <!-- 头部开始 -->
 <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="ChannelList.aspx">频道管理</a> >> <asp:Literal ID="litNav" runat="server"></asp:Literal></td>
                <td width="50" align="right">
                  </td>
            </tr>
        </table>

<!-- 头部结束 -->

<!-- 菜单开始 -->
<TABLE cellSpacing="0" cellPadding="0" width="99%" align="center" border="0" class="cd" >
  <TBODY>
  <TR align="center">
    <TD id="TabTitle0" class="title6" onclick=ShowTabs(0)>基本信息</TD>
    <TD id=TabTitle1 class="title5" onclick=ShowTabs(1)>频道设置</TD>
    <TD id=TabTitle2 class="title5" onclick=ShowTabs(2)>权限设置</TD> 
    <TD id=TabTitle3 class="title5" onclick=ShowTabs(3)>生成参数</TD>
    <TD>&nbsp;</TD></TR></TBODY></TABLE>
<!-- 菜单结束 -->
        <div align="center">
            <table class="editborder" cellspacing="1" cellpadding="0" width="99%" border="0">
                <tbody id="Tabs0">
                    <tr class="tdbg">
                        <td class="bqleft">
                            频道名称：
                        </td>
                        <td class="bqright">
                            <asp:TextBox ID="txtChName" MaxLength="10" runat="server"></asp:TextBox> <font color="red">*</font>
                        </td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            所属模型：
                        </td>
                        <td class="bqright">
                            <asp:DropDownList ID="ddlModelType" runat="server"></asp:DropDownList> <font color="red">* 选择以后不可修改</font>
                        </td>
                    </tr>             
                    
                    <tr class="tdbg">
                        <td class="bqleft">
                            频道目录(英文名)：
                            
                        </td>
                        <td class="bqright">
                        <asp:TextBox ID="txtDirName" MaxLength="50" runat="server"></asp:TextBox> <font color="red">* </font> 以字母开头，由字母和数字组成，不可修改</td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            项目名称：
                        </td>
                        <td class="bqright">
                            <asp:TextBox ID="txtTypeName" MaxLength="10" runat="server"></asp:TextBox> <font color="red">*</font> 例如：频道名称为“文章中心”，其项目名称为“文章”</td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            项目单位：
                        </td>
                        <td class="bqright">
                            <asp:TextBox ID="txtTypeUnit" MaxLength="10" runat="server"></asp:TextBox> <font color="red">*</font> 例如：“篇”、“条”</td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            是否是分站：
                        </td>
                        <td class="bqright">
                            <asp:RadioButton ID="rdIsChildSite1" runat="server" Checked="True" GroupName="gnIsChildSite" Text="否" onclick="SetChildSite()" />
                            &nbsp; &nbsp; <asp:RadioButton ID="rdIsChildSite2" runat="server" GroupName="gnIsChildSite" Text="是" onclick="SetChildSite()" /> </td>
                    </tr>
                    <tr class="tdbg" id="trSiteUrl" style="display:none" runat="server">
                        <td class="bqleft">
                            分站二级域名地址：
                        </td>
                        <td class="bqright">
                            <asp:TextBox ID="txtChildSiteUrl" MaxLength="255" runat="server" Width="300px"></asp:TextBox> 如：http://news.kycms.com
                        </td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            频道说明：
                        </td>
                        <td class="bqright">
                            <asp:TextBox ID="txtDescription" runat="server" Height="60px" MaxLength="255" TextMode="MultiLine"
                                Width="300px"></asp:TextBox></td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            频道首页模板：
                        </td>
                        <td class="bqright">
                        <asp:TextBox ID="txtTemplatePath" maxlength="255" runat="server" Width="300px" />       
                        <input type="button" value="选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtTemplatePath')+'&StartPath='+escape('/Template'),650,480)" class="btn"/> <font color="red">*</font> </td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            栏目页模板：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtColumnTemplatePath" runat="server" Width="300px"></asp:TextBox>
                        <input type="button" value="选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtColumnTemplatePath')+'&StartPath='+escape('/Template'),650,480)" class="btn"/> <font color="red">*</font></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            内容页模板：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtInfoTemplatePath" runat="server" Width="300px"></asp:TextBox>
                        <input type="button" value="选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtInfoTemplatePath')+'&StartPath='+escape('/Template'),650,480)" class="btn"/> <font color="red">*</font></td>
                    </tr>
                    <tr>
                        <td class="bqleft">
                            评论页模板：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtCommentTemplatePath" runat="server" Width="300px"></asp:TextBox>
                        <input type="button" value="选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtCommentTemplatePath')+'&StartPath='+escape('/Template'),650,480)" class="btn"/> <font color="red">*</font></td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            频道META关键词：
                        </td>
                        <td class="bqright">
                            <asp:TextBox ID="txtKeyword" MaxLength="100" runat="server" width="300px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            频道META网页描述：
                        </td>
                        <td class="bqright">
                            <asp:TextBox ID="txtContent" height="60px" runat="server" width="300px" TextMode="MultiLine"></asp:TextBox>
                         </td>
                    </tr>
                     <tr class="tdbg">
                        <td class="bqleft">
                          频道排序编号：
                        </td>
                        <td class="bqright">
                            <asp:TextBox ID="txtSort" MaxLength="4" runat="server" Text="0" Width="50px"></asp:TextBox> <font color="red">*</font> 请输入1-100之间的数字，数字越小，排序越靠前
                            
                        </td>
                    </tr>
                </tbody>
                <tbody id="Tabs1" style="display: none">
                  
                    <tr class="tdbg">
                        <td class="bqleft">
                            是否禁用频道：
                        </td>
                        <td class="bqright">
                            <asp:RadioButtonList ID="rblIsDisabled" runat="server" CellPadding="0" CellSpacing="0"
                                RepeatDirection="Horizontal" Width="121px">
                                <asp:ListItem Value="False" Selected="True">否</asp:ListItem>
                                <asp:ListItem Value="True">是</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr class="tdbg" runat="server" visible="false">
                        <td class="bqleft">
                            是否开启站内链接：
                        </td>
                        <td class="bqright">
                            <asp:RadioButtonList ID="rblIsOpenLink" runat="server" CellPadding="0" CellSpacing="0"
                                RepeatDirection="Horizontal" Width="120px">
                                <asp:ListItem Value="True">是</asp:ListItem>
                                <asp:ListItem Value="False" Selected="True">否</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                      <tr class="tdbg">
                        <td class="bqleft">
                           热点点击数最小值：
                        </td>
                        <td class="bqright">
                            <asp:TextBox ID="txtMiniHitCount" runat="server" Text = "500" MaxLength="10" Width="50px"></asp:TextBox> <font color="red">*</font>
                          
                        </td>
                    </tr>
                    
                    <tr class="tdbg">
                        <td class="bqleft">
                            频道审核级别：
                        </td>
                        <td class="bqright">
                            <asp:DropDownList ID="ddlVerifyType" runat="server">
                            <asp:ListItem Value="0" Selected="True" Text="不审核"></asp:ListItem>
                            <asp:ListItem Value="1" Text="一级审核"></asp:ListItem>
                            <asp:ListItem Value="2" Text="二级审核"></asp:ListItem>
                            <asp:ListItem Value="3" Text="三级审核"></asp:ListItem>
                            </asp:DropDownList>
                            
                        </td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            退稿时通知信息内容：
                        </td>
                        <td class="bqright">
                            <asp:TextBox ID="txtNotice1" runat="server" TextMode="MultiLine" Width="370px"></asp:TextBox> 可以通过{@标题}引用退稿内容的标题</td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft" style="height: 26px">
                            采纳时通知信息内容：
                        </td>
                        <td class="bqright" style="height: 26px">
                            <asp:TextBox ID="txtNotice2" runat="server" TextMode="MultiLine" Width="370px"></asp:TextBox> 可以通过{@标题}引用采纳内容的标题</td>
                    </tr>
                </tbody>
                <tbody id="Tabs2" style="display:none" >
               <tr class="tdbg">
                        <td class="bqleft">
                            频道访问权限：
                        </td>
                        <td class="bqright">
                            <asp:RadioButtonList ID="rblIsOpened" runat="server" CellPadding="0" CellSpacing="0"
                                RepeatDirection="Horizontal" Width="120px">
                                <asp:ListItem Value="True" Selected="True">开放</asp:ListItem>
                                <asp:ListItem Value="False">认证</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            允许查看的会员组：
                        </td>
                        <td class="bqright" valign="middle">
                            <asp:CheckBoxList ID="cblGroupIdStr" runat="server" CellPadding="0" CellSpacing="0"
                             RepeatDirection="Horizontal">
                            </asp:CheckBoxList> [当频道设置为认证时有效]</td>
                    </tr>
                 
                </tbody>
                <tbody id="Tabs3" style="display: none">
                  
                    <tr class="tdbg">
                        <td class="bqleft">
                            生成HTML的方式：
                        </td>
                        <td class="bqright">
                            <asp:RadioButtonList ID="rblIsStaticType" runat="server" RepeatDirection="Horizontal" Width="120px">
                            <asp:ListItem Text="生成" Value="True" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="不生成" Value="False"></asp:ListItem>
                            </asp:RadioButtonList>
                            
                        </td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            栏目页的存放结构：
                        </td>
                        <td class="bqright">
                            <asp:DropDownList ID="ddlColumnSortType" runat="server" RepeatDirection="Horizontal" Width="250px">
                            <asp:ListItem Value="1" Selected="True" Text="例：频道目录/栏目目录/Index.html"></asp:ListItem>
                            <asp:ListItem Value="2" Text="例：频道目录/List/Index_栏目编号.html"></asp:ListItem>
                            <asp:ListItem Value="3" Text="例：频道目录/Index_栏目编号.html"></asp:ListItem>
                            </asp:DropDownList>
                            
                            
                        </td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            内容的存放结构：
                        </td>
                        <td class="bqright">
                            <asp:DropDownList ID="ddlInfoSortType" runat="server" Width="250px">
                            <asp:ListItem Value="1" Text="例：频道目录/栏目目录/文件名称" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="2" Text="例：频道目录/Html/文件名称"></asp:ListItem>
                            <asp:ListItem Value="3" Text="例：频道目录/文件名称"></asp:ListItem>
                            <asp:ListItem Value="4" Text="例：频道目录/2007/07/29/文件名称"></asp:ListItem>
                            <asp:ListItem Value="5" Text="例：频道目录/2007/07-29/文件名称"></asp:ListItem>
                            <asp:ListItem Value="6" Text="例：频道目录/2007-07-29/文件名称"></asp:ListItem>
                            <asp:ListItem Value="7" Text="例：频道目录/200707/文件名称"></asp:ListItem>
                            </asp:DropDownList>
                            
                        </td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            文件命名方式：
                        </td>
                        <td class="bqright">
                            <asp:DropDownList ID="ddlFileNameType" runat="server" Width="250px">
                            <asp:ListItem Value="1" Text="例：内容编号.html" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="2" Text="例：200708内容编号.html"></asp:ListItem>
                            <asp:ListItem Value="3" Text="例：20070809内容编号.html"></asp:ListItem>
                            <asp:ListItem Value="4" Text="例：频道目录名_内容编号.html"></asp:ListItem>
                            <asp:ListItem Value="5" Text="例：频道目录名_20070809内容编号.html"></asp:ListItem>
                            </asp:DropDownList>
                            
                        </td>
                    </tr>

                 
                    <tr class="tdbg">
                        <td class="bqleft" style="height: 25px">
                            频道首页扩展名：
                        </td>
                        <td class="bqright" style="height: 25px">
                            <asp:RadioButtonList ID="rblChannelPageType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Text=".html" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="2" Text=".htm"></asp:ListItem>
                            <asp:ListItem Value="3" Text=".shtml"></asp:ListItem>
                            <asp:ListItem Value="4" Text=".aspx"></asp:ListItem>
                            </asp:RadioButtonList>
                           
                        </td>
                    </tr>
                    <tr class="tdbg">
                        <td class="bqleft">
                            栏目页扩展名：
                        </td>
                        <td class="bqright">
                        <asp:RadioButtonList ID="rblColumnPageType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Text=".html" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="2" Text=".htm"></asp:ListItem>
                            <asp:ListItem Value="3" Text=".shtml"></asp:ListItem>
                            <asp:ListItem Value="4" Text=".aspx"></asp:ListItem>
                            </asp:RadioButtonList>
                            
                        </td>
                    </tr>
                   
                    <tr class="tdbg">
                        <td class="bqleft">
                           内容页扩展名：
                        </td>
                        <td class="bqright">
                        <asp:RadioButtonList ID="rblInfoPageType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Text=".html" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="2" Text=".htm"></asp:ListItem>
                            <asp:ListItem Value="3" Text=".shtml"></asp:ListItem>
                            <asp:ListItem Value="4" Text=".aspx"></asp:ListItem>
                         </asp:RadioButtonList>
                            
                        </td>
                    </tr>
                    
                   
                </tbody>
                <tfoot>
                <tr class="tdbg">
                    <td class="tdheight" colspan="2" align="center">
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="确  定" OnClientClick="return CheckValidate()" CssClass="btn" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input
                            id="btnNo" type="button" value="取　消" onclick="location.href='ChannelList.aspx'"
                            class="btn" />
                    </td>
                </tr>
            </tfoot>
            </table>

        </div>
    </form>
   <asp:Literal id="litMsg" runat="server" ></asp:Literal> 
</body>
</html>
<script language='javascript' type="text/javascript">
function SetChildSite()
{
    if($("rdIsChildSite1").checked)
    {
        $("trSiteUrl").style.display = "none";
    }
    else
    {
        $("trSiteUrl").style.display = "";
    }
}

function CheckValidate()
{ 
    if($("txtChName").value.trim().length==0)
    {
        alert("频道名称必须填写");
        return false;
    }
   var dirName = $("txtDirName").value.trim();
   var patt = /^[a-zA-Z][0-9a-zA-Z]*$/
   if(!patt.test(dirName))
   {
       alert("频道（目录）英文名必须以字母开头，必须是字母和数字组成");
       return false; 
   } 
    if($("txtTypeName").value.trim().length==0)
   {
        alert("项目名称必须填写");
        return false;
   } 
   if($("txtTypeUnit").value.trim().length==0)
   {
        alert("项目单位必须填写");
        return false; 
   }
   if($("rdIsChildSite2").checked&&$("txtChildSiteUrl").value.trim().length==0)
   {
        alert("设置该频道为分站，分站地址必须填写");
        return false; 
   }
   if($("txtDescription").value.trim().length>255)
   {
        alert("网站描述不能超过255个字");
        return false; 
   }
   
   if($("txtTemplatePath").value.trim().length==0)
   {
       alert("频道模板必须选择");
       return false; 
   }
   if($("txtColumnTemplatePath").value.trim().length==0)
   {
       alert("栏目页模板必须选择");
       return false; 
   }
   if($("txtInfoTemplatePath").value.trim().length==0)
   {
        alert("内容页模版必须选择");
        return false; 
   }
   if($("txtCommentTemplatePath").value.trim().length==0)
   {
        alert("评论页模版必须选择");
        return false; 
   }
   if($("txtContent").value.trim().length>300)
   {
        alert("META网页描述不能超过300个字");
        return false; 
   }
  
   if(!CheckNumber($("txtMiniHitCount").value.trim()))
   {
        alert("热点点击数最小值必须是0或正整数");
        return false; 
   } 
   if($("txtNotice1").value.trim().length>500)
   {
        alert("退稿时通知信息内容不能超过500个字");
        return false; 
   }
   
    if($("txtNotice2").value.trim().length>500)
   {
        alert("采纳时通知信息内容不能超过500个字");
        return false; 
   }
    if(!CheckNumber($("txtSort").value.trim()))
   {
        alert("频道排序编号必须为0或正整数");
        return false; 
   }
   return true;
}
</script>