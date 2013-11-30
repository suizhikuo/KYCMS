    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetDownLoad.aspx.cs" Inherits="System_down_SetDownLoad" %>

<%@ Import Namespace="Ky.BLL" %>
<%@ Import Namespace="System.Data" %>
<%@ Register TagPrefix="FCKeditorV2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>下载添加页面</title>
    <link href="../Css/default.css" rel="stylesheet" type="text/css" />

    <script src="../../JS/Common.js" type="text/javascript"></script>

    <script src="../../JS/XmlHttp.js" type="text/javascript"></script>
   <script src="../../JS/RiQi.js" type="text/javascript"></script> 
</head>
<body onload="OnLoadParam();OnLoadAddress();SetTitleType()">

    <iframe width="260" height="165" id="colorPalette" src="../../common/setcolor.htm"
        style="visibility: hidden; position: absolute; border: 1px gray solid; left: 2px;
        top: 1px;" frameborder="0" scrolling="no"></iframe>
    <form id="form1" runat="server">
        <table width="99%" border="0" cellpadding="0" cellspacing="0" class="wzdh" align="center">
            <tr>
                <td width="27" style="height: 26px">
                    &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" /></td>
                <td style="height: 26px">
                    您现在的位置： <a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href="ChannelList.aspx">频道管理</a> &gt;&gt; <asp:Literal ID="litNav" runat="server"></asp:Literal></td>
                <td width="116" align="center" style="height: 26px">
                    &nbsp;</td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="99%" align="center" border="0">
            <tbody>
                <tr align="center">
                    <td id="TabTitle0" class="title6" onclick="ShowTabs(0)">
                        基本信息</td>
                    <td id="TabTitle1" class="title5" onclick="ShowTabs(1)">
                        所属专题</td>
                    <td id="TabTitle2" class="title5" onclick="ShowTabs(2)">
                        阅读权限</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </tbody>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" align="center" style="margin-top:0;">
            <tbody id="Tabs0">
                <tr>
                    <td class="bqleft" style="height: 29px">
                        标题类型：</td>
                    <td class="bqright" style="height: 29px">
                        <asp:RadioButton ID="rbComm" runat="server" Checked="True" GroupName="TitleType"
                            onclick="SetTitleType()" Text="普通标题" />
                        <asp:RadioButton ID="rbImg" runat="server" GroupName="TitleType" onclick="SetTitleType()"
                            Text="图片标题" /></td>
                </tr>
                <tr id="ShowImgUrl" style="display: none">
                    <td class="bqleft" style="height: 29px">
                        标题图片：</td>
                    <td class="bqright" style="height: 29px">
                        <asp:TextBox ID="txtTitleImgPath" name="txtTitleImgPath" runat="server" Width="35%"></asp:TextBox><asp:TextBox
                            ID="FilePicPath" runat="server" Style="display: none"></asp:TextBox>
                        <input type="button" value="选择图片" class="btn" onclick="WinOpenDialog('../../common/SelectPic.aspx?ControlId='+escape('txtTitleImgPath'),460,400)" /></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        所属栏目：</td>
                    <td class="bqright">
                        <select id="ddlColId" name="ddlColId" onchange="SetParam()">
                            <%
                                DataTable dt = ColumnBll.GetFormatListItemByChannelId(ChannelId);
                                foreach (DataRow dr in dt.Rows)
                                {
                                    string colName = dr["ColName"].ToString();
                                    int colId = Convert.ToInt32(dr["ColId"]);
                                    bool flag = ColumnBll.ChkHasChildByColId(colId);
                                    if (flag && !ColumnBll.GetColumn(colId).IsAllowAddInfo)
                                    {
                                        if (ColumnId == colId)
                                        {

                                            Response.Write("<option value=\"" + colId + "\" style=\"background-color:red\" selected>" + colName + "</option>");
                                        }
                                        else
                                            Response.Write("<option value=\"" + colId + "\" style=\"background-color:red\">" + colName + "</option>");
                                    }
                                    else
                                    {
                                        if (ColumnId == colId)
                                            Response.Write("<option value=\"" + colId + "\" selected>" + colName + "</option>");
                                        else
                                            Response.Write("<option value=\"" + colId + "\">" + colName + "</option>");
                                    }
                                }
                            %>
                        </select>
                        属性设置：
                        <asp:CheckBox runat="server" ID="chkBoxIsRecommand" Text="推荐" />
                        <asp:CheckBox runat="server" ID="chkBoxIsTop" Text="固顶" />
                        <asp:CheckBox runat="server" ID="chkBoxIsFocus" Text="焦点" />
                        <asp:CheckBox ID="chkBoxIsSideShow" runat="server" Text="幻灯" />
        <asp:CheckBox ID="chkBoxIsAllowComment" runat="server" Text="允许评论" Checked="True" />&nbsp; 
                    <asp:CheckBox ID="chkBoxIsCreate" runat="server" Text="发布" Checked="True" /></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        <%=ChannelModel.TypeName %>名称：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtSoftName" runat="server" Width="300px" MaxLength="200"></asp:TextBox>
                        
                        <asp:DropDownList ID="ddlTitleFontType" runat="server">
                            <asp:ListItem Value="0">常规</asp:ListItem>
                            <asp:ListItem Value="1">粗体</asp:ListItem>
                            <asp:ListItem Value="2">斜体</asp:ListItem>
                        </asp:DropDownList>
                        <span style="display: none">
                            <asp:TextBox ID="txtTitleColor" runat="server" Width="45px"></asp:TextBox></span>
                        <span>
                            <img src="../../images/<%if(txtTitleColor.Text=="") {%>rectNoColor.gif<%}else{%>rect.gif<%} %>"
                                width="18" height="17" border="0" align="absmiddle" id="TitleColorShow" style="cursor: pointer;
                                background-color: #<%=txtTitleColor.Text %>;" title="选取颜色!" onclick="GetColor($('TitleColorShow'),'txtTitleColor');" /></span>
                        <%=ChannelModel.TypeName %>版本号：<asp:TextBox ID="txtSoftEdition" runat="server" Width="15%"></asp:TextBox>
                        <input type="button" class="btn" value="<%=ChannelModel.TypeName %>名称重名检测" onclick="CheckTitle()" /></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        <%=ChannelModel.TypeName %>性质：</td>
                    <td class="bqright">
                        <%=ChannelModel.TypeName %>类别<asp:DropDownList ID="ddlSoftType" runat="server">
                        </asp:DropDownList>
                        <%=ChannelModel.TypeName %>语言<asp:DropDownList ID="ddlSoftLanguage" runat="server">
                        </asp:DropDownList>
                        授权方式<asp:DropDownList ID="ddlSoftWarrantType" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        TAG关键字：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtTagName" runat="server" Width="50%" MaxLength="100"></asp:TextBox><span class="tips">多个关键字用空格分开(每个关键字长度不能超过20个字)</span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        运行环境：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtSoftOS" runat="server" Width="70%"></asp:TextBox><br />
                        <span style="color: #808080" class="fl tips">平台选择:</span> <span class="fl">
                            <asp:Panel ID="plSoftOs" runat="server">
                            </asp:Panel>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        插件认证：</td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlSoftPlugin" runat="server">
                            <asp:ListItem>无插件</asp:ListItem>
                            <asp:ListItem>有插件 强行安装</asp:ListItem>
                            <asp:ListItem>有插件 手动安装</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        设定下载地址数：</td>
                    <td class="bqright">
                        <asp:TextBox runat="server" ID="txtAddressIdstr" Style="display: none"></asp:TextBox><asp:TextBox
                            runat="server" ID="txtreturnNum" Style="display: none"></asp:TextBox>
                        <input onkeypress="if(window.event.keyCode==13){document.form1.btnsetcount.focus(); };if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;" id="AddressNum" name="AddressNum" value="1" style="width: 33px" onblur="SetCount()" maxlength="2" />
                        <input type="button" value="设定" class="btn" id="btnsetcount" name="btnsetcount" onclick="SetCount()"
                            onfocus="true" /><input id="txtTemplateNum" name="txtTemplateNum" value="0" style="display: none" /></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        下载地址:
                    </td>
                    <td class="bqright">
                        <div id="MyMain" style="display: none">
                            <div id="div_template">
                                <input id="txtDLId" name="nmDLId" value="0" style="display:none " />
                                <input id="txtAddressName" style="width: 80px" value="下载地址" name="nmAddressName" />
                                <asp:DropDownList ID='ddlDownServerID' runat='server' name="nmDownServerID" onchange="$('txtAddressName').value=this.value==-1?'下载地址':this.options[this.selectedIndex].innerText">
                              </asp:DropDownList>
                                <input id='txtSoftAddressPath' name="nmAddressPath" style="width: 20%" />
                                <input type='button' value='添加地址' class='btn' id='btnAddAddress' onclick="AddAddress('txtSoftAddressPath');" /></div>
                        </div>
                        <div id="showServerList">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft" style="height: 28px">
                        <%=ChannelModel.TypeName %>大小：</td>
                    <td class="bqright" style="height: 28px">
                        <asp:TextBox ID="txtSoftSize" runat="server" Width="10%" Text="0"></asp:TextBox>
                        MB</td>
                </tr>
                <tr>
                    <td class="bqleft" style="height: 42px">
                        <%=ChannelModel.TypeName %>简介：</td>
                    <td class="bqright" style="height: 42px">
                        <FCKeditorV2:FCKeditor ID="txtSoftRemark" runat="server" Height="300px">
                        </FCKeditorV2:FCKeditor></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        演示地址：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtSoftPlayAddress" runat="server" Width="35%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        注册地址：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtSoftRegAddress" runat="server" Width="35%"></asp:TextBox></td>
                </tr>
				
                <tr>
                    <td class="bqleft">
                        添加时间：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtAddTime" runat="server" Width="15%" ></asp:TextBox><span class='tips'>默认为当前时间！</span></td>
                </tr>

                <tr>
                    <td class="bqleft">
                        解压密码：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtSoftDisplePwd" runat="server" Width="35%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        模板路径：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtSoftTemplatePath" runat="server" Width="35%"></asp:TextBox>
                        <input id="btnSelTemplate" class="btn" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtSoftTemplatePath')+'&StartPath='+escape('/Template'),650,480)"
                            type="button" value="选择模板" /></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        生成方式：</td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="rdBtnPageType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">.html</asp:ListItem>
                            <asp:ListItem Value="2">.htm</asp:ListItem>
                            <asp:ListItem Value="3">.shtml</asp:ListItem>
                            <asp:ListItem Value="4">.aspx</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        评分等级：</td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlSoftGrade" runat="server">
                            <asp:ListItem Value="★">★</asp:ListItem>
                            <asp:ListItem Value="★★">★★</asp:ListItem>
                            <asp:ListItem Selected="True" Value="★★★">★★★</asp:ListItem>
                            <asp:ListItem Value="★★★★">★★★★</asp:ListItem>
                            <asp:ListItem Value="★★★★★">★★★★★</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        下载次数：</td>
                    <td class="bqright">
                        本日：<asp:TextBox ID="txtSoftDownDayNum" runat="server" Width="50px" Text="0"  MaxLength="10" onkeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox>
                        本周：<asp:TextBox ID="txtSoftDownWeekNum" runat="server" Width="50px" Text="0"  MaxLength="10" onkeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox>
                        本月：<asp:TextBox ID="txtSoftDownMonthNum" runat="server" Width="50px" Text="0" MaxLength="10" onkeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox><asp:HiddenField ID="hfHitCount" runat="server"   Value="0"/>
                        总计：<asp:TextBox ID="txtSoftDownNum" runat="server" Width="50px" Text="0"></asp:TextBox></td>
                </tr>
            </tbody>
            <tbody id="Tabs1" style="display: none">
                <tr>
                    <td class="bqleft">
                        所属专题：
                    </td>
                    <td class="bqright" style="height: 221px">
                        <asp:ListBox ID="lBoxSpecialIdStr" runat="server" Height="173px" SelectionMode="Multiple"
                            Width="203px"></asp:ListBox>
                        <br />
                        <input type="button" id="btnSelAllTopicIdStr" name="btnSelAllTopicIdStr" value="选定所有专题"
                            class="btn" onclick="btnSetToppicStr('ChooseAll')" />
                        <br />
                        <input type="button" id="btnCanCelTopicIdStr" name="btnCanCelTopicIdStr" value="取消选定的专题"
                            class="btn" onclick="btnSetToppicStr('Cancel')" />
                    </td>
                </tr>
            </tbody>
            <tbody id="Tabs2" style="display: none">
                <tr>
                    <td class="bqleft">
                        下载权限：</td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="rdBtnIsOpened" runat="server">
                            <asp:ListItem Selected="True" Value="2">继承栏目权限（当所属栏目为认证栏目时，建议选择此项）</asp:ListItem>
                            <asp:ListItem Value="1">开放（当所属栏目为开放栏目，想单独对某些文章进行阅读权限设置，可以选择此项）</asp:ListItem>
                            <asp:ListItem Value="0">认证（当所属栏目为开放栏目，想单独对某些文章进行阅读权限设置，可以选择此项）</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:CheckBoxList ID="chkBoxGroupIdStr" runat="server" RepeatDirection="Horizontal">
                        </asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        重复收费方式：</td>
                    <td class="bqright">
                        <asp:RadioButton ID="rdBtnChargeType1" runat="server" Checked="True" GroupName="ChargeType" />不重复收费<br />
                        <asp:RadioButton ID="rdBtnChargeType2" runat="server" GroupName="ChargeType" />距离上次收费时间<asp:TextBox
                            runat="server" ID="txtChargeHourCount" Text="24" MaxLength="10" onkeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox>小时后重新收费<br />
                        <asp:RadioButton ID="rdBtnChargeType3" runat="server" GroupName="ChargeType" />会员重复阅读此文章<asp:TextBox
                            runat="server" ID="txtChargeViewCount" Text="10" Width="137px" MaxLength="10" onkeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox>
                        次后重新收费
                        <br />
                        <asp:RadioButton ID="rdBtnChargeType4" runat="server" GroupName="ChargeType" />上述两者都满足时重新收费<br />
                        <asp:RadioButton ID="rdBtnChargeType5" runat="server" GroupName="ChargeType" />上述两者任一个满足时就重新收费<br />
                        <asp:RadioButton ID="rdBtnChargeType6" runat="server" GroupName="ChargeType" />每阅读一次就重复收费一次（建议不要使用）
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        下载收取金币数：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtSoftPoint" runat="server" Width="10%" Text="0"  MaxLength="10" onkeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox>(阅读本文需要消耗多少<%=SiteModel.GUnitName%>金币)</td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="2" class="tdheight" align="center">
                        <asp:Button runat="server" Text=" 保 存 " OnClientClick="return CheckValidate()" ID="btnSoftSaveAs"
                            CssClass="btn" OnClick="btnSoftSaveAs_Click" />
                        &nbsp;&nbsp;
                        <input type="button" id="btnCancel" value="取 消" class="btn" onclick='javascript:history.back();' /><asp:Literal
                            ID="litMsg" runat="server"></asp:Literal></td>
                </tr>
            </tfoot>
        </table>
    </form>
