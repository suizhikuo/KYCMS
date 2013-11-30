<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserGroupModelPreView.aspx.cs" Inherits="system_UserGroupModel_UserGroupModelPreView" %>

<%@ Register Src="../../common/Linkage.ascx" TagName="Linkage" TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../Css/default.css" rel="stylesheet" type="text/css" />

    <script src="../../JS/XmlHttp.js" type="text/javascript"></script>

    <script src="../../JS/Common.js" type="text/javascript"></script>

    <script src="../../JS/RiQi.js" type="text/javascript"></script>

    <script src="../../JS/InfoModel.js" type="text/javascript"></script>
</head>
<body>
    <table width="99%" cellspacing="1" cellpadding="0" class="wzdh" align="center">
        <tr>
            <td height="24" width="20">
                <img src="../images/skin/default/you.gif" align="absmiddle" /></td>
            <td align="left" style="padding-top: 3px;">
                您现在的位置：<a href="../SystemInfo.aspx">后台管理</a> >> <a href="UserGroupModelList.aspx">用户注册模型列表</a> >>  <a href="UserGroupModelFieldList.aspx?ModelId=<%=Request.QueryString["ModelId"] %>">字段列表</a>
                >> 用户注册模型浏览<uc1:Linkage ID="Linkage1" runat="server" />
            </td>
            <td width="50" align="right">
                <img src="../images/skin/default/help.gif" align="absmiddle" /></td>
        </tr>
    </table>
    <form id="form1" runat="server">
    <table class="border" cellspacing="1" cellpadding="0" width="99%" border="0" align="center"><asp:TextBox ID="FilePicPath" runat="server" style="display:none">User|0</asp:TextBox>
            <asp:Literal ID="ModelHtml" runat="server"></asp:Literal><tr>
                <td class="bqleft" height="50"></td>
                <td class="bqright">
                    <input id="Button1" class="btn" type="button" value=" 返 回 " onclick="javascript:window.history.back()" /></td>
            </tr>
     </table>
    </form>
</body>
</html>
