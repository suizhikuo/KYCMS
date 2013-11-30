<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoList.aspx.cs" Inherits="user_enterprise_InfoList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<script type="text/javascript" src="../../JS/Common.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>公司信息列表</title>
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="22"><img src="../images/skin/default/you.gif" width="17" height="16"></td>
                <td>您现在的位置：<a href="../welcome.aspx">用户后台</a> &gt;&gt; 企业用户 &gt;&gt; 公司信息列表</td>
                <td width="116" align="center">
                    &nbsp;</td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr>
                <td style="width: 52%; background-color: #eef6fb">
                    &nbsp;
                    <asp:HyperLink ID="hlkBtnAddNews" runat="server" NavigateUrl="~/user/enterprise/AddInfo.aspx">新添信息</asp:HyperLink></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center" id="repTable">
            <tr class="title">
                <td align="center" height="20">
                    <strong>全选</strong></td>
                <td align="center" width="60%">
                    <strong>信息标题</strong></td>
                <td align="center" width="20%">
                    <strong>发布时间</strong></td>
                <td align="center" width="10%">
                    <strong>操作</strong></td>
            </tr>
            <asp:Repeater runat="server" ID="repEnterpriseInfoList" OnItemCommand="repEnterpriseInfoList_ItemCommand">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr align="center">
                        <td><asp:CheckBox ID="chkBoxDelete" runat="server"></asp:CheckBox>
                        </td>
                        <td align="left"><%#Eval("Title") %>
                        </td>
                        <td><%#Eval("AddTime") %>
                        </td>
                        <td><a href="AddInfo.aspx?Id=<%#Eval("Id") %>">修改</a>
                        <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("Id") %>' />
                        <asp:LinkButton ID="lkBtn" runat="server" OnClientClick="return confirm('你确定要删除此信息吗?');">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
       <div style="padding-left:5px;padding-top:5px "><asp:Button
                ID="btnDeleteChecked" runat="server" Text="删除选定的信息" CssClass="btn" 
                OnClientClick="return CheckDelete()" OnClick="btnDeleteChecked_Click" />&nbsp;
            <input type="checkbox" id="chkAll" onclick="ShowCheck(this)" /><label for="chkAll">全选</label></div> 
                
        <div style="clear: both">
           <table cellpadding="2" cellspacing="0" align="center" width="99%">
                    <tr>
                        <td height="30">
                            <webdiyer:AspNetPager ID="AspNetPager" runat="server" AlwaysShow="True" FirstPageText="首页"
                                LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager_PageChanging"
                                PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoSectionWidth="10%"
                                ShowNavigationToolTip="True" Width="99%" HorizontalAlign="Right" PageSize="20">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                </table>
            &nbsp;</div>
    </form>
</body>
</html>
<script>
function ShowCheck(o)
{
    var as=o.form.elements;
    for(var i=0;i<as.length;i++)
    {
        if(as[i].type.toLowerCase()=="checkbox" && as[i]!=o)
        {
            as[i].checked=o.checked;
        }
    }
}
function CheckDelete()
{
    var s = $("repTable").getElementsByTagName("INPUT");
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
   return confirm("你确定要删除所有选中项吗？");
}
</script>