</body>
</html>

<script language="javascript">
    var typeName='<%=ChannelModel.TypeName %>'
 //重名检测
function CheckTitle()
{
    var title=$('txtSoftName').value.trim();
   if(title.length==0)
   {
        alert("检测的"+typeName+"名称必须填写");
         $("txtSoftName").focus();
        return;
   } 
   var flag=CheckHas("../common/CheckHas.aspx",title,"Title","KyDownLoadData");
    if(flag)
        alert("该"+typeName+"名称已经存在"); 
     else
        alert("该"+typeName+"名称不存在");
} 
//标题类型
function SetTitleType(){
    if($("rbComm").checked)
     {
        ShowImgUrl.style.display="none";
        $('chkBoxIsSideShow').disabled=true;
     } 
    else
     {   ShowImgUrl.style.display="";$('chkBoxIsSideShow').disabled=false;}
}
   //平台选择
   function SetDownOS(OS)
   {
        var OSName=$("txtSoftOS");
        var OSStr = OSName.value.trim();
        var OSArray = null; 
        if(OSStr!="")
        {
             OSArray = OSStr.split('|');
             for(var i=0;i<OSArray.length;i++)
               {
                    if(OSArray[i]==OS)
                     {
                        return;
                     }
               }
               OSName.value+="|"+OS;
        } 
       else
       {
            OSName.value=OS;
       }
   }
