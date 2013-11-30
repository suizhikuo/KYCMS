<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetLabelParameter.aspx.cs"   Inherits="System_Label_LabelSetParameter" enableEventValidation="true" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>标签参数设置</title>

    <link rel="stylesheet" href="../css/default.css" type="text/css" />
    <script language="javascript" src="../../JS/Common.js" type="text/javascript"></script>

	<base target=_self></base>
    <script language="javascript" type="text/javascript">

		function hidenSelect()
		{
			    $("selNewsColumn").style.display="";
				$("ddlColumnStyle").style.display="";
				$("ddlStyle").style.display="";
				$("selShowStyle").style.display="";
				$("selectOrder").style.display="";
				$("lbColumn").style.display="";
				$("selColumn").style.display="";
				$("ddlStyle").options[0].selected=true;
				
		}
       //自定义样式
		function CustomStyle()
		{
			if($("ddlStyle").value=="0")
			{
				//myfun();
			    $("selNewsColumn").style.display="none";
				$("ddlColumnStyle").style.display="none";
				$("ddlStyle").style.display="none";
				$("selShowStyle").style.display="none";
				$("selectOrder").style.display="none";
				$("lbColumn").style.display="none";
				$("selColumn").style.display="none";
				

//				customStyle.style.display="";
//				window.dialogWidth=parseInt(window.dialogWidth.substring(0,3))+200+"px";
//				window.dialogHeight=parseInt(window.dialogHeight.substring(0,3))+200+"px";
    		}
			else
			{
			    $("selNewsColumn").style.display="";
				$("ddlColumnStyle").style.display="";
				$("ddlStyle").style.display="";
				$("selShowStyle").style.display="";
				$("selectOrder").style.display="";
				$("lbColumn").style.display="";
				$("selColumn").style.display="";				
//				customStyle.style.display="none";
//				window.dialogWidth=parseInt(window.dialogWidth.substring(0,3))-200+"px";
//				window.dialogHeight=parseInt(window.dialogHeight.substring(0,3))-200+"px";
			}
		}    
           var flag="optEmpty";
           function radioMar()
           {
                
                var objs=document.getElementsByName("article")
                if(objs[5].checked==true)
                {
                    trMarquee.style.display="";
                }
                else
                {
                    trMarquee.style.display="none";
                }
        
           }
           
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
                 var option = document.createElement("OPTION");
                 option.value = item[1];
                 option.innerHTML = item[0];
                 ddlChild.appendChild(option);
              }
              
              
           }

           function UpdateChild1(result)
           {

              var childDropDown = document.forms[0].elements['lbColumn'];
              if (!childDropDown)
                 return;

              childDropDown.length = 0;

              if (!result)
                  return;
              
              var lbColumn = document.getElementById('lbColumn');
              var items=result.split('|');
              for (var i = 0; i < items.length; i++)
              {
                 var item=items[i].split(',');
                 var option = document.createElement("OPTION");
                 option.value = item[1];
                 option.innerHTML = item[0];
                 lbColumn.appendChild(option);
              }
              
              
           }

           function UpdateChild2(result)
           {
              var childDropDown = document.forms[0].elements['ddlChild1'];
              if (!childDropDown)
                 return;

              childDropDown.length = 0;

              if (!result)
                  return;
              
              var ddlChild = document.getElementById("ddlChild1");
              ddlChild.options.add(new Option("当前栏目","0"));
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
           var temp=parseInt(window.dialogHeight.substring(0,3));
           function showColumn()
           {
                if($("ddlChinel").value!="0")
                {
                    changeColumn.style.display="";
                    $("spTop").style.display="none";
					
					window.dialogWidth=parseInt(window.dialogWidth.substring(0,3))+10+"px";
					window.dialogHeight=parseInt(window.dialogHeight.substring(0,3))+80+"px"
//					if((temp+100)<=690 && $("ddlStyle").value!="0")
//					{
//						window.dialogWidth=parseInt(window.dialogWidth.substring(0,3))+10+"px";
//						window.dialogHeight=parseInt(window.dialogHeight.substring(0,3))+100+"px";
//					}
//					if((temp+100)<=890 && $("ddlStyle").value!="0")
//					{
//						window.dialogWidth=parseInt(window.dialogWidth.substring(0,3))+10+"px";
//						window.dialogHeight=parseInt(window.dialogHeight.substring(0,3))+100+"px";
//					}
                }
                else
                {
                    changeColumn.style.display="none";
                    $("spTop").style.display="";
					window.dialogWidth=parseInt(window.dialogWidth.substring(0,3))-10+"px";
					window.dialogHeight=parseInt(window.dialogHeight.substring(0,3))-80+"px";
                }
                                    
           }
           
    
          //标签所属类别
          function LabelIsType()
          {
			if($("selOfType").value!="optNews" && $("selOfType").value!="optSpecial" && $("selOfType").value=="optColumn")
            {
                changeChinel.style.display="";
                columnstyle.style.display="";
                trShowColumns.style.display="";
                row1.style.display="none";
				Tr1.style.display="none";
				ultimateList.style.display="";
				strNewsColumn.style.display="none";
				trArticleProperty.style.display="none";
				//trCh.style.display="none";
				//isChkChannel.style.display="none";
                flag="optColumn";                
            }
            else if($("selOfType").value=="optNews" && $("selOfType").value!="optSpecial")
            {
                trPage.style.display="";
                trShowColumns.style.display="none";
                row1.style.display="none";
                Tr1.style.display="none";
				columnstyle.style.display="none";
                changeChinel.style.display="none";
                changeColumn.style.display="none";
				trArticleProperty.style.display="none"; 
				ultimateList.style.display="none";
				//isChkChannel.style.display="none";
				//trCh.style.display="none";
				strNewsColumn.style.display="";               
                flag="optNews";
            }
            else if($("selOfType").value=="optSubNews")
            {
                trPage.style.display="none";
                changeChinel.style.display="none";
                changeColumn.style.display="none";
				strNewsColumn.style.display="none";                
                trArticleProperty.style.display="none";
				ultimateList.style.display="";
				//trCh.style.display="none";
				//isChkChannel.style.display="none";
				trShowColumns.style.display="";
                row1.style.display="none";
				Tr1.style.display="";
                columnstyle.style.display="";
                flag="optSubNews";
            }
            else
            {
                trPage.style.display="none";
                trShowColumns.style.display="none";
                changeChinel.style.display="none";
                changeColumn.style.display="none";
                columnstyle.style.display="none";
				columnTop.style.display="none";
				ultimateList.style.display="";
				//isChkChannel.style.display="";
				//isChkChannel.checked=false;				
				trArticleProperty.style.display="";
				strNewsColumn.style.display="";
                row1.style.display="";
				Tr1.style.display="none";
                flag="optEmpty";         
            }
          }
          
          //显示隐藏栏目top
          function shwhidtop()
          {
            //alert(document.form1.ddlParent.value=="0");
            if(document.form1.ddlChild.value=="0")
            {
                columnTop.style.display="";
            }
            else
            {
                columnTop.style.display="none";
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

		  //显示隐藏频道
//		  function trChShow()
//		  {
//				if($("chkChannel").checked==true)
//					trCh.style.display="";
//				else
//					trCh.style.display="none";
//		  }


		  //频道设置显示隐藏栏目
		  function showhidenCol()
		 {
				if($("ddlParent").value=="0")
					showhidencol.style.display="none";
				else
					showhidencol.style.display="";
				
		 }
          
 


        //栏目文章列表
        function CreateColumnList()
        {
            var values;
            //----------------------------栏目文章列表-----------------------------------------------
            if(flag=="optEmpty" && $("ddlChild").value!="all" && $("ddlParent").value!="0")
            {
                values="{$ky id=\"columnnews\""+" columnid=\""+$("ddlChild").value+"\" ";//提取栏目Id
                //是否包含子栏目
                if($("chkIncludeSub").checked==true)
                    values=values+"includesub=\"true\" ";
                else
                    values=values+"includesub=\"false\" ";

				values=values+"newscolumn=\""+$("selNewsColumn").value+"\" "; //文章列表显示的列数               
                values=values+"liststyle=\""+$("ddlStyle").value+"\" ";//引用样式
                
                //显示样式
                    values=values+"showstyle=\""+$("selShowStyle").value+"\" ";
                    values=values+"divid=\""+$("DivID").value+"\" ";
                    values=values+"divclass=\""+$("Divclass").value+"\" ";
                    values=values+"ulid=\""+$("ulid").value+"\" ";
                    values=values+"ulclass=\""+$("ulclass").value+"\" ";
                    values=values+"liid=\""+$("liid").value+"\" ";
                    values=values+"liclass=\""+$("liclass").value+"\" ";         

                //日期格式
                values=values+"dateformat=\""+$("txtDateFormat").value+"\" "
                
                
                //调用文章的条数
                values=values+"newscount=\""+$("txtArticleCount").value+"\" ";
                
                //文章属性
                var   objs=document.getElementsByName("article")
                for(i=0;i<objs.length;i++)
                {
                   if(objs[i].checked==true)
                    {                    
                        values=values+"article=\""+objs[i].value+"\" ";
                        values=values+"marpace=\""+$("txtPace").value+"\" ";
                        values=values+"mardirection=\""+$("selDirection").value+"\" ";
                    }
               } 
               
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
            }


			//-------------------------------------频道列表---------------------------------------------------
            if(flag=="optEmpty" && $("ddlChild").value=="all" || $("ddlParent").value=="0")
            {
                values="{$ky id=\"channelnews\""+" channelid=\""+$("ddlParent").value+"\" ";//提取栏目Id
                //是否包含子栏目
//                if($("chkIncludeSub").checked==true)
//                    values=values+"includesub=\"true\" ";
//                else
//                    values=values+"includesub=\"false\" ";

				values=values+"newscolumn=\""+$("selNewsColumn").value+"\" "; //文章列表显示的列数               
                values=values+"liststyle=\""+$("ddlStyle").value+"\" ";//引用样式
                
                //显示样式
                    values=values+"showstyle=\""+$("selShowStyle").value+"\" ";
                    values=values+"divid=\""+$("DivID").value+"\" ";
                    values=values+"divclass=\""+$("Divclass").value+"\" ";
                    values=values+"ulid=\""+$("ulid").value+"\" ";
                    values=values+"ulclass=\""+$("ulclass").value+"\" ";
                    values=values+"liid=\""+$("liid").value+"\" ";
                    values=values+"liclass=\""+$("liclass").value+"\" ";         

                //日期格式
                values=values+"dateformat=\""+$("txtDateFormat").value+"\" "
                
                
                //调用文章的条数
                values=values+"newscount=\""+$("txtArticleCount").value+"\" ";
                
                //文章属性
                var   objs=document.getElementsByName("article")
                for(i=0;i<objs.length;i++)
                {
                   if(objs[i].checked==true)
                    {                    
                        values=values+"article=\""+objs[i].value+"\" ";
                        values=values+"marpace=\""+$("txtPace").value+"\" ";
                        values=values+"mardirection=\""+$("selDirection").value+"\" ";
                    }
               } 
               
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
            }			
            
            
            //------------------------------------频道文章列表-------------------------------------------------         
            if(flag=="optColumn")
            {
                values="{$ky id=\"channelcolumnnews\""+" channelid=\""+$("ddlChinel").value+"\" ";//提取栏目Id
                values=values+"columnnum=\""+$("txtTop").value+"\" ";
                var str="";
                for(i=0;i<$("lbColumn").options.length;i++)
                {
                    if($("lbColumn").options[i].selected==true)
                    {
                        str=str+$("lbColumn").options[i].value+",";
                    }
                }
                if(str.length>0)
                {
                    str=str.substring(0,str.length-1);
                }
                
                if($("chkChIncludeSub").checked==true)
                    values=values+"includesub=\"true\"";
                else
                    values=values+"includesub=\"false\" ";
                                    
                values=values+"columnidstr=\""+str+"\"";
                
                values=values+"columnstyle=\""+$("ddlColumnStyle").value+"\" "; //引用栏目样式
                
                values=values+"liststyle=\""+$("ddlStyle").value+"\" ";//引用样式
                
                //设置栏目显示的列数
                values=values+"setcolumn=\""+document.form1.selColumn.value+"\" ";
                
                //显示样式
                    values=values+"showstyle=\""+$("selShowStyle").value+"\" ";
                    values=values+"divid=\""+$("DivID").value+"\" ";
                    values=values+"divclass=\""+$("Divclass").value+"\" ";
                    values=values+"ulid=\""+$("ulid").value+"\" ";
                    values=values+"ulclass=\""+$("ulclass").value+"\" ";
                    values=values+"liid=\""+$("liid").value+"\" ";
                    values=values+"liclass=\""+$("liclass").value+"\" ";         

                //日期格式
                values=values+"dateformat=\""+$("txtDateFormat").value+"\" "
                
                
                //调用文章的条数
                values=values+"newscount=\""+$("txtArticleCount").value+"\" ";
                
                //文章属性
                var   objs=document.getElementsByName("article")
                for(i=0;i<objs.length;i++)
                {
                   if(objs[i].checked==true)
                    {                    
                        values=values+"article=\""+objs[i].value+"\" ";
                        values=values+"marpace=\""+$("txtPace").value+"\" ";
                        values=values+"mardirection=\""+$("selDirection").value+"\" ";
                    }
               } 
               
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
            }
            
            //--------------------------------子栏目文章列表-----------------------------------------
            if(flag=="optSubNews")
            {
                values="{$ky id=\"childlist\""+" columnid=\""+$("ddlChild1").value+"\" ";//提取栏目Id
                
                values=values+"top=\""+$("txtcolumntop1").value+"\" ";
                //是否包含子栏目
                if($("chkIncludeSub1").checked==true)
                    values=values+"includesub=\"true\"";
                else
                    values=values+"includesub=\"false\" ";
                    
                values=values+"columnstyle=\""+$("ddlColumnStyle").value+"\" "; //引用栏目样式    
                
                values=values+"liststyle=\""+$("ddlStyle").value+"\" ";//引用样式
                
                //设置栏目显示的列数
                values=values+"setcolumn=\""+document.form1.selColumn.value+"\" ";
                //显示样式
                    values=values+"showstyle=\""+$("selShowStyle").value+"\" ";
                    values=values+"divid=\""+$("DivID").value+"\" ";
                    values=values+"divclass=\""+$("Divclass").value+"\" ";
                    values=values+"ulid=\""+$("ulid").value+"\" ";
                    values=values+"ulclass=\""+$("ulclass").value+"\" ";
                    values=values+"liid=\""+$("liid").value+"\" ";
                    values=values+"liclass=\""+$("liclass").value+"\" ";         

                //日期格式
                values=values+"dateformat=\""+$("txtDateFormat").value+"\" "
                
                
                //调用文章的条数
                values=values+"newscount=\""+$("txtArticleCount").value+"\" ";
                
                //文章属性
                var   objs=document.getElementsByName("article")
                for(i=0;i<objs.length;i++)
                {
                   if(objs[i].checked==true)
                    {                    
                        values=values+"article=\""+objs[i].value+"\" ";
                        values=values+"marpace=\""+$("txtPace").value+"\" ";
                        values=values+"mardirection=\""+$("selDirection").value+"\" ";
                    }
               } 
               
               //日期范围
               values=values+"daterange\""+$("txtDateRange").value+"\" ";
               

                
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
            }

            //-------------------------------------终极文章列表参数------------------------------------------            
            if(flag=="optNews")
            {
                values="{$ky id=\"finallycolumnnews\" ";//提取栏目Id
                
                //是否包含子栏目
                if($("chkIsPage").checked==true)
                    values=values+"padding=\"true\" ";
                else
                    values=values+"padding=\"false\" ";
                    
                
                values=values+"paddingstyle=\""+$("txtPageStyle").value+"\" "; //分页样式
                
                values=values+"pagesize=\""+$("txtPageSize").value+"\" ";       //每页显示的数量
                
                values=values+"paddingcss=\""+$("txtPageCss").value+"\" ";    
                                
                values=values+"liststyle=\""+$("ddlStyle").value+"\" ";//引用样式

				values=values+"newscolumn=\""+$("selNewsColumn").value+"\" ";

                //设置栏目显示的列数
                //values=values+"setcolumn=\""+document.form1.selColumn.value+"\" ";
                //显示样式
                    values=values+"showstyle=\""+$("selShowStyle").value+"\" ";
                    values=values+"divid=\""+$("DivID").value+"\" ";
                    values=values+"divclass=\""+$("Divclass").value+"\" ";
                    values=values+"ulid=\""+$("ulid").value+"\" ";
                    values=values+"ulclass=\""+$("ulclass").value+"\" ";
                    values=values+"liid=\""+$("liid").value+"\" ";
                    values=values+"liclass=\""+$("liclass").value+"\" ";         

                //日期格式
                values=values+"dateformat=\""+$("txtDateFormat").value+"\" "
                
                
                //调用文章的条数
                //values=values+"newscount=\""+$("txtArticleCount").value+"\" ";
                
                //文章属性
//                var   objs=document.getElementsByName("article")
//                for(i=0;i<objs.length;i++)
//                {
//                   if(objs[i].checked==true)
//                    {                    
//                        values=values+"article=\""+objs[i].value+"\" ";
//                        values=values+"marpace=\""+$("txtPace").value+"\" ";
//                        values=values+"mardirection=\""+$("selDirection").value+"\" ";
//                    }
//               } 
               
               //日期范围
               values=values+"daterange\""+$("txtDateRange").value+"\" ";
               

                
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
            }
            dialogArguments.setx(values);
            window.close();
        }
        
        function GetFirstColumn(chId)
        {
            System_Label_LabelSetParameter.GetFirstColumnList(chId,Callback)
        }
        
        function Callback(result)
        {
            $('lbColumn').options.length=0;
           var count = result.value.Rows.length;
           for(var i=0;i<count;i++)
           {
                var text = result.value.Rows[i]["ColName"];
                var val = result.value.Rows[i]["ColId"];
                $('lbColumn').options.add(new Option(text,val));
           }
        }

		//设置样式的内容
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

		function Init()
		{
			window.dialogWidth="700";
			window.dialogHeight="800";
		}
		function myfun()
		{
			lyTest.style.display="";
			lyTest.style.width="600";
			lyTest.style.height="350";
			lyTest.style.backgroundColor="#FFF";
			lyTest.style.marginLeft=50;
			lyTest.style.marginTop=82;
			lyTest.style.border="solid 2px #CCC";
			//alert();
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
    </script>

</head>
<body style="margin: 0px;" onload="LabelIsType()">
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
                <tr>
                    <td class="bqleft">
                        <strong>标签所属类别：</strong></td>
                        
                    <td class="bqright">
                      <select id="selOfType" onchange="LabelIsType()">
                            <option value="optEmpty">普通文章列表</option>
                            <option value="optColumn">循环频道栏目</option>
                            <option value="optNews">终极文章列表</option>
                            <option value="optSubNews">子类文章列表</option>
                        </select>  <span class="STYLE2">创建类别</span> <!--<span id="isChkChannel">所属频道:<input id="chkChannel" type="checkbox" onclick="trChShow()" /></span>-->
                    </td>
                </tr>
<!--				<tr id="trCh" style="display:none;">
					<td class="bqleft">所属频道：</td>
					<td class="bqright">
						<asp:DropDownList ID="ddlChannelSite" runat="server">
						</asp:DropDownList>
					</td>	
				</tr>
-->
                <tr id="row1">
                    <td class="bqleft" width="40">
                        <strong>所属频道：</strong></td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlParent" runat="server" onchange="ListData(this.options[this.selectedIndex].value);showhidenCol()">
                        </asp:DropDownList>
						<span id="showhidencol" style="display:none">
                        栏目:<asp:DropDownList ID="ddlChild" runat="server" onchange="shwhidtop()">
                        </asp:DropDownList> 
                        <span id="columnTop">Top：<input id="txtcolumntop" type="text" size="2" /></span>
                        <input type="checkbox" id="chkIncludeSub" /> 包含子栏目 <span class="STYLE2">不勾选则只调用选中的文章</span>
						</span>
                    </td>
                </tr>

				<!--子类文章列表-->
                <tr id="Tr1" style="display:none;">
                    <td class="bqleft" width="40">
                        <strong>所属频道：</strong></td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlParent1" runat="server" onchange="ListData2(this.options[this.selectedIndex].value);showhidenCol()">
                        </asp:DropDownList>
                        栏目:<asp:DropDownList ID="ddlChild1" runat="server" onchange="shwhidtop()">
                        </asp:DropDownList> 
                        <span id="Span2">Top：<input type="text" id="txtcolumntop1" size="2" /></span>
                        <input type="checkbox" id="chkIncludeSub1" /> 包含子栏目 <span class="STYLE2">不勾选则只调用选中的文章</span>
                    </td>
                </tr>

                <tr id="changeChinel" style="display: none;">
                    <td class="bqleft">
                        <strong>请选择频道：</strong></td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlChinel" runat="server"  onchange="showColumn();GetFirstColumn(this.value)">
                        </asp:DropDownList>
                        <span id="spTop">Top：<input id="txtTop" type="text" size="5" value="0" /></span><input type="checkbox" id="chkChIncludeSub"> 包含子栏目 <span class="STYLE2">不勾选则只调用选中的文章</span>
                    </td>
                </tr>
                <tr id="changeColumn" style="display: none;">
                    <td class="bqleft">
                        <strong id="STRONG1">请选择具体的栏目：</strong></td>
                    <td class="bqright">
                   
                        <asp:ListBox ID="lbColumn" runat="server" Width="200" Height="150" SelectionMode="Multiple">
                        </asp:ListBox>
                    
                    </td>
                </tr> 
                <tr style="display: none;" id="trShowColumns">
                    <td class="bqleft">
                        <strong>栏目显示的列数：</strong></td>
                    <td class="bqright">
                        <select id="selColumn">

                            <script language="javascript" type="text/javascript">
                            for(i=1;i<=8;i++)
                            {
                                document.write("<option value="+i+">"+i+"</option>")
                            }
                            </script>

                        </select>
                        &nbsp;
                    </td>
                </tr>
                <tr style="display: none;" id="trPage">
                    <td class="bqleft">
                        <strong>是否使用分页：</strong></td>
                    <td class="bqright">
                        <input id="chkIsPage" type="checkbox" checked />
                        分页样式
                        <input id="txtPageStyle" size="12" type="text" />
                        <input id="btnSetStyle" class="btn" type="button" value="设置" onclick="WinOpenDialog('SetPage.aspx',250,245)" />
                        每页数量
                        <input id="txtPageSize" type="text" size="5" value="10" />
                        分页CSS
                        <input id="txtPageCss" size="8" type="text" />
                    </td>
                </tr>
				<tr id="strNewsColumn">
					<td class="bqleft">文章列表列数：</td>
					<td class="bqright">
						<select id="selNewsColumn">
							<script language="javascript" type="text/javascript">
								for(i=1;i<=5;i++)
								{		
									document.write("<option value="+i+">"+i+"</option>");
								}
								</script>
						</select>	
					</td>
				</tr>
                <tr id="columnstyle" style="display:none">
                    <td class="bqleft">引用栏目样式</td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlColumnStyle" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        <strong>引用样式：</strong></td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlStyle" runat="server" onchange="CustomStyle();">
                        </asp:DropDownList>
                        <span class="STYLE2">引用样式格式</span>
                    </td>
                </tr>

                <tr>
                    <td class="bqleft">
                        <strong>显示样式：</strong></td>
                    <td class="bqright">
                        <select id="selShowStyle" onchange="ControlStyle()">
                            <option value="out_table" selected="selected">普通表格式</option>
                            <option value="out_div">DIV+CSS式</option>
                        </select>
                    </td>
                </tr>
                <tr style="display: none;" id="trStyle1">
                    <td class="bqleft" rowspan="2">
                        <strong>DIV控制：</strong></td>
                    <td class="bqright">
                        &lt;div id=&quot;<input name="DivID" type="text" id="DivID" size="2" title="前台生成DIV调用的ID号，请在CSS中预先定义。不能为空">
                        &quot; class=&quot;
                        <input name="Divclass" type="text" id="Divclass" size="2" title="前台生成DIV调用的Class名称，请在CSS中预先定义。可以为空!!">
                        &quot;&gt; &lt;ul id=&quot;
                        <input name="ulid" type="text" id="ulid" size="2" title="前台生成ul调用的ID，请在CSS中预先定义。可以为空!!">
                        &quot; class=&quot;
                        <input name="ulclass" type="text" id="ulclass" size="2" title="前台生成ul调用的class名称，请在CSS中预先定义。可以为空!!">&quot;&gt;
                    </td>
                </tr>
                <tr style="display: none;" id="trStyle2">
                    <td class="bqright">
                        &lt;li id=&quot;
                        <input name="liid" type="text" id="liid" size="2" title="前台生成li调用的ID，请在CSS中预先定义。可以为空!!">
                        &quot; class=&quot;
                        <input name="liclass" type="text" id="liclass" size="2" title="前台生成li调用的class名称，请在CSS中预先定义。可以为空!!">&quot;&gt;
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        日期样式：</td>
                    <td class="bqright">
                        <input id="txtDateFormat" type="text" value="YY年MM月DD日" />格式:YY代表2位的年份(如06表示2006年),YYYY表示4位数的年份(2006)，MM代表月，DD代表日，HH代表小时，MI代表分，SS代表秒</td>
                </tr>
                <tr id="ultimateList">
                    <td class="bqleft">
                        <strong>文章数目：</strong></td>
                    <td class="bqright">
                        <input name="txtArticleCount" id="txtArticleCount" type="text" value="10" size="6"
                            maxlength="200">
                        <span class="STYLE1"><span class="STYLE2">如果为0则显示所有文章</span></span></td>
                </tr>
                <tr id="trArticleProperty">
                    <td class="bqleft">
                        <strong>文章属性：</strong></td>
                    <td class="bqright">
                        <input id="Radio8" name="article" type="radio" value="ordinarily" onclick="radioMar()"
                            checked />
                        普通
                        <input id="Radio1" name="article" type="radio" value="FocusNews" onclick="radioMar()" />
                        焦点
                        <input id="Radio2" name="article" type="radio" value="RecNews" onclick="radioMar()" />
                        推荐
                        <input id="Radio3" name="article" type="radio" value="TopNews" onclick="radioMar()" />
                        置顶
                        <input id="Radio4" name="article" type="radio" value="HotNews" onclick="radioMar()" />
                        热点
                        <input id="Radio5" name="article" type="radio" value="MarNews" onclick="radioMar()" />
                        滚动
                        <input id="Radio6" name="article" type="radio" value="HeadNews" onclick="radioMar()" />
                        头条
                        <input id="Radio7" name="article" type="radio" value="BriNews" onclick="radioMar()" />
                        精彩
                        <input id="Radio9" name="article" type="radio" value="imagenews" onclick="radioMar()" />
                        图片
                    </td>
                </tr>
                <tr id="trMarquee" style="display: none;">
                    <td class="bqleft">
                        滚动的速度：</td>
                    <td class="bqright">
                        <input id="txtPace" type="text" value="8" size="10" />
                        滚动方向
                        <select id="selDirection">
                            <option value="up">向上</option>
                            <option value="down">向下</option>
                            <option value="left">向左</option>
                            <option value="right">向右</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        <strong>日期范围：</strong></td>
                    <td class="bqright">
                        默认最近显示
                        <input type="text" value="10" size="4" maxlength="200" id="txtDateRange">
                        天的文章 <span class="STYLE1"><span class="STYLE2">如果为0则显示所有文章</span></span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        <strong>排序方式：</strong></td>
                    <td class="bqright">
                        <select name="selectOrder" id="selectOrder">
                            <option value="dateasc">添加日期升序</option>
                            <option value="datedesc">添加日期降序</option>
                            <option value="hitasc">文章点击升序</option>
                            <option value="hitdesc">文章点击降序</option>
                        </select>
                        如果是最新文章，请选择'<b>添加日期</b>'和'<b>降序</b>'排列如果是热点文章，则系统默认以点击数降序排列</td>
                </tr>
                <!--<tr>
                    <td class="bqleft">
                        <strong>文章列数：</strong></td>
                    <td class="bqright">
                        <input type="text" value="1" size="4" maxlength="200" id="txtNewsColumns">
                        <span class="STYLE2">超过此列数就换行，子类文章每行只显示一条文章。</span></td>
                </tr>-->
                <tr>
                    <td class="bqleft">
                        <strong>标题字数： </strong>
                    </td>
                    <td align="left" class="bqright">
                        <input name="txtTitleCount" type="text" value="30" size="10" maxlength="200">
                        <span class="STYLE2">如果为0则显示完整标题，一个汉字为2个字节，输入10则显示5个汉字或者10个字母</span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        <strong>导读字数：</strong></td>
                    <td class="bqright">
                        <input type="text" value="200" size="10" maxlength="200" id="txtNewstd">
                        <span class="STYLE2">如果为0则不显示导读信息，一个汉字为2个字节，输入10则显示5个汉字或者10个字母</span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        <strong>文章循环行样式：</strong></td>
                    <td class="bqright">
                        每显示<input type="text" value="0" size="4" maxlength="200" id="txtNewsRows">
                        行后，向循环列表中插入
                        <input type="text" value="&lt;hr&gt;" size="20" maxlength="200" id="txtCompart">
                        <span class="STYLE2">支持html代码</span></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <input id="btnSubmit" class="btn" type="button" value="确定创建此标签" onclick="CreateColumnList()" />
                        <input class="btn" type="button" value="取消" onclick="javascript:window.close();" /></td>
                </tr>
            </table>
            <!--endbody-->
        </div>

		<div id="lyTest" style="display:none;position:absolute;top:0px;">
			<div style="width:100%; height:25px; background-color:#4775B1; padding:3px;">
				<div style="color:#FFFFFF; text-align:left; float:left; font-size:12px; margin-top:5px;"><b>创建样式</b></div>
				<div style="float:right; margin-top:5px; margin-right:3px;">
						<a href="#" onclick="javascript:lyTest.style.display='none'; hidenSelect()"><img src="../images/skin/default/tab-close-on.gif" border="0" /></a>
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
							<td align="right" class="bqleft" style="height: 25px; width:100px;">
								选择字段：
							</td>
							<td class="bqright" valign="middle" style="height: 25px">
								<!--<asp:DropDownList id="ddlSelectField" runat="server">
									<asp:ListItem Value="0">列表页常用字段</asp:ListItem>
									<asp:ListItem Value="{KY_N_ID}">文章ID</asp:ListItem>
								</asp:DropDownList>
								-->
								<select id="selectcolumn" onchange="setx(this)" runat="server">
									<option value="" selected>列表页常用字段</option>
									<option value="{KY_N_ColName}">栏目名</option>
									<option value="{KY_N_ColumnUrl}">栏目访问路径</option>
									<option value="{KY_N_commentlink}">评论链接</option>
									<option value="{KY_N_NewsId}">文章编号</option>
									<option value="{KY_N_RowIndex}">索引行号</option>
									<option value="{KY_N_Title}">文章标题</option>
									<option value="{KY_N_Prefix}">文章前缀</option>
									<option value="{KY_N_Source}">文章来源</option>
									<option value="{KY_N_LongTitle}">文章副标题</option>
									<option value="{KY_N_NewsUrl}">文章访问路径</option>
									<option value="{KY_N_ImgPath}">图片地址(小图)</option>
									<option value="{KY_N_ShortContent}">文章导读</option>
									<option value="{KY_N_AddTime}">文章添加日期</option>
									<option value="{KY_N_Author}">文章作者</option>
									<option value="{KY_N_AdminUName}">文章责任编辑</option>
								</select>
								<select name="selectChangYou" onchange="setx(this)">
									<option value="" selected>内容页常用字段</option>
									<option value="{KY_N_Title}">文章标题</option>
									<option value="{KY_N_LongTitle}">文章副标题</option>
									<option value="{KY_N_Author}">文章作者</option>
									<option value="{KY_N_Content}">文章内容</option>
									<option value="{KY_N_HitsCount}">点击数</option>
									<option value="{KY_N_Source}">文章来源</option>
									<option value="{KY_N_TagNameStr}">TAG关键字</option>
									<option value="{KY_N_AdminUName}">文章责任编辑</option>
									<option value="{KY_N_StarLevel}">评分等级</option>
									<option value="{KY_N_Pre}">上一篇文章</option>
									<option value="{KY_N_Next}">下一篇文章</option>
		
								</select>
								<!--<select name="select9">
								  <option>自定义字段</option>
								  <option>字段一</option>
								  <option>字段二</option>
								</select>-->
							</td>
						</tr>
						<tr>
							<td align="right" class="bqleft" style="width:100px;">
								样式内容：</td>
							<td class="bqright">
								<!--<asp:TextBox ID="txtContent" TextMode="multiLine" Rows="6" Columns="50" runat="server"></asp:TextBox>-->
								<textarea id="test" rows="10" cols="50" runat="server"></textarea>
							</td>
						</tr>
						<tr>
							<td colspan="2" align="center" style="height: 29px">
								<asp:Button ID="btnSave" CssClass="btn" runat="server" Text="添加样式" OnClick="btnSave_Click"  OnClientClick="return CheckValidate()"  />
						</tr>
					</tbody>
				</table>			
			</div>
		</div>
    </form>
</body>
</html>

