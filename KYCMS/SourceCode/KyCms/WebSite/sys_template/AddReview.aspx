<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddReview.aspx.cs" Inherits="sys_template_AddReview" %>
<%@ Import Namespace="Ky.Common" %>
<%@ Import Namespace="Ky.Model" %>
<%@ Import Namespace="Ky.BLL" %>

<!--表情引用的样式-->
<link rel="stylesheet" type="text/css" href="<%=Param.ApplicationRootPath %>/images/post/edit.css" />
<script language="javascript" type="text/javascript" src="<%=Param.ApplicationRootPath %>/JS/Common.js"></script>

<!--验证用户输入的内容-->
<script type="text/javascript" language="javascript">
function validate()
{
	$("isValidate").value="login";
}

function FunLoginEnabled()
{
	if($("chkNoName").checked==false)
	{
		$("UserName").disabled=false;
		$("userPwd").disabled=false;
		$("btnSubmit").disabled=false;
	}
	else
	{
		$("UserName").disabled=true;
		$("userPwd").disabled=true;
		$("btnSubmit").disabled=true;
	}
	$("isValidate").value="nologin";
}

function CheckLogin()
{

	try
	{
		if($("isValidate").value=="login")
		{
			if($("UserName").value=="")
			{
				alert("用户名必须填写");
				$("UserName").focus();
				$("isValidate").value="nologin";
				return false;
			}
		}

		if($("isValidate").value=="login")
		{
			if($("userPwd").value=="")
			{
				alert("密码必须填写");
				$("userPwd").focus();
				$("isValidate").value="nologin";
				return false;
			}
		}
	}
	catch(e)
	{}

	var inputValue = $('txtContent').value.trim();

	if(inputValue.length==0)
    {
		try
		{
			if($("isValidate").value=="login")
			{
					return true;
			}
		}
		catch(e)
		{}
		alert('评论内容必须填写');
        return false;
    }


    if($("txtValidatec").value.trim().length==0)
   {
		try
		{
			if($("isValidate").value=="login")
			{
					return true;
			}
		}
		catch(e)
		{}
       alert('验证码不能为空');
	   $("txtValidatec").focus();
       return false; 
   } 
    return true;
}
function myfun()
{
	document.write($("txtContent2").value);
}


/*-------------------------------------------------------*\ 
 * UBB 编辑器演示 (兼容 IE, Opera, Firefox) By GrassLand 
 * 参数说明: 
 * target: 字符串, UBB 主编辑域 ID 
 * markup: 字符串, UBB 标签 
\*-------------------------------------------------------*/ 
function ubbTag(target, markup){
    var txa=document.getElementsByName(target)[0]; 
    txa.focus(); 
    var strEnd=markup.replace(/\[/ig,'[/'); 
    if (strEnd.indexOf('=')>-1){ 
        strEnd=strEnd.replace(/(.*?)\=.*?\]/,'$1]'); 
    } 
    if(document.selection&&document.selection.type== "Text"){ 
    // IE, Opera 
            var oStr=document.selection.createRange(); 
            oStr.text=markup+oStr.text+strEnd; 
    } else if(window.getSelection&&txa.selectionStart>-1) { 
    // Netscape 
        var st=txa.selectionStart; 
        var ed=txa.selectionEnd; 
           txa.value=txa.value.substring(0,st)+markup+ 
           txa.value.substring(st,ed)+strEnd+ 
           txa.value.slice(ed); 
    } else { 
        txa.value+=markup+strEnd; 
    } 
}



function setx(values)
{
	$('txtContent').focus();
	if (document.selection)
	{
		var range= document.selection.createRange();
		range.text = "["+values+"]";
	}			
}

