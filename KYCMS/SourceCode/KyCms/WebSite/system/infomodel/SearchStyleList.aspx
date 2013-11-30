<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchStyleList.aspx.cs" Inherits="system_infomodel_SearchStyleList" %>
<%@ Import Namespace="Ky.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" /> 
	<script language="javascript" type="text/javascript">
		function SetColor()
		{
			var id=<%= ModelId%>;
			var modid="mod"+id;
			var amodid="amod"+id;
			var obj=document.getElementById(modid);
			var obj1=document.getElementById(amodid);
			obj1.style.color="#FFF";
			obj.style.backgroundColor="#4975dc";
		}
		function dragmove()
        {
            if(window.drag)
            {
                var ev = ev || window.event;
                var mousePos = mouseCoords(ev);
                ev.returnValue = false; 
                dragspan.style.left = mousePos.x + 10;
                dragspan.style.top = mousePos.y + 8;
            }
        }
	</script>
</head>


<body  onmousemove="dragmove();" onmouseup="dragclear()" onload="GetSysFieldList();SetColor()">

<table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
    <tr>
        <td height="24" width="20">
            <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
        <td align="left" style="padding-top: 3px;">
            您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 模型搜索列表样式<asp:Literal ID="ltMsg" runat="server"></asp:Literal></td>
        <td width="50" align="right">
            <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
    </tr>
</table>

<table width="99%" cellpadding="0" cellspacing="1" class="border" align="center">
<tr>
	<td class="bqleft">选择创建样式的模型：</td>
			<asp:Repeater ID="repModel" runat="server">
			<ItemTemplate>
					<td style="background-color: #e6e6e6;" align="center" id="mod<%# Eval("ModelId") %>" ><a id="amod<%# Eval("ModelId") %>" href="SearchStyleList.aspx?ModelId=<%# Eval("ModelId") %>"><%#Eval("ModelName") %></a></td>
			</ItemTemplate>
		</asp:Repeater>
</tr>
</table> 

<form runat="server">
<table  width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center">
	<tr>
		<td class="bqleft"> 系统字段：</td>
		<td class="bqright"><div id="sysFieldShow"></div></td>
	</tr>
	<%if (ModelId != 1 && ModelId != 2 && ModelId != 3 && ModelId != 0 && ctmFildCount > 0)
	   {	%>
	<!--显示系统标签-->					
	<tr>
		<td class="bqleft">自定义字段：</td>
		<td class="bqright"><div id="customFieldShow"></div></td>
	</tr>
	<%} %>

	<%if(ModelId==1){%>
	<!--显示文章字段-->
	<tr>
		<td class="bqleft">字段：</td>
		<td class="bqright"><div id="articleFieldShow"></div></td>
	</tr>
	<%}	%>

	<%if (ModelId == 2){ %>
	<!--显示图片表的字段标签-->					
	<tr>
		<td class="bqleft">字段：</td>
		<td class="bqright"><div id="ImageFieldShow"></div></td>
	</tr>
	<%} %>

	<%if (ModelId == 3){ %>
	<!--显示图片表的字段标签-->					
	<tr>
		<td class="bqleft">字段：</td>
		<td class="bqright"><div id="downloadFieldShow"></div></td>
	</tr>
	<%} %>
	<tr>
		<td class="bqleft">样式内容：</td>
		<td class="bqright"><textarea id="txtContent" rows="10" cols="80" style="width:100%" runat="server"  onmouseup="dragend()" onmousemove="movePoint()"></textarea></td>
	</tr>
	<tr>
		<td colspan="2" align="center">
			<asp:Button ID="btnAddStyle" runat="server" Text="添加样式" CssClass="btn" OnClick="btnAddStyle_Click" /> 
			<asp:Button ID="btnReset" runat="server" Text="重新填写" CssClass="btn" OnClick="btnReset_Click" />
		</td>
	</tr>
</table>
</form>
</body>
</html>
<script language="javascript" type="text/javascript">
function GetSysFieldList()
{
     system_infomodel_SearchStyleList.GetSysFieldList('',Callback);				//系统字段标签
	 system_infomodel_SearchStyleList.GetArticleList('',CallBackArticle);		//系统模型文章字段标签
	 system_infomodel_SearchStyleList.GetImageList('',CallBackImage);		//系统模型图片字段标签
	 system_infomodel_SearchStyleList.GetDownLoadList('',CallBackDownLoad);		//系统模型图片字段标签
	 system_infomodel_SearchStyleList.GetCustomList('',CallBackCustom);		//自定义系统模型图片字段标签
}

