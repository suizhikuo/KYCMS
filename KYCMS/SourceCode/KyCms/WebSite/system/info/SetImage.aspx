<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetImage.aspx.cs" Inherits="system_SetImage" %>
<%@ Import Namespace="Ky.Common" %>
<%@ Import Namespace="Ky.BLL" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设置图片</title>
    <link href="../Css/default.css" rel="stylesheet" type="text/css" />

    <script src="../../JS/Common.js" type="text/javascript"></script>

    <script src="../../JS/XmlHttp.js" type="text/javascript"></script>


    <script type='text/javascript'>
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
</script>

</head>
<body onload="OnloadParam();HideProperty_3();">
    <form id="form1" runat="server">
        <iframe width="260" height="165" id="colorPalette" src="../../common/setcolor.htm"
            style="visibility: hidden; position: absolute; border: 1px gray solid; left: 661px;
            top: 490px;" frameborder="0" scrolling="no"></iframe>
        <table align="center" border="0" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
            <tr>
                <td width="27">
                    &nbsp;<img height="16" src="../images/skin/default/you.gif" width="17" /></td>
                <td>
                    您现在的位置： <a href="../SystemInfo.aspx">后台管理</a> >>
                    <asp:Literal runat="server" ID="litNav"></asp:Literal></td>
                <td align="center" width="116">
                    &nbsp;</td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" width="99%" align="center" class="cd">
            <tr align="center">
                <td id="TabTitle0" class="title6" onclick="ShowTabs(0)">
                    图片内容</td>
                <td id="TabTitle1" class="title5" onclick="ShowTabs(1)">
                    所属专题</td>
                <td id="TabTitle2" class="title5" onclick="ShowTabs(2)">
                    收费选项</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="1" class="editborder"
            width="99%">
            <tbody id="Tabs0">
                <tr>
                    <td class="bqleft">
                        标题类型：</td>
                    <td class="bqright">
                        <asp:RadioButton ID="rbTextTitle" runat="server" Text="文字标题" GroupName="TitleType"
                            Checked="true" onclick="SetPicTitle(1);$('TitleImgPath').style.display='none';$('property_3').disabled='disabled'"  /><asp:RadioButton ID="rbPicTitle" runat="server"
                                Text="图片标题" GroupName="TitleType" onclick="SetPicTitle(2);$('TitleImgPath').style.display='';$('property_3').disabled=''" /></td>
                </tr>
                <tr style="display: none;" id="TitleImgPath" runat="server">
                    <td class="bqleft">
                        图片标题路径：
                    </td>
                    <td class="bqright">
                        <asp:TextBox ID="txtPicTitlePath" runat="server" Width="35%"></asp:TextBox>
                        <input id="btnSelectImgPath" class="btn" type="button" value="选择图片" onclick="WinOpenDialog('../../common/SelectPic.aspx?ControlId=txtPicTitlePath',500,400)" /><span
                            style="color: #ff0000">*<asp:TextBox ID="FilePicPath" runat="server" style="display:none"></asp:TextBox></span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        标题：
                    </td>
                    <td class="bqright">
                        <asp:TextBox ID="txtTitle" runat="server" MaxLength="50" Width="35%"></asp:TextBox>
                        <input id="btnCheckTitle" type="button" value="重名检测" class="btn" onclick="CheckTitle();" /><span
                            style="color: #ff0000">* </span><span style="color: #000000; background-color: #e6e6e6">
                                <asp:DropDownList ID="ddlFontType" runat="server">
                                    <asp:ListItem Value="0">常规</asp:ListItem>
                                    <asp:ListItem Value="1">粗体</asp:ListItem>
                                    <asp:ListItem Value="2">斜体</asp:ListItem>
                                </asp:DropDownList></span><span style="display: none"><asp:TextBox ID="txtHeaderColor"
                                    runat="server" MaxLength="7" Width="50px"></asp:TextBox></span>
                        <img id="HeaderColorShow" align="absMiddle" border="0" height="17" onclick="GetColor($('HeaderColorShow'),'txtHeaderColor');"
                            src='../../images/<%if(txtHeaderColor.Text=="") {%>rectNoColor.gif<%}else{%>rect.gif<%} %>'
                            style="cursor: pointer; background-color: #<%=txtHeaderColor.Text %>;" title="选取颜色!"
                            width="18" />
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        所属栏目：</td>
                    <td class="bqright">
                        <select name="ddlColumn" onchange="SetParam()">
                            <% 
                                DataTable dt = ColumnBll.GetFormatListItemByChannelId(ChannelId);
                                if (dt == null || dt.Rows.Count == 0)
                                {
                                    Function.ShowSysMsg(0, "<li>本频道下没有栏目，不能添加信息</li><li>建议您先添加栏目</li><li><a href='info/SetColumn.aspx?ChId=" + ChannelId + "'>添加栏目</a> <a href='info/ColumnList.aspx?ChId=" + ChannelId + "'>栏目管理</a></li>");
                                }
                                Response.Write("<option value=\"-1\" selected>请选择栏目</option>");
                                foreach (DataRow dr in dt.Rows)
                                {
                                    string colName = dr["ColName"].ToString();
                                    int colId = Convert.ToInt32(dr["ColId"]);
                                    bool flag = ColumnBll.ChkHasChildByColId(colId);

                                    if ((flag && !ColumnBll.GetColumn(colId).IsAllowAddInfo) ||  !AdminGroupBll.Power_Channel(ChannelId, colId, AdminUserModel.GroupId, 2))
                                    {

                                        if (ColId == colId)
                                        {
                                            Response.Write("<option value=\"" + colId + "\" style=\"background-color:red\" selected>" + colName + "</option>");
                                        }
                                        else
                                        {
                                            Response.Write("<option value=\"" + colId + "\" style=\"background-color:red\">" + colName + "</option>");
                                        }
                                    }
                                    else
                                    {

                                        if (ColId == colId)
                                        {
                                            Response.Write("<option value=\"" + colId + "\" selected>" + colName + "</option>");
                                        }
                                        else
                                        {
                                            Response.Write("<option value=\"" + colId + "\" >" + colName + "</option>");
                                        }
                                    }
                                }
                          
                            %>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        属性：</td>
                    <td class="bqright">
                        <asp:CheckBoxList ID="property" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">推荐</asp:ListItem>
                            <asp:ListItem Value="1">置顶</asp:ListItem>
                            <asp:ListItem Value="1">焦点</asp:ListItem>
                            <asp:ListItem Value="1">幻灯</asp:ListItem>
                            <asp:ListItem Value="1">允许评论</asp:ListItem>
                            <asp:ListItem Value="1" Selected="True">发布</asp:ListItem>
                        </asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        已上传图片(<asp:Label ID="countImg" ForeColor="red" Text="0" runat="server"></asp:Label>)：</td>
                    <td class="bqright">
                        <asp:ListBox ID="imgs" runat="server" Height="94px" Width="35%" SelectionMode="Multiple">
                        </asp:ListBox>
                        <br />
                        <input type="button" value="选择图片" class="btn" id="btnShowWindow" onclick="ImgHandler('OpenWindow')" />
                        <input id="btnViewImg" type="button" class="btn" value="查看" onclick="ImgHandler('View');" />
                        <input id="btnDelImg" class="btn" type="button" value="删除" onclick="ImgHandler('Delete')" /></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        描述：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Height="94px" Width="60%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        TAG关键字：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtTagNameStr" runat="server" MaxLength="300" Width="35%"></asp:TextBox>
                        <span class="tips"> 多个关键字用空格分开(每个关键字长度不能超过20个字)</span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        模板路径 ：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtTemplatePath" runat="server" Enabled="true" Width="35%"></asp:TextBox>
                        <input id="btnSelTemplate" class="btn" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtTemplatePath')+'&StartPath='+escape('/Template'),650,480)"
                            type="button" value="选择模板" /></td>
                </tr>

                <tr>
                    <td class="bqleft">
                        添加时间：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtAddTime" runat="server" Width="15%" ></asp:TextBox><span class='tips'>默认为当前时间！</span></td>
                </tr>

                <tr>
                    <td class="bqleft">
                        点击次数：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtHitCount" runat="server" Width="23px">0</asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        页面类型：</td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="rblPageType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="html" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="htm" Value="2"></asp:ListItem>
                            <asp:ListItem Text="shtml" Value="3"></asp:ListItem>
                            <asp:ListItem Text="aspx" Value="4"></asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
            </tbody>
            <tbody id="Tabs1" style="display: none;">
                <tr>
                    <td class="bqleft">
                        所属专题：
                    </td>
                    <td class="bqright">
                        <asp:ListBox ID="lBoxTopicIdStr" runat="server" Height="94px" SelectionMode="Multiple"
                            Width="35%"></asp:ListBox>
                        <br />
                        <input id="btnSelectSpecls" class="btn" type="button" value="选定所有专题" onclick="selectSpecls('select');" />
                        <input id="btnCancleSelect" class="btn" type="button" value="取消选定的专题" onclick="selectSpecls('cancelS');" /></td>
                </tr>
            </tbody>
            <tbody id="Tabs2" style="display: none;">
                <tr>
                    <td class="bqleft">
                        收费金币个数：
                    </td>
                    <td class="bqright">
                        <asp:TextBox ID="txtPointCount" runat="server" Width="23px">0</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        阅读权限：</td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="rblIsOpened" runat="server">
                            <asp:ListItem Selected="True" Value="2">继承栏目权限（当所属栏目为认证栏目时，建议选择此项）</asp:ListItem>
                            <asp:ListItem Value="1">开放（当所属栏目为开放栏目，想单独对某些文章进行阅读权限设置，可以选择此项）</asp:ListItem>
                            <asp:ListItem Value="0">认证（当所属栏目为开放栏目，想单独对某些文章进行阅读权限设置，可以选择此项）</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:CheckBoxList ID="UserGroup" runat="server" RepeatDirection="Horizontal">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        重复收费方式：</td>
                    <td class="bqright">
                        <asp:RadioButton ID="rdBtnChargeType1" runat="server" Checked="True" GroupName="ChargeType" />不重复收费<br />
                        <asp:RadioButton ID="rdBtnChargeType2" runat="server" GroupName="ChargeType" />距离上次收费时间<asp:TextBox
                            ID="txtChargeHourCount" runat="server" MaxLength="10" Text="24" Width="23px"></asp:TextBox>小时后重新收费<br />
                        <asp:RadioButton ID="rdBtnChargeType3" runat="server" GroupName="ChargeType" />会员重复阅读此文章<asp:TextBox
                            ID="txtChargeViewCount" runat="server" MaxLength="10" Text="10" Width="23px"></asp:TextBox>
                        次后重新收费
                        <br />
                        <asp:RadioButton ID="rdBtnChargeType4" runat="server" GroupName="ChargeType" />上述两者都满足时重新收费<br />
                        <asp:RadioButton ID="rdBtnChargeType5" runat="server" GroupName="ChargeType" />上述两者任一个满足时就重新收费<br />
                        <asp:RadioButton ID="rdBtnChargeType6" runat="server" GroupName="ChargeType" />每阅读一次就重复收费一次（建议不要使用）
                    </td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td class="bqleft">
                    </td>
                    <td class="bqright">
                        <asp:Button ID="btnAdd" runat="server" Text="添加" CssClass="btn" OnClientClick="ImgHandler('Select');return chkInput();"
                            OnClick="btnAdd_Click" />&nbsp;<input type="button" class="btn" value="取消" onclick="history.back();" />
                    </td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>