//评论输入框内字符提示与清除
var clickCount = 0;
function clearCommentContent(oObject) {
    clickCount++;
    if (clickCount == 1) {
        oObject.value = "";
    }
}
</script>
<form name="form1" action="<%=Param.ApplicationRootPath %>/common/AddReview.aspx" method="post" onsubmit="return CheckLogin()">
	<table class="link01" cellSpacing="0" cellPadding="0" width="100%"  border="0">
	            <tr><td align="center"><img height="6" src="<%=Param.ApplicationRootPath %>/Images/news_60.gif" width="90%"></td></TR>
	            <tr>
					<td>
						<table width="90%" border="0" align="center" cellPadding="0" cellSpacing="0" class="link01" bgcolor="#f8f8f8" style="border-right:solid 1px #e4e4e4;border-left:solid 1px #e4e4e4; padding-top:5px;padding-bottom:5px">

	<%
		//如果没登录,显示登录信息
		if (!isLogin)
		{
	  %>
	<tr id="loginRow">
			<td colspan="2" align="left">
				用户名：<input type="text" maxlength="20" name="UserName" id="UserName" size="10" disabled="disabled" /> 
				密  码：<input type="password" maxlength="20" name="userPwd" id="userPwd" size="10" disabled="disabled" /> 
				<input type="submit" name="btnSubmit" id="btnSubmit" value="登录" class="btn" disabled="disabled" onclick="validate()" />
				 匿名发表：<input type="checkbox" value="chkNoName" name="chkNoName" checked="checked" onclick="FunLoginEnabled()" />
				<input type="hidden" name="txtIsLogin" value="<%=isLogin %>" /> 
				<input type="hidden" value="nologin" id="isValidate" />
			 </td>
	</tr>
	<%
		}		
	 %>

	<tr>	 
		<td rowspan="2" valign="top" width="45"> &nbsp;内容</td>
		<td align="left">
			<%
				//判断是否使用编辑
				if(!IsAddCommentEditor)
				{
			%>
				<textarea id="Content" name="txtContent" cols="60" class="reviewlogo" rows="8" class="link05" style="BORDER-RIGHT: #cccccc 1px solid; BORDER-TOP: #cccccc 1px solid; BORDER-LEFT: #cccccc 1px solid; WIDTH: 380px; BORDER-BOTTOM: #cccccc 1px solid" onclick="clearCommentContent(this)"></textarea>
			<% }
				else
				{
			%>
					<table cellpadding="0" cellspacing="0" border="0" width="100%">
						<tr>
							<td>
								<table bgcolor="DCDCDC" cellpadding="1" cellspacing="0" border="0" width="100%">
									<tr>
										<td style="width:8%; height:16px;" class="CaoYuan_Btn" onmouseover="this.className='CaoYuan_BtnMouseOverUp'" onmouseout="this.className='CaoYuan_Btn'">
											<img alt="加粗" src="<%=Param.ApplicationRootPath %>/images/Post/bold.gif" hand" onclick="ubbTag('txtContent', '[b]')" /> 
										</td>
										<td style="width:8%;" class="CaoYuan_Btn" onmouseover="this.className='CaoYuan_BtnMouseOverUp'" onmouseout="this.className='CaoYuan_Btn'">
											<img alt="斜体" src="<%=Param.ApplicationRootPath %>/images/post/italic.gif" class="hand" onclick="ubbTag('txtContent', '[i]')" />
										</td>
										<td style="width:8%;" class="CaoYuan_Btn" onmouseout="this.className='CaoYuan_Btn'" onmouseover="this.className='CaoYuan_BtnMouseOverUp'">
											<img alt="下划线" src="<%=Param.ApplicationRootPath %>/images/post/underline.gif" class="hand" onclick="ubbTag('txtContent', '[u]')" />
										</td>
										<td style="width:8%;" class="CaoYuan_Btn" onmouseout="this.className='CaoYuan_Btn'" onmouseover="this.className='CaoYuan_BtnMouseOverUp'">
											<img alt="左对齐" src="<%=Param.ApplicationRootPath %>/images/post/aleft.gif" class="hand" onclick="ubbTag('txtContent', '[align=left]')" />
										</td>
										<td style="width:8%;" class="CaoYuan_Btn" onmouseout="this.className='CaoYuan_Btn'" onmouseover="this.className='CaoYuan_BtnMouseOverUp'">
											<img alt="居中对齐" src="<%=Param.ApplicationRootPath %>/images/post/center.gif" class="hand" onclick="ubbTag('txtContent', '[align=center]')" />
										</td>
										<td style="width:8%;" class="CaoYuan_Btn" onmouseout="this.className='CaoYuan_Btn'" onmouseover="this.className='CaoYuan_BtnMouseOverUp'">
											<img alt="右对齐" src="<%=Param.ApplicationRootPath %>/images/post/aright.gif" class="hand" onclick="ubbTag('txtContent', '[align=right]')" />
										</td>
										<td>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
					<textarea id="txtContent" name="txtContent" rows="8" class="reviewlogo" style="width:99%;"  onclick="clearCommentContent(this)"></textarea>
					<table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin-top:-10px;">
						<tr align="center" style="cursor:hand"> 
						  <td height="50" class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em01')">
								<img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em01.gif" width="19" height="19" title="em01">
						</td>
						<td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em02')">
								<img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em02.gif" width="19" height="19" title="em02">
						</td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em03')">
								<img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em03.gif" width="19" height="19" title="em03">
						  </td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em04')">
								<img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em04.gif" width="19" height="19" title="em04">
						  </td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em05')">
								<img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em05.gif" width="19" height="19" title="em05">
						 </td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em06')">
								<img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em06.gif" width="19" height="19" title="em06">
						  </td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em07')">
								<img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em07.gif" width="19" height="19" title="em07"></td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em08')"><img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em08.gif" width="19" height="19" title="em08"></td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em09')"><img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em09.gif" width="19" height="19" title="em08"></td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em10')"><img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em10.gif" width="19" height="19" title="em08"></td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em11')"><img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em11.gif" width="19" height="19" title="em08"></td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em12')"><img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em12.gif" width="19" height="19" title="em08"></td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em13')"><img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em13.gif" width="19" height="19" title="em08"></td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em14')"><img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em14.gif" width="19" height="19" title="em08"></td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em15')"><img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em15.gif" width="19" height="19" title="em08"></td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em16')"><img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em16.gif" width="19" height="19" title="em08"></td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em17')"><img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em17.gif" width="19" height="19" title="em08"></td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em18')"><img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em18.gif" width="19" height="19" title="em08"></td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em19')"><img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em19.gif" width="19" height="19" title="em08"></td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em20')"><img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em20.gif" width="19" height="19" title="em08"></td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em21')"><img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em21.gif" width="19" height="19" title="em08"></td>
						  <td class="tdBgcolor" onmouseout="this.className='tdBgcolor'" onmouseover="this.className='tdBgcolor2'" onclick="setx('em22')"><img src="<%=Param.ApplicationRootPath %>/images/Post/pic/em22.gif" width="19" height="19" title="em08"></td>
						</tr>
					</table>
			<%
				}
			%>	
		</td>
	</tr>

	<tr>
		<td align="right" width="384">
		<%
			//评论时是否使用验证码
			if (IsCommentValidate)
			{
				validate = true;
		%>
<img src="<%=Param.ApplicationRootPath %>/Common/Code.aspx" id="img1" onclick="this.src='<%=Param.ApplicationRootPath %>/Common/Code.aspx'" alt="给我换一个" align="absmiddle" />
		验证码：	<input id="txtValidatec" type="text" name="txtValidate" size="10" style="height:18px;" maxlength="6" /><input type="hidden" value="nologin" id="Hidden1" />
		<%
			}
		 %><input id="Submit1" type="submit" value="发表评论" class="btn" />
		</td>		
	</tr>
	</TABLE>

	</td></tr>
	<TR><td align="center"><img height=7 src="<%=Param.ApplicationRootPath %>/Images/news_71.gif" width=90%></td></TR>
</table>	<input id="Button1" type="hidden" name="hidModeType" value="<%=modelId %>" />
			<!--评论时传递文章的ID号-->
			<input id="Button2" type="hidden" name="hidNewsId" value="<%=id %>" />
			<!--用户输入的验证码-->
			<input id="Hidden2" type="hidden" name="hidValidate" value="<%=validate %>" />
			<!--是否允许匿名用户评论-->
			<input id="Hidden3" type="hidden" name="hidNoName" value="<%=IsAllowCommentNoName %>" />
			<!--栏目设置评论是否需要审核-->
			<input id="Hidden4" type="hidden" name="hidColCommentSet" value="<%=isColCheckComment %>" />
</form>