//============================系统字段标签================================
function Callback(result)
{
	try
	{
		$('sysFieldShow').innerHTML = "";
		var count = result.value.Rows.length;
		var str =  "<table cellpadding='2' cellspacing='2' border='0' width='80%'><tr>" ;
		for(var i=0;i<count;i++)
		{
			var text = result.value.Rows[i]["FieldName"];
			var fieldValue=result.value.Rows[i]["FieldValue"]; 
			str+= "<td width='14%'>"+ FillText(text,fieldValue)+"</td>" ;
		   if(i!=0&&(i+1)%7==0&&(i+1)!=count) 
		   {
				str+="</tr><tr>"
		   }
		}
	   str+="</tr></table>"  
	   $('sysFieldShow').innerHTML=str;
	}
	catch(e)
	{}
}

//==========================系统模型文章字段标签============================
function CallBackArticle(result)
{
	try
	{
		$('articleFieldShow').innerHTML = "";
		var count = result.value.Rows.length;
		var str =  "<table cellpadding='2' cellspacing=2' border='0' width='80%'><tr>" ;

		var rowcount=parseInt(count/7)+1;
		var totalcount=rowcount*7;

		for(var i=0;i<count;i++)
		{
			var text = result.value.Rows[i]["FieldName"];
			var fieldValue=result.value.Rows[i]["FieldValue"]; 
			str+= "<td width='14%'>"+ FillText(text,fieldValue)+"</td>" ;
		   if(i!=0&&(i+1)%7==0&&(i+1)!=count) 
		   {
				str+="</tr><tr>"
		   }
		}

		if(count<totalcount && count!=7)
		{
			for(i=0;i<(totalcount-count);i++)
			{
				str+="<td width='14%'>"+ FillText('&nbsp;','&nbsp;')+"</td>";
			}
		}

	   str+="</tr></table>"  
	   $('articleFieldShow').innerHTML=str;
	}
	catch(e)
	{}
}

//==========================系统图片模型文章字段标签============================
function CallBackImage(result)
{
	try
	{
		$('ImageFieldShow').innerHTML = "";
		var count = result.value.Rows.length;
		var str =  "<table cellpadding='2' cellspacing='2' border='0' width='80%'><tr>" ;

		var rowcount=parseInt(count/7)+1;
		var totalcount=rowcount*7;

		for(var i=0;i<count;i++)
		{
			var text = result.value.Rows[i]["FieldName"];
			var fieldValue=result.value.Rows[i]["FieldValue"]; 
			str+= "<td width='14%'>"+ FillText(text,fieldValue)+"</td>" ;
		   if(i!=0&&(i+1)%7==0&&(i+1)!=count) 
		   {
				str+="</tr><tr>"
		   }
		}

		if(count<totalcount && count!=7)
		{
			for(i=0;i<(totalcount-count);i++)
			{
				str+="<td width='14%'>"+ FillText('&nbsp;','&nbsp;')+"</td>";
			}
		}

	   str+="</tr></table>"  
	   $('ImageFieldShow').innerHTML=str;
	}
	catch(e)
	{}
}

//==========================系统下载模型文章字段标签============================
function CallBackDownLoad(result)
{
	try
	{
		$('downloadFieldShow').innerHTML = "";
		var count = result.value.Rows.length;
		var str =  "<table cellpadding='2' cellspacing='2' border='0' width='80%'><tr>" ;

		var rowcount=parseInt(count/7)+1;
		var totalcount=rowcount*7;

		for(var i=0;i<count;i++)
		{
			var text = result.value.Rows[i]["FieldName"];
			var fieldValue=result.value.Rows[i]["FieldValue"]; 
			str+= "<td width='14%'>"+ FillText(text,fieldValue)+"</td>" ;
		   if(i!=0&&(i+1)%7==0&&(i+1)!=count) 
		   {
				str+="</tr><tr>"
		   }
		}

		if(count<totalcount && count!=7)
		{
			for(i=0;i<(totalcount-count);i++)
			{
				str+="<td width='14%'>"+ FillText('&nbsp;','&nbsp;')+"</td>";
			}
		}

	   str+="</tr></table>"  
	   $('downloadFieldShow').innerHTML=str;
	}
	catch(e)
	{}
}

