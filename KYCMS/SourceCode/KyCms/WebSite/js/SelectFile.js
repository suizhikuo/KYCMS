
function SetPath(path,controlId)
{
    if(controlId!="")
   {
       window.parent.dialogArguments.document.getElementById(controlId).value=path;
       window.close();
   } 
   else
   {
        alert("非法操作");
   }
}
function SetShow(val)
{
   var obj = document.getElementById(val);
   var obj2;
    if(val=="tbUpload")
   {
        obj2 = document.getElementById("tbCreate");
   }
   else
   {
        obj2 = document.getElementById("tbUpload");
   }
   if(obj.style.display=='none')
   {
       obj2.style.display = 'none';
       obj.style.display = '';
        
   } 
   else
   {
        obj.style.display = 'none';
   }
   return false;
}

/*
function CreateDir(val)
{
    alert(val)
}
function DeleteFile(val)
{
    alert(val);
}

function HiddenMenu()
{
    if(document.getElementById("menu").style.display=="")
   {
        document.getElementById("menu").style.display="none";
   } 
}


   function ShowMenu()
   {
        if(event.srcElement.parentElement.value!=null)
       {
            var arr = event.srcElement.parentElement.value.split('|');
            var path = arr[0].split('\\').join("\\\\"); 
            var type=arr[1]; 
            if(type=="")
           {
              var htmlStr =  "<table cellpadding=3 cellspacing=1 bgColor=gray width=100px>"; 
              htmlStr += "<tr bgColor=white class=hand><td onclick='CreateDir(\""+path+"\")''>建立文件夹</td></tr>";
              htmlStr += "<tr bgColor=white class=hand><td onclick='CreateDir(\""+path+"\")''>删除</td></tr>";
              htmlStr += "<tr bgColor=white class=hand><td onclick='HiddenMenu()'>关闭菜单</td></tr>";
              htmlStr +="</table>";
                document.getElementById("menu").innerHTML= htmlStr;
            }
           else
          {
               var htmlStr =  "<table cellpadding=3 cellspacing=1 bgColor=gray width=100px>"; 
              htmlStr += "<tr bgColor=white class=hand><td onclick='CreateDir(\""+path+"\")''>删除文件</td></tr>";
              htmlStr += "<tr bgColor=white class=hand><td onclick='HiddenMenu()'>关闭菜单</td></tr>";
              htmlStr +="</table>";
                document.getElementById("menu").innerHTML= htmlStr;
          }    
           
        var rightedge = document.body.clientWidth-event.srcElement.parentElement.offsetTop;
        var bottomedge = document.body.clientHeight-event.srcElement.parentElement.offsetLeft;
       //alert(event.srcElement.parentElement.offsetLeft) 
     

        if (rightedge <document.getElementById("menu").offsetWidth)
            document.getElementById("menu").style.left = document.body.scrollLeft + event.x;
        else

            document.getElementById("menu").style.left = document.body.scrollLeft + event.x;
        if (bottomedge <document.getElementById("menu").offsetHeight)
        document.getElementById("menu").style.top = document.body.scrollTop + event.srcElement.parentElement.offsetTop ;
        else   
        document.getElementById("menu").style.top = document.body.scrollTop + event.srcElement.parentElement.offsetTop;
        document.getElementById("menu").style.display = "";

       } 
        return false;
   }
   */