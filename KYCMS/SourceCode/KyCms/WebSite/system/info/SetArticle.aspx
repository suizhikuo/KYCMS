<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetArticle.aspx.cs" Inherits="InfoManage_SetArticle" %>

<%@ Import Namespace="Ky.BLL" %>
<%@ Import Namespace="System.Data" %>
<%@ Register TagPrefix="FCKeditorV2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<html>
<head id="Head1" runat="server">
    <title>文章添加页面</title>
    <link href="../Css/default.css" rel="stylesheet" type="text/css" />

    <script src="../../JS/Common.js" type="text/javascript"></script>
   <script src="../../JS/RiQi.js" type="text/javascript"></script> 

    <script src="../../JS/XmlHttp.js" type="text/javascript"></script>

</head>
<body onload="OnloadParam();GetTitleType();SetHeader()">
    <iframe width="260" height="165" id="colorPalette" src="../../common/setcolor.htm"
        style="visibility: hidden; position: absolute; border: 1px gray solid; left: 2px;
        top: 1px;" frameborder="0" scrolling="no"></iframe>
    <table width="99%" border="0" cellpadding="0" cellspacing="0" class="wzdh" align="center">
        <tr>
            <td width="27">
                &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" /></td>
            <td>
                您现在的位置： <a href="../SystemInfo.aspx">后台管理</a> >> <a href="ChannelList.aspx">频道管理</a>
                &gt;&gt;
                <asp:Literal runat="server" ID="litNav"></asp:Literal></td>
            <td width="116" align="center">
                &nbsp;</td>
        </tr>
    </table>
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="1" class="border" align="center">
            <tr>
                <td class="bqleft" width="168">
                    <%=ChannelModel.TypeName%>类型:</td>
                <td class="bqright">
                    <asp:RadioButton ID="rbComm" runat="server" Checked="True" GroupName="TitleType"
                        Text="普通标题" onclick="SetTitleType(1)" />
                    <asp:RadioButton ID="rbImg" runat="server" GroupName="TitleType" Text="图片标题" onclick="SetTitleType(2)" />
                    <asp:CheckBox ID="rbOuter" onclick="SetIsOuter()" runat="server" Text="外部链接" />
                </td>
            </tr>
            <tr style="display: none" id="ShowOurterUrl">
                <td class="bqleft">
                    转向地址:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtOuterUrl" runat="server" Width="35%"></asp:TextBox>
                    <span class="red">* </span>输入<%=ChannelModel.TypeName %>的链接URL</td>
            </tr>
            <tr id="ShowImgUrl" style="display: none">
                <td class="bqleft">
                    图片地址:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtTitleImgPath" name="txtTitleImgPath" runat="server" Width="35%"
                        ReadOnly="True"></asp:TextBox>
                    <input id="btn" type="button" class="btn" value="浏览" onclick="WinOpenDialog('../../common/SelectPic.aspx?ControlId='+escape('txtTitleImgPath'),460,400)" />
                    <span class="red">* </span>
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                    <%=ChannelModel.TypeName %>标题:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtTitle" runat="server" Text='' Width="300px" MaxLength="200" CssClass=""></asp:TextBox><span
                        class="red">*</span>&nbsp;
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
                    <asp:CheckBox ID="IsShowCommentLink" runat="server" Text="标题旁评论"  Visible="false"/>
                    <input type="button" class="btn" value="<%=ChannelModel.TypeName %>标题重名检测" onclick="CheckTitle()" />
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                    副标题:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtLongTitle" runat="server" Text='' Width="300px" MaxLength="500"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="bqleft">
                    所属栏目:</td>
                <td class="bqright">
                    <select name="ddlColId" onchange="SetParam()">
                        <% 
                            DataTable dt = ColumnBll.GetFormatListItemByChannelId(ChannelId);

                            Response.Write("<option value=\"0\" selected>请选择栏目</option>");
                            foreach (DataRow dr in dt.Rows)
                            {
                                string colName = dr["ColName"].ToString();
                                int colId = Convert.ToInt32(dr["ColId"]);
                                bool flag = ColumnBll.ChkHasChildByColId(colId);

                                if ((flag && !ColumnBll.GetColumn(colId).IsAllowAddInfo) || !AdminGroupBll.Power_Channel(ChannelId, colId, AdminUserModel.GroupId, 2))
                                {

                                    if (ColumnId == colId)
                                        Response.Write("<option value=\"" + colId + "\" style=\"background-color:red\" selected>" + colName + "</option>");
                                    else
                                        Response.Write("<option value=\"" + colId + "\" style=\"background-color:red\">" + colName + "</option>");
                                }
                                else
                                {

                                    if (ColumnId == colId)
                                        Response.Write("<option value=\"" + colId + "\" selected>" + colName + "</option>");
                                    else
                                        Response.Write("<option value=\"" + colId + "\" >" + colName + "</option>");
                                }
                            }
                          
                        %>
                    </select>
                </td>
            </tr>
            <tr>
                <td class="bqleft">
                    TAG关键字:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtTagNameStr" runat="server" Text='' Width="50%" MaxLength="100"></asp:TextBox><span
                        class="tips"> 多个关键字用空格分开(每个关键字长度不能超过20个字)</span></td>
            </tr>
            <tr>
                <td class="bqleft">
                    <%=ChannelModel.TypeName %>作者:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtAuthor" runat="server" Text='' Width="35%" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="bqleft">
                    <%=ChannelModel.TypeName %>来源:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtSource" runat="server" Text='' Width="35%" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="bqleft">
                    属性设置:</td>
                <td class="bqright">
                    <asp:CheckBox ID="chkBoxIsRecommend" runat="server" Text="推荐" /><asp:CheckBox ID="chkBoxIsFocus"
                        runat="server" Text="焦点" /><asp:CheckBox ID="chkBoxIsHeader" runat="server" Text="头条"
                            onclick="SetHeader()" /><asp:CheckBox ID="chkBoxIsSideShow" runat="server" Text="幻灯" />
                    <asp:CheckBox ID="chkBoxIsTop" runat="server" Text="置顶" />
                    <asp:CheckBox ID="chkBoxIsIrregular" runat="server" Text="不规则<%=ChannelModel.TypeName %>" />
                    <asp:CheckBox ID="chkBoxIsAllowComment" runat="server" Text="允许评论" />&nbsp;
                    <asp:CheckBox ID="chkBoxIsCreate" runat="server" Text="发布" Checked="True" /></td>
            </tr>
            <tbody style="display: none" id="ShowHeaderProperty">
                <tr>
                    <td class="bqleft">
                        头条属性设置:</td>
                    <td class="bqright">
                        文字:<asp:TextBox ID="txtHeaderFont" runat="server" Rows="6" MaxLength="86"></asp:TextBox>
                        属性:<asp:DropDownList ID="ddlHeaderProPerty" runat="server">
                            <asp:ListItem Value="常规">常规</asp:ListItem>
                            <asp:ListItem Value="粗体">粗体</asp:ListItem>
                            <asp:ListItem Value="斜体">斜体</asp:ListItem>
                        </asp:DropDownList>
                        大小:<asp:DropDownList ID="ddlHeaderSize" runat="server">
                        </asp:DropDownList>
                        颜色:<asp:TextBox ID="txtHeaderColor" runat="server" Width="45px" Style="display: none"></asp:TextBox>
                        <span>
                            <img src="../../images/<%if(txtHeaderColor.Text=="") {%>rectNoColor.gif<%}else{%>rect.gif<%} %>"
                                width="18" height="17" border="0" align="absmiddle" id="HeaderColorShow" style="cursor: pointer;
                                background-color: #<%=txtHeaderColor.Text %>;" title="选取颜色!" onclick="GetColor($('HeaderColorShow'),'txtHeaderColor');" /></span>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        头条图片:</td>
                    <td class="bqright">
                        <input id="txtHeaderImgPath" runat="server" readonly="readOnly" style="width: 35%" />&nbsp;<input type="button"
                            runat="server" class="btn" value="浏览..." onclick="WinOpenDialog('../../common/SelectPic.aspx?ControlId='+escape('txtHeaderImgPath'),460,400)" />&nbsp;<input
                                type="button" class="btn" onclick="javascript:$('txtHeaderImgPath').value='';"
                                value="清除" />
                    </td>
                </tr>
            </tbody>
            <tr>
                <td class="bqleft">
                    <%=ChannelModel.TypeName %>导读:</td>
                <td class="bqright">
                    <asp:TextBox ID="txtShortContent" runat="server" Rows="6" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tbody id="ShowDefault">
            <tr>
                <td class="bqright" colspan="2">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr align="center">
                            <td id="TabTitle0" class="title6" onclick="ShowTabs(0)">
                                <%=ChannelModel.TypeName %>内容</td>
                            <td id="TabTitle1" class="title5" onclick="ShowTabs(1)">
                                所属专题</td>
                            <td id="TabTitle2" class="title5" onclick="ShowTabs(2)">
                                高级选项</td>
                            <td id="TabTitle3" class="title5" onclick="ShowTabs(3)">
                                收费选项</td>
                        </tr>
                    </table>
                </td>
            </tr>
            </tbody>
            <tbody id="Tabs0">
                <tr>
                    <td colspan="2">
                        <!--文章内容-->
                        <asp:TextBox ID="FilePicPath" runat="server" Text="fbangd" Style="display: none"></asp:TextBox>
                        <FCKeditorV2:FCKeditor ID="txtContent" runat="server" Height="300px">
                        </FCKeditorV2:FCKeditor>
                        <table cellpadding="0" cellspacing="1" border="0">
                            <tr>
                                <td align="left" width="500px">
                                    <asp:CheckBox ID="chkBoxRemoteSaveImage" runat="server" Text="开启远程存图功能" />（推荐在图片量比较小的情况下使用）<br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </tbody>
            <!--所属专题-->
            <tbody id="Tabs1" style="display: none">
                <tr>
                    <td class="bqleft">
                        所属专题：
                    </td>
                    <td class="bqright" style="height: 221px">
                        <asp:ListBox ID="lBoxTopicIdStr" runat="server" Height="173px" SelectionMode="Multiple"
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
            <!--高级选项-->
            <tbody id="Tabs2" style="display: none">
                <tr>
                    <td class="bqleft">
                        点 击 数：
                    </td>
                    <td class="bqright">
                        <asp:TextBox ID="txtHitCount" runat="server" Width="70px" MaxLength="10" onkeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;">0</asp:TextBox>
                        次<asp:TextBox ID="txtUpdateDateTime" runat="server" style="display: none"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        评分等级:</td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlStarLevel" runat="server">
                            <asp:ListItem Value="★">★</asp:ListItem>
                            <asp:ListItem Value="★★">★★</asp:ListItem>
                            <asp:ListItem Value="★★★" Selected="True">★★★</asp:ListItem>
                            <asp:ListItem Value="★★★★">★★★★</asp:ListItem>
                            <asp:ListItem Value="★★★★★">★★★★★</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        要求签收用户:</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtViewer" runat="server" Width="35%" MaxLength="100"></asp:TextBox>
                        <input id="btnAddViewer" class="btn" type="button" value="添 加" onclick="WinOpenDialog('../../Common/SelectViewer.aspx?ControlId='+escape('txtViewer')+'&FilePath=news',460,400)" />&nbsp;<input
                            type="button" value="清空" class="btn" onclick="javascript:$('txtViewer').value='';" />
                    </td>
                </tr>

                <tr>
                    <td class="bqleft">
                        添加时间：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtAddTime" runat="server" Width="15%"></asp:TextBox><span class='tips'>默认为当前时间！</span></td>
                </tr>

                <tr>
                    <td class="bqleft">
                        签收结束时间：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtViewEndTime" runat="server" Width="15%" onclick="setday(this)" onblur="setday(this)"></asp:TextBox><span class='tips'>当有签收用户时，此项为必填！</span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        模板路径:</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtTemplatePath" runat="server" Text="" Width="35%"></asp:TextBox>
                        <input type="button" value="选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtTemplatePath')+'&StartPath='+escape('/Template'),650,480)"
                            id="btnSelTemplate" class="btn" />
                        <span class="red">* </span>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        内容页扩展名:</td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="rdBtnPageType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">.html</asp:ListItem>
                            <asp:ListItem Value="2">.htm</asp:ListItem>
                            <asp:ListItem Value="3">.shtml</asp:ListItem>
                            <asp:ListItem Value="4">.aspx</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        归档时间：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtExpireTime" runat="server" Width="15%" onclick="setday(this)" onblur="setday(this)"></asp:TextBox>
                        <span class="red">* </span>
                    </td>
                </tr>
            </tbody>
            <!--收费选项-->
            <tbody id="Tabs3" style="display:none">
                <tr>
                    <td class="bqleft">
                        阅读收取金币数：
                    </td>
                    <td class="bqright">
                        <asp:TextBox ID="txtPointCount" runat="server" Width="70px" MaxLength="10" onkeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;">0</asp:TextBox><span
                            class="STYLE2"><span class="tips">阅读本文需要消耗多少<%=SiteModel.GUnitName%>金币</span></span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        阅读权限：</td>
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
                            runat="server" ID="txtChargeHourCount" Text="24" MaxLength="10" Width="82px"
                            onkeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox>小时后重新收费<br />
                        <asp:RadioButton ID="rdBtnChargeType3" runat="server" GroupName="ChargeType" />会员重复阅读此文章<asp:TextBox
                            runat="server" ID="txtChargeViewCount" Text="10" MaxLength="10" Width="70px"
                            onkeypress="if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox>
                        次后重新收费
                        <br />
                        <asp:RadioButton ID="rdBtnChargeType4" runat="server" GroupName="ChargeType" />上述两者都满足时重新收费<br />
                        <asp:RadioButton ID="rdBtnChargeType5" runat="server" GroupName="ChargeType" />上述两者任一个满足时就重新收费<br />
                        <asp:RadioButton ID="rdBtnChargeType6" runat="server" GroupName="ChargeType" />每阅读一次就重复收费一次（建议不要使用）
                    </td>
                </tr>
            </tbody>
        </table>
        <table width="100%" align="center" cellpadding="2" cellspacing="0">
            <tr>
                <td height="50" align="center"><asp:Button ID="btnAddNewsSave" runat="server" Text=" 保 存 " OnClick="AddNewsBtn_Click"
                CssClass="btn" OnClientClick="return CheckValidate()" />
            &nbsp;&nbsp;
            <input type="button" id="btnAddNewsCanCel" value=" 取 消 " class="btn" onclick='javascript:history.back();' />
            <asp:Literal ID="litMsg" runat="server"></asp:Literal></td>
            </tr>
        </table>
    </form>
