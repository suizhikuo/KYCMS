//51/a/s/px
String.prototype.trim = function()  
{  
	return this.replace(/(^\s*)|(\s*$)/g, "");  
}
function $(val)
{
    return document.getElementById(val);
}
function IsDisplay(ctl)
{
    var obj=$(ctl);
    obj.style.display = obj.style.display=='none' ? obj.style.display='' :obj.style.display='none';
}
function WinOpen(url,n,w,h)
{
        var left = (screen.width-w)/2;
        var top = (screen.height-h)/2;
        var f = "width="+w+",height="+h+",top="+top+",left="+left+",scrollbars=1";
        var c = window.open(url,n,f);
        return c; 
}
//返回日期
function returnDate()
{
    var day="";
    var month="";
    var ampm="";
    var ampmhour="";
    var myweekday="";
    var year="";
    mydate=new Date();
    myweekday=mydate.getDay();
    mymonth=mydate.getMonth()+1;
    myday= mydate.getDate();
    myyear= mydate.getYear();
    year=(myyear > 200) ? myyear : 1900 + myyear;
    if(myweekday == 0)
    weekday=" 星期日 ";
    else if(myweekday == 1)
    weekday=" 星期一 ";
    else if(myweekday == 2)
    weekday=" 星期二 ";
    else if(myweekday == 3)
    weekday=" 星期三 ";
    else if(myweekday == 4)
    weekday=" 星期四 ";
    else if(myweekday == 5)
    weekday=" 星期五 ";
    else if(myweekday == 6)
    weekday=" 星期六 ";
    return year+"年"+mymonth+"月"+myday+"日"+weekday;
}

function WinOpenDialog(url,w,h)
{
    var feature = "dialogWidth:"+w+"px;dialogHeight:"+h+"px;center:yes;status:no;help:no";
    //WinOpenDialog('../Common/SelectTemplate.aspx?ControlId=TextBox1&StartPath='+escape('/Template'),650,480)"
    showModalDialog(url,window,feature);
}
function CheckNumber(val)
{
   var patt=/^\d+$/;
   return patt.test(val) ;
}
function CheckNumberNotZero(val)
{
    var patt=/^[^0]\d*$/
    return patt.test(val) ; 
}
function ImgSize(val)
{

			var height = val.height;
			var width = val.width; 
			if(height>150&&width<=330)
			{
				val.height = 150;
			}
			else if(height<=150&&width>330)
			{
				val.width = 330;
			}
			else if(height>150&&width>330)
			{
				if(height/width>=150/330)
				{
					val.height = 150;
				}
				else
				{
					val.width = 330;
				}
			}
				

}

function CheckHas(uri,input,fileldName,tableName)
{
   var inputStr = escape(input);
   var fileldNameStr = escape(fileldName);
   var tableNameStr = escape(tableName);
   var paramStr = "Input="+input+"&FileldName="+fileldNameStr+"&TableName="+tableNameStr;
   var flag = XmlHttpPostMethodText(uri,paramStr)
   if(flag==1)
   {
        return true;
   }
   else
   {
        return false;
   } 
}
var tid=0;
function ShowTabs(cid)
{
    if(cid!=tid)
    {
        $("TabTitle"+tid).className="title5";
        $("TabTitle"+cid).className="title6";
        $("Tabs"+tid).style.display="none";
        $("Tabs"+cid).style.display="";
        tid=cid;
    }
}


//获取颜色
function GetColor(img_val,input_val)
{
	var PaletteLeft,PaletteTop
	var obj = $("colorPalette");
	ColorImg = img_val;
	ColorValue = $(input_val);
	if (obj){
		PaletteLeft = getOffsetLeft(ColorImg)
		PaletteTop = (getOffsetTop(ColorImg) + ColorImg.offsetHeight)
		if (PaletteLeft+150 > parseInt(document.body.clientWidth)) PaletteLeft = parseInt(event.clientX)-260;
		if (PaletteTop > parseInt(document.body.clientHeight)) PaletteTop = parseInt(document.body.clientHeight)-165;
		obj.style.left = PaletteLeft + "px";
		obj.style.top = PaletteTop + "px";
		if (obj.style.visibility=="hidden")
		{
			obj.style.visibility="visible";
		}else {
			obj.style.visibility="hidden";
		}
	}
}
function getOffsetTop(elm) {
	var mOffsetTop = elm.offsetTop;
	var mOffsetParent = elm.offsetParent;
	while(mOffsetParent){
		mOffsetTop += mOffsetParent.offsetTop;
		mOffsetParent = mOffsetParent.offsetParent;
	}
	return mOffsetTop;
}
function getOffsetLeft(elm) {
	var mOffsetLeft = elm.offsetLeft;
	var mOffsetParent = elm.offsetParent;
	while(mOffsetParent) {
		mOffsetLeft += mOffsetParent.offsetLeft;
		mOffsetParent = mOffsetParent.offsetParent;
	}
	return mOffsetLeft;
}

