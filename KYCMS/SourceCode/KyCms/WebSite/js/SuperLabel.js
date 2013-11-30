// JScript 文件
function SelectCateGory(value,text)
    {
        if(value=="0")
        {
            $("txtLbCategoryName").value="";
            $("txtLbCategoryId").value=0;
        }
        else
        {
            $("txtLbCategoryName").value=text;
            $("txtLbCategoryId").value=value;
        }
    }
    
    function DbFieldList_1(val)
    {
        var DataBaseType=$("TableValue").value.split("|")[3];
        var DataBaseConn=$("TxtDataBaseConn").value;
        system_label_SuperLabel.GetOption(val,DataBaseType,DataBaseConn,Serverfull_CallBack_1);
    }
    
    function Serverfull_CallBack_1(res)
    {
        document.form1.DbFieldList1.length=0;
        
        for(var i=0;i<=res.value.Rows.length;i++)
        {
            document.form1.DbFieldList1.length++;
            if(i==0)
            {
                document.form1.DbFieldList1.options[i].text = "所有数据";
                document.form1.DbFieldList1.options[i].value = "*";
            }
            else
            {
                var value = res.value.Rows[i-1]["name"];
                document.form1.DbFieldList1.options[i].text = value;
                document.form1.DbFieldList1.options[i].value = value;
            }
        }
        
        RestrictField();        
    }
    
    function DbFieldList_2(val)
    {
        var DataBaseType=$("TableValue").value.split("|")[3];
        var DataBaseConn=$("TxtDataBaseConn").value;
        system_label_SuperLabel.GetOption(val,DataBaseType,DataBaseConn,Serverfull_CallBack_2);
    }
    
    function Serverfull_CallBack_2(res)
    {
        document.form1.DbFieldList2.length=0;
        
        for(var i=0;i<=res.value.Rows.length;i++)
        {
            document.form1.DbFieldList2.length++;
            if(i==0)
            {
                document.form1.DbFieldList2.options[i].text = "所有数据";
                document.form1.DbFieldList2.options[i].value = "*";
            }
            else
            {
                var value = res.value.Rows[i-1]["name"];
                document.form1.DbFieldList2.options[i].text = value;
                document.form1.DbFieldList2.options[i].value = value;
            }
        }
        
        RestrictField();
    }
    
    
    
    function DbFieldList_3(val)
    {
        var DataBaseType=$("TableValue").value.split("|")[3];
        var DataBaseConn=$("TxtDataBaseConn").value;
        system_label_SuperLabel.GetOption(val,DataBaseType,DataBaseConn,Serverfull_CallBack_3);
    }
    
    function Serverfull_CallBack_3(res)
    {
        document.form1.DbFieldList3.length=0;
        
        for(var i=0;i<res.value.Rows.length;i++)
        {
            var value = res.value.Rows[i]["name"];
            
            document.form1.DbFieldList3.length++;
            document.form1.DbFieldList3.options[i].text = value;
            document.form1.DbFieldList3.options[i].value = value;
        }
    }
    
    function DbFieldList_4(val)
    {
        var DataBaseType=$("TableValue").value.split("|")[3];
        var DataBaseConn=$("TxtDataBaseConn").value;
        system_label_SuperLabel.GetOption(val,DataBaseType,DataBaseConn,Serverfull_CallBack_4);
    }
    
    function Serverfull_CallBack_4(res)
    {
        document.form1.DbFieldList4.length=0;
        
        for(var i=0;i<res.value.Rows.length;i++)
        {
            var value = res.value.Rows[i]["name"];
            
            document.form1.DbFieldList4.length++;
            document.form1.DbFieldList4.options[i].text = value;
            document.form1.DbFieldList4.options[i].value = value;
        }
    }
    
    function RestrictField()
    {
        if(document.form1.DataTable1.value!="0" && document.form1.DataTable2.value!="0")
        {
            DbFieldList_3(document.form1.DataTable1.value);
            DbFieldList_4(document.form1.DataTable2.value);
        }
        else
        { 
            document.form1.DbFieldList3.length=0;
            document.form1.DbFieldList4.length=0;
            document.form1.DbFieldList3.length++;
            document.form1.DbFieldList3.options[0].text = "选择主表字段";
            document.form1.DbFieldList3.options[0].value = "选择主表字段";  
            
            document.form1.DbFieldList4.length++;
            document.form1.DbFieldList4.options[0].text = "选择从表字段";
            document.form1.DbFieldList4.options[0].value = "选择从表字段";
        }
    }
    
    function SuperSearchTerm()
    {
        if(document.form1.DataTable1.value=="0")
        {
            alert("请选择一个主表")
            document.form1.DataTable1.focus();
            return false;
        }
        else
        {
            var DataTable_1=document.form1.DataTable1.value;
            var DataTable_2=document.form1.DataTable2.value;
            var DataBaseType=document.form1.TableValue.value.split("|")[3];
            var DataBaseConn=document.form1.TxtDataBaseConn.value;
            
            WinOpenDialog('SuperSearchTerm.aspx?DataTable1='+DataTable_1+'&DataTable2='+DataTable_2+'&DataBaseType='+DataBaseType+'&DataBaseConn='+escape(DataBaseConn)+'','650','500')
        }
        
        return true;
    }
    
    function SuperLabelOrder()
    {
        if(document.form1.DataTable1.value=="0")
        {
            alert("请选择一个主表")
            document.form1.DataTable1.focus();
            return false;
        }
        else
        {
            var DataTable_1=document.form1.DataTable1.value;
            var DataTable_2=document.form1.DataTable2.value;
            var DataBaseType=document.form1.TableValue.value.split("|")[3];
            var DataBaseConn=document.form1.TxtDataBaseConn.value;
            
            WinOpenDialog('SuperLabelOrder.aspx?DataTable1='+DataTable_1+'&DataTable2='+DataTable_2+'&DataBaseType='+DataBaseType+'&DataBaseConn='+escape(DataBaseConn)+'','500','600')
        }
        
        return true;
    }
    
    //所有权限栏目只能够为数字
    function TopNumber()
    {
        if(document.form1.TopNum.value=="")
        {
            alert("输出数量不能够为空！");
            document.form1.TopNum.focus();
            return false;
        }
        
        if(isNaN(document.form1.TopNum.value))
        {
            alert("输出数量只能够为数字！")
            document.form1.TopNum.focus();
            return false;
        }        
        return true;
    }
    
    function DataTableValue_1()
    {
       var DataTableValue=document.form1.DataTable1.value;
       var sel = false;
       var MySql="";
                
       for(var i=0;i<document.form1.DbFieldList1.options.length;i++)
        {
            var current = document.form1.DbFieldList1.options[i];
            if (current.selected)
            {
                sel = true;
                MySql+= DataTableValue+"."+document.form1.DbFieldList1.options[i].value+",";
            }
        }
                        
        if(!sel)
        {
            MySql=DataTableValue+".*";
        }
        else
        {
            MySql=MySql.substring(0,MySql.length-1);
        }
        
        return MySql;
    }
    
     function DataTableValue_2()
    {
       var DataTableValue=document.form1.DataTable2.value;
       var sel = false;
       var MySql="";
                
       for(var i=0;i<document.form1.DbFieldList2.options.length;i++)
        {
            var current = document.form1.DbFieldList2.options[i];
            if (current.selected)
            {
                sel = true;
                MySql+= DataTableValue+"."+document.form1.DbFieldList2.options[i].value+",";
            }
        }
                        
        if(!sel)
        {
            MySql=DataTableValue+".*";
        }
        else
        {
            MySql=MySql.substring(0,MySql.length-1);
        }
        
        return MySql;
    }
    
    function DataTableValue_3()
    {
       var DataTableValue=document.form1.DataTable1.value;
       var sel = false;
       var MySql="";
                
       for(var i=0;i<document.form1.DbFieldList1.options.length;i++)
        {
            var current = document.form1.DbFieldList1.options[i];
            if (current.selected)
            {
                sel = true;
                MySql+= document.form1.DbFieldList1.options[i].value+",";
            }
        }
                        
        if(!sel)
        {
            MySql="*";
        }
        else
        {
            MySql=MySql.substring(0,MySql.length-1);
        }
        
        return MySql;
    }
    
    function SuperLabelSql()
    {
        var SuperSearchTermText=document.form1.SuperSearchTermText.value;
        var SuperLabelOrderText=document.form1.SuperLabelOrderText.value;
        
        if(TopNumber())
        {
            if(document.form1.DataTable1.value=="0")
            {
                alert("请选择一个主表")
                document.form1.DataTable1.focus();
                return false;
            }
            else
            {
                var DataTable1Value=document.form1.DataTable1.value;
                var DataTable2Value=document.form1.DataTable2.value;
                var sel1 = false;
                var sel2 = false;
                var MySql="";
                
                //没有从表
                if(document.form1.DataTable2.value=="0")
                {
                    if(document.form1.TopNum.value=="0")
                    { 
                        document.form1.SuperLabelSqlText.value="SELECT "+DataTableValue_3()+" FROM "+DataTable1Value+""+SuperSearchTermText+""+SuperLabelOrderText+"";
                    }
                    else
                    {
                        document.form1.SuperLabelSqlText.value="SELECT TOP "+document.form1.TopNum.value+" "+DataTableValue_3()+" FROM "+DataTable1Value+""+SuperSearchTermText+""+SuperLabelOrderText+"";
                    }
                }
                else
                {
                    if(DataTable1Value==DataTable2Value)
                    {
                        if(document.form1.TopNum.value=="0")
                        { 
                            document.form1.SuperLabelSqlText.value="SELECT "+DataTableValue_3()+" FROM "+DataTable1Value+""+SuperSearchTermText+""+SuperLabelOrderText+"";
                        }
                        else
                        {
                            document.form1.SuperLabelSqlText.value="SELECT TOP "+document.form1.TopNum.value+" "+DataTableValue_3()+" FROM "+DataTable1Value+""+SuperSearchTermText+""+SuperLabelOrderText+"";
                        }
                    }
                    else
                    {
                        if(document.form1.TopNum.value=="0")
                        { 
                            document.form1.SuperLabelSqlText.value="SELECT "+DataTableValue_1()+","+DataTableValue_2()+" FROM "+DataTable1Value+" "+document.form1.Join.value+" "+DataTable2Value+" ON "+DataTable1Value+"."+document.form1.DbFieldList3.value+"="+DataTable2Value+"."+document.form1.DbFieldList4.value+""+SuperSearchTermText+""+SuperLabelOrderText+"";
                        }
                        else
                        {
                            document.form1.SuperLabelSqlText.value="SELECT TOP "+document.form1.TopNum.value+" "+DataTableValue_1()+","+DataTableValue_2()+" FROM "+DataTable1Value+" "+document.form1.Join.value+" "+DataTable2Value+" ON "+DataTable1Value+"."+document.form1.DbFieldList3.value+"="+DataTable2Value+"."+document.form1.DbFieldList4.value+""+SuperSearchTermText+""+SuperLabelOrderText+"";
                        }
                    }
                }
            }
         }
      }
      
      function CheckSql()
      {
        var val=document.form1.SuperLabelSqlText.value;
        var DataBaseType=$("TableValue").value.split("|")[3];
        var DataBaseConn=$("TxtDataBaseConn").value;
        
        if(val.length==0)
        {
            alert("请先生成Sql语句")
            return false;
        }
        else
        {        
            system_label_SuperLabel.CheckSql(val,DataBaseType,DataBaseConn,Serverfull_CallBack_Sql);
        }
      }
      
      function Serverfull_CallBack_Sql(res)
      {
        alert(res.value);
      }
      
