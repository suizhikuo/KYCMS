// JScript 文件
function showtips(url,width,height){
	//dhTipsLayer:author:dh20156;
	if(document.getElementById("dhtipsiframe")==null){
		var iframe = document.createElement("IFRAME");
		iframe.id = "dhtipsiframe";
    	iframe.style.position = "absolute";
		iframe.style.left = 0;
		iframe.style.top = 0;
		iframe.style.width = (document.body.scrollWidth>document.body.offsetWidth)?document.body.scrollWidth:document.body.offsetWidth;
		iframe.style.height = (document.body.scrollHeight>document.body.offsetHeight)?document.body.scrollHeight+20:document.body.offsetHeight;
		iframe.src=url;

		var div = document.createElement("DIV");
		div.id = "dhtipsdiv";
		div.oncontextmenu = function(){return false}
		div.onselectstart = function(){return false}
       with(div.style)
		{
			position = "absolute";
			left = 0;
			width = (document.body.scrollWidth>document.body.offsetWidth)?document.body.scrollWidth:document.body.offsetWidth;
			height = (document.body.scrollHeight>document.body.offsetHeight)?document.body.scrollHeight+20:document.body.offsetHeight;
			top = 0;
		}
 
        
		var div2 = document.createElement("DIV");
		div2.id = "dhtipscontent";
		div2.style.position = "absolute";
		div2.style.width=width;
		div2.style.left = document.body.offsetWidth/2-150+document.body.scrollLeft;
		div2.style.top = document.body.offsetHeight/2-150+document.body.scrollTop;
		div2.innerHTML = "<div class=\"tipsdiv\" style=\"height:"+height+"\"><iframe src="+url+" allowTransparency=\"true\" frameborder=\"0\"  width=\"100%\" height=\"100%\" scrolling=\"no\"></iframe></div><div class=\"closediv\"><input type=\"button\" class=\"closebtn\" value=\"关闭\" onclick=\"document.body.style.overflow='auto';document.getElementById('dhtipsiframe').style.display='none';document.getElementById('dhtipsdiv').style.display='none';document.getElementById('dhtipscontent').style.display='none';\" /></div>";
		div2.oncontextmenu = function(){return false}

		document.body.appendChild(iframe);
		document.body.appendChild(div);
		document.body.appendChild(div2);
	}
	else{
		document.getElementById("dhtipsiframe").style.display = "block";
		document.getElementById("dhtipsdiv").style.display = "block";
		document.getElementById("dhtipscontent").style.display = "block";
		document.getElementById("dhtipscontent").innerHTML = "<div class=\"tipsdiv\" style=\"height:"+height+"\"><iframe src="+url+" allowTransparency=\"true\" frameborder=\"0\"  width=\"100%\" height=\"100%\" scrolling=\"no\"></iframe></div><div class=\"closediv\"><input type=\"button\" class=\"closebtn\" value=\"关闭\" onclick=\"document.body.style.overflow='auto';document.getElementById('dhtipsiframe').style.display='none';document.getElementById('dhtipsdiv').style.display='none';document.getElementById('dhtipscontent').style.display='none';\" /></div>";
		document.getElementById("dhtipscontent").style.left = document.body.offsetWidth/2-150+document.body.scrollLeft;
		document.getElementById("dhtipscontent").style.top = document.body.offsetHeight/2-150+document.body.scrollTop;
	}
	var l = document.body.scrollLeft;
	var t = document.body.scrollTop;
	//document.body.disabled=true;
	document.body.style.overflow = "hidden";
	document.body.scrollLeft = l;
	document.body.scrollTop = t;
}


function hiddenIframe()
{
    if(parent.document.getElementById("dhtipsiframe")!=null)
   {
       parent. document.body.style.overflow='auto';
        parent.document.getElementById('dhtipsiframe').style.display='none';
        parent.document.getElementById('dhtipsdiv').style.display='none';
        parent.document.getElementById('dhtipscontent').style.display='none';
    } 
}
