<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserGroupModel.aspx.cs" Inherits="system_UserGroupModel_UserGroupModel" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../../js/Common.js"></script>

</head>
<body>
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
        <tr>
            <td height="24" width="20">
                <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
            <td align="left" style="padding-top: 3px;">
                您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href="UserGroupModelList.aspx">
                    用户注册模型管理</a> &gt;&gt; <asp:Literal ID="Literal1" runat="server">新增</asp:Literal>用户注册模型</td>
            <td width="50" align="right">
                <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
        </tr>
    </table>
    <form id="form1" runat="server">
        <table class="border" cellspacing="1" cellpadding="0" width="99%" border="0" align="center">
            <tr class="tdbg">
                <td class="bqleft">
                    用户注册模型名称：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtName" MaxLength="50" runat="server"></asp:TextBox><font color="#ff0066">*</font>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    表名：
                </td>
                <td class="bqright">
                    Ky_User_<asp:TextBox ID="txtTableName" runat="server" MaxLength="20"></asp:TextBox><font
                        color="#ff0066">*</font>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    描述：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtContent" Columns="50" Rows="4" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    注册验证码：
                </td>
                <td class="bqright">
                    <font color="#ff0066">
                        <asp:RadioButtonList ID="txtIsValidate" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="True">显示</asp:ListItem>
                            <asp:ListItem Selected="True" Value="False">不显示</asp:ListItem>
                        </asp:RadioButtonList></font></td>
            </tr>            
            <tr class="tdbg">
                <td class="bqleft">
                     开启手动编辑录入界面：
                </td>
                <td class="bqright">
                    <table>
                        <tr>
                            <td><asp:RadioButtonList ID="IsHtml" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="True">开启</asp:ListItem>
                                <asp:ListItem Selected="True" Value="False">关闭</asp:ListItem>
                    </asp:RadioButtonList></td>
                            <td>
                                <span style="color: #ff0066">*</span> 选择开启后，新增、编辑、删除任何字段后，都需要手动更改模型录入Html界面.</td>
                        </tr>
                    </table>
                    </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">指定用户空间：</td>
                <td class="bqright"><asp:DropDownList ID="SpaceTypeId" runat="server">
                    <asp:ListItem Value="1">个人用户空间</asp:ListItem>
                    <asp:ListItem Value="2">企业用户空间</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr class="tdbg">
                <td class="tdheight" colspan="2" align="center">
                    <asp:Button ID="btnSubmit" runat="server" Text=" 确  定 " CssClass="btn" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input
                        id="btnNo" type="button" value=" 取　消 " onclick="location.href='UserGroupModelList.aspx'"
                        class="btn" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