//分隔关键字
function SepTagName()
{
    $("txtTagName").focus();
   if(document.selection)
   {
     var range=document.selection.createRange();
     range.text="|";
   } 
}

    //专题选择
   function btnSetToppicStr(val)
   {
        var lst1=$('lBoxSpecialIdStr');
        var length=lst1.options.length;
        var tt="";
        if(val=="ChooseAll")
        {
            for(var i=0;i<length;i++)
            {
                lst1.options[i].selected=true;
            }
        }
        else
        {
            for(var i=0;i<length;i++)
            {
                lst1.options[i].selected=false;
            }
        }
   }
//校验文本框的输入
   function CheckValidate()
   {

    var title=$('txtSoftName').value.trim();

        if(title.length==0)
        {   
             alert(""+typeName+"名称必须填写");
            $("txtSoftName").focus();  
             return false; 
        }
      if($('ddlColId').options[$('ddlColId').selectedIndex].style.backgroundColor.trim().length!=0)
       {
            alert("所选择的栏目不能添加"+typeName+"");
            return false;
       }
       if($("txtSoftPoint").value.trim().length==0)
       {
             alert("下载收取金币数必须填写");
            $("txtSoftPoint").focus();  
             return false;
       }
       if($('txtSoftRemark').value.trim().length==0)
      {
          alert(""+typeName+"简介必须填写");
         $('txtSoftRemark').focus(); 
         return false; 
      } 
       if(!CheckNumber($("txtSoftDownDayNum").value) || !CheckNumber($("txtSoftDownWeekNum").value) || !CheckNumber($("txtSoftDownMonthNum").value) || !CheckNumber($("txtSoftDownNum").value))
       {
             alert("请输入正确的浏览数");
            $('txtSoftDownDayNum').focus();  
             return false;
       }
        if($('AddressNum').value.length==0)
       {
            alert('请输入下载地址数');
            $('AddressNum').focus();
            return false;
       }
          var numAddress=$("AddressNum").value.trim()-0;
          for(var i=1;i<=numAddress;i++)
          {
                if($("txtAddressName_"+i).value.trim().length==0)
                {
                    alert("第"+i+"个下载地址名称必须填写");
                    $("txtAddressName_"+i).focus();
                    return false;
                }
                if($('txtSoftAddressPath_'+i).value.trim().length==0)
                {
                    alert("第"+i+"个下载地址路径必须填写");
                    $("txtSoftAddressPath_"+i).focus();
                    return false;
                }
          } 
           return true;
  }
   //根据栏目设置参数
   function OnLoadParam()
   {
        var softId;
        softId=<%=Id %>
        if(softId==0)
        {
            SetParam();
        }
    }

    function SetParam()
   {
        var data = XmlHttpPostMethodText("../Info/GetColumn.aspx","ColId="+$('ddlColId').value);
        if(data== "")
        {
            return; 
        }  
        else
        {
            var param = data.split('$');
            if(param.length==6)
           {  
            $('rdBtnPageType_'+(param[0]-1)).checked=true; 
            $('txtSoftTemplatePath').value = param[1];
            $('rdBtnChargeType'+param[2]).checked=true;
            $('txtChargeHourCount').value=param[3];
            $('txtChargeViewCount').value=param[4];
            $('txtSoftPoint').value=param[5]; 
           } 
        }   
   }
