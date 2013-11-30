String.prototype.trim = function()  
{  
	return this.replace(/(^\s*)|(\s*$)/g, "");  
}
function $(val)
{
    return document.getElementById(val);
}
function WinOpen(url,n,w,h)
{
        var left = (screen.width-w)/2;
        var top = (screen.height-h)/2;
        var f = "width="+w+",height="+h+",top="+top+",left="+left;
        var c = window.open(url,n,f);
        return c; 
}
function WinOpenDialog(url,w,h)
{
    var feature = "dialogWidth:"+w+"px;dialogHeight:"+h+"px;center:yes;status:no;help:no";
    showModalDialog(url,window,feature);
}
function showlist(path,chId,fieldName,fieldValue,_target)
{
    var encodeValue = escape(fieldValue);
    if(_target.toLowerCase()=='blank') 
    window.open(path+'/list.aspx?chid='+chId+'&fieldname='+fieldName+'&keyword='+encodeValue);
    else
    location.href(path+'/list.aspx?chid='+chId+'&fieldname='+fieldName+'&keyword='+encodeValue);  
}
function ReviewPadding(appPath,modelType,id,pageSize,pageIndex)
{
    var data = XmlHttpGetMethodText(appPath + "/sys_template/MoreReviewList.aspx?ModelType=" + modelType + "&Id=" + id + "&PageSize=" + pageSize + "&P=" + pageIndex);
    document.getElementById('review_morelist_' + modelType + '_' + id).innerHTML=data
}

function SetSearchField(appPath,val)
{
    if(val.value!=0)
   { 
        document.getElementById("src_field_list").src=appPath+"/common/getsearchform.aspx?id="+val.value+"&flag=1"
   }
   else
   {
         document.getElementById("src_field_list").src=appPath+"/common/getsearchform.aspx?id="+val.value+"&flag=0"
   } 
}
function GoSearch(appPath)
{
   var chid = document.getElementById("search_channel_list").value;
   var fieldName =  document.getElementById("search_field_list").value;
   var keyword = document.getElementById("search_txt_keyword").value.trim();
   if(keyword.length==0)
   {
        alert('搜索内容必须填写');
        return;
   }
   if(chid!=0&&fieldName!=0)
   {
        window.open(appPath+"/List.aspx?chid="+chid+"&fieldname="+fieldName+"&keyword="+escape(keyword)+"&Search=1");
   }
   else
   {
        alert("频道和字段必须选择");
   }
}
function CheckNumber(val)
{
   var patt=/^\d+$/;
   return patt.test(val) ;
}
function go(f_url,pc,colid)
{
    var pi = $("txtPageNav"+colid).value;
    if(!CheckNumber(pi)) 
    {
        alert('页索引只能是数字'); 
        return; 
    }  
    if(pi<1||pi>pc)
    { 
        alert("页索引超出范围") ;
        return; 
     } 
     if(pi==1) 
    { 
        location.href(f_url) ;
        return; 
     } 
     var charindex = f_url.lastIndexOf(".")
     var preStr = f_url.substr(0,charindex);
     var ext = f_url.substr(charindex,f_url.length-charindex);
     var patt = /.*(\..*?)\?.*/i
     if(f_url.replace(patt,"$1").toLowerCase()!=".aspx") 
     {     
            location.href(preStr+"_"+pi+ext);
     } 
     else
     {
            location.href(f_url.setQuery("p",pi));
     }   
}
 String.prototype.setQuery   =   function(name,   value)   
  {   
      var   reg   =   new   RegExp("(^|&|\\?)("+   name   +"=)([^&]*)(&|$)");   
      var   r   =   this.substr(this.indexOf("?")+1).match(reg);   
      if   (r!=null)   return   this.replace(reg,   "$1$2"+   value   +"$4");   
      else   return   this   +   (this.indexOf("?")>-1   ?   "&"   :   "?")+   name   +"="+   value   
  }   
function SetDig(appPath,modelid,id)
{

    if( $("dig_"+modelid+"_"+id)!=null&&$("click_dig_"+modelid+"_"+id)!=null)
    { 
   var loadstr =   '<img src="'+appPath+'/images/dig_loading.gif">' 

        $("click_dig_"+modelid+"_"+id).innerHTML = loadstr;

    var data = XmlHttpGetMethodText(appPath+"/common/dig.aspx?type=set&modelid="+modelid+"&id="+id); 
         if(data!="-1") 
           { 
                $("dig_"+modelid+"_"+id).innerHTML=data;
           } 
       $("click_dig_"+modelid+"_"+id).innerHTML="成&nbsp;&nbsp;功";
        $("click_dig_"+modelid+"_"+id).style.removeAttribute("cursor");
        $("click_dig_"+modelid+"_"+id).removeAttribute("onclick"); 
     } 
    return false; 
}



function SuperLabelPage(PagePath,CaseId)
{
    var data = XmlHttpGetMethodText(PagePath);
    document.getElementById(CaseId).innerHTML=data;
}

function GetAjaxLabel(url,paramStr,currId,type)
{
    
     var data = XmlHttpPostMethodText(url,"paramStr="+paramStr+"&currId="+currId+"&type="+type)
     document.write(data) ;
}

function GetHiddenContent(url,paramStr,infoId,pageIndex,pageCount,tableName)
{
    var data = XmlHttpPostMethodText(url,"paramstr="+paramStr+"&id="+infoId+"&pageindex="+pageIndex+"&pagecount="+pageCount+"&tablename="+tableName);
     document.write(data) ;
}
