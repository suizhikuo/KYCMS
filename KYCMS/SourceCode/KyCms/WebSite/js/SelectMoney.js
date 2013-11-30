// JScript 文件

function GetTime()
{
    var ExpireTime=document.form1.ExpireTime.value;
    user_Money_MoneyChange.GetTimeString(ExpireTime,Serverfull_CallBack)
    setTimeout("GetTime()",1000);
}

function Serverfull_CallBack(response)
{
    SpareDay.innerHTML=response.value;
}

function SelectMoneyType()
{
    var Index=document.form1.MoneyType.value;
    
    if(document.form1.MoneyType1.value!="0")
    {
        SelectMoneyType1();
    }

    if(Index!=0)
    {
     var MyGUnitName=eval("GUnitName_"+Index);
            
     MoneyTypeDiv_1.innerHTML=document.form1.MoneyType.options[Index].text
            
     GUnitNameLabel.innerHTML=MyGUnitName.innerHTML;
   }
}

function SelectChangeValue()
{
    var ChangeValue=document.form1.ChangeValue.value;
    
    document.form1.ChangeValue.value=Number(ChangeValue);
    
    ChangeValueLable.innerHTML=Number(ChangeValue);
    
    if(document.form1.MoneyType.value!="0")
    {
        SelectMoneyType();
    }
    
    if(document.form1.MoneyType1.value!="0")
    {
        SelectMoneyType1();
    }
}

function SelectMoneyType1()
{
    //判断需要转换的类型
    if(document.form1.MoneyType.value=="0")
    {
        alert("请选择需要转换类型!")
        ChangeVlaueLable2.innerHTML=0;
        GUnitNameLabel2.innerHTML="";
        document.form1.MoneyType1.value="0";
        document.form1.MoneyType.focus();
        return false;
    }
    
    //根据转换的类型计算出转换结果
    //获得结果
    var Index=document.form1.MoneyType.value;
    var IndexVlaue=document.form1.MoneyType1.value;
    var ChangeValueValue=document.form1.ChangeValue.value;
    var UserYellowBoyVlaue=document.form1.UserYellowBoy.value;
    var UserIntegralValue=document.form1.UserIntegral.value;
    var UserExpireDayValue=document.form1.UserExpireDay.value;   
    
    if(IndexVlaue!="0")
    {
        var MyGUnitName=eval("GUnitName_"+IndexVlaue);
        
        if(Index=="1")
        {
            if(IndexVlaue=="1")
            {
                alert("不能够和转换类型相同!")
                document.form1.MoneyType1.value="0";
                ChangeVlaueLable2.innerHTML=0;
                GUnitNameLabel2.innerHTML="";
                return false;
            }
            
            if(IndexVlaue=="2")
            {
                ChangeVlaueLable2.innerHTML=Math.floor(Number(ChangeValueValue)*Number(UserIntegralValue)/Number(UserYellowBoyVlaue))
                GUnitNameLabel2.innerHTML=MyGUnitName.innerHTML;
            }
            
            if(IndexVlaue=="3")
            {
                ChangeVlaueLable2.innerHTML=Math.floor(Number(ChangeValueValue)*Number(UserExpireDayValue)/Number(UserYellowBoyVlaue))
                GUnitNameLabel2.innerHTML=MyGUnitName.innerHTML;
            }
        }
        
        if(Index=="2")
        {
            if(IndexVlaue=="2")
            {
                alert("不能够和转换类型相同!")
                document.form1.MoneyType1.value="0";
                ChangeVlaueLable2.innerHTML=0;
                GUnitNameLabel2.innerHTML="";
                return false;
            }
            
            if(IndexVlaue=="1")
            {
                ChangeVlaueLable2.innerHTML=Math.floor(Number(ChangeValueValue)*Number(UserYellowBoyVlaue)/Number(UserIntegralValue))
                GUnitNameLabel2.innerHTML=MyGUnitName.innerHTML;
            }
            
            if(IndexVlaue=="3")
            {
                ChangeVlaueLable2.innerHTML=Math.floor(Number(ChangeValueValue)*Number(UserExpireDayValue)/Number(UserIntegralValue))
                GUnitNameLabel2.innerHTML=MyGUnitName.innerHTML;
            }
        }
        
        if(Index=="3")
        {
            if(IndexVlaue=="3")
            {
                alert("不能够和转换类型相同!")
                document.form1.MoneyType1.value="0";
                ChangeVlaueLable2.innerHTML=0;
                GUnitNameLabel2.innerHTML="";
                return false;
            }
            
            if(IndexVlaue=="1")
            {
                ChangeVlaueLable2.innerHTML=Math.floor(Number(ChangeValueValue)*Number(UserYellowBoyVlaue)/Number(UserExpireDayValue))
                GUnitNameLabel2.innerHTML=MyGUnitName.innerHTML;
            }
            
            if(IndexVlaue=="2")
            {
                ChangeVlaueLable2.innerHTML=Math.floor(Number(ChangeValueValue)*Number(UserIntegralValue)/Number(UserExpireDayValue))
                GUnitNameLabel2.innerHTML=MyGUnitName.innerHTML;
            }
        }
        
      
        MoneyTypeDiv_2.innerHTML=document.form1.MoneyType1.options[IndexVlaue].text
    }
    
    return true;
}

