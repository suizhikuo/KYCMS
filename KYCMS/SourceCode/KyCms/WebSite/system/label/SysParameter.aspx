<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SysParameter.aspx.cs" Inherits="System_label_SysParameter" EnableViewState="false"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>系统标签</title>
	<link rel="stylesheet" type="text/css" href="../css/default.css" />

	<script language="javascript" type="text/javascript" src="../../JS/Common.js"></script>

	<script language="javascript" type="text/javascript">
		function ShowOption(result)
		{
			revert();
			result.style.backgroundColor="#4975dc";
			result.style.color="#FFFFFF";
		}
		
		function revert()
		{
			for( i=1;i<=17;i++)
			{
				eval("td"+i).style.backgroundColor="#e6e6e6";
				eval("td"+i).style.color="#000000";
			}
		}

		
        function ShowHideTable(param)
        {
            Hiden();
            param.style.display="";
        }
        
        function Hiden()
        {
            for(i=1;i<=17;i++)
            {
                eval("table"+i).style.display="none";
            }
        }

		//网页信息
		function FunPageInfo()
		{
			var values="";
			values="{$ky id=\"page_info\" ";
			values=values+"type=\""+$("selPageInfo").value+"\" /}"
            //dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
            window.close();				
		}

		//加入收藏夹
		function FunShouChangJia()
		{
			if($("txtShowFont").value=="")
			{
				alert("显示操作收藏夹的文本必须填写");
				return false;	
			}	
			else
			{			
				var values="";
				values="{$ky id=\"addfav\" ";
				values=values+"showtext=\""+$("txtShowFont").value+"\" /}"
				//dialogArguments.setx(values);
				window.opener.document.all.lblContent.focus();
				if(window.opener.document.selection)
				{
						var reange=window.opener.document.selection.createRange();
						reange.text=values;
				}
				window.close();
			}				
		}

		//举报
		function FunJuBao()
		{
			if($("txtJuBao").value=="")
			{
				alert("显示举报的文本必须填写");
				return false;	
			}	
			else
			{			
				var values="";
				values="{$ky id=\"report\" ";
				values=values+"showtext=\""+$("txtJuBao").value+"\" /}"
				//dialogArguments.setx(values);
				window.opener.document.all.lblContent.focus();
				if(window.opener.document.selection)
				{
						var reange=window.opener.document.selection.createRange();
						reange.text=values;
				}
				window.close();
			}					
		}

		//评论
		function FunComment()
		{
     			values="{$ky id=\"review\"  /}";
				//dialogArguments.setx(values);
				window.opener.document.all.lblContent.focus();
				if(window.opener.document.selection)
				{
						var reange=window.opener.document.selection.createRange();
						reange.text=values;
				}
				window.close();
		}

		//登录
		function FunLogin()
		{
			var values="{$ky ";
			values=values+"arrange=\""+$("selArrange").value+"\" ";
			values=values+" id=\"login\"  /}";
//			values=values+"inputstyle=\""+$("txtInputStyle").value+"\" ";
//			values=values+"btnstyle=\""+$("txtBtnStyle").value+"\" /}";
//			dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
			window.close();
		}

		//当前位置标签
		function FunSysJs()
		{
			var values="";
			values="{$ky id=\"my_pos\" ";
			values=values+"hrefcss=\""+$("txtCurrposCss").value+"\" ";
			values=values+"compart=\""+$("txtCurrposCompart").value+"\" ";
			if($("chkBoxCurrShowChannel").checked)
			{
			    values=values+"showchannel=\"true\" /}"
			}
			else
			{
			     values=values+"showchannel=\"false\" /}"
			}
			//dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
			window.close();	
		}

		//评论列表
		function FunCommonList()
		{
     			values="{$ky id=\"reviewlist\"  /}";
				//dialogArguments.setx(values);
				window.opener.document.all.lblContent.focus();
				if(window.opener.document.selection)
				{
						var reange=window.opener.document.selection.createRange();
						reange.text=values;
				}
				window.close();			
		}

		//更多评论列表
		function MoreReviewList()
		{
			values="";
			values="{$ky id=\"morereviewlist\" ";
			values=values+"pagesize=\""+$("txtRecordCount").value+"\" /}";
			//dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
			window.close();
		}
		
		//站点名称
		function SiteName()
		{
			values="{$ky id=\"sitename\" /}";
			//dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
			window.close();
		}

		//站点logo
		function SiteLogo()
		{
			values="{$ky id=\"logo\" /}";
			//dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
			window.close();
		}

		//版权信息
		function CopyRight()
		{
			values="{$ky id=\"copyright\" /}";
			//dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
			window.close();
		}

		//banner
		function Banner()
		{
			values="{$ky id=\"banner\" /}";
			//dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
			window.close();
		}

		//站点根路径
		function AppPath()
		{
			values="{$ky id=\"applicationpath\" /}";
			//dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
			window.close();
		}

		//域名
		function Domain()
		{
			values="{$ky id=\"domain\" /}";
			//dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
			window.close();
		}
		//PV标签
		function PvTotal()
		{
			values="{$ky id=\"pvtotal\" /}";
			//dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
			window.close();
		}

		//友情链接
		function FunLink()
		{
			if($("ddlLink").value=="")
			{
				alert("请选择具体的项");
			}
			else
			{
				values="{$ky id=\"kylink\" ";
				values=values+"type=\""+$("ddlLink").value+"\" ";
				values=values+"linkcount=\""+$("txtCount").value+"\" ";
				if($("chkArrange").checked==true)
					values=values+"arrange=\"true\" ";
				else
					values=values+"arrange=\"false\" ";
				values=values+"rowcount=\""+$("rowCount").value+"\" ";
				values=values+"linktarget=\""+$("linkTarget").value+"\"  /}";
				//dialogArguments.setx(values);
				window.opener.document.all.lblContent.focus();
				if(window.opener.document.selection)
				{
						var reange=window.opener.document.selection.createRange();
						reange.text=values;
				}
				window.close();
			}
		}
		function FunInfoTotal()
		{
			values="{$ky id=\"infototal\" /}";
			//dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
			window.close();			
		}
		function GetCurrId()
		{
		    values="{$ky id=\""+$('selcurrid').value+"\" /}";
		    //dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
			window.close();		 
		}



		function ParamFun()
		{
		  var param=document.location.search.substring(1).split("&")[0];
		  return param.split('=')[1];
		}

		function SetFocus()
		{
			var id=ParamFun();
			switch(id)
			{
				case "1":
					ShowHideTable($("table1"));
					ShowOption($("td1"));
					break;
				case "2":
					ShowHideTable($("table2"));
					ShowOption($("td2"));
					break;
				case "3":
					ShowHideTable($("table3"));
					ShowOption($("td3"));
					break;
				case "4":
					ShowHideTable($("table11"));
					ShowOption($("td4"));
					break;
				case "6":
					ShowHideTable($("table9"));
					ShowOption($("td6"));
					break;
				case "7":
					ShowHideTable($("table5"));
					ShowOption($("td7"));
					break;
				case "8":
					ShowHideTable($("table7"));
					ShowOption($("td8"));
					break;
				case "16":
					ShowHideTable($("table16"));
					ShowOption($("td16"));
					break;
				case "17":
					ShowHideTable($("table17"));
					ShowOption($("td17"));
					break;
					
			}
		}
	</script>