function setColor(color)
{
	if(ColorImg.id=='FontColorShow' && color=="#") color='#000000';
	if(ColorImg.id=='FontBgColorShow' && color=="#") color='#FFFFFF';
	if (ColorValue){ColorValue.value = color.substr(1);}
	if (ColorImg && color.length>1){
		ColorImg.src='../../Images/Rect.gif';
		ColorImg.style.backgroundColor = color;
	}else if(color=='#'){ ColorImg.src='../../Images/rectNoColor.gif';}
	$("colorPalette").style.visibility="hidden";
}
 function SelectAll(trigger,container)
{
     var obj=$(trigger);
     var chks=document.getElementById(container).getElementsByTagName("input");
      for(var i=0;i<chks.length;i++)
      {
           if(chks[i].type=="checkbox")
            {
                chks[i].checked=obj.checked;
             } 
      }
}
 function   coder(str)   
  {   
        var   s   =   "";   
        if   (str.length   ==   0)   return   "";   
        for   (var   i=0;   i<str.length;   i++)   
        {   
              switch   (str.substr(i,1))   
              {   
                      case   "<"     :   s   +=   "&lt;";       break;   
                      case   ">"     :   s   +=   "&gt;";       break;   
                      case   "&"     :   s   +=   "&amp;";     break;   
                      case   "   "     :   s   +=   "&nbsp;";   break;   
                      case   "\""   :   s   +=   "&quot;";   break;   
                      case   "\n"   :   s   +=   "<br>";       break;   
                      default       :   s   +=   str.substr(i,1);   break;   
              }   
        }   
        return   s;   
  }   


//IE和firefox通用的复制到剪贴板的JS函数
function copyToClipboard(txt) 
{        
     if(window.clipboardData)
     {
        window.clipboardData.clearData(); 
        window.clipboardData.setData("Text", txt);
        alert("复制成功！")
     } 
     else if(navigator.userAgent.indexOf("Opera") != -1) 
     {
        window.location = txt;
     }
     else if (window.netscape)
     {
       try 
       {
          netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
       }
       catch (e)
       {
          alert("被浏览器拒绝！\n请在浏览器地址栏输入'about:config'并回车\n然后将'signed.applets.codebase_principal_support'设置为'true'");
       }
        var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
        if (!clip)
               return;
        var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
        if (!trans)
               return;
        trans.addDataFlavor('text/unicode');
        var str = new Object();
        var len = new Object();
        var str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
        var copytext = txt;
        str.data = copytext;
        trans.setTransferData("text/unicode",str,copytext.length*2);
        var clipid = Components.interfaces.nsIClipboard;
        if (!clip)
               return false;      
        clip.setData(trans,null,clipid.kGlobalClipboard); 
        alert("复制成功！") 
     } 
}  

function ShowHidden(obj,Is,abs)
{
    if($(obj).style.display=="")
   {
        $(obj).style.display='none';
       if(abs=="left") 
             Is.className="down_bg";
       else if(abs=="right")
            Is.className="modelTitleDown";  
       Is.title='点击显示' ;
   } 
   else
   {
        $(obj).style.display='';
       if(abs=="left") 
           Is.className="up_bg"; 
       else if(abs=="right")
           Is.className="modelTitle";
       Is.title='点击隐藏' ;
    } 
}


function GetReadUserInfo()
{
    document.write("<script type='text/javascript' src='~/ajaxpro/prototype.ashx'></script>");
    document.write("<script type='text/javascript' src='~/ajaxpro/core.ashx'></script>");
    document.write("<script type='text/javascript' src='~/ajaxpro/converter.ashx'></script>");
    document.write("<script type='text/javascript' src='~/ajaxpro/common_ReadUserInfo,App_Web_oaidv3np.ashx'></script>");
    common_ReadUserInfo.ReadUserInfo("",UserInfo_Call_Back);
}