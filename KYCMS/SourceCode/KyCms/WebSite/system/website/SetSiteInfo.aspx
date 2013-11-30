<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetSiteInfo.aspx.cs" Inherits="System_SetSiteInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml"> 
<head>
    <link href="../css/default.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript" src="../../js/common.js"></script>
    <script type="text/javascript">
   function CheckValidate()
   {
        if($("txtSequenceNum").value.trim().length==0)
       {
          alert('产品序列号必须填写');
          return false;  
       }
       if($("txtDomain").value.trim().length==0)
       {
           alert('站点域名必须填写');
           return false; 
       }
       if($("txtIndexTemplatePath").value.trim().length==0)
       {
         alert('首页模版必须选择');
         return false;
       } 
       if($('chkBoxIsTestEmail').checked&&($('txtEmailServerAddress').value.trim().length==0||$('txtServerUserName').value.trim().length==0||($('isSetPass').innerText.trim().length==0&&$('txtServerUserPass').value.trim().length==0)))
       {
           alert('选择了注册时邮箱验证，邮件发送设置必须填写');
           return false; 
       }
       if($('chkBoxIsTestEmail').checked)
       {
           var patt = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
           if(!patt.test($('txtServerUserName').value.trim()))
           {
               alert('发送邮件的地址名称格式不正确');
               return false;
           } 
       }
       
       if($('txtGUnitName').value.trim().length==0)
       {
           alert('金币单位必须填写');
           return false; 
       }
     
       if($("txtWaterMarkH").value.trim().length>0&&!CheckNumber($("txtWaterMarkH").value.trim()))
       {
            alert('水印图片的高度必须为数字');
            return false; 
       }
       if($("txtWaterMarkW").value.trim().length>0&&!CheckNumber($("txtWaterMarkW").value.trim()))
       {
            alert('水印图片的宽度必须为数字');
            return false; 
       }
       if($('txtWaterMarkLight').value.trim().length>0)
       {
            if(!CheckNumber($('txtWaterMarkLight').value.trim())||$('txtWaterMarkLight').value<0||$('txtWaterMarkLight').value>100)
           {
                alert('水印图片的透明度必须为0-100的数字'); 
                return false; 
          }  
       }
       return true;
   }  
  
    </script> 
</head>


<body>
<!-- 头部开始 -->
<iframe width="260" height="165" id="colorPalette" src="../../common/setcolor.htm" style="visibility:hidden; position: absolute;border:1px gray solid" frameborder="0" scrolling="no" ></iframe>

 <table width="99%" border="0" cellpadding="1" cellspacing="2" class="wzdh" align="center">
 <tr>
     <td width="27" height="20">
         &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" alt="" /></td>
     <td>
         您现在的位置： <a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; 站点参数设置</td>
 </tr>
</table>
<!-- 头部结束 -->

<!-- 菜单开始 -->
<table cellspacing="0" cellpadding="0"  border="0" width="99%" class="cd" align="center">
  <tr align="center">
    <td  id="TabTitle0" onclick="ShowTabs(0)" class="title6">全站参数</td>
    <td  id="TabTitle1" onclick="ShowTabs(1)" class="title5">内容参数</td>
    <td id="TabTitle2" onclick="ShowTabs(2)" class="title5">邮件参数</td> 
    <td id="TabTitle3" onclick="ShowTabs(3)" class="title5">用户参数</td>
    <td  id="TabTitle4" onclick="ShowTabs(4)" class="title5">水印/缩放</td>
    <td >&nbsp;</td> 
   </tr>