function SetCount()
{
    if($('AddressNum').value.length==0)
   {
        alert('请输入下载地址数');
        $('AddressNum').focus();
        return;
   }
  var n=$('AddressNum').value-0
   if(n<1  || n>10)
   {
       alert('下载地址数必须为1-10');
       $('AddressNum').focus(); 
       return;
   }
 
   var num=$('AddressNum').value
   ShowLoadCount(num,0);
}
//下载地址设置
function ReplaceTemplate(val,val1)
{
    return val.replace("txtAddressName","txtAddressName_"+val1).replace("下载地址","下载地址"+val1).replace("nmAddressName","nmAddressName_"+val1).replace("ddlDownServerID","ddlDownServerID_"+val1).replace("name=ddlDownServerID","name=ddlDownServerID_"+val1).replace("nmDownServerID","nmDownServerID_"+val1).replace("txtSoftAddressPath","txtSoftAddressPath_"+val1).replace("nmAddressPath","nmAddressPath_"+val1).replace("btnChoose","btnChoose_"+val1).replace("btnAddAddress","btnAddAddress_"+val1).replace("slt","slt"+val1).replace("item","item"+val1).replace("div_template","div_"+val1).replace("txtDLId","txtDLId_"+val1).replace("nmDLId","nmDLId_"+val1).replace("AddAddress('txtSoftAddressPath')","AddAddress('txtSoftAddressPath_"+val1+"')").replace("'txtAddressName'","'txtAddressName_"+val1+"'").replace("?'下载地址'","?'下载地址"+val1+"'");
}

