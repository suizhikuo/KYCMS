<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsRoutine.aspx.cs" Inherits="System_label_NewsRoutine" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>模型常规</title>
    <link rel="stylesheet" type="text/css" href="../css/default.css" />
    <script language="javascript" src="../../JS/Common.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
           function UpdateChild(result)
           {

              var childDropDown = document.forms[0].elements['ddlChild'];
              if (!childDropDown)
                 return;

              childDropDown.length = 0;

              if (!result)
                  return;
              
              var ddlChild = document.getElementById("ddlChild");
              var items=result.split('|');
              ddlChild.options.add(new Option("当前栏目","0"));
			  ddlChild.options.add(new Option("所有栏目","all"));
              for (var i = 0; i < items.length; i++)
              {
                 var item=items[i].split(',');
                 var option = document.createElement("OPTION");
                 option.value = item[1];
                 option.innerHTML = item[0];
                 ddlChild.appendChild(option);
              }
              
           }

           function ShowError(result, context)
           {
              alert(result);
           } 


			//头条频道与栏目
           function UpdateChild1(result)
           {

              var childDropDown = document.forms[0].elements['ddlCoHeader'];
              if (!childDropDown)
                 return;

              childDropDown.length = 0;

              if (!result)
                  return;
              
              var ddlChild = document.getElementById("ddlCoHeader");
              var items=result.split('|');
              for (var i = 0; i < items.length; i++)
              {
                 var item=items[i].split(',');
                 var option = document.createElement("OPTION");
                 option.value = item[1];
                 option.innerHTML = item[0];
                 ddlChild.appendChild(option);
              }
              
           }

           function UpdateChild2(result)
           {

              var childDropDown = document.forms[0].elements['ddlPicCoHeader'];
              if (!childDropDown)
                 return;

              childDropDown.length = 0;

              if (!result)
                  return;
              var ddlChild = document.getElementById("ddlPicCoHeader");
              var items=result.split('|');
              for (var i = 0; i < items.length; i++)
              {
                 var item=items[i].split(',');
                 var option = document.createElement("OPTION");
                 option.value = item[1];
                 option.innerHTML = item[0];
                 ddlChild.appendChild(option);
              }
              
           }

           function ShowError(result, context)
           {
              alert(result);
           }


        function ShowHideTable(param)
        {
            Hiden();
            param.style.display="";
        }
        
        function Hiden()
        {
            for(i=1;i<=13;i++)
            {
                eval("table"+i).style.display="none";
            }
        }
        
        function HidSowDaoHangCount()
        {
            if(window.document.form1.selArrange1.checked==true)
                daohangshow.style.display="none";
            else
                daohangshow.style.display="";
        }
        
        function ShowColumnDaoHang()
        {
            if(window.document.form1.selArrange2.checked==true)
                columndaohangshow.style.display="none";
            else
                columndaohangshow.style.display="";        
        }

		//验证
		function CheckValidate()
		{			
			var sizeStr=$("txtimgsize").value;
			var strArr=sizeStr.split(",");
			if(!(CheckNumber(strArr[0])&&CheckNumber(strArr[1])))
			{		
				alert("高宽必须输入整数");
				return false;
			}
			else
				return true;
		}
        
        //文章浏览
        function NewsBrowse()
        {
            var values;
            values="{$ky id=\"browse_info\""+" style=\""+$("ddlStyle").value+"\" ";
            values=values+"dateformat=\""+$("txtDateFormat").value+"\" /}";
            //dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
            window.close();
        }
        
        //投票
        function Vote()
        {
            var values="";
            values="{$ky id=\"vote\" "+"topicstyle=\""+$("txtTopicStyle").value+"\" ";
			values=values+"votesubjectid=\""+$("ddlVote").value+"\" ";
            values=values+"optionstyle=\""+$("txtOptionStyle").value+"\" ";
            values=values+"arrange=\""+$("selArrange").value+"\" /}";
            //dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
            window.close();            
        }
        
		//频道与栏目导航
        function ChannelDaoHang()
        {
            var values="";
            values="{$ky id=\""+$("selDaoHang").value+"\" "+"navcss=\""+$("txtCss").value+"\" ";

			if($("selDaoHang").value=="index_col_nav")
			{
				values=values+" chid=\""+$("ddlNavChannel").value+"\" ";
			}
            
            if($("selArrange1").checked==true)
            {
                values=values+"arrange=\"false\" ";
            }
            else
            {
                values=values+"arrange=\"true\" ";
            }
			
			values=values+"target=\""+$("chnavtarget").value+"\" ";
            values=values+"navcount=\""+$("txtDaoHangCount").value+"\" ";
            values=values+"compart=\""+$("txtCompart").value+ "\"/}";
            //dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
            window.close();
        }
        
		//栏目导航
        function ColumnDaoHang()
        {
            var values="";
            values="{$ky id=\"col_childcol_nav\" "+"navcss=\""+$("txtColCss").value+"\" ";
            if($("selArrange2").checked==true)
            {
                values=values+"arrange=\"false\" ";
            }
            else
            {
                values=values+"arrange=\"true\" ";
            }
			values=values+"target=\""+$("colnavtarget").value+"\" ";
            values=values+"navcount=\""+$("txtColumnDaoHangCount").value+"\" ";
            values=values+"compart=\""+$("txtCompart2").value+ "\"/}";
			//dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
            window.close();
        }
        
		//专题导航
        function SpeacilDaoHang()
        {
            var values="";
            values="{$ky id=\""+$("selSpecial").value+"\" "+"navcss=\""+$("txtTitleCss").value+"\" ";
            if($("chkArrange").checked==true)
            {
                values=values+"arrange=\"false\" ";
            }
            else
            {
                values=values+"arrange=\"true\" ";
            }
			values=values+"target=\""+$("selSpeTarget").value+"\" ";
            values=values+"navcount=\""+$("txtSpeCount").value+"\" ";
            values=values+"compart=\""+$("txtSpCompart").value+ "\"/}";
			//dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
            window.close();
        }
		
		//Flash幻灯
		function FlashLight()
		{
			values="";
			values="{$ky id=\"col_flashinfolist\" ";
			if($("ddlChild").value=="all")
				values=values+"chid=\""+$("ddlParent").value+"\" ";
			values=values+"colid=\""+$("ddlChild").value+"\" ";
			values=values+"includesub=\""+$("selincludesub").value+"\" ";
			values=values+"infocount=\""+$("txtlightcount").value+"\" ";
			values=values+"titlelength=\""+$("txttitlelength").value+"\" ";
			values=values+"imgsize=\""+$("txtimgsize").value+"\" /}";
            //dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
            window.close();			
		}
		
		//搜索标签
		function SearchForm()
		{
			values="";
			values="{$ky id=\"searchform\" ";
			//values=values+"datesearch=\""+$("selDateSearch").value+"\" ";
			values=values+" /}";
			//values=values+"searchtype=\""+$("selSearchType").value+"\" /}";
            //dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
            window.close();			
		}

		//浏览次数统计标签
		function BrowsTotal()
		{
			values="";
			values="{$ky id=\"viewtotal\" /}"
            dialogArguments.setx(values);
            window.close();
		}

		//相关文章
		function AboutNews()
		{
			values="";
			values="{$ky id=\"info_relationinfolist\" ";
			values=values+"titlelength=\""+$("txtTitleLength1").value+"\" ";
			values=values+"dateformat=\""+$("txtDateFormat1").value+"\" ";
			values=values+"liststyle=\""+$("dropStyle").value+"\" /}";
            //dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
            window.close();
		}

		//文字头条
		function FontHeader()
		{
			values="";
			values="{$ky id=\"article_txt_headerlist\" ";
			values=values+"colid=\""+$("ddlCoHeader").value+"\" ";
			values=values+"cellcount=\""+$("selColumns").value+"\" ";
			values=values+"infocount=\""+$("txtNewsCount").value+"\" ";
			values=values+"titlelength=\""+$("txtTitleLength2").value+"\" ";
			values=values+"align=\""+$("selAlign").value+"\" /}";
            //dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
            window.close();
		}

		//图片头条
		function PicHeader()
		{
			values="";
			values="{$ky id=\"article_img_headerlist\" ";
			values=values+"colid=\""+$("ddlPicCoHeader").value+"\" /}";
            //dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
            window.close();
		}
		
		function ShowOption(result)
		{
			revert();
			result.style.backgroundColor="#4975dc";
			result.style.color="#FFFFFF";
		}
		
		function revert()
		{
			for( i=1;i<12;i++)
			{
				eval("td"+i).style.backgroundColor="#e6e6e6";
				eval("td"+i).style.color="#000000";
			}
		}

		//构建聚合标签
		function FunRss()
		{
			values="{$ky id=\"rsslink\" text=\""+$("txtRssLink").value+"\" ";

			if($("chkRssIsIncludeSub").checked==true)
				values=values+"includesub=\"true\" /}";
			else
				values=values+"includesub=\"false\" /}";
            //dialogArguments.setx(values);
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
            window.close();
		}

		function FunTig()
		{
			values="{$ky id=\"dig\" hrefcss=\""+$("digCss").value+"\" /}";
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
					ShowHideTable($("table6"));
					ShowOption($("td2"));
					break;
				case "3":
					ShowHideTable($("table10"));
					ShowOption($("td3"));
					break;
				case "4":
					ShowHideTable($("table11"));
					ShowOption($("td4"));
					break;
				case "5":
					ShowHideTable($("table3"));
					ShowOption($("td5"));
					break;
				case "6":
					ShowHideTable($("table4"));
					ShowOption($("td6"));
					break;
				case "7":
					ShowHideTable($("table5"));
					ShowOption($("td7"));
					break;
				case "8":
					ShowHideTable($("table9"));
					ShowOption($("td8"));
					break;
				case "10":
					ShowHideTable($("table2"));
					ShowOption($("td10"));
					break;
				case "11":
					ShowHideTable($("table12"));
					ShowOption($("td11"));
					break;
				case "12":
					ShowHideTable($("table13"));
					ShowOption($("td12"));
					break;
					
			}
		}

		function ShowHideIndexColNav()
		{
			var val=$("selDaoHang").value;
			if(val=="index_col_nav")
				trIndexColNav.style.display="";
			else
				trIndexColNav.style.display="none";
		}
    </script>