</table>
<form id="SetForm" runat="server">
<table width="99%" border="0" cellpadding="2" cellspacing="1" class="editborder" align="center">
<tbody id="Tabs0">
    <tr visible="false" runat="server">
        <td class="bqleft"><strong>产品序列号：</strong></td>
        <td class="bqright"  >&nbsp;<asp:TextBox ID="txtSequenceNum" runat="server" MaxLength="400" Width="400px" Text="dd"></asp:TextBox>
            <font style="color:Red">*</font></td>
        
    </tr>
    <tr>
       <td class="bqleft"><strong>站点名称：</strong></td>
       <td class="bqright"  >&nbsp;<asp:TextBox ID="txtSiteName" runat="server" MaxLength="50" CssClass="inputSingle"></asp:TextBox></td>
    </tr>
   <tr> 
       <td class="bqleft"><strong>站点域名：</strong></td>
       <td class="bqright"  >&nbsp;<asp:TextBox ID="txtDomain" runat="server" MaxLength="200" CssClass="inputSingle"></asp:TextBox> <font color="red"> （请正确填写，例如：http://www.kycms.com 或 http://192.168.0.1/KyCms 后面不带“/”）</font></td>
    </tr>
	
    <tr>
	   <td class="bqleft"><strong>Logo地址：</strong></td>
       <td class="bqright"  >&nbsp;<asp:TextBox ID="txtLogoAddress" runat="server" MaxLength="255" CssClass="inputSingle"></asp:TextBox></td>
   </tr>
   <tr> 
       <td class="bqleft"><strong>Banner地址：</strong></td>
       <td class="bqright"  >&nbsp;<asp:TextBox ID="txtBannerAddress" runat="server" MaxLength="255" CssClass="inputSingle"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="bqleft">
       版权信息：</td>
        <td class="bqright">
            &nbsp;<asp:TextBox ID="txtCopyRight" runat="server" Width="400px" TextMode="MultiLine" Rows="5"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="bqleft">
            全站页面生成方式：</td>
        <td class="bqright">
            <asp:CheckBox ID="chkBoxIsStaticType" runat="server" Text="开启生成静态文件功能" />
            <font style="color:red">（此设置具有最高优先级）</font></td>
    </tr>
    <tr>
        <td class="bqleft" style="height: 16px">
            全站生成路径方式：</td>
        <td class="bqright" style="height: 16px">
       <asp:RadioButton ID="rdIsAbsPathType1" GroupName="gNIsAbsPathType" Text="相对路径" runat="server" Checked="true"></asp:RadioButton>
       <asp:RadioButton ID="rdIsAbsPathType2" GroupName="gNIsAbsPathType" Text="绝对路径" runat="server"></asp:RadioButton></td>
    </tr>
	
	<tr>
	   <td class="bqleft"><strong>首页关键字：</strong></td>
       <td class="bqright"   >&nbsp;<asp:TextBox ID="txtKeyword" runat="server" MaxLength="100" Width="400px"></asp:TextBox></td>
    </tr>
   <tr> 
       <td class="bqleft"><strong>首页内容描述：</strong></td>
       <td class="bqright"  >&nbsp;<asp:TextBox ID="txtKeyContent" runat="server" MaxLength="200" Width="400px"  TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="bqleft">
            首页模版路径设置：</td>
        <td class="bqright">
            &nbsp;<asp:TextBox ID="txtIndexTemplatePath" runat="server" MaxLength="255" Width="311px" ReadOnly="true" ></asp:TextBox>&nbsp;
            <input type="button" value="选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtIndexTemplatePath')+'&StartPath='+escape('/Template'),650,480)" class="btn"/>
            <span style="color: #ff0000">*</span></td>
    </tr>
    <tr>
        <td class="bqleft">
            首页页面类型设置：</td>
        <td class="bqright">
            <asp:RadioButton ID="rdPageType1" GroupName="gNPageType" Text=".html" runat="server" Checked="true"></asp:RadioButton>
       <asp:RadioButton ID="rdPageType2" GroupName="gNPageType" Text=".htm" runat="server"></asp:RadioButton>
       <asp:RadioButton ID="rdPageType3" GroupName="gNPageType" Text=".shtml" runat="server"></asp:RadioButton>
       <asp:RadioButton ID="rdPageType4" GroupName="gNPageType" Text=".aspx" runat="server"></asp:RadioButton></td>
    </tr>

   
   <tr> 
       <td class="bqleft"><strong>后台登陆设置：</strong></td>
       
       <td class="bqright"  >
           <asp:CheckBox ID="chkBoxIsOpenRZM" runat="server" Text="开启登陆认证码功能" /> <asp:Literal
               ID="litRZM" runat="server" Visible="false"></asp:Literal></td>
    </tr>
   
     
   
    
        <tr>
            <td class="bqleft">
                </td>
            <td class="bqright">
                </td>
        </tr>
   </tbody>
   <tbody id="Tabs1" style="display:none">
   <tr>
   <td class="bqleft"><strong>文章默认归档天数：</strong></td>
    <td class="bqright"  >
        &nbsp;文章默认归档天数为<asp:TextBox ID="txtHistoryTime" runat="server" MaxLength="10" Width="40px" Text="60"></asp:TextBox> 天
    </td>
   </tr>
   <tr>
   <td class="bqleft"><strong>内容生成设置：</strong></td>
   <td class="bqright"  >

   &nbsp;一次最多生成 <asp:TextBox ID="txtInfoCreateNum" runat="server" MaxLength="5" Width="30px" ></asp:TextBox> 个内容详细页 <font style="color:red">（请正确输入50-5000之间的数字,该值决定每次将多少条内容数据读入服务器内存中待生成）</font><br />
   <asp:TextBox ID="txtSpecialInfoCreateNum" runat="server" MaxLength="5" Width="30px"  Text="0" Visible="false"></asp:TextBox></td>
   </tr>
   <tr>
    <td class="bqleft"><strong>内容搜索设置：</strong></td>
    <td class="bqright"  >
     &nbsp;每次搜索时间间隔
        <asp:TextBox ID="txtSearchTime" runat="server" MaxLength="10"  Width="40px">30</asp:TextBox> 秒<br />
     &nbsp;搜索结果页每页显示 <asp:TextBox ID="txtSearchResultPageSize" runat="server" MaxLength="10" Width="40px" Text="20"></asp:TextBox> 条数据
    </td> 
   </tr>
   

   <tr runat="server" visible="false">
   <td class="bqleft"><strong>是否开启游客DIG功能：</strong></td>
    <td class="bqright"  >
        <asp:CheckBox ID="chkBoxIsOpenViewerDig" runat="server" Text="开启游客DIG功能" />
    </td>
   </tr>

       <tr>
           <td class="bqleft">
               文件上传设置：</td>
           <td class="bqright">
               &nbsp;允许上传的图片文件格式为&nbsp;
               <asp:TextBox ID="txtUploadType" runat="server" Width="280px"></asp:TextBox><br />
               &nbsp;允许上传的视频文件格式为&nbsp;
               <asp:TextBox ID="txtUploadVideoType" runat="server" Width="280px"></asp:TextBox> <br />
               &nbsp;允许上传的音频文件格式为&nbsp;
               <asp:TextBox ID="txtUploadAudioType" runat="server" Width="280px"></asp:TextBox> <br /> 
               &nbsp;允许上传的软件文件格式为&nbsp;
               <asp:TextBox ID="txtUploadSoftType" runat="server" Width="280px"></asp:TextBox> <br />
              &nbsp;允许上传的其他文件格式为&nbsp;
               <asp:TextBox ID="txtUploadOtherType" runat="server" Width="280px"></asp:TextBox> <br />   
               &nbsp;<font color='red'>（多种文件格式用“|”隔开，请正确按照.扩展名的格式输入,例如：.gif|.jpg）</font></td>
       </tr>
       <tr> 
       <td class="bqleft">内容过滤字符串：</td>
       <td class="bqright"  >
           &nbsp;<asp:TextBox ID="txtFilterStr" runat="server"  Width="400px" TextMode=MultiLine Height="100px"></asp:TextBox><font style="color:red">（多个过滤字之间用|分隔）</font></td></tr>
   </tbody>
   <tbody id="Tabs2" style="display:none">
  <tr>
        <td class="bqleft">
                邮件发送设置：</td>
        <td class="bqright">
            &nbsp;发送邮件服务器地址为 <asp:TextBox ID="txtEmailServerAddress" runat="server" MaxLength="50" CssClass="inputSingle" Width="150px"></asp:TextBox> <font color="red">（请正确填写邮件服务器地址）</font><br/>
       &nbsp;发送邮件的地址名称为 <asp:TextBox ID="txtServerUserName" runat="server" MaxLength="50"  Width="150px"></asp:TextBox> <font color="red">（请正确填写发送邮件的地址）</font><br />
       &nbsp;发送邮件的账户密码为 <asp:TextBox ID="txtServerUserPass" runat="server" MaxLength="50" TextMode="Password"  Width="150px"></asp:TextBox> <span id="isSetPass"><asp:Literal ID="litSet" runat="server"></asp:Literal></span><asp:Literal ID="litUserPass" runat="server" Visible="false"></asp:Literal>
        </td>
    </tr>
   </tbody>
   <tbody id="Tabs3" style="display:none">
  
    <tr>
        <td class="bqleft">
            用户注册设置：</td>
        <td class="bqright">
           <asp:CheckBox ID="chkBoxAllowRegiste" runat="server" Text="允许新用户注册"></asp:CheckBox>
            <br />
           &nbsp;用户每天登陆一次增加 <asp:TextBox ID="txtLoginScore" MaxLength="5" runat="server" Width="30px"></asp:TextBox> 个积分
           <br /> 
        <asp:CheckBox ID="chkBoxIsTestEmail" runat="server" Text="开启邮箱验证注册" ></asp:CheckBox>&nbsp;<br />
     
        &nbsp;用户登陆失败达 <asp:TextBox ID="txtLoginErrorNum" runat="server" MaxLength="10"  Width="50px"></asp:TextBox> 次，<asp:TextBox ID="txtDisabledLoginTime" runat="server" MaxLength="5" Text="30" Width="20px"></asp:TextBox> 分种内禁止登陆<font style="color:red">（设置为0则不限制）</font><br />&nbsp;用户最多允许创建<asp:TextBox ID="txtUserClassCount" runat="server" MaxLength="10" Width="50px"></asp:TextBox>个专栏<font style="color:red">（设置为0则不限制）</font><br />
            <asp:CheckBox ID="chkBoxIsLoginValidate" runat="server" Text="开启用户登录验证码" />
          <br />
          <asp:CheckBox ID="chkBoxIsOpenInvite" runat="server" Text="开启用户邀请机制"/>
            </td>
    </tr>
    <tr> 
         <td class="bqleft">金币单位名称：</td>
       <td class="bqright"  > &nbsp;<asp:TextBox ID="txtGUnitName" runat="server" MaxLength="15" Width="40px"></asp:TextBox> <font style="color:red">*</font></td>
    </tr> 
    <tr>
        <td class="bqleft">
       用户兑换设置：
        </td>
       <td class="bqright">
            &nbsp;<asp:TextBox ID="txtGNumber" runat="server" MaxLength="10" Width="30px"></asp:TextBox> 金币= <asp:TextBox ID="txtG_Score" runat="server" MaxLength="10" Width="30px"></asp:TextBox> 积分= <asp:TextBox ID="txtG_Day" runat="server" Width="30px"></asp:TextBox> 天有效期
       </td> 
    </tr> 
    <tr>
	   <td class="bqleft" style="height: 23px"><strong>友情链接设置：</strong></td>
       <td class="bqright" style="height: 23px"  ><asp:CheckBox ID="chkBosIsOpenRegLink" runat="server" Text="开启友情链接注册功能" />
		   <asp:CheckBox ID="chkIsCheckLink" runat="server" Text="友情链接是否需要审核" /></td>
    </tr>
