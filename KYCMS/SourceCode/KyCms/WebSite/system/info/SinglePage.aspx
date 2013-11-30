<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SinglePage.aspx.cs" Inherits="system_info_SinglePage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/default.css" rel="stylesheet" type="text/css" />
    <script src="../../JS/Common.js" type="text/javascript"></script>
</head>
<body>
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
        <tr>
            <td height="24" width="20">
                <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
            <td align="left" style="padding-top: 3px;">
                您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="ChannelList.aspx">内容管理</a>
                &gt;&gt; <a href="SinglePageList.aspx">单页管理</a> >>新增单页</td>
            <td width="50" align="right">
                <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
        </tr>
    </table>
    <form id="form1" runat="server">
        <table class="border" cellspacing="1" cellpadding="0" width="99%" border="0" align="center"
            runat="server" id="Table1">
            <tr class="tdbg">
                <td class="bqleft">
                    单页名称：
                </td>
                <td class="bqright"><asp:TextBox ID="txtName" runat="server"></asp:TextBox> <font color="red">*</font></td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    生成文件目录：
                </td>
                <td class="bqright"><asp:Literal ID="ParPath" runat="server"></asp:Literal>/
                    <asp:TextBox ID="txtFolderPath" MaxLength="50" runat="server" Columns="40"></asp:TextBox>&nbsp;
                    (如有下级目录，请用"/"隔开:upload/news/)</td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    生成文件名及后缀名：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtFileName" runat="server" Rows="6" ></asp:TextBox><asp:DropDownList
                        ID="txtFileExtend" runat="server">
                        <asp:ListItem>.html</asp:ListItem>
                        <asp:ListItem>.htm</asp:ListItem>
                        <asp:ListItem>.shtml</asp:ListItem>
                        <asp:ListItem>.shtm</asp:ListItem>
                        <asp:ListItem>.aspx</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    单页模板：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtTemplatePath" MaxLength="50" runat="server" Columns="50"></asp:TextBox><input type="button" value="...选择模板" onclick="WinOpenDialog('../Common/SelectTemplate.aspx?ControlId='+escape('txtTemplatePath')+'&StartPath='+escape('/Template'),650,480)"
                                    class="btn" /></td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                    单页描述：
                </td>
                <td class="bqright">
                    <asp:TextBox ID="txtContent" runat="server" Columns="45" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr class="tdbg">
                <td class="bqleft">
                </td>
                <td class="bqright" height="50">
                    <asp:Button ID="Button1" runat="server" Text=" 保 存 " CssClass="btn" OnClick="Button1_Click" />
                    &nbsp; &nbsp;
                    <asp:Button ID="Button2" runat="server"
                        Text=" 保存并生成 " CssClass="btn" OnClick="Button2_Click" />
                    &nbsp; &nbsp;
                    <input id="Button3" type="button" value=" 取 消 " class="btn" onclick="window.location.href='SinglePageList.aspx';" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
