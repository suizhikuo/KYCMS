<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetUserCate.aspx.cs" Inherits="System_user_UserCate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>创建用户专栏</title>
    <link href="../Css/default.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../../JS/Common.js"></script>

    <script type="text/javascript" src="../../JS/XmlHttp.js"></script>

    <script type="text/javascript" language="javascript">
      function CheckValidate()
      {
            if($("txtCateName").value.trim().length==0)
            {
                alert("专栏名称必须填写");
                $("txtCateName").focus();
               return false; 
            }
            return true;
      }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="99%" cellspacing="0" cellpadding="0" class="wzdh" align="center">
            <tr>
                <td width="27">
                    &nbsp;<img src="../images/skin/default/you.gif" width="17" height="16"></td>
                <td>
                    您现在的位置： <a href="../welcome.aspx">用户后台</a> &gt;&gt; <a href="UserCateList.aspx">用户专栏管理</a >&gt;&gt; 创建专栏</td>
                <td width="116" align="center">
                    &nbsp;</td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="1" class="border" style="width: 99%" align="center">
            
            <tr bgcolor="#eef6fb">
                <td class="bqleft">
                    专栏名称:</td>
                <td style="width: 85%; color: #ff0000; text-align: left">
                    <asp:TextBox ID="txtCateName" runat="server" Text="" Width="286px" MaxLength="255"></asp:TextBox>*</td>
            </tr>
            <tr bgcolor="#eef6fb">
                <td class="bqleft">
                    用户名:</td>
                <td style="width: 85%; color: #ff0000; text-align: left">
                    <asp:Label ID="lbUserName" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr bgcolor="#eef6fb">
                <td class="bqleft">
                    专栏所属模型:</td>
                <td style="width: 85%; color: #ff0000; text-align: left">
                    <asp:DropDownList ID="ddlCateType" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr bgcolor="#eef6fb">
                <td class="bqleft">
                    专栏描述:</td>
                <td style="width: 85%; color: #ff0000; text-align: left">
                    <asp:TextBox ID="txtDiscription" runat="server" Height="92px" TextMode="MultiLine"
                        Width="510px"></asp:TextBox>500个字符以内</td>
            </tr>
            <tr bgcolor="#eef6fb">
                <td class="bqleft" style="height: 23px">
                </td>
                <td style="width: 85%; color: #ff0000; text-align: left; height: 23px;">
                    <asp:Button ID="btnSaveCate" runat="server" Text="保 存" CssClass="btn" OnClick="btnSaveCate_Click"
                        OnClientClick="return CheckValidate()" />
                    &nbsp;<input onclick="javascript:history.back();" value="取消" type="button" class="btn" />
                    <asp:Literal ID="ltMsg" runat="server"></asp:Literal></td>
            </tr>
        </table>
        <br />
    </form>
</body>
</html>
