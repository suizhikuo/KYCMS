<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddInfo.aspx.cs" Inherits="system_info_AddInfo" %>

<%@ Register Src="../../common/Linkage.ascx" TagName="Linkage" TagPrefix="uc1" %>

<%@ Import Namespace="Ky.BLL" %>
<%@ Import Namespace="System.Data" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/default.css" rel="stylesheet" type="text/css" />

    <script src="../../JS/XmlHttp.js" type="text/javascript"></script>

    <script src="../../JS/Common.js" type="text/javascript"></script>

    <script src="../../JS/RiQi.js" type="text/javascript"></script>

    <script src="../../JS/InfoModel.js" type="text/javascript"></script>

</head>
<body onload="SetParam();GetTitleType()">
    <form id="form1" runat="server">
   <iframe width="260" height="165" id="colorPalette" src="../../common/setcolor.htm" style="visibility: hidden; position: absolute; border: 1px gray solid; left: 2px; top: 1px;" frameborder="0" scrolling="no"></iframe>      
    <table width="99%" border="0" cellpadding="0" cellspacing="0" class="wzdh" align="center">
            <tr>
                <td width="27">
                    &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" /></td>
                <td>
                    您现在的位置： <a href="../SystemInfo.aspx">后台管理</a> >>
                    <asp:Literal runat="server" ID="litNav"></asp:Literal>
                    <uc1:Linkage ID="Linkage1" runat="server" />
                </td>
                <td width="116" align="center">
                    &nbsp;</td>
            </tr>
        </table>
      
       <TABLE cellSpacing="0" cellPadding="0" width="99%" align="center" border="0" class="cd">
            <tbody id="ShowDefault">
                <tr align="center">
                   <td id="TabTitle0" class="title6" onclick="ShowTabs(0)">基本信息</td>
                   <td id="TabTitle1" class="title5" onclick="ShowTabs(1)">所属专题</td>
                   <td id="TabTitle2" class="title5" onclick="ShowTabs(2)">高级选项</td>
                   <td id="TabTitle3" class="title5" onclick="ShowTabs(3)">收费选项</td>
                    <TD>&nbsp;</TD></tr></table>
         <table class="editborder" cellspacing="1" cellpadding="0" width="99%" border="0" align="center">
            <tbody id="Tabs0">
                <tr>
                    <td class="bqleft">
                        <asp:TextBox ID="FilePicPath" runat="server" Style="display: none">news</asp:TextBox>
                        <%=ChannelModel.TypeName%>类型：</td>
                    <td class="bqright">
                        <asp:RadioButton ID="rbComm" runat="server" Checked="True" GroupName="TitleType"
                            Text="普通标题" onclick="SetTitleType(1)" />
                        <asp:RadioButton ID="rbImg" runat="server" GroupName="TitleType" Text="图片标题" onclick="SetTitleType(2)" />
                    </td>
                </tr>
                <tr id="ShowImgUrl" style="display: none">
                    <td class="bqleft">
                        图片地址：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtTitleImgPath" name="txtTitleImgPath" runat="server" Width="265px"></asp:TextBox>
                        <input id="btn" type="button" class="btn" value=" 浏 览 " onclick="WinOpenDialog('../../common/SelectPic.aspx?ControlId='+escape('txtTitleImgPath')+'&FilePath=news',460,400)" />
                        <span class="red">* </span>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                         <%=ChannelModel.TypeName%>标题：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtTitle" runat="server" Text='' Width="35%" MaxLength="200"></asp:TextBox><span
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
                        <input type="button" class="btn" value="<%=ChannelModel.TypeName%>标题重名检测" onclick="CheckTitle('<%=TableName %>')" />
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        所属栏目：</td>
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

                                        if (ColumnId == colId)
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
                        TAG关键字：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtTagNameStr" runat="server" Text='' Width="361px" MaxLength="100"> </asp:TextBox>&nbsp;<span class="tips"> 多个关键字用空格分开(每个关键字长度不能超过20个字)</span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        属性设置：</td>
                    <td class="bqright">
                        <asp:CheckBox ID="chkBoxIsRecommend" runat="server" Text="推荐" /><asp:CheckBox ID="chkBoxIsFocus"
                            runat="server" Text="焦点" />
                        <asp:CheckBox ID="chkBoxIsTop" runat="server" Text="置顶" />
                        <asp:CheckBox ID="chkBoxIsSideShow" runat="server" Text="幻灯" />
                        <asp:CheckBox ID="chkBoxIsAllowComment" runat="server" Text="允许评论"/>&nbsp;
                        <asp:CheckBox ID="chkBoxIsCreate" runat="server" Text="发布" Checked="True" /></td>
                </tr>
                <asp:Literal ID="ModelHtml" runat="server"></asp:Literal></tbody><tbody id="Tabs1" style="display: none"><tr>
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
            <tbody id="Tabs2" style="display: none">
                <tr>
                    <td class="bqleft">
                        点 击 数：
                    </td>
                    <td class="bqright" colspan="3">
                        <asp:TextBox ID="txtHitCount" runat="server" Width="70px" MaxLength="10">0</asp:TextBox>
                        次</td>
                </tr>
                <tr>
                    <td class="bqleft">
                        模板路径：</td>
                    <td class="bqright" colspan="3">
                        <asp:TextBox ID="txtTemplatePath" runat="server" Text="" Width="35%"></asp:TextBox>
                        <input type="button" value="选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtTemplatePath')+'&StartPath='+escape('/Template'),650,480)"
                            id="btnSelTemplate" class="btn" />
                        <span class="red">* </span>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft">
                        内容页扩展名：</td>
                    <td class="bqright" colspan="3">
                        <asp:RadioButtonList ID="rdBtnPageType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">.html</asp:ListItem>
                            <asp:ListItem Value="2">.htm</asp:ListItem>
                            <asp:ListItem Value="3">.shtml</asp:ListItem>
                            <asp:ListItem Value="4">.aspx</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
            </tbody>
            <tbody id="Tabs3" style="display: none">
                <tr>
                    <td class="bqleft">
                        阅读收取金币数：
                    </td>
                    <td class="bqright">
                        <asp:TextBox ID="txtPointCount" runat="server" Width="70px" MaxLength="10">0</asp:TextBox><span
                            class="STYLE2">(阅读本文需要消耗多少<%=SiteModel.GUnitName%>金币)</span></td>
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
                            runat="server" ID="txtChargeHourCount" Text="24" MaxLength="10" Width="82px"></asp:TextBox>小时后重新收费<br />
                        <asp:RadioButton ID="rdBtnChargeType3" runat="server" GroupName="ChargeType" />会员重复阅读此文章<asp:TextBox
                            runat="server" ID="txtChargeViewCount" Text="10" MaxLength="10" Width="70px"></asp:TextBox>
                        次后重新收费
                        <br />
                        <asp:RadioButton ID="rdBtnChargeType4" runat="server" GroupName="ChargeType" />上述两者都满足时重新收费<br />
                        <asp:RadioButton ID="rdBtnChargeType5" runat="server" GroupName="ChargeType" />上述两者任一个满足时就重新收费<br />
                        <asp:RadioButton ID="rdBtnChargeType6" runat="server" GroupName="ChargeType" />每阅读一次就重复收费一次（建议不要使用）
                    </td>
                </tr>
            </tbody>
            <tr>
                <td height="50" class="bqleft">
                </td>
                <td class="bqright" align="center">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="Button2" runat="server" Text=" 保 存 " CssClass="btn" OnClick="Button2_Click" />
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                    <input id="Button3" type="button" value=" 取 消 " class="btn" onclick="window.history.back()" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
