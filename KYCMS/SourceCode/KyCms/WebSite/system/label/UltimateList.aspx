<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UltimateList.aspx.cs" Inherits="system_label_UltimateList" %>
<%@ Import Namespace="Ky.BLL.CommonModel" %>
<%@ Import Namespace="Ky.BLL" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="Ky.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>终极列表标签参数设置</title>
	<script language="javascript" type="text/javascript" src="../../js/Common.js"></script>
	<link rel="stylesheet" type="text/css" href="../css/default.css" />
	<script language="javascript" type="text/javascript">
		//列表页面的切换
		function SwitchList()
		{
			window.location.href=document.form1.selectList.value;	
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
			    $("selNewsColumn").style.display="none";
				$("ddlStyle").style.display="none";
				$("selShowStyle").style.display="none";
				$("selectOrder").style.display="none";
    		}
			else
			{
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

		//显示字段
		function hidenSelect()
		{
			    $("selNewsColumn").style.display="";
				$("ddlStyle").style.display="";
				$("selShowStyle").style.display="";
				$("selectOrder").style.display="";
				$("ddlStyle").options[0].selected=true;				
		}

		// 验正自定义样式的输入
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


	   //终极列表参数处理函数
	   function UltimateList()
	   {
                values="{$ky id=\"col_finallyinfolist\" ";										//提取栏目Id
                
                 //是否包含子栏目
                if($("chkIsPage").checked==true)
                    values=values+"padding=\"true\" ";
                else
                    values=values+"padding=\"false\" ";
                    
                values=values+"paddingstyle=\""+$("txtPageStyle").value+"\" "; //分页样式
                values=values+"pagesize=\""+$("txtPageSize").value+"\" ";        //每页显示的数量
                values=values+"paddingcss=\""+$("txtPageCss").value+"\" ";	   //分页使用的Css样式    
                values=values+"liststyle=\""+$("ddlStyle").value+"\" ";					//引用样式
				values=values+"cellcount=\""+$("selNewsColumn").value+"\" ";	//指定列表的数
				values=values+"modelid=\""+$("hidModelId").value+"\" ";			//模型Id
				values=values+"pagenav=\""+$("txtPageNav").value+"\" "			//分标签
                
                values=values+"showstyle=\""+$("selShowStyle").value+"\" ";		 //布局方式
                values=values+"dateformat=\""+$("txtDateFormat").value+"\" "   //日期格式
                values=values+"infocount=\""+$("txtArticleCount").value+"\" ";     //调用文章的条数
                values=values+"daterange=\""+$("txtDateRange").value+"\" ";  	 //日期范围
                values=values+"order=\""+$("selectOrder").value+"\" ";			     //排序方式
                values=values+"titlelength=\""+$("txtTitleCount").value+"\" ";      //标题字数
                   
                //显示的行数
                if($("txtNewsRows").value=="0")
                {
                    values=values+"rowcount=\"\" ";
                    values=values+"compart=\"\" /}";
                }
                else
                {
                    values=values+"rowcount=\""+$("txtNewsRows").value+"\" ";
                    values=values+"compart=\""+$("txtCompart").value+"\" /}";            
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

		function setPageStyle()
		{
			$('txtPageNav').focus();
			if (document.selection)
			{
				var range= document.selection.createRange();
				range.text = "{@page_nav}";
			}			
		}

		function CountFun()
		{
			if($("chkIsPage").checked==true)
				ultimateList.style.display="none";
			else
				ultimateList.style.display="";
		}

	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

            <!--top-->
            <table width="99%" border="0" cellpadding="0" cellspacing="0" class="wzdh" align="center" style="margin-top:1px;">
                <tr>
                    <td><b>&nbsp;终极列表标签参数设置</b></td>                    
                    <td align="right"><a href="#" onclick="javascript:window.close();">关闭</a>&nbsp;</td>
                </tr>
            </table>
            <!--endtop-->

			<!--body-->
			<table width="99%" border="0" cellpadding="0" cellspacing="1" class="border" align="center">

                <tr>
                    <td class="bqleft"><strong>标签所属类别：</strong></td>
                    <td class="bqright">
                      <select id="selectList" onchange="SwitchList()">
                            <option value="CommonlyList.aspx?modelId=<%=modelId  %>">普通列表</option>
                            <option value="CycChColList.aspx?modelId=<%=modelId  %>">栏目循环</option>
                            <option value="UltimateList.aspx?modelId=<%=modelId  %>" selected="selected">终极列表</option>
                            <option value="SubList.aspx?modelId=<%=modelId  %>">子类列表</option>
                        </select>
						<input id="hidModelId" type="hidden" value="<%=modelId %>" />
                    </td>
                </tr>


				<!--列表是否分页-->
                <tr id="trPage">
                    <td class="bqleft">
                        <strong>是否使用分页：</strong></td>
                    <td class="bqright">
                        <input id="chkIsPage" type="checkbox" checked="checked" onclick="CountFun()" />
                        分页效果
                        <input id="txtPageStyle" size="1" type="text" />
                        <input id="btnSetStyle" class="btn" type="button" value="设置" onclick="WinOpenDialog('SetPage.aspx',450,200)" />
                        每页数量
                        <input id="txtPageSize" type="text" size="2" value="10" />
                        分页CSS
                        <input id="txtPageCss" size="5" type="text" />
                    </td>
                </tr>
				<!--列表是否分页-->

				<tr>
					<td class="bqleft">分页样式：</td>
					<td class="bqright">
						<textarea id="txtPageNav" rows="5" style="width:80%;"><tr><td>{@page_nav}</td></tr></textarea><br />
						&nbsp;<a href="#" onclick="setPageStyle()"><span style="color:#4975dc">插入分页标签</span></a>
					</td>					
				</tr>

				<!--栏目列表-->
                <tr id="changeColumn" style="display: none;">
                    <td class="bqleft">
                        <strong id="STRONG1">请选择具体的栏目：</strong></td>
                    <td class="bqright">
                        <asp:ListBox ID="lbColumn" runat="server" Width="200" Height="150" SelectionMode="Multiple">
                        </asp:ListBox>
                    </td>
                </tr> 
				<!--end栏目列表-->


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
                        <select id="selShowStyle" onchange="ControlStyle()">
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
                <tr id="ultimateList" style="display:none;">
                    <td class="bqleft"><strong>文章数目：</strong></td>
                    <td class="bqright">
                        <input name="txtArticleCount" id="txtArticleCount" type="text" value="10" size="3" maxlength="200" />
                        <span class="STYLE1"><span class="STYLE2">如果为0则显示所有文章</span></span>
					</td>
                </tr>
				<!--end调用数据库表中记录的条数-->

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
                    <td colspan="2" align="center">
                        <input id="btnSubmit" class="btn" type="button" value="确定创建此标签" onclick="UltimateList()" />
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
						<a href="#" onclick="javascript:lyTest.style.display='none'; hidenSelect()"><img src="../images/skin/default/tab-close-on.gif" border="0" alt="关闭" /></a>
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
							<select id="select1" onchange="setx(this)">
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
							<select id="select2" onchange="setx(this)">
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
							<select id="select3" onchange="setx(this)">
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