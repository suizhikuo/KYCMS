<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="sys_template_Login" %>
<%@ Import Namespace="Ky.Common" %>
<script type="text/javascript">
function MyCheckLogin()
{
	var inputValue = $('txtUserName').value.trim();
	if(inputValue.length==0)
    {
		alert('用户名必须填写');
		$('txtUserName').focus();
        return false;
    } 
    inputValue = $('txtPwd').value.trim();
	if(inputValue.length==0)
    {
		alert('密码必须填写');
		$('txtPwd').focus();
        return false;
    }


	//在没有开启验证码的时候会异常
	try
	{
		if($("txtValidate").value.trim().length==0)
	   {
		   alert('验证码不能为空');
		   return false; 
	   }
	}
	catch(e)
	{}

    return true;
}

function IsCheckLogin()
{
    if(MyCheckLogin())
    {
        var UserName=document.getElementById("txtUserName").value;
        var PassWord=document.getElementById("txtPwd").value;
        var CookieType=document.getElementById("rbCookie").value;

		//在没有开启验证码的时候会异常
		try{
	        var txtValidate=document.getElementById("txtValidate").value;
		}
		catch(e)
		{}
        
        sys_template_Login.AjaxCheckLogin(UserName,PassWord,CookieType,txtValidate,Call_Back);
   }
}

function Call_Back(response)
{
    if(response.value=="True")
    {
        Tab2.style.display = '';
        Tab1.style.display = 'none';
        LabelUser_Name.innerText=document.getElementById("txtUserName").value;
    }
    else
    {
        alert(response.value);
    }
}

function LogOut()
{
    sys_template_Login.AjaxLouOut("",Call_BackLogOut)
}

function Call_BackLogOut(response)
{
    Tab1.style.display = '';
    Tab2.style.display = 'none';
}
function setimg()
{
	document.getElementById("IMG1").src='<%=Param.ApplicationRootPath %>/Common/Code.aspx'
}
function setFocus()
{
	if(event.keyCode==13)
	{
		IsCheckLogin();
	}
}
</script>
<form id="LoginForm" runat="server">

	<%if (LoginModel){ %>
	<!--纵向-->
    <table border="0" cellpadding="0" cellspacing="0" id="Tab1" width="100%">
        <tr>
            <td height="22">
                用户名：</td>
            <td>
                <input type="text" name="txtUserName" maxlength="20" style="height: 18px; width: 125px" onkeypress="setFocus()" /></td>
        </tr>
        <tr>
            <td height="22">
                密&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
            <td>
                <input type="password" name="txtPwd" maxlength="20" style="height: 18px; width: 125px" onkeypress="setFocus()"  />
				<input type="hidden" name="rbCookie" value="No" />
			</td>
        </tr>
		<%if (isValidate){ %>
		<tr>
			<td>验证码：</td>
			<td><input type="text" name="txtValidate" class="LoginInput" style="height: 18px; width:50px;" onkeypress="setFocus()"  /><img src='<%=ApplicationPath%>/Common/Code.aspx' id="IMG1" style="margin-top:3px;" onclick="setimg()" alt="给我换一个" style="cursor:hand;" /></td>
		</tr>
		<%} %>
        <tr>
            <td colspan="2" height="25" style="line-height:150%"> <input id="Button1" type="button" value=" 登 陆 " onclick="IsCheckLogin()" /><br />
                 <a href='<%=ApplicationPath%>/User/Reg.aspx?TypeId=1'>个人会员免费注册</a><br />
                <a href='<%=ApplicationPath%>/User/Reg.aspx?TypeId=2'>企业会员免费注册</a>
            </td>
        </tr>
    </table>
	<%}else{ %>

	<!--横向-->
	<table table border="0" cellpadding="0" cellspacing="0" id="Tab1" width="100%">
		<tr>
			<td  height="22">
				用户名：<input type="text" name="txtUserName" maxlength="20" style="height: 18px; width: 125px" onkeypress="setFocus()" />
				密&nbsp;&nbsp;&nbsp;&nbsp;码：<input type="password" name="txtPwd" maxlength="20" style="height: 18px; width: 125px" onkeypress="setFocus()"  />
				<input type="hidden" name="rbCookie" value="No" />
				<%if (isValidate){ %>
				验证码：<input type="text" name="txtValidate" class="LoginInput" style="height: 18px; width:50px;" onkeypress="setFocus()"  />
						<img src='<%=ApplicationPath%>/Common/Code.aspx' id="IMG1" onclick="setimg()" alt="给我换一个" style="cursor:hand;" />&nbsp;
				<%} %>
				<input id="Button2" type="button" value=" 登 陆 " onclick="IsCheckLogin()" />
			</td>
		</tr>
	</table>
	<%}%>

    <table border="0" cellpadding="0" cellspacing="0" id="Tab2" style="display: none" width="100%">
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td align="right" height="25">用户名:</td>
                        <td><%=LabelUserName %><div id="LabelUser_Name"></div></td>
                    </tr>
                </table>
                
            </td>
        </tr>
        <tr>
            <td height="25">
                <a href='<%=ApplicationPath%>/User/Main.aspx'>用户中心</a> | <a href="javascript:" onclick="LogOut()">
                    退出登陆</a>
            </td>
        </tr>
    </table>
</form>
<% 
    if (!IsLogin)
    {
        Response.Write("<script>Tab1.style.display = '';</script>");
        Response.Write("<script>Tab2.style.display = 'none';</script>");
    }
    else
    {
        Response.Write("<script>Tab2.style.display = '';</script>");
        Response.Write("<script>Tab1.style.display = 'none';</script>");
    }
%>