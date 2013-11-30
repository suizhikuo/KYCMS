<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserCateList.aspx.cs" Inherits="User_News_UserCateList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员专栏列表管理</title>
    <link href="../Css/default.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../../js/XmlHttp.js"></script>

    <script type="text/javascript" src="../../js/Common.js"></script>

    <script language="javascript" type="text/javascript">
   
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27">
                    &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16" /></td>
                <td>
                    您现在的位置：<a href="../welcome.aspx">用户后台</a> &gt;&gt; 自建专栏列表
                    </td>
                <td width="116" align="center">
                    &nbsp;</td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr>
                <td style="width: 52%; background-color: #eef6fb">
               &nbsp; 
                    <asp:HyperLink ID="hlkBtnAddNews" runat="server" NavigateUrl="~/user/info/SetUserCate.aspx">新建专栏</asp:HyperLink></td>
            </tr>
        </table>
        <asp:GridView ID="gvInfoList" runat="server" AutoGenerateColumns="False" Width="99%"
            align="center" CellSpacing="1" GridLines="None" CssClass="border" OnRowDataBound="gvInfoList_RowDataBound"
            OnRowDeleting="gvInfoList_RowDeleting" DataKeyNames="UserCateId">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="UserCateId">
                    <ItemStyle Width="5%" CssClass="tc" />
                </asp:BoundField>
                <asp:BoundField HeaderText="专栏名称" DataField="CateName">
                    <ItemStyle Width="20%" CssClass="tc" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="所属模型">
                    <ItemTemplate>
                        <%#Eval("ModelName") %>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="专栏描述" DataField="Discription">
                    <ItemStyle Width="30%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlkUpdate" runat="server" Text="修改" NavigateUrl='<%# "SetUserCate.aspx?UCId="+Eval("UserCateId") %>'></asp:HyperLink>
                        <asp:LinkButton ID="lkBtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="删除" OnClientClick="return confirm('你确定删除该专栏吗？')"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="10%" CssClass="tc" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="title" Width="20px" />
            <PagerStyle CssClass="tc" />
            <RowStyle CssClass="tdbg" />
        </asp:GridView>
        <!--文章搜索栏-->
        <table width="99%" cellpadding="0" cellspacing="1" class="border" align="center">
            <tr>
                <td width="80" height="26" align="right" bgcolor="f0f0f0">
                    <strong>所属模型：</strong></td>
                <td bgcolor="f0f0f0">
                    <asp:DropDownList ID="ddlModelType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlModelType_SelectedIndexChanged">
                    </asp:DropDownList></td>
            </tr>
        </table>
        <!--文章底部分-->
    </form>
</body>
</html>