function ShowLoadCount(num,isReturn)
{
//    alert("num="+num+"isReturn="+isReturn+"returnNUm"+<%=returnNum %>)
    var template =$("MyMain").innerHTML
   var currCount =parseInt($("txtTemplateNum").value); 
   var setCount =0;
   if(isReturn==0)
       setCount =$("AddressNum").value.trim()
    else 
        setCount=<%=returnNum %>

    if(currCount<setCount)
   {
        for(var i=currCount+1;i<=setCount;i++)
        {
            var item =ReplaceTemplate(template,i)
            $("showServerList").insertAdjacentHTML("beforeEnd",item);
            var count = $('txtTemplateNum').value
            $('txtTemplateNum').value = parseInt(count)+1;
        }
   }
   
    if(<%=returnNum %>!=0 && setCount<<%=returnNum %>)
    {
         return;
    }
   if(currCount>setCount)
   {
        for(var i=currCount;i>setCount;i--)
        {  
            $('div_'+i).outerHTML= '';
            var count = $('txtTemplateNum').value
            $('txtTemplateNum').value = parseInt(count)-1;
        }
   }
  var setNewCount=parseInt($("AddressNum").value);
   if(setNewCount>currCount && currCount!=0 && <%=returnNum %>!=0)
   {
       for(var i=currCount+1;i<=setNewCount;i++)
      {
        $('nmDLId_'+i).value=1;
      } 
  } 
}
function OnLoadAddress()
{
    if(<%=Id %>==0)
     {
        ShowLoadCount(1,0)
     }
    else
     { 
        var templateNum = <%=returnNum %>;
        ShowLoadCount(templateNum,1);
        $('AddressNum').value=templateNum
        
        var addressNameArray = new Array(<%=AddressName %>);
        var downServerIdArray=new Array(<%=DownServerId %>);
        var softAddressPathArray=new Array(<%=AddressPath %>);
        for(var i=1;i<=addressNameArray.length;i++)
        {
            $('txtAddressName_'+i).value=addressNameArray[i-1];
            $('ddlDownServerID_'+i).value=downServerIdArray[i-1];
            $('txtSoftAddressPath_'+i).value=softAddressPathArray[i-1];
        }
     }
}
function AddAddress(ControlId,FilePath)
{
WinOpenDialog("../../common/UpLoadSoft.aspx?ControlId="+ControlId+"&FilePath="+FilePath,400,180)
}
</script>

