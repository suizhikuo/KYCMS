<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MassSetInfo.aspx.cs" Inherits="System_news_MassSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>批量修改文章属性</title>
    <link href="../Css/Default.css" rel="stylesheet" type="text/css" />

    <script src="../../JS/Common.js" type="text/javascript"></script>

    <script src="../../JS/XmlHttp.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="border" style="width: 99%">
            <div class="title tc">
                <strong>批量修改文章属性</strong></div>
            <div class="fl" style="width: 30%">
                <strong>文章范围<br />
                    <asp:RadioButton ID="rdBtnByArticleIdStr" runat="server" Checked="true" GroupName="Left"
                        Text="指定文章ID" />：<asp:TextBox ID="txtByArticleIdStr" runat="server" onkeyup="value=value.replace(/[^,\d]/g,'')"
                            Width="203px" MaxLength="500"></asp:TextBox><br />
                    <asp:RadioButton ID="rdBtnByColumnIdStr" runat="server" GroupName="Left" Text="指定栏目的文章" /><br />
                    <asp:ListBox ID="lsbColumnLeft" runat="server" Height="420px" SelectionMode="Single"
                        Width="100%"></asp:ListBox></strong></div>
            <div class="fl">
                <table cellspacing="0" cellpadding="0" width="99%" align="center" border="0" class="cd">
                    <tbody>
                        <tr align="center">
                            <td id="TabTitle0" class="title6" onclick="ShowTabs(0)">
                                属性设置</td>
                            <td id="TabTitle1" class="title5" onclick="ShowTabs(1)">
                                收费选项</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </tbody>
                </table>
                <table cellpadding="0" cellspacing="1" class="border" align="center" style="margin-top: 0px">
                    <tbody id="Tabs0">
                        <tr>
                            <td class="bqleft" style="width: 5%; text-align: center">
                                <asp:CheckBox ID="chkBoxPropterty1" runat="server" /></td>
                            <td class="bqleft" style="width: 113px">
                                关键字：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtTagNameStr" runat="server" MaxLength="100" Width="316px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bqleft" style="width: 5%; text-align: center">
                                <asp:CheckBox ID="chkBoxPropterty2" runat="server" /></td>
                            <td class="bqleft" style="width: 113px">
                                推荐设置：</td>
                            <td class="bqright">
                                <asp:CheckBox ID="chkBoxIsRecommend" runat="server" Text="推荐" />
                            </td>
                        </tr>
                        <tr>
                            <td class="bqleft" style="width: 5%; text-align: center">
                                <asp:CheckBox ID="chkBoxPropterty3" runat="server" /></td>
                            <td class="bqleft" style="width: 113px">
                                焦点设置:</td>
                            <td class="bqright">
                                <asp:CheckBox ID="chkBoxIsFocus" runat="server" Text="焦点" /></td>
                        </tr>
                        <tr>
                            <td class="bqleft" style="width: 5%; text-align: center">
                                <asp:CheckBox ID="chkBoxPropterty4" runat="server" /></td>
                            <td class="bqleft" style="width: 113px">
                                置顶设置：</td>
                            <td class="bqright">
                                <asp:CheckBox ID="chkBoxIsTop" runat="server" Text="置顶" />
                            </td>
                        </tr>
                        <tr>
                            <td class="bqleft" style="width: 5%; text-align: center">
                                <asp:CheckBox ID="chkBoxPropterty5" runat="server" /></td>
                            <td class="bqleft" style="width: 113px">
                                模板路径:</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtTemplatePath" runat="server" Text="" Width="361px"></asp:TextBox>
                                <input type="button" value="选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtTemplatePath')+'&StartPath='+escape('/Template'),650,480)"
                                    id="btnSelTemplate" class="btn" />
                            </td>
                        </tr>
                        <tr>
                            <td class="bqleft" style="width: 5%; text-align: center">
                                <asp:CheckBox ID="chkBoxPropterty6" runat="server" /></td>
                            <td class="bqleft" style="width: 113px">
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
                            <td class="bqleft" style="width: 5%; text-align: center">
                                <asp:CheckBox ID="chkBoxPropterty7" runat="server" /></td>
                            <td class="bqleft" style="width: 113px">
                                点 击 数：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtHitsCount" runat="server" onkeyup="value=value.replace(/[^\d]/g,'')"
                                    MaxLength="10" Width="70px"></asp:TextBox></td>
                        </tr>
                    </tbody>
                    <tbody id="Tabs1" style="display: none">
                        <tr>
                            <td class="bqleft" style="width: 5%; text-align: center">
                                &nbsp;<asp:CheckBox ID="chkBoxPropterty8" runat="server" /></td>
                            <td class="bqleft" style="width: 113px">
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
                            <td class="bqleft" style="width: 5%; text-align: center">
                                <asp:CheckBox ID="chkBoxPropterty9" runat="server" /></td>
                            <td class="bqleft" style="width: 113px">
                                重复收费方式：</td>
                            <td class="bqright">
                                <asp:RadioButton ID="rdBtnChargeType1" runat="server" Checked="True" GroupName="ChargeType" />不重复收费<br />
                                <asp:RadioButton ID="rdBtnChargeType2" runat="server" GroupName="ChargeType" />距离上次收费时间<asp:TextBox
                                    runat="server" ID="txtChargeHourCount" Text="24" onkeyup="value=value.replace(/[^\d]/g,'')"
                                    MaxLength="10" Width="82px"></asp:TextBox>小时后重新收费<br />
                                <asp:RadioButton ID="rdBtnChargeType3" runat="server" GroupName="ChargeType" />会员重复阅读此文章<asp:TextBox
                                    runat="server" ID="txtChargeViewCount" Text="10" onkeyup="value=value.replace(/[^\d]/g,'')"
                                    MaxLength="10" Width="70px"></asp:TextBox>
                                次后重新收费
                                <br />
                                <asp:RadioButton ID="rdBtnChargeType4" runat="server" GroupName="ChargeType" />上述两者都满足时重新收费<br />
                                <asp:RadioButton ID="rdBtnChargeType5" runat="server" GroupName="ChargeType" />上述两者任一个满足时就重新收费<br />
                                <asp:RadioButton ID="rdBtnChargeType6" runat="server" GroupName="ChargeType" />每阅读一次就重复收费一次（建议不要使用）
                            </td>
                        </tr>
                        <tr>
                            <td class="bqleft" style="width: 5%; text-align: center">
                                <asp:CheckBox ID="chkBoxPropterty10" runat="server" /></td>
                            <td class="bqleft" style="width: 113px">
                                收取金币个数：</td>
                            <td class="bqright">
                                <asp:TextBox ID="txtPointCount" runat="server" Width="70px" Text="0" onkeyup="value=value.replace(/[^\d]/g,'')"
                                    MaxLength="10"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <table>
                <tr>
                    <td>
                        <strong>说明:</strong></td>
                    <td>
                        1、若要批量修改某个属性的值，请先选中其左侧的复选框，然后再设定属性值。</td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        2、这里显示的属性值都是系统默认值，与所选文章的已有属性无关</td>
                </tr>
            </table>
        </div>
        <div class="tc">
            <asp:Button runat="server" Text="执行批处理" ID="btnMassSet" CssClass="btn" OnClick="btnMassSet_Click" />
            <input type="button" id="btnCancel" value="取 消" class="btn" onclick='javascript:history.back();' /><asp:Literal
                ID="litMsg" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
