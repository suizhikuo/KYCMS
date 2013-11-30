<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetStyle.aspx.cs" Inherits="System_Label_SetStyle"
    ValidateRequest="false" %>
<%@ Import Namespace="Ky.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>增加样式与修改样式</title>
    <link rel="stylesheet" href="../css/default.css" type="text/css" />
   <script language="Javascript" type="TEXT/JAVASCRIPT" src="../../js/Common.js"></script> 

    <script language="javascript" type="text/javascript">
			function $(val)
			{
				return document.getElementById(val);
			}
			function setx(obj)
			{
				$("test").focus();
			    
				if (document.selection)
				{
					var range= document.selection.createRange();
					range.text= obj.value;
				}
				obj.options[0].selected=true;
			}
			
			function CheckValidate()
			{
                if($("txtTypeName").value.trim().length==0)
               {
                    alert("样式名称必须填写");
                    $("txtTypeName").focus();
                    return false; 
               } 
				if($("test").value.trim().length==0)
				{
					alert("样式内容必须填写");
					return false;
				}
               return true;			
           }

		   //相应的模型对应相应的字段
			function ChangeModel()
			{
				if($("ddlModel").value=="2")
				{
					$("userCustomField").style.display="";
					$("articleField").style.display="none";
				}
				else
				{
					$("articleField").style.display="";
					$("userCustomField").style.display="none";
				}
			}

			//内容样式
			function ContentStyle()
			{
				try
				{
					userStyle.style.display="none";
					userField.style.display="none";
					conStyle.style.display="";
					conField.style.display="none";
				}
				catch(e)
				{
				}
			}

			function UserStyle()
			{
				conStyle.style.display="none";
				try
				{
				conField.style.display="none";
				}
				catch(e)
				{
				}
				userStyle.style.display="";
				userField.style.display="";
			}

			function CustomField()
			{

				conStyle.style.display="none";
				try
				{				
					conField.style.display="";
				}
				catch(e)
				{

				}
				userStyle.style.display="none";
				userField.style.display="none";
			}

		var menuHit=0;
		function ShowModelList()
		{
			if(menuHit==0)
			{
				modelMenuList.style.display="";
				menuHit=menuHit+1;
			}
			else
			{
				modelMenuList.style.display="none";	
				menuHit=menuHit-1;
			}
		}

		function showMenu()
		{
				modelMenuList.style.display="";
				menuHit=1;
		}
			
    </script>

