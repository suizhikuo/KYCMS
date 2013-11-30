<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResumeList.aspx.cs" Inherits="user_ResumeList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>简历列表</title>
    <link href="Css/default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
            <tr>
                <td width="20">
                    <img align="absMiddle" src="images/skin/default/you.gif" /></td>
                <td>
                    您现在的位置：<a href="welcome.aspx" target="ContentIframe">用户后台</a> &gt;&gt; 简历列表
                </td>
                <td align="right" width="50">
                </td>
            </tr>
        </table>
        <table align="center" cellpadding="0" cellspacing="1" class="border" width="99%">
            <tr class="title">
                <td>应聘者</td>
                <td>应聘时间</td>
                <td>状态</td>
                <td>常规操作</td>
            </tr>
            <asp:Repeater ID="rptHireInfo" runat="server" OnItemCommand="rptHireInfo_ItemCommand">
                <ItemTemplate>
                    <tr class="tdbg" onmouseover="this.className='tdbgmouseover'" onmouseout="this.className='tdbg'">
                        <td><a href='ViewResume.aspx?Id=<%#GetResumeId(Eval("Id")) %>' target="_blank"><%#Eval("UserName") %></a></td>
                        <td><%#Eval("AddTime") %></td>
                        <td><%#Eval("Status").ToString()=="1"?"未读":"已读"%></td>
                        <td><a href='ViewResume.aspx?Id=<%#GetResumeId(Eval("Id")) %>' target="_blank">查看简历</a>  <asp:LinkButton ID="lnkbtnDel" CommandArgument='<%#Eval("Id") %>' CommandName="Delete" OnClientClick="return confirm('是否删除此简历？');"
                                runat="server">删除</asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
         <table class="border" align="center">
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
    </div>
    </form>
</body>
</html>