function SelectDataBaseType()
{
    var val=$("DataBaseType").value;
    
    if(val=="1")
    {
        $("DataBaseType_1").style.display="";
        $("DataBaseType_2").style.display="none";
        $("DataBaseType_2_1").style.display="none";
        $("DataBaseType_2_2").style.display="none";
        $("DataBaseType_3").style.display="none";
    }
    
    if(val=="2")
    {
        $("DataBaseType_1").style.display="none";
        $("DataBaseType_2").style.display="";
        $("DataBaseType_2_1").style.display="";
        $("DataBaseType_2_2").style.display="";
        $("DataBaseType_3").style.display="none";
    }
    
    if(val=="3")
    {
        $("DataBaseType_1").style.display="";
        $("DataBaseType_2").style.display="none";
        $("DataBaseType_2_1").style.display="none";
        $("DataBaseType_2_2").style.display="none";
        $("DataBaseType_3").style.display="";
    }
    
    if(val=="4" || val=="5" || val=="6" || val=="7" || val=="8")
    {
        alert("目前还未开通该数据库类型，请选择KYCMS主数据库");
        $("DataBaseType").value="1";
        SelectDataBaseType();
    }
}

function SelectIsHtml()
{
    var IsHtml=document.getElementsByName("IsHtml"); 
    
    for(var i=1;i<IsHtml.length;i++)
    {         
        if(IsHtml[i].checked)
        {
            if(IsHtml[i].value=="True")
            {
                $("DivIsHtml").style.display="none"; 
                $("DivIsHtml_1").style.display="none"; 
            }
            else
            {
                $("DivIsHtml").style.display=""; 
                $("DivIsHtml_1").style.display=""; 
            }
        }
    }
}

function CheckSqlConn()
{
    system_label_SuperLabel.CheckSqlConn(document.form1.SqlIp.value,document.form1.SqlName.value,document.form1.SqlUserName.value,document.form1.SqlPassWord.value,CallBack);
}

function CallBack(res)
{
    alert(res.value);
}