</head>
<body onmousemove="dragmove();" onmouseup="dragclear()" onload="GetSysFieldList()">
    <form id="form1" runat="server">
        <div>

			<table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
				<tr>
					<td height="24" width=20><img src="../images/skin/default/you.gif" align=absmiddle /></td>
					<td align=left style="padding-top:3px;" >您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="../template/CreateFolder.aspx">标签&模板管理</a> >> <a href="StyleManager.aspx"> 样式管理</a> >> 创建样式</td>
					<td width="50" align="right"><img src="../images/skin/default/help.gif" align=absmiddle /></td>
				</tr>
			</table>

            <table width="99%" border="0" cellpadding="0" cellspacing="0" class="wzdh" align="center" style="margin-top:5px;">
                <tr>
                    <td height="26" align="left">
                        &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/System/Label/StyleManager.aspx">样式管理首页</asp:HyperLink>
                        |
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/System/label/AddStyleType.aspx">新增样式分类</asp:HyperLink>
                        | <a href="#" onclick="javascript:window.history.back();">返回</a>
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="ddlRedirectPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRedirectPage_SelectedIndexChanged">
                            <asp:ListItem>跳转类型至…</asp:ListItem>
                            <asp:ListItem Value="StyleManager.aspx">样式管理</asp:ListItem>
                            <asp:ListItem Value="LabelManager.aspx">标签管理</asp:ListItem>
                            <asp:ListItem Value="../Template/CreateFolder.aspx">模板管理</asp:ListItem>
                        </asp:DropDownList>&nbsp;
                    </td>
                </tr>
            </table>

            <table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center">
                <tbody>
                    <tr>
                        <td class="bqleft">
                            样式名称：</td>
                        <td class="bqright">
                            <asp:TextBox ID="txtTypeName" runat="server" Width="40%" MaxLength="200"></asp:TextBox>
                            <asp:DropDownList ID="ddlStyleType" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
					
					<tr>
						<td class="bqleft">选择样式：</td>
						<td class="bqright">&nbsp;<span style="border:solid 1px #CCCCCC; padding:0px 0px 0px 0px ; background-color:#FFFFFF;"><a href="#" onclick="ContentStyle()">&nbsp;通用字段&nbsp; &nbsp;<img id="img2" style="vertical-align:middle;" src="../images/skin/default/sitelist.gif" alt="" border="0" /></a></span> | 
							<span style="border:solid 1px #CCCCCC; padding:0px 0px 0px 0px ; background-color:#FFFFFF;"><a href="#" onclick="CustomField()">&nbsp;自定义字段&nbsp; &nbsp;<img id="img1" style="vertical-align:middle;" src="../images/skin/default/sitelist.gif" alt="" border="0" /></a></span> | 
							<span style="border:solid 1px #CCCCCC; padding:0px 0px 0px 0px ; background-color:#FFFFFF;"><a href="#" onclick="ShowModelList()">&nbsp;用户字段&nbsp; &nbsp;<img id="imgdrp" style="vertical-align:middle;" src="../images/skin/default/sitelist.gif" alt="" border="0" /></a></span>
						</td>
					</tr>					

					<tr id="conStyle">
						<td class="bqleft">系统字段：</td>
						<td class="bqright"><div id="sysFieldShow"></div></td>
					</tr>

					<%if (isShowTr != 1 && isShowTr != 2 && isShowTr != 3 && isShowTr != 0 && ctmFildCount>0) {	%>
					<!--显示系统标签-->					
					<tr id="conField" style="display:none;">
						<td class="bqleft">自定义字段：</td>
						<td class="bqright"><div id="customFieldShow"></div></td>
					</tr>
					<%} %>

					<%if(isShowTr==1){%>
					<!--显示文章字段-->
					<tr id="conField" style="display:none;">
						<td class="bqleft">自定义字段：</td>
						<td class="bqright"><div id="articleFieldShow"></div></td>
					</tr>
					<%}	%>

					<%if (isShowTr == 2){ %>
					<!--显示图片表的字段标签-->					
					<tr id="conField" style="display:none;">
						<td class="bqleft">自定义字段：</td>
						<td class="bqright"><div id="ImageFieldShow">图片</div></td>
					</tr>
					<%} %>

					<%if (isShowTr == 3){ %>
					<!--显示图片表的字段标签-->					
					<tr id="conField" style="display:none;">
						<td class="bqleft">自定义字段：</td>
						<td class="bqright"><div id="downloadFieldShow">下载</div></td>
					</tr>
					<%} %>

					<!--用户样式-->
					<tr id="userStyle" style="display:none;">
						<td class="bqleft">系统字段：</td>
						<td class="bqright"><div id="userSysField"></div></td>
					</tr>

					<tr id="userField" style="display:none;">
						<td class="bqleft">自定义字段：</td>
						<td class="bqright"><div id="customUserField"></div></td>
					</tr>

                    <tr>
                        <td align="right" class="bqleft">
                            样式内容：</td>
                        <td class="bqright">
                            <textarea id="test" rows="14" cols="80" style="width:100%" runat="server"  onmouseup="dragend()" onmousemove="movePoint()"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="height: 29px">
                            <asp:Button ID="btnSave" CssClass="btn" runat="server" Text="添加样式" OnClick="btnSave_Click"  OnClientClick="return CheckValidate()" />
                            <asp:Button ID="btnReset" CssClass="btn" runat="server" Text="重新填写" OnClick="btnReset_Click" /></td>
                    </tr>
                </tbody>
            </table>
		</div>

		<!--选择用户模型-->
		<div id="modelMenuList" style="display:none;position:absolute;top:0px; margin-top:125px; margin-left:385px; width:110px; padding:0px;" class="wzlist border" onmouseout="ShowModelList()">
				<div style="width:100%; height:100%; padding:0px;">
					<table cellpadding="0" border="0" cellspacing="0" width="100%">
						<asp:Repeater runat="server" ID="repUserModelList">
							<ItemTemplate>
								<tr>
									<a href="#" onclick="UserStyle();ShowModelList();GetUserCustomField(<%# Eval("Id") %>)")>
										<td style="cursor:hand;" onmouseover="showMenu();javascript:this.style.backgroundColor='#CCCCCC'" onmouseout="showMenu();javascript:style.backgroundColor='#eef6fb'">&nbsp;&nbsp;<%# Eval("Name")%>
										</td>
									</a>
								</tr>
							</ItemTemplate>
						</asp:Repeater>
					</table>
				</div>
			</div>
		<!--用户模型结束-->
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
function GetSysFieldList()
{
     System_Label_SetStyle.GetSysFieldList('',Callback);							//系统字段标签
	 System_Label_SetStyle.GetArticleList('',CallBackArticle);					//系统模型文章字段标签
	 System_Label_SetStyle.GetImageList('',CallBackImage);					//系统模型图片字段标签
	 System_Label_SetStyle.GetDownLoadList('',CallBackDownLoad);		//系统模型图片字段标签
	 System_Label_SetStyle.GetCustomList('',CallBackCustom);				//自定义系统模型图片字段标签
	
	System_Label_SetStyle.GetUserSysFieldList('',UserSysField);				//系统用户模型字段
	
}

