<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetObject.aspx.cs" Inherits="system_collection_SetObject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加新项目</title>
	<link rel="stylesheet" href="../css/default.css" type="text/css" />
	<script language="javascript" type="text/javascript" src="../../js/Common.js"></script>
	<script language="javascript" type="text/javascript" src="../../js/XmlHttp.js"></script>
	<script language="JavaScript" type="text/javascript">
	 var tID=0;
	 function ShowTabs(ID){
	  if(ID!=tID)
	  {
		if(ID==2)
		{
			flag=ValidateListCode();
			if(flag)
			{
				TabTitle[tID].className='title5';
				TabTitle[ID].className='title6';
				Tabs[tID].style.display='none';
				Tabs[ID].style.display='';
				tID=ID;



				var listAddress=$("txtListUrl").value;
				var listStatCode=$("txtListStart").value;
				var listEndCode=$("txtListEnd").value;
				var linkStartCode=$("txtLinkStart").value;
				var linkEndCode=$("txtLinkEnd").value;
				var charSet="";
				var   objs=document.getElementsByName("rdoCharSet")
				for(i=0;i<objs.length;i++)
				{
				   if(objs[i].checked==true)
					{                    
						charSet=objs[i].value;
					}
			   }

				var postStr="";
				postStr=listAddress+"|"+listStatCode+"|"+listEndCode+"|"+linkStartCode+"|"+linkEndCode+"|"+charSet;
				CodePre(postStr);	
			}	
		}
		else if(ID==1)
		{
			flag=ValidateListCode();
			if(flag)
			{
				TabTitle[tID].className='title5';
				TabTitle[ID].className='title6';
				Tabs[tID].style.display='none';
				Tabs[ID].style.display='';
				tID=ID;
			}			
		}
		else if(ID==0)
		{
			flag=true;
			if($("rdoPage0").checked!=true)
			{
				flag=ValidatePageCode();				
			}			
			if(flag)
			{
				TabTitle[tID].className='title5';
				TabTitle[ID].className='title6';
				Tabs[tID].style.display='none';
				Tabs[ID].style.display='';
				tID=ID;
			}
		}
		else
		{
			TabTitle[tID].className='title5';
			TabTitle[ID].className='title6';
			Tabs[tID].style.display='none';
			Tabs[ID].style.display='';
			tID=ID;
		}
	  }
	 }

	//代码预览
    function CodePre(val)
    {
		$("txtPreview").value="正在加载数据. . .";
        system_collection_SetObject.CodePre(val,CodePre_CallBack);
    }
    
    function CodePre_CallBack(res)
    {
		if(res.value!="")
			$("txtPreview").value=res.value;
		else
			$("txtPreview").value="请检查参数据设置";
			
    }



	var tID1=3;
	function ShowTabs1(ID){
	  if(ID!=tID1){
		if(ID==6)
		{
			flag=true;
			if($("rdoConPage1").checked!=true)
			{
				flag=ValidateConPage();	
			}	
			if(flag)
			{
				TabTitle[tID1].className='title5';
				TabTitle[ID].className='title6';
				Tabs[tID1].style.display='none';
				Tabs[ID].style.display='';
				tID1=ID;

				//列表
				var listAddress=$("txtListUrl").value;
				var listStatCode=$("txtListStart").value;
				var listEndCode=$("txtListEnd").value;
				var linkStartCode=$("txtLinkStart").value;
				var linkEndCode=$("txtLinkEnd").value;
				var doMain=$("txtWebSite").value
				var charSet="";
				var   objs=document.getElementsByName("rdoCharSet")
				for(i=0;i<objs.length;i++)
				{
				   if(objs[i].checked==true)
					{                    
						charSet=objs[i].value;
					}
			   }

				var postStr="";
				postStr=listAddress+"|"+listStatCode+"|"+listEndCode+"|"+linkStartCode+"|"+linkEndCode+"|"+charSet+"|"+doMain;

				//字段
				var   objs=document.getElementById("lbFildList");
				var htmlStr="";
			   var fieldValue="";
			
				for(i=0;i<objs.length;i++)
				{
				   if(objs[i].selected==true)
					{                    
						htmlStr=htmlStr+objs[i].text+"|";
						fieldValue=fieldValue+objs[i].value+","+$(objs[i].value+"Start").value+","+$(objs[i].value+"End").value+","+$(objs[i].value+"Default").value+"|";
					}
			   }			
				
				//栏目Id
				var colId=$("hidColumnId").value;			
				
				//内容分页设置
				var conPageObj=document.getElementsByName("ConPaingType");
				var pageSet=""; 
				for(i=0;i<conPageObj.length;i++)
				{
					if(conPageObj[i].checked==true)
					{
						switch(conPageObj[i].value)
						{
							case "0":
								pageSet = pageSet + "pageSet┃0";
								break;
							case "1":
								pageSet = pageSet + "pageSet┃1|PageStartCode┃" + $("txtConPageStart").value + "|";
								pageSet = pageSet + "PageEndCode┃" + $("txtConPageEnd").value;
								break;
							case "2":
								pageSet = pageSet + "pageSet┃2|ListPageAddress┃" + $("txtConAddress").value + "|";
								pageSet = pageSet + "StartPageId┃" + $("txtConStartId").value + "|";
								pageSet = pageSet + "EndPageId┃" + $("txtConEndId").value;
								break;
							case "3":
								pageSet = pageSet + "pageSet┃3|PageListUrl┃" + $("txtConPageAddress").value;
								break;
						}
					}
				}

				//简单过滤规则
				var simleStr="";
				for(i=0;i<10;i++)
				{
					if($("chkSimpleFilter_"+i).checked==true)
					{
						simleStr=simleStr+i+",";
					}
				}

				//复杂过滤规则
				var superior="";
				var   superiorObj=document.getElementById("lbFilterRule");
				var superiorResult="";
				for(i=0;i<superiorObj.length;i++)
				{
				   if(superiorObj[i].selected==true)
					{                    
						superior=superior+superiorObj[i].value+",";
					}
			   }
				
				var superiorArr=superior.split(',');
				for(i=0;i<superiorArr.length-1;i++)
				{
					if(superiorArr.length-2==i)
						superiorResult=superiorResult+superiorArr[i];
					else
						superiorResult=superiorResult+superiorArr[i]+",";
				}			
				CollectionTest(postStr+"$"+htmlStr+"$"+fieldValue+"$"+colId+"$"+pageSet+"$"+simleStr+"$"+superiorResult);
			}
		}
		else
		{
			flag=true;
			if(ID!=4)
			{
				if($("rdoConPage1").checked!=true)
				{
					flag=ValidateConPage();	
				}	
			}
			if(flag)
			{
				TabTitle[tID1].className='title5';
				TabTitle[ID].className='title6';
				Tabs[tID1].style.display='none';
				Tabs[ID].style.display='';
				tID1=ID;
		   }
		}
	  }
	}

	//采集测试
    function CollectionTest(val)
    {
		$("txtCollectionTest").value="正在加载数据. . .";
        system_collection_SetObject.CollectionTest(val,CollectionTest_CallBack);
    }
    
    function CollectionTest_CallBack(res)
    {
		if(res.value!="null")
			$("txtCollectionTest").value=res.value;
		else
			$("txtCollectionTest")="请检查参数据设置";
    }

	function SkipFun(result)
	{
		if(result.id=="btnSkip")
		{
			flag=ValidateBaseList();
			if(!flag)
				return;
			//检测内容分页代码
			if($("rdoConPage1").checked!=true)
			{
				flag=ValidateConPage();	
			}	

			if(flag)
			{
				//导航位置设置
				base.style.color="#000";			
				list.style.color="#F00";
				ContentSet.style.color="#000";

				//基本设置
				baseTable.style.display="none";			

				//列表设置
				listTable1.style.display="";
				listTable2.style.display="";

				//正文设置
				conTable1.style.display="none";
				conTable2.style.display="none";
			}
		}
		else if(result.id=="btnListSkip")
		{
			flag=true;
			//验证列表基本设置
			flag=ValidateBaseList();
			if(!flag)
				return;
			//检测列表代码
			flag=ValidateListCode();
			//检测分页代码
			if($("rdoPage0").checked!=true)
			{
				flag=ValidatePageCode();				
			}

			if(flag)
			{
				//导航位置设置
				list.style.color="#000";
				base.style.color="#000";			
				ContentSet.style.color="#F00";

				//基本设置
				baseTable.style.display="none";			

				//列表设置
				listTable1.style.display="none";
				listTable2.style.display="none";

				//正文设置
				conTable1.style.display="";
				conTable2.style.display="";
				LbFieldList($('hidColumnId').value);
			}
		}
		else
		{
			flag=ValidateListCode();
			//检测分页代码
			if($("rdoPage0").checked!=true)
			{
				flag=ValidatePageCode();
				if(!flag)
					return;				
			}

			//检测内容分页代码
			if($("rdoConPage1").checked!=true)
			{
				flag=ValidateConPage();	
			}	

			if(flag)
			{
				//导航位置设置
				base.style.color="#F00";			
				list.style.color="#000";
				ContentSet.style.color="#000";

				//基本设置
				baseTable.style.display="";			

				//列表设置
				listTable1.style.display="none";
				listTable2.style.display="none";

				//正文设置
				conTable1.style.display="none";
				conTable2.style.display="none";	
			}
		}
	}

	function PreFun(result)
	{
		if(result.id=="btnListPre")
		{
			//导航位置设置
			base.style.color="#F00";			
			list.style.color="#000";
			ContentSet.style.color="#000";

			//基本设置
			baseTable.style.display="";			

			//列表设置
			listTable1.style.display="none";
			listTable2.style.display="none";

			//正文设置
			conTable1.style.display="none";
			conTable2.style.display="none";	
		}
		else if(result.id=="btnPreCon")
		{
			//导航位置设置
			base.style.color="#000";			
			list.style.color="#F00";
			ContentSet.style.color="#000";

			//基本设置
			baseTable.style.display="none";			

			//列表设置
			listTable1.style.display="";
			listTable2.style.display="";

			//正文设置
			conTable1.style.display="none";
			conTable2.style.display="none";	
		}
	}

	function HidPage()
	{
		for(i=1;i<=3;i++)
		{
			eval("ListPaing"+i).style.display="none";
		}
	}

	function HidConPage()
	{
		for(i=1;i<=3;i++)
		{
			eval("ConPaing"+i).style.display="none";
		}		
	}

	function ShowPageFun(result)
	{
	    var id=result.id.substring(0,4);
		if(id=="List")
			HidPage();
		else
			HidConPage();
		result.style.display="";
	}	


    function LbFieldList(val)
    {
        system_collection_SetObject.GetOption(val,Serverfull_CallBack);
    }
    
    function Serverfull_CallBack(res)
    {
        document.form1.lbFildList.length=0;
        
        for(var i=0;i<=res.value.Rows.length-1;i++)
        {
            document.form1.lbFildList.length++;

				document.form1.lbFildList.options[i].value = res.value.Rows[i]["Name"];
				document.form1.lbFildList.options[i].text = res.value.Rows[i]["Alias"];

        }
    }
   
   function CreateHtml()
   {
        var   objs=document.getElementById("lbFildList");
        var htmlStr="";
		var nameStr="";
        for(i=0;i<objs.length;i++)
        {
           if(objs[i].selected==true)
            {                    
                htmlStr=htmlStr+objs[i].text+",";
				nameStr=nameStr+objs[i].value+",";
            }
       }
      var tableStr="<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\">";
      var tableBody="";
      var Arr=htmlStr.split(',');
	  var NameArr=nameStr.split(',');
      for(i=0;i<Arr.length-1;i++)
      {
        tableBody=tableBody+"<tr><td class=\"bqleft\">"+Arr[i]+"：</td><td class=\"bqright\">开始代码：</td><td class=\"bqright\"><textarea name=\""+NameArr[i]+"Start\" ></textarea></td><td class=\"bqright\">结束代码：</td><td class=\"bqright\"><textarea name=\""+NameArr[i]+"End\" ></textarea></td><td class=\"bqright\">&nbsp;<input type=\"button\" value=\"测试\" class=\"btn\" name=\""+NameArr[i]+"\" id=\""+NameArr[i]+"\" title=\""+Arr[i]+"\" onclick=\"TestContent(this)\" /></td><td class=\"bqright\">默认值：</td><td class=\"bqright\"><input type=\"text\" name=\""+NameArr[i]+"Default\" value=\"\"  style=\"width:85px;\" /></td></tr>\r\n"
      }
      tableCreate.innerHTML=tableStr+tableBody+"</table>";
   } 

	function setChecked()
	{
		if($("rdoPage0").checked==true)
		{
			HidPage();
		}
		if($("rdoPage1").checked==true)
		{
			ShowPageFun(ListPaing1);
		}
		if($("rdoPage2").checked==true)
		{
			ShowPageFun(ListPaing2);
		}
		if($("rdoPage3").checked==true)
		{
			ShowPageFun(ListPaing3);
		}
		
		$('rdoConPage1').checked=true;
		$("rdoPage0").checked=true;
	}

	
	//检测列表
	function CheckCodeFun(obj)
	{
		var charSet="";
        var   objs=document.getElementsByName("rdoCharSet")
        for(i=0;i<objs.length;i++)
        {
           if(objs[i].checked==true)
            {                    
                charSet=objs[i].value;
            }
       }

		//编码方式
		charSetStr="gb2312";
		if(charSet!="0")
			charSetStr="UTF-8";
		
		checkCodeStr=obj.value;
		listAddress=$("txtListUrl").value;
		
		if(checkCodeStr!="")
			CheckCodeAjax(charSetStr+"|"+checkCodeStr+"|"+listAddress);
		else
		{
			alert("必须填写检测内容");
			obj.focus();
		}
	}

	//采集测试
    function CheckCodeAjax(val)
    {
        system_collection_SetObject.CheckHtmlCode(val,CheckCode_CallBack);
    }
    
    function CheckCode_CallBack(res)
    {
		if(res.value!=null)
			alert(res.value);
		else
			alert("你的参数据设置有误");
    }

	//检测内容
	function CheckContentFun(obj)
	{
		var listAddress=$("txtListUrl").value;
		var listStatCode=$("txtListStart").value;
		var listEndCode=$("txtListEnd").value;
		var linkStartCode=$("txtLinkStart").value;
		var linkEndCode=$("txtLinkEnd").value;
		var doMain=$("txtWebSite").value
		var charSet="";
		var   objs=document.getElementsByName("rdoCharSet")
		for(i=0;i<objs.length;i++)
		{
		   if(objs[i].checked==true)
			{                    
				charSet=objs[i].value;
			}
	   }
		//编码方式
		charSetStr="gb2312";
		if(charSet!="0")
			charSetStr="UTF-8";
		//检测代码
		checkCodeStr=obj.value;
		if(checkCodeStr!="")
			CheckContentCodeAjax(listAddress+"|"+listStatCode+"|"+listEndCode+"|"+linkStartCode+"|"+linkEndCode+"|"+charSetStr+"|"+doMain+"|"+checkCodeStr);
		else
		{
			alert("必须填写检测内容");
			obj.focus();
		}
	}

    function CheckContentCodeAjax(val)
    {
        system_collection_SetObject.CheckContentCode(val,CheckContentCode_CallBack);
    }
    
    function CheckContentCode_CallBack(res)
    {
		if(res.value!=null)
			alert(res.value);
		else
			alert("你的参数据设置有误");
    }


	//验证列表页用户是否输入
	function ValidateListCode()
	{
			flag=true;
			var obj=document.getElementById("btnSkip");
			if($("txtListStart").value=="")
			{
				SkipFun(obj);
				alert("列表页开始代码必须填写");
				$("txtListStart").focus();
				flag=false;
				return flag;
			}

			if($("txtListEnd").value=="")
			{
				SkipFun(obj);
				alert("列表页结束代码必须填写");
				$("txtListEnd").focus();
				flag=false;
				return flag;
			}

			if($("txtLinkStart").value=="")
			{
				SkipFun(obj);
				alert("链接开始代码必须填写");
				$("txtLinkStart").focus();
				flag=false;
				return flag;
			}	

			if($("txtLinkEnd").value=="")
			{
				SkipFun(obj);
				alert("链接结束代码必须填写");
				$("txtLinkEnd").focus();
				flag=false;
				return flag;
			}
			return flag;
	}

	//列表分页设置是否输入
	function ValidatePageCode()
	{
			flag=true;		
			if($("rdoPage1").checked==true)
			{
				ShowPageFun(ListPaing1);
				if($("txtNextPageStart").value=="")
				{
					alert("分页开始代码必须填写");
					$("txtNextPageStart").focus();
					flag=false;
					return flag;
				}
				if($("txtNextPageEnd").value=="")
				{
					alert("分页开始代码必须填写");
					$("txtNextPageEnd").focus();
					flag=false;
					return flag;
				}
			}

			if($("rdoPage2").checked==true)
			{
				ShowPageFun(ListPaing2);
				if($("txtUrlStr").value=="")
				{
					alert("分页地址必须填写");
					$("txtUrlStr").focus();
					flag=false;
					return flag;
				}
				else
				{
					if(!(isurl($("txtUrlStr").value)))
					{
						alert("填写的分页地址格式不对");
						$("txtUrlStr").value="";
						$("txtUrlStr").focus();
						flag=false;
						return flag;				
					}
				}

				if($("txtStartId").value=="")
				{
					alert("分页Id必须填写");
					$("txtStartId")="";
					$("txtStartId").focus();
					flag=false;
					return flag;
				}
				else
				{
					if(!CheckNumber($("txtStartId").value))
					{
						alert("必须输入数字");
						$("txtStartId").value="";
						$("txtStartId").focus();
						flag=false;
						return flag;				
					}
				}

				if($("txtEndId").value=="")
				{
					alert("分页Id必须填写");
					$("txtEndId").focus();
					flag=false;
					return flag;
				}
				else
				{
					if(!CheckNumber($("txtEndId").value))
					{
						alert("必须输入数字");
						$("txtEndId").value="";
						$("txtEndId").focus();
						flag=false;
						return flag;				
					}
				}
			}

			if($("rdoPage3").checked==true)
			{
				ShowPageFun(ListPaing3);
				if($("txtUrlList").value=="")
				{
					alert("列表地址必须填写");
					$("txtUrlList").focus();
					flag=false;
					return flag;
				}
				else
				{
					var addressArr=$("txtUrlList").value.split('\r\n').join('|').split('|');
					//var patt = /\n/g
					//var addressArr = $("txtUrlList").value.replace(patt,"|");
					var addressStr="";
					var newArr=null;
					var addressflag=true;
					for(i=0;i<addressArr.length;i++)
					{
						if(addressArr[i]!="")
						{
							addressStr=addressStr+addressArr[i]+"|";
						}
					}
					
					if(addressArr.length>0)
					{
						newArr=addressStr.split('|');
						for(i=0;i<newArr.length-1;i++)
						{
							if(!isurl(newArr[i]))
							{
								addressflag=false;
							}
						}
					}
					else
					{
						if(!isurl($("txtUrlList").value))
						{
							addressflag=false;
						}
					}
					
					if(!addressflag)
					{
						alert("必须输入正确的地址");
						$("txtUrlList").focus();
						flag=false;
						return flag;
					}
				}
			}
			return flag;	
	}

	//验证基本列表页用户的输入
	function ValidateBaseList()
	{
		flag=true;
		if($("txtObjectName").value=="")
		{
			alert("项目名称必须填写");
			$("txtObjectName").focus();
			flag=false;
			return flag;
		}

		if($("txtWebSite").value=="")
		{
			alert("目标站点地址必须填写");
			$("txtWebSite").focus();
			flag=false;
			return flag;
		}
		else
		{
			if(!(isurl($("txtWebSite").value)))
			{
				alert("目标站点地址格式不对");
				$("txtWebSite").value="";
				$("txtWebSite").focus();
				flag=false;
				return flag;				
			}
		}
		
		if($('hidColumnId').value=="")
		{
			alert("必须选择入库栏目");
			window.open('SetColumn.aspx','open','width=200,height=200,top=360,left=520,scrollbars');
			//SkipFun('baseTable');
			flag=false;
			return flag;
		}

		if($("txtListUrl").value=="")
		{
			alert("必须填写列表页地址");
			$("txtListUrl").focus();
			flag=false;
			return flag;
		}
		else
		{
			if(!(isurl($("txtListUrl").value)))
			{
				alert("填写的列表页地址格式不对");
				$("txtListUrl").value="";
				$("txtListUrl").focus();
				flag=false;
				return flag;				
			}
		}
		return flag;
	}

	//内容分页验证
	function ValidateConPage()
	{
		flag=true;
		if($("rdoConPage2").checked==true)
		{
			ShowPageFun(ConPaing1);
			if($("txtConPageStart").value=="")
			{
				alert("分页开始代码必须填写");
				$("txtConPageStart").focus();
				flag=false;
				return flag;
			}
			if($("txtConPageEnd").value=="")
			{
				alert("分页开始代码必须填写");
				$("txtConPageEnd").focus();
				flag=false;
				return flag;
			}
		}
		if($("rdoConPage3").checked==true)
		{
			ShowPageFun(ConPaing2);
			if($("txtConAddress").value=="")
			{
				alert("分页地址必须填写");
				$("txtConAddress").focus();
				flag=false;
				return flag;
			}
			else
			{
				if(!(isurl($("txtConAddress").value)))
				{
					alert("填写的分页地址格式不对");
					$("txtConAddress").value="";
					$("txtConAddress").focus();
					flag=false;
					return flag;				
				}
			}

			if($("txtConStartId").value=="")
			{
				alert("分页Id必须填写");
				$("txtConStartId").focus();
				flag=false;
				return flag;
			}
			else
			{
				if(!CheckNumber($("txtConStartId").value))
				{
					alert("必须输入数字");
					$("txtConStartId").value="";
					$("txtConStartId").focus();
					flag=false;
					return flag;				
				}
			}

			if($("txtConEndId").value=="")
			{
				alert("分页Id必须填写");
				$("txtConEndId").focus();
				flag=false;
				return flag;
			}
			else
			{
				if(!CheckNumber($("txtConEndId").value))
				{
					alert("必须输入数字");
					$("txtConEndId").value="";
					$("txtConEndId").focus();
					flag=false;
					return flag;				
				}
			}
		}
		if($("rdoConPage4").checked==true)
		{
			ShowPageFun(ConPaing3);
			ShowPageFun(ListPaing3);
			if($("txtConPageAddress").value=="")
			{
				alert("列表地址必须填写");
				$("txtConPageAddress").focus();
				flag=false;
				return flag;
			}
			else
			{
				var addressArr=$("txtConPageAddress").value.split('\r\n').join('|').split('|');
				//var patt = /\n/g
				//var addressArr = $("txtUrlList").value.replace(patt,"|");
				var addressStr="";
				var newArr=null;
				var addressflag=true;
				for(i=0;i<addressArr.length;i++)
				{
					if(addressArr[i]!="")
					{
						addressStr=addressStr+addressArr[i]+"|";
					}
				}
				
				if(addressArr.length>0)
				{
					newArr=addressStr.split('|');
					for(i=0;i<newArr.length-1;i++)
					{
						if(!isurl(newArr[i]))
						{
							addressflag=false;
						}
					}
				}
				else
				{
					if(!isurl($("txtConPageAddress").value))
					{
						addressflag=false;
					}
				}
				
				if(!addressflag)
				{ 
					alert("必须输入正确的地址");
					$("txtConPageAddress").focus();
					flag=false;
					return flag;
				}
			}
		}
		return flag;		
	}

	function isurl(str)
	{ 
		// "^[a-zA-z]+://(\\w+(-\\w+)*)(\\.(\\w+(-\\w+)*))*(\\?\\S*)?$"
		var reg = /^http:\/\/.{0,93}/; 
		return reg.test(str); 
	}
	function TestContent(obj)
	{
		var startcode=$(obj.id+"Start").value;
		var endcode=$(obj.id+"End").value;
		
		if(startcode=="")
		{
			alert("开始代码不能为空");
			$(obj.id+"Start").focus();
			return;
		}

		if(endcode=="")
		{
			alert("结束代码不能为空");
			$(obj.id+"End").focus();
			return;
		}
		
		//列表
		var listAddress=$("txtListUrl").value;
		var listStatCode=$("txtListStart").value;
		var listEndCode=$("txtListEnd").value;
		var linkStartCode=$("txtLinkStart").value;
		var linkEndCode=$("txtLinkEnd").value;
		var doMain=$("txtWebSite").value
		var charSet="";
		var   objs=document.getElementsByName("rdoCharSet")
		for(i=0;i<objs.length;i++)
		{
		   if(objs[i].checked==true)
			{                    
				charSet=objs[i].value;
			}
	   }

		var postStr="";
		postStr=listAddress+"|"+listStatCode+"|"+listEndCode+"|"+linkStartCode+"|"+linkEndCode+"|"+charSet+"|"+doMain;

		//字段
		var   objs=document.getElementById("lbFildList");
		var htmlStr="";
	   var fieldValue="";
	
                   
		htmlStr=obj.title+"|";
		fieldValue=obj.id+","+startcode+","+endcode+","+$(obj.id+"Default").value+"|";

		
		//栏目Id
		var colId=$("hidColumnId").value;			
		
		//内容分页设置
		var conPageObj=document.getElementsByName("ConPaingType");
		var pageSet=""; 
		for(i=0;i<conPageObj.length;i++)
		{
			if(conPageObj[i].checked==true)
			{
				switch(conPageObj[i].value)
				{
					case "0":
						pageSet = pageSet + "pageSet┃0";
						break;
					case "1":
						pageSet = pageSet + "pageSet┃1|PageStartCode┃" + $("txtConPageStart").value + "|";
						pageSet = pageSet + "PageEndCode┃" + $("txtConPageEnd").value;
						break;
					case "2":
						pageSet = pageSet + "pageSet┃2|ListPageAddress┃" + $("txtConAddress").value + "|";
						pageSet = pageSet + "StartPageId┃" + $("txtConStartId").value + "|";
						pageSet = pageSet + "EndPageId┃" + $("txtConEndId").value;
						break;
					case "3":
						pageSet = pageSet + "pageSet┃3|PageListUrl┃" + $("txtConPageAddress").value;
						break;
				}
			}
		}

		//简单过滤规则
		var simleStr="";
		for(i=0;i<10;i++)
		{
			if($("chkSimpleFilter_"+i).checked==true)
			{
				simleStr=simleStr+i+",";
			}
		}

		//复杂过滤规则
		var superior="";
		var   superiorObj=document.getElementById("lbFilterRule");
		var superiorResult="";
		for(i=0;i<superiorObj.length;i++)
		{
		   if(superiorObj[i].selected==true)
			{                    
				superior=superior+superiorObj[i].value+",";
			}
	   }
		
		var superiorArr=superior.split(',');
		for(i=0;i<superiorArr.length-1;i++)
		{
			if(superiorArr.length-2==i)
				superiorResult=superiorResult+superiorArr[i];
			else
				superiorResult=superiorResult+superiorArr[i]+",";
		}			
		FieldPre(postStr+"$"+htmlStr+"$"+fieldValue+"$"+colId+"$"+pageSet+"$"+simleStr+"$"+superiorResult);
	}

	//代码预览
    function FieldPre(val)
    {
		$("txtFieldPre").value="正在加载数据. . . ";
        system_collection_SetObject.FieldPre(val,FieldPre_CallBack);
		WindowOpen('PreCode.aspx','precode',500,460) 

    }
    
    function FieldPre_CallBack(res)
    {
		$("txtFieldPre").value=res.value;
		WindowOpen('PreCode.aspx','precode',500,460) 
    }
    function WindowOpen(url,n,w,h) 
    {
        var left = (screen.width-w)/2;
        var top = (screen.height-h)/2;
        var f = "width="+w+",height="+h+",top="+top+",left="+left+",scrollbars=yes";
        var c=window.open(url,n,f);
		c.focus();
    }	
	</script>

