<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PreCode.aspx.cs" Inherits="system_collection_PreCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>预览采集内容</title>
	<link rel="stylesheet" type="text/css" href="../css/default.css" />
	<script language="javascript" type="text/javascript" src="../../js/Common.js"></script>
	<script language="javascript" type="text/javascript">
		function setValue()
		{
			if(window.opener.document.all.txtFieldPre.value!="null")
			{
				$("divPreCode").innerHTML=window.opener.document.all.txtFieldPre.value;
			}
			else
			{
				$("divPreCode").innerHTML="请检查你的参数设置";
			}
		}
	</script>
</head>
<body onload="setValue()">
    <form id="form1" runat="server">
    <div>
		<div id="divPreCode"><textarea id="txtPreCode" style="width:100%; height:410px; border:0px; display:none;"></textarea></div>
		<div style="text-align:center;"><input id="Button1" type="button" value=" 确 定 " class="btn" onclick="javascript:window.close();" /></div>    
    </div>
    </form>
</body>
</html>
