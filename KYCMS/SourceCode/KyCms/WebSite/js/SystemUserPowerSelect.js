// JScript 文件

//选择普通权限
    function CheckBox(PCName,PCId)
    {
        var pc_id=PCId;
        var MyPCId=pc_id.split(",")
                
        if(document.all[PCName].checked==true)
        {
            for(var i=0;i<MyPCId.length;i++)
            {
                document.all["PCId_"+MyPCId[i]].checked=true
            }
            
           document.all["Show"+PCName].innerHTML="取消选择"; 
         }
         else
         {
            for(var i=0;i<MyPCId.length;i++)
            {
                document.all["PCId_"+MyPCId[i]].checked=false
            }
            document.all["Show"+PCName].innerHTML="选择全部";
         }   
         //表格显示
         CheckTable(1);
    }
    
    function CheckTable(TableId)
    {
        Case_div=eval("CheckTable_" + TableId)
        
        if(document.all["PCId_"+TableId].checked==true)
        {
            Case_div.style.display=""
        }
        else
        {
            Case_div.style.display="none"
        }
    }
    
    function SelectAllChColColSpan(TableId)
    {
        var TableNum=document.form1.TableNum.value;
        
        //选择列
        if(document.all["SelectAllChColColSpan"+TableId].checked==true)
        {
            for(var i=1;i<=TableNum;i++)
            {
                document.all["ChIdColumnId_"+i+"_"+TableId].checked=true
            }
        }
        else
        {
            for(var i=1;i<=TableNum;i++)
            {
                document.all["ChIdColumnId_"+i+"_"+TableId].checked=false
            }
        }
    }
    
    function SelectAllChColRowsSpan(TableNum)
    {
        //选择行
        if(document.all["SelectAllChColRowsSpan"+TableNum].checked==true)
        {
            for(var i=1;i<=4;i++)
            {
                document.all["ChIdColumnId_"+TableNum+"_"+i].checked=true
            }
        }
        else
        {
            for(var i=1;i<=4;i++)
            {
                document.all["ChIdColumnId_"+TableNum+"_"+i].checked=false
            }
        }
    }
    
    //所有全选
    function SelectAllChColColRows()
    {
        var TableNum=document.form1.TableNum.value;
    
        if(document.form1.AllChColColRows.checked==true)
        {
            for(var i=1;i<=TableNum;i++)
            {
                for(var o=1;o<=4;o++)
                {
                    document.all["ChIdColumnId_"+i+"_"+o].checked=true
                    document.all["SelectAllChColColSpan"+o].checked=true
                }
                document.all["SelectAllChColRowsSpan"+i].checked=true
            }
            
        }
        else
        {
            for(var i=1;i<=TableNum;i++)
            {
                for(var o=1;o<=4;o++)
                {
                    document.all["ChIdColumnId_"+i+"_"+o].checked=false
                    document.all["SelectAllChColColSpan"+o].checked=false
                }
                document.all["SelectAllChColRowsSpan"+i].checked=false
            }
        }
    }
    
    //审核选择
    //
    function SelectOption()
    {
        var SelectBoxValue1=document.form1.SelectBoxValue.value;
        var MySlectBoxValue=SelectBoxValue1.split(",")
        var SelectBox=document.form1.Select_Option.selectedIndex;
        
        
        for(var i=0;i<MySlectBoxValue.length;i++)
        {
            document.all["Select_"+MySlectBoxValue[i]].options[SelectBox].selected=true;
        }
    }
    
    //取消选择后，需要取消总选择
    //管理员组
    function SelectCancel(Colspan,TableNum)
    {        
        var TableNumValue=document.form1.TableNum.value;
        
        if(document.all["ChIdColumnId_"+TableNum+"_"+Colspan].checked==false)
        {
            document.all["SelectAllChColColSpan"+Colspan].checked=false
            document.all["SelectAllChColRowsSpan"+TableNum].checked=false
            document.form1.AllChColColRows.checked=false;
        }
    }
    
    //取消选择后，需要取消总选择
    //用户组
    function SelectCancelUser(Colspan,TableNum)
    {        
        var TableNumValue=document.form1.TableNum.value;
        
        if(document.all["ChIdColumnId_"+TableNum+"_"+Colspan].checked==false)
        {
            document.all["SelectAllChColColSpan"+Colspan].checked=false
        }
    }
    
    //取消下拉框值
    function SelectCancelSelect()
    {
        document.form1.Select_Option.options[0].selected=true;
    }
    
    //角色模型跳转
    function ModelPowerColumn(PowerId)
    {
        window.location.href="ModelPowerColumn.aspx?PowerId="+PowerId+"";
    }
    
    //所有权限栏目只能够为数字
    function AllUserGroup(ColumnName)
    {
        if(document.all[ColumnName].value=="")
        {
            alert("栏目设置不能够为空！");
            document.all[ColumnName].focus();
            return false;
        }
        
        if(isNaN(document.all[ColumnName].value))
        {
            alert("栏目设置只能够为数字！")
            document.all[ColumnName].focus();
            return false;
        }        
        return true;
    }