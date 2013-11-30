<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomForm.aspx.cs" Inherits="system_infomodel_CustomForm" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/default.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../../js/Common.js"></script>
    <script src="../../JS/RiQi.js" type="text/javascript"></script>

</head>
<body>
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
        <tr>
            <td height="24" width="20">
                <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
            <td align="left" style="padding-top: 3px;">
                您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> &gt;&gt; <a href="CustomFormList.aspx">
                    表单管理</a> &gt;&gt; <asp:Literal ID="Literal1" runat="server">新增</asp:Literal>表单</td>
            <td width="50" align="right">
                <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
        </tr>
    </table>
    <form id="form1" runat="server">
        <table class="border" cellspacing="1" cellpadding="0" width="99%" border="0" align="center">
            <tr class="tdbg">
                <td class="bqleft">
                    表单显示控制：
                </td>
                <td class="bqright">
                    <asp:RadioButtonList ID="txtShowForm" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="0">系统前台可见</asp:ListItem>
                        <asp:ListItem Value="1">会员后台可见</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    表单名称：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtFormName" MaxLength="50" runat="server"></asp:TextBox><font color="#ff0066">*</font>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    表名：
                </td>
                <td class="bqright">
                    Ky_Form_<asp:TextBox ID="txtTableName" runat="server" MaxLength="20"></asp:TextBox><font
                        color="#ff0066">*</font>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    上传附件存放目录：
                </td>
                <td class="bqright">
                    upload/<asp:TextBox ID="txtUploadPath" runat="server" MaxLength="50" Columns="12"></asp:TextBox> <font
                        color="#ff0066">*</font>（只能以字母开头，由字母或数字组成，如修改此设置请手动修改对应文件夹名称）
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    允许上传的文件大小：
                </td>
                <td class="bqright">
                    只能上传小于或等于<asp:TextBox ID="txtUploadSize" runat="server" MaxLength="15" Text="0"></asp:TextBox>KB的文件（0KB表示不限制）<font
                        color="#ff0066">*</font>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    表单描述：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtFormDesc" Columns="50" Rows="4" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    启用时间限制：
                </td>
                <td class="bqright">
                    <font color="#ff0066">
                        <asp:RadioButtonList ID="txtIsUnlockTime" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="True">启用</asp:ListItem>
                            <asp:ListItem Selected="True" Value="False">不启用</asp:ListItem>
                        </asp:RadioButtonList></font></td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    开始时间：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtStartTime" MaxLength="50" runat="server" onblur="setday(this)" onclick="setday(this)"></asp:TextBox><font color="#ff0066">*</font>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    结束时间：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtEndTime" MaxLength="50" runat="server" onblur="setday(this)" onclick="setday(this)"></asp:TextBox><font color="#ff0066">*</font>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    指定用户组提交：
                </td>
                <td class="bqright">
                    <asp:CheckBoxList ID="UserGroupList" runat="server" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    每个用户只允许提交一次：
                </td>
                <td class="bqright">
                        <asp:RadioButtonList ID="txtIsSubmitNum" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="True">限制</asp:ListItem>
                            <asp:ListItem Selected="True" Value="False">不限制</asp:ListItem>
                        </asp:RadioButtonList></td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft" style="height: 26px">
                    金币设置：
                </td>
                <td class="bqright" style="height: 26px">
                    <asp:TextBox ID="txtMoney" MaxLength="5" runat="server" Columns="5">0</asp:TextBox>
                    如需要扣除5个金币请设置为-5，不设置请为0</td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    显示验证码：
                </td>
                <td class="bqright">
                    <font color="#ff0066">
                        <asp:RadioButtonList ID="txtIsValidate" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="True">显示</asp:ListItem>
                            <asp:ListItem Selected="True" Value="False">不显示</asp:ListItem>
                        </asp:RadioButtonList></font></td>
            </tr>
            <tr class="tdbg">
                <td class="tdheight" colspan="2" align="center">
                    <asp:Button ID="btnSubmit" runat="server" Text=" 确  定 " CssClass="btn" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input
                            id="btnNo" type="button" value=" 取　消 " onclick="location.href='CustomFormList.aspx'"
                            class="btn" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
