function  getWorkRange(obj){  
 obj.focus();  
 var  workRange=document.selection.createRange();  
 var  allRange=obj.createTextRange();  
 //len=workRange.text.length;  
 //alert("select text: "+ allRange.text);
}  

function onBold(obj)
{
	 obj.focus();  
	 var  workRange=document.selection.createRange();  
	 //var  allRange=obj.createTextRange(); 
	 //workRange.setEndPoint("StartToStart",allRange);  
	
	 if(workRange.text)
		 workRange.text = "[b]"+workRange.text+"[/b]";
	 else
		 alert("请先选中文字!");
	//obj.value = str;
}

function onItalic(obj)
{
	obj.focus();  
	 var  workRange=document.selection.createRange();  
	if(workRange.text)
		 workRange.text = "[i]"+workRange.text+"[/i]";
	 else
		 alert("请先选中文字!");
}

function onUnderline(obj)
{
	obj.focus();  
	 var  workRange=document.selection.createRange();  
	if(workRange.text)
		 workRange.text = "[u]"+workRange.text+"[/u]";
	 else
		 alert("请先选中文字!");
}

function onHyperLink(obj)
{
	
	var str = prompt("请输入超链接地址):",  "http:\/\/");

	if ((str != null) && (str != "http://"))
	{
		
		obj.focus();  
		 var  workRange=document.selection.createRange();  
		if(workRange.text)
			 workRange.text = "[url=\""+str+"\"]"+workRange.text+"[/url]";
		 else{
			 str = "[url]"+str+"[/url]";
		//str = "[url]"+str+"[/url]";
			obj.value = obj.value + str;
		 }
	}
}

function onImage(obj)
{
var str = prompt("输入图片的超链接):", "http:\/\/");

if ((str != null) && (str != "http://"))
{
	str = "\n[img]"+str+"[/img]\n";
	obj.value =obj.value + str;
}
}

//email
function onEmail(obj)
{
var str = prompt("输入E-mail链接地址):", "");

if ((str != null) && (str != ""))
{
	str = "[email]"+str+"[/email]";
	obj.value =obj.value + str;
}
}

function openme(obj)
{ 
	obj.style.background="#CCCCCC";
}
function closeme(obj)
{
	obj.style.background="";
} 

function onMp(obj) {
    var str = prompt("请输入视频地址):", "");

    if ((str != null) && str.length>0) {
        str = "\n[mp=320,260]"+str+"[/mp]\n";
        obj.value = obj.value + str;
    }
}

//flash
function onFlash(obj) {
    var str = prompt("请输入Flash地址):", "");

    if ((str != null) && str.length>0) {
        str = "\n[flash=480,360]"+str+"[/flash]\n";
        obj.value = obj.value + str;
    }
}


//onShockwave
function onShockwave(obj) {
    var str = prompt("请输入Shockwave地址):", "");

    if ((str != null) && str.length>0) {
        str = "\n[dir=480,360]"+str+"[/dir]\n";
        obj.value = obj.value + str;
    }
}

function onRm(obj) {
    var str = prompt("请输入视频地址", "");

    if ((str != null) && str.length>0) {
        str = "\n[rm=340,260]"+str+"[/rm]\n";
        obj.value = obj.value + str;
    }
}

//
function onQt(obj) {
    var str = prompt("请输入视频地址", "");

    if ((str != null) && str.length>0) {
        str = "\n[qt=500,350]"+str+"[/qt]\n";
        obj.value = obj.value + str;
    }
}

//发光字
function onGlow(obj) {
    var str = prompt("请输入产生发光的文字", "");

    if ((str != null) && str.length>0) {
        str = "[glow=255,red,2]"+str+"[/glow]";
        obj.value = obj.value + str;
    }
}

//阴影字
function onShadow(obj) {
    var str = prompt("请输入产生阴影的文字", "");

    if ((str != null) && str.length>0) {
        str = "[SHADOW=255,green,1]"+str+"[/SHADOW]";
        obj.value = obj.value + str;
    }
}

//表情
function OnEm(obj)
{
	window.open("../images/post/Em.html","","left=300,top=200,width=350,height=200,toolbar=no,menubar=no,scrollbars=no");
}

//帮助
function OnHelp(obj)
{
	window.open("../images/post/Help.html","","left=100,top=100,width=700,height=300,toolbar=no,menubar=no,scrollbars=yes");
}