<script type="text/javascript">
function HideProperty_3()
{
    if($("rbTextTitle").checked)
    { 
        $('property_3').disabled='disabled';
    } 
}
function SetPicTitle(type)
{
    if(type==1)
    {
        $('TitleImgPath').style.display='none';$('property_3').disabled='disabled';$('property_3').checked='';
    }
    if(type==2)
    {
        $('TitleImgPath').style.display='';$('property_3').disabled='';
    }
}
var spcls=$("lBoxTopicIdStr");
function SetParam()
{
    var data = XmlHttpPostMethodText("GetColumn.aspx","ColId="+$('ddlColumn').value);
    if(data== "")
    {
        return; 
    }  
    else
    {
        var param = data.split('$');
        if(param.length==7)
       {  
            $('rblPageType_'+(param[0]-1)).checked=true; 
            $('txtTemplatePath').value = param[1];
            $('rdBtnChargeType'+param[2]).checked=true;
            $('txtChargeHourCount').value=param[3];
            $('txtChargeViewCount').value=param[4];
            $('txtPointCount').value=param[5];
            if(param[6]=="True")
            {
                $('property_4').checked=true;
            }
       } 
    }   
}
function OnloadParam()
{
   var imgId=<%=ImgId %>;
   if(imgId==0)
   {
        SetParam();
   } 
}
function selectSpecls(type)
{    
    for(var i=0;i<spcls.length;i++)
   {
        if(type=="select")
        {
        spcls.options[i].selected=true;
        }
        else if(type=="cancelS")
        {
            spcls.options[i].selected=spcls.options[i].selected==true?false:false;
        }
   } 
}
//检测的短标题
function CheckTitle()
{
      var title = $("txtTitle").value.trim();
      if(title.length==0) 
      {
          alert('检测的文章标题必须填写') ;
          return;
      } 

            var flag = CheckHas("../common/CheckHas.aspx",title,"Title","KyImage")
            if(!flag)
            {
                alert("恭喜!该标题可以使用"); 
            }  
            else
            {
                 alert("该标题已经存在"); 
            }   
}
function ImgHandler(type)
{
    var obj=$("imgs");
   if(type=="View"&&obj.options.selectedIndex>-1)
   {
       try
       {
        window.showModalDialog('UploadImg.aspx?type=View&img='+obj.options[obj.options.selectedIndex].value);
        }
        catch(e)//Firefox
        {
            window.open('UploadImg.aspx?type=View&img='+obj.options[obj.options.selectedIndex].value,'name','modal=yes');
        }
   }
   if(type=="OpenWindow")
   {
        window.open('UploadImg.aspx','','width=700,height=170')
   }
   if(type=="Delete"&&obj.options.selectedIndex>-1)
   {
       try
       {
            obj.options.remove(obj.options.selectedIndex);
            document.getElementById("countImg").innerText=obj.options.length; 
        }
        catch(e)//Firefox
        {
            obj.remove(obj.options.selectedIndex);
            document.getElementById("countImg").innerText=obj.options.length;  
        }
   }
   if(type=="Select"&&obj.options.length>0)
   {
     for( var i=0;i<obj.options.length;i++)
     {
             obj.options[i].selected=true;
     }
   }
}
function chkInput()
{
    var column=$('ddlColumn');
    if($('txtTitle').value=='')
   {
        alert('请输入标题');
        return false;
   } 
   if(column.options[column.selectedIndex].value=="-1")
   {
        alert('请选择栏目');
        return false;
   }
   if(!CheckNumber($('txtHitCount').value))
   {
        alert('点击次数不正确.请修改');
        return false;
   }
   if(!CheckNumber($('txtPointCount').value))
   {
        alert('收费金币个数不正确,请修改');
        return false;
   }
   if($('rdBtnChargeType2').checked&&(!CheckNumber($('txtChargeHourCount').value)))
   {
        alert('收费时间不正确,请修改');
        return false;
   }
    if($('rdBtnChargeType3').checked&&(!CheckNumber($('txtChargeViewCount').value)))
   {
        alert('重复阅读收费不正确,请修改');
        return false;
   }
   if($('rbPicTitle').checked && $('txtPicTitlePath').value=="")
   {
        alert('请选择设置图片标题路径');
        return false;
   }
   if($('imgs').options.length==0)
   {
        return confirm('未上传任何图片,是否继续?');
   }
   return true;
}
</script>

