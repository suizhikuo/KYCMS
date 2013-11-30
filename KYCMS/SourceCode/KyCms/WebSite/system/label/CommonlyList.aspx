<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommonlyList.aspx.cs" Inherits="system_label_CommonlyList" %>
<%@ Import Namespace="Ky.BLL.CommonModel" %>
<%@ Import Namespace="Ky.BLL" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="Ky.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>普通列表标签参数设置</title>
	<script language="javascript" type="text/javascript" src="../../js/Common.js"></script>
	<link rel="stylesheet" type="text/css" href="../css/default.css" />
	<script language="javascript" type="text/javascript">
		//列表页面的切换
		function SwitchList()
		{
			window.location.href=document.form1.selectList.value
		}

		//对复选框的处理
		function CheckBoxChecked(obj)
		{
                var   objs=document.getElementById(obj);
				if(objs.checked==true)
					objs.checked=false;
				else
					objs.checked=true;
		}
		
		//对单选按钮的处理(暂时没用)
		function RadioChecked(radioId,radioName)
		{
				//alert(radioId+"="+radioName);
				//alert(radioName.length);
                for(i=0;i<radioName.length;i++)
                {
                   if(radioName[i].id==radioId)
                    {                    
						radioName[i].checked=true;
                    }
               }
		}

	 //给隐藏域赋值
	 var hidStr="";
	 function HidSetValue(obj)
	 {
		var totalArr=new Array();	
        
		if(obj.type=="checkbox")
		{			
			if(obj.checked==true)
			{
				hidStr=hidStr+obj.name+"$"+obj.value+"|";		
			}
			else
			{
				hidStr=hidStr.replace(obj.name+"$"+obj.value+"|","");
			}
		}
		else
		{
			if(obj.value!="")
			{
				hidStr=hidStr+obj.name+"$"+obj.value+"|";
			    var pro=obj.name;
				var pro2=pro+"\\$.*?\\|";
                var reg=new RegExp(pro2,"ig");
                var temp=hidStr.replace(reg,"");
                hidStr=temp+pro+"$"+obj.value+"|";
                //hidStr=hidStr.replace(reg,pro+="=\""+obj.value+"\"");			
			}
				
		}
		$("hidPropertylField").value=hidStr;
    }		

		// 选择频道时调用频道相应的栏目
       function UpdateChild(result)
       {

          var childDropDown = document.forms[0].elements['ddlChild'];
          if (!childDropDown)
             return;

          childDropDown.length = 0;

          if (!result)
              return;
          
          var ddlChild = document.getElementById("ddlChild");
          ddlChild.options.add(new Option("当前栏目","0"));
		  ddlChild.options.add(new Option("所有栏目","all"));
          var items=result.split('|');
          for (var i = 0; i < items.length; i++)
          {
             var item=items[i].split(',');
			if(item[0]!="")
			{
				 var option = document.createElement("OPTION");
				 option.value = item[1];
				 option.innerHTML = item[0];
				 ddlChild.appendChild(option);
			}
          }         
       }
       function ShowError(result, context)
       {
          alert(result);
       }

        //控制显示的样式
       function ControlStyle()
       {
            if($("selShowStyle").value=="out_table")
            {
                trStyle1.style.display="none";
                trStyle2.style.display="none";                                        
            }
            else
            {
                trStyle1.style.display="";
                trStyle2.style.display="";                
            }
       }

       //自定义样式
		function CustomStyle()
		{
			if($("ddlStyle").value=="0")
			{
				myfun();
				try
				{
					userCustomStr.style.display="none";
				}
				catch(e)
				{}
			    $("selNewsColumn").style.display="none";
				$("ddlStyle").style.display="none";
				$("selShowStyle").style.display="none";
				$("selectOrder").style.display="none";
    		}
			else
			{
				try
				{
					userCustomStr.style.display="";
				}
				catch(e)
				{}
			    $("selNewsColumn").style.display="";
				$("ddlStyle").style.display="";
				$("selShowStyle").style.display="";
				$("selectOrder").style.display="";
			}
		}

		//初始化层
		function myfun()
		{
			lyTest.style.display="";
			lyTest.style.width="600";
			lyTest.style.height="350";
			lyTest.style.backgroundColor="#FFF";
			lyTest.style.marginLeft=50;
			lyTest.style.marginTop=82;
			lyTest.style.border="solid 2px #CCC";
		}

		//关闭层显示下拉框
		function hidenSelect()
		{
				try
				{
					userCustomStr.style.display="";
				}
				catch(e)
				{}
			    $("selNewsColumn").style.display="";
				$("ddlStyle").style.display="";
				$("selShowStyle").style.display="";
				$("selectOrder").style.display="";
				$("ddlStyle").options[0].selected=true;				
		}

		//验证用户在样式中的输入
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
		
		//给多行文本域赋值
		function setx(obj)
		{
			$("test").focus();
			if (document.selection)
			{
				var range= document.selection.createRange();
				if(obj.value=="$search$")
					range.text="<a href=javascript:showlist(\"<%=Param.ApplicationRootPath %>\",\"{KY_chid}\",\"字段名称\",\"{KY_字段名称}\",\"blank\")>字段值</a>";				
				else
					range.text= obj.value;
			}
			obj.options[0].selected=true;
		}

      //显示隐藏栏目top
      function shwhidtop()
      {
        if(document.form1.ddlChild.value=="0")
        {
            columnTop.style.display="";
        }
        else
        {
            columnTop.style.display="none";
        }                
      }

	  //频道设置显示隐藏栏目
	  function showhidenCol()
	 {
			if($("ddlParent").value=="0")
				showhidencol.style.display="none";
			else
				showhidencol.style.display="";
			
	 }

	   //普通列表使用的参数
	   function CreateCommonlyList()
	  {
            var values;
            //----------------------------栏目文章列表-----------------------------------------------
            if($("ddlChild").value!="all" && $("ddlParent").value!="0")
            {
                values="{$ky id=\"col_infolist\""+" colid=\""+$("ddlChild").value+"\" ";//提取栏目Id

                //是否包含子栏目
                if($("chkIncludeSub").checked==true)
                    values=values+"includesub=\"true\" ";
                else
                    values=values+"includesub=\"false\" ";

				values=values+"cellcount=\""+$("selNewsColumn").value+"\" ";		  //文章列表显示的列数               
                values=values+"liststyle=\""+$("ddlStyle").value+"\" ";						  //引用样式
				values=values+"modelid=\""+$("hidModelId").value+"\" ";				  //模型Id号
                
                values=values+"showstyle=\""+$("selShowStyle").value+"\" ";			 //布局方式
                values=values+"dateformat=\""+$("txtDateFormat").value+"\" "		 //日期格式
                values=values+"infocount=\""+$("txtArticleCount").value+"\" ";		 //调用文章的条数
                
		       //属性组合字符串
			  var prostr="";
			   //焦点
			   if($("Radio1").checked==true)
				{
					prostr="isfocus$1|";
				}

				//推荐
				if($("Radio2").checked==true)
				{
					prostr=prostr+"isrecommend$1|";
				}

				//置顶
				if($("Radio3").checked==true)
				{
					prostr=prostr+"istop$1|";
				}

				//热点
				if($("Radio4").checked==true)
				{
					prostr=prostr+"ishot$1|";
				}

				//图片
				if($("Radio5").checked==true)
				{
					prostr=prostr+"titletype$2|";
				}
				
				values=values+"property1=\""+prostr.substring(prostr,prostr.length-1)+"\" ";										//系统属性
				
				var customprostr=$("hidPropertylField").value;
				var str=customprostr.substring(customprostr,customprostr.length-1);

				//对字段的处理
				var strArr=str.split('|');
				var newStr="";
				for(var i=0;i<strArr.length;i++)
				{
					var arrItem=strArr[i].split('$')[0];
					var temp=strArr[i];
					for(var j=0;j<strArr.length;j++)
					{
						if(arrItem==strArr[j].split('$')[0]&&i!=j)
						{
							temp=temp+"|"+strArr[j];
						}	
					}
					if(newStr.indexOf(arrItem,0)==-1)
					{
						newStr=newStr+temp+"#";
					}
					temp="";
				}
				if(newStr!="")
				{
					newStr=newStr.substring(newStr,newStr.length-1);
				}

				values=values+"property2=\""+newStr+"\" ";	//用户自定义属性
                values=values+"daterange=\""+$("txtDateRange").value+"\" ";															//日期范围
                values=values+"order=\""+$("selectOrder").value+"\" ";																		//排序方式
                values=values+"titlelength=\""+$("txtTitleCount").value+"\" ";																//标题字数
                
                //显示的行数
                if($("txtNewsRows").value=="0")
                {
                    values=values+"rowcount=\"\" ";
                    values=values+"compart=\"\" ";
                }
                else
                {
                    values=values+"rowcount=\""+$("txtNewsRows").value+"\" ";
                    values=values+"compart=\""+$("txtCompart").value+"\" ";            
                }            
            }

			//-------------------------------------频道列表---------------------------------------------------
            if($("ddlChild").value=="all" || $("ddlParent").value=="0")
            {
                values="{$ky id=\"ch_infolist\""+" chid=\""+$("ddlParent").value+"\" ";				//提取栏目Id
				values=values+"cellcount=\""+$("selNewsColumn").value+"\" ";							//文章列表显示的列数
                values=values+"liststyle=\""+$("ddlStyle").value+"\" ";											//引用样式
				values=values+"modelid=\""+$("hidModelId").value+"\" ";									//模型Id
                
                values=values+"showstyle=\""+$("selShowStyle").value+"\" ";								//布局方式
                values=values+"dateformat=\""+$("txtDateFormat").value+"\" "							//日期格式                
                values=values+"infocount=\""+$("txtArticleCount").value+"\" ";							//调用文章的条数
                
		       //属性组合字符串
			  var prostr="";
			   //焦点
			   if($("Radio1").checked==true)
				{
					prostr="isfocus$1|";
				}

				//推荐
				if($("Radio2").checked==true)
				{
					prostr=prostr+"isrecommend$1|";
				}

				//置顶
				if($("Radio3").checked==true)
				{
					prostr=prostr+"istop$1|";
				}

				//热点
				if($("Radio4").checked==true)
				{
					prostr=prostr+"ishot$1|";
				}

				//图片
				if($("Radio5").checked==true)
				{
					prostr=prostr+"titletype$2|";
				}
				
				values=values+"property1=\""+prostr.substring(prostr,prostr.length-1)+"\" ";												//系统属性
				
				var customprostr=$("hidPropertylField").value;
				var str=customprostr.substring(customprostr,customprostr.length-1);

				//对字段的处理
				var strArr=str.split('|');
				var newStr="";
				for(var i=0;i<strArr.length;i++)
				{
					var arrItem=strArr[i].split('$')[0];
					var temp=strArr[i];
					for(var j=0;j<strArr.length;j++)
					{
						if(arrItem==strArr[j].split('$')[0]&&i!=j)
						{
							temp=temp+"|"+strArr[j];
						}	
					}
					if(newStr.indexOf(arrItem,0)==-1)
					{
						newStr=newStr+temp+"#";
					}
					temp="";
				}
				if(newStr!="")
				{
					newStr=newStr.substring(newStr,newStr.length-1);
				}

				values=values+"property2=\""+newStr+"\" ";	//用户自定义属性
                values=values+"daterange=\""+$("txtDateRange").value+"\" ";																	//日期范围
                values=values+"order=\""+$("selectOrder").value+"\" ";																				//排序方式
                values=values+"titlelength=\""+$("txtTitleCount").value+"\" ";																		//标题字数
                
                //显示的行数
                if($("txtNewsRows").value=="0")
                {
                    values=values+"rowcount=\"\" ";
                    values=values+"compart=\"\" ";
                }
                else
                {
                    values=values+"rowcount=\""+$("txtNewsRows").value+"\" ";
                    values=values+"compart=\""+$("txtCompart").value+"\" ";            
                }            
            }
            
           if($("chkAjax").checked)  
           {
                 values = values + "ajaxflag=\"1\" /}";
           }  
           else
           {
                 values = values + "/}";
           }   
			window.opener.document.all.lblContent.focus();
			if(window.opener.document.selection)
			{
					var reange=window.opener.document.selection.createRange();
					reange.text=values;
			}
			window.close();
	  }

	 function FunShoHIdComp()
	{
		if($("selNewsColumn").value!="1")
			trCom.style.display="none";
		else
			trCom.style.display="";
	}  

		
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

            <!--top-->
            <table width="99%" border="0" cellpadding="0" cellspacing="0" class="wzdh" align="center" style="margin-top:1px;">
                <tr>
                    <td><b>&nbsp;普通列表标签参数设置&nbsp;&nbsp;</b><span style="color:Red;">注意：为绿色背景的部分是用户自定义属性</span></td>                    
                    <td align="right"><a href="#" onclick="javascript:window.close();">关闭</a>&nbsp;</td>
                </tr>
            </table>
            <!--endtop-->

			<!--body-->
			<table width="99%" border="0" cellpadding="0" cellspacing="1" class="border" align="center">
				<!--start页面的切换-->
                <tr>
                    <td class="bqleft"><strong>标签所属类别：</strong></td>
                    <td class="bqright">
                      <select id="selectList" onchange="SwitchList()">
                            <option value="CommonlyList.aspx?modelId=<%=modelId  %>" selected="selected">普通列表</option>
                            <option value="CycChColList.aspx?modelId=<%=modelId  %>">栏目循环</option>
                            <option value="UltimateList.aspx?modelId=<%=modelId  %>">终极列表</option>
                            <option value="SubList.aspx?modelId=<%=modelId  %>">子类列表</option>
                        </select>
                    </td>
                </tr>
				<!--end页面的切换-->

				<!--选择内容表与频道或栏目相应的数据-->
                <tr id="row1">
                    <td class="bqleft" width="40">
                        <strong>所属频道：</strong></td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlParent" runat="server" onchange="ListData(this.options[this.selectedIndex].value);showhidenCol()"></asp:DropDownList>
						<span id="showhidencol"  style="display:none">栏目:
							<asp:DropDownList ID="ddlChild" runat="server" onchange="shwhidtop()">
							</asp:DropDownList> 
							<span id="columnTop">Top：<input id="txtcolumntop" type="text" size="2" /></span>
							<input type="checkbox" id="chkIncludeSub" /> 包含子栏目 <span class="STYLE2">不勾选则只调用选中的文章</span>
						</span>
                    </td>
                </tr>
				<!--end选择内容表与频道或栏目相应的数据-->

				<!--指定列表显示的的列数-->
				<tr id="strNewsColumn">
					<td class="bqleft">内容列表列数：</td>
					<td class="bqright">
						<select id="selNewsColumn" onchange="FunShoHIdComp()">
							<script language="javascript" type="text/javascript">
								for(i=1;i<=5;i++)
								{		
									document.write("<option value="+i+">"+i+"</option>");
								}
								</script>
						</select>	
					</td>
				</tr>
				<!--end指定列表显示的的列数-->

				<!--引用用户创建的样式-->
                <tr>
                    <td class="bqleft">
                        <strong>引用内容样式：</strong></td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlStyle" runat="server" onchange="CustomStyle();">
                        </asp:DropDownList>&nbsp;<a href="http://edu.kycms.com/" target="_blank"><img src="../images/icn_qa.gif" alt="什么是引用内容样式？" border="0" /></a>
                    </td>
                </tr>
				<!--引用用户创建的样式-->

				<!--用户选择代码的格式-->
                <tr>
                    <td class="bqleft">
                        <strong>布局方式：</strong></td>
                    <td class="bqright">
                        <select id="selShowStyle">
                            <option value="out_table" selected="selected">普通表格式</option>
                            <option value="out_div">DIV+CSS式</option>
                        </select>
                    </td>
                </tr>
				<!--end用户选择代码的格式-->

				<!--定义在列表中日期显示的格式-->
                <tr>
                    <td class="bqleft">
                        日期样式：</td>
                    <td class="bqright">
                        <input id="txtDateFormat" type="text" value="YY年MM月DD日" size="12" />格式：YYYY(4位数的年份2006)、MM(月)、DD(日)、HH(小时)、MI(分)、SS(秒)</td>
                </tr>
				<!--end定义在列表中日期显示的格式-->

				<!--调用数据库表中记录的条数-->
                <tr id="ultimateList">
                    <td class="bqleft"><strong>文章数目：</strong></td>
                    <td class="bqright">
                        <input name="txtArticleCount" id="txtArticleCount" type="text" value="10" size="3" maxlength="200" />
                        <span class="STYLE1"><span class="STYLE2">如果为0则显示所有文章</span></span>
					</td>
                </tr>
				<!--end调用数据库表中记录的条数-->

				<!--指定文章在表中的类别-->
                <tr id="trArticleProperty">
                    <td class="bqleft">
                        <strong>系统属性：</strong></td>
                    <td class="bqright">
                        <span class="mouseStyle" onclick="CheckBoxChecked('Radio1')"><input id="Radio1" name="FocusNews" type="checkbox" value="FocusNews"  onclick="CheckBoxChecked('Radio1')"/>焦点</span>
                        <span class="mouseStyle" onclick="CheckBoxChecked('Radio2')"><input id="Radio2" name="RecNews" type="checkbox" value="RecNews"  onclick="CheckBoxChecked('Radio2')"/>推荐</span>
                        <span class="mouseStyle" onclick="CheckBoxChecked('Radio3')"><input id="Radio3" name="TopNews" type="checkbox" value="TopNews"  onclick="CheckBoxChecked('Radio3')"/>置顶</span>
                        <span class="mouseStyle" onclick="CheckBoxChecked('Radio4')"><input id="Radio4" name="HotNews" type="checkbox" value="HotNews"  onclick="CheckBoxChecked('Radio4')"/>热点</span>
                        <span class="mouseStyle" onclick="CheckBoxChecked('Radio5')"><input id="Radio5" name="imagenews" type="checkbox" value="imagenews"  onclick="CheckBoxChecked('Radio5')"/> 图片</span>
						<input id="hidPropertylField" type="hidden" value="" />
						<input id="hidModelId" type="hidden" value="<%=modelId %>" /> 
	                </td>
                </tr>
				<!--end指定文章在表中的类别-->

				<%					
					if (modelId != 1 && modelId != 2 && modelId != 3)
					{
						B_ModelField ModelFieldBll = new B_ModelField();
						DataTable dt = ModelFieldBll.GetSelectPropertyTrue(modelId);
						if (dt.Rows.Count > 0)
						{						
				%>
						
				<!--模型中用户自定义属性
                <tr id="userCustomStr">
                    <td class="bqleft">
                        <strong>用户自定义属性：</strong></td>
                    <td class="bqright" style="padding:0px; border:0">
						<table cellpadding="0" cellspacing="1" border="0" style="background-color:#FFF;" width="100%">-->
							<%
					for (int j = 0; j < dt.Rows.Count; j++)
					{
						string MyTable = "";

						string[] MyContent = dt.Rows[j]["Content"].ToString().Split(new Char[] { ',' });
						string[] MyType = MyContent[0].Split(new Char[] { '=' });
						string[] MyValue = MyType[1].Split(new Char[] { '|' });

						switch (MyType[0])
						{
							case "2":
								MyTable = "<tr style=\"background-color:#FFF;\"><td class=\"bqleft1\" width=\"20%\">" + dt.Rows[j]["Alias"] + "：</td><td  class=\"bqright1\" width=\"80%\"><table><tr>";
								for (int i = 0; i < MyValue.Length; i++)
								{
									MyTable += "<td><input id=\"" + dt.Rows[j]["name"] + i + "\" value=" + MyValue[i] + " type=\"checkbox\" name=\"" + dt.Rows[j]["Name"] + "\" onclick=\"HidSetValue(this)\" /><label>" + MyValue[i] + "</label></td>";
								   if(i!=0&&(i+1)%6==0) 
								   {
									   MyTable += "</tr><tr>";
								   }
								}
								MyTable += "</tr></table></td></tr>";
								Response.Write(MyTable);
								break;
							case "1":
								MyTable = "<tr style=\"background-color:#FFF;\"><td class=\"bqleft\" width=\"20%\">" + dt.Rows[j]["Alias"] + "：</td><td class=\"bqright\" width=\"80%\"><select name=\"" + dt.Rows[j]["name"] + "\"  onchange=\"HidSetValue(this)\" ><option value=\"\">请选择</option>";
								for (int i = 0; i < MyValue.Length; i++)
								{
									MyTable += "<option value=\"" + MyValue[i] + "\">" + MyValue[i] + "</option>";
								}
								MyTable += "</select></td></tr>";
								Response.Write(MyTable);
								break;
							default:
								MyTable = "";
								break;
						}
					}
						   %><!--
						</table>
    
                    </td>
                </tr>	
				end模型中用户自定义属性-->
				<%
						}
					}
		        %>
				

				<!--显示指定日期范围内添加的内容-->
                <tr>
                    <td class="bqleft">
                        <strong>日期范围：</strong></td>
                    <td class="bqright">
                        默认最近显示
						<input type="text" value="0" size="4" maxlength="200" id="txtDateRange" />
                        天的文章 <span class="STYLE1"><span class="STYLE2">如果为0则显示所有文章</span></span></td>
                </tr>
				<!--end显示指定日期范围内添加的内容-->

				<!--添加的内容按添加日期与文章点击数方式排序-->
                <tr>
                    <td class="bqleft"><strong>排序方式：</strong></td>
                    <td class="bqright">
                        <select name="selectOrder" id="selectOrder">
                            <option value="datedesc">添加日期降序</option>
                            <option value="dateasc">添加日期升序</option>
                            <option value="hitasc">文章点击升序</option>
                            <option value="hitdesc">文章点击降序</option>
                        </select>
                </tr>
				<!--end添加的内容按添加日期与文章点击数方式排序-->

				<!--指定列表标题允许显示字的个数-->
                <tr>
                    <td class="bqleft"><strong>标题字数：</strong></td>
                    <td align="left" class="bqright">
                        <input name="txtTitleCount" type="text" value="30" size="3" maxlength="200" />
                        <span class="STYLE2">如果为0则显示完整标题</span></td>
                </tr>
				<!--end指定列表标题允许显示字的个数-->

				<!--将筛选出来的数据第显示多少记录后插入记录分分隔符-->
                <tr id="trCom">
                    <td class="bqleft"><strong>循环行样式：</strong></td>
                    <td class="bqright">
                        每显示<input type="text" value="0" size="1" maxlength="200" id="txtNewsRows" />行后，向循环列表中插入                        
                        <input type="text" value="&lt;hr&gt;" size="5" maxlength="200" id="txtCompart" />
                        <span class="STYLE2">支持html代码</span>
					</td>
                </tr>
				<!--end将筛选出来的数据第显示多少记录后插入记录分分隔符-->
                 <tr>
						    <td class="bqleft"><strong>标签类型：</strong></td>
						    <td class="bqright"><input type="checkbox" id="chkAjax" /><label for="chkAjax">设置该标签为ajax标签</label> </td>
						</tr>
            <tr>
                <tr>
                    <td colspan="2" align="center">
                        <input id="btnSubmit" class="btn" type="button" value="确定创建此标签" onclick="CreateCommonlyList()" />
                        <input class="btn" type="button" value="取消" onclick="javascript:window.close();" />
					</td>
                </tr>
			</table>
			<!--endbody-->
    </div>


	<div id="lyTest" style="display:none;position:absolute;top:0px;">
		<div style="width:100%; height:25px; background-color:#4775B1; padding:3px;">
			<div style="color:#FFFFFF; text-align:left; float:left; font-size:12px; margin-top:5px;"><b>创建样式</b></div>
			<div style="float:right; margin-top:5px; margin-right:3px;">
					<a href="#" onclick="javascript:lyTest.style.display='none'; hidenSelect()"><img src="../images/skin/default/tab-close-on.gif" alt="关闭"  border="0" /></a>
			</div>
		</div>
		<div>
			<table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center">
				<tbody>
					<tr>
						<td class="bqleft" style="width:100px;">
							样式名称：</td>
						<td class="bqright">
							<asp:TextBox ID="txtTypeName" runat="server" Width="40%" MaxLength="200"></asp:TextBox>
							<asp:DropDownList ID="ddlStyleType" runat="server">
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td align="right" class="bqleft" style="height: 25px; width:100px;">系统字段：</td>
						<td class="bqright" valign="middle" style="height: 25px">
						<asp:DropDownList ID="selectcolumn" runat="server" onchange="setx(this)">
						</asp:DropDownList>
						<%if (modelId != 1 && modelId != 2 && modelId != 3){%>
							用户自定义：
							<select id="selectChangeYou" onchange="setx(this)">
								<option value="">请选择样式字段</option>
								<%
									B_ModelField ModelFieldBll = new B_ModelField();
									DataTable dt = ModelFieldBll.GetList(modelId);
									for (int i = 0; i < dt.Rows.Count; i++)
									{
										Response.Write("<option value=\"{KY_" + dt.Rows[i]["Name"] + "}\">" + dt.Rows[i]["Alias"] + "</option>");
									}
								 %>
							</select>
						<%}
						else if (modelId == 1 && modelId != 2 && modelId != 3)
						{ %>
							字段：									
							<select id="selectChangeYou" onchange="setx(this)">
								<option value="">请选择样式字段</option>
								<%
									B_SysModelField sysModelFieldBll = new B_SysModelField();
									DataTable dt = sysModelFieldBll.GetArticleListDt();
									for (int i = 0; i < dt.Rows.Count; i++)
									{
										Response.Write("<option value=\"" + dt.Rows[i]["FieldValue"] + "\">" + dt.Rows[i]["FieldName"] + "</option>");
									}			
								 %>
							</select>		
						<%}
						else if (modelId != 1 && modelId == 2 && modelId != 3)
						{ %>
							字段：
							<select id="selectChangeYou" onchange="setx(this)">
								<option value="">请选择样式字段</option>
								<%
									B_SysModelField sysModelFieldBll = new B_SysModelField();
									DataTable dt = sysModelFieldBll.GetImageListDt();
									for (int i = 0; i < dt.Rows.Count; i++)
									{
										Response.Write("<option value=\"" + dt.Rows[i]["FieldValue"] + "\">" + dt.Rows[i]["FieldName"] + "</option>");
									}			
								 %>
							</select>	
						<%}
						else if (modelId != 1 && modelId != 2 && modelId == 3)
						{ %>
							字段：
							<select id="selectChangeYou" onchange="setx(this)">
								<option value="">请选择样式字段</option>
								<%
									B_SysModelField sysModelFieldBll = new B_SysModelField();
									DataTable dt = sysModelFieldBll.GetDownLoadListDt();
									for (int i = 0; i < dt.Rows.Count; i++)
									{
										Response.Write("<option value=\"" + dt.Rows[i]["FieldValue"] + "\">" + dt.Rows[i]["FieldName"] + "</option>");
									}			
								 %>
							</select>							
						<%} %>

						</td>
					</tr>
					<tr>
						<td align="right" class="bqleft" style="width:100px;">
							样式内容：</td>
						<td class="bqright">
							<textarea id="test" rows="10" cols="50" runat="server"></textarea>
						</td>
					</tr>
					<tr>
						<td colspan="2" align="center" style="height: 29px">
							<asp:Button ID="btnSave" CssClass="btn" runat="server" Text="添加样式" OnClick="btnSave_Click"  OnClientClick="return CheckValidate()"  />&nbsp;&nbsp;
							<input id="Button1" type="button" class="btn" value="关闭" onclick="javascript:lyTest.style.display='none';hidenSelect()"  />
						</td>
					</tr>
				</tbody>
			</table>			
		</div>
	</div>
    </form>
</body>
</html>
