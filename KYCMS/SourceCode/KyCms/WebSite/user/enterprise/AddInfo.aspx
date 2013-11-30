<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddInfo.aspx.cs" Inherits="user_Enterprise_AddInfo" %>
<%@ Import Namespace="Ky.Common" %>

<script type="text/javascript" src="../../JS/Common.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加公司信息</title>
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
           <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="20" ><img src="../images/skin/default/you.gif" width="17" height="16"></td>
                <td>您现在的位置：<a href="../welcome.aspx">用户后台</a> &gt;&gt; 企业用户 &gt;&gt; 添加公司信息</td>
                <td width="116" align="center">
                    &nbsp;</td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
            <tr>
                <td colspan="2" class="title">
                    添加公司信息</td>
            </tr>
            <tr>
                <td class="bqleft">
                    信息标题:</td>
                <td class="bqright" >
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                    </td>
            </tr>
           <tr>
                <td class="bqleft">
                    所属类别:</td>
                <td class="bqright" >
               <asp:DropDownList ID="ddlTypeId"  runat="server">
                    </asp:DropDownList>
                    </td>
            </tr> 
           <tr>
                <td class="bqleft">
                    信息内容:</td>
                <td class="bqright" ><asp:TextBox ID="FilePicPath" runat="server" Text="user|0" Style="display: none"></asp:TextBox>
                <div><asp:TextBox ID="txtContent" runat="server" style="display:none"></asp:TextBox><input type="hidden" id="txtContent___Config" value="" /><iframe id="txtContent___Frame" src="<%=Param.ApplicationRootPath %>/editor/fckeditor_3.html?InstanceName=txtContent&amp;Toolbar=Default" width="100%" height="300px" frameborder="no" scrolling="no"></iframe></div>
                    </td>
            </tr>
           <tr>
                <td class="bqright">
                    </td>
                <td class="bqright"><asp:Button ID="btnSaveAs" runat="server" Text=" 添 加 " CssClass="btn"
                        OnClientClick="return CheckValidate()" OnClick="btnSaveAs_Click" /> <input type="button" id="btnCanCel" name="btnCanCel" value="取 消" class="btn" onclick="javascript:history.back();" />
                    </td>
            </tr> 
        </table>

    </form>
</body>
</html>
<script language="javascript">
function CheckValidate()
{
    if($("txtTitle").value.trim().length==0)
    {
        alert("标题必须填写");
        $("txtTitle").focus();
        return false;
    }

}
</script>
