<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetUser.aspx.cs" Inherits="System_user_SetUser" %>

<%@ Register Src="../../common/Linkage.ascx" TagName="Linkage" TagPrefix="uc2" %>

<%@ Register Src="../../common/CityList.ascx" TagName="CityList" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script src="../../JS/Common.js" type="text/javascript"></script>
    <script src="../../JS/InfoModel.js" type="text/javascript"></script>
    <script src="../../JS/RiQi.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td height="24" width="20">
                    <img src="../images/skin/default/you.gif" align="absmiddle" alt="您现在的位置" /></td>
                <td align="left" style="padding-top: 3px;">
                    您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> 用户管理 >> 新增<asp:Literal ID="ModelName"
                        runat="server"></asp:Literal><asp:TextBox ID="FilePicPath" runat="server" style="display:none">User|0</asp:TextBox></td>
                <td width="50" align="right">
                    <img src="../images/skin/default/help.gif" align="absmiddle" alt="帮助" /></td>
            </tr>
        </table>
        <table width="99%" cellspacing="1" cellpadding="0" class="border" align="center">
            <tr class="wzlist">
                <td align="left">
                   <asp:Repeater ID="RepUserGroupModel" runat="server">
                        <ItemTemplate>
                            <a href="SetUser.aspx?TypeId=<%# Eval("Id") %>">新增<%# Eval("Name") %></a> | 
                        </ItemTemplate>
                    </asp:Repeater>
                    <uc2:Linkage ID="Linkage1" runat="server" />
                 </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="99%" align="center" border="0" class="cd">
            <tbody>
                <tr align="center">
                    <td class="title6" id="TabTitle0" onclick="ShowTabs(0)">
                        基本信息</td>
                    <td class="title5" id="TabTitle1" onclick="ShowTabs(1)">
                        扩展信息</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </tbody>
        </table>
        <table width="99%" border="0" cellpadding="2" cellspacing="1" class="editborder"
            align="center">
            <tbody id="Tabs0">
                <tr>
                    <td class="bqleft">
                        所属用户组：</td>
                    <td class="bqright">
                        <asp:DropDownList ID="ddlistGroup" runat="server" Width="98px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        登录名：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtLogName" runat="server" MaxLength="18"></asp:TextBox><span style="color: Red;">*</span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        登录密码：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:Label ID="lbDot" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                </tr>
                <tr runat="server" id="DivCnfmPwd">
                    <td class="bqleft">
                        确认密码:</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtCnfmPwd" runat="server" TextMode="Password"></asp:TextBox>
                        <span style="color: Red;">*</span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        电子邮箱：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <span style="color: Red;">*</span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        提示问题：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtQuestion" runat="server" Width="267px"></asp:TextBox>
                        <span style="color: Red;">*</span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        提示答案：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtAnswer" runat="server" Width="268px" MaxLength="20"></asp:TextBox>
                        <span style="color: Red;">*</span></td>
                </tr>
                <tr>
                    <td class="bqleft">
                        隐私设定：</td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="txtSecret" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">公开</asp:ListItem>
                            <asp:ListItem Value="0">隐藏</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
            </tbody>
            <tbody id="Tabs1" style="display: none">
                <asp:Literal ID="ModelHtml" runat="server"></asp:Literal></tbody><tr>
                <td colspan="4" align="center" height="30">
                    <asp:Button ID="btnOk" runat="server" CssClass="btn" Text=" 添 加 " OnClick="btnOk_Click" />&nbsp;
                    <input id="Reset1" class="btn" type="reset"  value=" 取 消 " onclick="javascript:history.back();"  /></td>
            </tr>
        </table>
    </form>
</body>
</html>
<%if (Request.QueryString["uid"]!=null) {%>
<script>
   GetModelHtmlUser_User('<%=Request.QueryString["TypeId"] %>','<%=Request.QueryString["uid"] %>');
</script>
<%} %>