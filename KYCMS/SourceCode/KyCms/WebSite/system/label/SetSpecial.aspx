<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetSpecial.aspx.cs" Inherits="System_label_SetSpecial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>专题参数设置</title>

	<link rel="stylesheet" href="../css/default.css" type="text/css" />
	<script language="javascript" src="../../JS/Common.js" type="text/javascript"></script>

	<script language="javascript" type="text/javascript">
		//列表页面的切换
		function SwitchList()
		{
			window.location.href=document.form1.selectList.value;	
		}

		function showHidenTop()
		{
			if($("chkIsPage").checked==false)
			{
				ultimateList.style.display="";
			}
			else
			{
				ultimateList.style.display="none";
				$("txtArticleCount").value="0";
			}						
		}

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

		function CreateSqecialList()
		{
                values="{$ky id=\"special_infolist\" ";	//专题Id
				values=values+"spid=\""+$("ddlSpecial").value+"\" ";
				
				if($("chkIsSqecail").checked==true) 
					values=values+"includesub=\"true\" ";
				else
					values=values+"includesub=\"false\" ";	
								
				if($("chkIsPage").checked==true)
				{
					values=values+"padding=\"true\" ";	                
					values=values+"paddingstyle=\""+$("txtPageStyle").value+"\" "; //分页样式
					values=values+"pagesize=\""+$("txtPageSize").value+"\" ";       //每页显示的数量
					values=values+"paddingcss=\""+$("txtPageCss").value+"\" ";
					values=values+"pagenav=\""+$("txtPageNav").value+"\" "			//分标签					   
				}
				else
				{
					values=values+"padding=\"false\" ";
				}
                                
                values=values+"liststyle=\""+$("ddlStyle").value+"\" ";//引用样式

				values=values+"cellcount=\""+$("selNewsColumn").value+"\" ";		//设置列表的列数

                //设置栏目显示的列数
                //values=values+"setcolumn=\""+document.form1.selColumn.value+"\" ";
                //显示样式
                    values=values+"showstyle=\""+$("selShowStyle").value+"\" ";
                //日期格式
                values=values+"dateformat=\""+$("txtDateFormat").value+"\" "
                
                //调用文章的条数
                values=values+"infocount=\""+$("txtArticleCount").value+"\" ";
               
               //日期范围
               values=values+"daterange=\""+$("txtDateRange").value+"\" ";
                
                //日期排序
                values=values+"order=\""+$("selectOrder").value+"\" ";
                
                //标题字数
                values=values+"titlelength=\""+$("txtTitleCount").value+"\" ";
                
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
				//dialogArguments.setx(values);
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
				//var range= document.selection.createRange();
				window.opener.document.all.lblContent.focus();
				if(window.opener.document.selection)
				{
						var reange=window.opener.document.selection.createRange();
						reange.text=values;
				}
				range.text = "{@page_nav}";
			}			
		}
	</script>