//用户自定义用户模型字段
function GetUserCustomField(val)
{
	System_Label_SetStyle.GetUserModelCustomListDt(val,CallBackUserCustomModel);
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
			if(fieldValue!="$search$")
			{ 
				str+= "<td width='14%'>"+ FillText(text,fieldValue)+"</td>" ;
			}
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
		var str =  "<table cellpadding='2' cellspacing='2' border='0' width='80%' ><tr>" ;

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

		if(count<totalcount && count!=7 && (totalcount%7)!=0)
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

		if(count<totalcount && count!=7 && (totalcount%7)!=0)
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
//============================= 用户系统字段===========================
function UserSysField(result)
{
	try
	{
		$('userSysField').innerHTML = "";
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

		if(count<totalcount && count!=7 && ((totalcount%7)!=0 || count<7 ))
		{
			for(i=0;i<(totalcount-count);i++)
			{
				str+="<td width='14%'>"+ FillText('&nbsp;','&nbsp;')+"</td>";
			}
		}

	   str+="</tr></table>"  
	   $('userSysField').innerHTML=str;
	}
	catch(e)
	{}
}

//==========================用户自定义用户模型字段标签============================
function CallBackUserCustomModel(result)
{
	try
	{
		$('customUserField').innerHTML = "";
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
				var fieldValue="{KY_User_"+result.value.Rows[i]["Name"]+"}"; 
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
	   $('customUserField').innerHTML=str;
	}
	catch(e)
	{}
}

function FillText(val,fieldValue)
{
	if(fieldValue!="$search$" && val!="&nbsp;")
	    return "<div id="+fieldValue+" onmousedown='DragStart()' onclick='SetValue()' style='cursor:hand;border:solid 1px #9c9c9c;width=99%;height:99%;text-align:center; background-color:#E1ECEE;'>"+val+"</div>"
	else if(fieldValue=="$search$"  && val!="&nbsp;")
		return "<div id='<a href=javascript:showlist(\"<%=Param.ApplicationRootPath %>\",\"{KY_chid}\",\"字段名称\",\"{KY_字段名称}\",\"blank\")>字段值</a>' onmousedown='DragStart()' onclick='SetValue()' style='cursor:hand;border:solid 1px #9c9c9c;width=99%;height:99%;text-align:center;background-color:#E1ECEE;'>"+val+"</div>";
	else
		 return "<div></div>"
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
    document.all.test.focus();
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