</head>
<body onload="setChecked()">
    <form id="form1" runat="server">
    <div>

		<table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
				<tr>
					<td width="20" height="24">
						<img src="../images/skin/default/you.gif" width="17" height="16" /></td>
					<td align="left" style="padding-top: 3px;">
						您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href="../user/LogList.aspx">扩展功能</a> &gt;&gt; 采集管理</td>
					<td width="50" align="right">
						<img src="../images/skin/default/help.gif" align="absmiddle" /></td>
				</tr>
		</table>

        <table border="0" cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
            <tr class="wzlist">
                <td>
                    <a id="hyperInfo" href="SetObject.aspx">添加采集<img src="../images/comment_add.gif" border="0" /></a> |
                    <a href="CollectionManager.aspx">管理采集</a> |
					<a id="A1" href="SetSuperior.aspx">添加过滤<img src="../images/comment_add.gif" border="0" /></a> |
					<a href="SuperiorManger.aspx">过滤管理</a> |
					<a href="CollectionAddressManager.aspx">采集历史管理<img src="../images/comment_add.gif" border="0" /></a> 
                </td>
            </tr>
        </table>

		<table width="99%" cellpadding="0" cellspacing="0" border="0" align="center">
			<tr>
				<td>采集项目设置步骤：
						<span  id="base" class="mouseStyle" style="color:Red;" onclick="SkipFun('baseTable')">基本设置</span> >> 
						<span  id="list" class="mouseStyle" onclick="SkipFun(btnSkip)">列表设置</span>  >> 
						<span id="ContentSet" class="mouseStyle" onclick="SkipFun(btnListSkip)">正文设置</span> >>  完成设置
				</td>
			</tr>
		</table>

