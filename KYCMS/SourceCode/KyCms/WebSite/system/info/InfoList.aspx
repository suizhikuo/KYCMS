<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoList.aspx.cs" Inherits="System_InfoList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head id="Head1" runat="server">
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />
    <title>内容管理列表</title>

    <script type="text/javascript" src="../../js/XmlHttp.js"></script>

    <script type="text/javascript" src="../../js/Common.js"></script>

    <script type="text/javascript">
    var gvElement = 'gvInfoList'
function SetCheckBox()
{
   if($(gvElement)!=null)
   {
       var s=$(gvElement).getElementsByTagName("INPUT")
        for(var i=0;i<s.length;i++)
        {
            if(s[i].type=="checkbox")
            {
                s[i].checked=$("chkBoxChooseAll").checked;
            }
        }
    }
}
function IsSelectedId()
{ 
    var flag = false;
    if($(gvElement)==null)
     {
      return flag;
     }
    var s = $(gvElement).getElementsByTagName("INPUT")
    
    for(var i=0;i<s.length;i++)
    {
        if(s[i].type=="checkbox")
        {
            if(s[i].checked)
            {
                flag = true; 
                break;
            } 
        }
    }
   return flag; 
}
    </script>

</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnGoSearch" defaultfocus="txtKeyword">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27" height="24">
                    &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" alt="您所在的位置" /></td>
                <td>
                    您现在的位置：<a href='../SystemInfo.aspx'>后台管理</a> >>
                    <asp:Literal runat="server" ID="litNav"></asp:Literal></td>
                <td width="116" align="center">
                    &nbsp;</td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td style="width: 60%;" align="left">
                    &nbsp;<asp:HyperLink ID="hyperGetAll" runat="server">频道<%=ChannelModel.TypeName %>列表</asp:HyperLink>
                    |
                    <asp:HyperLink ID="hyperSetInfo" runat="server">添加<%=ChannelModel.TypeName %></asp:HyperLink><img src="../images/comment_add.gif" border="0" align="absmiddle" />
                    |
                    <asp:HyperLink ID="hyperPass" runat="server" Text="已审核"></asp:HyperLink>
                    |
                    <asp:HyperLink ID="hyperNoPass" runat="server" Text="未审核"></asp:HyperLink>
                    |
                    <asp:HyperLink ID="hyperUserType" runat="server" Text="投稿"></asp:HyperLink>
                </td>
                <td style="width: 40%;" align="center">
                    <asp:LinkButton ID="lkBtnIsTop" runat="server" Text="置顶" CommandName="IsTop" OnClick="ShowSearchResult"></asp:LinkButton>
                    |
                    <asp:LinkButton ID="lkBtnIsRecommend" runat="server" Text="推荐" CommandName="IsRecommend"
                        OnClick="ShowSearchResult"></asp:LinkButton>
                    |
                    <asp:LinkButton ID="lkBtnIsFocus" runat="server" Text="焦点" CommandName="IsFocus"
                        OnClick="ShowSearchResult"></asp:LinkButton>
                    |
                    <asp:LinkButton ID="lkBtnIsHot" runat="server" Text="热点" CommandName="IsHot" OnClick="ShowSearchResult"></asp:LinkButton>
                    |
                    <asp:LinkButton ID="lkBtnIsSideShow" runat="server" Text="幻灯" CommandName="IsSideShow"
                        OnClick="ShowSearchResult"></asp:LinkButton>
                    |
                    <asp:LinkButton ID="lkBtnIsImg" runat="server" Text="图片" CommandName="IsImg" OnClick="ShowSearchResult"></asp:LinkButton>
                </td>
                <td>
                    <asp:DropDownList ID="ddlChannel" runat="server" OnSelectedIndexChanged="ddlChannel_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList></td>
            </tr>
        </table>
        <asp:GridView ID="gvInfoList" runat="server" AutoGenerateColumns="False" Width="99%"
            CssClass="border" align="center" OnRowDataBound="gvInfoList_RowDataBound" OnRowDeleting="gvInfoList_RowDeleting"
            DataKeyNames="Id" CellSpacing="1" GridLines="None" OnRowCommand="gvInfoList_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="全选">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkBoxChooseInfo" runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="32px" CssClass="tc" />
                    <HeaderTemplate>
                        <asp:Label ID="lbChooseAll" runat="server" Text="全选"></asp:Label>
                    </HeaderTemplate>
                    <HeaderStyle CssClass="title" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%# InfoTitle(Eval("ColName"), Eval("Title"), Eval("ColId"), Eval("Id"), Eval("UName"))%>
                    </ItemTemplate>
                    <ItemStyle CssClass="tl wrap" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="点击数" DataField="HitCount">
                    <ItemStyle Width="40px" CssClass="tc" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="属 性">
                    <ItemTemplate>
                        <%# ChangePropertyDisplay(Eval("IsTop"),Eval("IsRecommend"),Eval("IsFocus"),Eval("HitCount"),Eval("IsSideShow"),Eval("TitleType")) %>
                    </ItemTemplate>
                    <ItemStyle Width="150px" CssClass="tc" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="审核状态">
                    <ItemTemplate>
                        <asp:Label ID="lbStatus" runat="server" Text='<%# ChangeStatus(Eval("Status")) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="tc" Width="60px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="生成">
               <ItemStyle Width="30px" CssClass="tc" /> 
                    <ItemTemplate>
                        <%#(bool)Eval("IsCreated") ? "√" : "×"%>
                    </ItemTemplate> 
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="常规管理操作" ShowHeader="False">
                    <ItemTemplate>
                        &nbsp; <a href='../preview/PreInfo.aspx?ModelId=<%=ChannelModel.ModelType %>&Id=<%#Eval("Id") %>' target="_blank">预览</a>
                        <a href='<%#GetInfoUrl(Eval("Id"),Eval("ColId")) %>'>修改</a>
                        <asp:LinkButton ID="lkBtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="删除" OnClientClick="return confirm('你确定将该数据删除到回收站吗？')"></asp:LinkButton>
                        <asp:LinkButton ID="lkBtnSetTop" runat="server" CausesValidation="False" CommandArgument='<%# SetIsTopCA(Eval("IsTop")+"|"+Eval("Id")) %>'
                            Text='<%# SetIsTopText(Eval("IsTop")) %>' CommandName="setIsTop"></asp:LinkButton>
                        <asp:LinkButton ID="lkBtnSetRecommend" runat="server" CausesValidation="False" Text='<%#SetIsRecommendText(Eval("IsRecommend")) %>'
                            CommandArgument='<%# SetIsRecommendCA(Eval("IsRecommend")+"|"+Eval("Id")) %>'
                            CommandName="setIsRecommend"></asp:LinkButton>
                        <asp:LinkButton ID="lkBtnExitInfo" runat="server" Text='<%# ExitInfoText(Eval("Status"),Eval("UserType")) %>'
                            CommandArgument='<%# Eval("Id") %>' CommandName="ExitInfo" CausesValidation="False" OnClientClick="javascript:return confirm('你确定退稿吗？')">退稿</asp:LinkButton>
						<asp:LinkButton ID="lkBtnAnomaly" runat="server" CommandArgument='<%# Eval("Id")+"┃"+Eval("Title") %>' CommandName="Anomaly">设为不规则</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="250px" CssClass="tl" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="title" Width="20px" />
            <PagerStyle CssClass="tc" />
            <RowStyle CssClass="tdbg" />
        </asp:GridView>
        <div style="padding-left: 5px">
            &nbsp;&nbsp;<input type='checkbox' onclick="SetCheckBox()" id="chkBoxChooseAll" /><label
                for="chkBoxChooseAll">全选</label>
        </div>
        <table cellpadding='0' cellspacing='0' border='0' align="center">
            <tr>
                <td>
                    <div id="dvCreateSelectInfo" runat="server" style="float: left">
                        <asp:Button ID="btnCreateSelectInfo" runat="server" CssClass="btn" OnClick="btnCreateSelectInfo_Click"
                            OnClientClick="if(!IsSelectedId()){alert('请选择生成项');return false;}else{return confirm('你确定要生成所有选中的内容吗？')}" />&nbsp;</div>
                    <div id="dvCreateColumn" runat="server" style="float: left">
                        <asp:Button ID="btnCreateColumn" runat="server" CssClass="btn" OnClick="btnCreateColumn_Click"
                            OnClientClick="return confirm('你确定要生成本栏目所有内容吗？')" />&nbsp;</div>
                    <div id="dvAudit" runat="server" style="float: left">
                        <asp:Button ID="btnAudit" runat="server" CssClass="btn" OnClick="btnAudit_Click" OnClientClick="if(!IsSelectedId()){alert('请选择审核项');return false;}else{return confirm('你确定要审核选中内容吗？')}"/>&nbsp;</div>
                    <div id="dvMassSet" runat="server" style="float: left">
                        <asp:Button ID="btnMassSet" runat="server" Text="批量设置" CssClass="btn" OnClick="btnMassSet_Click" />&nbsp;</div>
                    <div id="dvMassMove" runat="server" style="float: left">
                        <asp:Button ID="btnMassMove" runat="server" Text="批量移动" CssClass="btn" OnClick="btnMassMove_Click" />&nbsp;</div>
                    <div id="dvDeleteTotal" runat="server" style="float: left">
                        <asp:Button ID="btnDeleteAll" runat="server" Text="批量删除" OnClick="btnDeleteAll_Click"
                            OnClientClick="if(!IsSelectedId()){alert('请选择删除项');return false;}else{return confirm('你确定要将所有选择项放入回收站吗？')}"
                            CssClass="btn" UseSubmitBehavior="true" />&nbsp;</div>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" align="center" width="99%">
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="AspNetPager" runat="server" AlwaysShow="True" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager_PageChanging"
                        PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never"
                        CustomInfoSectionWidth="10%" ShowNavigationToolTip="True" Width="99%" HorizontalAlign="Right">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
        <!--内容搜索栏-->
        <table width="99%" cellpadding="0" cellspacing="1" class="border" align="center">
            <tr>
                <td width="80" height="26" align="right" bgcolor="f0f0f0">
                    <strong>内容搜索：</strong></td>
                <td bgcolor="f0f0f0">
                    <asp:DropDownList ID="ddlColId" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlsortName" runat="server">
                        <asp:ListItem Value="Title"></asp:ListItem>
                        <asp:ListItem Value="UName">录入者</asp:ListItem>
                        <asp:ListItem Value="AdminUName">审核人</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtKeyword" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:Button runat="server" ID="btnGoSearch" Text="搜 索" CssClass="btn" OnClick="btnGoSearch_Click"
                        OnClientClick="javascript:if($('txtKeyword').value==''){alert('请输入关键字');$('txtKeyword').focus();return false;}" /></td>
            </tr>
        </table>
        <!--文章底部分-->
    </form>
</body>
</html>
