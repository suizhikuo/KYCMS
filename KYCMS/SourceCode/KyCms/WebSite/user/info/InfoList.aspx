<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoList.aspx.cs" Inherits="User_Info_InfoList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员内容列表管理</title>
    <link href="../Css/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/Common.js"></script>

 <script language="javascript" type="text/javascript">
 function SetCheckBox()
 {
    if($("gvInfoList")==null) 
        return; 
    var s = $("gvInfoList").getElementsByTagName("INPUT")
    for(var i=0;i<s.length;i++)
    {
       if(s[i].type=="checkbox"&&s[i].disabled==false)
       {
            s[i].checked=$("chkBoxChooseAll").checked; 
       }
    }
 }
function CheckDelete()
{
    var s = $("gvInfoList").getElementsByTagName("INPUT");
    var flag = false;
    for(var i=0;i<s.length;i++)
    {
        if(s[i].type=="checkbox")
        {
            if(s[i].checked)
            {
                flag = true;
            } 
        }
    }
    if(!flag)
   {
        alert("请选择删除项");
        return false; 
   }  
   return confirm("你确定要将所有选择项放入回收站吗？");
}
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27">
                    &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" /></td>
                <td>
                    您现在的位置： <a href='../Welcome.aspx'>用户后台</a> &gt;&gt; 会员稿件列表管理 &gt;&gt; [<%=ChannelModel.ChName %>]稿件</td>
                <td width="116" align="center">
                    &nbsp;</td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr>
                <td style="width: 52%; background-color: #eef6fb">
                    &nbsp;<asp:HyperLink ID="hylnkSetInfo" runat="server">添加稿件</asp:HyperLink>
                    | <a href='InfoList.aspx?ChId=<%=ChId %>&Status=all'>所有稿件</a>
                    | <a href='InfoList.aspx?ChId=<%=ChId %>&Status=rec'>草稿箱</a>
                    | <a href='InfoList.aspx?ChId=<%=ChId %>&Status=wait'>待审核的内容</a>
                    | <a href='InfoList.aspx?ChId=<%=ChId %>&Status=yes'>已审核</a>
                    | <a href='InfoList.aspx?ChId=<%=ChId %>&Status=no'>未被采纳</a>
                </td>
                <td style="width: 7%; text-align: center; vertical-align: middle; background-color: #eef6fb;
                    height: 24px;">
                </td>
            </tr>
        </table>
        <asp:GridView ID="gvInfoList" runat="server" AutoGenerateColumns="False" Width="99%"
            GridLines="None" class="border" align="center" CellSpacing="1" OnRowDataBound="gvInfoList_RowDataBound"
            OnRowDeleting="gvInfoList_RowDeleting" DataKeyNames="Id" OnRowCommand="gvInfoList_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="全选">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkBoxChooseInfo" runat="server" BackColor="White" BorderStyle="None" Enabled= '<%# GetDeleteAndPublishStatus(Eval("Status"))%>'/>
                    </ItemTemplate>
                    <ItemStyle Width="32px" CssClass="tc" />
                    <HeaderTemplate>
                        <asp:Label ID="lbChooseAll" runat="server" Text="全选"></asp:Label>
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="ID" DataField="Id">
                    <ItemStyle Width="38px" CssClass="tc" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="hlkTitle" runat="server" Text='<%# InfoTitle(Eval("Title"),Eval("TitleType")) %>'
                            ToolTip='<%#Eval("Title") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle CssClass="tl" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="发布时间">
                <ItemTemplate>
              <%#Eval("AddTime","{0:yyyy-MM-dd HH:ss}") %> 
                </ItemTemplate> 
                </asp:TemplateField> 
               
                <asp:TemplateField HeaderText="审核状态">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lbShowStatus" Text='<%#Eval("Status") %>' Visible="false"></asp:Label>
                        <asp:Label ID="lbStatus" runat="server" Text='<%# ChangeStatus(Eval("Status")) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="tc" Width="60px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                    <ItemTemplate>
                        <%# IsAllowUpdate(Eval("Status"), Eval("Id"),Eval("ChId"),Eval("ColId"))%>
                        <asp:LinkButton ID="lkBtnDelete" runat="server" CausesValidation="False" CommandName="Delete" Visible='<%# GetDeleteAndPublishStatus(Eval("Status"))%>' Text="删除" OnClientClick="return confirm('你确定要删除该稿件草稿吗？')"></asp:LinkButton>
                        <asp:LinkButton ID="lkBtnSet" runat="server" CausesValidation="false" CommandName="UserPublished"
                            CommandArgument='<%#Eval("Id") %>' Text="发布" Visible='<%# GetDeleteAndPublishStatus(Eval("Status"))%>'
                            OnClientClick="return confirm('你确定发布此草稿吗?')"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="90px" CssClass="tl" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="title" Width="20px" />
            <PagerStyle CssClass="tc" />
            <RowStyle CssClass="tdbg" />
        </asp:GridView>
        <div>
            <div style="padding-left: 5px" class="fl">
                &nbsp;&nbsp;<input type='checkbox' onclick="SetCheckBox()" id="chkBoxChooseAll" /><label
                    for="chkBoxChooseAll">全选</label></div>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDeleteAll" runat="server" Text="批量删除" OnClick="btnDeleteAll_Click"
                OnClientClick="return CheckDelete()" CssClass="btn" UseSubmitBehavior="true" /><div
                    id="dvDeleteTotal" runat="server" class="fl">
                </div>
        </div>
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
        <!--文章搜索栏-->
        <table width="99%" cellpadding="0" cellspacing="1" class="border" align="center">
            <tr>
                <td width="80" height="26" align="right" bgcolor="f0f0f0">
                    <strong>文章搜索：</strong></td>
                <td bgcolor="f0f0f0">
                    <asp:DropDownList ID="ddlUserCate" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlsortName" runat="server">
                        <asp:ListItem Value="Title"></asp:ListItem>
                        <asp:ListItem Value="AdminUName">审核人</asp:ListItem>
                        <asp:ListItem Value="AddTime">添加时间</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtKeyword" runat="server" Height="15px" MaxLength="50"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" CommandName="SearchNews" CssClass="btn"
                        OnClick="btnSearch_Click" Text="搜 索" OnClientClick="javascript:if($('txtKeyword').value==''){alert('请输入关键字');$('txtKeyword').focus();return false;}" /></td>
            </tr>
        </table>
        <asp:Label ID="lbMessageBox" runat="server" Visible="False"></asp:Label>
    </form>
</body>
</html>