<!--基本设置-->
		<table id="baseTable" width="99%" align="center" class="border" cellspacing="1" cellpadding="0">
		   <tbody>
				<tr>
				  <td class="bqleft"> 项目名称：&nbsp;</td>
				  <td class="bqright">
					  <asp:TextBox ID="txtObjectName" runat="server"></asp:TextBox>&nbsp;<span style="color:Red">*</span></td>
				</tr>

				 <tr> 
				  <td class="bqleft" style="height: 28px"> 目标站点域名：&nbsp;</td>
				  <td class="bqright" style="height: 28px"><asp:TextBox ID="txtWebSite" runat="server" Width="350px"></asp:TextBox>&nbsp;<span style="color:Red">*</span><span style="color:#0099FF">例如：http://news.qq.com/</span></td>
				</tr>

				 <tr>
				  <td class="bqleft"> 入库栏目：&nbsp;</td>
				  <td class="bqright">
					  <asp:HiddenField ID="hidColumnId" runat="server" />
					  <asp:TextBox ID="txtColumnId" runat="server" Width="80" Enabled="false"></asp:TextBox>
					  <input id="Button1" type="button" class="btn" value="点击选择" onclick="javascript:window.open('SetColumn.aspx','open','width=200,height=200,top=360,left=520,scrollbars')" />
				  </td>
				</tr> 

				 <tr>
				  <td class="bqleft"> 入库专题：&nbsp;</td>
				  <td class="bqright">
				      <asp:HiddenField ID="hidSpecialId" runat="server" />
					  <asp:TextBox ID="txtSpecialId" runat="server" Width="80" Enabled="false"></asp:TextBox>
					  <input id="Button2" class="btn" type="button" value="点击选择"  onclick="javascript:if($('txtColumnId').value==''){alert('必须填选择栏目');window.open('SetColumn.aspx','open','width=200,height=200,top=360,left=520,scrollbars');return false;}javascript:window.open('SetSpecial.aspx?colid='+$('hidColumnId').value,'open','width=175,height=220,top=360,left=520,scrollbars')" />
				  </td>
				</tr>

				<tr>
				  <td class="bqleft"> 网页编码：&nbsp;</td>
				  <td class="bqright">
					  <asp:RadioButtonList ID="rdoCharSet" runat="server" RepeatDirection="Horizontal" name="rdoCharSet">
						  <asp:ListItem Selected="True" Value="0">GB2312</asp:ListItem>
						  <asp:ListItem Value="1">UTF-8</asp:ListItem>
					  </asp:RadioButtonList>
				  </td>
              </tr>

			  <tr>
				  <td class="bqleft"> 列表页URL：&nbsp;</td>
				  <td class="bqright">
					<asp:TextBox ID="txtListUrl" runat="server" TextMode="MultiLine" Width="550px" Height="80px"></asp:TextBox>
				  </td>
				</tr>
				 <tr>
				 <td class="bqleft"> 项目备注：&nbsp;</td>
				 <td class="bqright">
					 <asp:TextBox ID="txtObjectDemo" runat="server" TextMode="MultiLine" Width="450px" Height="80px"></asp:TextBox>
				 </td>
			   </tr>
				<tr>
					<td colspan="2" align="center">
						<input id="btnSkip" type="button" value=" 下一步 " class="btn" onclick="SkipFun(this);" />
					</td>
				</tr>
			   </tbody>
			</table>