</head>
<body onload="showHidenTop()">
    <form id="form1" runat="server">
    <div>
            <!--top-->
            <table width="99%" border="0" cellpadding="0" cellspacing="0" class="wzdh" align="center">
                <tr>
                    <td>
                        <b>&nbsp;设置标签参数</b></td>
                    
                    <td align="right">
                        <a href="#" onclick="javascript:window.close();">关闭</a>&nbsp;</td>
                </tr>
            </table>
            <!--endtop-->

            <!--body-->
            <table width="99%" border="0" cellpadding="2" cellspacing="1" class="border" align="center">
                <tr id="row1">
                    <td class="bqleft" width="40">
                        <strong>所属专题：</strong></td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlSpecial" runat="server">
                        </asp:DropDownList>
						是否包含子专题：<input id="chkIsSqecail" type="checkbox" />
                    </td>
                </tr>

				<tr id="strNewsColumn">
					<td class="bqleft">专题列表列数：</td>
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

                <tr>
                    <td class="bqleft">
                        <strong>引用内容样式：</strong></td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlStyle" runat="server">
                        </asp:DropDownList>&nbsp;<a href="http://edu.kycms.com/" target="_blank"><img src="../images/icn_qa.gif" alt="什么是引用内容样式？" border="0" /></a>
                    </td>
                </tr>

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

                <tr>
                    <td class="bqleft">
                        日期样式：</td>
                    <td class="bqright">
                        <input id="txtDateFormat" type="text" value="YY年MM月DD日" size="12" />格式：YYYY(4位数的年份2006)、MM(月)、DD(日)、HH(小时)、MI(分)、SS(秒)</td>
                </tr>

                <tr>
                    <td class="bqleft">
                        <strong>是否使用分页：</strong></td>
                    <td class="bqright">
                        <input id="chkIsPage" name="chkIsPage" type="checkbox" checked="checked" onclick="showHidenTop()" />
                        分页样式
                        <input id="txtPageStyle" size="1" type="text" />
                        <input id="btnSetStyle" class="btn" type="button" value="设置" onclick="WinOpenDialog('SetPage.aspx',450,200)" />
                        每页数量
                        <input id="txtPageSize" type="text" size="1" value="10" />
                        分页CSS
                        <input id="txtPageCss" size="5" type="text" />
                    </td>
                </tr>

				<tr>
					<td class="bqleft">分页样式：</td>
					<td class="bqright">
						<textarea id="txtPageNav" rows="5" style="width:80%;"><tr><td>{@page_nav}</td></tr></textarea><br />
						&nbsp;<a href="#" onclick="setPageStyle()"><span style="color:#4975dc">插入分页标签</span></a>
					</td>					
				</tr>

                <tr id="ultimateList">
                    <td class="bqleft">
                        <strong>文章数目：</strong></td>
                    <td class="bqright">
                        <input name="txtArticleCount" id="txtArticleCount" type="text" value="0" size="3" maxlength="200" />
                        <span class="STYLE1"><span class="STYLE2">如果为0则显示所有文章</span></span></td>
                </tr>

                
                <tr>
                    <td class="bqleft">
                        <strong>日期范围：</strong></td>
                    <td class="bqright">
                        默认最近显示
                        <input type="text" value="0" size="4" maxlength="200" id="txtDateRange">
                        天的文章 <span class="STYLE1"><span class="STYLE2">如果为0则显示所有文章</span></span></td>
                </tr>

                <tr>
                    <td class="bqleft">
                        <strong>排序方式：</strong></td>
                    <td class="bqright">
                        <select name="selectOrder">
                            <option value="datedesc">添加日期降序</option>
                            <option value="dateasc">添加日期升序</option>
                            <option value="hitasc">文章点击升序</option>
                            <option value="hitdesc">文章点击降序</option>
                        </select>
                </tr>

                <tr>
                    <td class="bqleft">
                        <strong>标题字数： </strong>
                    </td>
                    <td align="left" class="bqright">
                        <input name="txtTitleCount" type="text" value="30" size="3" maxlength="200">
                        <span class="STYLE2">如果为0则显示完整标题</span></td>
                </tr>

                <tr id="trCom">
                    <td class="bqleft">
                        <strong>文章循环行样式：</strong></td>
                    <td class="bqright">
                        每显示<input type="text" value="0" size="1" maxlength="200" id="txtNewsRows">
                        行后，向循环列表中插入
                        <input type="text" value="&lt;hr&gt;" size="5" maxlength="200" id="txtCompart">
                        <span class="STYLE2">支持html代码</span></td>
                </tr>

                <tr>
                    <td colspan="2" align="center">
                        <input id="btnSubmit" class="btn" type="button" value="确定创建此标签" onclick="CreateSqecialList()" />
                        <input class="btn" type="button" value="取消" onclick="javascript:window.close();" /></td>
                </tr>

            </table>
            <!--endbody-->		
    </div>
    </form>
</body>
</html>
