<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetPage.aspx.cs" Inherits="System_label_SetPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>设置分页的样式</title>
    <link rel="stylesheet" href="../css/default.css" type="text/css" />
<script language="javascript" language="javascript">
function getColorOptions(){
	var color= new Array("00","33","66","99","CC","FF");
	for (var i=0;i<color.length ;i++ )
	{
		for (var j=0;j<color.length ;j++ )
		{
			for (var k=0;k<color.length ;k++ )
			{
				if(k==0&&j==0&&i==0)
				document.write('<option style="background:#'+color[j]+color[k]+color[i]+'" value="'+color[j]+color[k]+color[i]+'" selected>　　</option>');
				else
				document.write('<option style="background:#'+color[j]+color[k]+color[i]+'" value="'+color[j]+color[k]+color[i]+'">　　</option>');
			}
		}
	}
}
function getChecked(o){
	for (var i=0;i<o.length;i++ )
	{
		if(o[i].checked) return o[i].value;
	}
}
function setIT(obj){
	var retV='';
	retV += '' + getChecked(obj.list2);
	//var pageColor=obj.pageColor.options[obj.pageColor.selectedIndex].value;
	//if(pageColor='undefined')pageColor='CC0099';
	//retV += ',' + obj.pageColor.options[obj.pageColor.selectedIndex].value;
	//window.returnValue = retV;
	dialogArguments.$("txtPageStyle").value=retV;
	window.close();	
}
</script>    
</head>

<body topmargin="0" leftmargin="0">
<form name="form1">
<table width="100%" border="0" height="100%" cellspacing="1" cellpadding="1">
<tr> 
<td valign="top">
	<table width="100%"  border="0" cellspacing="2" cellpadding="1">
			  <tr> 
				<td valign="middle"><input name="list2" type="radio" value="1" style="margin-top:10px;" /></td>
				<td><img src="../images/pagestyl1.gif" alt="列表页码样式" border="0"  /></td>
			  </tr>
			  <tr> 
				<td valign="middle"><input name="list2" type="radio" value="2" /></td>
				<td><img src="../images/pagestyl2.gif" alt="列表页码样式" border="0" /></td>
			  </tr>
			  <tr> 
				<td valign="middle"><input name="list2" type="radio" value="3" checked="checked" /></td>
				<td><img src="../images/pagestyl3.gif" alt="列表页码样式" border="0" /></td>
			  </tr>
			  <tr> 
				<td valign="middle"><input name="list2" type="radio" value="4" /></td>
				<td><img src="../images/pagestyl4.gif" alt="列表页码样式" border="0" /></td>
			  </tr>
        </table>
</td>
</tr>
<tr>
<td valign="middle" align="center">
	<input type="button" value=" 确 定 " class="btn" onClick="setIT(this.form);" />
	<input type="button" value=" 取 消 " class="btn" onClick="window.returnValue='';window.close();" style="margin-top:5px;" /></td>
</tr>

</table>
</form>
</body>
</html>