</head>
<body onload="ShowOption(td1);SetFocus()">
	<form id="form1" runat="server">
		<div>
			<!--starttop-->
			<table width="99%" border="0" cellpadding="0" cellspacing="0" class="wzdh" align="center">
				<tr>
					<td>
						<b>&nbsp;系统标签创建</b></td>
					<td align="right">
						<a href="#" onclick="javascript:window.close();">关闭</a>&nbsp;</td>
				</tr>
			</table>
			<!--endtop-->



			<!--startbody-->
			<!--start导航-->
			<table style="margin-top: 5px;" width="99%" border="0" cellpadding="2" cellspacing="1"
				class="border" align="center">
				<tr>
					<td id="td1" class="bqright mouseStyle" style="width: 12%; text-align: center;" onclick="ShowHideTable(table1);ShowOption(this)">栏目频道信息</td>
					<td id="td2" class="bqright mouseStyle" style="width: 12%; text-align: center" onclick="ShowHideTable(table2);ShowOption(this)">添加收藏夹</td>
					<td id="td3" class="bqright mouseStyle" style="width: 12%; text-align: center;" onclick="ShowHideTable(table3);ShowOption(this)">举报</td>
					<td id="td4" class="bqright mouseStyle" style="width: 12%; text-align: center;" onclick="ShowHideTable(table4);ShowOption(this)" title="此标签是系统标签，修改样式请到“系统模板”修改">评论</td>
					<td id="td5" class="bqright mouseStyle" style="width: 12%; text-align: center;" onclick="ShowHideTable(table8);ShowOption(this)" title="此标签是系统标签，修改样式请到“系统模板”修改">评论列表</td>
					<td id="td6" class="bqright mouseStyle" style="width: 12%; text-align:center;" onclick="ShowHideTable(table9);ShowOption(this)" title="此标签是系统标签，修改样式请到“系统模板”修改">更多评论列表</td>
					<td id="td7" class="bqright mouseStyle" style="width: 12%; text-align: center;" onclick="ShowHideTable(table5);ShowOption(this)" title="此标签是系统标签，修改样式请到“系统模板”修改">登录标签</td>
					<td id="td8" class="bqright mouseStyle" style="width: 12%; text-align: center;" onclick="ShowHideTable(table7);ShowOption(this)">当前位置标签</td>
				</tr>
				<tr>
					<td id="td9" class="bqright mouseStyle" style="width:12% ; text-align: center;" onclick="ShowHideTable(table6);ShowOption(this)">站点名称</td>
					<td id="td10" class="bqright mouseStyle" style="width:12% ; text-align: center;" onclick="ShowHideTable(table10);ShowOption(this)">站点logo</td>
					<td id="td11" class="bqright mouseStyle" style="width:12% ; text-align: center;" onclick="ShowHideTable(table11);ShowOption(this)">banner</td>
					<!--<td id="td12" class="bqright mouseStyle" style="width:12% ; text-align: center;" onclick="ShowHideTable(table12);ShowOption(this)">站点根路径</td>-->
					<td id="td12" class="bqright mouseStyle" style="width:12% ; text-align: center;" onclick="ShowHideTable(table12);ShowOption(this)">信息统计</td>
					<td id="td13" class="bqright mouseStyle" style="width:12% ; text-align: center;" onclick="ShowHideTable(table13);ShowOption(this)">站点域名</td>
					<td id="td14" class="bqright mouseStyle" style="width:12% ; text-align: center;" onclick="ShowHideTable(table14);ShowOption(this)">版权信息</td>
					<td id="td15" class="bqright mouseStyle" style="width:12% ; text-align: center;" onclick="ShowHideTable(table15);ShowOption(this)">访问统计</td>
					<td id="td16" class="bqright mouseStyle" style="width:12% ; text-align: center;" onclick="ShowHideTable(table16);ShowOption(this)">友情链接</td>
				</tr>
				<tr>
				    <td id="td17" class="bqright mouseStyle" style="width:12% ; text-align: center;" onclick="ShowHideTable(table17);ShowOption(this)">页面ID编号</td>
		 		     <td class="bqright mouseStyle" style="width:12% ; text-align: center;" > &nbsp;</td>
		 		      <td class="bqright mouseStyle" style="width:12% ; text-align: center;" >&nbsp;</td>
		 		      <td class="bqright mouseStyle" style="width:12% ; text-align: center;" >&nbsp;</td> 
		 		      <td class="bqright mouseStyle" style="width:12% ; text-align: center;" >&nbsp;</td> 
		 		      <td class="bqright mouseStyle" style="width:12% ; text-align: center;" >&nbsp;</td> 
		 		      <td class="bqright mouseStyle" style="width:12% ; text-align: center;" >&nbsp;</td> 
		 		      <td class="bqright mouseStyle" style="width:12% ; text-align: center;" >&nbsp;</td>
				</tr>
			</table>
			<!--endstart-->


			<!--start设置页面的信息-->
			<table id="table1" width="99%" border="0" cellpadding="2" cellspacing="1" class="border"
				align="center">
				<tr>
					<td class="bqleft">
						调用内容：</td>
					<td class="bqright">
						<select id="selPageInfo">
							<option value="1">首页/频道/栏目名称</option>
							<option value="2">首页/频道/栏目关键字</option>
							<option value="3">首页/频道/栏目描述</option>
						</select>
					</td>
				</tr>
				<tr>
					<td class="bqleft">
					</td>
					<td class="bqright">
						<input id="Button1" onclick="FunPageInfo()" type="button" value="确定创建此标签" class="btn"  />
						<input id="Button2" type="button" value="取消" onclick="javascript:window.close();" class="btn"  /></td>
				</tr>
			</table>
			<!--end-->


			<!--start添加收藏夹-->
			<table id="table2" width="99%" border="0" cellpadding="2" cellspacing="1" class="border"
				align="center" style="display: none;">
				<tr>
					<td class="bqleft">
						显示的文字：</td>
					<td class="bqright">
						<input id="txtShowFont" type="text" /></td>
				</tr>
				<tr>
					<td class="bqleft">
					</td>
					<td class="bqright">
						<input id="Button3" type="button" value="创建此标签" onclick="return FunShouChangJia()" class="btn"  />
						<input id="Button4" type="button" value="取消" onclick="javascript:window.close();" class="btn"  /></td>
				</tr>
			</table>
			<!--end-->


			<!--start举报-->
			<table id="table3" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none;">
				<tr>
					<td class="bqleft">显示举报的文本：</td><td class="bqright"><input id="txtJuBao" type="text" /></td>
				</tr>
				<tr>
					<td class="bqleft"></td><td class="bqright"><input id="Button5" type="button" value="确定创建此标签" onclick="FunJuBao()" class="btn"  /><input id="Button6"  class="btn"  type="button" value="取消" onclick="javascript:window.close()" /></td>
				</tr>
			</table>
			<!--end-->


			<!--start评论-->
			<table id="table4" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
				<tr>
					<td class="bqleft"></td>					
					<td class="bqright"><input id="Button7" type="button" class="btn" value="确定创建此标签" onclick="FunComment()" /> <input id="Button8" class="btn"  type="button" value="取消" onclick="javascript:window.close()" /></td>
				</tr>
			</table>
			<!--end-->
			
			<!--start登录-->
			<table id="table5" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
				<tr><td class="bqleft">排列的方式：</td>
					<td class="bqright">
					<select id="selArrange">
						<option value="horizontal"> 横向   </option>
						<option value="vertical"> 纵向    </option>
					</select>
					</td>
				</tr>
				<!--
				<tr><td class="bqleft">输入框样式：</td><td class="bqright"><input id="txtInputStyle" type="text" /></td></tr>
				<tr><td class="bqleft">按 钮样 式：</td><td class="bqright"><input id="txtBtnStyle" type="text" /></td></tr>-->
				<tr>
					<td class="bqleft"></td>
					<td class="bqright">
						<input id="Button9" type="button" value="确定创建此标签" onclick="FunLogin()" class="btn" />
						<input id="Button10" class="btn" type="button" value="取消" onclick="javascript:window.close();" />
					</td>
				</tr>	
			</table>
			<!--end-->
			
			<!--start统计
			<table id="table6" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
				<tr><td class="bqleft"></td><td class="bqright"></td></tr>
			</table>	
			<!--end-->

			<!--当前位置设置-->
			<table id="table7" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
				<tr>
					<td class="bqleft">CSS调用：</td><td class="bqright"><input id="txtCurrposCss" type="text" /></td>
				</tr>
				<tr>
					<td class="bqleft">分隔符：</td><td class="bqright"><input id="txtCurrposCompart" type="text" />
                        <label for="chkBoxCurrShowChannel">栏目页调用时是否显示频道</label><input id="chkBoxCurrShowChannel" type="checkbox" /></td>
				</tr>
				<tr><td class="bqleft"></td><td class="bqright">	<input id="Button11" type="button" value=" 确定创建此标签" class="btn" onclick="FunSysJs()" /> <input id="Button12" type="button" value="取消" onclick="javascript:window.close();" class="btn" /></td></tr>
			</table>				
			<!--end-->

			<!--start评论开始-->
			<table id="table8" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
				<tr>
					<td class="bqleft"></td>
					<td class="bqright">	
							<input id="Button13" type="button" value=" 确定创建此标签" class="btn" onclick="FunCommonList()" />
							<input id="Button14" type="button" value="取消" onclick="javascript:window.close();" class="btn" />
					</td>
				</tr>
			</table>
			<!--end-->

			<!--start更多评论列表-->					
			<table id="table9" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
				
				<tr>
					<td class="bqleft">每页记录数：</td>
					<td class="bqright">	<input id="txtRecordCount" type="text" /></td>
				</tr>
				<tr>
					<td class="bqleft"></td>
					<td class="bqright">	
							<input id="Button15" type="button" value=" 确定创建此标签" class="btn" onclick="MoreReviewList()" />
							<input id="Button16" type="button" value="取消" onclick="javascript:window.close();" class="btn" />
					</td>
				</tr>
			</table>
			<!--end-->

			<!--start点名称-->
			<table id="table6" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
				<tr>
					<td class="bqleft"></td>
					<td class="bqright">	
							<input id="Button17" type="button" value=" 确定创建此标签" class="btn" onclick="SiteName()" />
							<input id="Button18" type="button" value="取消" onclick="javascript:window.close();" class="btn" />
					</td>
				</tr>
			</table>
			<!--end-->

			<!--start站点logo-->
			<table id="table10" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
				<tr>
					<td class="bqleft"></td>
					<td class="bqright">	
							<input id="Button19" type="button" value=" 确定创建此标签" class="btn" onclick="SiteLogo()" />
							<input id="Button20" type="button" value="取消" onclick="javascript:window.close();" class="btn" />
					</td>
				</tr>
			</table>
			<!--end-->

			<!--start   banner-->
			<table id="table11" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
				<tr>
					<td class="bqleft"></td>
					<td class="bqright">	
							<input id="Button21" type="button" value=" 确定创建此标签" class="btn" onclick="Banner()" />
							<input id="Button22" type="button" value="取消" onclick="javascript:window.close();" class="btn" />
					</td>
				</tr>
			</table>
			<!--end-->

			<!--start站点根路径-->
			<!--<table id="table12" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
				<tr>
					<td class="bqleft"></td>
					<td class="bqright">	
							<input id="Button23" type="button" value=" 确定创建此标签" class="btn" onclick="AppPath()" />
							<input id="Button24" type="button" value="取消" onclick="javascript:window.close();" class="btn" />
					</td>
				</tr>
			</table>-->
			<!--end-->

			<!--start信息统计-->
			<table id="table12" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
				<tr>
					<td class="bqleft"></td>
					<td class="bqright">	
							<input id="Button23" type="button" value=" 确定创建此标签" class="btn" onclick="FunInfoTotal()" />
							<input id="Button24" type="button" value="取消" onclick="javascript:window.close();" class="btn" />
					</td>
				</tr>
			</table>
			<!--end-->

			<!--start域名-->
			<table id="table13" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
				<tr>
					<td class="bqleft"></td>
					<td class="bqright">	
							<input id="Button25" type="button" value=" 确定创建此标签" class="btn" onclick="Domain()" />
							<input id="Button26" type="button" value="取消" onclick="javascript:window.close();" class="btn" />
					</td>
				</tr>
			</table>
			<!--end-->

			<!--start版权信息-->
			<table id="table14" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
				<tr>
					<td class="bqleft"></td>
					<td class="bqright">	
							<input id="Button27" type="button" value=" 确定创建此标签" class="btn" onclick="CopyRight()" />
							<input id="Button28" type="button" value="取消" onclick="javascript:window.close();" class="btn" />
					</td>
				</tr>
			</table>
			<!--end-->
		
			<!--PV标签-->
			<table id="table15" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
				<tr>
					<td class="bqleft"></td>
					<td class="bqright">	
							<input id="Button29" type="button" value=" 确定创建此标签" class="btn" onclick=" PvTotal()" />
							<input id="Button30" type="button" value="取消" onclick="javascript:window.close();" class="btn" />
					</td>
				</tr>
			</table>

			<!--友情链接-->
			<table id="table16" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
				<tr>
					<td class="bqleft">友情链接类型：</td>
					<td class="bqright">
						<asp:DropDownList ID="ddlLink" runat="server">
						</asp:DropDownList>
					</td>
				</tr>
				
				<tr>
					<td class="bqleft">调用个数：</td>
					<td class="bqright"><input id="txtCount" type="text" size="3" value="10" /></td>
				</tr>

				<tr>
					<td class="bqleft">是否纵向排列：</td>
					<td class="bqright"><input id="chkArrange" type="checkbox" /></td>
				</tr>

				<tr>
					<td class="bqleft">每行显示个数：</td>
					<td class="bqright"><input id="rowCount" type="text" size="4" value="10" /></td>
				</tr>

				<tr>
					<td class="bqleft">打开窗口方式：</td>
					<td class="bqright">
							<select id="linkTarget">
								<option value="_self">_self</option>
								<option value="_parent">_parent</option>
								<option value="_search">_search</option>
								<option value="_blank">_blank</option>
								<option value="_top">_top</option>
							</select>
					</td>
				</tr>

				<tr>
					<td class="bqleft"></td>
					<td class="bqright">	
							<input id="Button31" type="button" value=" 确定创建此标签" class="btn" onclick=" FunLink()" />
							<input id="Button32" type="button" value="取消" onclick="javascript:window.close();" class="btn" />
					</td>
				</tr>
			</table>
			
			<table id="table17" width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" style="display: none">
	        <tr>
					<td class="bqleft">页面ID编号：</td>
					<td class="bqright">
						<select id="selcurrid">
								<option value="currchid">频道页编号</option>
								<option value="currcolid">栏目页编号</option>
								<option value="currinfoid">内容页编号</option>
							</select>
					</td>
				</tr>
				<tr>
					<td class="bqleft"></td>
					<td class="bqright">	
							<input id="Button33" type="button" value=" 确定创建此标签" class="btn" onclick="GetCurrId()" />
							<input id="Button34" type="button" value="取消" onclick="javascript:window.close();" class="btn" />
					</td>
				</tr>
				
			</table>
			<!--endbody-->
		</div>
	</form>
</body>
</html>
