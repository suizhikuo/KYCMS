// JScript 文件

function CheckDelBox(box)    
{
   for (var i=0;i<document.form1.elements.length;i++)
   {
      var e = document.form1.elements[i];
      if ( (e.type=='checkbox') )
        {                    
           var o=e.name.lastIndexOf('CheckBox1');
                   
           if(o!=-1)
           {
			    e.checked = box.checked;
           }
         }
    }
            
    if(document.form1.checkDel.checked==true)
    {
		ShowA.innerHTML="取消选择";
	}
	else
	{
		ShowA.innerHTML="选择全部";
	}
}