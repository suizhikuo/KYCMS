<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpLoadFile.aspx.cs" Inherits="common_UpLoadFile" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上传文件</title>
    <link href="../user/css/default.css" type="text/css" rel="stylesheet" />
    <base target="_self"></base>
    <script type="text/javascript" src="../js/Common.js"></script>
    <script language="javascript">
    function isok()
    {
        if(document.form1.File1.value=="")
        {
            alert("请选择需要上传的文件")
            document.form1.File1.focus();
            return false;
        }
        return true;
    }
    </script>
</head>
<body onload="setxx()" style="margin:0px">
    <form id="form1" runat="server">
        <table width="100%" align="center" cellpadding="6">
            <tr>
                <td>
                    <asp:TextBox ID="File_PicPath" runat="server" style="display:none"></asp:TextBox>
                    <table width="400" cellpadding="4" cellspacing="0" border="0" align="center">
                        <tr>
                            <td colspan="2">
                                选择文件：<input id="File1" type="file" size="29" name="File1" runat="server" class="btn">
                                <asp:Button ID="Button1" runat="server" Text=" 上传 " Height="22px" onmousedown="isok()" OnClick="Button1_Click" CssClass="btn" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
<script>
function setxx()
{
  $('File_PicPath').value = dialogArguments.document.form1.FilePicPath.value
}
</script>