<tr>
	   <td class="bqleft" style="height: 23px"><strong>评论设置：</strong></td>
       <td class="bqright" style="height: 23px"  ><asp:CheckBox ID="chkBoxIsCommentValidate" runat="server" Text="用户评论需要输入验证码" />
       <asp:CheckBox ID="chkBoxIsAllowCommentNoName" runat="server" Text="允许匿名评论" />
       <asp:CheckBox ID="chkBoxIsAddCommentEditor" runat="server" Text="用户评论时加载编辑器" /></td>
    </tr>
   </tbody>
       <tbody id="Tabs4" style="display:none">
     <tr> 
       <td class="bqleft" ><strong>水印类型：</strong></td>
       <td class="bqright"  ><asp:RadioButton ID="rdIsImgWaterMark1" GroupName="gNIsImgWaterMark" runat="server" Text="文字水印" Checked="true" /><asp:RadioButton ID="rdIsImgWaterMark2" GroupName="gNIsImgWaterMark" runat="server" Text="图片水印" /></td>
    </tr>            

      <tr> 
       <td class="bqleft"><strong>文字水印设置：</strong></td>
       <td class="bqright"  >
       &nbsp;水印的文字内容为 <asp:TextBox ID="txtWaterMarkStr" runat="server" MaxLength="100"  Width="231px"></asp:TextBox> <br />
       &nbsp;水印文字的大小为 <asp:TextBox ID="txtWaterMarkFontSize" runat="server" MaxLength="5"  Width="40px"></asp:TextBox> pt&nbsp;
       &nbsp;&nbsp;水印文字的字体为
       <asp:DropDownList ID="ddlWaterMarkFontName" runat="server">
       
       </asp:DropDownList>
       <br />
       &nbsp;水印文字的颜色为 <asp:TextBox ID="txtWaterMarkFontColor" runat="server" MaxLength="6"   Width="40px" style="display:none"></asp:TextBox><img src="../../images/<%if(txtWaterMarkFontColor.Text=="") {%>rectNoColor.gif<%}else{%>rect.gif<%} %>" width="18" height="17" border=0 align="absmiddle" id="TitleColorShow" style="cursor:pointer;background-color:#<%=txtWaterMarkFontColor.Text %>;" title="选取颜色!" onClick="GetColor($('TitleColorShow'),'txtWaterMarkFontColor');">
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:CheckBox ID="chkBoxWaterMarkIsBold" Text="粗体" runat="server" /></td>
    </tr>            
      
   <tr>
       <td class="bqleft"><strong>图片水印设置：</strong></td>
       <td class="bqright"  >
       &nbsp;用作水印的图片路径为 <asp:TextBox ID="txtWaterMarkPath" runat="server" MaxLength="255"  Width="207px"></asp:TextBox> <font style="color:Red">(请正确设置图片路径)</font><br />
       &nbsp;图片水印的宽高为<asp:TextBox ID="txtWaterMarkW" runat="server" MaxLength="5"  Width="30px"></asp:TextBox> x <asp:TextBox ID="txtWaterMarkH" runat="server" MaxLength="5"  Width="30px"></asp:TextBox> 单位：px<br />
       &nbsp;图片水印的透明度为 <asp:TextBox ID="txtWaterMarkLight" runat="server" MaxLength="3"  Width="30px"></asp:TextBox>  %<br />
       &nbsp;图片水印文字为 <asp:DropDownList ID="ddlWaterMarkPos" runat="server"  Width="60px">
       <asp:ListItem Value="1" Text="左上"></asp:ListItem>
       <asp:ListItem Value="2" Text="右上"></asp:ListItem>
       <asp:ListItem Value="3" Text="右下"></asp:ListItem>
           <asp:ListItem Value="4">左下</asp:ListItem>
       </asp:DropDownList>
       </td>
    </tr>                  
   
    </tbody>
   
   
   
   <tbody>
   <tr>
    <td colspan="2" align="center"><asp:Button ID="btnSumbit" Text="保存设置" runat="server" OnClick="btnSumbit_Click" OnClientClick="return CheckValidate()" CssClass="btn"/></td>
   </tr>
   </tbody>                             
   </table>