//==========================用户自定义模型文章字段标签============================
function CallBackCustom(result)
{
	try
	{
		$('customFieldShow').innerHTML = "";
		var count = result.value.Rows.length;
		var str =  "<table cellpadding='2' cellspacing='2' border='0' width='80%'><tr>" ;

		var rowcount=parseInt(count/7)+1;
		var totalcount=rowcount*7;

		for(var i=0;i<count;i++)
		{
			var text = result.value.Rows[i]["Alias"];
			if(result.value.Rows[i]["Name"]=="$search$")
			{
				var fieldValue=result.value.Rows[i]["Name"]; 
			}
			else
			{
				var fieldValue="{KY_"+result.value.Rows[i]["Name"]+"}"; 
			}
			str+= "<td width='14%'>"+ FillText(text,fieldValue)+"</td>" ;
		   if(i!=0&&(i+1)%7==0&&(i+1)!=count) 
		   {
				str+="</tr><tr>"
		   }
		}

		if(count<totalcount && count!=7 && ((totalcount%7)!=0 || count<7 ))
		{
			for(i=0;i<(totalcount-count);i++)
			{
				str+="<td width='14%'>"+ FillText('&nbsp;','&nbsp;')+"</td>";
			}
		}

	   str+="</tr></table>" 
	   $('customFieldShow').innerHTML=str;
	}
	catch(e)
	{}
}
//<a href='javascript:showlist('/',{ky_chid},'字段名称','感窜')'>[{ky_opin}]</a>
//&lt;href='javascript:showlist('<%=Param.ApplicationRootPath %>',{KY_chid},'字段名称','KY_字段名称')'&gt;"+fieldValue+"&lt;/a&gt;
function FillText(val,fieldValue)
{
	if(fieldValue!="$search$" && val!="&nbsp;")
		return "<div id="+fieldValue+" onmousedown='DragStart()' onclick='SetValue()' style='cursor:hand;border:solid 1px #9c9c9c;width=99%;height:99%;text-align:center;background-color:#E1ECEE;'>"+val+"</div>";
	else if(fieldValue=="$search$"  && val!="&nbsp;")
		return "<div id='<a href=javascript:showlist(\"<%=Param.ApplicationRootPath %>\",\"{KY_chid}\",\"字段名称\",\"{KY_字段名称}\",\"blank\")>字段值</a>' onmousedown='DragStart()' onclick='SetValue()' style='cursor:hand;border:solid 1px #9c9c9c;width=99%;height:99%;text-align:center;background-color:#E1ECEE;'>"+val+"</div>";
	else
		 return "<div></div>";
		
}

var labelStr;
function DragStart()
{
    dragclear();
    window.drag = 1;
    dragspan = document.createElement('div');
    dragspan.style.position = "absolute";
    dragspan.className="div" ;
    var mousePos = mouseCoords(window.event);
    dragspan.style.left = mousePos.x + 10;
    dragspan.style.top = mousePos.y + 8;    
    labelStr = window.event.srcElement.id;
    dragspan.appendChild(document.createTextNode(window.event.srcElement.innerHTML));
    document.body.appendChild(dragspan);
}
function SetValue()
{
    document.all.txtContent.focus();
   var tarobj = document.selection.createRange();
   tarobj.text = labelStr;
    if(window.drag)
    {
        window.drag = 0;
        window.event.returnValue = true;
    } 
    
}
function dragend()
{
    if(window.drag)
    {
        document.body.removeChild(dragspan); 
        SetValue(); 
    }
}
function mouseCoords(ev) {
    if(ev.pageX || ev.pageY) {
      return {x:ev.pageX, y:ev.pageY};
    }
    return {
      x:ev.clientX + document.documentElement.scrollLeft - document.body.clientLeft,
      y:ev.clientY + document.documentElement.scrollTop - document.body.clientTop
    };
}
function dragclear()
{

    if(window.drag)
    {
        document.body.removeChild(dragspan);
        window.drag = 0;
        window.event.returnValue = true;
    }
    
}

function movePoint() 
{
    if(window.drag)
    {
        var rng = event.srcElement.createTextRange(); 
        rng.moveToPoint(event.x,event.y); 
        rng.select(); 
    }
}
</script>