</body>
</html>

<script type="text/javascript">
       var typeName='<%=ChannelModel.TypeName %>'
//检测的标题
function CheckTitle()
{
      var title = $("txtTitle").value.trim();
      if(title.length==0) 
      {
          alert("检测的"+typeName+"标题必须填写") ;
          return;
      } 
        var flag = CheckHas("../common/CheckHas.aspx",title,"Title","KyArticle")
        if(!flag)
        {
            alert("该"+typeName+"标题不存在"); 
        }  
        else
        {
             alert("该"+typeName+"标题已经存在"); 
        }   
}

 var elementCount = 0;
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

///文章类型是否外部链接
function SetIsOuter()
{
    if($('rbOuter').checked)
    {
       ShowOurterUrl.style.display=""; 
       ShowDefault.style.display="none";
       Tabs0.style.display="none";
       Tabs1.style.display="none";
       Tabs2.style.display="none";
       Tabs3.style.display="none";
    }
    else
    {
       ShowOurterUrl.style.display="none"; 
       ShowDefault.style.display="";
       Tabs0.style.display="";
       ShowTabs(0);
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



//校验文本框的输入
function CheckValidate()
{
   var patt=/\d{4}-\d{1,2}-\d{1,2}$/;
//   var pattUrl=/http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?/
   var title = $("txtTitle").value.trim();
   if(title.length==0)
   {
        alert(""+typeName+"标题必须填写");
        return false;
   }
   if($('ddlColId').value=="0")
   {
        alert("请选择栏目");
        return false;
   }
   if($('ddlColId').options[$('ddlColId').selectedIndex].style.backgroundColor.trim().length!=0)
   {
        alert("所选择的栏目不能添加/修改"+typeName+"");
        return false;
   }
   if($("rbOuter").checked)
   {
        if($("txtOuterUrl").value.trim().length==0)
        {
            alert(""+typeName+"的链接URL必须填写");
            return false;
        }
   } 
      if($("rbImg").checked)
   {
        if($("txtTitleImgPath").value.trim().length==0)
        {
            alert("图片地址必须填写");
            return false;
        }
   }
   if(!$("rbOuter").checked)
   {
          
           if($("txtPointCount").value.trim().length==0)
           {
                 alert("阅读收取金币数必须填写");
                return false;
           }
           if($("txtHitCount").value.trim().length==0)
           {
                 alert("点击数必须填写");
                return false;
           }

           if($("txtExpireTime").value.trim().length==0)
           {
                 alert("归档时间必须填写");
                return false;
           }
            if(!patt.test($("txtExpireTime").value.trim()))
            {
               alert("请输入正确的归档时间(2008-08-08)");
               return false;
            }
             if(!patt.test($("txtViewEndTime").value.trim()) && $("txtViewEndTime").value.trim()!="")
            {
               alert("请输入正确的签收结束时间(2008-08-08)");
               return false;
            }
            if($("txtTemplatePath").value.trim().length==0)
           {
                 alert("模板路径必须填写");
                return false;
           }      
            if($("rdBtnChargeType2").checked || $("rdBtnChargeType4").checked || $("rdBtnChargeType5").checked)
           {
                if($("txtChargeHourCount").value.trim()=="")
                {
                       alert("请输入距离上次收费时间");
                       return false;
                }
           } 
           if($("rdBtnChargeType3").checked || $("rdBtnChargeType4").checked || $("rdBtnChargeType5").checked)
            {
                if($("txtChargeViewCount").value.trim()=="")
                {
                       alert("请输入会员重复阅读此"+typeName+"后重新收费次数");
                       return false;
                }
            } 
   }
   if($('chkBoxIsHeader').checked)
   {
        if($('txtHeaderFont').value.trim().length==0)
        {
               alert("头条文字必须填写");
               return false;
        }
        if($('txtHeaderColor').value.trim().length==0)
        {
               alert("头条文字颜色必须选择");
               return false;
        }
   } 
          return true;
}

//获取文章类型
function GetTitleType()
{
    if($("rbComm").checked){
        ShowOurterUrl.style.display="none";
        ShowDefault.style.display="";
        ShowImgUrl.style.display="none";
         $('chkBoxIsSideShow').disabled=true;
    }
   else  if($("rbImg").checked){
         ShowImgUrl.style.display="";
         ShowOurterUrl.style.display="none";
          ShowDefault.style.display="";
          $('chkBoxIsSideShow').disabled=false; 
    }
     if($("rbOuter").checked)
     {
       SetIsOuter()
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
function OnloadParam()
{
   var articleId=<%=ArticleId %>;
   if(articleId==0)
   {
        SetParam();
   } 
}

function SetHeader()
{
    if($('chkBoxIsHeader').checked)
        ShowHeaderProperty.style.display="";
   else
        ShowHeaderProperty.style.display="none";
}


</script>