<!--全站设置结束-->
</form>
<asp:Literal ID="litMsg" runat="server"></asp:Literal>

</body>
</html>
<!-- JS代码开始 -->
<script type="text/javascript">

function GetColor(img_val,input_val)
{
	var PaletteLeft,PaletteTop
	var obj = $("colorPalette");
	ColorImg = img_val;
	ColorValue = $(input_val);
	if (obj){
		PaletteLeft = getOffsetLeft(ColorImg)
		PaletteTop = (getOffsetTop(ColorImg) + ColorImg.offsetHeight)
		if (PaletteLeft+150 > parseInt(document.body.clientWidth)) PaletteLeft = parseInt(event.clientX)-260;
		if (PaletteTop > parseInt(document.body.clientHeight)) PaletteTop = parseInt(document.body.clientHeight)-165;
		obj.style.left = PaletteLeft + "px";
		obj.style.top = PaletteTop + "px";
		if (obj.style.visibility=="hidden")
		{
			obj.style.visibility="visible";
		}else {
			obj.style.visibility="hidden";
		}
	}
}
function getOffsetTop(elm) {
	var mOffsetTop = elm.offsetTop;
	var mOffsetParent = elm.offsetParent;
	while(mOffsetParent){
		mOffsetTop += mOffsetParent.offsetTop;
		mOffsetParent = mOffsetParent.offsetParent;
	}
	return mOffsetTop;
}
function getOffsetLeft(elm) {
	var mOffsetLeft = elm.offsetLeft;
	var mOffsetParent = elm.offsetParent;
	while(mOffsetParent) {
		mOffsetLeft += mOffsetParent.offsetLeft;
		mOffsetParent = mOffsetParent.offsetParent;
	}
	return mOffsetLeft;
}
function setColor(color)
{
	if(ColorImg.id=='FontColorShow' && color=="#") color='#000000';
	if(ColorImg.id=='FontBgColorShow' && color=="#") color='#FFFFFF';
	if (ColorValue){ColorValue.value = color.substr(1);}
	if (ColorImg && color.length>1){
		ColorImg.src='../../Images/Rect.gif';
		ColorImg.style.backgroundColor = color;
	}else if(color=='#'){ ColorImg.src='../../Images/rectNoColor.gif';}
	$("colorPalette").style.visibility="hidden";
}
</script>