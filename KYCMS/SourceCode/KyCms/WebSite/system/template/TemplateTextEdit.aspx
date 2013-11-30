<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TemplateTextEdit.aspx.cs" Inherits="System_templateList_TemplateTextEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>文本编辑模板</title>
    <link rel="stylesheet" href="../css/default.css" type="text/css" />
    <script src="../../JS/Common.js" type="text/javascript"></script>
	<script language="javascript" type="text/javascript">
		function WindowOpen(url,n,w,h) 
		{
			var c=WinOpen(url,n,w,h);
			c.focus(); 
		} 
		  var x=0;
		  var y=0;
		function MenuPos()
		{
		  //1 获得鼠标点击的位置 
		  x=window.event.clientX;    
		  y=window.event.clientY;
		  //2 修改div1的位置
		  var o=document.getElementById("sub1");
		  o.style.left=x;
		  o.style.top=y;
		  o.style.visibility="";
		}
	   function showHide()
	   {
		 var o=document.getElementById("sub1");
		 o.style.visibility="hidden";
	   }
   
		function setx(values)
		{
			$('lblContent').focus();
			if (document.selection)
			{
				var range= document.selection.createRange();
				range.text = values;
			}			
		}

		//表单搜索
		function SearchForm()
		{
			setx('{$ky id=\"searchform\"  /}');
		}

		//评论
		function Review()
		{
			setx('{$ky id=\"review\"  /}');
		}

		//评论列表
		function ReviewList()
		{
			setx('{$ky id=\"reviewlist\"  /}');
		}

		//站点名称
		function SiteName()
		{
			setx('{$ky id=\"sitename\" /}');
		}


		//logo
		function Logo()
		{
			setx('{$ky id=\"logo\" /}');
		}

		//banner
		function Banner()
		{
			setx('{$ky id=\"banner\" /}');
		}

		//infototal
		function InfoTotal()
		{
			setx('{$ky id=\"infototal\" /}');	
		}

		//domain
		function DoMain()
		{
			setx('{$ky id=\"domain\" /}');
		}

		//copyright
		function CopyRight()
		{
			setx('{$ky id=\"copyright\" /}');
		}

		//pvtotal
		function PvTotal()
		{
			setx('{$ky id=\"pvtotal\" /}');	
		}



		function OnmouseOverFun(obj)
		{
			obj.style.backgroundColor="#003366";
			obj.style.color="#fff"
			obj.style.cursor="hand";
			var sub="";
			switch(obj.id)
			{
				case "model":
					sub="sub11";
					break;
				case "common":
					sub="sub12";
					break;
				case "modelsub":
					sub="sub13";
					var o1=document.getElementById("list1");
					o1.title=obj.title;
					var o2=document.getElementById("list2");
					o2.title=obj.title;
					var o3=document.getElementById("list3");
					o3.title=obj.title;
					var o4=document.getElementById("list4");
					o4.title=obj.title;
					break;
				case "special":
					sub="special";
					break;
				case "modelOffen":
					sub="sub14";
					break;
				case "systemOffen":
					sub="sub15";
					break;
			}
			if(obj.id!="")
				showFun(sub)	
		}

		
		function OnmouseOUtFun(obj)
		{
			obj.style.backgroundColor="#D4D0C8";
			obj.style.color="#000"
		}

		//在指定的对象显示指定的对象
	   function showFun(obj)
	   {
		 var o=document.getElementById(obj);
		 if(obj=="sub11" || obj=="sub12" || obj=="special")
		{
			  o.style.left=x+134;
		}
		else
			o.style.left=x+134+150;
		 o.style.top=window.event.clientY;
		  hideAll(obj);		 
		  o.style.visibility="";
	   }

		//隐藏指定的对象
		function hideFun(obj)
		{
			 var o=document.getElementById(obj);
			 o.style.visibility="hidden";
		}

		//隐藏所有再显示指定的菜单
		function hideAll(obj)
		{
			for(var i=1;i<=5;i++)
			{
				eval("sub1"+i).style.visibility="hidden";
			}
			if(obj=="sub13")
			{
				var o=document.getElementById("sub11");
			    o.style.visibility="";			
			}
			if(obj=="sub14"||obj=="sub15")
			{
				var o=document.getElementById("sub12");
			    o.style.visibility="";
			}
		}


		//隐藏所有的子菜单
		function hideAllSub()
		{
			for(var i=1;i<=5;i++)
			{
				eval("sub1"+i).style.visibility="hidden";
			}
		}

		//打开窗口
		function WindwoOpen(val,obj)
		{		
			switch(obj.id)
			{
				case "list1":
					WindowOpen('../label/CommonlyList.aspx?modelId='+val,'commonlist',750,590);
					break;
				case "list2":
					WindowOpen('../label/CycChColList.aspx?modelId='+val,'commonlist',750,590);
					break;
				case "list3":
					WindowOpen('../label/SubList.aspx?modelId='+val,'commonlist',750,590);
					break;
				case "list4":
					WindowOpen('../label/UltimateList.aspx?modelId='+val,'commonlist',750,590);
					break;
			}				
		} 

	</script>