function isok()
{
    if(document.form1.ChangeValue.value=="")
    {
        alert("请输入转换值")
        document.form1.ChangeValue.focus();
        return false;
    }
    
    if(Number(document.form1.ChangeValue.value)<=0)
    {
        alert("请输入一个大于0的整数")
        document.form1.ChangeValue.focus();
        return false;
    }
    
    if(document.form1.MoneyType.value==0)
    {
        alert("请选择需要转换的类型")
        document.form1.MoneyType.focus();
        return false;
    }
    
    if(document.form1.MoneyType1.value==0)
    {
        alert("请选择转换的类型")
        document.form1.MoneyType1.focus();
        return false;
    }
    
    if(document.form1.PassWord.value=="")
    {
        alert("请输入登陆密码")
        document.form1.PassWord.focus();
        return false;
    }
    
    return true;
}


function SelectMoneyType2()
{
    var MyMoneyType=document.form1.MoneyType.value;
    
    if(MyMoneyType!="0")
    {
        if(MyMoneyType=="1")
        {
            GUnitNameLable.innerHTML=GUnitName_9.innerHTML;
            GUnitNameLable_1.innerHTML=GUnitName_9.innerHTML+"金币";
        }
        
        if(MyMoneyType=="2" )
        {
            GUnitNameLable.innerHTML="点";
            GUnitNameLable_1.innerHTML="点积分";
        }
        
        if(MyMoneyType=="3" )
        {
            GUnitNameLable.innerHTML="天";
            GUnitNameLable_1.innerHTML="天有效期";
        }
    }
}

function SelectChangeValue2()
{
    var MySelectChangeValue=document.form1.ChangeValue.value;
    SelectChangeValueLable.innerHTML=Number(MySelectChangeValue);
    document.form1.ChangeValue.value=Number(MySelectChangeValue);
}

function SelectSendUser()
{
    var MySelectSendUser=document.form1.SendUser.value;
    SendUserLable.innerHTML=MySelectSendUser;
}

function isok2()
{
    if(document.form1.ChangeValue.value=="")
    {
        alert("请输入转换值")
        document.form1.ChangeValue.focus();
        return false;
    }
    
    if(Number(document.form1.ChangeValue.value)<=0)
    {
        alert("请输入一个大于0的整数")
        document.form1.ChangeValue.focus();
        return false;
    }
    
    if(document.form1.MoneyType.value==0)
    {
        alert("请选择需要转换的类型")
        document.form1.MoneyType.focus();
        return false;
    }
    
    if(document.form1.SendUser.value==0)
    {
        alert("请输入赠送用户名称")
        document.form1.SendUser.focus();
        return false;
    }
    
    if(document.form1.PassWord.value=="")
    {
        alert("请输入登陆密码")
        document.form1.PassWord.focus();
        return false;
    }
    
    return true;
}