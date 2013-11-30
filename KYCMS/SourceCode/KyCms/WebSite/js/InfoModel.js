// JScript 文件
function SetParam()
{
    var data = XmlHttpPostMethodText("GetColumn.aspx","ColId="+$('ddlColId').value);
    if(data== "")
    {
        return; 
    }  
    else
    {
        var param = data.split('$');
        if(param.length==7)
        {  
            $('rdBtnPageType_'+(param[0]-1)).checked=true; 
            $('txtTemplatePath').value = param[1];
            $('rdBtnChargeType'+param[2]).checked=true;
            $('txtChargeHourCount').value=param[3];
            $('txtChargeViewCount').value=param[4];
            $('txtPointCount').value=param[5]; 
            if(param[6]=="True")
            {
                $('chkBoxIsAllowComment').checked=true;
            }
       } 
    }   
}

function SetParamuser()
{
    var data = XmlHttpPostMethodText("../../system/info/GetColumn.aspx","ColId="+$('ddlColId').value);
    if(data== "")
    {
        return; 
    }  
    else
    {
        var param = data.split('$');
        $('rdBtnPageType_'+(param[0]-1)).checked=true; 
        $('txtTemplatePath').value = param[1];
        $('rdBtnChargeType'+param[2]).checked=true;
        $('txtChargeHourCount').value=param[3];
        $('txtChargeViewCount').value=param[4];
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

//检测的短标题
function CheckTitle(TableName)
{
    var title = $("txtTitle").value.trim();
    if(title.length==0) 
    {
          alert('检测的标题必须填写');
          $("txtTitle").focus();
          return;
    } 
     var flag = CheckHas("../common/CheckHas.aspx",title,"Title",TableName)
     if(!flag)
     {
          alert("该标题不存在！"); 
          $("txtTitle").focus();
     }  
     else
     {
         alert("该标题已经存在！"); 
         $("txtTitle").focus();
     }
}

//标题类型
function SetTitleType(obj){
    var temp=obj;
    if(temp==1){
        $('rbComm').checked=true;
        ShowImgUrl.style.display="none";
        $('chkBoxIsSideShow').disabled=true;
    }
    else if(temp==2){
        $('rbImg').checked=true; 
        ShowImgUrl.style.display=""; 
         $('chkBoxIsSideShow').disabled=false; 
    }
}

//获取文章类型
function GetTitleType()
{
    if($("rbComm").checked){
        ShowDefault.style.display="";
        ShowImgUrl.style.display="none";
         $('chkBoxIsSideShow').disabled=true;
    }
   else  if($("rbImg").checked){
         ShowImgUrl.style.display="";
          ShowDefault.style.display="";
          $('chkBoxIsSideShow').disabled=false; 
    }
}

//分隔关键字
function SepTagName()
{
    $("txtTagNameStr").focus();
   if(document.selection)
   {
     var range=document.selection.createRange();
     range.text="|";
   } 
}

function btnSetToppicStr(val)
{
   var lst1=$("lBoxTopicIdStr");
   var length=lst1.options.length;
   var tt="";
   if(val=="ChooseAll")
   {
       for(var i=0;i<length;i++)
       {
            lst1.options[i].selected = true;
       }
   }
   else 
   {
       for(var i=0;i<length;i++)
       {
            lst1.options[i].selected = false;
       }
   }
}

//
function GetModelHtml(ChId,Id)
{
    system_info_UpdateInfo.GetModelHtmlValue(ChId,Id,CallBack)
}

function GetModelHtmlUser(ChId,Id)
{
    user_info_UpdateInfo.GetModelHtmlValue(ChId,Id,CallBack)
}

function GetModelHtmlUser_User(TypeId,UserId)
{
    System_user_SetUser.GetModelHtmlValue(TypeId,UserId,CallBack)
}

function GetModelHtmlUser_User_1(TypeId,UserId)
{
    user_SetUser.GetModelHtmlValue(TypeId,UserId,CallBack)
}

function CallBack(res)
{
    for(var i=0;i<res.value.Tables[0].Rows.length;i++)
    {
        //TextType
        var FieldName=res.value.Tables[0].Rows[i]["Name"];
        
        switch(res.value.Tables[0].Rows[i]["Type"])
        {
            case "TextType":
                try
                {
                    $("txt_"+FieldName+"").value=res.value.Tables[1].Rows[0][""+FieldName+""];
                }
                catch(e)
                {}
                break;
            case "ListBoxType":
                try
                {
                    if(res.value.Tables[0].Rows[i]["Content"].substring(0,1)=="1")
                    {
                        for(var p=0;p<document.all["txt_"+FieldName+""].length;p++)
                        {
                            if(res.value.Tables[1].Rows[0][""+FieldName+""].indexOf(","+document.all["txt_"+FieldName+"_"+p+""].value+",")!="-1")
                             {
                                 document.all["txt_"+FieldName+"_"+p+""].checked=true;                             
                             }
                        }
                     }
                     else
                     {
                        for(var p=0;p<document.all["txt_"+FieldName+""].length;p++)
                        {
                            if(res.value.Tables[1].Rows[0][""+FieldName+""].indexOf(","+document.all["txt_"+FieldName+""][p].value+",")!="-1")
                             {
                                 document.all["txt_"+FieldName+""][p].selected=true;                             
                             }
                        }
                     }
                 }
                 catch(e)
                 {}
                break;
            case "DateType":
                try
                {
                    $("txt_"+FieldName+"").value=res.value.Tables[1].Rows[0][""+FieldName+""];
                }
                catch(e)
                {}
                break;
            case "MultipleTextType":
                try
                {
                    $("txt_"+FieldName+"").value=res.value.Tables[1].Rows[0][""+FieldName+""];
                }
                catch(e){}
                break;
            case "MultipleHtmlType":
                try
                {
                    $("txt_"+FieldName+"").value=res.value.Tables[1].Rows[0][""+FieldName+""];
                    window.frames["txt_"+FieldName+"___Frame"].location.reload();
                }
                catch(e){}
                break;
            case "PicType":
                try
                {
                    $("txt_"+FieldName+"").value=res.value.Tables[1].Rows[0][""+FieldName+""];
                }
                catch(e){}
            break;
            case "RadioType":
                try
                {
                if(res.value.Tables[0].Rows[i]["Content"].substring(0,1)=="2")
                {
                    for(var p=0;p<document.all["txt_"+FieldName+""].length;p++)
                    {
                        if(document.all["txt_"+FieldName+"_"+p+""].value==""+res.value.Tables[1].Rows[0][""+FieldName+""]+"")
                        {
                            document.all["txt_"+FieldName+"_"+p+""].checked=true;
                        }
                    }
                }
                else
                {
                    $("txt_"+FieldName+"").value=res.value.Tables[1].Rows[0][""+FieldName+""];
                }
                }
                catch(e){}
                break;
            case "FileType":
                try
                {
                    $("txt_"+FieldName+"").value=res.value.Tables[1].Rows[0][""+FieldName+""];
                }
                catch(e){}
                break;
            case "RadomType":
                try
                {
                    $("txt_"+FieldName+"").value=res.value.Tables[1].Rows[0][""+FieldName+""];
                }
                catch(e){}
                break;
            case "NumberType":
                try
                {
                    $("txt_"+FieldName+"").value=res.value.Tables[1].Rows[0][""+FieldName+""];
                }
                catch(e){}
                break;
            case "ErLinkageType":
                try
                {
                    if(res.value.Tables[1].Rows[0][""+FieldName+""]==null)
                    {
                        GetLinkage('select_'+FieldName,'select_'+SelName,0);
                    }
                    else
                    {
                        $("select_"+FieldName+"").value=res.value.Tables[1].Rows[0][""+FieldName+"_Id"];
                        $("txt_"+FieldName+"").value=res.value.Tables[1].Rows[0][""+FieldName+""];
                        var SelName=res.value.Tables[0].Rows[i]["Content"].split(",")[2].split("=")[1];
                        var SelValue=res.value.Tables[1].Rows[0][""+SelName+""];
                        $("txt_"+SelName+"").value=SelValue;
                        $("txt_"+SelName+"_Id").value=res.value.Tables[1].Rows[0][""+SelName+"_Id"];
                        GetLinkage('select_'+FieldName,'select_'+SelName,1);
                    }
                }
                catch(e){}
                break;
            default:
                try
                {
                    $("txt_"+FieldName+"").value=res.value.Tables[1].Rows[0][""+FieldName+""];
                }
                catch(e){}
                break;
        }
    }
}
    
function GetLinkage(ParName,SelName,TypeId)
{
    var ParentId=$(ParName).value;
    var ParentText=$(ParName).options[$(ParName).selectedIndex].text;
    
    $(ParName.replace("select","txt")+"_Id").value=ParentId;
    $(ParName.replace("select","txt")).value=ParentText;
    if(ParentId=="0")
    {
        $(SelName).length=1;
        $(SelName).options[0].text = "请选择";
        $(SelName).options[0].value = "0";
        $(SelName.replace("select","txt")).value=0;
    }
    else
    {
        if(TypeId=="0")
        {
            common_Linkage.GetLinkageDs(ParentId,SelName,Call_Back_Linkage);
        }
        else
        {
            common_Linkage.GetLinkageDs(ParentId,SelName,Call_Back_Linkage_Update);
        }
    }
}
    
function Call_Back_Linkage(res)
{
    var SelName=res.value.Tables[1].Rows[0]["SelName"];
    $(SelName).length=0;
    
    if(res.value.Tables[0].Rows.length>0)
    {
        for(var i=0;i<res.value.Tables[0].Rows.length;i++)
        {
           $(SelName).length++;
           $(SelName).options[i].text = res.value.Tables[0].Rows[i]["DicName"];
           $(SelName).options[i].value = res.value.Tables[0].Rows[i]["ID"];
        }
        
        $(SelName.replace("select","txt")).value=res.value.Tables[0].Rows[0]["DicName"];
        $(SelName.replace("select","txt")+"_Id").value=res.value.Tables[0].Rows[0]["ID"];
    }
    else
    {
        $(SelName).length=1;
        $(SelName).options[0].text = "无相关小类";
        $(SelName).options[0].value = "0";
        $(SelName.replace("select","txt")).value="无";
        $(SelName.replace("select","txt")+"_Id").value=0;
    }
}

function GetSmallLinkage(SelName)
{
    var SelId=$(SelName).value;
    var SelIdText=$(SelName).options[$(SelName).selectedIndex].text;
    $(SelName.replace("select","txt")).value=SelIdText;
    $(SelName.replace("select","txt")+"_Id").value=SelId;
}

function Call_Back_Linkage_Update(res)
{
    var SelName=res.value.Tables[1].Rows[0]["SelName"];
    $(SelName).length=0;
    
    if(res.value.Tables[0].Rows.length>0)
    {
        for(var i=0;i<res.value.Tables[0].Rows.length;i++)
        {
           $(SelName).length++;
           $(SelName).options[i].text = res.value.Tables[0].Rows[i]["DicName"];
           $(SelName).options[i].value = res.value.Tables[0].Rows[i]["ID"];
           
           if(res.value.Tables[0].Rows[i]["ID"]==$(SelName.replace("select","txt")+"_Id").value)
           {
                $(SelName).options[i].selected=true;
           }
        }       
    }
    else
    {
        $(SelName).length=1;
        $(SelName).options[0].text = "无相关小类";
        $(SelName).options[0].value = "0";
        $(SelName.replace("select","txt")).value="无";
        $(SelName.replace("select","txt")+"_Id").value=0;
    }
}