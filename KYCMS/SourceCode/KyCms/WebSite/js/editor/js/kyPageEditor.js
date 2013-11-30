    var kyEditor = null; 
    var isComplete = false;
    var model = 0; 
    var currRange = null; 
     function $(val)
    {
        return document.getElementById(val);
    } 
    function WinOpenDialog(url,w,h)
    {
    var feature = "dialogWidth:"+w+"px;dialogHeight:"+h+"px;center:yes;status:no;help:no";
    showModalDialog(url,window,feature);
    } 
    function InstanceIframe()
    {
        kyEditor = window.frames["Editor"]; 
        kyEditor.document.designMode="On";
        isComplete = true;
    } 
    public_description = new KyEditorInstane;
    function KyEditorInstane ()
    {
        this.get_Document = GetDocument; 
        this.put_SetDocument = SetDocument; 
    }  

    function GetDocument()
    {
        while(!isComplete) {}    
        if(model==1)
        { 
            return kyEditor.document.documentElement.outerText;
         } 
        else
         { 
            return kyEditor.document.documentElement.outerHTML;
         } 

    } 

    function SetDocument(val) 
   {
        while(!isComplete) {}   
        kyEditor.document.write(val);
   } 
   function SetEditor(val)
   {
        if(model==1)
        {
            alert('请切换到界面模式'); 
            return ; 
        }  
        kyEditor.focus();
        kyEditor.document.execCommand(val);
   }
   function SetPasteHTML(val)
   {
        if(model==1)
        {
            alert('请切换到界面模式'); 
            return ; 
        }  
         kyEditor.focus();
         try
        {  
            var oRange = kyEditor.document.selection.createRange();
            oRange.pasteHTML(val);
        }catch(e){} 
   }
    function SetPasteHTML2(val)
   {
         kyEditor.focus();
         try
        {  
            var oRange = kyEditor.document.selection.createRange();
            oRange.pasteHTML(val);
        }catch(e){} 
   }
   function SetOtherEditor(op)
   {
        kyEditor.focus();
        switch(op)
       {
           case "Source":
           if(model==0) 
           { 
                model = 1; 
                $('btnSource').value = '界面模式';
                var tmp = kyEditor.document.documentElement.outerHTML 
                kyEditor.document.open();
                kyEditor.document.clear(); 
                kyEditor.document.write("<html><head><style>body{font-size:12px;font-family:verdana;margin:0px}p{margin:0px}</style></head><body></body></html>");
                kyEditor.document.close();
                kyEditor.document.body.innerText = tmp;

           } 
           else
           { 
                model = 0;  
                $('btnSource').value = '代码模式'; 
                var tmp = kyEditor.document.body.innerText;
                kyEditor.document.open();
                kyEditor.document.clear(); 
                kyEditor.document.write(tmp);
                kyEditor.document.close();
           } 
           break; 
       } 
   }
   function InsertTable(val)
   {
   
        if($('dvShow').style.visibility=="hidden")
       { 
            var top = getOffsetTop($('imgInsertTable'))+$('imgInsertTable').offsetHeight;
            var left = getOffsetLeft($('imgInsertTable'));
            $('dvShow').style.top = top; 
            $('dvShow').style.left= left;
            $('dvShow').style.visibility = "visible" ;
       }
       else
       {
            $('dvShow').style.visibility = "hidden" ;
       } 
       
            
   }
   function getOffsetTop(elm) 
{
	var mOffsetTop = elm.offsetTop;
	var mOffsetParent = elm.offsetParent;
	while(mOffsetParent){
		mOffsetTop += mOffsetParent.offsetTop;
		mOffsetParent = mOffsetParent.offsetParent;
	}
	return mOffsetTop;
}
function getOffsetLeft(elm)
{
	var mOffsetLeft = elm.offsetLeft;
	var mOffsetParent = elm.offsetParent;
	while(mOffsetParent) {
		mOffsetLeft += mOffsetParent.offsetLeft;
		mOffsetParent = mOffsetParent.offsetParent;
	}
	return mOffsetLeft;
}