<!--列表页设置-->
			<table id="listTable1" cellpadding="0" cellspacing="0" width="99%" align="center" border="0" class="cd" style="display:none">
			   <tbody>
					<tr align='center'>
						<td id='TabTitle' onclick=ShowTabs(0) class="title6">基本设置</td>
						<td id='TabTitle' onclick=ShowTabs(1) class="title5">分页设置</td>
						<td id='TabTitle' onclick=ShowTabs(2) class='title5'>代码预览</td>
						 <td>&nbsp;</td>              
					</tr>
				</tbody>
            </table>

			<table id="listTable2"   width='99%' border='0' align='center' cellpadding='0' cellspacing='1' class='editborder' style="display:none">
			  <tbody id='Tabs'>
				   <tr>
					  <td class="bqleft">列表开始代码：</td>
					  <td class="bqright">
						  <asp:TextBox ID="txtListStart" runat="server" TextMode="multiLine" Width="500" Height="50"></asp:TextBox>
						  <span style="color:Red">*</span>
						  <input id="btnStartCheck" type="button" value="测试代码" class="btn" onclick="CheckCodeFun(txtListStart)" />
					  </td>
					</tr>

					<tr>
					  <td class="bqleft"> 列表结束代码：</td>
					  <td class="bqright">
						  <asp:TextBox ID="txtListEnd" runat="server" TextMode="multiLine" Width="500" Height="50" ></asp:TextBox>
						  <span style="color:Red">*</span>
						  <input id="btnEndCheck" type="button" value="测试代码" class="btn" onclick="CheckCodeFun(txtListEnd)" />
						</td>
					</tr>

					<tr>
					   <td class="bqleft">  链接开始代码：</td>
					   <td class="bqright">
						  <asp:TextBox ID="txtLinkStart" runat="server" TextMode="multiLine" Width="500" Height="50"></asp:TextBox>
						  <span style="color:Red">*</span>
					  </td>
					</tr>

					<tr>
					   <td class="bqleft"> 链接结束代码：</td>
					   <td class="bqright">
						  <asp:TextBox ID="txtLinkEnd" runat="server" TextMode="multiLine" Width="500" Height="50"></asp:TextBox>
						  <span style="color:Red">*</span>
						</td>
					</tr>
					</tbody>

					<tbody id='Tabs' style='display:none'>
					<tr>
					  <td class="bqleft"> 选择分页类型：</td>
					   <td class="bqright">
						<input type="radio" id="rdoPage0" value="0" name="ListPaingType" runat="server" onclick="HidPage()" />不采集列表分页&nbsp;
						<input type="radio" id="rdoPage1" value="1" name="ListPaingType" runat="server" onclick="ShowPageFun(ListPaing1)" />从源代码中获取下一页的URL&nbsp;
						<input type="radio" id="rdoPage2" value="2" name="ListPaingType" runat="server" onclick="ShowPageFun(ListPaing2)" />批量指定分页URL代码&nbsp;
						<input type="radio" id="rdoPage3" value="3" name="ListPaingType" runat="server" onclick="ShowPageFun(ListPaing3)" />手动添加分页URL代码 
					  </td>
					</tr>

					<tr id="ListPaing1" style="display:none;">
					 <td class="bqleft">“下一页”<br />URL开始代码：<br/><br/><br/><br/><br/><br/>
						“下一页”<br />URL结束代码：
					  </td>
					  <td class="bqright">
						  <asp:TextBox ID="txtNextPageStart" runat="server" TextMode="multiLine" Width="450px" Height="100px"></asp:TextBox>&nbsp;
						  <input type="button" value='测试代码' class="btn" onclick="CheckCodeFun(txtNextPageStart)" /><br/>
						  <asp:TextBox ID="txtNextPageEnd" runat="server" TextMode="multiLine" Width="450px" Height="100px"></asp:TextBox>&nbsp;
						  <input type="button" value='测试代码' class="btn" onclick="CheckCodeFun(txtNextPageEnd)" /><br/>
					  </td>
					</tr>

					<tr id="ListPaing2" style="display:none">
					  <td class="bqleft">URL字符串：<br/><br/><br/>ID范围：</td>
					   <td class="bqright"><asp:TextBox ID="txtUrlStr" runat="server" Width="500"></asp:TextBox><br />
							<span style="color:#0099FF">例：http://www.xxxxx.com/news/index_{$ID}.html&nbsp;&nbsp;&nbsp;&nbsp;{$ID}代表分页数</span><br/><br/>
						    <asp:TextBox ID="txtStartId" runat="server" Width="80" Text="0"></asp:TextBox>
						    <span lang="en-us"> To </span>
						    <asp:TextBox ID="txtEndId" runat="server" Width="80" Text="0"></asp:TextBox>
						    <span style="color:#0099FF;"> 1 ~ 9 或 9 ~ 1 升序或倒序采集</span><br/>
					  </td>
					</tr>

					<tr id="ListPaing3" style="display:none">
					 <td class="bqleft">URL列表：&nbsp;</td>
					   <td class="bqright">
						    <asp:TextBox ID="txtUrlList" TextMode="multiLine" runat="server" Width="500" Height="100"></asp:TextBox><br />
							<span style="color:#0099FF">注：一行写一个网页地址</span>
					 </td>
					</tr>
					</tbody>

					<tbody id='Tabs' style='display:none'>
						<tr>
							  <td class="tdbg" colspan="2" align="left" >
								  <div><asp:TextBox ID="txtPreview" runat="server" TextMode="multiLine" Width="100%" Height="500px"></asp:TextBox></div>
								  <div style="text-align:left;"><span style="color:#0099FF">注：由于考虑到数据量的，我们只列出第一个列表页的数据</span></div>
							 </td>
						</tr>
					</tbody>
					<tr>
						<td colspan="2" align="center">
							<input id="btnListPre" type="button" value="上一步" class="btn" onclick="PreFun(this)" />
							<input id="btnListSkip" type="button" value="下一步" class="btn" onclick="SkipFun(this)" />
						</td>
					</tr>
				</table>