</head>
<body onmousemove="dragmove();" onmouseup="dragclear()" onload="GetLabel($('ddlCategory').value)"  onclick="showHide();hideAll()">
    <form id="form1" runat="server">
    <div>
        <table width="99%" cellpadding="2" border="0" cellspacing="1" class="border" align="center">
            <tr class="title"><td align="left"> 文本编辑模板　　　文件名：<%=FileName %> 　　　路径:<%=ShowPath%></td></tr>
            <tr class="tdbg">
                <td align="left">
                    <asp:DropDownList ID="ddlCategory" runat="server" onchange="GetLabel(this.value)"></asp:DropDownList> 
                    <div id="lbShow"></div>  
                </td>
            </tr>
            <tr class="tdbg"><td align="left">
                <textarea id="lblContent" style="width:100%" rows="25" runat="server" onmouseup="dragend()" onmousemove="movePoint()" onclick="showHide();hideAll()" oncontextmenu="javascript:MenuPos();hideAllSub();return false;"></textarea></td></tr>
            <tr class="tdbg"><td align="left"><asp:Button ID="btnSave" runat="server" Text="保存模板" CssClass="btn" OnClick="btnSave_Click" /> <asp:Button ID="btnReset" CssClass="btn" runat="server" Text="恢复模板" OnClick="btnReset_Click" /></td></tr>
        </table>
    </div>

		<!--右键弹出菜单-->
		<table id="sub1" style="background-Color:#D4D0C8; border-left:solid 1px #D4D0C8;border-top:solid 1px #D4D0C8; border-bottom:solid 1px #404040;border-right:solid 1px #404040; z-index:101;position:absolute;left:0;top:0;visibility:hidden;" unselectable="on">
		   <tr>
				<td id="model" onclick="setx('aa')"  onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)">&nbsp;&nbsp;创建模型标签 &nbsp; &nbsp; &nbsp; &nbsp;<span  style="font-family:Webdings">4</span>
				</td>
			</tr>

		   <tr>
				<td id="common"  onmouseover="OnmouseOverFun(this)"  onmouseout="OnmouseOUtFun(this)">&nbsp;&nbsp;创建通用标签  &nbsp; &nbsp; &nbsp; &nbsp;<span style="font-family:Webdings">4</span>
				</td>
			</tr>

		   <tr>
				<td onclick="javascript:WindowOpen('../label/SetSpecial.aspx?modelId=','commonlist',750,590)" id="special"  onmouseover="OnmouseOverFun(this)"  onmouseout="OnmouseOUtFun(this)"  unselectable="on">&nbsp;&nbsp;创建专题标签
				</td>
			</tr>
		</table>

		<!--级联模型菜单-->
		<table id="sub11" style="background-Color:#D4D0C8; border-left:solid 1px #D4D0C8;border-top:solid 1px #D4D0C8; border-bottom:solid 1px #404040;border-right:solid 1px #404040; z-index:101;position:absolute;left:0;top:0;visibility:hidden; width:150px;" unselectable="on">
			<asp:Repeater runat="server" ID="repModelList">
				<ItemTemplate>
					<tr>
							<td id="modelsub" title="<%# Eval("ModelId") %>" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)">
								<div style="float:left; padding-left:10px;"><%# Eval("ModelName") %></div>
								<div style="float:right;"><span style="font-family:Webdings"  >4</span></div>
							</td>
					</tr>
				</ItemTemplate>
			</asp:Repeater>
		</table>

		<!--级联通用标签-->
		<table id="sub12" style="background-Color:#D4D0C8; border-left:solid 1px #D4D0C8;border-top:solid 1px #D4D0C8; border-bottom:solid 1px #404040;border-right:solid 1px #404040; z-index:101;position:absolute;left:0;top:0;visibility:hidden; width:150px;"  unselectable="on">
			<tr>
				<td id="modelOffen"  onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)">
					&nbsp;&nbsp;模型常规  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
					<span style="font-family:Webdings" >4</span></td>
			</tr>

			<tr>
				<td id="systemOffen"  onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)">
					&nbsp;&nbsp;系统常用  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
					<span style="font-family:Webdings">4</span></td>
			</tr>				
		</table>

		<!--列表页标签-->
		<table  id="sub13" style="background-Color:#D4D0C8; border-left:solid 1px #D4D0C8;border-top:solid 1px #D4D0C8; border-bottom:solid 1px #404040;border-right:solid 1px #404040; z-index:101;position:absolute;left:0;top:0;visibility:hidden; width:150px;"  unselectable="on">
			<tr><td id="list1" onclick="WindwoOpen(this.title,this)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)"  unselectable="on">普通列表</td></tr>
			<tr><td id="list2" onclick="WindwoOpen(this.title,this)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)"  unselectable="on">栏目循环  </td></tr>
			<tr><td id="list3" onclick="WindwoOpen(this.title,this)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)"  unselectable="on">子类列表  </td></tr>
			<tr><td id="list4" onclick="WindwoOpen(this.title,this)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)"  unselectable="on">终级列表  </td></tr>
		</table>

		<!--模型常规-->
		<table  id="sub14" style="background-Color:#D4D0C8; border-left:solid 1px #D4D0C8;border-top:solid 1px #D4D0C8; border-bottom:solid 1px #404040;border-right:solid 1px #404040; z-index:101;position:absolute;left:0;top:0;visibility:hidden; width:150px;"  unselectable="on">
			<tr><td  onclick="javascript:WindowOpen('../label/NewsRoutine.aspx?modelId=1','commonlist',750,590)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)"  unselectable="on">内容浏览</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/NewsRoutine.aspx?modelId=2','commonlist',750,590)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)"  unselectable="on">FLASH幻灯</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/NewsRoutine.aspx?modelId=3','commonlist',750,590)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">文字头条</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/NewsRoutine.aspx?modelId=4','commonlist',750,590)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">图片头条</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/NewsRoutine.aspx?modelId=5','commonlist',750,590)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">频道导航</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/NewsRoutine.aspx?modelId=6','commonlist',750,590)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">栏目导航</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/NewsRoutine.aspx?modelId=7','commonlist',750,590)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">栏目导航</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/NewsRoutine.aspx?modelId=8','commonlist',750,590)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">专题导航</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/NewsRoutine.aspx?modelId=','commonlist',750,590)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">相关内容</td></tr>
			<tr><td onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" onclick="SearchForm()">搜索表单</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/NewsRoutine.aspx?modelId=10','commonlist',750,590)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">投票标签</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/NewsRoutine.aspx?modelId=11','commonlist',750,590)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">频道/栏目聚合标签</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/NewsRoutine.aspx?modelId=12','commonlist',750,590)" onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">dig标签</td></tr>
		</table>

		<!--系统常用标签-->
		<table id="sub15" style="background-Color:#D4D0C8; border-left:solid 1px #D4D0C8;border-top:solid 1px #D4D0C8; border-bottom:solid 1px #404040;border-right:solid 1px #404040; z-index:101;position:absolute;left:0;top:0;visibility:hidden; width:150px;"  unselectable="on">
			<tr><td onclick="javascript:WindowOpen('../label/SysParameter.aspx?modelId=1','commonlist',750,590)"  onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">栏目频道信息</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/SysParameter.aspx?modelId=2','commonlist',750,590)"  onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">添加收藏夹</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/SysParameter.aspx?modelId=3','commonlist',750,590)"  onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">举报</td></tr>
			<tr><td onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" onclick="Review()">评论</td></tr>
			<tr><td onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" onclick="ReviewList()">评论列表</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/SysParameter.aspx?modelId=6','commonlist',750,590)"  onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">更多评论列表</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/SysParameter.aspx?modelId=7','commonlist',750,590)"  onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">登录标签</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/SysParameter.aspx?modelId=8','commonlist',750,590)"  onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">当前位置标签</td></tr>
			<tr><td onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" onclick="SiteName()">站点名称</td></tr>
			<tr><td onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" onclick="Logo()">站点logo</td></tr>
			<tr><td onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" onclick="Banner()">banner</td></tr>
			<tr><td onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" onclick="InfoTotal()">信息统计</td></tr>
			<tr><td onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" onclick="DoMain()">站点域名</td></tr>
			<tr><td onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" onclick="CopyRight()">版权信息</td></tr>
			<tr><td onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" onclick="PvTotal()">访问统计</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/SysParameter.aspx?modelId=16','commonlist',750,590)"  onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">友情链接</td></tr>
			<tr><td onclick="javascript:WindowOpen('../label/SysParameter.aspx?modelId=17','commonlist',750,590)"  onmouseover="OnmouseOverFun(this)" onmouseout="OnmouseOUtFun(this)" unselectable="on">页面ID编号</td></tr>			
		</table>


    </form>
</body>
</html>
<script language="javascript">
function GetLabel(categoryId)
{
     System_templateList_TemplateTextEdit.GetLabelList(categoryId,Callback)
}

function Callback(result)
{
    $('lbShow').innerHTML = "";
    var count = result.value.Rows.length;
    var str =  "<table cellpadding='2' cellspacing='0' border='0'><tr>" ;
    for(var i=0;i<count;i++)
    {
        var text = result.value.Rows[i]["Name"]; 
        str+= "<td nowrap>"+ FillText(text)+"</td>" ;
       if(i!=0&&(i+1)%7==0&&(i+1)!=count) 
       {
            str+="</tr><tr>"
       }
    }
   str+="</tr></table>"  
   $('lbShow').innerHTML=str;
}
function FillText(val)
{
    return "<div onmousedown='DragStart()' onclick='SetValue()' style='cursor:hand;border:solid 1px #9c9c9c;width=99%;height:99%;text-align:center'>"+val+"</div>"
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
    labelStr = window.event.srcElement.innerText;
    dragspan.appendChild(document.createTextNode(window.event.srcElement.innerHTML));
    document.body.appendChild(dragspan);
}
function SetValue()
{
    document.all.lblContent.focus();
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