<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PushCategoryList.aspx.cs"
    Inherits="system_other_PushCategoryList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>广告位列表</title>
    <link href="../css/default.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="../../js/Common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="PushCategoryList.aspx">广告管理 </a>>> 广告位列表</td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td>
                    <a href="setpushinfo.aspx">添加广告</a> | <a href="setpushcategory.aspx">添加广告位</a> | <a href="pushinfolist.aspx">广告列表</a> | <a href="PushCategoryList.aspx">广告位列表</a></td>
            </tr>
        </table>
        <table id="rtpTable" style="width: 99%" class="border" cellpadding="0" cellspacing="1"
            align="center">
            <asp:Repeater ID="rptAdCategory" runat="server" OnItemCommand="rptItemCommand" OnItemDataBound="rptItemDataBound">
                <HeaderTemplate>
                    <tr class="title">
                        <td>
                            选择</td>
                        <td>
                            编号</td>
                        <td>
                            名称</td>
                        <td>
                            调用方式
                        </td>
                        <td>
                            宽高</td>
                        <td>
                            显示</td>
                        <td>
                            状态</td>
                           <td>描述</td> 
                        <td>
                            常规操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdbg" onmouseout="this.className='tdbg'" onmouseover="this.className='tdbgmouseover'">
                        <td>
                            <asp:CheckBox ID="chkBox" runat="server" /></td>
                        <td>
                            <asp:Literal ID="LitId" runat="server" Text='<%#Eval("AdCategoryId") %>'></asp:Literal>
                        </td>
                        <td>
                            <a href="SetPushCategory.aspx?categoryId=<%#Eval("AdCategoryId") %>"><%#Eval("CategoryName") %></a>
                        </td>
                        <td>
                            <a href="#" onclick="WinOpenDialog('ShowJS.aspx?categoryId=<%#Eval("AdCategoryId") %>',600,200)">
                                查看</a> <a href='preview.aspx?categoryId=<%#Eval("AdCategoryId") %>' target="_blank">预览</a>
                        </td>
                        <td>
                            <%#SetWH(Eval("WidthHeigth")) %>
                        </td>
                        <td>
                            <asp:Literal ID="LitDisplayType" runat="server" Text='<%#Eval("DisplayType") %>'></asp:Literal>
                        </td>
                        <td>
                            <%#Eval("IsDisabled").ToString()=="1" ?"正常":"<span style='color:red'>禁用</span>" %>
                        </td>
                       <td><%#Eval("Description") %></td>
                        <td>
                        <asp:LinkButton ID="lnkbtnRefeshJs" runat="server" Text="刷新JS" CommandName="Refresh" CommandArgument='<%#Eval("AdCategoryId") %>'></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnDisable" runat="server" Text='<%#Eval("IsDisabled").ToString()=="1"?"禁用":"启用" %>'
                                CommandName="SetDisable" CommandArgument='<%#Eval("AdCategoryId")+"|"+Eval("IsDisabled") %>'></asp:LinkButton>
                            <a href="SetPushCategory.aspx?categoryId=<%#Eval("AdCategoryId") %>">修改</a>
                            <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClientClick="return confirm('是否删除此广告位?')"
                                CommandArgument='<%#Eval("AdCategoryId") %>' CommandName="Delete">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table class="border" cellpadding="0" cellspacing="1" align="center">
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" CustomInfoSectionWidth="10%"
                        FirstPageText="首页" HorizontalAlign="Right" LastPageText="尾页" NextPageText="下一页"
                        OnPageChanging="Pager_PageChanging" PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left"
                        ShowInputBox="Never" ShowNavigationToolTip="True" Width="99%">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
        <input id="chk" type="checkbox" onclick="SelectAll('chk','rtpTable')" />全选
        <asp:Button ID="btnDelete" runat="server" Text="删除所选项" OnClientClick="return confirm('是否删除所选项?');"
            CssClass="btn" OnClick="btnDelete_Click" />
    </form>
</body>
</html>