<!--正文设置-->
          <table id="conTable1" cellspacing="0" cellpadding="0" width="99%" align="center" border="0" class="cd" style="display:none;">
           <tbody>
                <tr align='center'>
                    <td id='TabTitle' onclick=ShowTabs1(3) class="title6">基本设置</td>
					<td id='TabTitle' onclick=ShowTabs1(4) class="title5">分页设置</td>
                    <td id='TabTitle' onclick=ShowTabs1(5) class="title5">过滤规则</td>
                    <td id='TabTitle' onclick=ShowTabs1(6) class="title5">采样测试</td>
                    <td id='TabTitle' onclick=ShowTabs1(7) class="title5">属性设置</td>
                     <td>&nbsp;</td>              
                </tr></tbody>
            </table>

			<table id="conTable2" width='99%' border='0' align='center' cellpadding='0' cellspacing='1' class='editborder' style="display:none;">
				<tbody id='Tabs'>
					 <tr>
						<td style="padding:0px;">
							<table cellspacing="1" cellpadding="0" width="100%" border="0">
								 <tr>
									<td class="bqleft">选择字段：</td>
									<td class="bqright">
										<table>
											<tr>
												<td>
													<asp:ListBox ID="lbFildList" runat="server" Height="180" Width="160" SelectionMode="Multiple" onChange="CreateHtml()"></asp:ListBox>           												</td>
												<td align="right" valign="top" style="display:none;">
													<table>
														<tr>
															<td><b>测试代码预览：</b></td>
															<td><asp:TextBox ID="txtFieldPre" runat="server" TextMode="multiLine" Width="100%" Height="165px"></asp:TextBox></td>
														</tr>
													</table>
												</td>
											</tr>
										</table>                            
									</td>
								 </tr>
							</table>
						</td>
					</tr>
				     <tr>
				        <td id="tableCreate" style="padding:0px; border:none;">
				        </td>
				     </tr>
			   </tbody>

    			<tbody id="Tabs" style="display:none">
					<tr>
					  <td class="bqleft"> 选择分页类型：</td>
					   <td class="bqright">
						<input type="radio" id="rdoConPage1" value="0" name="ConPaingType" runat="server" onclick="HidConPage()" />不采集列表分页&nbsp;
						<input type="radio" id="rdoConPage2" value="1" name="ConPaingType" runat="server" onclick="ShowPageFun(ConPaing1)" />从源代码中获取下一页的URL&nbsp;
						<input type="radio" id="rdoConPage3" value="2" name="ConPaingType" runat="server" onclick="ShowPageFun(ConPaing2)" />批量指定分页URL代码&nbsp;
						<input type="radio" id="rdoConPage4" value="3" name="ConPaingType" runat="server" onclick="ShowPageFun(ConPaing3)" />手动添加分页URL代码 
					  </td>
					</tr>

					<tr id="ConPaing1" style="display:none;">
					 <td class="bqleft">“下一页”<br />URL开始代码：<br/><br/><br/><br/><br/><br/>
						“下一页”<br />URL结束代码：
					  </td>
					  <td class="bqright">
						  <asp:TextBox ID="txtConPageStart" runat="server" TextMode="multiLine" Width="450px" Height="100px"></asp:TextBox>&nbsp;
						  <input type="button" value='测试代码' class="btn" /><br/>
						  <asp:TextBox ID="txtConPageEnd" runat="server" TextMode="multiLine" Width="450px" Height="100px"></asp:TextBox>&nbsp;
						  <input type="button" value='测试代码' class="btn" /><br/>
					  </td>
					</tr>

					<tr id="ConPaing2" style="display:none">
					  <td class="bqleft">URL字符串：<br/><br/><br/>ID范围：</td>
					   <td class="bqright"><asp:TextBox ID="txtConAddress" runat="server" Width="500"></asp:TextBox><br />
							<span style="color:#0099FF">例：http://www.xxxxx.com/news/index_{$ID}.html&nbsp;&nbsp;&nbsp;&nbsp;{$ID}代表分页数</span><br/><br/>
						    <asp:TextBox ID="txtConStartId" runat="server" Width="80" Text="0"></asp:TextBox>
						    <span lang="en-us"> To </span>
						    <asp:TextBox ID="txtConEndId" runat="server" Width="80" Text="0"></asp:TextBox>
						    <span style="color:#0099FF;"> 1 ~ 9 或 9 ~ 1 升序或倒序采集</span><br/>
					  </td>
					</tr>

					<tr id="ConPaing3" style="display:none">
					 <td class="bqleft">URL列表：&nbsp;</td>
					   <td class="bqright">
						    <asp:TextBox ID="txtConPageAddress" TextMode="multiLine" runat="server" Width="500" Height="100"></asp:TextBox><br />
							<span style="color:#0099FF">注：一行写一个网页地址</span>
					 </td>
					</tr>		
				</tbody>

				<tbody id='Tabs' style='display:none'>
				  <tr>
					<td class="bqleft"> 简单过滤规则：</td>
					<td class="bqright">
						<asp:CheckBoxList ID="chkSimpleFilter" runat="server">
							<asp:ListItem Value="0">Object：过滤Falsh广告,控件等。</asp:ListItem>
							<asp:ListItem Value="1">Script：过滤js、vbs等脚本。</asp:ListItem>
							<asp:ListItem Value="2">Style：过滤Css 类。</asp:ListItem>
							<asp:ListItem Value="3">Div：过滤层。</asp:ListItem>
							<asp:ListItem Value="4">Span：过滤行内元素Span容器。</asp:ListItem>
							<asp:ListItem Value="5">Table Tr Td ：过滤表格属性。</asp:ListItem>
							<asp:ListItem Value="6">Img：过滤图片。注意如果选择过滤图片采集过来的数据中将不会有图片</asp:ListItem>
							<asp:ListItem Value="7">FONT：过滤字体定义。 (字留下样式去掉)</asp:ListItem>
							<asp:ListItem Value="8">A：过滤链接 (字留下链接去掉)</asp:ListItem>
							<asp:ListItem Value="9">Html：过滤采集正文页中的html字符。注意如果选择过滤HTML采集过来的数据将以纯文本形式显</asp:ListItem>
						</asp:CheckBoxList>
				</td>
				</tr>
				<tr>
				   <td class="bqleft"> 高级过滤规则：</td>
				   <td class="bqright">
					   <asp:ListBox ID="lbFilterRule" runat="server" Width="120" Height="150" SelectionMode="Multiple">
						</asp:ListBox><br />
						复杂规则,用于过滤广告等信息.
					</td>
				</tr>
			</tbody>

			<tbody id='Tabs' style='display:none'>
				<tr>
					<td colspan="2">
						<asp:TextBox ID="txtCollectionTest" runat="server" TextMode="multiLine" Width="100%" Height="500"></asp:TextBox>
					</td>
				</tr>
		   </tbody>

			<tbody id='Tabs' style='display:none'>
				<tr>
					<td class="bqleft">属性设置</td>
					<td class="bqright">
                        <asp:CheckBoxList ID="chkPropetry" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0" Text="推荐"></asp:ListItem>
                            <asp:ListItem Value="1" Text="焦点"></asp:ListItem>
                            <asp:ListItem Value="2" Text="头条"></asp:ListItem>
                            <asp:ListItem Value="3" Text="幻灯"></asp:ListItem>
                            <asp:ListItem Value="4" Text="置顶"></asp:ListItem>
                            <asp:ListItem Value="5" Text="不规则"></asp:ListItem>
                            <asp:ListItem Value="6" Text="允许评论"></asp:ListItem>
                            <asp:ListItem Value="7" Text="发布"></asp:ListItem>
                        </asp:CheckBoxList>
					</td>
				</tr>
				<tr>
					<td class="bqleft">评分等级</td>
					<td class="bqright">
                        <asp:DropDownList ID="ddlStarLevel" runat="server">
                            <asp:ListItem Value="★">★</asp:ListItem>
                            <asp:ListItem Value="★★">★★</asp:ListItem>
                            <asp:ListItem Value="★★★">★★★</asp:ListItem>
                            <asp:ListItem Value="★★★★">★★★★</asp:ListItem>
                            <asp:ListItem Value="★★★★★">★★★★★</asp:ListItem>
                        </asp:DropDownList>
					</td>
				</tr>
				<tr><td class="bqleft">阅读点数</td><td class="bqright"><asp:TextBox ID="txtHitCout" runat="server" Width="60px" Text="0"></asp:TextBox></td></tr>
			</tbody>


			<tr>
				<td colspan="2" align="center">
                    &nbsp;<input id="btnPreCon" type="button" value=" 上一步 " class="btn" onclick="PreFun(this)" />
					<asp:Button ID="btnSave" runat="server" Text=" 完 成 " CssClass="btn" OnClientClick="return ValidateConPage()" OnClick="btnSave_Click" />
				</td>
			</tr>
    </table>
		
    </div>
    </form>
</body>
</html>