</head>
<body onload="ShowOption(td1);SetFocus()">
    <form id="form1" runat="server">
    <div>
    
        <!--starttop-->
            <table width="99%" border="0" cellpadding="0" cellspacing="0" class="wzdh" align="center">
                <tr><td><b>&nbsp;常规标签创建</b></td><td align="right"><a href="#" onclick="javascript:window.close();">关闭</a>&nbsp;</td></tr>
            </table>
        <!--endtop-->
        
        <!--startbody-->
        
            <!--start标签导航-->    
                <table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center">
                    <tr  class="bqright">
                        <td id="td1" align="center" width="12%" onclick="ShowHideTable(table1);ShowOption(this)" class="mouseStyle" style="height: 23px">内容浏览</td>
						<td id="td2"  align="center" width="12%" class="mouseStyle" onclick="ShowHideTable(table6);ShowOption(this)" style="height: 23px">FLASH幻灯</td>
						<td id="td3"  align="center" width="12%" style="height: 23px" onclick="ShowHideTable(table10);ShowOption(this)" class="mouseStyle">文字头条</td>
						<td id="td4"  align="center" width="12%" style="height: 23px" onclick="ShowHideTable(table11);ShowOption(this)" class="mouseStyle">图片头条</td>
						<td id="td5"  align="center" width="12%"  onclick="ShowHideTable(table3);ShowOption(this)" class="mouseStyle" style="height: 23px">频道导航</td>
						<td id="td6"  align="center" width="12%" onclick="ShowHideTable(table4);ShowOption(this)" class="mouseStyle" style="height: 23px">栏目导航</td>
						<td id="td7"  align="center" width="12%" onclick="ShowHideTable(table5);ShowOption(this)" class="mouseStyle">专题导航</td>
                        <td id="td8" align="center" width="12%" onclick="ShowHideTable(table9);ShowOption(this)" class="mouseStyle">相关内容</td>
                    </tr>
                    <tr  class="bqright">
						<td id="td9" align="center" width="12%" class="mouseStyle" onclick="ShowHideTable(table7);ShowOption(this)">搜索表单</td>
						<td id="td10" align="center" width="12%" onclick="ShowHideTable(table2);ShowOption(this)" class="mouseStyle">投票标签</td>
						<td id="td11" align="center" width="12%" class="mouseStyle" onclick="ShowHideTable(table12);ShowOption(this)">频道/栏目聚合标签</td>
						<%--<td id="td12" align="center" width="12%" class="mouseStyle" onclick="ShowHideTable(table13);ShowOption(this)">dig标签</td>--%>
						<td align="center" width="12%"></td>
						<td align="center" width="12%"></td>
						<td align="center" width="12%"></td>
						<td align="center" width="12%"></td>
						<td align="center" width="12%"></td>
                    </tr>
                </table>
            <!--end标签导航-->
            
            <!--start标签参数设置-->
                <!--文章浏览-->
                <table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" id="table1">
                    <tr><td class="bqleft">引用样式</td>
                        <td class="bqright">
                            <asp:DropDownList ID="ddlStyle" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr><td class="bqleft">显示日期格式</td><td class="bqright"><input id="txtDateFormat" type="text" value="YY年MM月DD日" />格式:YYYY(4位数的年份2006)、MM(月)、DD(日)、HH(小时)、MI(分)、SS(秒)</td></tr>
                    <tr><td class="bqleft"></td><td class="bqright"><input class="btn" id="btnSaveNewsBrowse" onclick="NewsBrowse()" type="button" value=" 确定创建此标签 " /> <input class="btn" id="btnCancel" type="button" value=" 取消 " onclick="javascript:window.close();" /></td></tr>                                        
                </table>
                
                <!--投票-->
                <table width="99%" border=0 cellpadding=2 cellspacing=1 class="border" align="center" id="table2" style="display:none;">
					<tr>
						<td class="bqleft">选择投票的主题：</td>
						<td class="bqright">
							<asp:DropDownList ID="ddlVote" runat="server">
							</asp:DropDownList>
							注意：此标签可以在录入内容时插入到内容中
						</td>
					</tr>
                    <tr><td class="bqleft" style="height: 28px">主题样式：</td><td class="bqright" style="height: 28px"><input id="txtTopicStyle" type="text" /></td></tr>
                    <tr><td class="bqleft" style="height: 28px">选项样式：</td><td class="bqright" style="height: 28px"><input id="txtOptionStyle" type="text" /></td></tr>
                    <tr><td class="bqleft">排列方式：</td>
                        <td class="bqright">
                            <select id="selArrange">
                                <option value="horizontal">横向</option>
                                <option value="vertical">纵向</option>
                            </select>
                        </td>
                    </tr>
                    <tr><td class="bqleft"></td><td class="bqright"><input class="btn" id="Button1" type="button" onclick="Vote()" value=" 确定创建此标签 " /> <input class="btn" id="Button2" type="button" value=" 取消 " onclick="javascript:window.close();" /></td></tr>
                </table>
            
                <!--频道导航-->                
                <table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" id="table3" style="display:none;">
                    <tr>
                        <td class="bqleft">选择导航位置：</td>
                        <td class="bqright">
                            <select id="selDaoHang" onchange="ShowHideIndexColNav()">
                                <option value="index_ch_nav">全站导航</option>
                                <option value="ch_col_nav">频道栏目页导航</option>
								<option value="index_col_nav">首页栏目导航</option>
                            </select>
                        </td>
                    </tr>
					
					<tr id="trIndexColNav" style="display:none;">
						<td class="bqleft">选择频道：</td>
						<td class="bqright">
							<asp:DropDownList ID="ddlNavChannel" runat="server">
							</asp:DropDownList>
						</td>
					</tr>

                    <tr>
                        <td class="bqleft">标题CSS：</td>
                        <td class="bqright">
                            <input id="txtCss" type="text" size="3" />
                            是否纵向排列：<input id="selArrange1" type="checkbox" onclick="HidSowDaoHangCount()" />
                            分隔符：<input id="txtCompart" type="text" size="2" />
                            <span id="daohangshow">每行显示的个数：<input id="txtDaoHangCount" type="text" size="2" /></span>    
                        </td>
                    </tr>
					
					<tr>
						<td class="bqleft">打开窗口方式：</td>
						<td class="bqright">
							<select id="chnavtarget">
								<option value="_self">_self</option>
								<option value="_parent">_parent</option>
								<option value="_search">_search</option>
								<option value="_blank">_blank</option>
								<option value="_top">_top</option>
							</select>
						</td>
					</tr>
                    <tr><td class="bqleft"></td><td class="bqright"><input id="Button3" type="button" value="确定创建此标签" class="btn" onclick="ChannelDaoHang()" /><input id="Button4" type="button" class="btn" value="取消" onclick="javascript:window.close();" /></td></tr>
                </table>
                
                <!--栏目导航-->
                <table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" id="table4" style="display:none;">
                    <tr>
                        <td class="bqleft">标题CSS：</td>
                        <td class="bqright">
                            <input id="txtColCss" type="text" size="2" />
                            是否纵向排列：<input id="selArrange2" type="checkbox" onclick="ShowColumnDaoHang()" />
                            分隔符：<input id="txtCompart2" type="text" size="2" />
                            <span id="columndaohangshow">每行的个数：<input id="txtColumnDaoHangCount" type="text" size="2" /></span>    
                        </td>
                    </tr>
					
					<tr>
						<td class="bqleft">打开窗口方式：</td>
						<td class="bqright">
							<select id="colnavtarget">
								<option value="_self">_self</option>
								<option value="_parent">_parent</option>
								<option value="_search">_search</option>
								<option value="_blank">_blank</option>
								<option value="_top">_top</option>
							</select>
						</td>
					</tr>
                    <tr><td class="bqleft"></td><td class="bqright"><input id="Button5" type="button" value="确定创建此标签" class="btn" onclick="ColumnDaoHang()" /><input class="btn" onclick="javascript:window.close();" id="Button6" type="button" value="取消" /></td></tr>
                </table>
                <!--专题导航-->
                <table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" id="table5" style="display:none;">
                    <tr>
                        <td class="bqleft">选择导航：</td>
                        <td class="bqright">
                            <select id="selSpecial">
                                <option value="index_sp_nav">全站专题导航</option>
                                <option value="sp_nav">专题导航</option>
                            </select>
                        </td>
                    </tr>
                   <tr>
                        <td class="bqleft">标题CSS：</td>
                        <td class="bqright">
                            <input id="txtTitleCss" type="text" size="2" />
                            是否纵向排列：<input id="chkArrange" type="checkbox" />
                            分隔符：<input id="txtSpCompart" type="text" size="2" />
                            <span id="Span1">每行的个数：<input id="txtSpeCount" type="text" size="2" /></span>    
                        </td>
                    </tr>
					
					<tr>
						<td class="bqleft">打开窗口方式：</td>
						<td class="bqright">
							<select id="selSpeTarget">
								<option value="_self">_self</option>
								<option value="_parent">_parent</option>
								<option value="_search">_search</option>
								<option value="_blank">_blank</option>
								<option value="_top">_top</option>
							</select>
						</td>
					</tr>
                    <tr><td class="bqleft"></td><td class="bqright"><input id="Button7" type="button" value="确定创建此标签" class="btn" onclick="SpeacilDaoHang()" /><input class="btn" onclick="javascript:window.close();" id="Button8" type="button" value="取消" /></td>
					</tr>
                </table>
                
				<!--flash幻灯-->
                <table width="99%" border=0 cellpadding=2 cellspacing=1 class="border" align="center" id="table6" style="display:none;">
                    <tr><td class="bqleft">选择频道：</td>
                        <td class="bqright">
						 <asp:DropDownList ID="ddlParent" runat="server" onchange="ListData(this.options[this.selectedIndex].value);">
                         </asp:DropDownList>
					     栏目：<asp:DropDownList ID="ddlChild" runat="server">
                         </asp:DropDownList>
						是否包含子栏目：
						<select id="selincludesub">
							<option value="true">是</option>
							<option value="false">否</option>
						</select>
                        </td>
                    </tr>
                    <tr><td class="bqleft">调用数量：</td><td class="bqright"><input id="txtlightcount" type="text" value="5" /></td></tr>
                    <tr><td class="bqleft">标题字数：</td><td class="bqright"><input id="txttitlelength" type="text" value="30" /></td></tr>
                    <tr><td class="bqleft">图片尺寸（高度，宽度）：</td><td class="bqright"><input id="txtimgsize" type="text" value="120,100" />格式120，100。请正确使用格式</td></tr>
                    <tr><td class="bqleft"></td><td class="bqright"><input id="Button9" type="button" value="确定创建此标签" class="btn" onclick="FlashLight()" /><input id="Button10" type="button" value="取消" class="btn" onclick="javascript:window.close()" /></td></tr>                    
                </table>
				
				<!--搜索表单-->
				<table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" id="table7" style="display:none;">
					<tr><td class="bqleft"></td>
						<td class="bqright">
							<input id="Button11" type="button" value="确认创建此标签" onclick="SearchForm()" class="btn"/>
							<input id="Button12" type="button" value="取消" onclick="javascript:window.close()"  class="btn"/>
						</td>
					</tr>
				</table>  
				<!--end-->

			<!--start文章浏览次数统计-->
				<table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" id="table8" style="display:none;">
					<tr><td class="bqleft"></td>
						<td class="bqright">
							<input id="Button13" type="button" value="确认创建此标签" onclick="BrowsTotal()" class="btn" />
							<input id="Button14" type="button" value="取消" onclick="javascript:window.close()" class="btn" />
						</td>
					</tr>
				</table>				
			<!--end-->
			
			<!--相关文章-->
				<table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" id="table9" style="display:none;">
					<tr><td class="bqleft">文章标题长度：</td><td class="bqright"><input id="txtTitleLength1" type="text" value="30" /></td></tr>
					<tr><td class="bqleft">日期格式：</td><td class="bqright"><input id="txtDateFormat1" type="text" value="YY年MM月DD日" />格式:YYYY(4位数的年份2006)、MM(月)、DD(日)、HH(小时)、MI(分)、SS(秒)</td></tr>
					<tr><td class="bqleft">引用样式：</td><td class="bqright">
						<asp:DropDownList ID="dropStyle" runat="server">
						</asp:DropDownList></td>
					</tr>
					<tr><td class="bqleft"></td>
						<td class="bqright">
							<input id="Button15" type="button" value="确认创建此标签" onclick="AboutNews()" class="btn" />
							<input id="Button16" type="button" value="取消" onclick="javascript:window.close()" class="btn" />
						</td>
					</tr>
				</table>				
			<!--end--> 

			<!--文字头条-->
				<table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" id="table10" style="display:none;">
					<tr>
						<td class="bqleft">选择频道：</td>
						<td class="bqright">
							<asp:DropDownList ID="ddlChHeader" runat="server"  onchange="ListData1(this.options[this.selectedIndex].value);">
							</asp:DropDownList>
							栏目：
							<asp:DropDownList ID="ddlCoHeader" runat="server">
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td class="bqleft">列数：</td>
						<td class="bqright">
							<select id="selColumns">
								<script language="javascript" type="text/javascript">
									for(i=1;i<=5;i++)
									{
										document.write("<option value="+i+">"+i+"</option>");
									}
								</script>
							</select>
						</td>
					</tr>
					<tr>
						<td class="bqleft">调用数量：</td>
						<td class="bqright">	<input id="txtNewsCount" type="text" size="5" />标题字数：<input id="txtTitleLength2" type="text" size="5" value="30" /></td>
					</tr>
					<tr>
						<td class="bqleft">对齐方式：</td>
						<td class="bqright">
							<select id="selAlign">
								<option value="left">左</option>
								<option value="center">中</option>
								<option value="right">右</option>
							</select>
						</td>
					</tr>
					<tr>
						<td class="bqleft"></td>
						<td class="bqright">
							<input id="Button17" type="button" value="确认创建此标签" onclick="FontHeader()" class="btn" />
							<input id="Button18" type="button" value="取消" onclick="javascript:window.close()" class="btn" />
						</td>
					</tr>
				</table>	
			<!--end-->

			<!--图片头条-->
				<table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" id="table11" style="display:none;">
					<tr>
						<td class="bqleft">选择频道：</td>
						<td class="bqright">
							<asp:DropDownList ID="ddlPicChHeader" runat="server"  onchange="ListData2(this.options[this.selectedIndex].value);">
							</asp:DropDownList>
							栏目：
							<asp:DropDownList ID="ddlPicCoHeader" runat="server">
							</asp:DropDownList>
						</td>
					</tr>
					<tr><td class="bqleft"></td>
						<td class="bqright">
							<input id="Button19" type="button" value="确认创建此标签" onclick="PicHeader()" class="btn" />
							<input id="Button20" type="button" value="取消" onclick="javascript:window.close()" class="btn" />
						</td>
					</tr>
				</table>	
			<!--end-->
                            
			<!--站点地图-->
				<table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" id="table12" style="display:none;">
					<tr>
						<td class="bqleft">RSS链接地址文本：</td>
						<td class="bqright"><input id="txtRssLink" type="text" /> 注意：只能在频道|栏目页解析,可以使用文字或图片作为链接显示的文本</td>
					</tr>
					<tr>
						<td class="bqleft">是否包含子栏目：</td>
						<td class="bqright"><input id="chkRssIsIncludeSub" type="checkbox" />&nbsp;注意：此标签放在栏目页才有效</td>
					</tr>
					<tr>
						<td class="bqleft"></td>
						<td class="bqright">
							<input id="Button21" type="button" value="确认创建此标签" onclick="FunRss()" class="btn" />
							<input id="Button22" type="button" value="取消" onclick="javascript:window.close()" class="btn" />
						</td>
					</tr>
				</table>	
			<!--end-->
			<!--dig标签-->
				<table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center" id="table13" style="display:none">
					<tr>
						<td class="bqleft">digCss：</td>
						<td class="bqright"><input id="digCss" type="text" /></td>
					</tr>
					<tr>
						<td class="bqleft"></td>
						<td class="bqright">
							<input id="Button23" type="button" value="确认创建此标签" onclick="FunTig()" class="btn" />
							<input id="Button24" type="button" value="取消" onclick="javascript:window.close()" class="btn" />
						</td>
					</tr>
				</table>
			<!--end-->
            <!--end标签参数设置-->
        <!--endbody-->    
    </div>
    </form>
</body>
</html>
